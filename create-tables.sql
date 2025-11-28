USE TrabalhoFinalDb;
GO

CREATE TABLE [Editoras] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(200) NOT NULL,
    [Pais] nvarchar(100) NOT NULL,
    [Site] nvarchar(max) NULL,
    [AnoFundacao] int NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    CONSTRAINT [PK_Editoras] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Mangas] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] nvarchar(200) NOT NULL,
    [Autor] nvarchar(100) NOT NULL,
    [Genero] nvarchar(50) NOT NULL,
    [Volumes] int NOT NULL,
    [AnoPublicacao] int NOT NULL,
    [EmAndamento] bit NOT NULL,
    [Preco] decimal(18,2) NOT NULL,
    [EditoraId] int NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    CONSTRAINT [PK_Mangas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Mangas_Editoras_EditoraId] FOREIGN KEY ([EditoraId]) REFERENCES [Editoras] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Mangas_EditoraId] ON [Mangas] ([EditoraId]);
GO
