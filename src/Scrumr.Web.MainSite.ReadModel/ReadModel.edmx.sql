
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/31/2010 22:15:29
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

IF OBJECT_ID(N'[dbo].[FK_ProjectModelStoryModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StoryModels] DROP CONSTRAINT [FK_ProjectModelStoryModel];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProjectModels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectModels];
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
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StoryModels'
CREATE TABLE [dbo].[StoryModels] (
    [Id] uniqueidentifier  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ProjectModel_Id] uniqueidentifier  NOT NULL
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

-- Creating primary key on [Id] in table 'StoryModels'
ALTER TABLE [dbo].[StoryModels]
ADD CONSTRAINT [PK_StoryModels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProjectModel_Id] in table 'StoryModels'
ALTER TABLE [dbo].[StoryModels]
ADD CONSTRAINT [FK_ProjectModelStoryModel]
    FOREIGN KEY ([ProjectModel_Id])
    REFERENCES [dbo].[ProjectModels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectModelStoryModel'
CREATE INDEX [IX_FK_ProjectModelStoryModel]
ON [dbo].[StoryModels]
    ([ProjectModel_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------