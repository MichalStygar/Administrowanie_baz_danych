CREATE TABLE adres
(
        id_adresu bigserial  PRIMARY KEY,
        ulica varchar(30) NULL,
        nr_domu integer NOT NULL,
        kod_pocztowy varchar(6) NOT NULL,
        miejscowosc varchar(30) NOT NULL
 
);
 
CREATE TABLE swiadczeniobiorca
(
        id_swiadczeniobiorca bigserial  PRIMARY KEY,
        imie varchar(25) NOT NULL,
        nazisko varchar(25) NOT NULL,
        nazwisko_rodowe varchar(25) NOT NULL,
        data_urodzenia date NOT NULL,
        plec varchar(25) NOT NULL,
        nr_pesel varchar(11) NOT NULL UNIQUE,
        adres_zamieszkania varchar(35) NOT NULL,
        nr_telefonu varchar(9) NOT NULL,
        miejsce_nauki varchar(35) NULL,
        nr_karty varchar(14) NOT NULL,
        kod_odddzialu varchar(2) NOT NULL,
        id_adresu bigint  REFERENCES adres(id_adresu)
 
);
 
CREATE TABLE lekarz
(
        id_lakarza bigserial  PRIMARY KEY,
        imie varchar(25) NOT NULL,
        nazwisko varchar(25) NOT NULL,
        nr_pesel varchar(11) NOT NULL UNIQUE,
        nr_telefonu varchar(9) NOT NULL,
        id_adresu bigint  REFERENCES adres(id_adresu)
        
 
);
 
CREATE TABLE swiadczeniodawca
(
        id_swiadczeniodawca bigserial  PRIMARY KEY,
        siedziba varchar(25) NOT NULL,
        swiadczenia varchar(25) NOT NULL,
        id_adresu bigint  REFERENCES adres(id_adresu)
        
 
);
 
CREATE TABLE deklaracja
(
        id_deklaracji bigserial  PRIMARY KEY,
        id_swiadczeniobiorca bigint  REFERENCES swiadczeniobiorca(id_swiadczeniobiorca),
        id_lakarza bigint  REFERENCES lekarz(id_lakarza),
        id_swiadczeniodawca bigint  REFERENCES swiadczeniodawca(id_swiadczeniodawca),
        data_zlozenia date NOT NULL
);