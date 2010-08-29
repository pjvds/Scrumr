
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/29/2010 10:40:59
-- Generated from EDMX file: C:\projects\Scrumr\src\Scrumr.Web.MainSite.ReadModel\ReadModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ScrumrWebMainSiteReadModel];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProductBacklogStory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StoryModels] DROP CONSTRAINT [FK_ProductBacklogStory];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectModelProductBacklog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectModels] DROP CONSTRAINT [FK_ProjectModelProductBacklog];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProjectModels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectModels];
GO
IF OBJECT_ID(N'[dbo].[ProductBacklogModels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductBacklogModels];
GO
IF OBJECT_ID(N'[dbo].[StoryModels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StoryModels];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProjectModels'
CREATE TABLE [dbo].[ProjectModels] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ProductBacklog_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ProductBacklogModels'
CREATE TABLE [dbo].[ProductBacklogModels] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StoryModels'
CREATE TABLE [dbo].[StoryModels] (
    [Id] uniqueidentifier  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ProductBacklog_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ProjectModels'
ALTER TABLE [dbo].[ProjectModels]
ADD CONSTRAINT [PK_ProjectModels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductBacklogModels'
ALTER TABLE [dbo].[ProductBacklogModels]
ADD CONSTRAINT [PK_ProductBacklogModels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StoryModels'
ALTER TABLE [dbo].[StoryModels]
ADD CONSTRAINT [PK_StoryModels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProductBacklog_Id] in table 'StoryModels'
ALTER TABLE [dbo].[StoryModels]
ADD CONSTRAINT [FK_ProductBacklogStory]
    FOREIGN KEY ([ProductBacklog_Id])
    REFERENCES [dbo].[ProductBacklogModels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductBacklogStory'
CREATE INDEX [IX_FK_ProductBacklogStory]
ON [dbo].[StoryModels]
    ([ProductBacklog_Id]);
GO

-- Creating foreign key on [ProductBacklog_Id] in table 'ProjectModels'
ALTER TABLE [dbo].[ProjectModels]
ADD CONSTRAINT [FK_ProjectModelProductBacklog]
    FOREIGN KEY ([ProductBacklog_Id])
    REFERENCES [dbo].[ProductBacklogModels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectModelProductBacklog'
CREATE INDEX [IX_FK_ProjectModelProductBacklog]
ON [dbo].[ProjectModels]
    ([ProductBacklog_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------