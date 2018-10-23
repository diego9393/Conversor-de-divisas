
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/19/2018 13:11:54
-- Generated from EDMX file: C:\Users\usuario\Documents\GitHub\proyecto-Final\ingenieriaInversa-final\modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [monedasProyecto];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Factores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Factores];
GO
IF OBJECT_ID(N'[dbo].[Historial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Historial];
GO
IF OBJECT_ID(N'[dbo].[Monedas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Monedas];
GO
IF OBJECT_ID(N'[dbo].[Paises]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Paises];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Factores'
CREATE TABLE [dbo].[Factores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Id_Origen] varchar(50)  NOT NULL,
    [Id_Destno] varchar(50)  NOT NULL,
    [Factor] varchar(50)  NOT NULL
);
GO

-- Creating table 'Historial'
CREATE TABLE [dbo].[Historial] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [id_Destino] varchar(50)  NOT NULL,
    [id_origen] varchar(50)  NOT NULL,
    [Resultado] varchar(50)  NULL,
    [Fecha_consulta] varchar(50)  NOT NULL
);
GO

-- Creating table 'Monedas'
CREATE TABLE [dbo].[Monedas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [Id_Moneda] varchar(50)  NOT NULL
);
GO

-- Creating table 'Paises'
CREATE TABLE [dbo].[Paises] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(500)  NOT NULL,
    [Id_Pais] varchar(50)  NOT NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] varchar(50)  NOT NULL,
    [Pass] varchar(50)  NOT NULL,
    [Id_Pais] varchar(50)  NOT NULL,
    [Nombre_y_Apellidos] varchar(50)  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [Fecha_de_nacimiento] varchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id], [Id_Origen], [Id_Destno], [Factor] in table 'Factores'
ALTER TABLE [dbo].[Factores]
ADD CONSTRAINT [PK_Factores]
    PRIMARY KEY CLUSTERED ([Id], [Id_Origen], [Id_Destno], [Factor] ASC);
GO

-- Creating primary key on [Id], [id_Destino], [id_origen], [Fecha_consulta] in table 'Historial'
ALTER TABLE [dbo].[Historial]
ADD CONSTRAINT [PK_Historial]
    PRIMARY KEY CLUSTERED ([Id], [id_Destino], [id_origen], [Fecha_consulta] ASC);
GO

-- Creating primary key on [Id], [Nombre], [Id_Moneda] in table 'Monedas'
ALTER TABLE [dbo].[Monedas]
ADD CONSTRAINT [PK_Monedas]
    PRIMARY KEY CLUSTERED ([Id], [Nombre], [Id_Moneda] ASC);
GO

-- Creating primary key on [Id], [Nombre], [Id_Pais] in table 'Paises'
ALTER TABLE [dbo].[Paises]
ADD CONSTRAINT [PK_Paises]
    PRIMARY KEY CLUSTERED ([Id], [Nombre], [Id_Pais] ASC);
GO

-- Creating primary key on [Id], [Login], [Pass], [Id_Pais], [Nombre_y_Apellidos], [Email], [Fecha_de_nacimiento] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([Id], [Login], [Pass], [Id_Pais], [Nombre_y_Apellidos], [Email], [Fecha_de_nacimiento] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------