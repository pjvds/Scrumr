
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/09/2010 14:13:46
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

IF OBJECT_ID(N'[dbo].[FK_StoryTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_StoryTask];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskStage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_TaskStage];
GO
IF OBJECT_ID(N'[dbo].[FK_SprintStage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stages] DROP CONSTRAINT [FK_SprintStage];
GO
IF OBJECT_ID(N'[dbo].[FK_SprintStory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stories] DROP CONSTRAINT [FK_SprintStory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[Tasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tasks];
GO
IF OBJECT_ID(N'[dbo].[Stages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stages];
GO
IF OBJECT_ID(N'[dbo].[Stories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stories];
GO
IF OBJECT_ID(N'[dbo].[Sprints]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sprints];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ShortCode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tasks'
CREATE TABLE [dbo].[Tasks] (
    [Id] uniqueidentifier  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Story_Id] uniqueidentifier  NOT NULL,
    [Stage_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Stages'
CREATE TABLE [dbo].[Stages] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Sprint_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Stories'
CREATE TABLE [dbo].[Stories] (
    [Id] uniqueidentifier  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Sprint_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Sprints'
CREATE TABLE [dbo].[Sprints] (
    [Id] uniqueidentifier  NOT NULL,
    [ProjectId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [From] datetime  NOT NULL,
    [To] datetime  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
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

-- Creating primary key on [Id] in table 'Sprints'
ALTER TABLE [dbo].[Sprints]
ADD CONSTRAINT [PK_Sprints]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- Creating foreign key on [Stage_Id] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_TaskStage]
    FOREIGN KEY ([Stage_Id])
    REFERENCES [dbo].[Stages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskStage'
CREATE INDEX [IX_FK_TaskStage]
ON [dbo].[Tasks]
    ([Stage_Id]);
GO

-- Creating foreign key on [Sprint_Id] in table 'Stages'
ALTER TABLE [dbo].[Stages]
ADD CONSTRAINT [FK_SprintStage]
    FOREIGN KEY ([Sprint_Id])
    REFERENCES [dbo].[Sprints]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SprintStage'
CREATE INDEX [IX_FK_SprintStage]
ON [dbo].[Stages]
    ([Sprint_Id]);
GO

-- Creating foreign key on [Sprint_Id] in table 'Stories'
ALTER TABLE [dbo].[Stories]
ADD CONSTRAINT [FK_SprintStory]
    FOREIGN KEY ([Sprint_Id])
    REFERENCES [dbo].[Sprints]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SprintStory'
CREATE INDEX [IX_FK_SprintStory]
ON [dbo].[Stories]
    ([Sprint_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------