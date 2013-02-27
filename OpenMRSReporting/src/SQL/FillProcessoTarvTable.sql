set sql_mode='';
DELIMITER $$

DROP PROCEDURE IF EXISTS FillProcessoTARVTable $$
CREATE PROCEDURE FillProcessoTARVTable(dataFinal date,monthreport smallint(1))
    READS SQL DATA
begin

declare horas int default 0;

select hour(timediff(now(),data_hora)) into horas from hora_processo;
if ((horas>2) or (monthreport=1)) then
	truncate table openmrsreporting.processo_tarv;

	/*Abertura de Processo*/
	insert into openmrsreporting.processo_tarv(patient_id,data_abertura,location_id,location_name,birthdate,gender,dead,death_date,idade_abertura,idade_actual)
	Select 	distinct	encounter.patient_id,min(encounter_datetime),location.location_id,location.name,birthdate,gender,dead,death_date,
			round(datediff(encounter.encounter_datetime,person.birthdate)/365) idade_abertura,
			round(datediff(curdate(),person.birthdate)/365) idade_actual
	from 	openmrs.encounter 
			inner join openmrs.patient on encounter.patient_id=patient.patient_id
			inner join openmrs.person on person.person_id=patient.patient_id
			inner join openmrs.location on encounter.location_id=location.location_id
	where 	patient.voided=0 and encounter_type in (5,7) and encounter.voided=0 and person.voided=0
	group by patient_id;


	/*Inicio TARV*/
	update openmrsreporting.processo_tarv,
	(Select p.patient_id,
		min(e.encounter_datetime) data_tarv,
		if(o.value_coded=1256,'INICIO','TRANSFERIDO DE') formainicio,
		o.value_coded
	from 	openmrsreporting.processo_tarv p 
		inner join openmrs.encounter e on p.patient_id=e.patient_id	
		inner join openmrs.obs o on o.encounter_id=e.encounter_id
	where 	e.voided=0 and o.voided=0 and
		e.encounter_type=18 and o.concept_id=1255 and o.value_coded in (1256,1369)
	group by p.patient_id) inicio

	set processo_tarv.data_inicio=inicio.data_tarv,
		processo_tarv.forma_inicio=inicio.formainicio,
		processo_tarv.forma_inicio_concept_id=inicio.value_coded
	where processo_tarv.patient_id=inicio.patient_id;



	/*REINICIO TARV*/
	update openmrsreporting.processo_tarv,
	(Select p.patient_id,
		max(e.encounter_datetime) data_reinicio,
		'REINICIO' as  forma_reinicio,
		o.value_coded
	from 	openmrsreporting.processo_tarv p 
		inner join openmrs.encounter e on p.patient_id=e.patient_id	
		inner join openmrs.obs o on o.encounter_id=e.encounter_id
	where 	e.voided=0 and o.voided=0 and e.encounter_datetime<dataFinal and 
		e.encounter_type=18 and o.concept_id=1255 and o.value_coded=1705
	group by p.patient_id) reinicio

	set processo_tarv.data_reinicio=reinicio.data_reinicio,
		processo_tarv.forma_reinicio=reinicio.forma_reinicio,
		processo_tarv.forma_reinicio_concept_id=reinicio.value_coded
	where processo_tarv.patient_id=reinicio.patient_id;


	/*Estado Actual*/
	update openmrsreporting.processo_tarv,
	(select obs.person_id, 
			concept_name.name,
			obs.obs_datetime,
			concept_name.concept_id
	from 	openmrs.obs 
			inner join 
			(	select encounter_id,data_ultima_frida.encounter_datetime,data_ultima_frida.patient_id
				from 	openmrs.encounter,
						(	select patient.patient_id,max(encounter_datetime) as encounter_datetime
							from openmrs.encounter inner join openmrs.patient on patient.patient_id=encounter.patient_id
							where 	encounter_type=18 and encounter.voided=0 and patient.voided=0 and encounter_datetime<=dataFinal
							group by patient_id
						) data_ultima_frida
				where 	encounter.encounter_datetime=data_ultima_frida.encounter_datetime and encounter.encounter_type=18 and
					data_ultima_frida.patient_id=encounter.patient_id and encounter.voided=0
			) id_ultimo_levantamento on obs.encounter_id=id_ultimo_levantamento.encounter_id
			inner join openmrs.concept_name on concept_name.concept_id=obs.value_coded
			
	where 	concept_name.locale='pt' and 
			obs.concept_id=1708 and obs.voided=0) saida 
			
	set 	processo_tarv.estado_actual=saida.name,
			processo_tarv.data_estado=saida.obs_datetime,
			processo_tarv.estado_concept_id=saida.concept_id
	where saida.person_id=processo_tarv.patient_id;

	/*Ultimo Levantamento ARV*/
	update openmrsreporting.processo_tarv,
	(select 	p.patient_id,max(encounter_datetime) as encounter_datetime
	from 	openmrs.encounter e 
		inner join openmrsreporting.processo_tarv p on p.patient_id=e.patient_id 
		inner join openmrs.obs o on o.encounter_id=e.encounter_id 		
	where 	encounter_type=18 and e.voided=0 and  o.voided=0 and 
			o.concept_id=1255 and o.value_coded<>1708 and encounter_datetime<=dataFinal
	group by p.patient_id) ultimo
	set ultimo_levantamento=encounter_datetime
	where ultimo.patient_id=processo_tarv.patient_id;

	/*DATA PROXIMO Levantamento*/
	update openmrsreporting.processo_tarv,

	(	select 	p.patient_id,e.encounter_datetime,o.value_datetime
		from 	openmrs.encounter e 
			inner join openmrsreporting.processo_tarv p on p.patient_id=e.patient_id 
			inner join openmrs.obs o on o.encounter_id=e.encounter_id 		
		where 	e.encounter_type=18 and e.voided=0 and o.voided=0 and  
			e.encounter_datetime <= dataFinal and o.concept_id=5096 and 
			e.encounter_datetime=p.ultimo_levantamento
		) proximo
	set 	processo_tarv.data_proximo=value_datetime
	where proximo.patient_id=processo_tarv.patient_id;

	/*Update NID*/
	update openmrsreporting.processo_tarv,
	(select 	p.patient_id,pd.identifier
	from 	openmrs.patient_identifier pd 
		inner join openmrsreporting.processo_tarv p on p.patient_id=pd.patient_id 		
	where 	pd.identifier_type=2 and pd.voided=0) nid
	set processo_tarv.nid=nid.identifier
	where nid.patient_id=processo_tarv.patient_id;


	/*Update NOME*/
	update openmrsreporting.processo_tarv,
	(select 	p.patient_id,concat(given_name,' ',middle_name,' ',family_name) nome
	from 	openmrs.person_name pn 
		inner join openmrsreporting.processo_tarv p on p.patient_id=pn.person_id 		
	where 	pn.voided=0) name
	set processo_tarv.nome=name.nome
	where name.patient_id=processo_tarv.patient_id;

	/*Endereco*/
	update openmrsreporting.processo_tarv,
	(select 	p.patient_id,county_district,region,subregion,address1
	from 	openmrs.person_address pa 
		inner join openmrsreporting.processo_tarv p on p.patient_id=pa.person_id 		
	where 	pa.voided=0) endereco
	set 	processo_tarv.distrito=county_district,
		processo_tarv.localidade=region,
		processo_tarv.bairro=subregion,
		processo_tarv.ponto_referencia=address1
	where endereco.patient_id=processo_tarv.patient_id;


	/*Ultima Visita*/
	update 
		openmrsreporting.processo_tarv,
		(	Select p.patient_id,max(encounter_datetime) encounter_datetime
			from 	openmrs.patient p 
					inner join openmrs.encounter e on e.patient_id=p.patient_id
			where 	p.voided=0 and e.voided=0 and e.encounter_datetime<=dataFinal
			group by p.patient_id 
		) ultimavisita
	set 	processo_tarv.ultima_visita=ultimavisita.encounter_datetime
	where	processo_tarv.patient_id= ultimavisita.patient_id;

	/*Ultima Visita Visitante TARV*/
	update 	openmrsreporting.processo_tarv,
			(	select 	p.patient_id,max(encounter_datetime) as encounter_datetime
				from 	openmrs.encounter e 
						inner join openmrs.patient p on p.patient_id=e.patient_id 		
				where 	e.voided=0 and p.voided=0 and e.encounter_type in (9,6) and 
						e.encounter_datetime<=dataFinal
				group by p.patient_id
			) ultimavisita
	set 	processo_tarv.ultima_visita_seguimento=ultimavisita.encounter_datetime
	where ultimavisita.patient_id=processo_tarv.patient_id;


	/*DATA PROXIMA VISITA SEGUIMENTO MARCADO NA ULTIMA VISITA*/
	update 	openmrsreporting.processo_tarv,
			(	select 	p.patient_id,e.encounter_datetime,o.value_datetime
				from 	openmrs.encounter e 
						inner join openmrsreporting.processo_tarv p on p.patient_id=e.patient_id 
						inner join openmrs.obs o on o.encounter_id=e.encounter_id 		
				where 	e.encounter_type in (9,6) and e.voided=0 and  o.voided=0 and 
						e.encounter_datetime <= dataFinal and o.concept_id=1410 and 
						e.encounter_datetime=p.ultima_visita_seguimento
			) proximo
	set 	processo_tarv.proxima_visita=value_datetime
	where proximo.patient_id=processo_tarv.patient_id;

	/*TRINTA DIAS MAIS EM RELACAO A DATA PROXIMA MARCADA - SEGUIMENTO*/
	update openmrsreporting.processo_tarv
	set proxima_mais30=date_add(proxima_visita, interval 30 day)
	where proxima_visita is not null;

	/*60 DIAS MAIS EM RELACAO A DATA PROXIMA MARCADA - SEGUIMENTO*/
	update openmrsreporting.processo_tarv
	set proxima_mais2=date_add(proxima_visita, interval 60 day)
	where proxima_visita is not null;

	/*Idade Inicio*/

	update openmrsreporting.processo_tarv set idade_inicio=round(datediff(data_inicio,birthdate)/365) where data_inicio is not null;

	/*Update Ultima Busca*/
	update openmrsreporting.processo_tarv,
		(Select 	patient_id,max(encounter_datetime) encounter_datetime
		from 	openmrs.encounter
		where 	voided=0 and encounter_datetime<=dataFinal and encounter_type=21
		group by patient_id) busca
	set processo_tarv.data_busca=busca.encounter_datetime
	where busca.patient_id=processo_tarv.patient_id;

	update hora_processo set data_hora=now();

	/*ULTIMO CD4*/
	update openmrsreporting.processo_tarv,
	(select obs.person_id, obs.concept_id,obs.value_numeric,obs.obs_datetime
		from 	openmrs.obs,
			(	select encounter_id,d.encounter_datetime
				from 	openmrs.encounter,
						(	select 	patient.patient_id,max(encounter_datetime) as encounter_datetime
							from 	openmrs.encounter
									inner join openmrs.patient on patient.patient_id=encounter.patient_id
									inner join openmrs.obs on obs.encounter_id=encounter.encounter_id
							where 	encounter_type=13 and encounter.voided=0 and
									encounter_datetime <=dataFinal
									and patient.voided=0 and obs.voided=0
									and obs.concept_id=5497
							group by patient_id
						) d
				where 	encounter.encounter_datetime=d.encounter_datetime and encounter.encounter_type=13 and 
						d.patient_id=encounter.patient_id and encounter.voided=0
			) e
		where 	obs.encounter_id=e.encounter_id and
				obs.concept_id=5497 and obs.voided=0) cd4
	set processo_tarv.ultimo_cd4=cd4.value_numeric,
		processo_tarv.data_cd4=cd4.obs_datetime
	where processo_tarv.patient_id=cd4.person_id;


	update openmrsreporting.processo_tarv,
			(	select 	patient_id,max(encounter_datetime) data_consentimento
				from 	openmrs.encounter
				where 	encounter_type=30 and voided=0
				group by patient_id
			) consentimento
	set 	processo_tarv.data_consentimento=consentimento.data_consentimento
	where 	processo_tarv.patient_id=consentimento.patient_id;


	/*ULTIMO CD4 MAIS 8 MESES*/

	update 	openmrsreporting.processo_tarv 
	set 	ultimocd4_mais8=date_add(data_cd4, interval 8 month)
	where	data_cd4 is not null; 


	/*DATA USAR - COM CD4 e SEGUIMENTO*/
	update 	openmrsreporting.processo_tarv 
	set 	data_usar=if(ultimocd4_mais8>proxima_mais2,ultimocd4_mais8,proxima_mais2)
	where	ultimocd4_mais8 is not null and proxima_mais2 is not null;

	/*DATA USAR - COM CD4 e SEM SEGUIMENTO*/
	update 	openmrsreporting.processo_tarv 
	set 	data_usar=ultimocd4_mais8
	where	ultimocd4_mais8 is not null and proxima_mais2 is null;

	/*DATA USAR - SE CD4 e COM SEGUIMENTO*/
	update 	openmrsreporting.processo_tarv 
	set 	data_usar=proxima_mais2
	where	ultimocd4_mais8 is null and proxima_mais2 is not null;

	/*DATA USAR - SEM CD4 e SEM SEGUIMENTO*/
	update 	openmrsreporting.processo_tarv 
	set 	data_usar=date_add(ultima_visita, interval 2 month)
	where	ultimocd4_mais8 is null and proxima_mais2 is null;

	/*DECISAO*/
	update 	openmrsreporting.processo_tarv 
	set 	situacao=if(data_usar>=dataFinal,0,1);

	/*TERMO DE CONSENTIMENTO*/
	update openmrsreporting.processo_tarv,
			(	select 	patient_id,max(encounter_datetime) data_consentimento
				from 	openmrs.encounter
				where 	encounter_type=30 and voided=0
				group by patient_id
			) consentimento
	set 	processo_tarv.data_consentimento=consentimento.data_consentimento
	where 	processo_tarv.patient_id=consentimento.patient_id;


	/*INICIO TB*/
	update openmrsreporting.processo_tarv,
	(	Select 	p.patient_id,
				max(e.encounter_datetime) data_inicio_tb
		from 	openmrsreporting.processo_tarv p 
				inner join openmrs.encounter e on p.patient_id=e.patient_id	
				inner join openmrs.obs o on o.encounter_id=e.encounter_id
		where 	e.voided=0 and o.voided=0 and e.encounter_datetime<dataFinal and 
				o.concept_id=1268 and o.value_coded=1256
		group by p.patient_id
	) inicio
	set processo_tarv.data_inicio_tb=inicio.data_inicio_tb
	where processo_tarv.patient_id=inicio.patient_id;

/*Proveniencia*/
	update openmrsreporting.processo_tarv,
	(	Select	p.patient_id,
				o.value_coded
		from 	openmrsreporting.processo_tarv p 
				inner join openmrs.encounter e on p.patient_id=e.patient_id	
				inner join openmrs.obs o on o.encounter_id=e.encounter_id
		where 	e.voided=0 and o.voided=0 and
				e.encounter_type in (5,7) and o.concept_id=1594
		group by p.patient_id) proveniencia 
	set processo_tarv.proveniencia_concept_id=proveniencia.value_coded		
	where processo_tarv.patient_id=proveniencia.patient_id;

	call MANAGERGRAVIDATRACK();

end if;

end $$

DELIMITER ;