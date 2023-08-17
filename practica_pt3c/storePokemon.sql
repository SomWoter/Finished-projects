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

INSERT INTO Clients (nomClient, cognoms, adreça, població, telèfon, responsable, emailContacte)  Values ('Admin', 'Admin', 'Pueblo Admin', 'Población Admin', '633132132', 'Andrei Marin', 'admin@poke.com');
INSERT INTO Clients (nomClient, cognoms, adreça, població, telèfon, responsable, emailContacte)  Values ('Dawn', 'Poke', 'Pueblo HojaVerde', 'Sinnoh', '931553221', 'Andrei Marin', 'dapo@poke.com');
INSERT INTO Clients (nomClient, cognoms, adreça, població, telèfon, responsable, emailContacte)  Values ('Brock', 'Poke', 'Ciudad Plateada', 'Kato', '723211141', 'Andrei Marin', 'brpo@poke.com');
INSERT INTO Clients (nomClient, cognoms, adreça, població, telèfon, responsable, emailContacte)  Values ('Ash', 'Ketchum', 'Pueblo Paleta', 'Kato', '630253741', 'Andrei Marin', 'aske@poke.com');
INSERT INTO Clients (nomClient, cognoms, adreça, població, telèfon, responsable, emailContacte)  Values ('Gary', 'Oak', 'Pueblo Paleta', 'Kato', '630233241', 'Andrei Marin', 'gaoa@poke.com');

INSERT INTO Articles (nomArticle, seccioMagatzem, preuUnitat, disponibilitat, origen) VALUES ('Morpeko', 'Eléctrico', 10.5, 50, 'Japan');
INSERT INTO Articles (nomArticle, seccioMagatzem, preuUnitat, disponibilitat, origen) VALUES ('Kecleon', 'Normal', 10.8, 30, 'Japan');
INSERT INTO Articles (nomArticle, seccioMagatzem, preuUnitat, disponibilitat, origen) VALUES ('Aegislash', 'Acero', 15.5, 20, 'Japan');
INSERT INTO Articles (nomArticle, seccioMagatzem, preuUnitat, disponibilitat, origen) VALUES ('Kubfu', 'Lucha', 12.5, 70, 'Japan');
INSERT INTO Articles (nomArticle, seccioMagatzem, preuUnitat, disponibilitat, origen) VALUES ('Sinistea', 'Fantasma', 7, 30, 'Japan');
INSERT INTO Articles (nomArticle, seccioMagatzem, preuUnitat, disponibilitat, origen) VALUES ('Arctovish', 'Agua', 22.5, 10, 'Japan');
INSERT INTO Articles (nomArticle, seccioMagatzem, preuUnitat, disponibilitat, origen) VALUES ('Swoobat', 'Psíquico', 20, 20, 'Japan');
INSERT INTO Articles (nomArticle, seccioMagatzem, preuUnitat, disponibilitat, origen) VALUES ('Wingull', 'Agua', 7.5, 20, 'Japan');
INSERT INTO Articles (nomArticle, seccioMagatzem, preuUnitat, disponibilitat, origen) VALUES ('Pidgey', 'Normal', 10.5, 40, 'Japan');
INSERT INTO Articles (nomArticle, seccioMagatzem, preuUnitat, disponibilitat, origen) VALUES ('Turtwig', 'Planta', 4.5, 50, 'Japan');
INSERT INTO Articles (nomArticle, seccioMagatzem, preuUnitat, disponibilitat, origen) VALUES ('Snorlax', 'Normal', 7.5, 40, 'Japan');
INSERT INTO Articles (nomArticle, seccioMagatzem, preuUnitat, disponibilitat, origen) VALUES ('Skitty', 'Normal', 15.5, 30, 'Japan');


INSERT INTO Comandes (idClient, dataComanda, formaPagament, descompte, enviat) VALUES (1, '2022-05-11 03:22:00', 'Tarjeta', 25, 1);
INSERT INTO Comandes (idClient, dataComanda, formaPagament, descompte, enviat) VALUES (2, '2022-06-15 09:30:00', 'Tarjeta', 5, 1);
INSERT INTO Comandes (idClient, dataComanda, formaPagament, descompte, enviat) VALUES (3, '2022-11-01 06:00:00', 'Efectivo', 5, 1);
INSERT INTO Comandes (idClient, dataComanda, formaPagament, descompte, enviat) VALUES (4, '2022-11-01 05:00:00', 'Efectivo', 5, 1);
INSERT INTO Comandes (idClient, dataComanda, formaPagament, descompte, enviat) VALUES (5, '2022-12-28 10:30:00', 'Tarjeta', 0, 0);
INSERT INTO Comandes (idClient, dataComanda, formaPagament, descompte, enviat) VALUES (2, '2022-11-25 11:00:00', 'Tarjeta', 5, 0);
INSERT INTO Comandes (idClient, dataComanda, formaPagament, descompte, enviat) VALUES (3, '2022-01-19 05:00:00', 'Efectivo', 20, 1);
INSERT INTO Comandes (idClient, dataComanda, formaPagament, descompte, enviat) VALUES (4, '2021-12-29 12:00:00', 'Tarjeta', 10, 1);

INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (1, 1, 10);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (1, 2, 1);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (1, 3, 3);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (1, 4, 5);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (1, 11, 5);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (1, 12, 12);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (2, 2, 5);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (2, 3, 1);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (2, 12, 3);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (2, 11, 4);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (2, 10, 5);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (3, 1, 10);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (3, 2, 5);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (4, 4, 3);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (5, 5, 6);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (6, 6, 4);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (7, 7, 9);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (8, 8, 2);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (5, 9, 7);
INSERT INTO Detalls (idComanda, idArticle, quantitat) VALUES (1, 10, 3);
