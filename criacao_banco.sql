CREATE DATABASE db_mvc;
USE db_mvc;
GO
CREATE TABLE usuarios 
(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nome NVARCHAR(50),
	usuario NVARCHAR(50),
	senha NVARCHAR(50)
);
GO
INSERT INTO db_mvc.usuarios 
( nome, usuario, senha ) VALUES 
('Admin','admin','123');