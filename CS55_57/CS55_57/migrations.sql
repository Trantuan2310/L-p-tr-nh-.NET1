IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [article] (
    [ArticleId] int NOT NULL IDENTITY,
    [Title] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_article] PRIMARY KEY ([ArticleId])
);
GO

CREATE TABLE [Tags] (
    [TagId] nvarchar(20) NOT NULL,
    [Content] ntext NOT NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([TagId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241112040637_V0', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[article].[Title]', N'Name', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241112130645_V1', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [article] ADD [Content] ntext NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241112131306_V2', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Tags] DROP CONSTRAINT [PK_Tags];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tags]') AND [c].[name] = N'TagId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Tags] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Tags] DROP COLUMN [TagId];
GO

ALTER TABLE [Tags] ADD [TagIdNew] int NOT NULL IDENTITY;
GO

ALTER TABLE [Tags] ADD CONSTRAINT [PK_Tags] PRIMARY KEY ([TagIdNew]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241112132443_V3-RemoveTagID', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Tags].[TagIdNew]', N'TagId', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241112133119_V3-RenameTagID', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [ArticleTags] (
    [ArticleTagId] int NOT NULL IDENTITY,
    [TagId] int NOT NULL,
    [ArticleId] int NOT NULL,
    CONSTRAINT [PK_ArticleTags] PRIMARY KEY ([ArticleTagId]),
    CONSTRAINT [FK_ArticleTags_Tags_TagId] FOREIGN KEY ([TagId]) REFERENCES [Tags] ([TagId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArticleTags_article_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [article] ([ArticleId]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_ArticleTags_ArticleId_TagId] ON [ArticleTags] ([ArticleId], [TagId]);
GO

CREATE INDEX [IX_ArticleTags_TagId] ON [ArticleTags] ([TagId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241112151211_V4', N'8.0.10');
GO

COMMIT;
GO

