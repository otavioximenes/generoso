-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.4.13-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for bancogeneroso
DROP DATABASE IF EXISTS `bancogeneroso`;
CREATE DATABASE IF NOT EXISTS `bancogeneroso` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `bancogeneroso`;

-- Dumping structure for table bancogeneroso.aspnetroleclaims
DROP TABLE IF EXISTS `aspnetroleclaims`;
CREATE TABLE IF NOT EXISTS `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(767) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_AspNetRoleClaims_AspNetRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table bancogeneroso.aspnetroleclaims: ~0 rows (approximately)
DELETE FROM `aspnetroleclaims`;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;

-- Dumping structure for table bancogeneroso.aspnetroles
DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(767) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table bancogeneroso.aspnetroles: ~0 rows (approximately)
DELETE FROM `aspnetroles`;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
	('178AA25A-088A-479D-8E9B-61728577B1EC', 'Bancos', 'BANCOS', NULL),
	('1C72AF05-C80C-48B2-BCA1-F72BCC54D452', 'Usuarios', 'USUARIOS', NULL),
	('1DAFACF1-0DBA-4A31-BF32-835559796D0B', 'Clientes', 'CLIENTES', NULL),
	('27E0266D-91E9-4D12-A816-358023325468', 'Enderecos', 'ENDERECOS', NULL),
	('41970AD4-5BC0-44F0-B707-8C048E02A79D', 'Contatos', 'CONTATOS', NULL),
	('4794B341-5B18-4C3E-97B3-1BABC55C1549', 'TiposBancos', 'TIPOSBANCOS', NULL),
	('9D56C7F4-D21D-4922-AB62-4E71E2EC7F48', 'Admin', 'ADMIN', NULL),
	('E44D11C9-3895-4EF7-A821-CAAB0C553CBF', 'Minuta', 'MINUTA', NULL);
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;

-- Dumping structure for table bancogeneroso.aspnetuserclaims
DROP TABLE IF EXISTS `aspnetuserclaims`;
CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(767) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_AspNetUserClaims_AspNetUsers_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- Dumping data for table bancogeneroso.aspnetuserclaims: ~0 rows (approximately)
DELETE FROM `aspnetuserclaims`;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
INSERT INTO `aspnetuserclaims` (`Id`, `UserId`, `ClaimType`, `ClaimValue`) VALUES
	(2, 'd12cfdc1-d2e9-4e35-b1bc-e6db37d7fff2', 'Clientes', 'Ready,EditAndWrite,Delete,Report'),
	(3, 'd12cfdc1-d2e9-4e35-b1bc-e6db37d7fff2', 'Contatos', 'Ready,EditAndWrite,Delete,Report'),
	(4, 'd12cfdc1-d2e9-4e35-b1bc-e6db37d7fff2', 'Bancos', 'Ready,EditAndWrite,Delete,Report'),
	(5, '3626ee90-85bf-4329-adc8-7058c3f027a6', 'Clientes', 'Ready,EditAndWrite,Delete,Report'),
	(6, '3626ee90-85bf-4329-adc8-7058c3f027a6', 'Contatos', 'Ready,EditAndWrite,Delete,Report'),
	(7, '3626ee90-85bf-4329-adc8-7058c3f027a6', 'TiposBancos', 'Ready,EditAndWrite,Delete,Report');
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;

-- Dumping structure for table bancogeneroso.aspnetuserlogins
DROP TABLE IF EXISTS `aspnetuserlogins`;
CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` text DEFAULT NULL,
  `UserId` varchar(767) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `FK_AspNetUserLogins_AspNetUsers_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table bancogeneroso.aspnetuserlogins: ~0 rows (approximately)
DELETE FROM `aspnetuserlogins`;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;

-- Dumping structure for table bancogeneroso.aspnetusers
DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(767) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` text DEFAULT NULL,
  `SecurityStamp` text DEFAULT NULL,
  `ConcurrencyStamp` text DEFAULT NULL,
  `PhoneNumber` text DEFAULT NULL,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `Discriminator` text NOT NULL,
  `PhotoIdPath` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table bancogeneroso.aspnetusers: ~6 rows (approximately)
