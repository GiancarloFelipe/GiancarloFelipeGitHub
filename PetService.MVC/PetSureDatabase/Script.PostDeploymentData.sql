/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

SET IDENTITY_INSERT [dbo].[PetList] ON 
GO
MERGE INTO [dbo].[PetList] AS Target 
USING (VALUES 
        (1, N'Rover'),
        (2, N'Fido'),
        (3, N'Pixie')
) 
AS Source ([PetId],[PetName]) 
ON Target.[PetId] = Source.[PetId] 
--WHEN MATCHED THEN
--UPDATE SET Target.[DepartmentName] = Source.[DepartmentName] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([PetId],[PetName]) 
VALUES ([PetId],[PetName]);
GO
SET IDENTITY_INSERT [dbo].[PetList] OFF