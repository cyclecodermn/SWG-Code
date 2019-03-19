CREATE SCHEMA dvd02;

CREATE TABLE dvd02.dvd02a ( 
	dvdid                int  NOT NULL  ,
	title                varchar(128)    ,
	realeaseyear         int    ,
	director             varchar(64)    ,
	rating               char(4)    ,
	notes                varchar(600)    ,
	CONSTRAINT pk_dvd02a_dvdid PRIMARY KEY ( dvdid )
 ) engine=InnoDB;

ALTER TABLE dvd02.dvd02a COMMENT 'Table for Week9 DVD project.';

