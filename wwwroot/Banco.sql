/*DROP DATABASE projcadastros;
CREATE DATABASE projcadastros;
USE projcadastros;

CREATE table pessoa(
id int(2) PRIMARY key AUTO_INCREMENT,
nome  varchar (200) not null,
login varchar (200) not null,
senha varchar (200) not null,
tipo int (1) NOT null,
Data date not null
);

CREATE TABLE objeto(
IDProduto int primary key AUTO_INCREMENT ,
nomePacote varchar (200) NOT null,
origemPacote varchar (200) not null,
destinoPacote varchar (100) not null,
atrativosPacote varchar (500) not null,
saidaPacote DateTime NOT  null,
retornoPacote DateTime not null, 
IDusuario int, constraint fk_IDusuario FOREIGN key(IDusuario) REFERENCES pessoa (id));

*/


create table pacotes( IdProduto int PRIMARY KEY AUTO_INCREMENT, Nome varchar(200), Origem varchar(200), Destino varchar(100), Atrativos varchar(200), Saida date, Retorno date, Login varchar(10), Senha varchar(4), tipo varchar(2), ID_Usuario int, constraint fk_ID_Usuario FOREIGN key(Id_Usuario) REFERENCES usuario (idUsuario)) 
create table usuario( 
    IdUsuario int PRIMARY KEY AUTO_INCREMENT,
     Nome varchar(200),
     Data date,
     Login varchar(10),
     Senha varchar(4),
     tipo varchar(2)
     )