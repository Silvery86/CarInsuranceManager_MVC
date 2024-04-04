-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Apr 01, 2024 at 08:33 PM
-- Server version: 5.7.34
-- PHP Version: 8.0.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `eProject_Insurance`
--

-- --------------------------------------------------------

--
-- Table structure for table `Admins`
--

CREATE TABLE `Admins` (
  `ID` int(11) NOT NULL,
  `Email` varchar(30) NOT NULL,
  `Password` varchar(32) NOT NULL,
  `Active_status` tinyint(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `Billings`
--

CREATE TABLE `Billings` (
  `ID` int(11) NOT NULL,
  `Insurance_ID` int(11) NOT NULL,
  `Date` date NOT NULL,
  `Amount` decimal(12,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `Claims`
--

CREATE TABLE `Claims` (
  `ID` int(11) NOT NULL,
  `Insurance_ID` int(11) NOT NULL,
  `Accident_place` varchar(100) NOT NULL,
  `Accident_date` date NOT NULL,
  `Insurance_amount` decimal(12,0) NOT NULL,
  `Claimable_amount` decimal(12,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `Customers`
--

CREATE TABLE `Customers` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Address` varchar(100) NOT NULL,
  `Phone` varchar(20) NOT NULL,
  `Password` varchar(32) NOT NULL,
  `Active_status` tinyint(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `Estimates`
--

CREATE TABLE `Estimates` (
  `ID` int(11) NOT NULL,
  `Vehicle_ID` int(11) NOT NULL,
  `Warranty` varchar(100) NOT NULL,
  `Policy_type` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `Expenses`
--

CREATE TABLE `Expenses` (
  `ID` int(11) NOT NULL,
  `Date` date NOT NULL,
  `Type` varchar(100) NOT NULL,
  `Amount` decimal(12,0) NOT NULL,
  `Claim_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `Insurances`
--

CREATE TABLE `Insurances` (
  `ID` int(11) NOT NULL,
  `Estimate_ID` int(11) NOT NULL,
  `Policy_date` date NOT NULL,
  `Policy_duration` date NOT NULL,
  `Customer_prove` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `Vehicles`
--

CREATE TABLE `Vehicles` (
  `ID` int(11) NOT NULL,
  `Name` varchar(20) NOT NULL,
  `Cus_ID` int(11) NOT NULL,
  `Model` varchar(20) NOT NULL,
  `Version` varchar(20) NOT NULL,
  `Rate` decimal(12,0) NOT NULL,
  `Body_number` varchar(20) NOT NULL,
  `Engine_number` varchar(20) NOT NULL,
  `Number` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Admins`
--
ALTER TABLE `Admins`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `Billings`
--
ALTER TABLE `Billings`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Insurance_ID` (`Insurance_ID`);

--
-- Indexes for table `Claims`
--
ALTER TABLE `Claims`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Insurance_ID` (`Insurance_ID`);

--
-- Indexes for table `Customers`
--
ALTER TABLE `Customers`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `Estimates`
--
ALTER TABLE `Estimates`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Vehicle_ID` (`Vehicle_ID`);

--
-- Indexes for table `Expenses`
--
ALTER TABLE `Expenses`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Claim_ID` (`Claim_ID`);

--
-- Indexes for table `Insurances`
--
ALTER TABLE `Insurances`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Estimate_ID` (`Estimate_ID`);

--
-- Indexes for table `Vehicles`
--
ALTER TABLE `Vehicles`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Cus_ID` (`Cus_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Admins`
--
ALTER TABLE `Admins`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Billings`
--
ALTER TABLE `Billings`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Claims`
--
ALTER TABLE `Claims`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Customers`
--
ALTER TABLE `Customers`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Estimates`
--
ALTER TABLE `Estimates`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Expenses`
--
ALTER TABLE `Expenses`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Insurances`
--
ALTER TABLE `Insurances`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Vehicles`
--
ALTER TABLE `Vehicles`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `Billings`
--
ALTER TABLE `Billings`
  ADD CONSTRAINT `billings_ibfk_1` FOREIGN KEY (`Insurance_ID`) REFERENCES `Insurances` (`ID`);

--
-- Constraints for table `Claims`
--
ALTER TABLE `Claims`
  ADD CONSTRAINT `claims_ibfk_1` FOREIGN KEY (`Insurance_ID`) REFERENCES `Insurances` (`ID`);

--
-- Constraints for table `Estimates`
--
ALTER TABLE `Estimates`
  ADD CONSTRAINT `estimates_ibfk_1` FOREIGN KEY (`Vehicle_ID`) REFERENCES `Vehicles` (`ID`);

--
-- Constraints for table `Expenses`
--
ALTER TABLE `Expenses`
  ADD CONSTRAINT `expenses_ibfk_1` FOREIGN KEY (`Claim_ID`) REFERENCES `Claims` (`ID`);

--
-- Constraints for table `Insurances`
--
ALTER TABLE `Insurances`
  ADD CONSTRAINT `insurances_ibfk_1` FOREIGN KEY (`Estimate_ID`) REFERENCES `Estimates` (`ID`);

--
-- Constraints for table `Vehicles`
--
ALTER TABLE `Vehicles`
  ADD CONSTRAINT `vehicles_ibfk_1` FOREIGN KEY (`Cus_ID`) REFERENCES `Customers` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