DELETE FROM `aspnetusers`;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`, `Discriminator`, `PhotoIdPath`) VALUES
	('22ba9c91-dda5-475e-90b9-a448181e8c47', 'TesteGR12', 'TESTEGR12', 'otavio.ximenes@gmail.com', 'OTAVIO.XIMENES@GMAIL.COM', b'1', 'AQAAAAEAACcQAAAAEEUfzeetjf4u7CCYSfnqwLiWZe2Fscmvia6FYRNcudanMF6vbVIVBv3dDAUFHKwglw==', 'F7WVXT2ALAFZHXSMKUYKG6VEL22KKHJO', 'c2dfb7f4-c03c-425d-88ee-004f3ae773fe', '972523105', b'0', b'0', NULL, b'1', 0, 'UserCustomerModel', 'C:\\_workspace\\Consultoria CRS\\webBancoGeneroso\\wwwroot\\Arquivos\\Fotos\\Recebidos\\foto_TesteGR12605.png'),
	('29ffa460-a007-4e54-91f3-54e36d1f7b32', 'te55', 'TE55', 'tes@tes.com', 'TES@TES.COM', b'1', 'AQAAAAEAACcQAAAAECrhR6Zh5BzcqNxjk1lnb11z/M4R/MdtikAPFfMw1bJ7StdAaYxuAhVDYSk5Fus4Rg==', 'FNGZL2KBQ3PT6WB3M2NOSDSGUX6EUM4J', '158a6285-7a97-4d08-a9e6-30acdc2660cc', NULL, b'0', b'0', NULL, b'1', 0, '', NULL),
	('3626ee90-85bf-4329-adc8-7058c3f027a6', 'testeuser2', 'TESTEUSER2', 'Pistache2@tes.com.br', 'PISTACHE2@TES.COM.BR', b'1', 'AQAAAAEAACcQAAAAENGLaa1LqBK5tmZ/c06hIKQwrk8R6nrgA9A/Sb16BvlNdsfRUJLbZpebwa6m7EWJIw==', 'UT7SUPNW3DAWCS2L6YOH5JCNXJ5G7VTN', '9b40d4e5-3b1c-4c4c-9b4f-b13958f948d5', '972523105', b'0', b'0', NULL, b'1', 0, 'UserCustomerModel', NULL),
	('7406d64e-d126-45f0-a79b-5df53ed38e9a', 'tes222', 'TES222', 'tes@teste.com', 'TES@TESTE.COM', b'0', 'AQAAAAEAACcQAAAAEKq2bM92pjL3aIFlYFAhobHtjzobjdMhf7EFh3woUmsIoqmwg+TE9muZKhjH/mPkBg==', 'O55FTCCGJAYKVHUTC2UGRZQG7JV7IUTT', '8daa0efa-ba9c-4003-9d2e-3cc5d9863666', NULL, b'0', b'0', NULL, b'1', 0, '', NULL),
	('7427e6cf-ebaa-4d16-8685-0f0c6ae4e240', 'ca.ximenes@gmail.com', 'CA.XIMENES@GMAIL.COM', 'ca.ximenes@gmail.com', 'CA.XIMENES@GMAIL.COM', b'1', 'AQAAAAEAACcQAAAAELEdPvyeBiv9ANGXJLzFCEySCDKycNxAQdiA0WjWD2kE8ImHZYcyEbC1GHoYxItZag==', 'U47ZUOMBKCFSG7IX3D5NWOOGKPXH6ATP', 'a6c921be-fdb7-49a7-a31e-53434bdeca60', NULL, b'0', b'0', NULL, b'1', 0, '', NULL),
	('7ba54013-55b2-408e-a800-2c95c8529b72', 'testeClaim', 'TESTECLAIM', 'tete@claim.com.br', 'TETE@CLAIM.COM.BR', b'1', 'AQAAAAEAACcQAAAAEKfy5sO5/PG8+BlICnCJLizzf/D3piBdSjhMBJAGzvDQZZiJ7xfJnVr5j+yM9G+e8g==', 'DOITMCUUAZT7R243GPUOB2B4NQ5CBXJM', '0fe268a2-e1d6-4eb6-9e57-8476a5829e5a', '11952312205', b'0', b'0', NULL, b'1', 0, 'UserCustomerModel', 'C:\\_workspace\\Consultoria CRS\\webBancoGeneroso\\wwwroot\\Arquivos\\Fotos\\Recebidos\\foto_testeClaim561.png'),
	('8d987f4d-38e1-468f-b2fa-6b954163a8ed', 'teste', 'TESTE', 'teste@teste.com', 'TESTE@TESTE.COM', b'0', 'AQAAAAEAACcQAAAAEOiOOUOV91s7B9RkhZTijdFMqJP28UFlWVIElxkFdlPYvqnhg5IW+r1mm2zhtp387A==', '7XERLSY6K5BIYNFO75RIQUHTMKB73LTU', 'fe4c0447-55cd-44b5-92eb-30a77f8676a8', NULL, b'0', b'0', NULL, b'1', 0, '', NULL),
	('9f8c7b27-e353-47fb-a20c-d2de0de85e97', 'tes2', 'TES2', 'test@teste.com', 'TEST@TESTE.COM', b'0', 'AQAAAAEAACcQAAAAEM+v+2A/CHVULl8lxqLqo7Rw6B9CvBn6MPpCKEv8krPxWAZie+NgmL7V8JTBo3lcvg==', 'PZUZH7HLBH4USLOMFH3SY4JL7LX7JVNJ', '2aa170af-baaf-4369-93c1-69ce1d4a07ea', NULL, b'0', b'0', NULL, b'1', 0, '', NULL),
	('d12cfdc1-d2e9-4e35-b1bc-e6db37d7fff2', 'novoCLaim', 'NOVOCLAIM', 'teste@teste', 'TESTE@TESTE', b'1', 'AQAAAAEAACcQAAAAEIiSmBl2Uxg7bhhpFukojB+GFN2rU/quzvIV+6Tj1dWuhtBnYmLyx+YLhWDbFmMwLA==', 'LIIHNPAPUP7IPM2KLQOWYSV2TQDPPFMP', 'd004072e-fcb9-480c-972e-fd6bb7b7ee57', '11985654421', b'0', b'0', NULL, b'1', 0, 'UserCustomerModel', 'C:\\_workspace\\Consultoria CRS\\webBancoGeneroso\\wwwroot\\Arquivos\\Fotos\\Recebidos\\foto_novoCLaim921.png');
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;

-- Dumping structure for table bancogeneroso.clientes
DROP TABLE IF EXISTS `clientes`;
CREATE TABLE IF NOT EXISTS `clientes` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(20) NOT NULL,
  `RG` text NOT NULL,
  `CPF` text NOT NULL,
  `Email` text NOT NULL,
  `DataNascimento` datetime NOT NULL,
  `Telefone` text NOT NULL,
  `Celular` text NOT NULL,
  `Situacao` bit(1) NOT NULL,
  `Observacoes` text DEFAULT NULL,
  `TipoPessoa` int(11) NOT NULL,
  `Sexo` text NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Dumping data for table bancogeneroso.clientes: ~0 rows (approximately)
DELETE FROM `clientes`;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` (`Id`, `Nome`, `RG`, `CPF`, `Email`, `DataNascimento`, `Telefone`, `Celular`, `Situacao`, `Observacoes`, `TipoPessoa`, `Sexo`) VALUES
	(1, 'otavio teste', '12345678945', '350955569841', 'otavio@teste.com.br', '1986-05-31 00:00:00', '11972523105', '11972523105', b'1', 'Teste Observação', 1, 'Masculino');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;

