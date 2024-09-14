CREATE DATABASE  IF NOT EXISTS `sistematickets` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `sistematickets`;
-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: localhost    Database: sistematickets
-- ------------------------------------------------------
-- Server version	8.0.39

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `funcionario`
--

DROP TABLE IF EXISTS `funcionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `funcionario` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  `CPF` varchar(16) DEFAULT NULL,
  `situacao` char(1) NOT NULL,
  `DtAlteracao` date NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `funcionario`
--

LOCK TABLES `funcionario` WRITE;
/*!40000 ALTER TABLE `funcionario` DISABLE KEYS */;
INSERT INTO `funcionario` VALUES (1,'João Silva','123.456.789-01','I','2024-01-01'),(2,'Maria Oliveira','234.567.890-12','A','2024-02-01'),(3,'Carlos Menegassi','144.111.989-24','A','2024-09-13'),(4,'Ana Pereira','456.789.012-34','A','2024-04-01'),(5,'Paulo Santos','567.890.123-45','I','2024-05-01'),(6,'Mariana Ribeiro','678.901.234-56','A','2024-06-01'),(7,'Pedro Alves','789.012.345-67','I','2024-07-01'),(8,'Fernanda Lima','890.123.456-78','A','2024-08-01'),(9,'Ricardo Martins','901.234.567-89','I','2024-01-15'),(10,'Juliana Costa','012.345.678-90','A','2024-02-15'),(11,'Lucas Moreira','111.222.333-44','I','2024-03-15'),(12,'Camila Teixeira','222.333.444-55','I','2024-09-13'),(13,'José Rocha','333.444.555-66','I','2024-05-15'),(14,'Bianca Menezes','444.555.666-77','A','2024-06-15'),(15,'Roberto Fonseca','555.666.777-88','I','2024-07-15'),(16,'Tatiana Carvalho','666.777.888-99','A','2024-08-15'),(17,'Rafael Araujo','777.888.999-00','I','2024-01-30'),(18,'Sara Freitas','888.999.000-11','A','2024-02-28'),(19,'André Barros','999.000.111-22','I','2024-03-30'),(20,'Letícia Medeiros','000.111.222-33','A','2024-04-30'),(21,'Gustavo Figueiredo','123.987.654-32','I','2024-05-30'),(22,'Renata Silva','234.876.543-21','A','2024-06-30'),(23,'Thiago Nunes','345.765.432-10','I','2024-07-30'),(24,'Priscila Cardoso','456.654.321-09','A','2024-08-30'),(25,'Eduardo Lima','567.543.210-98','I','2024-01-10'),(26,'George Henrique','143.654.876.98','A','2024-09-13');
/*!40000 ALTER TABLE `funcionario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ticket`
--

DROP TABLE IF EXISTS `ticket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ticket` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdFuncionario` int NOT NULL,
  `Quantidade` int NOT NULL,
  `Situacao` char(1) NOT NULL,
  `DtEntrega` date NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdFuncionario` (`IdFuncionario`),
  CONSTRAINT `ticket_ibfk_1` FOREIGN KEY (`IdFuncionario`) REFERENCES `funcionario` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ticket`
--

LOCK TABLES `ticket` WRITE;
/*!40000 ALTER TABLE `ticket` DISABLE KEYS */;
INSERT INTO `ticket` VALUES (1,1,5,'A','2024-04-15'),(2,2,3,'I','2024-05-10'),(3,3,7,'A','2024-03-20'),(4,4,40,'I','2024-09-12'),(5,5,4,'A','2024-07-05'),(6,6,6,'I','2024-03-30'),(7,7,8,'A','2024-04-18'),(8,8,1,'I','2024-05-12'),(9,9,9,'A','2024-06-03'),(10,10,3,'I','2024-07-20'),(11,11,2,'A','2024-03-15'),(12,12,7,'I','2024-04-22'),(13,13,5,'A','2024-05-30'),(14,14,6,'I','2024-06-10'),(15,15,4,'A','2024-07-25'),(16,16,3,'I','2024-03-10'),(17,17,6,'A','2024-04-28'),(18,18,8,'I','2024-05-15'),(19,19,2,'A','2024-06-12'),(20,20,1,'I','2024-07-30'),(21,1,10,'A','2024-04-15'),(22,3,100,'A','2024-09-11'),(23,1,2,'A','2024-09-11'),(24,7,30,'I','2024-09-13');
/*!40000 ALTER TABLE `ticket` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-09-13 23:55:18
