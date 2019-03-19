USE [master]
GO

if exists (select * from sys.databases where name = N'DvdRepoEF')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'DvdRepoEF';
	ALTER DATABASE DvdRepoEF SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE DvdRepoEF;
end


CREATE DATABASE [DvdRepoEF]
GO
USE [DvdRepoEF]
GO


CREATE SCHEMA main;

CREATE TABLE DvdRepoEF.main ( 
	dvdid                int primary key identity(1,1),
	title                nvarchar(128), NOT NULL,
	realeaseyear         int, NOT NULL
	director             nvarchar(64), NOT NULL,
	rating               char(4), NOT NULL,
	notes                nvarchar(600) NULL
 ) ;

 
use DvdRepoEF


insert into DvdRepoEF(title, realeaseyear, director, rating, notes)

values 

('Jaws','1975','Speilberg','R','Shark has a toothy smile.'),
('Star Wars','1976','Lucas','PG','It is a space-age western.'),