-- Dumping structure for table bancogeneroso.contato
DROP TABLE IF EXISTS `contato`;
CREATE TABLE IF NOT EXISTS `contato` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClienteId` bigint(20) NOT NULL,
  `Nome` varchar(20) NOT NULL,
  `Email` text NOT NULL,
  `Telefone` text DEFAULT NULL,
  `Celular` text NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Contatos_ClienteId` (`ClienteId`),
  CONSTRAINT `FK_Contato_Clientes_ClienteId` FOREIGN KEY (`ClienteId`) REFERENCES `clientes` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Dumping data for table bancogeneroso.contato: ~0 rows (approximately)
DELETE FROM `contato`;
/*!40000 ALTER TABLE `contato` DISABLE KEYS */;
INSERT INTO `contato` (`Id`, `ClienteId`, `Nome`, `Email`, `Telefone`, `Celular`) VALUES
	(1, 1, 'Contato teste', 'teste@teste.com', '1197523154', '3214554788');
/*!40000 ALTER TABLE `contato` ENABLE KEYS */;

-- Dumping structure for table bancogeneroso.dadosbancarios
DROP TABLE IF EXISTS `dadosbancarios`;
CREATE TABLE IF NOT EXISTS `dadosbancarios` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `TiposBancosId` int(11) NOT NULL,
  `CNPJ` text NOT NULL,
  `Agencia` text NOT NULL,
  `RazaoSocial` varchar(20) NOT NULL,
  `Numero` text NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_DadosBancarios_TiposBancosId` (`TiposBancosId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Dumping data for table bancogeneroso.dadosbancarios: ~0 rows (approximately)
