CREATE TABLE [dbo].[ContactNameChanges] (
    [ContactNameChangeID] INT           IDENTITY (1, 1) NOT NULL,
    [CustomerID]          NCHAR (5)     NOT NULL,
    [OldName]             NVARCHAR (30) NOT NULL,
    [NewName]             NVARCHAR (30) NOT NULL,
    [ChangedDate]         DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([ContactNameChangeID] ASC)
);

