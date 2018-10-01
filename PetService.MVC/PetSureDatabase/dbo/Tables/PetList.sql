CREATE TABLE [dbo].[PetList] (
    [PetId]   INT           IDENTITY (1, 1) NOT NULL,
    [PetName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_PetList] PRIMARY KEY CLUSTERED ([PetId] ASC)
);

