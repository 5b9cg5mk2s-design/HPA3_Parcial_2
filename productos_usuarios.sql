USE productosdb;

DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE IF NOT EXISTS `usuarios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `dsId` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `dsUsuario` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `dsPassword` varbinary(64) NOT NULL,
  `dsEstado` char(1) COLLATE utf8mb4_unicode_ci NOT NULL,
  `dsUsuarioCreacion` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `dtFechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `dsUsuarioModificacion` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT 'Sistema',
  `dtFechaModificacion` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
);

