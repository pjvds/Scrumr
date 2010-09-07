
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/07/2010 17:02:40
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

-- Creating table 'Tasks'
CREATE TABLE [dbo].[Tasks] (
    [Id] uniqueidentifier  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Story_Id] uniqueidentifier  NOT NULL,
    [Stages_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Stages'
CREATE TABLE [dbo].[Stages] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Scrumboard_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Stories'
CREATE TABLE [dbo].[Stories] (
    [Id] uniqueidentifier  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Scrumboard_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Scrumboards'
CREATE TABLE [dbo].[Scrumboards] (
    [Id] uniqueidentifier  NOT NULL
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

-- Creating primary key on [Id] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [PK_Tasks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Stages'
ALTER TABLE [dbo].[Stages]
ADD CONSTRAINT [PK_Stages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Stories'
ALTER TABLE [dbo].[Stories]
ADD CONSTRAINT [PK_Stories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Scrumboards'
ALTER TABLE [dbo].[Scrumboards]
ADD CONSTRAINT [PK_Scrumboards]
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

-- Creating foreign key on [Scrumboard_Id] in table 'Stories'
ALTER TABLE [dbo].[Stories]
ADD CONSTRAINT [FK_ScrumboardStory]
    FOREIGN KEY ([Scrumboard_Id])
    REFERENCES [dbo].[Scrumboards]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ScrumboardStory'
CREATE INDEX [IX_FK_ScrumboardStory]
ON [dbo].[Stories]
    ([Scrumboard_Id]);
GO

-- Creating foreign key on [Story_Id] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_StoryTask]
    FOREIGN KEY ([Story_Id])
    REFERENCES [dbo].[Stories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StoryTask'
CREATE INDEX [IX_FK_StoryTask]
ON [dbo].[Tasks]
    ([Story_Id]);
GO

-- Creating foreign key on [Scrumboard_Id] in table 'Stages'
ALTER TABLE [dbo].[Stages]
ADD CONSTRAINT [FK_ScrumboardStage]
    FOREIGN KEY ([Scrumboard_Id])
    REFERENCES [dbo].[Scrumboards]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ScrumboardStage'
CREATE INDEX [IX_FK_ScrumboardStage]
ON [dbo].[Stages]
    ([Scrumboard_Id]);
GO

-- Creating foreign key on [Stages_Id] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_TaskStage]
    FOREIGN KEY ([Stages_Id])
    REFERENCES [dbo].[Stages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskStage'
CREATE INDEX [IX_FK_TaskStage]
ON [dbo].[Tasks]
    ([Stages_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------