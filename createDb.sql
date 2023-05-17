CREATE DATABASE `bibliofetch` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `bibliofetch`;
CREATE TABLE `books` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ISBN` varchar(45) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `Subtitle` varchar(100) DEFAULT NULL,
  `Authors` varchar(300) NOT NULL,
  `NumberOfPages` int(11) DEFAULT NULL,
  `PublishDate` varchar(100) NOT NULL,
  `FromServer` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;
