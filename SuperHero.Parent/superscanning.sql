/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50721
Source Host           : localhost:3306
Source Database       : superscanning

Target Server Type    : MYSQL
Target Server Version : 50721
File Encoding         : 65001

Date: 2018-11-02 23:38:11
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for scandata
-- ----------------------------
DROP TABLE IF EXISTS `scandata`;
CREATE TABLE `scandata` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `orderid` varchar(50) NOT NULL,
  `scantime` datetime DEFAULT NULL,
  `scantype` int(11) DEFAULT NULL,
  `scanplace` varchar(20) DEFAULT NULL,
  `scanner` varchar(20) DEFAULT NULL,
  `poststatus` int(11) DEFAULT NULL,
  `posttimes` int(11) DEFAULT NULL,
  `posttime` datetime DEFAULT NULL,
  `weight` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Table structure for scanimage
-- ----------------------------
DROP TABLE IF EXISTS `scanimage`;
CREATE TABLE `scanimage` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `orderid` varchar(50) NOT NULL,
  `imgpath` varchar(255) DEFAULT NULL,
  `poststatus` int(11) DEFAULT NULL,
  `posttimes` int(11) DEFAULT NULL,
  `posttime` datetime DEFAULT NULL,
  `imgstatus` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
