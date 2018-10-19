
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/18/2018 15:25:14
-- Generated from EDMX file: C:\Users\usuario\Desktop\ArquitecturaPropuesta\ingenieriaInversa\monedaDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [monedasDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[monedasDBModelStoreContainer].[FK_ConversionFactores_idMonedaDestino2]', 'F') IS NOT NULL
    ALTER TABLE [monedasDBModelStoreContainer].[ConversionFactores] DROP CONSTRAINT [FK_ConversionFactores_idMonedaDestino2];
GO
IF OBJECT_ID(N'[monedasDBModelStoreContainer].[FK_ConversionFactores_idMonedaOrigen]', 'F') IS NOT NULL
    ALTER TABLE [monedasDBModelStoreContainer].[ConversionFactores] DROP CONSTRAINT [FK_ConversionFactores_idMonedaOrigen];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[monedas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[monedas];
GO
IF OBJECT_ID(N'[monedasDBModelStoreContainer].[ConversionFactores]', 'U') IS NOT NULL
    DROP TABLE [monedasDBModelStoreContainer].[ConversionFactores];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'monedas'
CREATE TABLE [dbo].[monedas] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IdentificadorMonedas] varchar(50)  NOT NULL,
    [Nombre] varchar(50)  NOT NULL
);
GO

-- Creating table 'ConversionFactores'
CREATE TABLE [dbo].[ConversionFactores] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idMonedaOrigen] int  NOT NULL,
    [idMonedaDestino] int  NOT NULL,
    [FactorConversion] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'monedas'
ALTER TABLE [dbo].[monedas]
ADD CONSTRAINT [PK_monedas]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [id], [idMonedaOrigen], [idMonedaDestino], [FactorConversion] in table 'ConversionFactores'
ALTER TABLE [dbo].[ConversionFactores]
ADD CONSTRAINT [PK_ConversionFactores]
    PRIMARY KEY CLUSTERED ([id], [idMonedaOrigen], [idMonedaDestino], [FactorConversion] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idMonedaDestino] in table 'ConversionFactores'
ALTER TABLE [dbo].[ConversionFactores]
ADD CONSTRAINT [FK_ConversionFactores_idMonedaDestino2]
    FOREIGN KEY ([idMonedaDestino])
    REFERENCES [dbo].[monedas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConversionFactores_idMonedaDestino2'
CREATE INDEX [IX_FK_ConversionFactores_idMonedaDestino2]
ON [dbo].[ConversionFactores]
    ([idMonedaDestino]);
GO

-- Creating foreign key on [idMonedaOrigen] in table 'ConversionFactores'
ALTER TABLE [dbo].[ConversionFactores]
ADD CONSTRAINT [FK_ConversionFactores_idMonedaOrigen]
    FOREIGN KEY ([idMonedaOrigen])
    REFERENCES [dbo].[monedas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConversionFactores_idMonedaOrigen'
CREATE INDEX [IX_FK_ConversionFactores_idMonedaOrigen]
ON [dbo].[ConversionFactores]
    ([idMonedaOrigen]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------