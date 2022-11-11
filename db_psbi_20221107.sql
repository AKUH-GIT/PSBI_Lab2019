
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


if not exists (select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where COLUMN_NAME = 'UR_04a_a')
alter table sample_result add UR_04a_a varchar(20)


if not exists (select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where COLUMN_NAME = 'UR_04a')
alter table sample_result add UR_04a varchar(20)



alter table sample_result alter column UR_12_a varchar(max)
alter table sample_result alter column UR_13_a varchar(max)
alter table sample_result alter column UR_14_a varchar(max)
alter table sample_result alter column UR_15_a varchar(max)
alter table sample_result alter column UR_16_a varchar(max)
alter table sample_result alter column UR_17_a varchar(max)
alter table sample_result alter column UR_18_a varchar(max)
alter table sample_result alter column UR_19_a varchar(max)
alter table sample_result alter column UR_20_a varchar(max)
alter table sample_result alter column CS_08_a varchar(max)



