info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 3.0.0 initialized 'Context' using provider 'Microsoft.EntityFrameworkCore.SqlServer' with options: None
ALTER TABLE [CandidateTests] DROP CONSTRAINT [FK_CandidateTests_Candidates_CandidateId];

GO

DROP INDEX [IX_CandidateTests_CandidateId] ON [CandidateTests];
DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CandidateTests]') AND [c].[name] = N'CandidateId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [CandidateTests] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [CandidateTests] ALTER COLUMN [CandidateId] int NOT NULL;
CREATE INDEX [IX_CandidateTests_CandidateId] ON [CandidateTests] ([CandidateId]);

GO

ALTER TABLE [CandidateTests] ADD CONSTRAINT [FK_CandidateTests_Candidates_CandidateId] FOREIGN KEY ([CandidateId]) REFERENCES [Candidates] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191023031348_CandidateTest_CandidateIdPropertyFix', N'3.0.0');

GO

ALTER TABLE [CandidateTests] ADD [Created] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [CandidateTests] ADD [Name] nvarchar(100) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191024011047_CandidateTest_AddNameCreated', N'3.0.0');

GO


