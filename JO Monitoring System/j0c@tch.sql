/*
 Navicat MySQL Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 100121
 Source Host           : localhost:3306
 Source Schema         : j0c@tch

 Target Server Type    : MySQL
 Target Server Version : 100121
 File Encoding         : 65001

 Date: 19/06/2017 13:20:05
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for tblemployee
-- ----------------------------
DROP TABLE IF EXISTS `tblemployee`;
CREATE TABLE `tblemployee`  (
  `EMP_ID` int(11) NOT NULL,
  `FNAME` varchar(30) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `MNAME` varchar(30) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `LNAME` varchar(30) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `SUFFIX` varchar(5) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `JOB_DESCRIPTION` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `DEPARTMENT` varchar(75) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `GENDER` smallint(1) NOT NULL,
  PRIMARY KEY (`EMP_ID`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for tblhistory
-- ----------------------------
DROP TABLE IF EXISTS `tblhistory`;
CREATE TABLE `tblhistory`  (
  `HIST_ID` int(11) NOT NULL AUTO_INCREMENT,
  `JO_ID` int(11) NOT NULL,
  `OLD_TARGETDATE` date NOT NULL,
  `NEW_TARGETDATE` date NOT NULL,
  PRIMARY KEY (`HIST_ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for tbljoborder
-- ----------------------------
DROP TABLE IF EXISTS `tbljoborder`;
CREATE TABLE `tbljoborder`  (
  `JOID` int(11) NOT NULL AUTO_INCREMENT,
  `NAME` varchar(100) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `DESCRIPTION` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `ASSIGNEE` int(11) NOT NULL,
  `DATE_STARTED` date NOT NULL COMMENT ' ',
  `DATE_TARTED` date NOT NULL,
  `REFNO` varchar(15) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `REMARKS` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `STATUS` smallint(1) NOT NULL,
  `NOTIFYSTATUS` smallint(1) NOT NULL,
  PRIMARY KEY (`JOID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for tbllogin
-- ----------------------------
DROP TABLE IF EXISTS `tbllogin`;
CREATE TABLE `tbllogin`  (
  `USERID` int(11) NOT NULL AUTO_INCREMENT,
  `USERNAME` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `USERPASS` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `FNAME` varchar(30) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `MNAME` varchar(30) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `LNAME` varchar(30) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `ROLE` varchar(15) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `STATUS` smallint(1) NOT NULL,
  PRIMARY KEY (`USERID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for tblmaintenance
-- ----------------------------
DROP TABLE IF EXISTS `tblmaintenance`;
CREATE TABLE `tblmaintenance`  (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `M_KEYS` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `M_VALUE` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `REMARKS` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

SET FOREIGN_KEY_CHECKS = 1;
