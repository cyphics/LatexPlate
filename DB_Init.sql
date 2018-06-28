CREATE TABLE [dbo].[Template] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Nom]  VARCHAR (20)  NOT NULL,
    [Desc] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Macro] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Nom]  VARCHAR (20)  NOT NULL,
    [Desc] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Package] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Nom]  VARCHAR (20)  NOT NULL,
    [Desc] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Meta] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Nom]  VARCHAR (20)  NOT NULL,
    [Desc] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Environment] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Nom]  VARCHAR (20)  NOT NULL,
    [Desc] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].TemplateMeta
(
    [Template_FK] INT NOT NULL,
    [Meta_FK] INT NOT NULL,
    [Nom] VARCHAR(50) NOT NULL,
    [Desc] VARCHAR(MAX) NULL,
    PRIMARY KEY ([Template_FK], [Meta_FK]),
	CONSTRAINT [FK_TemplateMeta_to_Template] FOREIGN KEY ([Template_FK]) REFERENCES [dbo].Template ([Id]),
	CONSTRAINT [FK_TemplateMeta_to_Meta] FOREIGN KEY ([Meta_FK]) REFERENCES [dbo].Meta ([Id]),
)

CREATE TABLE [dbo].TemplatePackage
(
    [Template_FK] INT NOT NULL,
    [Package_FK] INT NOT NULL,
    [Nom] VARCHAR(50) NOT NULL,
    [Desc] VARCHAR(MAX) NULL,
    PRIMARY KEY ([Template_FK], [Package_FK]),
	CONSTRAINT [FK_TemplatePackage_to_Template] FOREIGN KEY ([Template_FK]) REFERENCES [dbo].Template ([Id]),
	CONSTRAINT [FK_TemplatePackage_to_Package] FOREIGN KEY ([Package_FK]) REFERENCES [dbo].Package ([Id]),
)


CREATE TABLE [dbo].TemplateEnvironment
(
    [Template_FK] INT NOT NULL,
    [Environment_FK] INT NOT NULL,
    [Nom] VARCHAR(50) NOT NULL,
    [Desc] VARCHAR(MAX) NULL,
    PRIMARY KEY ([Template_FK], [Environment_FK]),
	CONSTRAINT [FK_TemplateEnvironment_to_Template] FOREIGN KEY ([Template_FK]) REFERENCES [dbo].Template ([Id]),
	CONSTRAINT [FK_TemplateEnvironment_to_Environment] FOREIGN KEY ([Environment_FK]) REFERENCES [dbo].Environment ([Id]),
)


CREATE TABLE [dbo].TemplateMacro
(
[Template_FK] INT NOT NULL,
[Macro_FK] INT NOT NULL,
[Nom] VARCHAR(50) NOT NULL,
[Desc] VARCHAR(MAX) NULL,
PRIMARY KEY ([Template_FK], [Macro_FK]),
CONSTRAINT [FK_TemplateMacro_to_Template] FOREIGN KEY ([Template_FK]) REFERENCES [dbo].Template ([Id]),
CONSTRAINT [FK_TemplateMacro_to_Macro] FOREIGN KEY ([Macro_FK]) REFERENCES [dbo].Macro ([Id]),
)

CREATE TABLE [dbo].PackageMeta
(
    [Package_FK] INT NOT NULL,
    [Meta_FK] INT NOT NULL,
    [Nom] VARCHAR(50) NOT NULL,
    [Desc] VARCHAR(MAX) NULL,
    PRIMARY KEY ([Package_FK], [Meta_FK]),
	CONSTRAINT [FK_PackageMeta_to_Package] FOREIGN KEY ([Package_FK]) REFERENCES [dbo].Package ([Id]),
	CONSTRAINT [FK_PackageMeta_to_Meta] FOREIGN KEY ([Meta_FK]) REFERENCES [dbo].Meta ([Id]),
)

CREATE TABLE [dbo].PackageMacro
(
    [Package_FK] INT NOT NULL,
    [Macro_FK] INT NOT NULL,
    [Nom] VARCHAR(50) NOT NULL,
    [Desc] VARCHAR(MAX) NULL,
    PRIMARY KEY ([Package_FK], [Macro_FK]),
	CONSTRAINT [FK_PackageMacro_to_Package] FOREIGN KEY ([Package_FK]) REFERENCES [dbo].Package ([Id]),
	CONSTRAINT [FK_PackageMacro_to_Macro] FOREIGN KEY ([Macro_FK]) REFERENCES [dbo].Macro ([Id]),
)

CREATE TABLE [dbo].PackageEnvironment
(
    [Package_FK] INT NOT NULL,
    [Environment_FK] INT NOT NULL,
    [Nom] VARCHAR(50) NOT NULL,
    [Desc] VARCHAR(MAX) NULL,
    PRIMARY KEY ([Package_FK], [Environment_FK]),
	CONSTRAINT [FK_PackageEnvironment_to_Package] FOREIGN KEY ([Package_FK]) REFERENCES [dbo].Package ([Id]),
	CONSTRAINT [FK_PackageEnvironment_to_Environment] FOREIGN KEY ([Environment_FK]) REFERENCES [dbo].Environment ([Id]),
)

CREATE TABLE [dbo].EnvironmentMeta
(
    [Environment_FK] INT NOT NULL,
    [Meta_FK] INT NOT NULL,
    [Nom] VARCHAR(50) NOT NULL,
    [Desc] VARCHAR(MAX) NULL,
    PRIMARY KEY ([Environment_FK], [Meta_FK]),
	CONSTRAINT [FK_EnvironmentMeta_to_Environment] FOREIGN KEY ([Environment_FK]) REFERENCES [dbo].Environment ([Id]),
	CONSTRAINT [FK_EnvironmentMeta_to_Meta] FOREIGN KEY ([Meta_FK]) REFERENCES [dbo].Meta ([Id]),
)

CREATE TABLE [dbo].MacroMeta
(
    [Macro_FK] INT NOT NULL,
    [Meta_FK] INT NOT NULL,
    [Nom] VARCHAR(50) NOT NULL,
    [Desc] VARCHAR(MAX) NULL,
    PRIMARY KEY ([Macro_FK], [Meta_FK]),
	CONSTRAINT [FK_MacroMeta_to_Macro] FOREIGN KEY ([Macro_FK]) REFERENCES [dbo].Macro ([Id]),
	CONSTRAINT [FK_MacroMeta_to_Meta] FOREIGN KEY ([Meta_FK]) REFERENCES [dbo].Meta ([Id]),
)