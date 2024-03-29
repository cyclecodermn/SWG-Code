USE [master]
GO

if exists (select * from sys.databases where name = N'Hotel3')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'Hotel3';
	ALTER DATABASE Hotel3 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE Hotel3;
end



CREATE DATABASE [Hotel3]
GO
USE [Hotel3]
GO

CREATE TABLE [AddOn](
	[AddOnId] [int] NOT NULL Primary Key,
	[AddOnName] [varchar](50) NULL,
	[AddOnCost] [decimal](18, 0) NULL,
	[AoDateStart] [date] NULL,
	[AoDateEnd] [date] NULL
	)
GO

CREATE TABLE [Amenity](
	[AmenityId] [int] NOT NULL Primary Key,
	[AmenityName] [varchar](50) NOT NULL,
	[AmenityCost] [int] NOT NULL
	)
GO

CREATE TABLE [Billing](
	[BillingId] [int] NOT NULL Primary Key,
	[BillDate] [date] NOT NULL,
	[PromoId] [int] NULL)
GO

CREATE TABLE [Customer](
	[CustomerId] [int] NOT NULL Primary Key,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Phone] [char](15) NOT NULL,
	[Email] [char](20) NOT NULL,
	[GuestOf] [int] NULL
	)
GO

CREATE TABLE [CustRes](
	[ReservationId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	CONSTRAINT PK_CustRes PRIMARY KEY (ReservationId,CustomerID)
)
GO

CREATE TABLE [Promotion](
	[PromoId] [int] NOT NULL Primary Key,
	[PromoName] [varchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[PromoPercent] [decimal](18, 0) NULL,
	[FlatRate] [decimal](18, 0) NULL
	)
GO

CREATE TABLE [Reservation](
	[ReservationId] [int] NOT NULL Primary Key,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Promotion] [decimal](18, 0) NULL,
	[CustId] [int] NULL
	)
GO

CREATE TABLE [Room](
	[RoomId] [int] NOT NULL Primary Key,
	[Number] [int] NOT NULL,
	[FloorNum] [int] NOT NULL,
	[NumBeds] [int] NOT NULL,
	[MaxOccupancy] [int] NOT NULL,
	[RoomTypeId] [int] NOT NULL,
	[AmenityId] [int] NOT NULL
	)
GO

CREATE TABLE [ResAddOn](
	[ReservationId] [int] NULL,
	[AddOnId] [int] NULL
)
GO

CREATE TABLE [RoomRes](
	[RoomId] [int] NOT NULL,
	[ReservationId] [int] NOT NULL,
	CONSTRAINT PK_RoomRes Primary Key (RoomId,ReservationId)
)
------RoomRes Hack
CREATE TABLE [RoomAmenity](
	[RoomId] [int] NOT NULL,
	[AmenityId] [int] NOT NULL
)
GO

CREATE TABLE [ReservationBilling](
	[BillingId] [int] NOT NULL,
	[ReservationId] [int] NOT NULL
) 
GO

CREATE TABLE [RoomType](
	[RoomTypeId] [int] NOT NULL Primary Key,
	[TypeName] [varchar](50) NOT NULL,
	[Rate] [decimal] NOT NULL
	)
GO

-- *****************
-- BEGIN CONSTRAINTS
-- *****************



ALTER TABLE [Billing]  WITH CHECK ADD  CONSTRAINT [FK_Billing_Promotion] FOREIGN KEY([PromoId])
REFERENCES [Promotion] ([PromoId])
GO
ALTER TABLE [Billing] CHECK CONSTRAINT [FK_Billing_Promotion]
GO
ALTER TABLE [CustRes]  WITH CHECK ADD  CONSTRAINT [FK_CustRes_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Customer] ([CustomerId])
GO
ALTER TABLE [CustRes] CHECK CONSTRAINT [FK_CustRes_Customer]
GO
ALTER TABLE [CustRes]  WITH CHECK ADD  CONSTRAINT [FK_CustRes_Reservation] FOREIGN KEY([ReservationId])
REFERENCES [Reservation] ([ReservationId])
GO
ALTER TABLE [CustRes] CHECK CONSTRAINT [FK_CustRes_Reservation]
GO
ALTER TABLE [Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([RoomTypeId])
REFERENCES [RoomType] ([RoomTypeId])
GO
ALTER TABLE [Room] CHECK CONSTRAINT [FK_Room_RoomType]
GO
ALTER TABLE [ResAddOn]  WITH CHECK ADD  CONSTRAINT [FK_ResAddOn_AddOn] FOREIGN KEY([AddOnId])
REFERENCES [AddOn] ([AddOnId])
GO
ALTER TABLE [ResAddOn] CHECK CONSTRAINT [FK_ResAddOn_AddOn]
GO
ALTER TABLE [ResAddOn]  WITH CHECK ADD  CONSTRAINT [FK_ResAddOn_Reservation] FOREIGN KEY([ReservationId])
REFERENCES [Reservation] ([ReservationId])
GO
ALTER TABLE [ResAddOn] CHECK CONSTRAINT [FK_ResAddOn_Reservation]
GO

----------- Room Res Hack2
ALTER TABLE [RoomRes]  WITH CHECK ADD  CONSTRAINT [FK_RoomRes_Reservation] FOREIGN KEY([ReservationId])
REFERENCES [Reservation] ([ReservationId])
GO
ALTER TABLE [RoomRes] CHECK CONSTRAINT [FK_RoomRes_Reservation]
GO
ALTER TABLE [RoomRes]  WITH CHECK ADD  CONSTRAINT [FK_RoomRes_Room] FOREIGN KEY([RoomId])
REFERENCES [Room] ([RoomId])
GO
ALTER TABLE [RoomRes] CHECK CONSTRAINT [FK_RoomRes_Room]

-------------

ALTER TABLE [RoomAmenity]  WITH CHECK ADD  CONSTRAINT [FK_RoomAmenity_Amenity] FOREIGN KEY([AmenityId])
REFERENCES [Amenity] ([AmenityId])
GO
ALTER TABLE [RoomAmenity] CHECK CONSTRAINT [FK_RoomAmenity_Amenity]
GO
ALTER TABLE [RoomAmenity]  WITH CHECK ADD  CONSTRAINT [FK_RoomAmenity_Room] FOREIGN KEY([RoomId])
REFERENCES [Room] ([RoomId])
GO
ALTER TABLE [RoomAmenity] CHECK CONSTRAINT [FK_RoomAmenity_Room]
GO
ALTER TABLE [ReservationBilling]  WITH CHECK ADD  CONSTRAINT [FK_ReservationBilling_Billing] FOREIGN KEY([ReservationId])
REFERENCES [Billing] ([BillingId])
GO
ALTER TABLE [ReservationBilling] CHECK CONSTRAINT [FK_ReservationBilling_Billing]
GO
ALTER TABLE [ReservationBilling]  WITH CHECK ADD  CONSTRAINT [FK_ReservationBilling_Reservation] FOREIGN KEY([ReservationId])
REFERENCES [Reservation] ([ReservationId])
GO
ALTER TABLE [ReservationBilling] CHECK CONSTRAINT [FK_ReservationBilling_Reservation]
GO


-- ********************
-- END CONSTRAINTS
-- BEGIN DATA INSERTION
-- ********************

Use [Hotel3]
GO


use Hotel3

-- My Table ID 1.1.1
insert into RoomType (RoomTypeId,TypeName,Rate)
values
(1,'Single',50),
(2,'bunk',20)

-- My Table ID 1.3.2
insert into Amenity(AmenityId, AmenityName, AmenityCost)
values 
(1,'Fridge',10),
(2,'Shower',20)

insert into Room(RoomId,Number,FloorNum,NumBeds,MaxOccupancy,RoomTypeId,AmenityId)
values
(1,1,1,6,6,2,2),
(2,2,1,6,6,2,1),
(3,3,1,6,6,2,1),
(4,4,1,6,6,2,1),
(5,5,1,6,6,2,1),
(6,6,1,4,4,2,1),
(7,7,1,4,4,2,1),
(8,8,2,4,4,2,1),
(9,9,2,1,2,1,1),
(10,10,2,1,2,1,2)


-- My Table ID 1.3.1
insert into RoomAmenity(RoomId,AmenityId)
values
(1,1),
(2,1),
(3,1),
(4,1),
(5,1),
(6,1),
(7,1),
(8,1),
(8,2),
(9,1),
(9,2),
(10,1),
(10,2)

-- My Table ID 1.4.2
insert into AddOn(AddOnId,AddOnName,AddOnCost,AoDateStart,AoDateEnd)
values(1,'Pillow',5,'2019-02-21','2019-02-26'),
(2,'Sheets',5,'2019-02-21','2019-02-26'),
(3,'Shower',5,'2017-12-27','2018-01-01')


-- My Table ID 2.1.2
insert into Promotion (PromoId,PromoName,StartDate,EndDate,PromoPercent,FlatRate)
values(1,'SlowSeason','2019-11-1','2020-03-15',0.20,NULL)


-- My Table ID 2.1.1
--insert into BillPromo (BillingId,PromoId)


-- My Table ID 2.2.2
insert into Customer(CustomerId,FirstName,LastName,Age,Phone,Email,GuestOf)

values 

(1,'Beth','Almaer',52,'651-111-1111','Beth@email.com', NULL),
(2,'Simon','Almaer',49,'652-222-2222','Simon@email.com',NULL),
(3,'John','Abbott',55,'653-333-3333','john@email.com',NULL),
(4,'Aimee','Abbott',45,'654-444-4444','aimee@email.com',NULL),
(5,'Sue','Mal',60,'655-555-5555','sue@email.com',NULL),
(6,'Jackie','Klemmer',58,'656-666-6666','jackie@email.com',NULL)

Insert into Reservation(ReservationId,StartDate,EndDate,Promotion,CustId)
values
(1,'2019-02-21','2019-02-26',NULL,1),
(2,'2019-02-21','2019-02-26',NULL,1),
(3,'2017-12-27','2018-01-01',NULL,2),
(4,'2017-12-27','2018-01-01',NULL,2),
(5,'2017-12-07','2017-12-12',NULL,3),
(6,'2017-11-17','2017-11-22',NULL,4),
(7,'2017-10-28','2017-11-02',NULL,5),
(8,'2017-10-08','2017-10-13',NULL,6),
(9,'2017-09-18','2017-09-23',NULL,7),
(10,'2017-08-29','2017-09-03',NULL,8)

-- My Table ID 3.1
insert into CustRes(ReservationId,CustomerId)
values 
(1,1),
(2,2),
(3,3),
(4,4),
(5,5),
(6,6),
(1,3),
(2,4),
(3,5),
(4,6)

--	[BillingId] [int] NOT NULL Primary Key,
--	[BillDate] [date] NOT NULL,
--	[PromoId] [int] NULL)

Insert into Billing(BillingId,BillDate,PromoId)
values
(1,'2019-02-26',NULL),
(2,'2019-02-26',NULL),
(3,'2018-01-01',NULL),
(4,'2018-01-01',NULL),
(5,'2017-12-12',NULL),
(6,'2017-11-22',NULL),
(7,'2017-11-02',NULL),
(8,'2017-10-13',NULL),
(9,'2017-09-23',NULL),
(10,'2017-09-03',NULL)

-- My Table ID 2.2
insert into ReservationBilling(ReservationId,BillingId)
values
(2,2),
(3,3),
(4,4),
(5,5),
(6,6),
(7,7),
(8,8),
(9,9),
(10,10)

-- My Table ID 3.2
insert into RoomRes(ReservationId,RoomId)
values 
(1,1),
(2,2),
(3,3),
(4,4),
(5,5),
(6,6),
(7,9),
(8,10),
(9,9),
(10,10)


-- My Table ID 1.4.1
insert into ResAddOn(ReservationId,AddOnId)
values(1,1),
(2,1),
(3,1),
(4,1),
(5,1),
(6,1),
(7,1),
(8,1),
(8,2),
(9,1),
(9,2),
(10,1),
(10,2)

-- Write a query that returns a list of reservations that end tomorrow.
select * from Reservation
where EndDate='2019-02-26'

-- Write a query that returns all the rooms reserved for a particular customer.
SELECT
rm.RoomId

From Reservation r
INNER JOIN CustRes cr ON cr.ReservationId = r.ReservationId
INNER JOIN Customer  c ON c.CustomerId=cr.CustomerId
Inner join RoomRes rs ON rs.ReservationId=r.ReservationId
Inner JOIN Room rm ON rs.RoomId=rm.RoomId

where c.CustomerId=3

-- Write a query that returns rooms that do not contain a specific amenity.

select
	ra.RoomId,
	ra.AmenityId
From RoomAmenity ra
where AmenityId!=1