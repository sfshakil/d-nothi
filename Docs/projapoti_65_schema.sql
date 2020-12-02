-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Nov 22, 2020 at 03:06 PM
-- Server version: 5.7.29
-- PHP Version: 7.3.14-1~deb10u1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `projapoti_65`
--

-- --------------------------------------------------------

--
-- Table structure for table `api_nothi_part_flag`
--

CREATE TABLE `api_nothi_part_flag` (
  `id` int(11) NOT NULL,
  `part_id` int(11) DEFAULT NULL,
  `nothi_master_id` int(11) DEFAULT NULL,
  `nothi_office_id` int(11) DEFAULT NULL,
  `office_unit_organogram_id` int(11) DEFAULT NULL,
  `flag` tinyint(4) DEFAULT '0',
  `type` tinyint(4) DEFAULT '0',
  `created` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `daak_personal_folders`
--

CREATE TABLE `daak_personal_folders` (
  `id` int(11) NOT NULL,
  `dak_id` int(11) NOT NULL,
  `dak_type` varchar(64) NOT NULL,
  `is_copied_dak` tinyint(2) NOT NULL,
  `designation_id` int(11) NOT NULL,
  `dak_custom_label_id` int(11) NOT NULL,
  `created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` int(11) NOT NULL DEFAULT '0',
  `modified_by` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dak_actions_mig`
--

CREATE TABLE `dak_actions_mig` (
  `id` int(11) NOT NULL,
  `dak_action_name` varchar(255) NOT NULL DEFAULT '',
  `status` tinyint(2) NOT NULL DEFAULT '1',
  `creator` int(11) DEFAULT '0',
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_action_employees`
--

CREATE TABLE `dak_action_employees` (
  `id` int(11) NOT NULL,
  `dak_action_id` int(11) NOT NULL,
  `employee_id` int(11) DEFAULT '0',
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_attachments`
--

CREATE TABLE `dak_attachments` (
  `id` bigint(20) NOT NULL,
  `dak_type` varchar(255) NOT NULL,
  `dak_id` bigint(20) NOT NULL,
  `is_main` tinyint(4) NOT NULL DEFAULT '0',
  `attachment_type` varchar(255) NOT NULL,
  `attachment_description` varchar(255) DEFAULT NULL,
  `file_size_in_kb` double NOT NULL DEFAULT '0',
  `file_custom_name` varchar(255) DEFAULT NULL,
  `file_name` varchar(200) DEFAULT NULL,
  `user_file_name` varchar(255) DEFAULT NULL,
  `file_dir` varchar(255) DEFAULT NULL,
  `content_cover` longtext,
  `content_body` longtext,
  `meta_data` varchar(1000) DEFAULT NULL,
  `is_summary_nothi` tinyint(2) DEFAULT '0',
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created` datetime DEFAULT CURRENT_TIMESTAMP,
  `modified` datetime DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_attachment_comment`
--

CREATE TABLE `dak_attachment_comment` (
  `id` bigint(20) NOT NULL,
  `dak_id` bigint(20) NOT NULL,
  `dak_type` varchar(10) NOT NULL DEFAULT 'Daptorik',
  `attachment_id` bigint(20) NOT NULL,
  `fonts` varchar(50) DEFAULT 'italic 14px "Nikosh"',
  `color` varchar(10) NOT NULL DEFAULT '#D314D8',
  `comments` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `designation_label` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `office_address` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `position_x` double NOT NULL DEFAULT '10',
  `position_y` double NOT NULL DEFAULT '20',
  `created` datetime NOT NULL,
  `created_by` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dak_childs`
--

CREATE TABLE `dak_childs` (
  `id` int(11) NOT NULL,
  `dak_type` varchar(255) NOT NULL,
  `designation_id` int(11) NOT NULL DEFAULT '0',
  `parent_dak` varchar(255) NOT NULL,
  `content_dak` varchar(64) DEFAULT NULL,
  `created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_custom_labels`
--

CREATE TABLE `dak_custom_labels` (
  `id` bigint(20) NOT NULL,
  `parent_id` int(11) NOT NULL DEFAULT '0',
  `module_type` varchar(64) NOT NULL,
  `open_for_all` tinyint(2) NOT NULL DEFAULT '0',
  `designation_id` bigint(20) NOT NULL,
  `designation` varchar(255) NOT NULL,
  `office_unit_id` bigint(20) NOT NULL,
  `office_unit` varchar(255) NOT NULL,
  `office_id` bigint(20) NOT NULL,
  `office` varchar(255) NOT NULL,
  `officer_id` bigint(20) NOT NULL,
  `officer` varchar(255) NOT NULL,
  `custom_name` varchar(255) NOT NULL,
  `created_by` bigint(20) NOT NULL,
  `modified_by` bigint(20) NOT NULL,
  `created` datetime NOT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_daptoriks`
--

CREATE TABLE `dak_daptoriks` (
  `id` bigint(20) NOT NULL,
  `sender_sarok_no` varchar(255) DEFAULT NULL,
  `sender_office_id` int(11) NOT NULL,
  `sender_officer_id` int(11) NOT NULL,
  `sender_office_name` varchar(255) NOT NULL,
  `sender_office_unit_id` int(11) NOT NULL,
  `sender_office_unit_name` varchar(255) NOT NULL,
  `sender_officer_designation_id` int(11) NOT NULL,
  `sender_officer_designation_label` varchar(255) DEFAULT NULL,
  `sending_date` datetime DEFAULT NULL,
  `sender_name` varchar(255) DEFAULT NULL,
  `sender_address` text,
  `sender_email` varchar(255) DEFAULT NULL,
  `sender_phone` varchar(255) DEFAULT NULL,
  `sender_mobile` varchar(255) DEFAULT NULL,
  `dak_sending_media` varchar(255) DEFAULT NULL,
  `dak_received_no` varchar(50) NOT NULL,
  `docketing_no` bigint(20) NOT NULL,
  `receiving_date` datetime DEFAULT NULL,
  `dak_subject` text NOT NULL,
  `dak_security_level` varchar(64) NOT NULL,
  `dak_priority_level` varchar(64) NOT NULL,
  `dak_cover` longtext,
  `dak_description` longtext,
  `meta_data` varchar(1000) DEFAULT NULL,
  `receiving_office_id` int(11) NOT NULL,
  `receiving_office_name` varchar(255) DEFAULT NULL,
  `receiving_office_unit_id` int(11) NOT NULL,
  `receiving_office_unit_name` varchar(255) NOT NULL,
  `receiving_officer_id` int(11) NOT NULL,
  `receiving_officer_designation_id` int(11) NOT NULL,
  `receiving_officer_designation_label` varchar(255) DEFAULT NULL,
  `receiving_officer_name` varchar(255) DEFAULT NULL,
  `dak_status` varchar(64) NOT NULL,
  `is_summary_nothi` tinyint(2) DEFAULT '0',
  `created_by` int(11) NOT NULL DEFAULT '0',
  `modified_by` int(11) NOT NULL DEFAULT '0',
  `uploader_designation_id` int(11) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL,
  `previous_receipt_no` text,
  `previous_docketing_no` varchar(250) DEFAULT NULL,
  `is_rollback_to_dak` tinyint(4) NOT NULL DEFAULT '0',
  `from_potrojari` tinyint(1) NOT NULL DEFAULT '0',
  `potrojari_id` bigint(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_master_movements`
--

CREATE TABLE `dak_master_movements` (
  `id` bigint(20) NOT NULL,
  `dak_key` varchar(255) NOT NULL,
  `operation_type` varchar(64) NOT NULL,
  `dak_security` int(4) NOT NULL,
  `dak_priority` int(4) NOT NULL DEFAULT '0',
  `dak_decision` varchar(255) NOT NULL DEFAULT ' ',
  `last_movement_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `potrojari_id` bigint(20) NOT NULL DEFAULT '0',
  `is_summary_nothi` tinyint(1) NOT NULL DEFAULT '0',
  `from_office_id` int(11) NOT NULL,
  `from_office_unit_id` int(11) NOT NULL,
  `from_designation_id` int(11) NOT NULL,
  `from_officer_id` int(11) NOT NULL,
  `from_office` varchar(255) NOT NULL,
  `from_office_unit` varchar(255) NOT NULL,
  `from_designation` varchar(255) NOT NULL,
  `from_officer` varchar(255) NOT NULL,
  `from_office_address` varchar(255) NOT NULL DEFAULT ' ',
  `created_by` int(11) NOT NULL DEFAULT '0',
  `modifed_by` int(11) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `token` varchar(255) NOT NULL,
  `device_type` varchar(255) NOT NULL,
  `device_id` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_master_movement_users`
--

CREATE TABLE `dak_master_movement_users` (
  `id` bigint(20) NOT NULL,
  `dak_master_movement_id` bigint(20) NOT NULL,
  `recipient_type` varchar(255) NOT NULL,
  `office_id` int(11) NOT NULL,
  `office` varchar(255) NOT NULL,
  `office_unit_id` int(11) NOT NULL,
  `office_unit` varchar(255) NOT NULL,
  `designation_id` int(11) NOT NULL,
  `designation` varchar(255) NOT NULL,
  `officer_id` int(11) NOT NULL,
  `officer` varchar(255) NOT NULL,
  `office_address` varchar(255) NOT NULL,
  `created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` int(11) NOT NULL DEFAULT '0',
  `modified_by` int(11) NOT NULL DEFAULT '0',
  `token` varchar(255) DEFAULT NULL,
  `device_id` varchar(255) DEFAULT NULL,
  `device_type` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_movements`
--

CREATE TABLE `dak_movements` (
  `id` bigint(20) NOT NULL,
  `dak_type` varchar(64) NOT NULL,
  `dak_origin` varchar(64) NOT NULL DEFAULT 'nothi',
  `dak_dagorik_type` tinyint(2) NOT NULL DEFAULT '1',
  `dak_id` bigint(20) NOT NULL,
  `is_copied_dak` tinyint(2) NOT NULL DEFAULT '1',
  `from_office_id` int(11) DEFAULT '0',
  `from_office_name` varchar(255) DEFAULT NULL,
  `from_office_unit_id` int(11) DEFAULT '0',
  `from_office_unit_name` varchar(255) DEFAULT NULL,
  `from_office_address` text,
  `from_officer_id` int(11) DEFAULT '0',
  `from_officer_name` varchar(255) DEFAULT NULL,
  `from_officer_designation_id` int(11) DEFAULT '0',
  `from_officer_designation_label` varchar(255) DEFAULT NULL,
  `to_office_id` int(11) DEFAULT '0',
  `to_office_name` varchar(255) DEFAULT NULL,
  `to_office_unit_id` int(11) NOT NULL,
  `to_office_unit_name` varchar(255) NOT NULL,
  `to_office_address` text,
  `to_officer_id` int(11) NOT NULL,
  `to_officer_name` varchar(255) DEFAULT NULL,
  `to_officer_designation_id` int(11) NOT NULL,
  `to_officer_designation_label` varchar(255) DEFAULT NULL,
  `attention_type` varchar(128) NOT NULL,
  `docketing_no` bigint(20) NOT NULL,
  `from_sarok_no` varchar(255) NOT NULL,
  `to_sarok_no` varchar(255) NOT NULL,
  `operation_type` varchar(255) NOT NULL COMMENT 'Forward, sent etc',
  `dak_actions` varchar(255) NOT NULL COMMENT 'Text From Dak Action',
  `from_potrojari` tinyint(2) NOT NULL DEFAULT '0',
  `is_summary_nothi` tinyint(4) NOT NULL DEFAULT '0',
  `sequence` int(4) DEFAULT NULL,
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `dak_priority` tinyint(3) DEFAULT '0',
  `dak_security_level` varchar(64) DEFAULT NULL,
  `last_movement_date` datetime DEFAULT NULL,
  `token` bigint(20) DEFAULT NULL,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_nagoriks`
--

CREATE TABLE `dak_nagoriks` (
  `id` bigint(16) NOT NULL,
  `docketing_no` bigint(20) NOT NULL,
  `dak_subject` text NOT NULL,
  `dak_type_id` tinyint(2) NOT NULL DEFAULT '1',
  `dak_received_no` varchar(50) DEFAULT NULL,
  `dak_description` longtext,
  `dak_priority_level` varchar(64) NOT NULL DEFAULT '1',
  `dak_security_level` varchar(64) NOT NULL DEFAULT '1',
  `name_eng` varchar(250) DEFAULT NULL,
  `name_bng` varchar(250) NOT NULL,
  `sender_name` varchar(200) DEFAULT NULL,
  `national_idendity_no` varchar(20) DEFAULT NULL,
  `birth_registration_number` varchar(20) DEFAULT NULL,
  `passport` varchar(20) DEFAULT NULL,
  `father_name` varchar(250) DEFAULT NULL,
  `mother_name` varchar(250) DEFAULT NULL,
  `address` varchar(500) DEFAULT NULL,
  `parmanent_address` varchar(255) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `phone_no` varchar(20) DEFAULT NULL,
  `mobile_no` varchar(20) DEFAULT NULL,
  `gender` varchar(10) DEFAULT NULL,
  `nationality` varchar(50) DEFAULT NULL,
  `religion` varchar(20) DEFAULT NULL,
  `feedback_type` int(11) NOT NULL DEFAULT '0' COMMENT '1:email, 2:sms, 3: dak',
  `receiving_office_id` int(10) NOT NULL,
  `receiving_office_name` varchar(255) DEFAULT NULL,
  `receiving_office_unit_id` int(11) NOT NULL,
  `receiving_office_unit_name` varchar(255) NOT NULL,
  `receiving_officer_id` int(11) NOT NULL,
  `receiving_officer_designation_id` int(11) NOT NULL,
  `receiving_officer_designation_label` varchar(255) NOT NULL,
  `receiving_officer_name` varchar(255) NOT NULL,
  `receiving_date` datetime DEFAULT NULL,
  `nothi_master_id` bigint(10) DEFAULT NULL,
  `dak_status` varchar(64) NOT NULL,
  `uploader_designation_id` bigint(20) NOT NULL DEFAULT '0',
  `application_origin` varchar(50) DEFAULT 'nothi',
  `meta_data` text,
  `created_by` int(10) DEFAULT NULL,
  `modified_by` bigint(15) DEFAULT NULL,
  `created` datetime NOT NULL,
  `modified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `previous_receipt_no` text,
  `previous_docketing_no` varchar(250) DEFAULT NULL,
  `is_rollback_to_dak` tinyint(4) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_register`
--

CREATE TABLE `dak_register` (
  `id` bigint(20) NOT NULL,
  `dak_id` bigint(20) NOT NULL,
  `dak_type` varchar(64) NOT NULL,
  `dak_received_no` varchar(50) NOT NULL,
  `docketing_no` varchar(255) NOT NULL,
  `sender_sarok_no` varchar(255) DEFAULT NULL,
  `sender_office_id` int(11) DEFAULT NULL,
  `sender_officer_id` int(11) DEFAULT NULL,
  `sender_office_name` varchar(255) DEFAULT NULL,
  `sender_office_unit_id` int(11) DEFAULT NULL,
  `sender_office_unit_name` varchar(255) DEFAULT NULL,
  `sender_officer_designation_id` int(11) DEFAULT NULL,
  `sender_officer_designation_label` varchar(255) DEFAULT NULL,
  `sending_date` datetime DEFAULT NULL,
  `sender_name` varchar(255) DEFAULT NULL,
  `sender_address` text,
  `sender_email` varchar(255) DEFAULT NULL,
  `sender_phone` varchar(255) DEFAULT NULL,
  `sender_mobile` varchar(255) DEFAULT NULL,
  `dak_sending_media` varchar(255) DEFAULT NULL,
  `receiving_date` datetime DEFAULT NULL,
  `dak_subject` varchar(255) NOT NULL,
  `dak_security_level` varchar(64) DEFAULT NULL,
  `dak_priority_level` varchar(64) DEFAULT NULL,
  `receiving_office_id` int(11) DEFAULT NULL,
  `receiving_office_unit_id` int(11) DEFAULT NULL,
  `receiving_office_unit_name` varchar(255) DEFAULT NULL,
  `receiving_officer_id` int(11) DEFAULT NULL,
  `receiving_officer_designation_id` int(11) DEFAULT NULL,
  `receiving_officer_designation_label` varchar(255) DEFAULT NULL,
  `receiving_officer_name` varchar(255) DEFAULT NULL,
  `is_summary_nothi` tinyint(2) DEFAULT NULL,
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `uploader_designation_id` int(11) NOT NULL,
  `dak_status` varchar(64) NOT NULL,
  `from_office_id` int(11) NOT NULL,
  `from_office_name` varchar(255) NOT NULL,
  `from_office_unit_id` int(11) NOT NULL,
  `from_office_unit_name` varchar(255) NOT NULL,
  `from_officer_id` int(11) NOT NULL,
  `from_officer_name` varchar(255) NOT NULL,
  `from_officer_designation_id` int(11) NOT NULL,
  `from_officer_designation_label` varchar(255) NOT NULL,
  `to_office_id` int(11) NOT NULL,
  `to_office_name` varchar(255) NOT NULL,
  `to_office_unit_id` int(11) NOT NULL,
  `to_office_unit_name` varchar(255) NOT NULL,
  `to_officer_id` int(11) NOT NULL,
  `to_officer_name` varchar(255) NOT NULL,
  `to_officer_designation_id` int(11) NOT NULL,
  `to_officer_designation_label` varchar(255) NOT NULL,
  `attention_type` tinyint(2) NOT NULL,
  `dak_actions` varchar(255) DEFAULT NULL,
  `movement_id` bigint(20) NOT NULL,
  `operation_type` varchar(255) NOT NULL,
  `movement_time` datetime NOT NULL,
  `dak_created` datetime NOT NULL,
  `nothi_master_id` bigint(20) DEFAULT NULL,
  `nothi_part_id` bigint(20) DEFAULT NULL,
  `nothi_potro_id` bigint(20) DEFAULT NULL,
  `created` datetime NOT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_sorting_permissions`
--

CREATE TABLE `dak_sorting_permissions` (
  `id` bigint(20) NOT NULL,
  `assignor_designation_id` bigint(20) NOT NULL,
  `assignor_designation_level` varchar(255) NOT NULL,
  `assignor_office_unit_id` bigint(20) NOT NULL,
  `assignor_office_unit_name` varchar(255) NOT NULL,
  `assignor_office_id` bigint(20) NOT NULL,
  `assignor_office_name` varchar(255) NOT NULL,
  `assignor_name` varchar(255) NOT NULL,
  `assignee_designation_id` bigint(20) NOT NULL,
  `assignee_designation_level` varchar(255) NOT NULL,
  `assignee_office_unit_id` bigint(20) NOT NULL,
  `assignee_office_unit_name` varchar(255) NOT NULL,
  `assignee_office_id` bigint(20) NOT NULL,
  `assignee_office_name` varchar(255) NOT NULL,
  `assignee_name` varchar(255) NOT NULL,
  `module_name` int(11) NOT NULL DEFAULT '0',
  `permission_type` varchar(64) DEFAULT NULL COMMENT 'read, write',
  `created_by` bigint(20) NOT NULL,
  `modified_by` bigint(20) NOT NULL,
  `created` datetime NOT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_third_table`
--

CREATE TABLE `dak_third_table` (
  `id` int(11) NOT NULL,
  `dak_id` int(11) NOT NULL,
  `dak_type` varchar(255) NOT NULL,
  `is_copied_dak` tinyint(4) NOT NULL,
  `designation_id` int(11) NOT NULL,
  `no_of_times_dak_received` int(11) NOT NULL,
  `dak_movement_sequence` int(11) NOT NULL,
  `dak_decision` varchar(255) NOT NULL,
  `last_movement_date` datetime NOT NULL,
  `from_potrojari` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_users`
--

CREATE TABLE `dak_users` (
  `id` bigint(20) NOT NULL,
  `dak_type` varchar(64) NOT NULL,
  `dak_id` bigint(20) NOT NULL,
  `is_copied_dak` tinyint(2) NOT NULL DEFAULT '1',
  `dak_origin` varchar(64) NOT NULL DEFAULT 'nothi',
  `action_office_id` int(11) NOT NULL DEFAULT '0',
  `from_potrojari` tinyint(1) NOT NULL DEFAULT '0',
  `to_office_id` int(11) NOT NULL,
  `to_office_name` varchar(255) DEFAULT NULL,
  `to_office_unit_id` int(11) NOT NULL,
  `to_office_unit_name` varchar(255) NOT NULL,
  `to_office_address` text,
  `to_officer_id` int(11) NOT NULL,
  `to_officer_name` varchar(255) DEFAULT NULL,
  `to_officer_designation_id` int(11) NOT NULL,
  `to_officer_designation_label` varchar(255) DEFAULT NULL,
  `no_of_times_dak_received` int(4) NOT NULL DEFAULT '1',
  `dak_view_status` varchar(64) NOT NULL,
  `dak_priority` varchar(64) NOT NULL,
  `dak_security` varchar(65) NOT NULL,
  `attention_type` varchar(128) NOT NULL,
  `dak_movement_sequence` int(11) NOT NULL DEFAULT '0',
  `rollback_move_seq` int(11) NOT NULL DEFAULT '0',
  `last_movement_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `is_archive` tinyint(2) NOT NULL DEFAULT '0',
  `is_rollback_dak` tinyint(2) NOT NULL DEFAULT '0',
  `dak_category` varchar(64) NOT NULL,
  `is_summary_nothi` tinyint(2) NOT NULL DEFAULT '0',
  `is_nisponno` tinyint(2) NOT NULL DEFAULT '0',
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `token` bigint(20) DEFAULT NULL,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL,
  `dak_subject` text,
  `dak_receipt_no` varchar(255) DEFAULT NULL,
  `docketing_no` bigint(20) DEFAULT NULL,
  `dak_decision` text,
  `drafted_by_designation_id` int(11) NOT NULL DEFAULT '0',
  `drafted_decisions` json DEFAULT NULL,
  `archived_dak_user_id` int(11) NOT NULL DEFAULT '0' COMMENT 'onulipi dak forward: mul dak is archived for this user and generated new dak id and movement'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_user_actions`
--

CREATE TABLE `dak_user_actions` (
  `id` bigint(20) NOT NULL,
  `dak_id` bigint(20) NOT NULL,
  `dak_type` varchar(10) NOT NULL DEFAULT 'Daptorik',
  `dak_user_id` bigint(20) NOT NULL,
  `dak_action` varchar(64) NOT NULL,
  `is_summary_nothi` tinyint(2) NOT NULL DEFAULT '0',
  `created_by` int(11) DEFAULT NULL,
  `created` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `ds_user_info`
--

CREATE TABLE `ds_user_info` (
  `id` bigint(20) NOT NULL,
  `username` varchar(250) NOT NULL,
  `employee_record_id` bigint(20) NOT NULL,
  `soft_token` varchar(250) NOT NULL,
  `expired_at` datetime NOT NULL,
  `created` datetime NOT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `device_id` varchar(50) DEFAULT NULL,
  `device_type` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `guard_files`
--

CREATE TABLE `guard_files` (
  `id` bigint(20) NOT NULL,
  `name_bng` varchar(200) NOT NULL,
  `name_eng` varchar(200) DEFAULT NULL,
  `guard_file_category_id` bigint(20) NOT NULL,
  `file_number` bigint(20) NOT NULL,
  `office_id` int(11) NOT NULL,
  `office_name` varchar(255) DEFAULT NULL,
  `office_unit_id` bigint(20) NOT NULL,
  `office_unit_name` varchar(255) DEFAULT NULL,
  `office_unit_organogram_id` bigint(20) DEFAULT NULL,
  `office_unit_organogram_name` varchar(255) DEFAULT NULL,
  `created_by` bigint(20) DEFAULT NULL,
  `modified_by` bigint(20) DEFAULT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `guard_file_api_datas`
--

CREATE TABLE `guard_file_api_datas` (
  `id` bigint(20) NOT NULL,
  `layer_id` int(11) DEFAULT NULL,
  `type` text,
  `subdomain` varchar(255) DEFAULT NULL,
  `name` text,
  `link` text,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `guard_file_attachments`
--

CREATE TABLE `guard_file_attachments` (
  `id` int(11) NOT NULL,
  `guard_file_id` bigint(20) NOT NULL,
  `name_bng` varchar(255) DEFAULT NULL,
  `attachment_type` varchar(150) NOT NULL,
  `user_file_name` varchar(255) DEFAULT NULL,
  `file_name` varchar(255) NOT NULL,
  `file_custom_name` varchar(255) DEFAULT NULL,
  `file_dir` varchar(255) DEFAULT NULL,
  `file_size_in_kb` double NOT NULL DEFAULT '0',
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `created_by` bigint(20) DEFAULT NULL,
  `modified_by` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `guard_file_categories`
--

CREATE TABLE `guard_file_categories` (
  `id` int(11) NOT NULL,
  `name_bng` varchar(200) NOT NULL,
  `parent_id` bigint(20) NOT NULL DEFAULT '0',
  `office_id` int(11) NOT NULL,
  `office_unit_id` bigint(20) NOT NULL,
  `office_unit_organogram_id` bigint(20) NOT NULL,
  `created_by` bigint(20) DEFAULT NULL,
  `modified_by` bigint(20) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `honor_boards`
--

CREATE TABLE `honor_boards` (
  `id` int(11) NOT NULL,
  `unit_id` int(11) NOT NULL,
  `name` varchar(512) CHARACTER SET utf8 NOT NULL,
  `organogram_name` varchar(512) CHARACTER SET utf8 NOT NULL,
  `incharge_label` varchar(128) CHARACTER SET utf8 DEFAULT NULL,
  `employee_record_id` int(11) DEFAULT NULL,
  `organogram_id` int(11) DEFAULT NULL,
  `join_date` date NOT NULL,
  `release_date` date DEFAULT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `messages`
--

CREATE TABLE `messages` (
  `id` int(11) NOT NULL,
  `title` varchar(256) COLLATE utf8_unicode_ci NOT NULL,
  `message` text COLLATE utf8_unicode_ci NOT NULL,
  `message_for` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `related_id` int(11) NOT NULL,
  `message_by` int(11) NOT NULL,
  `is_deleted` int(1) NOT NULL,
  `created` datetime DEFAULT NULL,
  `modified` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `message_views`
--

CREATE TABLE `message_views` (
  `id` int(11) NOT NULL,
  `message_id` int(11) NOT NULL,
  `is_view` int(1) NOT NULL,
  `organogram_id` int(11) NOT NULL,
  `view_count` int(11) NOT NULL,
  `created` datetime DEFAULT NULL,
  `updated` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `nisponno_records`
--

CREATE TABLE `nisponno_records` (
  `id` bigint(20) NOT NULL,
  `nothi_master_id` int(11) NOT NULL,
  `nothi_part_no` int(11) NOT NULL,
  `type` varchar(100) NOT NULL,
  `nothi_onucched_id` int(11) DEFAULT NULL,
  `potrojari_id` int(11) NOT NULL DEFAULT '0',
  `nothi_office_id` int(11) NOT NULL,
  `office_id` int(11) NOT NULL,
  `unit_id` int(11) NOT NULL,
  `designation_id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  `potrojari_internal_own` int(11) NOT NULL DEFAULT '0',
  `potrojari_internal_other` int(11) NOT NULL DEFAULT '0',
  `dak_srijito` int(11) NOT NULL DEFAULT '0',
  `operation_date` datetime NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `note_flags`
--

CREATE TABLE `note_flags` (
  `id` int(11) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `notesheet_id` bigint(20) NOT NULL,
  `office_id` bigint(20) NOT NULL,
  `office_unit_id` bigint(20) NOT NULL,
  `office_organogram_id` bigint(20) NOT NULL,
  `employee_id` bigint(20) NOT NULL,
  `color` varchar(25) NOT NULL,
  `title` varchar(50) CHARACTER SET utf8 NOT NULL,
  `page_url` varchar(200) CHARACTER SET utf8 DEFAULT NULL,
  `created` timestamp NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `note_initiator`
--

CREATE TABLE `note_initiator` (
  `id` bigint(20) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL,
  `office_id` bigint(20) NOT NULL,
  `office_unit_id` int(11) NOT NULL,
  `designation_id` int(11) NOT NULL,
  `office` varchar(255) NOT NULL DEFAULT '',
  `office_unit` varchar(255) NOT NULL DEFAULT '',
  `designation` varchar(255) NOT NULL DEFAULT '',
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `created` datetime NOT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `token` text,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL,
  `self_note` tinyint(2) NOT NULL DEFAULT '1',
  `dak_note` tinyint(2) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothivukto_nothis`
--

CREATE TABLE `nothivukto_nothis` (
  `id` int(11) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL DEFAULT '0',
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '1',
  `nothi_potro_id` int(11) NOT NULL,
  `dak_id` bigint(20) NOT NULL,
  `dak_type` varchar(10) NOT NULL DEFAULT 'Daptorik',
  `is_copied_dak` tinyint(2) NOT NULL DEFAULT '1',
  `dak_movement_id` bigint(20) NOT NULL DEFAULT '0',
  `is_nisponno` tinyint(2) NOT NULL DEFAULT '0',
  `status` tinyint(2) NOT NULL DEFAULT '1',
  `created` datetime DEFAULT NULL,
  `modified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `created_by` int(11) NOT NULL DEFAULT '0',
  `modified_by` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `nothivukto_nothis_merge_table`
--

CREATE TABLE `nothivukto_nothis_merge_table` (
  `id` bigint(20) NOT NULL,
  `dak_id` bigint(20) NOT NULL,
  `dak_movement_id` bigint(20) NOT NULL,
  `dak_type` varchar(10) CHARACTER SET utf8 NOT NULL DEFAULT 'Daptorik',
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '1',
  `status` tinyint(2) NOT NULL DEFAULT '1',
  `created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_archive_requests`
--

CREATE TABLE `nothi_archive_requests` (
  `id` int(11) NOT NULL,
  `office_id` int(11) DEFAULT NULL,
  `nothi_master_id` int(11) DEFAULT NULL,
  `requested_date` datetime DEFAULT NULL,
  `requested_organogram_id` int(11) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `responsed_date` datetime DEFAULT NULL,
  `comments` varchar(1024) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_data_change_history`
--

CREATE TABLE `nothi_data_change_history` (
  `id` int(11) NOT NULL,
  `nothi_master_id` int(11) NOT NULL,
  `nothi_data` text,
  `employee_id` int(11) DEFAULT NULL,
  `office_unit_organogram_id` int(11) DEFAULT NULL,
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL,
  `employee_name` varchar(250) DEFAULT NULL,
  `designation_name` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_decisions_mig`
--

CREATE TABLE `nothi_decisions_mig` (
  `id` int(11) NOT NULL,
  `decisions` varchar(255) NOT NULL DEFAULT '',
  `status` tinyint(2) NOT NULL DEFAULT '1',
  `creator` int(11) DEFAULT '0',
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_decision_employees`
--

CREATE TABLE `nothi_decision_employees` (
  `id` int(11) NOT NULL,
  `nothi_decision_id` int(11) NOT NULL,
  `employee_id` int(11) DEFAULT '0',
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_masters`
--

CREATE TABLE `nothi_masters` (
  `id` bigint(20) NOT NULL,
  `office_id` bigint(20) NOT NULL,
  `office_name` varchar(255) DEFAULT NULL,
  `office_unit_id` int(11) NOT NULL,
  `office_unit_name` varchar(255) DEFAULT NULL,
  `office_unit_organogram_id` int(11) NOT NULL,
  `office_designation_name` varchar(255) DEFAULT NULL,
  `nothi_type_id` int(11) NOT NULL,
  `nothi_no` varchar(64) NOT NULL,
  `subject` text NOT NULL,
  `nothi_created_date` date NOT NULL,
  `description` text,
  `nothi_class` tinyint(9) NOT NULL DEFAULT '1',
  `is_active` tinyint(4) NOT NULL DEFAULT '1',
  `is_deleted` tinyint(1) NOT NULL DEFAULT '0',
  `is_archived` tinyint(1) NOT NULL DEFAULT '0',
  `archived_date` datetime DEFAULT NULL,
  `archived_organogram_id` int(11) DEFAULT NULL,
  `archived_designation_name` varchar(255) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_master_movements`
--

CREATE TABLE `nothi_master_movements` (
  `id` bigint(20) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '1',
  `nothi_office` int(11) NOT NULL DEFAULT '0',
  `note_decision` varchar(255) NOT NULL,
  `from_office_id` int(11) DEFAULT NULL,
  `from_office_name` varchar(255) DEFAULT NULL,
  `from_office_unit_id` int(11) NOT NULL,
  `from_office_unit_name` varchar(255) NOT NULL,
  `from_officer_id` int(11) DEFAULT NULL,
  `from_officer_name` varchar(255) DEFAULT NULL,
  `from_officer_designation_id` int(11) NOT NULL,
  `from_officer_designation_label` varchar(255) DEFAULT NULL,
  `to_office_id` int(11) NOT NULL,
  `to_office_name` varchar(255) DEFAULT NULL,
  `to_office_unit_id` int(11) NOT NULL,
  `to_office_unit_name` varchar(255) NOT NULL,
  `to_officer_id` int(11) NOT NULL,
  `to_officer_name` varchar(255) DEFAULT NULL,
  `to_officer_designation_id` int(11) NOT NULL,
  `to_officer_designation_label` varchar(255) DEFAULT NULL,
  `view_status` tinyint(4) NOT NULL DEFAULT '0',
  `movement_type` tinyint(2) NOT NULL DEFAULT '1',
  `priority` tinyint(4) NOT NULL DEFAULT '0',
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL,
  `token` bigint(20) DEFAULT NULL,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_master_permissions`
--

CREATE TABLE `nothi_master_permissions` (
  `id` int(11) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_office` int(11) DEFAULT '0',
  `office_id` int(11) NOT NULL,
  `office_unit_id` int(11) NOT NULL,
  `designation_id` int(11) NOT NULL,
  `nothi_office_name` varchar(255) DEFAULT NULL,
  `office` varchar(255) DEFAULT NULL,
  `office_unit` varchar(255) DEFAULT NULL,
  `designation` varchar(255) DEFAULT NULL,
  `designation_level` int(11) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL,
  `modified` datetime DEFAULT NULL,
  `created_by` int(11) NOT NULL,
  `modified_by` bigint(20) DEFAULT '0',
  `is_strict_route` tinyint(4) NOT NULL DEFAULT '0',
  `route_index` int(11) NOT NULL DEFAULT '0',
  `max_transaction_day` int(8) NOT NULL DEFAULT '0',
  `layer_index` int(8) NOT NULL DEFAULT '1',
  `is_active` int(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_master_permissions_history`
--

CREATE TABLE `nothi_master_permissions_history` (
  `id` bigint(20) NOT NULL,
  `nothi_users_privilige_id` bigint(20) NOT NULL,
  `privilige_type_new` tinyint(1) NOT NULL DEFAULT '0',
  `privilige_type_prev` tinyint(1) NOT NULL DEFAULT '0' COMMENT '0: No access 1: Can View and Edit 2: Can View Only',
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `modified_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_notes`
--

CREATE TABLE `nothi_notes` (
  `id` bigint(20) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_note_no` bigint(20) NOT NULL DEFAULT '1',
  `nothi_note_no_bn` varchar(20) NOT NULL DEFAULT '১',
  `office_id` bigint(20) NOT NULL,
  `office_unit_id` int(11) NOT NULL DEFAULT '0',
  `office_unit_organogram_id` int(11) NOT NULL DEFAULT '0',
  `office_name` varchar(255) NOT NULL DEFAULT '',
  `office_unit_name` varchar(255) NOT NULL DEFAULT '',
  `office_designation_name` varchar(255) NOT NULL DEFAULT '',
  `nothi_type_id` int(11) NOT NULL DEFAULT '0',
  `nothi_no` varchar(64) NOT NULL,
  `subject` text NOT NULL COMMENT 'nothi subject',
  `nothi_created_date` date NOT NULL,
  `description` text,
  `nothi_class` tinyint(4) NOT NULL DEFAULT '4',
  `is_active` tinyint(4) NOT NULL DEFAULT '1',
  `is_deleted` tinyint(1) NOT NULL DEFAULT '0',
  `note_subject` text,
  `last_update` datetime DEFAULT NULL,
  `finished_count` int(11) NOT NULL DEFAULT '0',
  `onucched_count` int(11) NOT NULL DEFAULT '0',
  `created` datetime DEFAULT NULL,
  `modified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) NOT NULL,
  `token` bigint(20) DEFAULT NULL,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_note_attachment_refs`
--

CREATE TABLE `nothi_note_attachment_refs` (
  `id` bigint(20) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '1',
  `attachment_type` varchar(255) NOT NULL,
  `file_name` varchar(255) NOT NULL,
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_note_current_users`
--

CREATE TABLE `nothi_note_current_users` (
  `id` bigint(20) NOT NULL,
  `nothi_master_id` bigint(20) DEFAULT NULL,
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '1',
  `note_subject` text,
  `note_no` int(11) NOT NULL DEFAULT '0',
  `nothi_office` int(11) NOT NULL DEFAULT '0',
  `is_archive` tinyint(2) NOT NULL DEFAULT '0',
  `is_finished` tinyint(2) NOT NULL DEFAULT '0',
  `is_summary` tinyint(2) NOT NULL DEFAULT '0',
  `office_id` bigint(20) DEFAULT NULL,
  `office_unit_id` bigint(20) DEFAULT NULL,
  `office_unit_organogram_id` bigint(20) DEFAULT NULL,
  `employee_id` bigint(20) DEFAULT NULL,
  `office_name` varchar(255) NOT NULL DEFAULT '',
  `office_unit_name` varchar(255) NOT NULL DEFAULT '',
  `office_designation_name` varchar(255) NOT NULL DEFAULT '',
  `officer_name` varchar(255) NOT NULL DEFAULT '',
  `view_status` tinyint(4) NOT NULL DEFAULT '0',
  `issue_date` datetime DEFAULT NULL,
  `forward_date` datetime DEFAULT NULL,
  `is_new` tinyint(2) NOT NULL DEFAULT '0',
  `priority` tinyint(4) NOT NULL DEFAULT '0',
  `note_current_status` enum('New','View','Finished') NOT NULL DEFAULT 'New',
  `attachment_count` int(8) NOT NULL DEFAULT '0',
  `khoshra_potro` int(8) NOT NULL DEFAULT '0',
  `khoshra_waiting_for_approval` int(8) NOT NULL DEFAULT '0',
  `approved_potro` int(8) NOT NULL DEFAULT '0',
  `nothivukto_potro` int(8) NOT NULL DEFAULT '0',
  `potrojari` int(8) NOT NULL DEFAULT '0',
  `onucched_count` int(8) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL,
  `created_by` bigint(20) DEFAULT '0',
  `modified_by` bigint(20) DEFAULT '0',
  `token` bigint(20) DEFAULT NULL,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL,
  `is_migrated` tinyint(4) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_note_onuccheds`
--

CREATE TABLE `nothi_note_onuccheds` (
  `id` bigint(20) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '1' COMMENT 'nothi notes table id',
  `office_id` int(11) NOT NULL,
  `office_unit_id` int(11) NOT NULL,
  `office_unit_organogram_id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  `office_name` varchar(255) DEFAULT NULL,
  `office_unit_name` varchar(255) DEFAULT NULL,
  `employee_name` varchar(255) DEFAULT NULL,
  `designation_name` varchar(255) DEFAULT NULL,
  `onucched_no` varchar(8) DEFAULT NULL,
  `onucched_sequence` int(11) NOT NULL DEFAULT '0',
  `subject` text,
  `note_description` longtext,
  `digital_sign` tinyint(2) NOT NULL DEFAULT '0',
  `sign_info` text,
  `description_bk` text,
  `encoded` tinyint(4) NOT NULL DEFAULT '0',
  `note_onucched_status` varchar(10) DEFAULT 'DRAFT',
  `is_potrojari` tinyint(4) NOT NULL DEFAULT '0',
  `potrojari` tinyint(4) NOT NULL DEFAULT '0',
  `potrojari_id` bigint(20) NOT NULL DEFAULT '0',
  `potrojari_status` varchar(20) DEFAULT NULL,
  `created` datetime NOT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` bigint(20) DEFAULT NULL,
  `modified_by` bigint(20) DEFAULT NULL,
  `token` bigint(20) DEFAULT NULL,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_note_onucched_refs`
--

CREATE TABLE `nothi_note_onucched_refs` (
  `id` bigint(20) NOT NULL,
  `nothi_master_id` int(11) NOT NULL,
  `nothi_note_id` int(11) NOT NULL,
  `note_onucched_id` varchar(20) NOT NULL,
  `guard_file_ids` varchar(255) DEFAULT NULL,
  `potro_ids` varchar(255) DEFAULT NULL,
  `flag_ids` varchar(255) DEFAULT NULL,
  `ref_onucched_ids` varchar(255) DEFAULT NULL COMMENT 'onucched ids',
  `ref_note_ids` varchar(255) DEFAULT NULL COMMENT 'all onucched in current nore',
  `ref_attachment_ids` varchar(255) DEFAULT NULL,
  `nothi_decision_ids` varchar(255) DEFAULT NULL,
  `created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` bigint(20) NOT NULL DEFAULT '0',
  `modified_by` bigint(20) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_note_permissions`
--

CREATE TABLE `nothi_note_permissions` (
  `id` bigint(20) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL,
  `nothi_office` int(11) DEFAULT '0',
  `office_id` int(11) NOT NULL,
  `office_unit_id` int(11) NOT NULL,
  `designation_id` int(11) NOT NULL,
  `nothi_office_name` varchar(255) NOT NULL DEFAULT ' ',
  `office` varchar(255) DEFAULT NULL,
  `office_unit` varchar(255) DEFAULT NULL,
  `designation` varchar(255) DEFAULT NULL,
  `designation_level` int(11) NOT NULL DEFAULT '0',
  `privilige_type` tinyint(1) NOT NULL DEFAULT '0',
  `visited` tinyint(2) NOT NULL DEFAULT '0',
  `last_visit_date` datetime DEFAULT NULL,
  `first_onucched_seqs` varchar(255) NOT NULL DEFAULT '',
  `last_onucched_seqs` varchar(255) NOT NULL DEFAULT '' COMMENT 'last onucched id before revoking permission',
  `created` datetime NOT NULL,
  `modified` datetime DEFAULT NULL,
  `created_by` int(11) NOT NULL,
  `modified_by` bigint(20) DEFAULT '0',
  `is_strict_route` tinyint(4) NOT NULL DEFAULT '0',
  `route_index` int(11) NOT NULL DEFAULT '0',
  `max_transaction_day` int(8) NOT NULL DEFAULT '0',
  `layer_index` int(8) NOT NULL DEFAULT '1',
  `is_signatory` tinyint(2) NOT NULL DEFAULT '1',
  `is_active` int(1) NOT NULL DEFAULT '1',
  `token` bigint(20) DEFAULT NULL,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_note_sheets`
--

CREATE TABLE `nothi_note_sheets` (
  `id` bigint(10) NOT NULL,
  `nothi_master_id` int(10) NOT NULL,
  `nothi_part_no` bigint(20) NOT NULL DEFAULT '1',
  `sheet_no` bigint(20) NOT NULL DEFAULT '1',
  `sheet_no_bn` varchar(20) NOT NULL DEFAULT '১'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_onucched_attachments`
--

CREATE TABLE `nothi_onucched_attachments` (
  `id` bigint(20) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '1',
  `note_onucched_id` bigint(20) NOT NULL,
  `attachment_type` varchar(255) NOT NULL,
  `file_name` varchar(255) NOT NULL,
  `user_file_name` varchar(255) DEFAULT NULL,
  `file_size_in_kb` double NOT NULL DEFAULT '0',
  `file_dir` varchar(255) NOT NULL,
  `digital_sign` tinyint(2) NOT NULL DEFAULT '0',
  `sign_info` longtext,
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `created` datetime DEFAULT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `token` bigint(20) DEFAULT NULL,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_onucched_signatures`
--

CREATE TABLE `nothi_onucched_signatures` (
  `id` bigint(20) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '1',
  `office_id` int(11) NOT NULL,
  `office_unit_id` int(11) NOT NULL,
  `office_unit_organogram_id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  `office_name` varchar(255) NOT NULL DEFAULT ' ',
  `office_unit_name` varchar(255) NOT NULL DEFAULT ' ',
  `designation_name` varchar(255) NOT NULL DEFAULT ' ',
  `employee_name` varchar(255) NOT NULL DEFAULT ' ',
  `employee_designation` varchar(255) DEFAULT NULL,
  `designation_level` int(11) NOT NULL DEFAULT '0',
  `sequence` int(11) NOT NULL DEFAULT '0',
  `note_onucched_id` bigint(20) NOT NULL DEFAULT '0',
  `note_onucched_decision` varchar(255) DEFAULT NULL,
  `is_signature` tinyint(1) NOT NULL DEFAULT '0',
  `cross_signature` tinyint(1) NOT NULL DEFAULT '0',
  `signature_date` datetime NOT NULL,
  `digital_sign` tinyint(4) DEFAULT '0',
  `user_signature_id` bigint(20) NOT NULL DEFAULT '0',
  `is_hidden_signature` tinyint(2) NOT NULL DEFAULT '1' COMMENT 'is user is not note signatory, then value = 2, otherwise 1',
  `can_delete` tinyint(2) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `created_by` bigint(20) DEFAULT NULL,
  `modified_by` bigint(20) DEFAULT NULL,
  `token` bigint(20) DEFAULT NULL,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_potrojari_attachment_refs`
--

CREATE TABLE `nothi_potrojari_attachment_refs` (
  `id` bigint(20) NOT NULL,
  `office_id` int(11) NOT NULL,
  `nothi_part_no` bigint(20) NOT NULL,
  `attachment_type` varchar(255) NOT NULL,
  `file_name` varchar(255) NOT NULL,
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_potros`
--

CREATE TABLE `nothi_potros` (
  `id` bigint(20) NOT NULL,
  `nothi_master_id` int(11) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '1',
  `note_onucched_id` int(11) NOT NULL DEFAULT '0',
  `dak_id` int(11) DEFAULT NULL,
  `dak_type` varchar(10) NOT NULL DEFAULT 'Daptorik',
  `is_copied_dak` tinyint(4) NOT NULL DEFAULT '1',
  `nothijato` tinyint(2) NOT NULL DEFAULT '0',
  `potrojari_id` bigint(20) DEFAULT '0',
  `potro_media` varchar(100) NOT NULL,
  `potro_pages` int(11) NOT NULL DEFAULT '0',
  `subject` text,
  `sarok_no` varchar(255) NOT NULL,
  `page_numbers` varchar(64) DEFAULT NULL,
  `due_date` datetime NOT NULL,
  `issue_date` datetime NOT NULL,
  `potro_content` longtext,
  `meta_data` varchar(1000) DEFAULT NULL,
  `is_deleted` tinyint(4) NOT NULL DEFAULT '0',
  `application_origin` varchar(50) DEFAULT 'nothi',
  `application_meta_data` text,
  `created` datetime NOT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `dak_json` text,
  `noter_potro_json` text,
  `note_json` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_potro_attachments`
--

CREATE TABLE `nothi_potro_attachments` (
  `id` bigint(20) NOT NULL,
  `nothi_master_id` int(11) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '1',
  `nothi_potro_id` bigint(20) NOT NULL,
  `nothijato` tinyint(2) NOT NULL DEFAULT '0',
  `is_main` int(11) NOT NULL DEFAULT '0',
  `nothi_potro_page` bigint(20) NOT NULL DEFAULT '1',
  `nothi_potro_page_bn` varchar(30) DEFAULT '১',
  `sarok_no` varchar(255) NOT NULL,
  `attachment_type` varchar(255) NOT NULL,
  `attachment_description` varchar(255) DEFAULT NULL,
  `file_name` varchar(255) NOT NULL,
  `user_file_name` varchar(255) DEFAULT NULL,
  `file_size_in_kb` double NOT NULL DEFAULT '0',
  `file_dir` varchar(255) DEFAULT NULL,
  `potro_cover` longtext,
  `content_body` longtext,
  `meta_data` varchar(1000) DEFAULT NULL,
  `potrojari` tinyint(4) NOT NULL DEFAULT '0',
  `potrojari_id` bigint(20) NOT NULL DEFAULT '0',
  `potrojari_status` varchar(20) DEFAULT NULL,
  `is_summary_nothi` tinyint(2) DEFAULT '0',
  `is_approved` tinyint(2) NOT NULL DEFAULT '0',
  `status` tinyint(2) NOT NULL DEFAULT '1',
  `application_origin` varchar(50) DEFAULT 'nothi',
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL,
  `token` bigint(20) DEFAULT NULL,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_register_lists`
--

CREATE TABLE `nothi_register_lists` (
  `id` bigint(20) NOT NULL,
  `nothi_master_id` int(11) NOT NULL,
  `nothi_part_no` int(11) DEFAULT NULL,
  `potrojari_id` bigint(20) DEFAULT NULL,
  `nothi_no` varchar(64) NOT NULL,
  `subject` text NOT NULL,
  `created_office_id` int(11) DEFAULT NULL,
  `created_unit_id` int(11) DEFAULT NULL,
  `created_designation_id` int(11) DEFAULT NULL,
  `sending_date` date DEFAULT NULL,
  `from_office_id` bigint(20) DEFAULT NULL,
  `from_office_name` varchar(200) DEFAULT NULL,
  `from_office_unit_id` int(11) DEFAULT NULL,
  `from_officer_name` varchar(200) DEFAULT NULL,
  `from_office_unit_name` varchar(500) DEFAULT NULL,
  `from_officer_designation_id` bigint(20) DEFAULT NULL,
  `from_officer_designation_label` varchar(500) DEFAULT NULL,
  `to_office_id` bigint(20) DEFAULT NULL,
  `to_office_name` varchar(200) DEFAULT NULL,
  `to_office_unit_id` bigint(20) DEFAULT NULL,
  `to_office_unit_name` varchar(500) DEFAULT NULL,
  `to_officer_id` bigint(20) DEFAULT NULL,
  `to_officer_name` varchar(200) DEFAULT NULL,
  `to_officer_designation_id` bigint(20) DEFAULT NULL,
  `to_officer_designation_label` varchar(500) DEFAULT NULL,
  `nothi_created_date` date NOT NULL,
  `nothi_class` tinyint(9) NOT NULL,
  `movement_type` varchar(50) NOT NULL,
  `nothi_type_id` int(11) NOT NULL,
  `nothi_modified` date DEFAULT NULL,
  `is_finished` tinyint(1) DEFAULT NULL,
  `is_archived` tinyint(1) DEFAULT NULL,
  `created` timestamp NULL DEFAULT NULL,
  `modified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='entry all nothi movements in this table';

-- --------------------------------------------------------

--
-- Table structure for table `nothi_running_processes`
--

CREATE TABLE `nothi_running_processes` (
  `id` int(11) NOT NULL,
  `designation_id` int(11) NOT NULL,
  `module` varchar(64) NOT NULL,
  `process_name` varchar(255) NOT NULL,
  `identification_key` text NOT NULL,
  `json_data` longtext NOT NULL,
  `process_display_data` text NOT NULL,
  `status` enum('Running','Completed','Failed') NOT NULL DEFAULT 'Running',
  `reason` text COMMENT 'Failed reason',
  `created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_types`
--

CREATE TABLE `nothi_types` (
  `id` int(4) NOT NULL,
  `type_name` varchar(240) NOT NULL,
  `type_code` char(2) NOT NULL DEFAULT '০০',
  `type_last_number` bigint(20) DEFAULT '0',
  `office_id` int(11) DEFAULT '0',
  `office_unit_id` int(11) NOT NULL DEFAULT '0',
  `is_deleted` tinyint(1) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `notifications`
--

CREATE TABLE `notifications` (
  `id` bigint(20) NOT NULL,
  `event_id` int(12) NOT NULL,
  `employee_id` int(16) NOT NULL,
  `officee_id` int(12) NOT NULL,
  `status` tinyint(4) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `notification_events`
--

CREATE TABLE `notification_events` (
  `id` int(11) NOT NULL,
  `event_name_bng` varchar(255) NOT NULL,
  `event_name_eng` varchar(255) NOT NULL,
  `notification_type` varchar(100) DEFAULT NULL,
  `template_id` int(11) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `notification_messages`
--

CREATE TABLE `notification_messages` (
  `id` int(100) NOT NULL,
  `event_id` int(11) DEFAULT NULL,
  `event_type` varchar(50) DEFAULT NULL,
  `title_eng` varchar(255) DEFAULT NULL,
  `title_bng` varchar(255) DEFAULT NULL,
  `message_eng` text,
  `message_bng` text NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL,
  `from_user_id` int(20) NOT NULL,
  `to_user_id` int(20) NOT NULL,
  `from_office_id` int(11) NOT NULL,
  `to_office_id` int(11) NOT NULL,
  `media` varchar(50) NOT NULL,
  `system` tinyint(2) NOT NULL DEFAULT '0',
  `email` tinyint(2) NOT NULL DEFAULT '0',
  `sms` tinyint(2) NOT NULL DEFAULT '0',
  `mobile_app` tinyint(1) NOT NULL DEFAULT '1',
  `is_notified` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `notification_settings`
--

CREATE TABLE `notification_settings` (
  `id` bigint(20) NOT NULL,
  `event_id` bigint(20) NOT NULL,
  `employee_id` bigint(20) NOT NULL,
  `office_id` bigint(20) NOT NULL,
  `system` tinyint(2) NOT NULL DEFAULT '1',
  `email` tinyint(2) NOT NULL DEFAULT '1',
  `sms` tinyint(2) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `notification_templates`
--

CREATE TABLE `notification_templates` (
  `id` int(11) NOT NULL,
  `title_eng` varchar(255) CHARACTER SET latin1 NOT NULL,
  `title_bng` varchar(255) CHARACTER SET latin1 NOT NULL,
  `status` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `notification_template_messages`
--

CREATE TABLE `notification_template_messages` (
  `id` int(11) NOT NULL,
  `title_eng` varchar(255) NOT NULL,
  `title_bng` varchar(255) NOT NULL,
  `template_id` int(11) NOT NULL,
  `media` varchar(100) NOT NULL,
  `template_message_bng` text NOT NULL,
  `template_message_eng` text NOT NULL,
  `status` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `office_designation_seals`
--

CREATE TABLE `office_designation_seals` (
  `id` int(11) NOT NULL,
  `designation_name_bng` varchar(256) NOT NULL,
  `designation_name_eng` varchar(256) NOT NULL,
  `office_id` int(11) NOT NULL,
  `office_unit_organogram_id` int(11) NOT NULL,
  `office_unit_id` int(11) NOT NULL,
  `unit_name_bng` varchar(255) NOT NULL,
  `unit_name_eng` varchar(255) NOT NULL,
  `office_name_bng` varchar(255) DEFAULT NULL,
  `office_name_eng` varchar(255) DEFAULT NULL,
  `seal_owner_unit_id` int(11) NOT NULL,
  `seal_owner_designation_id` bigint(20) NOT NULL,
  `designation_seq` int(11) NOT NULL DEFAULT '0',
  `designation_level` int(11) NOT NULL DEFAULT '0',
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL,
  `token` bigint(20) DEFAULT NULL,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `office_unit_seals`
--

CREATE TABLE `office_unit_seals` (
  `id` int(11) NOT NULL,
  `designation_name_bng` varchar(256) NOT NULL,
  `designation_name_eng` varchar(256) NOT NULL,
  `office_id` int(11) NOT NULL,
  `office_unit_organogram_id` int(11) NOT NULL,
  `office_unit_id` int(11) NOT NULL,
  `unit_name_bng` varchar(255) NOT NULL,
  `unit_name_eng` varchar(255) NOT NULL,
  `office_name_bng` varchar(255) DEFAULT NULL,
  `office_name_eng` varchar(255) DEFAULT NULL,
  `seal_owner_unit_id` int(11) NOT NULL,
  `designation_seq` int(11) NOT NULL DEFAULT '0',
  `designation_level` int(11) NOT NULL DEFAULT '0',
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `old_dak_filter`
--

CREATE TABLE `old_dak_filter` (
  `id` int(11) NOT NULL,
  `office_id` int(11) NOT NULL,
  `status` tinyint(2) NOT NULL,
  `total` int(11) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `one_time_passwords`
--

CREATE TABLE `one_time_passwords` (
  `id` int(11) NOT NULL,
  `employee_record_id` int(11) NOT NULL,
  `otp` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `other_office_nothi_master_movements`
--

CREATE TABLE `other_office_nothi_master_movements` (
  `id` bigint(20) NOT NULL,
  `nothi_no` varchar(64) DEFAULT NULL,
  `subject` varchar(255) DEFAULT NULL,
  `nothi_shakha` varchar(255) DEFAULT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '0',
  `nothi_office` int(11) NOT NULL DEFAULT '0',
  `from_office_id` int(11) DEFAULT NULL,
  `from_office_name` varchar(255) DEFAULT NULL,
  `from_office_unit_id` int(11) NOT NULL,
  `from_office_unit_name` varchar(255) NOT NULL,
  `from_officer_id` int(11) DEFAULT NULL,
  `from_officer_name` varchar(255) DEFAULT NULL,
  `from_officer_designation_id` int(11) NOT NULL,
  `from_officer_designation_label` varchar(255) DEFAULT NULL,
  `to_office_id` int(11) NOT NULL,
  `to_office_name` varchar(255) DEFAULT NULL,
  `to_office_unit_id` int(11) NOT NULL,
  `to_office_unit_name` varchar(255) NOT NULL,
  `to_officer_id` int(11) NOT NULL,
  `to_officer_name` varchar(255) DEFAULT NULL,
  `to_officer_designation_id` int(11) NOT NULL,
  `to_officer_designation_label` varchar(255) DEFAULT NULL,
  `view_status` tinyint(4) NOT NULL DEFAULT '0',
  `priority` tinyint(4) NOT NULL DEFAULT '0',
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL,
  `token` text,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `other_organogram_activities_settings`
--

CREATE TABLE `other_organogram_activities_settings` (
  `id` int(11) NOT NULL,
  `organogram_id` int(11) NOT NULL,
  `assigned_organogram_id` int(11) NOT NULL,
  `assigned_date` datetime DEFAULT NULL,
  `unassigned_date` datetime DEFAULT NULL,
  `permission_for` int(1) NOT NULL COMMENT '0 for all - 1 for dak - 2 for nothi',
  `status` int(1) NOT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `performance_designations`
--

CREATE TABLE `performance_designations` (
  `id` int(11) NOT NULL,
  `designation_id` int(11) NOT NULL,
  `unit_id` int(11) DEFAULT NULL,
  `office_id` int(11) DEFAULT NULL,
  `ministry_id` int(11) DEFAULT NULL,
  `layer_id` int(11) DEFAULT NULL,
  `origin_id` int(11) DEFAULT NULL,
  `ministry_name` varchar(200) DEFAULT NULL,
  `layer_name` varchar(200) DEFAULT NULL,
  `origin_name` varchar(200) DEFAULT NULL,
  `office_name` varchar(200) DEFAULT NULL,
  `unit_name` varchar(200) DEFAULT NULL,
  `designation_name` varchar(200) DEFAULT NULL,
  `inbox` int(11) NOT NULL,
  `outbox` int(11) NOT NULL,
  `nothijat` int(11) NOT NULL,
  `nothivukto` int(11) NOT NULL,
  `nisponnodak` int(11) NOT NULL,
  `onisponnodak` int(11) NOT NULL,
  `selfnote` int(11) NOT NULL,
  `daksohonote` int(11) NOT NULL,
  `nisponnopotrojari` int(11) NOT NULL,
  `nisponnonote` int(11) NOT NULL,
  `onisponnonote` int(11) NOT NULL,
  `potrojari` int(11) NOT NULL DEFAULT '0',
  `status` tinyint(2) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL,
  `record_date` date NOT NULL,
  `updated` tinyint(4) NOT NULL DEFAULT '0',
  `dak_srijito_note_nisponno` int(11) NOT NULL DEFAULT '0',
  `self_srijito_note_nisponno` int(11) NOT NULL DEFAULT '0',
  `potrojari_nisponno_internal_own` int(11) NOT NULL DEFAULT '0',
  `potrojari_nisponno_internal_other` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `performance_offices`
--

CREATE TABLE `performance_offices` (
  `id` int(11) NOT NULL,
  `office_id` int(11) NOT NULL,
  `ministry_id` int(11) DEFAULT NULL,
  `layer_id` int(11) DEFAULT NULL,
  `origin_id` int(11) DEFAULT NULL,
  `ministry_name` varchar(200) DEFAULT NULL,
  `layer_name` varchar(200) DEFAULT NULL,
  `origin_name` varchar(200) DEFAULT NULL,
  `office_name` varchar(200) DEFAULT NULL,
  `inbox` int(11) NOT NULL,
  `outbox` int(11) NOT NULL,
  `nothijat` int(11) NOT NULL,
  `nothivukto` int(11) NOT NULL,
  `online_dak` int(11) DEFAULT NULL,
  `uploaded_dak` int(11) DEFAULT NULL,
  `nisponnodak` int(11) NOT NULL,
  `onisponnodak` int(11) NOT NULL,
  `selfnote` int(11) NOT NULL,
  `daksohonote` int(11) NOT NULL,
  `nisponnopotrojari` int(11) NOT NULL,
  `nisponnonote` int(11) NOT NULL,
  `onisponnonote` int(11) NOT NULL,
  `potrojari` int(11) NOT NULL DEFAULT '0',
  `potrojari_nisponno_internal` int(11) NOT NULL DEFAULT '0',
  `potrojari_nisponno_external` int(11) NOT NULL DEFAULT '0',
  `unassigned_pending_dak` int(11) NOT NULL DEFAULT '0',
  `unassigned_pending_note` int(11) NOT NULL DEFAULT '0',
  `unassigned_designation` int(11) NOT NULL DEFAULT '0',
  `status` tinyint(4) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL,
  `record_date` date NOT NULL,
  `updated` tinyint(4) NOT NULL DEFAULT '0',
  `dak_srijito_note_nisponno` int(11) NOT NULL DEFAULT '0',
  `self_srijito_note_nisponno` int(11) NOT NULL DEFAULT '0',
  `potrojari_nisponno_internal_own` int(11) NOT NULL DEFAULT '0',
  `potrojari_nisponno_internal_other` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `portal_publishes`
--

CREATE TABLE `portal_publishes` (
  `id` bigint(20) NOT NULL,
  `potrojari_id` bigint(20) NOT NULL,
  `publish_type` varchar(50) NOT NULL,
  `publish_type_category` varchar(255) DEFAULT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_office` text NOT NULL,
  `nothi_part_id` bigint(20) NOT NULL,
  `subject` text NOT NULL,
  `description` text NOT NULL,
  `domain` varchar(255) NOT NULL,
  `archive_date` date NOT NULL,
  `potrojari_date` date NOT NULL,
  `file_path` text NOT NULL,
  `unique_id` varchar(255) DEFAULT NULL,
  `portal_returned_id` varchar(255) DEFAULT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL,
  `created_by` bigint(20) NOT NULL DEFAULT '0',
  `modified_by` bigint(20) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `potrojari`
--

CREATE TABLE `potrojari` (
  `id` bigint(20) NOT NULL,
  `potro_type` int(11) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '1',
  `note_onucched_id` bigint(20) NOT NULL,
  `nothi_potro_attachment_id` bigint(20) NOT NULL,
  `nothi_potro_id` bigint(20) NOT NULL DEFAULT '0',
  `dak_id` bigint(20) NOT NULL DEFAULT '0',
  `attached_potro` longtext,
  `sarok_no` varchar(255) DEFAULT NULL,
  `potrojari_date` date DEFAULT NULL,
  `potro_subject` text NOT NULL,
  `potro_security_level` varchar(64) NOT NULL,
  `potro_priority_level` varchar(64) NOT NULL,
  `potro_cover` longtext CHARACTER SET utf16,
  `potro_description` longtext,
  `meta_data` varchar(1000) DEFAULT NULL,
  `potro_status` varchar(64) NOT NULL DEFAULT 'Draft',
  `receiver_sent` tinyint(1) NOT NULL DEFAULT '0',
  `onulipi_sent` tinyint(1) NOT NULL DEFAULT '0',
  `is_summary_nothi` tinyint(2) NOT NULL DEFAULT '0',
  `digital_sign` tinyint(2) NOT NULL DEFAULT '0',
  `sign_info` text,
  `cloned_potrojari_id` int(11) DEFAULT NULL,
  `potrojari_internal` tinyint(2) NOT NULL DEFAULT '0',
  `potrojari_language` varchar(5) NOT NULL DEFAULT 'bn',
  `draft_office_id` int(11) NOT NULL DEFAULT '0',
  `draft_office_name` varchar(255) DEFAULT NULL,
  `draft_unit_id` int(11) NOT NULL DEFAULT '0',
  `draft_unit_name` varchar(255) DEFAULT NULL,
  `draft_designation_id` bigint(20) NOT NULL DEFAULT '0',
  `draft_designation_name` varchar(255) DEFAULT NULL,
  `draft_officer_id` int(11) NOT NULL DEFAULT '0',
  `draft_officer_name` varchar(255) DEFAULT NULL,
  `shared_nothi_id` int(11) NOT NULL DEFAULT '0',
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `noter_potro_json` text,
  `note_json` text,
  `attachment_count` int(4) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `token` bigint(20) DEFAULT NULL,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `potrojari_attachments`
--

CREATE TABLE `potrojari_attachments` (
  `id` bigint(20) NOT NULL,
  `potrojari_type` varchar(255) NOT NULL,
  `potrojari_id` bigint(20) NOT NULL,
  `attachment_type` varchar(255) NOT NULL,
  `attachment_description` varchar(255) NOT NULL,
  `attachment_name` varchar(255) DEFAULT NULL,
  `content_cover` longtext,
  `content_body` longtext,
  `meta_data` varchar(1000) DEFAULT NULL,
  `is_summary_nothi` tinyint(2) DEFAULT '0',
  `is_inline` tinyint(2) NOT NULL DEFAULT '0',
  `potro_id` bigint(20) DEFAULT NULL,
  `nothi_potro_attachment_id` int(11) NOT NULL DEFAULT '0',
  `nothi_potro_id` int(11) NOT NULL DEFAULT '0',
  `file_name` varchar(255) NOT NULL,
  `user_file_name` varchar(255) DEFAULT NULL,
  `file_dir` varchar(255) NOT NULL,
  `file_size_in_kb` double NOT NULL DEFAULT '0',
  `digital_sign` tinyint(2) NOT NULL DEFAULT '0',
  `sign_info` text,
  `options` text,
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `created` datetime DEFAULT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `token` bigint(20) DEFAULT NULL,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `potrojari_error_logs`
--

CREATE TABLE `potrojari_error_logs` (
  `id` int(11) NOT NULL,
  `potrojari_id` int(11) DEFAULT NULL,
  `nothi_office` int(11) DEFAULT NULL,
  `nothi_part_no` int(11) DEFAULT NULL,
  `error_message` text NOT NULL,
  `error_code` varchar(16) NOT NULL,
  `is_action_taken` int(11) NOT NULL DEFAULT '0',
  `action_date` datetime DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `potrojari_recipient_onulipis`
--

CREATE TABLE `potrojari_recipient_onulipis` (
  `id` bigint(20) NOT NULL,
  `potrojari_id` bigint(20) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '1',
  `note_onucched_id` bigint(20) NOT NULL,
  `nothi_potro_id` bigint(20) NOT NULL,
  `potro_type` int(11) NOT NULL,
  `dak_id` bigint(20) NOT NULL DEFAULT '0',
  `officer_mobile` varchar(150) DEFAULT NULL,
  `sms_message` varchar(250) DEFAULT NULL,
  `group_id` bigint(20) DEFAULT '0',
  `group_name` varchar(250) DEFAULT NULL,
  `group_member` int(11) NOT NULL DEFAULT '1',
  `group_display` varchar(64) NOT NULL DEFAULT '',
  `office_id` int(11) DEFAULT NULL,
  `office` varchar(200) DEFAULT NULL,
  `office_unit_id` int(11) DEFAULT NULL,
  `office_unit` varchar(255) DEFAULT NULL,
  `officer_id` int(11) DEFAULT NULL,
  `designation_id` int(11) DEFAULT NULL,
  `designation` varchar(255) DEFAULT NULL,
  `officer_name` varchar(255) DEFAULT NULL,
  `officer_email` varchar(150) DEFAULT NULL,
  `visibleName` varchar(500) DEFAULT NULL,
  `office_head` tinyint(5) NOT NULL DEFAULT '0',
  `options` text,
  `run_task` tinyint(2) NOT NULL DEFAULT '0',
  `retry_count` int(11) NOT NULL DEFAULT '0',
  `task_response` varchar(255) DEFAULT NULL,
  `potro_status` varchar(255) NOT NULL,
  `is_sent` tinyint(2) NOT NULL DEFAULT '0',
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `created` datetime NOT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `potrojari_recipient_others`
--

CREATE TABLE `potrojari_recipient_others` (
  `id` bigint(20) NOT NULL,
  `potrojari_id` bigint(20) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '1',
  `note_onucched_id` bigint(20) NOT NULL,
  `nothi_potro_id` bigint(20) NOT NULL,
  `potro_type` int(11) NOT NULL,
  `dak_id` bigint(20) NOT NULL DEFAULT '0',
  `recipient_type` varchar(100) DEFAULT NULL,
  `office_id` int(11) DEFAULT NULL,
  `office_name` varchar(200) DEFAULT NULL,
  `office_unit_id` int(11) DEFAULT NULL,
  `office_unit_name` varchar(255) DEFAULT NULL,
  `officer_id` int(11) DEFAULT NULL,
  `officer_name` varchar(255) DEFAULT NULL,
  `officer_email` varchar(150) DEFAULT NULL,
  `officer_designation_id` int(11) DEFAULT NULL,
  `officer_designation_label` varchar(255) DEFAULT NULL,
  `visible_name` varchar(500) DEFAULT NULL,
  `visible_designation` varchar(500) DEFAULT NULL,
  `potro_status` varchar(255) NOT NULL,
  `is_sent` tinyint(2) NOT NULL DEFAULT '0',
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `created` datetime NOT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `potrojari_recipient_receivers`
--

CREATE TABLE `potrojari_recipient_receivers` (
  `id` bigint(20) NOT NULL,
  `potrojari_id` bigint(20) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '1',
  `note_onucched_id` bigint(20) NOT NULL,
  `nothi_potro_id` bigint(20) NOT NULL,
  `potro_type` int(11) NOT NULL,
  `dak_id` bigint(20) NOT NULL DEFAULT '0',
  `officer_mobile` varchar(150) DEFAULT NULL,
  `sms_message` varchar(250) DEFAULT NULL,
  `group_id` bigint(20) DEFAULT '0',
  `group_name` varchar(250) DEFAULT NULL,
  `group_member` int(11) NOT NULL DEFAULT '1',
  `group_display` varchar(64) NOT NULL DEFAULT '',
  `office_id` int(11) DEFAULT NULL,
  `office` varchar(200) DEFAULT NULL,
  `office_unit_id` int(11) DEFAULT NULL,
  `office_unit` varchar(255) DEFAULT NULL,
  `officer_id` int(11) DEFAULT NULL,
  `designation_id` int(11) DEFAULT NULL,
  `designation` varchar(255) DEFAULT NULL,
  `officer_name` varchar(255) DEFAULT NULL,
  `officer_email` varchar(150) DEFAULT NULL,
  `visibleName` varchar(500) DEFAULT NULL,
  `office_head` tinyint(5) NOT NULL DEFAULT '0',
  `options` text,
  `run_task` tinyint(2) NOT NULL DEFAULT '0',
  `retry_count` int(11) NOT NULL DEFAULT '0',
  `task_response` varchar(255) DEFAULT NULL,
  `potro_status` varchar(255) NOT NULL,
  `is_sent` tinyint(2) NOT NULL DEFAULT '0',
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `created` datetime NOT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `potrojari_registers`
--

CREATE TABLE `potrojari_registers` (
  `id` bigint(20) NOT NULL,
  `potrojari_id` bigint(20) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_part_no` bigint(20) NOT NULL DEFAULT '1',
  `nothi_notes_id` bigint(20) DEFAULT NULL,
  `nothi_potro_id` bigint(20) DEFAULT NULL,
  `potro_type` int(11) NOT NULL,
  `dak_id` bigint(20) DEFAULT NULL,
  `dak_type` varchar(35) NOT NULL,
  `dak_receive_no` varchar(250) DEFAULT NULL,
  `potrojari_sharok_no` varchar(200) DEFAULT NULL,
  `potrojari_date` datetime NOT NULL,
  `potrojari_subject` varchar(350) NOT NULL,
  `sender_office_id` int(11) DEFAULT NULL,
  `sender_officer_id` int(11) DEFAULT NULL,
  `sender_office_name` varchar(200) NOT NULL,
  `sender_officer_name` varchar(200) NOT NULL,
  `sender_officer_designation_id` int(11) NOT NULL,
  `sender_officer_designation_name` varchar(200) NOT NULL,
  `sender_office_unit_id` int(11) NOT NULL,
  `sender_unit_name` varchar(200) NOT NULL,
  `approval_office_id` int(11) NOT NULL,
  `approval_office_name` varchar(200) NOT NULL,
  `approval_officer_id` int(11) NOT NULL,
  `approval_officer_name` varchar(200) NOT NULL,
  `approval_designation_id` int(11) NOT NULL,
  `approval_designation_name` varchar(200) NOT NULL,
  `approval_unit_id` int(11) NOT NULL,
  `approval_unit_name` varchar(200) NOT NULL,
  `onulipi_info` text,
  `receiver_info` text,
  `security_level` varchar(35) NOT NULL DEFAULT '0',
  `priority_level` varchar(35) DEFAULT NULL,
  `potro_status` varchar(255) NOT NULL,
  `is_sent` tinyint(2) NOT NULL DEFAULT '0',
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `created` datetime NOT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `potrojari_versions`
--

CREATE TABLE `potrojari_versions` (
  `id` bigint(20) NOT NULL,
  `potrojari_id` bigint(20) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_part_no` bigint(20) NOT NULL DEFAULT '1',
  `updated_cover` longtext,
  `updated_content` longtext CHARACTER SET utf8,
  `office_id` bigint(20) NOT NULL,
  `officer_id` bigint(20) NOT NULL,
  `officer_name` varchar(250) CHARACTER SET utf8 DEFAULT NULL,
  `officer_unit_id` bigint(20) NOT NULL,
  `office_organogram_id` bigint(20) NOT NULL,
  `designation_label` varchar(250) CHARACTER SET utf8 NOT NULL,
  `created` datetime NOT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `token` bigint(20) DEFAULT NULL,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `potro_flags`
--

CREATE TABLE `potro_flags` (
  `id` int(11) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_note_id` bigint(20) NOT NULL DEFAULT '1',
  `office_id` bigint(20) NOT NULL,
  `office_unit_id` bigint(20) NOT NULL,
  `office_organogram_id` bigint(20) NOT NULL,
  `office_name` varchar(255) NOT NULL DEFAULT ' ',
  `office_unit_name` varchar(255) NOT NULL DEFAULT ' ',
  `designation_name` varchar(255) NOT NULL DEFAULT '',
  `color` varchar(25) NOT NULL,
  `title` varchar(50) CHARACTER SET utf8 NOT NULL,
  `potro_attachment_id` bigint(20) NOT NULL,
  `page_no` int(11) DEFAULT '0',
  `created` timestamp NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `protikolpo_log`
--

CREATE TABLE `protikolpo_log` (
  `id` int(11) NOT NULL,
  `protikolpo_id` int(11) NOT NULL,
  `protikolpo_start_date` datetime NOT NULL,
  `protikolpo_end_date` datetime DEFAULT NULL,
  `protikolpo_ended_by` int(11) DEFAULT NULL,
  `employee_office_id_from_name` varchar(255) DEFAULT NULL,
  `employee_office_id_to_name` varchar(255) DEFAULT NULL,
  `protikolpo_status` tinyint(5) NOT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `protikolpo_settings`
--

CREATE TABLE `protikolpo_settings` (
  `id` int(11) NOT NULL,
  `office_id` int(11) NOT NULL,
  `unit_id` int(11) NOT NULL,
  `designation_id` bigint(20) NOT NULL,
  `employee_record_id` bigint(20) DEFAULT NULL,
  `employee_name` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `protikolpos` text CHARACTER SET utf8 NOT NULL,
  `selected_protikolpo` int(11) NOT NULL,
  `start_date` date DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  `is_show_acting` int(11) DEFAULT NULL,
  `acting_level` varchar(64) CHARACTER SET utf8 DEFAULT NULL,
  `active_status` tinyint(4) NOT NULL DEFAULT '0',
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `shared_nothis`
--

CREATE TABLE `shared_nothis` (
  `id` bigint(20) NOT NULL,
  `nothi_id` int(11) NOT NULL DEFAULT '0',
  `note_id` int(11) NOT NULL DEFAULT '0',
  `onucched_id` int(11) NOT NULL DEFAULT '0',
  `potrojari_id` int(11) NOT NULL DEFAULT '0',
  `shared_status` varchar(32) NOT NULL,
  `original_content` longtext NOT NULL,
  `edited_content` longtext NOT NULL,
  `shared_by_designation_id` int(11) NOT NULL DEFAULT '0',
  `shared_by_office_id` int(11) NOT NULL DEFAULT '0',
  `shared_by_designation_detail` json NOT NULL,
  `committed_by_designation_id` int(11) NOT NULL DEFAULT '0',
  `committed_by_office_id` int(11) NOT NULL DEFAULT '0',
  `committed_by_designation_detail` json NOT NULL,
  `created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `nothi_detail` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `shared_nothi_users`
--

CREATE TABLE `shared_nothi_users` (
  `id` bigint(20) NOT NULL,
  `shared_nothi_id` bigint(20) NOT NULL DEFAULT '0',
  `designation_id` int(11) NOT NULL DEFAULT '0',
  `office_id` int(11) NOT NULL DEFAULT '0',
  `designation_detail` json NOT NULL,
  `shared_status` varchar(32) NOT NULL,
  `review_mode` varchar(32) NOT NULL,
  `shared_by_office_id` int(11) DEFAULT '0',
  `shared_by_designation_id` int(11) NOT NULL DEFAULT '0',
  `shared_by_designation_detail` json NOT NULL,
  `created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `summary_nothi_users`
--

CREATE TABLE `summary_nothi_users` (
  `id` int(11) NOT NULL,
  `nothi_master_id` bigint(20) NOT NULL,
  `nothi_part_no` bigint(20) NOT NULL DEFAULT '1',
  `potrojari_id` bigint(20) NOT NULL,
  `designation_id` bigint(20) DEFAULT '0',
  `employee_record_id` bigint(20) NOT NULL,
  `position_number` varchar(50) NOT NULL,
  `can_approve` tinyint(2) NOT NULL,
  `is_approve` tinytext NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `unit_update_history`
--

CREATE TABLE `unit_update_history` (
  `id` int(11) NOT NULL,
  `office_id` int(11) NOT NULL,
  `office_unit_id` int(11) NOT NULL,
  `office_origin_unit_id` int(11) DEFAULT NULL,
  `parent_unit_id` int(11) DEFAULT NULL,
  `old_unit_eng` varchar(255) DEFAULT NULL,
  `old_unit_bng` varchar(255) NOT NULL,
  `unit_eng` varchar(255) DEFAULT NULL,
  `unit_bng` varchar(255) NOT NULL,
  `employee_office_id` int(11) NOT NULL,
  `employee_unit_id` int(11) NOT NULL,
  `employee_designation_id` int(11) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL,
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `api_nothi_part_flag`
--
ALTER TABLE `api_nothi_part_flag`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `daak_personal_folders`
--
ALTER TABLE `daak_personal_folders`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `dak_actions_mig`
--
ALTER TABLE `dak_actions_mig`
  ADD PRIMARY KEY (`id`),
  ADD KEY `creator` (`creator`);

--
-- Indexes for table `dak_action_employees`
--
ALTER TABLE `dak_action_employees`
  ADD PRIMARY KEY (`id`),
  ADD KEY `employee_id` (`employee_id`);

--
-- Indexes for table `dak_attachments`
--
ALTER TABLE `dak_attachments`
  ADD PRIMARY KEY (`id`),
  ADD KEY `dak_type` (`dak_type`,`dak_id`),
  ADD KEY `attachment_type` (`attachment_type`);

--
-- Indexes for table `dak_attachment_comment`
--
ALTER TABLE `dak_attachment_comment`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `dak_childs`
--
ALTER TABLE `dak_childs`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `dak_custom_labels`
--
ALTER TABLE `dak_custom_labels`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `dak_daptoriks`
--
ALTER TABLE `dak_daptoriks`
  ADD PRIMARY KEY (`id`),
  ADD KEY `sender_office_id` (`sender_office_id`),
  ADD KEY `receiving_officer_designation_id` (`receiving_officer_designation_id`),
  ADD KEY `sender_officer_designation_id` (`sender_officer_designation_id`),
  ADD KEY `uploader_designation_id` (`uploader_designation_id`),
  ADD KEY `receiving_office_id` (`receiving_office_id`);

--
-- Indexes for table `dak_master_movements`
--
ALTER TABLE `dak_master_movements`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `dak_master_movement_users`
--
ALTER TABLE `dak_master_movement_users`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `dak_movements`
--
ALTER TABLE `dak_movements`
  ADD PRIMARY KEY (`id`),
  ADD KEY `dak_type` (`dak_type`,`dak_id`),
  ADD KEY `operation_type` (`operation_type`),
  ADD KEY `to_office_unit_id` (`to_office_unit_id`),
  ADD KEY `attention_type` (`attention_type`),
  ADD KEY `to_officer_designation_id` (`to_officer_designation_id`),
  ADD KEY `from_officer_designation_id` (`from_officer_designation_id`);

--
-- Indexes for table `dak_nagoriks`
--
ALTER TABLE `dak_nagoriks`
  ADD PRIMARY KEY (`id`),
  ADD KEY `receiving_officer_designation_id` (`receiving_officer_designation_id`),
  ADD KEY `receiving_office_id` (`receiving_office_id`);

--
-- Indexes for table `dak_register`
--
ALTER TABLE `dak_register`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `dak_sorting_permissions`
--
ALTER TABLE `dak_sorting_permissions`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `dak_third_table`
--
ALTER TABLE `dak_third_table`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `dak_users`
--
ALTER TABLE `dak_users`
  ADD PRIMARY KEY (`id`),
  ADD KEY `dak_type` (`dak_type`,`dak_id`),
  ADD KEY `to_officer_designation_id` (`to_officer_designation_id`),
  ADD KEY `dak_category` (`dak_category`),
  ADD KEY `attention_type` (`attention_type`);

--
-- Indexes for table `dak_user_actions`
--
ALTER TABLE `dak_user_actions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `dak_user_id` (`dak_user_id`);

--
-- Indexes for table `ds_user_info`
--
ALTER TABLE `ds_user_info`
  ADD PRIMARY KEY (`id`),
  ADD KEY `username` (`username`),
  ADD KEY `employee_record_id` (`employee_record_id`);

--
-- Indexes for table `guard_files`
--
ALTER TABLE `guard_files`
  ADD PRIMARY KEY (`id`),
  ADD KEY `office_id` (`office_id`);

--
-- Indexes for table `guard_file_api_datas`
--
ALTER TABLE `guard_file_api_datas`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `guard_file_attachments`
--
ALTER TABLE `guard_file_attachments`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `guard_file_categories`
--
ALTER TABLE `guard_file_categories`
  ADD PRIMARY KEY (`id`),
  ADD KEY `office_id` (`office_id`);

--
-- Indexes for table `honor_boards`
--
ALTER TABLE `honor_boards`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `messages`
--
ALTER TABLE `messages`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `message_views`
--
ALTER TABLE `message_views`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `nisponno_records`
--
ALTER TABLE `nisponno_records`
  ADD PRIMARY KEY (`id`),
  ADD KEY `office_id` (`office_id`),
  ADD KEY `unit_id` (`unit_id`),
  ADD KEY `designation_id` (`designation_id`),
  ADD KEY `nothi_part_no` (`nothi_part_no`);

--
-- Indexes for table `note_flags`
--
ALTER TABLE `note_flags`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `note_initiator`
--
ALTER TABLE `note_initiator`
  ADD PRIMARY KEY (`id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`),
  ADD KEY `office_units_organogram_id` (`designation_id`);

--
-- Indexes for table `nothivukto_nothis`
--
ALTER TABLE `nothivukto_nothis`
  ADD PRIMARY KEY (`id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`);

--
-- Indexes for table `nothivukto_nothis_merge_table`
--
ALTER TABLE `nothivukto_nothis_merge_table`
  ADD PRIMARY KEY (`id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`);

--
-- Indexes for table `nothi_archive_requests`
--
ALTER TABLE `nothi_archive_requests`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `nothi_data_change_history`
--
ALTER TABLE `nothi_data_change_history`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `nothi_decisions_mig`
--
ALTER TABLE `nothi_decisions_mig`
  ADD PRIMARY KEY (`id`),
  ADD KEY `creator` (`creator`);

--
-- Indexes for table `nothi_decision_employees`
--
ALTER TABLE `nothi_decision_employees`
  ADD PRIMARY KEY (`id`),
  ADD KEY `employee_id` (`employee_id`);

--
-- Indexes for table `nothi_masters`
--
ALTER TABLE `nothi_masters`
  ADD PRIMARY KEY (`id`),
  ADD KEY `office_id` (`office_id`),
  ADD KEY `nothi_no` (`nothi_no`);

--
-- Indexes for table `nothi_master_movements`
--
ALTER TABLE `nothi_master_movements`
  ADD PRIMARY KEY (`id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`),
  ADD KEY `from_office_id` (`from_office_id`),
  ADD KEY `to_office_id` (`to_office_id`),
  ADD KEY `to_officer_designation_id` (`to_officer_designation_id`),
  ADD KEY `from_officer_designation_id` (`from_officer_designation_id`),
  ADD KEY `nothi_office` (`nothi_office`),
  ADD KEY `view_status` (`view_status`);

--
-- Indexes for table `nothi_master_permissions`
--
ALTER TABLE `nothi_master_permissions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `office_id` (`office_id`),
  ADD KEY `nothi_office` (`nothi_office`);

--
-- Indexes for table `nothi_master_permissions_history`
--
ALTER TABLE `nothi_master_permissions_history`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `nothi_notes`
--
ALTER TABLE `nothi_notes`
  ADD PRIMARY KEY (`id`),
  ADD KEY `office_id` (`office_id`),
  ADD KEY `office_units_organogram_id` (`office_unit_organogram_id`),
  ADD KEY `nothi_types_id` (`nothi_type_id`),
  ADD KEY `nothi_masters_id` (`nothi_master_id`),
  ADD KEY `nothi_class` (`nothi_class`);

--
-- Indexes for table `nothi_note_attachment_refs`
--
ALTER TABLE `nothi_note_attachment_refs`
  ADD PRIMARY KEY (`id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`);

--
-- Indexes for table `nothi_note_current_users`
--
ALTER TABLE `nothi_note_current_users`
  ADD PRIMARY KEY (`id`),
  ADD KEY `nothi_office` (`nothi_office`),
  ADD KEY `nothi_part_no` (`nothi_note_id`),
  ADD KEY `office_unit_organogram_id` (`office_unit_organogram_id`);

--
-- Indexes for table `nothi_note_onuccheds`
--
ALTER TABLE `nothi_note_onuccheds`
  ADD PRIMARY KEY (`id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`),
  ADD KEY `nothi_master_id` (`nothi_master_id`),
  ADD KEY `note_status` (`note_onucched_status`);

--
-- Indexes for table `nothi_note_onucched_refs`
--
ALTER TABLE `nothi_note_onucched_refs`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `nothi_note_permissions`
--
ALTER TABLE `nothi_note_permissions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `office_id` (`office_id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`),
  ADD KEY `nothi_office` (`nothi_office`),
  ADD KEY `nothi_masters_id` (`nothi_master_id`),
  ADD KEY `office_unit_organograms_id` (`designation_id`);

--
-- Indexes for table `nothi_note_sheets`
--
ALTER TABLE `nothi_note_sheets`
  ADD PRIMARY KEY (`id`),
  ADD KEY `nothi_part_no` (`nothi_part_no`);

--
-- Indexes for table `nothi_onucched_attachments`
--
ALTER TABLE `nothi_onucched_attachments`
  ADD PRIMARY KEY (`id`),
  ADD KEY `note_no` (`note_onucched_id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`),
  ADD KEY `attachment_type` (`attachment_type`);

--
-- Indexes for table `nothi_onucched_signatures`
--
ALTER TABLE `nothi_onucched_signatures`
  ADD PRIMARY KEY (`id`),
  ADD KEY `office_organogram_id` (`office_unit_organogram_id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`);

--
-- Indexes for table `nothi_potrojari_attachment_refs`
--
ALTER TABLE `nothi_potrojari_attachment_refs`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `nothi_potros`
--
ALTER TABLE `nothi_potros`
  ADD PRIMARY KEY (`id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`),
  ADD KEY `is_deleted` (`is_deleted`);

--
-- Indexes for table `nothi_potro_attachments`
--
ALTER TABLE `nothi_potro_attachments`
  ADD PRIMARY KEY (`id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`),
  ADD KEY `nothi_master_id` (`nothi_master_id`),
  ADD KEY `is_summary_nothi` (`is_summary_nothi`),
  ADD KEY `potrojari_id` (`potrojari_id`),
  ADD KEY `attachment_type` (`attachment_type`),
  ADD KEY `status` (`status`);

--
-- Indexes for table `nothi_register_lists`
--
ALTER TABLE `nothi_register_lists`
  ADD PRIMARY KEY (`id`),
  ADD KEY `office_id` (`from_office_id`);

--
-- Indexes for table `nothi_running_processes`
--
ALTER TABLE `nothi_running_processes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `nothi_types`
--
ALTER TABLE `nothi_types`
  ADD PRIMARY KEY (`id`),
  ADD KEY `office_id` (`office_id`,`office_unit_id`);

--
-- Indexes for table `notifications`
--
ALTER TABLE `notifications`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `notification_events`
--
ALTER TABLE `notification_events`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `notification_messages`
--
ALTER TABLE `notification_messages`
  ADD PRIMARY KEY (`id`),
  ADD KEY `to_user_id` (`to_user_id`);

--
-- Indexes for table `notification_settings`
--
ALTER TABLE `notification_settings`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `notification_templates`
--
ALTER TABLE `notification_templates`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `notification_template_messages`
--
ALTER TABLE `notification_template_messages`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `office_designation_seals`
--
ALTER TABLE `office_designation_seals`
  ADD PRIMARY KEY (`id`),
  ADD KEY `seal_owner_designation_id` (`seal_owner_designation_id`);

--
-- Indexes for table `office_unit_seals`
--
ALTER TABLE `office_unit_seals`
  ADD PRIMARY KEY (`id`),
  ADD KEY `office_id` (`office_id`),
  ADD KEY `seal_owner_unit_id` (`seal_owner_unit_id`);

--
-- Indexes for table `old_dak_filter`
--
ALTER TABLE `old_dak_filter`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `one_time_passwords`
--
ALTER TABLE `one_time_passwords`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `other_office_nothi_master_movements`
--
ALTER TABLE `other_office_nothi_master_movements`
  ADD PRIMARY KEY (`id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`),
  ADD KEY `from_office_id` (`from_office_id`),
  ADD KEY `to_office_id` (`to_office_id`);

--
-- Indexes for table `other_organogram_activities_settings`
--
ALTER TABLE `other_organogram_activities_settings`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `performance_designations`
--
ALTER TABLE `performance_designations`
  ADD PRIMARY KEY (`id`),
  ADD KEY `designation_id` (`designation_id`),
  ADD KEY `unit_id` (`unit_id`),
  ADD KEY `office_id` (`office_id`);

--
-- Indexes for table `performance_offices`
--
ALTER TABLE `performance_offices`
  ADD PRIMARY KEY (`id`),
  ADD KEY `office_id` (`office_id`);

--
-- Indexes for table `portal_publishes`
--
ALTER TABLE `portal_publishes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `potrojari`
--
ALTER TABLE `potrojari`
  ADD PRIMARY KEY (`id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`),
  ADD KEY `potro_status` (`potro_status`),
  ADD KEY `potrojari_draft_office_id` (`draft_office_id`);

--
-- Indexes for table `potrojari_attachments`
--
ALTER TABLE `potrojari_attachments`
  ADD PRIMARY KEY (`id`),
  ADD KEY `potrojari_id` (`potrojari_id`),
  ADD KEY `attachment_type` (`attachment_type`);

--
-- Indexes for table `potrojari_error_logs`
--
ALTER TABLE `potrojari_error_logs`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `potrojari_recipient_onulipis`
--
ALTER TABLE `potrojari_recipient_onulipis`
  ADD PRIMARY KEY (`id`),
  ADD KEY `potrojari_id` (`potrojari_id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`),
  ADD KEY `nothi_master_id` (`nothi_master_id`);

--
-- Indexes for table `potrojari_recipient_others`
--
ALTER TABLE `potrojari_recipient_others`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `potrojari_recipient_receivers`
--
ALTER TABLE `potrojari_recipient_receivers`
  ADD PRIMARY KEY (`id`),
  ADD KEY `potrojari_id` (`potrojari_id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`),
  ADD KEY `nothi_master_id` (`nothi_master_id`);

--
-- Indexes for table `potrojari_registers`
--
ALTER TABLE `potrojari_registers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `potrojari_versions`
--
ALTER TABLE `potrojari_versions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `potrojari_id` (`potrojari_id`);

--
-- Indexes for table `potro_flags`
--
ALTER TABLE `potro_flags`
  ADD PRIMARY KEY (`id`),
  ADD KEY `nothi_part_no` (`nothi_note_id`);

--
-- Indexes for table `protikolpo_log`
--
ALTER TABLE `protikolpo_log`
  ADD PRIMARY KEY (`id`),
  ADD KEY `employee_office_id_from` (`employee_office_id_from_name`),
  ADD KEY `employee_office_id_to` (`employee_office_id_to_name`),
  ADD KEY `protikolpo_id` (`protikolpo_id`);

--
-- Indexes for table `protikolpo_settings`
--
ALTER TABLE `protikolpo_settings`
  ADD PRIMARY KEY (`id`),
  ADD KEY `office_id` (`office_id`),
  ADD KEY `active_status` (`active_status`);

--
-- Indexes for table `shared_nothis`
--
ALTER TABLE `shared_nothis`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `shared_nothi_users`
--
ALTER TABLE `shared_nothi_users`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `summary_nothi_users`
--
ALTER TABLE `summary_nothi_users`
  ADD PRIMARY KEY (`id`),
  ADD KEY `nothi_part_no` (`nothi_part_no`),
  ADD KEY `designation_id` (`designation_id`);

--
-- Indexes for table `unit_update_history`
--
ALTER TABLE `unit_update_history`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `api_nothi_part_flag`
--
ALTER TABLE `api_nothi_part_flag`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `daak_personal_folders`
--
ALTER TABLE `daak_personal_folders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_actions_mig`
--
ALTER TABLE `dak_actions_mig`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_action_employees`
--
ALTER TABLE `dak_action_employees`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_attachments`
--
ALTER TABLE `dak_attachments`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_attachment_comment`
--
ALTER TABLE `dak_attachment_comment`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_childs`
--
ALTER TABLE `dak_childs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_custom_labels`
--
ALTER TABLE `dak_custom_labels`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_daptoriks`
--
ALTER TABLE `dak_daptoriks`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_master_movements`
--
ALTER TABLE `dak_master_movements`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_master_movement_users`
--
ALTER TABLE `dak_master_movement_users`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_movements`
--
ALTER TABLE `dak_movements`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_nagoriks`
--
ALTER TABLE `dak_nagoriks`
  MODIFY `id` bigint(16) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_register`
--
ALTER TABLE `dak_register`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_sorting_permissions`
--
ALTER TABLE `dak_sorting_permissions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_third_table`
--
ALTER TABLE `dak_third_table`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_users`
--
ALTER TABLE `dak_users`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_user_actions`
--
ALTER TABLE `dak_user_actions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `ds_user_info`
--
ALTER TABLE `ds_user_info`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `guard_files`
--
ALTER TABLE `guard_files`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `guard_file_api_datas`
--
ALTER TABLE `guard_file_api_datas`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `guard_file_attachments`
--
ALTER TABLE `guard_file_attachments`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `guard_file_categories`
--
ALTER TABLE `guard_file_categories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `honor_boards`
--
ALTER TABLE `honor_boards`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `messages`
--
ALTER TABLE `messages`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `message_views`
--
ALTER TABLE `message_views`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nisponno_records`
--
ALTER TABLE `nisponno_records`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `note_flags`
--
ALTER TABLE `note_flags`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `note_initiator`
--
ALTER TABLE `note_initiator`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothivukto_nothis`
--
ALTER TABLE `nothivukto_nothis`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothivukto_nothis_merge_table`
--
ALTER TABLE `nothivukto_nothis_merge_table`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_archive_requests`
--
ALTER TABLE `nothi_archive_requests`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_data_change_history`
--
ALTER TABLE `nothi_data_change_history`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_decisions_mig`
--
ALTER TABLE `nothi_decisions_mig`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_decision_employees`
--
ALTER TABLE `nothi_decision_employees`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_masters`
--
ALTER TABLE `nothi_masters`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_master_movements`
--
ALTER TABLE `nothi_master_movements`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_master_permissions`
--
ALTER TABLE `nothi_master_permissions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_master_permissions_history`
--
ALTER TABLE `nothi_master_permissions_history`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_notes`
--
ALTER TABLE `nothi_notes`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_note_attachment_refs`
--
ALTER TABLE `nothi_note_attachment_refs`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_note_current_users`
--
ALTER TABLE `nothi_note_current_users`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_note_onuccheds`
--
ALTER TABLE `nothi_note_onuccheds`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_note_onucched_refs`
--
ALTER TABLE `nothi_note_onucched_refs`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_note_permissions`
--
ALTER TABLE `nothi_note_permissions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_note_sheets`
--
ALTER TABLE `nothi_note_sheets`
  MODIFY `id` bigint(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_onucched_attachments`
--
ALTER TABLE `nothi_onucched_attachments`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_onucched_signatures`
--
ALTER TABLE `nothi_onucched_signatures`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_potrojari_attachment_refs`
--
ALTER TABLE `nothi_potrojari_attachment_refs`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_potros`
--
ALTER TABLE `nothi_potros`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_potro_attachments`
--
ALTER TABLE `nothi_potro_attachments`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_register_lists`
--
ALTER TABLE `nothi_register_lists`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_running_processes`
--
ALTER TABLE `nothi_running_processes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_types`
--
ALTER TABLE `nothi_types`
  MODIFY `id` int(4) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `notifications`
--
ALTER TABLE `notifications`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `notification_events`
--
ALTER TABLE `notification_events`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `notification_messages`
--
ALTER TABLE `notification_messages`
  MODIFY `id` int(100) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `notification_settings`
--
ALTER TABLE `notification_settings`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `notification_templates`
--
ALTER TABLE `notification_templates`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `notification_template_messages`
--
ALTER TABLE `notification_template_messages`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `office_designation_seals`
--
ALTER TABLE `office_designation_seals`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `office_unit_seals`
--
ALTER TABLE `office_unit_seals`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `old_dak_filter`
--
ALTER TABLE `old_dak_filter`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `one_time_passwords`
--
ALTER TABLE `one_time_passwords`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `other_office_nothi_master_movements`
--
ALTER TABLE `other_office_nothi_master_movements`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `other_organogram_activities_settings`
--
ALTER TABLE `other_organogram_activities_settings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `performance_designations`
--
ALTER TABLE `performance_designations`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `performance_offices`
--
ALTER TABLE `performance_offices`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `portal_publishes`
--
ALTER TABLE `portal_publishes`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `potrojari`
--
ALTER TABLE `potrojari`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `potrojari_attachments`
--
ALTER TABLE `potrojari_attachments`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `potrojari_error_logs`
--
ALTER TABLE `potrojari_error_logs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `potrojari_recipient_onulipis`
--
ALTER TABLE `potrojari_recipient_onulipis`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `potrojari_recipient_others`
--
ALTER TABLE `potrojari_recipient_others`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `potrojari_recipient_receivers`
--
ALTER TABLE `potrojari_recipient_receivers`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `potrojari_registers`
--
ALTER TABLE `potrojari_registers`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `potrojari_versions`
--
ALTER TABLE `potrojari_versions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `potro_flags`
--
ALTER TABLE `potro_flags`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `protikolpo_log`
--
ALTER TABLE `protikolpo_log`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `protikolpo_settings`
--
ALTER TABLE `protikolpo_settings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `shared_nothis`
--
ALTER TABLE `shared_nothis`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `shared_nothi_users`
--
ALTER TABLE `shared_nothi_users`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `summary_nothi_users`
--
ALTER TABLE `summary_nothi_users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `unit_update_history`
--
ALTER TABLE `unit_update_history`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
