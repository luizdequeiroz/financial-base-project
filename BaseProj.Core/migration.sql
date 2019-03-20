IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [RG] nvarchar(max) NULL,
    [CPF] nvarchar(max) NULL,
    [BirthDate] datetime2 NULL,
    [Phone] nvarchar(max) NULL,
    [Cell] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Registration] nvarchar(max) NULL,
    [PortalPassword] nvarchar(max) NULL,
    [Type] int NOT NULL,
    [Margin] decimal(18,2) NOT NULL,
    [MarginDate] datetime2 NULL,
    [BenefitNumber] nvarchar(max) NULL,
    [SIAPNumber] nvarchar(max) NULL,
    [Bank] nvarchar(max) NULL,
    [Agency] nvarchar(max) NULL,
    [Account] nvarchar(max) NULL,
    [Op] nvarchar(max) NULL,
    [Observation] nvarchar(max) NULL,
    [RegisterDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NULL,
    [BirthDate] datetime2 NULL,
    [RegisterDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190320013239_BaseDB001', N'2.2.2-servicing-10034');

GO


