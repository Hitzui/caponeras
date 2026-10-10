CREATE TABLE IF NOT EXISTS `caponeras`.`ausencia_cadete` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `idconductor` INT NOT NULL,
    `fecha` DATE NOT NULL,
    `motivo` VARCHAR(100) NOT NULL,
    `detalle` TEXT NULL,
    `idvehiculo` INT NULL,
    `idzona` INT NULL,
    `codigo_vehiculo` VARCHAR(50) NULL,
    `placa` VARCHAR(50) NULL,
    `zona` VARCHAR(255) NULL,
    `creado_en` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (`id`),
    UNIQUE KEY `uq_ausencia_cadete_fecha` (`idconductor`, `fecha`),
    KEY `ix_ausencia_cadete_fecha` (`fecha`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
