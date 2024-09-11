CREATE TABLE [dbo].[FizzBuzzResult] (
    Id INT IDENTITY(1, 1) NOT NULL,
    output varchar(255) NOT NULL,
    Age int NOT NULL,

    CONSTRAINT PK_TransactionHistoryArchive1_TransactD PRIMARY KEY CLUSTERED (TransactionID)
);
