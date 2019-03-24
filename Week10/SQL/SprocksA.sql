USE GuildCars1
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DbReset')
		DROP PROCEDURE DbReset
GO

-- -  -   -    -     -      -       -        -

CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM BikeFrameTable;
	DELETE FROM BikeModelTable;
	DELETE FROM BikeMakeTable;
 
-- -  -   -    -     -      -       -        -
	SET IDENTITY_INSERT BikeFrameTable ON;
	
	INSERT INTO BikeFrameTable (BikeFrameId, BikeFrame)
	VALUES
	(1,'Touring'),
	(2,'Road'),
	(3,'Hybrid');

	SET IDENTITY_INSERT BikeFrameTable OFF;

-- -  -   -    -     -      -       -        -
	SET IDENTITY_INSERT BikeMakeTable ON;
	
	INSERT INTO BikeMakeTable (BikeMakeId, BikeMake)
	VALUES
	(1,'Giant'),
	(2,'Surley'),
	(3,'Trek');

	SET IDENTITY_INSERT BikeMakeTable OFF;
-- -  -   -    -     -      -       -        -
	
	SET IDENTITY_INSERT BikeModelTable ON;
	
	INSERT INTO BikeModelTable (BikeModelId, BikeMakelId, BikeModel)
	VALUES
	(1,1,'RidgeBack'),
	(2,2,'Long Haul Trucker'),
	(3,3,'520');

	SET IDENTITY_INSERT BikeModelTable OFF;
-- -  -   -    -     -      -       -        -

END