DELETE FROM `dadosbancarios`;
/*!40000 ALTER TABLE `dadosbancarios` DISABLE KEYS */;
INSERT INTO `dadosbancarios` (`Id`, `TiposBancosId`, `CNPJ`, `Agencia`, `RazaoSocial`, `Numero`) VALUES
	(1, 1, '12.255.655/0001-65', '123456', 'Razao Teste empresa ', '548888');
/*!40000 ALTER TABLE `dadosbancarios` ENABLE KEYS */;

-- Dumping structure for table bancogeneroso.endereco
DROP TABLE IF EXISTS `endereco`;
CREATE TABLE IF NOT EXISTS `endereco` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClienteId` bigint(20) NOT NULL,
  `Logradouro` text NOT NULL,
  `Numero` text NOT NULL,
  `Complemento` text DEFAULT NULL,
  `Cep` text NOT NULL,
  `Bairro` text NOT NULL,
  `Cidade` text NOT NULL,
  `Estado` text NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Enderecos_ClienteId` (`ClienteId`),
  CONSTRAINT `FK_Endereco_Clientes_ClienteId` FOREIGN KEY (`ClienteId`) REFERENCES `clientes` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Dumping data for table bancogeneroso.endereco: ~0 rows (approximately)
DELETE FROM `endereco`;
/*!40000 ALTER TABLE `endereco` DISABLE KEYS */;
INSERT INTO `endereco` (`Id`, `ClienteId`, `Logradouro`, `Numero`, `Complemento`, `Cep`, `Bairro`, `Cidade`, `Estado`) VALUES
	(1, 1, 'teste logradouro', '123', 'teste complemento', '07021070', 'vila augusta', 'Guarulhos', 'SP');
/*!40000 ALTER TABLE `endereco` ENABLE KEYS */;

-- Dumping structure for table bancogeneroso.gruposacessos
DROP TABLE IF EXISTS `gruposacessos`;
CREATE TABLE IF NOT EXISTS `gruposacessos` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `PageAcesso` text DEFAULT NULL,
  `Role` text DEFAULT NULL,
  `UsuarioGruposAcessoId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_gruposAcessos_UsuarioGruposAcessoId` (`UsuarioGruposAcessoId`),
  CONSTRAINT `FK_gruposAcessos_UsuarioGruposAcessos_UsuarioGruposAcessoId` FOREIGN KEY (`UsuarioGruposAcessoId`) REFERENCES `usuariogruposacessos` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- Dumping data for table bancogeneroso.gruposacessos: ~8 rows (approximately)
