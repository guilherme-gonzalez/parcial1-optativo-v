CREATE TABLE IF NOT EXISTS public.factura (
        id serial4 PRIMARY KEY,
        id_cliente VARCHAR(255) NOT NULL,
        nro_factura VARCHAR(255) NOT NULL CHECK (nro_factura ~ '^[0-9]{3}-[0-9]{3}-[0-9]{6}$'),
        fecha_hora TIMESTAMP NOT NULL,
        total NUMERIC NOT NULL,
        total_iva5 NUMERIC NOT NULL,
        total_iva10 NUMERIC NOT NULL,
        total_iva NUMERIC NOT NULL,
        total_letras VARCHAR(255) NOT NULL CHECK (char_length(total_letras) >= 6),
        sucursal VARCHAR(255)
    );

