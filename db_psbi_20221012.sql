
use psbi_lab


if not exists (select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where COLUMN_NAME = 'AS2_Q7_2a')
alter table form1 add AS2_Q7_2a varchar(50)


alter table sample_result alter column CS_09_a varchar(max)
alter table sample_result alter column CS_10_a varchar(max)
alter table sample_result alter column LA_17 varchar(max)
alter table sample_result alter column LA_18 varchar(max)
alter table sample_result alter column LA_19 varchar(max)

alter table sample_result alter column UR_01_a varchar(max)
alter table sample_result alter column UR_02_a varchar(max)
alter table sample_result alter column UR_19_a varchar(max)
alter table sample_result alter column UR_20_a varchar(max)
alter table sample_result alter column UR_21_a varchar(max)
alter table sample_result alter column LA_16_a varchar(max)


if not exists (select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where COLUMN_NAME = 'uc_01_ca')
alter table sample_result add uc_01_ca varchar(max)

alter table sample_result alter column UR_15_a varchar(max)
alter table sample_result alter column UR_16_a varchar(max)
alter table sample_result alter column UR_17_a varchar(max)
alter table sample_result alter column UR_18_a varchar(max)
alter table sample_result alter column UR_19_a varchar(max)
alter table sample_result alter column UR_20_a varchar(max)


