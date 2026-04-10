CREATE TABLE Contacto(
    ID_Contacto INTEGER PRIMARY KEY,
    Nombre TEXT NOT NULL,
    Apellido TEXT NOT NULL,
    Empresa TEXT,
    Telefono TEXT NOT NULL,
    Puesto TEXT,
    Gmail TEXT,
    Es_Favorito INTEGER NOT NULL,
    Fecha_Creacion TEXT DEFAULT (datetime('now')),
    Nota TEXT
);

INSERT INTO Contacto 
(ID_Contacto, Nombre, Apellido, Empresa, Telefono, Puesto, Gmail, Es_Favorito, Nota)
VALUES
(2, 'Perez', 'Cesar', 'Cesar Iglesias', '8298338999', NULL, NULL, 1, NULL);

INSERT INTO Contacto 
(ID_Contacto, Nombre, Apellido, Empresa, Telefono, Puesto, Gmail, Es_Favorito, Nota)
VALUES
(1, 'Juan', 'Castro', NULL, '8298383939', NULL, NULL, 0, NULL);

INSERT INTO Contacto 
(ID_Contacto, Nombre, Apellido, Empresa, Telefono, Puesto, Gmail, Es_Favorito, Nota)
VALUES
(3, 'Richard', 'Peguero', NULL, '8298323459', NULL, NULL, 1, NULL);

CREATE TABLE Categoria(
ID_Categoria INTEGER PRIMARY KEY,
Nombre TEXT (20) NOT NULL,
Descripcion TEXT (20) NULL
);

INSERT INTO Categoria VALUES(0, 'NO FAVORITOS', NULL);
INSERT INTO Categoria VALUES(1, 'FAVORITOS', NULL);