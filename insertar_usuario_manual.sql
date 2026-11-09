-- 1. Limpiar los registros viejos
TRUNCATE TABLE `usuarios`;

-- 2. Insertar el usuario con el cifrado SHA-512 correcto
INSERT INTO `usuarios` 
(`dsId`, `dsUsuario`, `dsPassword`, `dsEstado`, `dsUsuarioCreacion`) 
VALUES 
('001', 'admin', UNHEX(SHA2('admin123', 512)), '1', 'Sistema');
