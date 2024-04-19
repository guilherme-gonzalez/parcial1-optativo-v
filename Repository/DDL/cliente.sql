CREATE TABLE IF NOT EXISTS public.cliente (
      id serial4 PRIMARY KEY,
      id_banco VARCHAR(255),
      nombre VARCHAR(255) NOT NULL CHECK (char_length(nombre) >= 3),
      apellido VARCHAR(255) NOT NULL CHECK (char_length(apellido) >= 3),
      documento VARCHAR(255) NOT NULL CHECK (char_length(documento) >= 3),
      direccion VARCHAR(255),
      mail VARCHAR(255),
      celular CHAR(10) CHECK (celular ~ '^[0-9]+$'),
      estado VARCHAR(255)
);