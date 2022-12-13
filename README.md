Base de Datos Mysql:

DROP DATABASE IF EXISTS cheil2;
CREATE DATABASE cheil2;
USE cheil2;

DROP TABLE IF EXISTS hoteles;
CREATE TABLE hoteles (
	HotelID INT AUTO_INCREMENT,
	HotelName VARCHAR(250) NOT NULL,
	Categoria VARCHAR(250) NOT NULL,
	Precio FLOAT(11,2) NOT NULL,
	foto1 VARCHAR(250) NOT NULL,
	foto2 VARCHAR(250) NOT NULL,
	foto3 VARCHAR(250) NOT NULL,
	PRIMARY KEY (HotelID)
); ALTER TABLE hoteles CONVERT TO CHARACTER SET utf8 COLLATE utf8_unicode_ci;

INSERT INTO hoteles (HotelName,Categoria,Precio,foto1,foto2,foto3) VALUES 
('Hotel1','Categoria1',100,'foto1','foto2','foto3'),
('Hotel1','Categoria1',100,'foto1','foto2','foto3');

DROP TABLE IF EXISTS calificaciones;
CREATE TABLE calificaciones (
	id INT AUTO_INCREMENT,
	HotelID INT NOT NULL,
	calificacion INT NOT NULL,
	comentario VARCHAR(250) NOT NULL,
	PRIMARY KEY (id)
); ALTER TABLE calificaciones CONVERT TO CHARACTER SET utf8 COLLATE utf8_unicode_ci;

INSERT INTO calificaciones (HotelID,calificacion,comentario) VALUES 
(1,5,"Comentario de Prueba 1"),
(2,4,"Comentario de Prueba 2");
