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
CREATE TABLE [Artistas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [FotoPerfil] nvarchar(max) NOT NULL,
    [Bio] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Artistas] PRIMARY KEY ([Id])
);

CREATE TABLE [Musicas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Musicas] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231110171503_projetoInicial', N'9.0.3');

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
    SET IDENTITY_INSERT [Artistas] ON;
INSERT INTO [Artistas] ([Nome], [Bio], [FotoPerfil])
VALUES (N'Djavan', N'Djavan Caetano Viana é um cantor, compositor, arranjador, produtor musical, empresário, violonista e ex-futebolista brasileiro.', N'https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
    SET IDENTITY_INSERT [Artistas] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
    SET IDENTITY_INSERT [Artistas] ON;
INSERT INTO [Artistas] ([Nome], [Bio], [FotoPerfil])
VALUES (N'Foo Fighters', N'Foo Fighters é uma banda de rock alternativo americana formada por Dave Grohl em 1995.', N'https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
    SET IDENTITY_INSERT [Artistas] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
    SET IDENTITY_INSERT [Artistas] ON;
INSERT INTO [Artistas] ([Nome], [Bio], [FotoPerfil])
VALUES (N'Pitty', N'Priscilla Novaes Leone, mais conhecida como Pitty, é uma cantora, compositora, produtora, escritora, empresária, apresentadora e multi-instrumentista brasileira.', N'https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
    SET IDENTITY_INSERT [Artistas] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
    SET IDENTITY_INSERT [Artistas] ON;
INSERT INTO [Artistas] ([Nome], [Bio], [FotoPerfil])
VALUES (N'Gilberto Gil', N'Gilberto Passos Gil Moreira é um cantor, compositor, multi-instrumentista, produtor musical, político e escritor brasileiro.', N'https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
    SET IDENTITY_INSERT [Artistas] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
    SET IDENTITY_INSERT [Artistas] ON;
INSERT INTO [Artistas] ([Nome], [Bio], [FotoPerfil])
VALUES (N'Foo Fighters', N'Foo Fighters é uma banda de rock alternativo americana formada por Dave Grohl em 1995.', N'https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
    SET IDENTITY_INSERT [Artistas] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
    SET IDENTITY_INSERT [Artistas] ON;
INSERT INTO [Artistas] ([Nome], [Bio], [FotoPerfil])
VALUES (N'Pitty', N'Priscilla Novaes Leone, mais conhecida como Pitty, é uma cantora, compositora, produtora, escritora, empresária, apresentadora e multi-instrumentista brasileira.', N'https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
    SET IDENTITY_INSERT [Artistas] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
    SET IDENTITY_INSERT [Artistas] ON;
INSERT INTO [Artistas] ([Nome], [Bio], [FotoPerfil])
VALUES (N'Roque Abílio', N'Recriando músicas famosas com uma reviravolta rockabilly, a Roque Abílio cativa o público com uma explosão autêntica do passado que ainda faz todo mundo dançar no presente.', N'https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
    SET IDENTITY_INSERT [Artistas] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231110180103_PopularTabela', N'9.0.3');

ALTER TABLE [Musicas] ADD [AnoLancamento] int NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231110182035_AdicionarColunaAnoLancamento', N'9.0.3');

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
    SET IDENTITY_INSERT [Musicas] ON;
INSERT INTO [Musicas] ([Nome], [AnoLancamento])
VALUES (N'Oceano', 1989);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
    SET IDENTITY_INSERT [Musicas] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
    SET IDENTITY_INSERT [Musicas] ON;
INSERT INTO [Musicas] ([Nome], [AnoLancamento])
VALUES (N'Flor de Lis', 1976);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
    SET IDENTITY_INSERT [Musicas] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
    SET IDENTITY_INSERT [Musicas] ON;
INSERT INTO [Musicas] ([Nome], [AnoLancamento])
VALUES (N'Samurai', 1982);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
    SET IDENTITY_INSERT [Musicas] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
    SET IDENTITY_INSERT [Musicas] ON;
INSERT INTO [Musicas] ([Nome], [AnoLancamento])
VALUES (N'Se', 1992);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
    SET IDENTITY_INSERT [Musicas] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231113194025_PopularMusicas', N'9.0.3');

ALTER TABLE [Musicas] ADD [ArtistaId] int NULL;

CREATE INDEX [IX_Musicas_ArtistaId] ON [Musicas] ([ArtistaId]);

ALTER TABLE [Musicas] ADD CONSTRAINT [FK_Musicas_Artistas_ArtistaId] FOREIGN KEY ([ArtistaId]) REFERENCES [Artistas] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231113203016_RelacionarArtistaMusica', N'9.0.3');

CREATE TABLE [Generos] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Descricao] nvarchar(max) NULL,
    CONSTRAINT [PK_Generos] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231128015225_AdicaoDaTabelaGenero', N'9.0.3');

CREATE TABLE [GeneroMusica] (
    [GenerosId] int NOT NULL,
    [MusicasId] int NOT NULL,
    CONSTRAINT [PK_GeneroMusica] PRIMARY KEY ([GenerosId], [MusicasId]),
    CONSTRAINT [FK_GeneroMusica_Generos_GenerosId] FOREIGN KEY ([GenerosId]) REFERENCES [Generos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_GeneroMusica_Musicas_MusicasId] FOREIGN KEY ([MusicasId]) REFERENCES [Musicas] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_GeneroMusica_MusicasId] ON [GeneroMusica] ([MusicasId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231128021008_RelacionandoMusicaGenero', N'9.0.3');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250408154535_cargaTOTAL', N'9.0.3');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250408154850_cargaTOTAL2', N'9.0.3');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250408163158_cargaTOTAL3', N'9.0.3');

COMMIT;
GO

