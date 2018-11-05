-- Create scripts used for tables

CREATE TABLE [Customer]
(
	[CustomerId] INT PRIMARY KEY IDENTITY(1,1),
	[FirstName] NVARCHAR(100),
	[LastName] NVARCHAR(100),
	[Email] NVARCHAR(100),
	[PhoneNumber] NVARCHAR(20),
	[DateRegistered] DATETIME,
	[IsActive] BIT
)

CREATE TABLE [Address]
(
	[AddressId] INT PRIMARY KEY IDENTITY(1,1),
	[Address1] NVARCHAR(255),
	[Address2] NVARCHAR(255),
	[City] NVARCHAR(100),
	[State] NVARCHAR(100),
	[ZipCode] NVARCHAR(30),
	[CountryCode] NVARCHAR(2)
)

CREATE TABLE [BillingInformation]
(
	[BillingInformationId] INT PRIMARY KEY IDENTITY(1,1),
	[CreditCardNumber] NVARCHAR(25),
	[SecurityCode] NVARCHAR(10),
	[ExpirationDate] DATETIME,
	[ReferenceCustomerId] INT NOT NULL,
	[ReferenceBillingAddressId] INT NOT NULL,
	FOREIGN KEY ([ReferenceCustomerId]) REFERENCES [Customer]([CustomerId]),
	FOREIGN KEY ([ReferenceBillingAddressId]) REFERENCES [Address]([AddressId])
)