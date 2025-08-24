-- Drop existing DB if it exists
IF DB_ID('PharmacyDB') IS NOT NULL
    DROP DATABASE PharmacyDB;
GO

-- Create new DB
CREATE DATABASE PharmacyDB;
GO
USE PharmacyDB;
GO

-- Medicines table
CREATE TABLE Medicines (
    MedicineID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(150) NOT NULL,
    Category VARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Quantity INT NOT NULL
);
GO

-- Sales table
CREATE TABLE Sales (
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    MedicineID INT NOT NULL FOREIGN KEY REFERENCES Medicines(MedicineID),
    QuantitySold INT NOT NULL,
    SaleDate DATETIME NOT NULL DEFAULT(GETDATE())
);
GO

-- Stored Procedures

-- Add new medicine
CREATE PROCEDURE AddMedicine
    @Name VARCHAR(150),
    @Category VARCHAR(100),
    @Price DECIMAL(10,2),
    @Quantity INT
AS
BEGIN
    INSERT INTO Medicines(Name, Category, Price, Quantity)
    VALUES(@Name, @Category, @Price, @Quantity);
END
GO

-- Search medicine by name or category
CREATE PROCEDURE SearchMedicine
    @SearchTerm VARCHAR(100)
AS
BEGIN
    SELECT * FROM Medicines
    WHERE Name LIKE '%' + @SearchTerm + '%'
       OR Category LIKE '%' + @SearchTerm + '%';
END
GO

-- Update stock
CREATE PROCEDURE UpdateStock
    @MedicineID INT,
    @Quantity INT
AS
BEGIN
    UPDATE Medicines
    SET Quantity = @Quantity
    WHERE MedicineID = @MedicineID;
END
GO

-- Record sale
CREATE PROCEDURE RecordSale
    @MedicineID INT,
    @QuantitySold INT
AS
BEGIN
    INSERT INTO Sales(MedicineID, QuantitySold)
    VALUES(@MedicineID, @QuantitySold);

    UPDATE Medicines
    SET Quantity = Quantity - @QuantitySold
    WHERE MedicineID = @MedicineID;
END
GO

-- Get all medicines
CREATE PROCEDURE GetAllMedicines
AS
BEGIN
    SELECT * FROM Medicines;
END
GO
