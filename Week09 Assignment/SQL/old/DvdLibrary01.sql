CREATE DATABASE DVD02;
GO

USE DVD02;
GO

CREATE TABLE Persons (
    dvdId INT PRIMARY KEY IDENTITY(1, 1),
    title VARCHAR(100) NOT NULL,
    realeaseYear int,
    director varchar(255),
    rating char(2),
    Notes varchar(255),
)

