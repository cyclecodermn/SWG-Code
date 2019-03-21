use DvdRepoEF
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdGetAll')
      DROP PROCEDURE DvdGetAll
GO
CREATE PROCEDURE DvdGetAll
AS
    SELECT *
    FROM Dvd
    ORDER BY dvdId
GO

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdGetById')
      DROP PROCEDURE DvdGetById
GO
CREATE PROCEDURE DvdGetById (@id int)
AS
    SELECT *
    FROM Dvd
    WHERE dvdId = @id
GO

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
  WHERE ROUTINE_NAME = 'DvdAdd')
     DROP PROCEDURE DvdAdd
GO

CREATE PROCEDURE DvdAdd (
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

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdEdit')
      DROP PROCEDURE DvdEdit
GO
CREATE PROCEDURE DvdEdit (
    @dvdId int,
    @title varchar (128),
    @realeaseYear int,
    @director varchar(64),
    @rating varchar(4),
    @notes varchar(600)
)
AS
    UPDATE Dvd
        SET title = @title,
        realeaseYear = @realeaseYear,
        director = @director,
        rating = @rating,
        notes = @notes
    WHERE dvdId = @dvdId
GO

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdGetByTitle')
      DROP PROCEDURE DvdGetByTitle
GO
CREATE PROCEDURE DvdGetByTitle (@term varchar(50))
AS
    SELECT *
    FROM Dvd
    Where title = @term
    ORDER BY dvdId
GO

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdGetByYear')
      DROP PROCEDURE DvdGetByYear
GO
CREATE PROCEDURE DvdGetByYear (@term varchar(50))
AS
    SELECT *
    FROM Dvd
    Where realeaseYear = @term
    ORDER BY dvdId
GO

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdGetByDirector')
      DROP PROCEDURE DvdGetByDirector
GO
CREATE PROCEDURE DvdGetByDirector (@term varchar(50))
AS
    SELECT *
    FROM Dvd
    Where director = @term
    ORDER BY dvdId
GO

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdGetByRating')
      DROP PROCEDURE DvdGetByRating
GO
CREATE PROCEDURE DvdGetByRating (@term varchar(50))
AS
    SELECT *
    FROM Dvd
    Where rating = @term
    ORDER BY dvdId
GO

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdDelete')
      DROP PROCEDURE DvdDelete
GO
CREATE PROCEDURE DvdDelete (@id int)
AS
    DELETE 
    FROM Dvd
    WHERE dvdId = @id
GO
Collapse
