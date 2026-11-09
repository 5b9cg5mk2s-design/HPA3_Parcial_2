USE `productosdb`;

DROP PROCEDURE IF EXISTS `sp_ValidarLoginHash`;

DELIMITER //

CREATE PROCEDURE `sp_ValidarLoginHash` (
    IN _dsUsuario VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci, -- Sintaxis explícita correcta
    IN _dsPassword VARCHAR(50)
)
BEGIN
    SELECT 
        `id`,
        `dsId`,
        `dsUsuario`,
        `dsPassword`,
        `dsEstado`,
        `dsUsuarioCreacion`,
        `dtFechaCreacion`
    FROM `usuarios`
    WHERE `dsUsuario` = _dsUsuario
      AND `dsPassword` = UNHEX(SHA2(_dsPassword, 512))
      AND `dsEstado` = '1';
END //

DELIMITER ;


