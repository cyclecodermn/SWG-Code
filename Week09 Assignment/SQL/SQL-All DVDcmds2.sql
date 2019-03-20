use dvdRepoEF
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'dvdGetAll')
      DROP PROCEDURE dvdGetAll
GO
CREATE PROCEDURE dvdGetAll
AS
    SELECT *
    FROM dvdMain
    ORDER BY dvdId
GO

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'dvdGetById')
      DROP PROCEDURE dvdGetById
GO
CREATE PROCEDURE dvdGetById (@id int)
AS
    SELECT *
    FROM dvdMain
    WHERE dvdId = @id
GO

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
  WHERE ROUTINE_NAME = 'dvdAdd')
     DROP PROCEDURE dvdAdd
GO

CREATE PROCEDURE dvdAdd (
@dvdId int output,
@dvdTitle nvarchar(128),
@dvdYear int,
@dvdDirector nvarchar(64),
@dvdRating varchar(4),
@dvdNotes nvarchar(600) = ''
)
AS
    INSERT INTO dvdMain (title, realeaseYear, director, rating, notes) values
    (@dvdTitle,@dvdYear,@dvdDirector,@dvdRating,@dvdNotes)

    set @dvdId = SCOPE_IDENTITY()
	-- A new ID was generated, and now, we're sending it back.
GO

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'dvdEdit')
      DROP PROCEDURE dvdEdit
GO
CREATE PROCEDURE dvdEdit (
    @dvdId int,
    @title varchar (128),
    @realeaseYear int,
    @director varchar(64),
    @rating varchar(4),
    @notes varchar(600)
)
AS
    UPDATE dvdMain
        SET title = @title,
        realeaseYear = @realeaseYear,
        director = @director,
        rating = @rating,
        notes = @notes
    WHERE dvdId = @dvdId
GO

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'dvdGetByTitle')
      DROP PROCEDURE dvdGetByTitle
GO
CREATE PROCEDURE dvdGetByTitle (@term varchar(50))
AS
    SELECT *
    FROM dvdMain
    Where title = @term
    ORDER BY dvdId
GO

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'dvdGetByYear')
      DROP PROCEDURE dvdGetByYear
GO
CREATE PROCEDURE dvdGetByYear (@term varchar(50))
AS
    SELECT *
    FROM dvdMain
    Where realeaseYear = @term
    ORDER BY dvdId
GO

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'dvdGetByDirector')
      DROP PROCEDURE dvdGetByDirector
GO
CREATE PROCEDURE dvdGetByDirector (@term varchar(50))
AS
    SELECT *
    FROM dvdMain
    Where director = @term
    ORDER BY dvdId
GO

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'dvdGetByRating')
      DROP PROCEDURE dvdGetByRating
GO
CREATE PROCEDURE dvdGetByRating (@term varchar(50))
AS
    SELECT *
    FROM dvdMain
    Where rating = @term
    ORDER BY dvdId
GO

-- -  -   -    -     -      -       -        -

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'dvdDelete')
      DROP PROCEDURE dvdDelete
GO
CREATE PROCEDURE dvdDelete (@id int)
AS
    DELETE 
    FROM dvdMain
    WHERE dvdId = @id
GO


