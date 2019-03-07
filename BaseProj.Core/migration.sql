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
    [BirthDate] datetime2 NOT NULL,
    [Phone] nvarchar(max) NULL,
    [Cell] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Registration] nvarchar(max) NULL,
    [PortalPassword] nvarchar(max) NULL,
    [Type] int NOT NULL,
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

CREATE TABLE [Loans] (
    [Id] int NOT NULL IDENTITY,
    [Status] int NOT NULL,
    [Modality] int NOT NULL,
    [StatusDate] datetime2 NOT NULL,
    [RegisterDate] datetime2 NOT NULL,
    [RequestDate] datetime2 NULL,
    [LoanDate] datetime2 NULL,
    [LoanValue] decimal(18,2) NOT NULL,
    [InstallmentAmount] int NOT NULL,
    [InstallmentValue] decimal(18,2) NOT NULL,
    [TotalPayable] decimal(18,2) NOT NULL,
    [BankId] int NOT NULL,
    [ClientId] int NOT NULL,
    CONSTRAINT [PK_Loans] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NULL,
    [BirthDate] datetime2 NOT NULL,
    [RegisterDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190220223759_BaseDB001', N'2.2.2-servicing-10034');

GO

ALTER TABLE [Loans] ADD [Observation] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190221015511_BaseDB002', N'2.2.2-servicing-10034');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'BirthDate');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Users] ALTER COLUMN [BirthDate] datetime2 NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190221143629_BaseDB003', N'2.2.2-servicing-10034');

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clients]') AND [c].[name] = N'BirthDate');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Clients] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Clients] ALTER COLUMN [BirthDate] datetime2 NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190221153458_BaseDB004', N'2.2.2-servicing-10034');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190222140327_BaseDB005', N'2.2.2-servicing-10034');

GO

ALTER TABLE [Loans] ADD [DebtorBalance] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [Loans] ADD [DebtorBalanceQtdPart] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Loans] ADD [PaymentDate] datetime2 NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190222174415_BaseDB006', N'2.2.2-servicing-10034');

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Loans]') AND [c].[name] = N'TotalPayable');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Loans] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Loans] ALTER COLUMN [TotalPayable] decimal(18,2) NULL;

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Loans]') AND [c].[name] = N'StatusDate');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Loans] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Loans] ALTER COLUMN [StatusDate] datetime2 NULL;

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Loans]') AND [c].[name] = N'InstallmentValue');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Loans] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Loans] ALTER COLUMN [InstallmentValue] decimal(18,2) NULL;

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Loans]') AND [c].[name] = N'InstallmentAmount');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Loans] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Loans] ALTER COLUMN [InstallmentAmount] int NULL;

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Loans]') AND [c].[name] = N'DebtorBalanceQtdPart');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Loans] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Loans] ALTER COLUMN [DebtorBalanceQtdPart] int NULL;

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Loans]') AND [c].[name] = N'DebtorBalance');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Loans] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Loans] ALTER COLUMN [DebtorBalance] decimal(18,2) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190222190346_BaseDB007', N'2.2.2-servicing-10034');

GO

ALTER TABLE [Clients] ADD [Margin] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190306234515_BaseDB008', N'2.2.2-servicing-10034');

GO

ALTER TABLE [Clients] ADD [MarginDate] datetime2 NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190307013919_BaseDB009', N'2.2.2-servicing-10034');

GO