DELETE FROM `gruposacessos`;
/*!40000 ALTER TABLE `gruposacessos` DISABLE KEYS */;
INSERT INTO `gruposacessos` (`Id`, `PageAcesso`, `Role`, `UsuarioGruposAcessoId`) VALUES
	(1, 'Admin', 'Admin', 1),
	(2, 'Clientes', 'Admin', NULL),
	(3, 'Contatos', 'Admin', NULL),
	(4, 'Enderecos', 'Admin', NULL),
	(5, 'Minuta', 'Admin', NULL),
	(6, 'TiposBancos', 'Admin', NULL),
	(7, 'Bancos', 'Admin', NULL),
	(8, 'Usuarios', 'Admin', NULL);
/*!40000 ALTER TABLE `gruposacessos` ENABLE KEYS */;

-- Dumping structure for table bancogeneroso.minuta
DROP TABLE IF EXISTS `minuta`;
CREATE TABLE IF NOT EXISTS `minuta` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Codigo` text NOT NULL,
  `DataEmissao` datetime NOT NULL,
  `DataVencimento` datetime NOT NULL,
  `Adm` int(11) NOT NULL,
  `ValorAdmin` decimal(18,2) NOT NULL,
  `ClienteId` bigint(20) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Minuta_ClienteId` (`ClienteId`),
  CONSTRAINT `FK_Minuta_Clientes_ClienteId` FOREIGN KEY (`ClienteId`) REFERENCES `clientes` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table bancogeneroso.minuta: ~0 rows (approximately)
DELETE FROM `minuta`;
/*!40000 ALTER TABLE `minuta` DISABLE KEYS */;
/*!40000 ALTER TABLE `minuta` ENABLE KEYS */;

