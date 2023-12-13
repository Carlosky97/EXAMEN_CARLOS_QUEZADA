-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 13-12-2023 a las 01:37:15
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `taller`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mecanico`
--

CREATE TABLE `mecanico` (
  `IdMecanico` int(11) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `Edad` int(11) NOT NULL,
  `Domicilio` varchar(100) NOT NULL,
  `Titulo` varchar(100) NOT NULL,
  `Especialidad` varchar(100) NOT NULL,
  `SueldoBase` int(11) NOT NULL,
  `GratTitulo` int(11) NOT NULL,
  `SueldoTotal` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `mecanico`
--

INSERT INTO `mecanico` (`IdMecanico`, `Nombre`, `Edad`, `Domicilio`, `Titulo`, `Especialidad`, `SueldoBase`, `GratTitulo`, `SueldoTotal`) VALUES
(3, 'Miguel el queso', 41, 'Av Las Condes 9800', 'Ingeniero', 'Asesor Mecanico', 1200000, 300000, 1500000),
(4, 'Marcos Peñailillo', 45, 'los toquillos 1000', 'Tecnico', 'Analista de motor de barcos', 700000, 200000, 900000),
(7, 'Osvaldo Rebolledo', 32, 'Matucana 350', 'Tecnico', 'Soporte de motores', 600000, 200000, 800000);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `mecanico`
--
ALTER TABLE `mecanico`
  ADD PRIMARY KEY (`IdMecanico`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `mecanico`
--
ALTER TABLE `mecanico`
  MODIFY `IdMecanico` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
