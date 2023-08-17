CREATE DATABASE storePokemon;

USE storePokemon;

CREATE TABLE Clients (
  idClient INT PRIMARY KEY AUTO_INCREMENT,
  nomClient VARCHAR(150),
  cognoms VARCHAR(100),
  adreça VARCHAR(200),
  població VARCHAR(200),
  telèfon VARCHAR(50),
  responsable VARCHAR(150),
  emailContacte VARCHAR(150)
);

CREATE TABLE Comandes (
  idComanda INT PRIMARY KEY AUTO_INCREMENT,
  idClient INT,
  dataComanda DATETIME,
  formaPagament VARCHAR(50),
  descompte INT,
  enviat BOOLEAN,
  FOREIGN KEY (idClient) REFERENCES Clients(idClient)
);

CREATE TABLE Articles (
  idArticle INT PRIMARY KEY AUTO_INCREMENT,
  nomArticle VARCHAR(100),
  seccioMagatzem VARCHAR(100),
  preuUnitat FLOAT,
  disponibilitat INT,
  origen VARCHAR(100)
);

CREATE TABLE Detalls (
  idComanda INT,
  idArticle INT,
  quantitat INT,
  PRIMARY KEY (idComanda, idArticle),
  FOREIGN KEY (idComanda) REFERENCES Comandes(idComanda),
  FOREIGN KEY (idArticle) REFERENCES Articles(idArticle)
);