-- Dumping structure for table bancogeneroso.tiposbancos
DROP TABLE IF EXISTS `tiposbancos`;
CREATE TABLE IF NOT EXISTS `tiposbancos` (
  `Codigo` int(11) DEFAULT NULL,
  `Nome` text DEFAULT NULL,
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Codigo` (`Codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8;

-- Dumping data for table bancogeneroso.tiposbancos: ~15 rows (approximately)
DELETE FROM `tiposbancos`;
/*!40000 ALTER TABLE `tiposbancos` DISABLE KEYS */;
INSERT INTO `tiposbancos` (`Codigo`, `Nome`, `Id`) VALUES
	(333, 'Itaú', 1),
	(237, 'Bradesco', 2),
	(1, 'Banco do Brasil', 3),
	(3, 'Banco da Amazônia S.A.', 4),
	(4, 'Banco do Nordeste do Brasil S.A.', 5),
	(7, 'Banco Nacional de Desenvolvimento Econômico e Social - BNDES', 6),
	(10, 'CREDICOAMO CREDITO RURAL COOPERATIVA', 7),
	(11, 'CREDIT SUISSE HEDGING-GRIFFO CORRETORA DE VALORES S.A', 8),
	(12, 'Banco Inbursa S.A.', 9),
	(14, 'State Street Brasil S.A. - Banco Comercial', 10),
	(15, 'UBS Brasil Corretora de Câmbio, Títulos e Valores Mobiliários S.A.', 11),
	(16, 'COOPERATIVA DE CRÉDITO MÚTUO DOS DESPACHANTES DE TRÂNSITO DE SANTA CATARINA E RI', 12),
	(17, 'BNY Mellon Banco S.A.', 13),
	(18, 'Banco Tricury S.A.', 14),
	(21, 'BANESTES S.A. Banco do Estado do Espírito Santo', 15),
	(22, 'Banco BANDEPE S.A.', 16),
	(25, 'Banco Alfa S.A.', 17),
	(208, 'Banco BTG Pactual S.A.', 18),
	(336, 'Banco C6 S.A.', 20),
	(389, 'Banco Mercantil do Brasil S.A.', 21),
	(399, 'HSBC Bank Brasil S.A. – Banco Múltiplo', 22),
	(422, 'Banco Safra S.A.', 23),
	(453, 'Banco Rural S.A.', 24),
	(633, 'Banco Rendimento S.A', 25),
	(652, 'Itaú Unibanco Holding S.A.', 28),
	(745, 'Banco Citibank S.A.', 29),
	(246, 'Banco ABC Brasil S.A.', 30),
	(641, 'Banco Alvorada S.A.', 32),
	(29, 'Banco Banerj S.A.', 33),
	(38, 'Banco Banestado S.A.', 34),
	(0, 'Banco Bankpar S.A.', 35),
	(740, 'Banco Barclays S.A.', 39),
	(107, 'Banco BBM S.A.', 40),
	(31, 'Banco Beg S.A.', 41),
	(96, 'Banco BM&F de Serviços de Liquidação e Custódia S.A', 42),
	(318, 'Banco BMG S.A.', 43),
	(752, 'Banco BNP Paribas Brasil S.A.', 44),
	(248, 'Banco Boavista Interatlântico S.A.', 45),
	(36, 'Banco Bradesco BBI S.A.', 46),
	(204, 'Banco Bradesco Cartões S.A.', 47),
	(225, 'Banco Brascan S.A.', 48),
	(44, 'Banco BVA S.A.', 49),
	(263, 'Banco Cacique S.A.', 50),
	(473, 'Banco Caixa Geral – Brasil S.A.', 51);
/*!40000 ALTER TABLE `tiposbancos` ENABLE KEYS */;

-- Dumping structure for table bancogeneroso.usuariogruposacessos
DROP TABLE IF EXISTS `usuariogruposacessos`;
CREATE TABLE IF NOT EXISTS `usuariogruposacessos` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `IdUsuarioSistema` bigint(20) NOT NULL,
  `UsuarioSistemaId` bigint(20) DEFAULT NULL,
  `IdGrupoAcessos` bigint(20) NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`),
  KEY `IX_UsuarioGruposAcessos_UsuarioSistemaId` (`UsuarioSistemaId`),
  CONSTRAINT `FK_UsuarioGruposAcessos_usuarioSistemas_UsuarioSistemaId` FOREIGN KEY (`UsuarioSistemaId`) REFERENCES `usuariosistemas` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

-- Dumping data for table bancogeneroso.usuariogruposacessos: ~6 rows (approximately)
DELETE FROM `usuariogruposacessos`;
/*!40000 ALTER TABLE `usuariogruposacessos` DISABLE KEYS */;
INSERT INTO `usuariogruposacessos` (`Id`, `IdUsuarioSistema`, `UsuarioSistemaId`, `IdGrupoAcessos`) VALUES
	(1, 1, 1, 1),
	(2, 5, NULL, 2),
	(3, 5, NULL, 3),
	(4, 5, NULL, 4),
	(5, 5, NULL, 6),
	(6, 5, NULL, 7),
	(7, 9, NULL, 2),
	(8, 9, NULL, 3),
	(9, 9, NULL, 7),
	(10, 3, NULL, 2),
	(11, 3, NULL, 3),
	(12, 3, NULL, 6);
/*!40000 ALTER TABLE `usuariogruposacessos` ENABLE KEYS */;

-- Dumping structure for table bancogeneroso.usuariosistemas
DROP TABLE IF EXISTS `usuariosistemas`;
CREATE TABLE IF NOT EXISTS `usuariosistemas` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Nome` text NOT NULL,
  `PathPhoto` text DEFAULT NULL,
  `Email` text NOT NULL,
  `Telefone` text NOT NULL,
  `Password` text NOT NULL,
  `GuidId` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- Dumping data for table bancogeneroso.usuariosistemas: ~8 rows (approximately)
DELETE FROM `usuariosistemas`;
/*!40000 ALTER TABLE `usuariosistemas` DISABLE KEYS */;
INSERT INTO `usuariosistemas` (`Id`, `Nome`, `PathPhoto`, `Email`, `Telefone`, `Password`, `GuidId`) VALUES
	(1, 'Otavio', NULL, 'otavio.ximenes@gmail.com', '11972523105', 'Otavio1@', '3626ee90-85bf-4329-adc8-7058c3f027a6'),
	(2, 'testeuser', NULL, 'Pistache@tes.com.br', '972523105', 'Tre12#', NULL),
	(3, 'testeuser2', NULL, 'Pistache2@tes.com.br', '972523105', 'qwe123$', NULL),
	(4, 'TesteGR', NULL, 'teste@teste.com.br', '972523105', 'Teste#', NULL),
	(5, 'TesteGR12', 'C:\\_workspace\\Consultoria CRS\\webBancoGeneroso\\wwwroot\\Arquivos\\Fotos\\Recebidos\\foto_TesteGR12605.png', 'otavio.ximenes@gmail.com', '972523105', 'Teste123$', '22ba9c91-dda5-475e-90b9-a448181e8c47'),
	(6, 'testeClaim', 'C:\\_workspace\\Consultoria CRS\\webBancoGeneroso\\wwwroot\\Arquivos\\Fotos\\Recebidos\\foto_testeClaim561.png', 'tete@claim.com.br', '11952312205', 'Otavio1@', '7ba54013-55b2-408e-a800-2c95c8529b72'),
	(7, 'TesteClaim', 'C:\\_workspace\\Consultoria CRS\\webBancoGeneroso\\wwwroot\\Arquivos\\Fotos\\Recebidos\\foto_TesteClaim160.png', 'teste@claim.com.br', '123456687', 'Teste123', 'dc780d58-3325-49fd-b85d-da02edb0f49a'),
	(8, 'Claim teste', 'C:\\_workspace\\Consultoria CRS\\webBancoGeneroso\\wwwroot\\Arquivos\\Fotos\\Recebidos\\foto_Claim teste689.png', 'teste@teste.com.br', '159654421', 'Teste123!', '2ea1c4b1-3771-4bd6-80ed-25381d2efaf5'),
	(9, 'novoCLaim', 'C:\\_workspace\\Consultoria CRS\\webBancoGeneroso\\wwwroot\\Arquivos\\Fotos\\Recebidos\\foto_novoCLaim921.png', 'teste@teste', '11985654421', 'Novo12#', 'd12cfdc1-d2e9-4e35-b1bc-e6db37d7fff2');
/*!40000 ALTER TABLE `usuariosistemas` ENABLE KEYS */;

-- Dumping structure for table bancogeneroso.__efmigrationshistory
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table bancogeneroso.__efmigrationshistory: ~9 rows (approximately)
DELETE FROM `__efmigrationshistory`;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20200619011705_ClienteEnderecoContato', '3.1.5'),
	('20200619015340_UserCustomer', '3.1.5'),
	('20200620234942_criarbancodados', '3.1.5'),
	('20200621003535_TiposBancosDadosMinuta', '3.1.5'),
	('20200621222755_ajustTipoBanco', '3.1.5'),
	('20200622221500_ajustContext', '3.1.5'),
	('20200622234623_ajusteUsuarioGrupo', '3.1.5'),
	('20200623022157_ajusteUsuarioGrupoitem', '3.1.5'),
	('20200623033421_ajusteUsuarioGrupoAcesso', '3.1.5'),
	('20200623141447_guidId', '3.1.5'),
	('20200625020335_AjusteCampos', '3.1.5'),
	('20200712002313_ajuste', '3.1.5');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
