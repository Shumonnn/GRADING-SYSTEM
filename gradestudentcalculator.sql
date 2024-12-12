-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 11, 2024 at 06:08 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gradestudentcalculator`
--

-- --------------------------------------------------------

--
-- Table structure for table `blocksection`
--

CREATE TABLE `blocksection` (
  `SectionName` varchar(50) NOT NULL,
  `CourseID` int(11) DEFAULT NULL,
  `StudentID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `blocksection`
--

INSERT INTO `blocksection` (`SectionName`, `CourseID`, `StudentID`) VALUES
('II-ACSAD', 1, NULL),
('II-BCSAD', 2, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `course`
--

CREATE TABLE `course` (
  `CourseID` int(11) NOT NULL,
  `ProfessorID` int(11) DEFAULT NULL,
  `CourseName` varchar(100) NOT NULL,
  `CourseCode` varchar(20) NOT NULL,
  `StudentID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `course`
--

INSERT INTO `course` (`CourseID`, `ProfessorID`, `CourseName`, `CourseCode`, `StudentID`) VALUES
(1, 1, 'Object-Oriented Programming', 'OOP', NULL),
(2, 2, 'Data Structure', 'DATASTRU', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `professor`
--

CREATE TABLE `professor` (
  `ProfessorID` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `FullName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `professor`
--

INSERT INTO `professor` (`ProfessorID`, `Username`, `Password`, `FullName`) VALUES
(1, 'joms', '1234', 'maam JOMS'),
(2, 'professor2', 'password2', 'Dr. Jane Doe'),
(3, 'professor3', 'password3', 'Dr. Emily Davis');

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE `student` (
  `StudentID` int(11) NOT NULL,
  `MidtermGrade` decimal(5,2) DEFAULT NULL,
  `StudentName` varchar(50) NOT NULL,
  `FinalsGrade` decimal(5,2) DEFAULT NULL,
  `FinalGrade` decimal(5,2) DEFAULT NULL,
  `StudentNumber` varchar(50) NOT NULL,
  `SectionTest` enum('II-ACSAD','II-BCSAD') NOT NULL,
  `Course` varchar(80) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`StudentID`, `MidtermGrade`, `StudentName`, `FinalsGrade`, `FinalGrade`, `StudentNumber`, `SectionTest`, `Course`) VALUES
(1, 85.00, 'John Doe', 90.00, 88.00, '2024001', 'II-ACSAD', 'Data Structures'),
(2, 72.00, 'Jane Smith', 74.00, 73.00, '2024002', 'II-ACSAD', 'Data Structures'),
(3, 58.00, 'Alice Johnson', 62.00, 60.00, '2024003', 'II-ACSAD', 'Data Structures'),
(4, 35.00, 'Bob Brown', 38.00, 39.00, '2024004', 'II-ACSAD', 'Data Structures'),
(5, 50.00, 'Charlie White', 50.00, 50.00, '2024005', 'II-ACSAD', 'Data Structures'),
(6, 80.00, 'David Black', 82.00, 81.00, '2024006', 'II-ACSAD', 'Data Structures'),
(7, 70.00, 'Emma Green', 74.00, 72.00, '2024007', 'II-ACSAD', 'Data Structures'),
(8, 59.00, 'Frank Blue', 61.00, 60.00, '2024008', 'II-ACSAD', 'Data Structures'),
(9, 81.77, 'Grace Pink', 0.00, 0.00, '2024009', 'II-ACSAD', 'Data Structures'),
(10, 87.00, 'Hannah Yellow', 89.00, 88.00, '2024010', 'II-BCSAD', 'Data Structures'),
(11, 70.00, 'Ivy Brown', 73.00, 71.00, '2024011', 'II-BCSAD', 'Data Structures'),
(12, 57.00, 'Jack Black', 61.00, 59.00, '2024012', 'II-BCSAD', 'Data Structures'),
(13, 36.00, 'Karen Orange', 39.00, 38.00, '2024013', 'II-BCSAD', 'Data Structures'),
(14, 50.00, 'Leo Gray', 50.00, 50.00, '2024014', 'II-BCSAD', 'Data Structures'),
(15, 81.00, 'Mia Purple', 83.00, 82.00, '2024015', 'II-BCSAD', 'Data Structures'),
(16, 69.00, 'Nathan White', 71.00, 70.00, '2024016', 'II-BCSAD', 'Data Structures'),
(17, 58.00, 'Olivia Silver', 60.00, 59.00, '2024017', 'II-BCSAD', 'Data Structures'),
(18, 37.00, 'Paul Gold', 38.00, 38.00, '2024018', 'II-BCSAD', 'Data Structures'),
(19, 57.00, 'Jack Black', 61.00, 59.00, '2024012', 'II-BCSAD', 'Data Structures'),
(20, 72.80, 'Marie Teal', 94.00, 54.00, '2024023', 'II-ACSAD', 'Data Structures');

-- --------------------------------------------------------

--
-- Table structure for table `studentoopgr`
--

CREATE TABLE `studentoopgr` (
  `StudentID` int(11) NOT NULL,
  `MidtermGrade` decimal(5,2) DEFAULT NULL,
  `StudentName` varchar(50) NOT NULL,
  `FinalsGrade` decimal(5,2) DEFAULT NULL,
  `FinalGrade` decimal(5,2) DEFAULT NULL,
  `StudentNumber` varchar(50) NOT NULL,
  `SectionTest` enum('II-ACSAD','II-BCSAD') NOT NULL,
  `Course` varchar(80) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `studentoopgr`
--

INSERT INTO `studentoopgr` (`StudentID`, `MidtermGrade`, `StudentName`, `FinalsGrade`, `FinalGrade`, `StudentNumber`, `SectionTest`, `Course`) VALUES
(1, 86.00, 'John Doe', 90.00, 88.00, '2024001', 'II-ACSAD', 'Object Oriented Programming'),
(2, 73.00, 'Jane Smith', 74.00, 73.20, '2024002', 'II-ACSAD', 'Object Oriented Programming'),
(3, 58.00, 'Alice Johnson', 62.00, 60.40, '2024003', 'II-ACSAD', 'Object Oriented Programming'),
(4, 0.00, 'Bob Brown', 0.00, 0.00, '2024004', 'II-ACSAD', 'Object Oriented Programming'),
(5, 50.00, 'Charlie White', 50.00, 50.00, '2024005', 'II-ACSAD', 'Object Oriented Programming'),
(6, 80.00, 'David Black', 82.00, 81.20, '2024006', 'II-ACSAD', 'Object Oriented Programming'),
(7, 70.00, 'Emma Green', 74.00, 72.40, '2024007', 'II-ACSAD', 'Object Oriented Programming'),
(8, 59.00, 'Frank Blue', 61.00, 60.20, '2024008', 'II-ACSAD', 'Object Oriented Programming'),
(9, 37.00, 'Grace Pink', 39.00, 38.20, '2024009', 'II-ACSAD', 'Object Oriented Programming'),
(10, 87.00, 'Hannah Yellow', 89.00, 88.20, '2024010', 'II-BCSAD', 'Object Oriented Programming'),
(11, 70.00, 'Ivy Brown', 73.00, 71.80, '2024011', 'II-BCSAD', 'Object Oriented Programming'),
(12, 57.00, 'Gary Indigo', 61.00, 59.40, '2024012', 'II-BCSAD', 'Object Oriented Programming'),
(13, 36.00, 'Karen Orange', 39.00, 37.80, '2024013', 'II-BCSAD', 'Object Oriented Programming'),
(14, 50.00, 'Leo Gray', 50.00, 50.00, '2024014', 'II-BCSAD', 'Object Oriented Programming'),
(15, 81.00, 'Mia Purple', 83.00, 82.20, '2024015', 'II-BCSAD', 'Object Oriented Programming'),
(16, 69.00, 'Nathan White', 71.00, 70.20, '2024016', 'II-BCSAD', 'Object Oriented Programming'),
(17, 58.00, 'Olivia Silver', 60.00, 59.20, '2024017', 'II-BCSAD', 'Object Oriented Programming'),
(18, 0.00, 'Paul Gold', 0.00, 0.00, '2024018', 'II-BCSAD', 'Object Oriented Programming'),
(19, 57.00, 'Jack Black', 61.00, 59.40, '2024012', 'II-BCSAD', 'Object Oriented Programming'),
(20, 94.00, 'Marie Teal', 92.00, 92.00, '2024023', 'II-ACSAD', 'Object Oriented Programming');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `blocksection`
--
ALTER TABLE `blocksection`
  ADD PRIMARY KEY (`SectionName`),
  ADD KEY `CourseID` (`CourseID`),
  ADD KEY `StudentID` (`StudentID`);

--
-- Indexes for table `course`
--
ALTER TABLE `course`
  ADD PRIMARY KEY (`CourseID`),
  ADD KEY `ProfessorID` (`ProfessorID`),
  ADD KEY `StudentID` (`StudentID`);

--
-- Indexes for table `professor`
--
ALTER TABLE `professor`
  ADD PRIMARY KEY (`ProfessorID`),
  ADD UNIQUE KEY `Username` (`Username`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`StudentID`);

--
-- Indexes for table `studentoopgr`
--
ALTER TABLE `studentoopgr`
  ADD PRIMARY KEY (`StudentID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `course`
--
ALTER TABLE `course`
  MODIFY `CourseID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `professor`
--
ALTER TABLE `professor`
  MODIFY `ProfessorID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `student`
--
ALTER TABLE `student`
  MODIFY `StudentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `studentoopgr`
--
ALTER TABLE `studentoopgr`
  MODIFY `StudentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=69;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `blocksection`
--
ALTER TABLE `blocksection`
  ADD CONSTRAINT `blocksection_ibfk_1` FOREIGN KEY (`CourseID`) REFERENCES `course` (`CourseID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `blocksection_ibfk_2` FOREIGN KEY (`StudentID`) REFERENCES `student` (`StudentID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `course`
--
ALTER TABLE `course`
  ADD CONSTRAINT `course_ibfk_1` FOREIGN KEY (`ProfessorID`) REFERENCES `professor` (`ProfessorID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `course_ibfk_2` FOREIGN KEY (`StudentID`) REFERENCES `student` (`StudentID`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
