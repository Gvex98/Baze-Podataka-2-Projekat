
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2021 20:32:44
-- Generated from EDMX file: C:\Users\Milan\source\repos\BioskopData\BioskopData\ADONETBioskop.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyDataBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_KartaKupac]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kartas] DROP CONSTRAINT [FK_KartaKupac];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjekcijaKarta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kartas] DROP CONSTRAINT [FK_ProjekcijaKarta];
GO
IF OBJECT_ID(N'[dbo].[FK_KartaProdavac]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kartas] DROP CONSTRAINT [FK_KartaProdavac];
GO
IF OBJECT_ID(N'[dbo].[FK_FilmProjekcija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projekcijas] DROP CONSTRAINT [FK_FilmProjekcija];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjekcijaSala]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projekcijas] DROP CONSTRAINT [FK_ProjekcijaSala];
GO
IF OBJECT_ID(N'[dbo].[FK_SalaProjektor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projektors] DROP CONSTRAINT [FK_SalaProjektor];
GO
IF OBJECT_ID(N'[dbo].[FK_Prodavac_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_Prodavac] DROP CONSTRAINT [FK_Prodavac_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Projektant_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_Projektant] DROP CONSTRAINT [FK_Projektant_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Domar_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_Domar] DROP CONSTRAINT [FK_Domar_inherits_Radnik];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Films]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Films];
GO
IF OBJECT_ID(N'[dbo].[Salas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Salas];
GO
IF OBJECT_ID(N'[dbo].[Kartas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kartas];
GO
IF OBJECT_ID(N'[dbo].[Radniks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks];
GO
IF OBJECT_ID(N'[dbo].[Projektors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projektors];
GO
IF OBJECT_ID(N'[dbo].[Kupacs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kupacs];
GO
IF OBJECT_ID(N'[dbo].[Projekcijas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projekcijas];
GO
IF OBJECT_ID(N'[dbo].[Radniks_Prodavac]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_Prodavac];
GO
IF OBJECT_ID(N'[dbo].[Radniks_Projektant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_Projektant];
GO
IF OBJECT_ID(N'[dbo].[Radniks_Domar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_Domar];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Films'
CREATE TABLE [dbo].[Films] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Zanr] nvarchar(max)  NOT NULL,
    [DuzinaTrajanja] int  NOT NULL
);
GO

-- Creating table 'Salas'
CREATE TABLE [dbo].[Salas] (
    [Broj] int IDENTITY(1,1) NOT NULL,
    [BrojMesta] int  NOT NULL
);
GO

-- Creating table 'Kartas'
CREATE TABLE [dbo].[Kartas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BrojSedista] int  NOT NULL,
    [Cena] int  NOT NULL,
    [KupacId] int  NOT NULL,
    [ProjekcijaId] int  NOT NULL,
    [ProdavacJMBG] int  NULL
);
GO

-- Creating table 'Radniks'
CREATE TABLE [dbo].[Radniks] (
    [JMBG] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Plata] int  NOT NULL
);
GO

-- Creating table 'Projektors'
CREATE TABLE [dbo].[Projektors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Cena] int  NOT NULL,
    [Sala_Broj] int  NULL
);
GO

-- Creating table 'Kupacs'
CREATE TABLE [dbo].[Kupacs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Projekcijas'
CREATE TABLE [dbo].[Projekcijas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Pocetak] datetime  NOT NULL,
    [Kraj] datetime  NOT NULL,
    [FilmId] int  NOT NULL,
    [SalaBroj] int  NOT NULL
);
GO

-- Creating table 'Odrzavas'
CREATE TABLE [dbo].[Odrzavas] (
    [SalaBroj] int  NOT NULL,
    [DomarJMBG] int  NOT NULL
);
GO

-- Creating table 'Osposobljens'
CREATE TABLE [dbo].[Osposobljens] (
    [ProjektantJMBG] int  NOT NULL,
    [ProjektorId] int  NOT NULL
);
GO

-- Creating table 'Radniks_Prodavac'
CREATE TABLE [dbo].[Radniks_Prodavac] (
    [JMBG] int  NOT NULL
);
GO

-- Creating table 'Radniks_Domar'
CREATE TABLE [dbo].[Radniks_Domar] (
    [JMBG] int  NOT NULL
);
GO

-- Creating table 'Radniks_Projektant'
CREATE TABLE [dbo].[Radniks_Projektant] (
    [JMBG] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Films'
ALTER TABLE [dbo].[Films]
ADD CONSTRAINT [PK_Films]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Broj] in table 'Salas'
ALTER TABLE [dbo].[Salas]
ADD CONSTRAINT [PK_Salas]
    PRIMARY KEY CLUSTERED ([Broj] ASC);
GO

-- Creating primary key on [Id] in table 'Kartas'
ALTER TABLE [dbo].[Kartas]
ADD CONSTRAINT [PK_Kartas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radniks'
ALTER TABLE [dbo].[Radniks]
ADD CONSTRAINT [PK_Radniks]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [Id] in table 'Projektors'
ALTER TABLE [dbo].[Projektors]
ADD CONSTRAINT [PK_Projektors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Kupacs'
ALTER TABLE [dbo].[Kupacs]
ADD CONSTRAINT [PK_Kupacs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Projekcijas'
ALTER TABLE [dbo].[Projekcijas]
ADD CONSTRAINT [PK_Projekcijas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [SalaBroj], [DomarJMBG] in table 'Odrzavas'
ALTER TABLE [dbo].[Odrzavas]
ADD CONSTRAINT [PK_Odrzavas]
    PRIMARY KEY CLUSTERED ([SalaBroj], [DomarJMBG] ASC);
GO

-- Creating primary key on [ProjektantJMBG], [ProjektorId] in table 'Osposobljens'
ALTER TABLE [dbo].[Osposobljens]
ADD CONSTRAINT [PK_Osposobljens]
    PRIMARY KEY CLUSTERED ([ProjektantJMBG], [ProjektorId] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radniks_Prodavac'
ALTER TABLE [dbo].[Radniks_Prodavac]
ADD CONSTRAINT [PK_Radniks_Prodavac]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radniks_Domar'
ALTER TABLE [dbo].[Radniks_Domar]
ADD CONSTRAINT [PK_Radniks_Domar]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radniks_Projektant'
ALTER TABLE [dbo].[Radniks_Projektant]
ADD CONSTRAINT [PK_Radniks_Projektant]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [KupacId] in table 'Kartas'
ALTER TABLE [dbo].[Kartas]
ADD CONSTRAINT [FK_KartaKupac]
    FOREIGN KEY ([KupacId])
    REFERENCES [dbo].[Kupacs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KartaKupac'
CREATE INDEX [IX_FK_KartaKupac]
ON [dbo].[Kartas]
    ([KupacId]);
GO

-- Creating foreign key on [ProjekcijaId] in table 'Kartas'
ALTER TABLE [dbo].[Kartas]
ADD CONSTRAINT [FK_ProjekcijaKarta]
    FOREIGN KEY ([ProjekcijaId])
    REFERENCES [dbo].[Projekcijas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjekcijaKarta'
CREATE INDEX [IX_FK_ProjekcijaKarta]
ON [dbo].[Kartas]
    ([ProjekcijaId]);
GO

-- Creating foreign key on [ProdavacJMBG] in table 'Kartas'
ALTER TABLE [dbo].[Kartas]
ADD CONSTRAINT [FK_KartaProdavac]
    FOREIGN KEY ([ProdavacJMBG])
    REFERENCES [dbo].[Radniks_Prodavac]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KartaProdavac'
CREATE INDEX [IX_FK_KartaProdavac]
ON [dbo].[Kartas]
    ([ProdavacJMBG]);
GO

-- Creating foreign key on [FilmId] in table 'Projekcijas'
ALTER TABLE [dbo].[Projekcijas]
ADD CONSTRAINT [FK_FilmProjekcija]
    FOREIGN KEY ([FilmId])
    REFERENCES [dbo].[Films]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilmProjekcija'
CREATE INDEX [IX_FK_FilmProjekcija]
ON [dbo].[Projekcijas]
    ([FilmId]);
GO

-- Creating foreign key on [SalaBroj] in table 'Projekcijas'
ALTER TABLE [dbo].[Projekcijas]
ADD CONSTRAINT [FK_ProjekcijaSala]
    FOREIGN KEY ([SalaBroj])
    REFERENCES [dbo].[Salas]
        ([Broj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjekcijaSala'
CREATE INDEX [IX_FK_ProjekcijaSala]
ON [dbo].[Projekcijas]
    ([SalaBroj]);
GO

-- Creating foreign key on [Sala_Broj] in table 'Projektors'
ALTER TABLE [dbo].[Projektors]
ADD CONSTRAINT [FK_SalaProjektor]
    FOREIGN KEY ([Sala_Broj])
    REFERENCES [dbo].[Salas]
        ([Broj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalaProjektor'
CREATE INDEX [IX_FK_SalaProjektor]
ON [dbo].[Projektors]
    ([Sala_Broj]);
GO

-- Creating foreign key on [SalaBroj] in table 'Odrzavas'
ALTER TABLE [dbo].[Odrzavas]
ADD CONSTRAINT [FK_SalaOdrzava]
    FOREIGN KEY ([SalaBroj])
    REFERENCES [dbo].[Salas]
        ([Broj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DomarJMBG] in table 'Odrzavas'
ALTER TABLE [dbo].[Odrzavas]
ADD CONSTRAINT [FK_OdrzavaDomar]
    FOREIGN KEY ([DomarJMBG])
    REFERENCES [dbo].[Radniks_Domar]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OdrzavaDomar'
CREATE INDEX [IX_FK_OdrzavaDomar]
ON [dbo].[Odrzavas]
    ([DomarJMBG]);
GO

-- Creating foreign key on [ProjektantJMBG] in table 'Osposobljens'
ALTER TABLE [dbo].[Osposobljens]
ADD CONSTRAINT [FK_OsposobljenProjektant]
    FOREIGN KEY ([ProjektantJMBG])
    REFERENCES [dbo].[Radniks_Projektant]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProjektorId] in table 'Osposobljens'
ALTER TABLE [dbo].[Osposobljens]
ADD CONSTRAINT [FK_OsposobljenProjektor]
    FOREIGN KEY ([ProjektorId])
    REFERENCES [dbo].[Projektors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OsposobljenProjektor'
CREATE INDEX [IX_FK_OsposobljenProjektor]
ON [dbo].[Osposobljens]
    ([ProjektorId]);
GO

-- Creating foreign key on [JMBG] in table 'Radniks_Prodavac'
ALTER TABLE [dbo].[Radniks_Prodavac]
ADD CONSTRAINT [FK_Prodavac_inherits_Radnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Radniks]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Radniks_Domar'
ALTER TABLE [dbo].[Radniks_Domar]
ADD CONSTRAINT [FK_Domar_inherits_Radnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Radniks]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Radniks_Projektant'
ALTER TABLE [dbo].[Radniks_Projektant]
ADD CONSTRAINT [FK_Projektant_inherits_Radnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Radniks]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------