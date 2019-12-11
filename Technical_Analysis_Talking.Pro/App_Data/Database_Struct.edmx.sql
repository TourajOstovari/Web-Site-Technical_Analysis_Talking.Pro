
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/02/2019 18:29:35
-- Generated from EDMX file: C:\Users\Toraj\Desktop\TechnicalAnalysis.Talking.Pro\MVC_Project\Technical_Analysis_Talking.Pro\Technical_Analysis_Talking.Pro\App_Data\Database_Struct.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Technical_Talking.pro];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Posts_Set]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Posts_Set];
GO
IF OBJECT_ID(N'[dbo].[Users_Set]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Set];
GO
IF OBJECT_ID(N'[dbo].[news_subscribe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[news_subscribe];
GO
IF OBJECT_ID(N'[dbo].[Interest_rate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Interest_rate];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Posts_Set'
CREATE TABLE [dbo].[Posts_Set] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [title] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [authore] nvarchar(max)  NOT NULL,
    [date] nvarchar(max)  NOT NULL,
    [image] nvarchar(max)  NOT NULL,
    [symbol] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users_Set'
CREATE TABLE [dbo].[Users_Set] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [last_login_time] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'news_subscribe'
CREATE TABLE [dbo].[news_subscribe] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [email_address] nvarchar(max)  NOT NULL,
    [nick_name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Interest_rate'
CREATE TABLE [dbo].[Interest_rate] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [usd_rate] nvarchar(max)  NOT NULL,
    [gbp_rate] nvarchar(max)  NOT NULL,
    [eur_rate] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Posts_Set'
ALTER TABLE [dbo].[Posts_Set]
ADD CONSTRAINT [PK_Posts_Set]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users_Set'
ALTER TABLE [dbo].[Users_Set]
ADD CONSTRAINT [PK_Users_Set]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'news_subscribe'
ALTER TABLE [dbo].[news_subscribe]
ADD CONSTRAINT [PK_news_subscribe]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Interest_rate'
ALTER TABLE [dbo].[Interest_rate]
ADD CONSTRAINT [PK_Interest_rate]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------