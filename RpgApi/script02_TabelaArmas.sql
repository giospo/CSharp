BEGIN TRANSACTION;
GO

CREATE TABLE [Armas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_Armas] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Armas]'))
    SET IDENTITY_INSERT [Armas] ON;
INSERT INTO [Armas] ([Id], [Dano], [Nome])
VALUES (1, 10, N'Lanca'),
(2, 20, N'Machado'),
(3, 30, N'Picareta'),
(4, 40, N'Pistola'),
(5, 50, N'Manopla'),
(6, 60, N'Chicote'),
(7, 70, N'Arco');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Armas]'))
    SET IDENTITY_INSERT [Armas] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220928042152_InitialCreate', N'6.0.9');
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220928042227_MigracaoArma', N'6.0.9');
GO

COMMIT;
GO

