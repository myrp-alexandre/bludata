use master
drop database bludata_db
create database bludata_db
use bludata_db




-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [estado]

CREATE TABLE [estado]
(
 [estado_id] int identity(1,1) NOT NULL ,
 [sigla]     varchar(2) NOT NULL ,
 [nome]      varchar(100) NOT NULL ,


 CONSTRAINT [PK_estado] PRIMARY KEY CLUSTERED ([estado_id] ASC)
);
GO








-- ************************************** [empresa]

CREATE TABLE [empresa]
(
 [cnpj]          varchar(14) NOT NULL ,
 [nome_fantasia] varchar(100) NOT NULL ,
 [estado_id]     int NOT NULL ,


 CONSTRAINT [PK_empresas] PRIMARY KEY CLUSTERED ([cnpj] ASC),
 CONSTRAINT [FK_69] FOREIGN KEY ([estado_id])  REFERENCES [estado]([estado_id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_69] ON [empresa] 
 (
  [estado_id] ASC
 )

GO








-- ************************************** [pessoa_fisica]

CREATE TABLE [pessoa_fisica]
(
 [cpf]             varchar(11) NOT NULL ,
 [rg]              varchar(10) NULL ,
 [data_nascimento] datetime NULL ,


 CONSTRAINT [PK_pessoa_cpf] PRIMARY KEY CLUSTERED ([cpf] ASC)
);
GO








-- ************************************** [fornecedor]

CREATE TABLE [fornecedor]
(
 [fornecedor_id] int identity(1,1) NOT NULL ,
 [nome]          varchar(100) NOT NULL ,
 [data_cadastro] datetime NOT NULL ,
 [cpf]           varchar(11) NULL ,
 [empresa_cnpj]  varchar(14) NULL ,
 [cnpj]          varchar(14) NULL ,


 CONSTRAINT [PK_fornecedor] PRIMARY KEY CLUSTERED ([fornecedor_id] ASC),
 CONSTRAINT [FK_25] FOREIGN KEY ([cpf])  REFERENCES [pessoa_fisica]([cpf]),
 CONSTRAINT [FK_61] FOREIGN KEY ([empresa_cnpj])  REFERENCES [empresa]([cnpj])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_25] ON [fornecedor] 
 (
  [cpf] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_61] ON [fornecedor] 
 (
  [empresa_cnpj] ASC
 )

GO









CREATE TABLE [telefone]
(
 [telefone_id]     int identity(1,1) NOT NULL ,
 [numero]        varchar(14) NOT NULL ,
 [fornecedor_id] int NOT NULL ,


 CONSTRAINT [PK_telefone] PRIMARY KEY CLUSTERED ([telefone_id] ASC),
 CONSTRAINT [FK_75] FOREIGN KEY ([fornecedor_id])  REFERENCES [fornecedor]([fornecedor_id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_75] ON [telefone] 
 (
  [fornecedor_id] ASC
 )

GO








insert into estado values ('PA', 'Pará')
insert into empresa values ('77854081000111', 'bludata', 1)
insert into pessoa_fisica values ('05487594655', null, null)
insert into fornecedor values ('Estêvão Braga', GETDATE(), '05487594655', '77854081000111', null)
insert into telefone values ('5591999999999', 1)
