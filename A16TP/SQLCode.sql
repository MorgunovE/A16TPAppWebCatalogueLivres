-- Create database
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'dbbookshop')
BEGIN
    CREATE DATABASE dbbookshop;
END
GO

USE dbbookshop;
GO

-- Drop tables if they exist
IF OBJECT_ID('dbo.Basket_Livre', 'U') IS NOT NULL
    DROP TABLE dbo.Basket_Livre;
IF OBJECT_ID('dbo.Basket', 'U') IS NOT NULL
    DROP TABLE dbo.Basket;
IF OBJECT_ID('dbo.Livre', 'U') IS NOT NULL
    DROP TABLE dbo.Livre;
IF OBJECT_ID('dbo.[User]', 'U') IS NOT NULL
    DROP TABLE dbo.[User];
GO

-- Create User table
CREATE TABLE [User] (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(255),
    familyName NVARCHAR(255) NOT NULL,
    tel NVARCHAR(20) NOT NULL,
    email NVARCHAR(255) NOT NULL UNIQUE
);
GO

-- Create Livre table
CREATE TABLE Livre (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    title NVARCHAR(255),
    description NVARCHAR(MAX),
    author NVARCHAR(255),
    genre NVARCHAR(255),
    image NVARCHAR(255),
    price FLOAT CHECK (price >= 0),
    quantity INT CHECK (quantity >= 0)
);
GO

-- Create Basket table
CREATE TABLE Basket (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    user_id BIGINT,
    FOREIGN KEY (user_id) REFERENCES [User](id)
);
GO

-- Create Basket_Livre table
CREATE TABLE Basket_Livre (
    basket_id BIGINT,
    livre_id BIGINT,
    PRIMARY KEY (basket_id, livre_id),
    FOREIGN KEY (basket_id) REFERENCES Basket(id),
    FOREIGN KEY (livre_id) REFERENCES Livre(id)
);
GO

-- Insert example data into User table
INSERT INTO [User] (name, familyName, tel, email) VALUES
('John', 'Doe', '123-456-7890', 'john.doe@example.com'),
('Jane', 'Smith', '098-765-4321', 'jane.smith@example.com'),
('Alice', 'Johnson', '555-123-4567', 'alice.johnson@example.com');
GO

-- Insert example data into Livre table
INSERT INTO Livre (title, description, author, genre, image, price, quantity) VALUES
('The Great Gatsby', 'A novel set in the Roaring Twenties', 'F. Scott Fitzgerald', 'Fiction', 'great_gatsby.jpg', 10.99, 5),
('To Kill a Mockingbird', 'A novel about racial injustice', 'Harper Lee', 'Fiction', 'to_kill_a_mockingbird.jpg', 8.99, 3),
('1984', 'A dystopian novel', 'George Orwell', 'Science Fiction', '1984.jpg', 12.99, 7);
GO

-- Insert example data into Basket table
INSERT INTO Basket (user_id) VALUES
(1),
(2),
(3);
GO

-- Insert example data into Basket_Livre table
INSERT INTO Basket_Livre (basket_id, livre_id) VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 1),
(3, 3);
GO