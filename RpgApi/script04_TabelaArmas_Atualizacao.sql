BEGIN TRANSACTION;
GO

ALTER TABLE [Personagens] ADD [Derrotas] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Personagens] ADD [Disputas] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Personagens] ADD [Vitorias] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Armas] ADD [PersonagemId] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [Habilidades] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_Habilidades] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PersonagemHabilidades] (
    [PersonagemId] int NOT NULL,
    [HabilidadeId] int NOT NULL,
    CONSTRAINT [PK_PersonagemHabilidades] PRIMARY KEY ([PersonagemId], [HabilidadeId]),
    CONSTRAINT [FK_PersonagemHabilidades_Habilidades_HabilidadeId] FOREIGN KEY ([HabilidadeId]) REFERENCES [Habilidades] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PersonagemHabilidades_Personagens_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [Personagens] ([Id]) ON DELETE CASCADE
);
GO

UPDATE [Armas] SET [PersonagemId] = 1
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 2
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 3
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 4
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 5
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 6
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 7
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Habilidades]'))
    SET IDENTITY_INSERT [Habilidades] ON;
INSERT INTO [Habilidades] ([Id], [Dano], [Nome])
VALUES (1, 39, N'Adormecer'),
(2, 41, N'Congelar'),
(3, 37, N'Hipnotizar');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Habilidades]'))
    SET IDENTITY_INSERT [Habilidades] OFF;
GO

UPDATE [Usuarios] SET [PasswordHash] = 0x8EBA641D8CB1B22610441C18D8304C53D06324CB5563D6818AA81330FE4813C92E6420760B3CF0BA21AF15FC4F83DE848CDAACA30503B9592C297DD56C2BF5D6, [PasswordSalt] = 0xB9034D3FAB47176AF68F5376ADDF562F8ECBF0E7647237A06A830740610BAFCA7FAAB22E72B0F7A9E0F8661682405C194694FCD1D05B0C87ECC190480140A7C65CAE4192BF6F51B7B6C7FFAE88F75A9C00A1F78DE99856AAC80371F164B8DA03508E94BB70949D99F5ED39912BC39E66EA9284A4BC4076C94F03CF7054C570A6
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[PersonagemHabilidades]'))
    SET IDENTITY_INSERT [PersonagemHabilidades] ON;
INSERT INTO [PersonagemHabilidades] ([HabilidadeId], [PersonagemId])
VALUES (1, 1),
(2, 1),
(2, 2),
(2, 3),
(3, 3),
(3, 4),
(1, 5),
(2, 6),
(3, 7);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[PersonagemHabilidades]'))
    SET IDENTITY_INSERT [PersonagemHabilidades] OFF;
GO

CREATE UNIQUE INDEX [IX_Armas_PersonagemId] ON [Armas] ([PersonagemId]);
GO

CREATE INDEX [IX_PersonagemHabilidades_HabilidadeId] ON [PersonagemHabilidades] ([HabilidadeId]);
GO

ALTER TABLE [Armas] ADD CONSTRAINT [FK_Armas_Personagens_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [Personagens] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221107015642_MigracaoUmParaUm', N'6.0.10');
GO

COMMIT;
GO

