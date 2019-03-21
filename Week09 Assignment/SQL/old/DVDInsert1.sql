use DvdRepoEF
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
  WHERE ROUTINE_NAME = 'DvdCreate')
     DROP PROCEDURE DvdCreate
GO

CREATE PROCEDURE DvdCreate (
@dvdId int output,
@dvdTitle nvarchar(128),
@dvdYear int,
@dvdDirector nvarchar(64),
@dvdRating varchar(4),
@dvdNotes nvarchar(600) = ''
)
AS
    INSERT INTO Dvd (title, realeaseYear, director, rating, notes) values
    (@dvdTitle,@dvdYear,@dvdDirector,@dvdRating,@dvdNotes)

    set @dvdId = SCOPE_IDENTITY()
GO

