USE [master]
GO

if exists (select * from sys.databases where name = N'dvd02')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'dvd02';
	ALTER DATABASE dvd02 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE dvd02;
end


CREATE DATABASE [dvd02]
GO
USE [dvd02]
GO


CREATE SCHEMA dvd02main;

CREATE TABLE dvd02.dvd02a ( 
	dvdid                int  NOT NULL  ,
	title                varchar(128)    ,
	realeaseyear         int    ,
	director             varchar(64)    ,
	rating               char(4)    ,
	notes                varchar(600)    ,
	CONSTRAINT pk_dvd02a_dvdid PRIMARY KEY ( dvdid )
 ) ;

 dvdid, 
ALTER TABLE dvd02.dvd02a COMMENT 'Table for Week9 DVD project.';
use DVD02


insert into dvd02main(title, realeaseyear, director, rating, notes)

values 

(1,'Beth','Almaer',52,'651-111-1111','Beth@email.com', NULL),
(2,'Simon','Almaer',49,'652-222-2222','Simon@email.com',NULL),

