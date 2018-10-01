CREATE TABLE [dbo].[PetClaimServiceTemp] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [PetId]          INT            NOT NULL,
    [FileName]       NVARCHAR (100) NULL,
    [FilePath]       TEXT           NULL,
    [CreatedDate]    DATETIME       NULL,
    [UploadedDate]   DATETIME       NULL,
    [SavedDate]      DATETIME       NULL,
    [PetClaimedDate] DATETIME       NULL,
    CONSTRAINT [PK_PetClaimServiceTemp] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PetClaimServiceTemp_PetList] FOREIGN KEY ([PetId]) REFERENCES [dbo].[PetList] ([PetId])
);

