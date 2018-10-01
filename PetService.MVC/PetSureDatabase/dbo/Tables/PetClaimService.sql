CREATE TABLE [dbo].[PetClaimService] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [PetId]          INT            NOT NULL,
    [FileName]       NVARCHAR (100) NULL,
    [FilePath]       TEXT           NULL,
    [CreatedDate]    DATETIME       NULL,
    [UploadedDate]   DATETIME       NULL,
    [SavedDate]      DATETIME       NULL,
    [PetClaimedDate] DATETIME       NULL,
    CONSTRAINT [PK_PetClaimService] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PetClaimService_PetList] FOREIGN KEY ([PetId]) REFERENCES [dbo].[PetList] ([PetId])
);

