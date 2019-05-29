-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 23, 2019 at 03:32 PM
-- Server version: 10.1.21-MariaDB
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `novel`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `add_emp` (IN `fname` VARCHAR(20), IN `lname` VARCHAR(20), IN `bday` DATETIME, OUT `empno` INT)  BEGIN INSERT INTO emp(first_name, last_name, birthdate) VALUES(fname, lname, DATE(bday)); SET empno = LAST_INSERT_ID(); END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `novel_infor`
--

CREATE TABLE `novel_infor` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Link` varchar(255) NOT NULL,
  `Author` varchar(15) NOT NULL,
  `Chap_number` int(11) NOT NULL,
  `Rating` int(11) NOT NULL,
  `Viewer` int(11) NOT NULL,
  `Voting` int(11) NOT NULL,
  `Recommandation` int(11) NOT NULL,
  `image_link` varchar(255) DEFAULT NULL,
  `Owner` int(11) NOT NULL,
  `Upload_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `novel_infor`
--

INSERT INTO `novel_infor` (`Id`, `Name`, `Link`, `Author`, `Chap_number`, `Rating`, `Viewer`, `Voting`, `Recommandation`, `image_link`, `Owner`, `Upload_date`) VALUES
(1, 'Hello', '1.txt', 'Fire', 10, 10, 103, 11, 10, '1.jpeg', 14, '2019-05-05'),
(2, 'business', '1.txt', 'Lee', 10, 10, 10, 10, 10, '2.png', 14, '2019-04-27'),
(3, 'Industry', '1.txt', 'Lee', 10, 10, 10, 22, 10, '3.jpg', 14, '2019-04-29'),
(4, 'Home', '1.txt', 'Lee', 10, 10, 10, 20, 10, '4.jpg', 0, '2019-04-16'),
(5, 'Game', '1.txt', 'Lee', 10, 10, 10, 20, 10, '5.jpg', 0, '2019-03-04'),
(6, 'Girl', '1.txt', 'Lee', 10, 10, 10, 20, 10, '6.jpg', 0, '2019-04-21'),
(7, 'Powerfull', '1.txt', 'Lee', 10, 10, 10, 20, 10, '7.jpg', 0, '2019-04-07'),
(8, 'Fire World', '1.txt', 'Lee', 10, 10, 16, 22, 10, '1.jpg', 0, '2019-05-08'),
(9, 'Champion World', '1.txt', 'Lee', 10, 10, 10, 10, 10, '9.jpg', 0, '2019-05-01'),
(10, 'King of the Ring', '1.txt', 'Lee', 10, 10, 10, 10, 10, '10.jpg', 0, '1911-11-07'),
(13, 'ABC', '1.txt', 'Lee', 1, 0, 0, 0, 0, '11.jpg', 0, '2019-03-21'),
(14, 'FireWar', '1.txt', 'John', 1, 0, 0, 0, 0, '13.jpg', 0, '2019-04-27'),
(16, '123', '1.txt', 'ae', 1, 0, 0, 0, 0, '1.jpg', 15, '2019-05-03'),
(17, 'meeting novel', '1.txt', 'tony', 1, 0, 0, 3, 0, '3.jpg', 17, '2019-05-11'),
(18, '13', '1.txt', '12', 1, 0, 0, 0, 0, '14.jpg', 14, '2019-05-05'),
(19, 'qwe', '1.txt', 'qwe', 0, 0, 0, 0, 0, '12.jpg', 14, '2019-02-18'),
(20, 'Adventures of Sujith', '1.txt', 'The world', 1, 0, 1, 0, 0, '2.jpg', 17, '2019-05-18'),
(22, 'Fire', 'feedback.txt', '123', 0, 0, 0, 4, 0, 'Untitled.png', 14, '2019-05-21'),
(23, 'swinburne', 'feedback.txt', 'lee', 0, 0, 0, 25, 0, 'Untitled.png', 14, '2019-05-21'),
(24, 'awesomeness', 'feedback.txt', 'me', 0, 0, 3, 1, 0, 'Untitled.png', 18, '2019-05-22'),
(25, 'adventures3', 'feedback.txt', 'mohan', 0, 0, 4, 4, 0, 'Untitled.png', 19, '2019-05-22');

-- --------------------------------------------------------

--
-- Table structure for table `reading_infor`
--

CREATE TABLE `reading_infor` (
  `user_id` int(11) NOT NULL,
  `novel_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reading_infor`
--

INSERT INTO `reading_infor` (`user_id`, `novel_id`) VALUES
(14, 1),
(14, 25),
(14, 24),
(14, 8),
(14, 20);

-- --------------------------------------------------------

--
-- Table structure for table `user_infor`
--

CREATE TABLE `user_infor` (
  `ID` int(11) NOT NULL,
  `UserName` varchar(100) NOT NULL,
  `Password` varchar(200) NOT NULL,
  `Date_of_birth` date NOT NULL,
  `Image_profile` varchar(255) NOT NULL,
  `Coin` int(11) NOT NULL,
  `Level` int(11) NOT NULL,
  `Experience` int(11) NOT NULL,
  `Type` varchar(100) NOT NULL,
  `Power` int(11) NOT NULL,
  `Nick_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_infor`
--

INSERT INTO `user_infor` (`ID`, `UserName`, `Password`, `Date_of_birth`, `Image_profile`, `Coin`, `Level`, `Experience`, `Type`, `Power`, `Nick_name`) VALUES
(12, 'tony@gmail', '123', '1993-11-11', '4.jpg', 100, 1, 100, 'Admin', 100, 'Lee'),
(14, 'TheVinh', '123', '0000-00-00', '5.jpg', 100, 1, 100, 'Admin', 100, 'Hello'),
(15, 'vinh', '123', '1999-11-11', '6.jpg', 123, 1, 100, 'normal', 100, '#'),
(17, 'meetingTest', 'test', '1998-07-17', '7.jpg', 100, 1, 100, 'normal', 100, '#'),
(18, 'meeting', '1234', '1993-11-11', '#', 100, 1, 100, 'normal', 100, 'Lee'),
(19, 'mohan', '123', '1993-11-11', '#', 100, 1, 100, 'normal', 100, 'Lee');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `novel_infor`
--
ALTER TABLE `novel_infor`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `user_infor`
--
ALTER TABLE `user_infor`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `novel_infor`
--
ALTER TABLE `novel_infor`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;
--
-- AUTO_INCREMENT for table `user_infor`
--
ALTER TABLE `user_infor`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
