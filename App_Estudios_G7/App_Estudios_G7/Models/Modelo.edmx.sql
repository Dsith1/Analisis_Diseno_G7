
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/15/2019 18:31:46
-- Generated from EDMX file: C:\Users\crisa\Documents\GitHub\Analisis_Diseno_G7\App_Estudios_G7\App_Estudios_G7\Models\Modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Sistema_estudios];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__CURSO__creador__3A81B327]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CURSOes] DROP CONSTRAINT [FK__CURSO__creador__3A81B327];
GO
IF OBJECT_ID(N'[dbo].[FK__EXAMEN__curso__48CFD27E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EXAMEN] DROP CONSTRAINT [FK__EXAMEN__curso__48CFD27E];
GO
IF OBJECT_ID(N'[dbo].[FK__TAREA__curso__412EB0B6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TAREAs] DROP CONSTRAINT [FK__TAREA__curso__412EB0B6];
GO
IF OBJECT_ID(N'[dbo].[FK__NOTA_EXAM__exame__4CA06362]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NOTA_EXAMEN] DROP CONSTRAINT [FK__NOTA_EXAM__exame__4CA06362];
GO
IF OBJECT_ID(N'[dbo].[FK__NOTA_EXAM__estud__4D94879B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NOTA_EXAMEN] DROP CONSTRAINT [FK__NOTA_EXAM__estud__4D94879B];
GO
IF OBJECT_ID(N'[dbo].[FK__NOTA_TARE__estud__45F365D3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NOTA_TAREA] DROP CONSTRAINT [FK__NOTA_TARE__estud__45F365D3];
GO
IF OBJECT_ID(N'[dbo].[FK__NOTA_TARE__tarea__44FF419A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NOTA_TAREA] DROP CONSTRAINT [FK__NOTA_TARE__tarea__44FF419A];
GO
IF OBJECT_ID(N'[dbo].[FK_ASIGNACION_CURSO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ASIGNACION] DROP CONSTRAINT [FK_ASIGNACION_CURSO];
GO
IF OBJECT_ID(N'[dbo].[FK_ASIGNACION_USUARIO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ASIGNACION] DROP CONSTRAINT [FK_ASIGNACION_USUARIO];
GO
IF OBJECT_ID(N'[dbo].[FK__ACTIVIDAD__curso__5DCAEF64]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ACTIVIDADs] DROP CONSTRAINT [FK__ACTIVIDAD__curso__5DCAEF64];
GO
IF OBJECT_ID(N'[dbo].[FK__COMENTARI__curso__6383C8BA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[COMENTARIOs] DROP CONSTRAINT [FK__COMENTARI__curso__6383C8BA];
GO
IF OBJECT_ID(N'[dbo].[FK__COMENTARI__estud__6477ECF3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[COMENTARIOs] DROP CONSTRAINT [FK__COMENTARI__estud__6477ECF3];
GO
IF OBJECT_ID(N'[dbo].[FK__PUBLICACI__curso__60A75C0F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PUBLICACIONs] DROP CONSTRAINT [FK__PUBLICACI__curso__60A75C0F];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CURSOes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CURSOes];
GO
IF OBJECT_ID(N'[dbo].[EXAMEN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EXAMEN];
GO
IF OBJECT_ID(N'[dbo].[NOTA_EXAMEN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NOTA_EXAMEN];
GO
IF OBJECT_ID(N'[dbo].[NOTA_TAREA]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NOTA_TAREA];
GO
IF OBJECT_ID(N'[dbo].[TAREAs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TAREAs];
GO
IF OBJECT_ID(N'[dbo].[USUARIOs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[USUARIOs];
GO
IF OBJECT_ID(N'[dbo].[ACTIVIDADs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ACTIVIDADs];
GO
IF OBJECT_ID(N'[dbo].[COMENTARIOs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[COMENTARIOs];
GO
IF OBJECT_ID(N'[dbo].[PUBLICACIONs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PUBLICACIONs];
GO
IF OBJECT_ID(N'[dbo].[ASIGNACION]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ASIGNACION];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CURSOes'
CREATE TABLE [dbo].[CURSOes] (
    [id_curso] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(20)  NOT NULL,
    [creador] int  NOT NULL
);
GO

-- Creating table 'EXAMEN'
CREATE TABLE [dbo].[EXAMEN] (
    [id_examen] int IDENTITY(1,1) NOT NULL,
    [preguntas] varchar(max)  NULL,
    [Fecha] datetime  NOT NULL,
    [minutos] int  NOT NULL,
    [curso] int  NOT NULL
);
GO

-- Creating table 'NOTA_EXAMEN'
CREATE TABLE [dbo].[NOTA_EXAMEN] (
    [estudiante] int  NOT NULL,
    [examen] int  NOT NULL,
    [nota] int  NOT NULL
);
GO

-- Creating table 'NOTA_TAREA'
CREATE TABLE [dbo].[NOTA_TAREA] (
    [estudiante] int  NOT NULL,
    [tarea] int  NOT NULL,
    [nota] int  NOT NULL
);
GO

-- Creating table 'TAREAs'
CREATE TABLE [dbo].[TAREAs] (
    [id_tarea] int IDENTITY(1,1) NOT NULL,
    [Enunciado] varchar(20)  NOT NULL,
    [Entrega] datetime  NOT NULL,
    [curso] int  NOT NULL
);
GO

-- Creating table 'USUARIOs'
CREATE TABLE [dbo].[USUARIOs] (
    [id_usuario] int IDENTITY(1,1) NOT NULL,
    [nick] varchar(20)  NOT NULL,
    [contra] varchar(20)  NOT NULL,
    [nombre_1] varchar(20)  NOT NULL,
    [nombre_2] varchar(20)  NULL,
    [apellido_1] varchar(20)  NULL,
    [apellido_2] varchar(20)  NOT NULL,
    [edad] int  NOT NULL,
    [correo] varchar(20)  NOT NULL
);
GO

-- Creating table 'ACTIVIDADs'
CREATE TABLE [dbo].[ACTIVIDADs] (
    [id_Actividad] int IDENTITY(1,1) NOT NULL,
    [tipo] int  NOT NULL,
    [id_evento] int  NOT NULL,
    [curso] int  NOT NULL
);
GO

-- Creating table 'COMENTARIOs'
CREATE TABLE [dbo].[COMENTARIOs] (
    [id_Comentario] int IDENTITY(1,1) NOT NULL,
    [info] varchar(max)  NULL,
    [curso] int  NOT NULL,
    [estudiante] int  NULL
);
GO

-- Creating table 'PUBLICACIONs'
CREATE TABLE [dbo].[PUBLICACIONs] (
    [id_publicacon] int IDENTITY(1,1) NOT NULL,
    [info] varchar(max)  NULL,
    [curso] int  NOT NULL
);
GO

-- Creating table 'ASIGNACION'
CREATE TABLE [dbo].[ASIGNACION] (
    [CURSOes1_id_curso] int  NOT NULL,
    [USUARIOs_id_usuario] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id_curso] in table 'CURSOes'
ALTER TABLE [dbo].[CURSOes]
ADD CONSTRAINT [PK_CURSOes]
    PRIMARY KEY CLUSTERED ([id_curso] ASC);
GO

-- Creating primary key on [id_examen] in table 'EXAMEN'
ALTER TABLE [dbo].[EXAMEN]
ADD CONSTRAINT [PK_EXAMEN]
    PRIMARY KEY CLUSTERED ([id_examen] ASC);
GO

-- Creating primary key on [estudiante], [examen] in table 'NOTA_EXAMEN'
ALTER TABLE [dbo].[NOTA_EXAMEN]
ADD CONSTRAINT [PK_NOTA_EXAMEN]
    PRIMARY KEY CLUSTERED ([estudiante], [examen] ASC);
GO

-- Creating primary key on [estudiante], [tarea] in table 'NOTA_TAREA'
ALTER TABLE [dbo].[NOTA_TAREA]
ADD CONSTRAINT [PK_NOTA_TAREA]
    PRIMARY KEY CLUSTERED ([estudiante], [tarea] ASC);
GO

-- Creating primary key on [id_tarea] in table 'TAREAs'
ALTER TABLE [dbo].[TAREAs]
ADD CONSTRAINT [PK_TAREAs]
    PRIMARY KEY CLUSTERED ([id_tarea] ASC);
GO

-- Creating primary key on [id_usuario] in table 'USUARIOs'
ALTER TABLE [dbo].[USUARIOs]
ADD CONSTRAINT [PK_USUARIOs]
    PRIMARY KEY CLUSTERED ([id_usuario] ASC);
GO

-- Creating primary key on [id_Actividad] in table 'ACTIVIDADs'
ALTER TABLE [dbo].[ACTIVIDADs]
ADD CONSTRAINT [PK_ACTIVIDADs]
    PRIMARY KEY CLUSTERED ([id_Actividad] ASC);
GO

-- Creating primary key on [id_Comentario] in table 'COMENTARIOs'
ALTER TABLE [dbo].[COMENTARIOs]
ADD CONSTRAINT [PK_COMENTARIOs]
    PRIMARY KEY CLUSTERED ([id_Comentario] ASC);
GO

-- Creating primary key on [id_publicacon] in table 'PUBLICACIONs'
ALTER TABLE [dbo].[PUBLICACIONs]
ADD CONSTRAINT [PK_PUBLICACIONs]
    PRIMARY KEY CLUSTERED ([id_publicacon] ASC);
GO

-- Creating primary key on [CURSOes1_id_curso], [USUARIOs_id_usuario] in table 'ASIGNACION'
ALTER TABLE [dbo].[ASIGNACION]
ADD CONSTRAINT [PK_ASIGNACION]
    PRIMARY KEY CLUSTERED ([CURSOes1_id_curso], [USUARIOs_id_usuario] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [creador] in table 'CURSOes'
ALTER TABLE [dbo].[CURSOes]
ADD CONSTRAINT [FK__CURSO__creador__3A81B327]
    FOREIGN KEY ([creador])
    REFERENCES [dbo].[USUARIOs]
        ([id_usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CURSO__creador__3A81B327'
CREATE INDEX [IX_FK__CURSO__creador__3A81B327]
ON [dbo].[CURSOes]
    ([creador]);
GO

-- Creating foreign key on [curso] in table 'EXAMEN'
ALTER TABLE [dbo].[EXAMEN]
ADD CONSTRAINT [FK__EXAMEN__curso__48CFD27E]
    FOREIGN KEY ([curso])
    REFERENCES [dbo].[CURSOes]
        ([id_curso])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__EXAMEN__curso__48CFD27E'
CREATE INDEX [IX_FK__EXAMEN__curso__48CFD27E]
ON [dbo].[EXAMEN]
    ([curso]);
GO

-- Creating foreign key on [curso] in table 'TAREAs'
ALTER TABLE [dbo].[TAREAs]
ADD CONSTRAINT [FK__TAREA__curso__412EB0B6]
    FOREIGN KEY ([curso])
    REFERENCES [dbo].[CURSOes]
        ([id_curso])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TAREA__curso__412EB0B6'
CREATE INDEX [IX_FK__TAREA__curso__412EB0B6]
ON [dbo].[TAREAs]
    ([curso]);
GO

-- Creating foreign key on [examen] in table 'NOTA_EXAMEN'
ALTER TABLE [dbo].[NOTA_EXAMEN]
ADD CONSTRAINT [FK__NOTA_EXAM__exame__4CA06362]
    FOREIGN KEY ([examen])
    REFERENCES [dbo].[EXAMEN]
        ([id_examen])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__NOTA_EXAM__exame__4CA06362'
CREATE INDEX [IX_FK__NOTA_EXAM__exame__4CA06362]
ON [dbo].[NOTA_EXAMEN]
    ([examen]);
GO

-- Creating foreign key on [estudiante] in table 'NOTA_EXAMEN'
ALTER TABLE [dbo].[NOTA_EXAMEN]
ADD CONSTRAINT [FK__NOTA_EXAM__estud__4D94879B]
    FOREIGN KEY ([estudiante])
    REFERENCES [dbo].[USUARIOs]
        ([id_usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [estudiante] in table 'NOTA_TAREA'
ALTER TABLE [dbo].[NOTA_TAREA]
ADD CONSTRAINT [FK__NOTA_TARE__estud__45F365D3]
    FOREIGN KEY ([estudiante])
    REFERENCES [dbo].[USUARIOs]
        ([id_usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [tarea] in table 'NOTA_TAREA'
ALTER TABLE [dbo].[NOTA_TAREA]
ADD CONSTRAINT [FK__NOTA_TARE__tarea__44FF419A]
    FOREIGN KEY ([tarea])
    REFERENCES [dbo].[TAREAs]
        ([id_tarea])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__NOTA_TARE__tarea__44FF419A'
CREATE INDEX [IX_FK__NOTA_TARE__tarea__44FF419A]
ON [dbo].[NOTA_TAREA]
    ([tarea]);
GO

-- Creating foreign key on [CURSOes1_id_curso] in table 'ASIGNACION'
ALTER TABLE [dbo].[ASIGNACION]
ADD CONSTRAINT [FK_ASIGNACION_CURSO]
    FOREIGN KEY ([CURSOes1_id_curso])
    REFERENCES [dbo].[CURSOes]
        ([id_curso])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [USUARIOs_id_usuario] in table 'ASIGNACION'
ALTER TABLE [dbo].[ASIGNACION]
ADD CONSTRAINT [FK_ASIGNACION_USUARIO]
    FOREIGN KEY ([USUARIOs_id_usuario])
    REFERENCES [dbo].[USUARIOs]
        ([id_usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ASIGNACION_USUARIO'
CREATE INDEX [IX_FK_ASIGNACION_USUARIO]
ON [dbo].[ASIGNACION]
    ([USUARIOs_id_usuario]);
GO

-- Creating foreign key on [curso] in table 'ACTIVIDADs'
ALTER TABLE [dbo].[ACTIVIDADs]
ADD CONSTRAINT [FK__ACTIVIDAD__curso__5DCAEF64]
    FOREIGN KEY ([curso])
    REFERENCES [dbo].[CURSOes]
        ([id_curso])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ACTIVIDAD__curso__5DCAEF64'
CREATE INDEX [IX_FK__ACTIVIDAD__curso__5DCAEF64]
ON [dbo].[ACTIVIDADs]
    ([curso]);
GO

-- Creating foreign key on [curso] in table 'COMENTARIOs'
ALTER TABLE [dbo].[COMENTARIOs]
ADD CONSTRAINT [FK__COMENTARI__curso__6383C8BA]
    FOREIGN KEY ([curso])
    REFERENCES [dbo].[CURSOes]
        ([id_curso])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__COMENTARI__curso__6383C8BA'
CREATE INDEX [IX_FK__COMENTARI__curso__6383C8BA]
ON [dbo].[COMENTARIOs]
    ([curso]);
GO

-- Creating foreign key on [estudiante] in table 'COMENTARIOs'
ALTER TABLE [dbo].[COMENTARIOs]
ADD CONSTRAINT [FK__COMENTARI__estud__6477ECF3]
    FOREIGN KEY ([estudiante])
    REFERENCES [dbo].[USUARIOs]
        ([id_usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__COMENTARI__estud__6477ECF3'
CREATE INDEX [IX_FK__COMENTARI__estud__6477ECF3]
ON [dbo].[COMENTARIOs]
    ([estudiante]);
GO

-- Creating foreign key on [curso] in table 'PUBLICACIONs'
ALTER TABLE [dbo].[PUBLICACIONs]
ADD CONSTRAINT [FK__PUBLICACI__curso__60A75C0F]
    FOREIGN KEY ([curso])
    REFERENCES [dbo].[CURSOes]
        ([id_curso])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PUBLICACI__curso__60A75C0F'
CREATE INDEX [IX_FK__PUBLICACI__curso__60A75C0F]
ON [dbo].[PUBLICACIONs]
    ([curso]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------