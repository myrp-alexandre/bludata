# Listagem de Fornecedores

## Descrição
Sistema de gestão de fornecedores, usando: 

Arquitetura: DDD(_Domain Driven Design_) 
Bibliotecas: 
- _Auto Mapper_ 
- _Newtonsoft Json_ 
- _Entity Framework Core Sql Server_ 
- _Fluent Validation_ 
Documentação: _Swagger 4.0.1_ 
Front-End: VueJS com Quasar Framework

## Requisitos 
- dotnet core SDK - 2.2 
- dotnet core runtime - 2.2 
- Docker (Recomendado) ou Sql Server 
- NodeJs - v10.15.1
- NPM - 6.4.1
- Vue - 3.4.1 
- Quasar - v1
- Windows ou Linux 

## Iniciando o Projeto
#### 1) Baixe o projeto
`git clone https://github.com/estevaobraga/bludata.git` 

#### 2) Com Docker 
- Na API REST, pasta /api-bludata 
`docker-compose up --build` 
- Acesse a base de dados e rode o script 'bludata-db.sql' 
Server: _localhost_ 
User: sa 
Password: "sa@123456" 
_localizado em '/bludata/api-bludata/bludata-db.sql'_ 
_Acesse documentação em:_ 
`http://localhost:44399/swagger` 
_Se tudo estiver ok, pular para o passo 4_ 

#### 3) API REST - Restaurar os pacotes e rodar Api
- Na API REST, pasta /api-bludata 
`dotnet restore` 
- Configurar seu SQL Server, em /api-bludata/api-bludata.cross-cutting.ioc/NativeInjectorBootStrapper.cs 
`"Server=sql-server;Database=bludata_db;User Id=sa;Password=sa@123456;"` 
_Informe o endereço do servidor_ 
_Rode o script bludata-db.sql localizado em '/bludata/api-bludata'_ 
- Buildar projeto, pasta '/api-bludata' 
`dotnet publish -c Release -o ../Publish` 

![Alt Text](/api-bludata/docs/Swagger.PNG)  
_Documentação no swagger_ 

#### 4) Restaure os pacotes do Front-End 
- No Front-End, pasta /bludata 
`npm install` 
- Rodar projeto 
`quasar dev` 
_http://localhost:8080/#/_ 

![Alt Text](/bludata/docs/home.PNG)  
_home_ 

![Alt Text](/bludata/docs/empresa.PNG)  
_tela empresa_ 

![Alt Text](/bludata/docs/telefone.PNG)  
_tela fornecedores_

![Alt Text](/bludata/docs/fornecedores.png)  
_listagem fornecedores_ 