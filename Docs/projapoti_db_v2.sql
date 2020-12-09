-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Nov 22, 2020 at 03:07 PM
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
-- Database: `projapoti_db_v2`
--

-- --------------------------------------------------------

--
-- Table structure for table `dak_priority_types`
--

CREATE TABLE `dak_priority_types` (
  `id` int(4) NOT NULL,
  `name_bng` varchar(255) NOT NULL,
  `name_eng` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_security_levels`
--

CREATE TABLE `dak_security_levels` (
  `id` int(4) NOT NULL,
  `name_bng` varchar(255) NOT NULL,
  `name_eng` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_tracks`
--

CREATE TABLE `dak_tracks` (
  `sarok_no` varchar(255) DEFAULT NULL,
  `service_name` varchar(100) NOT NULL DEFAULT 'nothi',
  `sender_office_id` int(11) DEFAULT NULL,
  `sender_officer_designation_id` int(11) DEFAULT NULL,
  `sender_name` varchar(255) DEFAULT NULL,
  `sender_email` varchar(255) DEFAULT NULL,
  `sender_mobile` varchar(255) DEFAULT NULL,
  `dak_received_no` varchar(50) DEFAULT NULL,
  `docketing_no` varchar(255) DEFAULT NULL,
  `forms_track_no` varchar(100) DEFAULT NULL,
  `receiving_date` datetime DEFAULT NULL,
  `dak_subject` varchar(255) DEFAULT NULL,
  `receiving_office_id` int(11) DEFAULT NULL,
  `receiving_officer_designation_label` varchar(255) DEFAULT NULL,
  `receiving_officer_name` varchar(255) DEFAULT NULL,
  `dak_id` bigint(20) DEFAULT NULL,
  `dak_type` varchar(255) DEFAULT NULL,
  `id` bigint(20) NOT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_types`
--

CREATE TABLE `dak_types` (
  `id` tinyint(2) NOT NULL DEFAULT '0',
  `name` varchar(100) NOT NULL COMMENT 'need for own and 3rd party',
  `created_by` bigint(10) NOT NULL,
  `created` datetime NOT NULL,
  `modified_by` bigint(20) DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='need for own and 3rd party';

-- --------------------------------------------------------

--
-- Table structure for table `mig_potrojari_header_settings`
--

CREATE TABLE `mig_potrojari_header_settings` (
  `id` int(11) NOT NULL,
  `employee_record_id` bigint(20) NOT NULL,
  `office_id` bigint(20) NOT NULL,
  `office_unit_id` bigint(20) NOT NULL,
  `office_unit_organogram_id` bigint(20) NOT NULL,
  `potrojari_head` longtext,
  `potrojari_head_eng` longtext,
  `potrojari_head_img` longtext,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `created_by` bigint(20) DEFAULT NULL,
  `modified_by` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `mig_queue_potrojari_request`
--

CREATE TABLE `mig_queue_potrojari_request` (
  `id` bigint(20) NOT NULL,
  `command` varchar(250) NOT NULL,
  `office_id` int(11) NOT NULL,
  `potrojari_id` bigint(20) NOT NULL,
  `try` tinyint(4) NOT NULL,
  `status` tinyint(4) DEFAULT '0',
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `mig_queue_sms_request`
--

CREATE TABLE `mig_queue_sms_request` (
  `id` bigint(20) NOT NULL,
  `cell_number` varchar(20) NOT NULL,
  `message` varchar(250) NOT NULL,
  `status` tinyint(4) NOT NULL DEFAULT '0',
  `try` int(11) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `mig_view_reports`
--

CREATE TABLE `mig_view_reports` (
  `id` int(11) NOT NULL,
  `username` varchar(15) NOT NULL,
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `module_infos`
--

CREATE TABLE `module_infos` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `name_bn` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL,
  `created_by` varchar(100) NOT NULL,
  `modified_by` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `module_mappings`
--

CREATE TABLE `module_mappings` (
  `id` int(11) NOT NULL,
  `module_id` int(4) NOT NULL,
  `office_id` int(11) NOT NULL,
  `designation_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
  `status` int(11) DEFAULT NULL COMMENT '1 for no action; 2 for running; 3 for done; 4 for failed;',
  `responsed_date` datetime DEFAULT NULL,
  `comments` varchar(1024) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_decisions`
--

CREATE TABLE `nothi_decisions` (
  `id` int(11) NOT NULL,
  `decisions` varchar(255) CHARACTER SET utf8 NOT NULL,
  `status` tinyint(1) NOT NULL DEFAULT '1',
  `office_id` int(11) DEFAULT '0',
  `unit_id` int(11) DEFAULT '0',
  `organogram_id` int(11) DEFAULT '0',
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL,
  `token` bigint(20) DEFAULT NULL,
  `device_type` varchar(50) NOT NULL DEFAULT 'web',
  `device_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_updates`
--

CREATE TABLE `nothi_updates` (
  `id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  `body` longtext NOT NULL,
  `is_display` tinyint(2) NOT NULL DEFAULT '0',
  `version` varchar(100) NOT NULL,
  `release_date` date NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
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
-- Table structure for table `notification_tokens`
--

CREATE TABLE `notification_tokens` (
  `id` bigint(20) NOT NULL,
  `token` text NOT NULL,
  `type` varchar(20) NOT NULL,
  `username` bigint(20) NOT NULL,
  `employee_record_id` bigint(20) NOT NULL,
  `designations` varchar(255) DEFAULT NULL,
  `device_id` varchar(100) NOT NULL,
  `device_type` varchar(50) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `office_domains`
--

CREATE TABLE `office_domains` (
  `id` int(11) NOT NULL,
  `office_id` int(11) NOT NULL,
  `domain_url` varchar(255) NOT NULL,
  `domain_prefix` varchar(100) NOT NULL,
  `domain_host` varchar(20) NOT NULL,
  `office_db` varchar(100) NOT NULL,
  `domain_username` varchar(200) NOT NULL,
  `domain_password` varchar(200) NOT NULL,
  `status` tinyint(4) NOT NULL DEFAULT '1',
  `created_by` int(11) NOT NULL,
  `modified_by` int(11) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `office_notification_settings`
--

CREATE TABLE `office_notification_settings` (
  `id` bigint(20) NOT NULL,
  `event_id` bigint(20) NOT NULL,
  `employee_id` bigint(20) NOT NULL,
  `office_id` bigint(20) NOT NULL,
  `system` tinyint(2) NOT NULL DEFAULT '1',
  `email` tinyint(2) NOT NULL DEFAULT '1',
  `sms` tinyint(2) NOT NULL DEFAULT '0',
  `mobile_app` tinyint(1) NOT NULL DEFAULT '1',
  `is_notified` tinyint(1) NOT NULL DEFAULT '0',
  `last_request` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `potrojari_templates`
--

CREATE TABLE `potrojari_templates` (
  `id` bigint(20) NOT NULL,
  `template_name` varchar(255) DEFAULT NULL,
  `field_list` varchar(255) DEFAULT NULL,
  `html_content` longtext NOT NULL,
  `status` tinyint(5) NOT NULL DEFAULT '1',
  `template_id` int(11) NOT NULL DEFAULT '0',
  `version` varchar(5) NOT NULL DEFAULT 'bn',
  `office_id` int(11) NOT NULL DEFAULT '0',
  `office` varchar(255) NOT NULL DEFAULT '',
  `designation_id` bigint(20) NOT NULL DEFAULT '0',
  `designation` varchar(255) NOT NULL DEFAULT '',
  `recipient_type` varchar(255) NOT NULL DEFAULT '',
  `created_by` bigint(10) NOT NULL,
  `created` datetime NOT NULL,
  `modified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `modified_by` bigint(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `summary_nothi_users`
--

CREATE TABLE `summary_nothi_users` (
  `id` bigint(20) NOT NULL,
  `nothi_office` int(11) DEFAULT '0',
  `current_office_id` int(11) DEFAULT '0',
  `nothi_master_id` bigint(20) DEFAULT '0',
  `nothi_part_no` bigint(20) DEFAULT '0',
  `potrojari_id` bigint(20) DEFAULT '0',
  `dak_id` bigint(20) DEFAULT '0',
  `potro_id` bigint(20) DEFAULT '0',
  `designation_id` bigint(20) DEFAULT '0',
  `employee_record_id` bigint(20) NOT NULL,
  `position_number` varchar(50) NOT NULL,
  `sequence_number` int(11) NOT NULL,
  `can_approve` tinyint(2) DEFAULT '1',
  `is_approve` tinyint(2) DEFAULT '0',
  `is_sent` tinyint(2) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `user_roles`
--

CREATE TABLE `user_roles` (
  `id` int(11) NOT NULL,
  `name` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `description` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `user_level` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `user_signatures`
--

CREATE TABLE `user_signatures` (
  `id` bigint(20) NOT NULL,
  `username` varchar(14) NOT NULL,
  `signature_file` varchar(255) NOT NULL,
  `encode_sign` longtext NOT NULL,
  `previous_signature` varchar(255) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `created_by` bigint(20) DEFAULT NULL,
  `modified_by` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `dak_priority_types`
--
ALTER TABLE `dak_priority_types`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `dak_security_levels`
--
ALTER TABLE `dak_security_levels`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `dak_tracks`
--
ALTER TABLE `dak_tracks`
  ADD PRIMARY KEY (`id`),
  ADD KEY `dak_id` (`dak_id`,`dak_type`);

--
-- Indexes for table `mig_potrojari_header_settings`
--
ALTER TABLE `mig_potrojari_header_settings`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mig_queue_potrojari_request`
--
ALTER TABLE `mig_queue_potrojari_request`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `command` (`command`);

--
-- Indexes for table `mig_queue_sms_request`
--
ALTER TABLE `mig_queue_sms_request`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mig_view_reports`
--
ALTER TABLE `mig_view_reports`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `module_infos`
--
ALTER TABLE `module_infos`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `module_mappings`
--
ALTER TABLE `module_mappings`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `module_office_designation` (`module_id`,`office_id`,`designation_id`) USING BTREE;

--
-- Indexes for table `nothi_archive_requests`
--
ALTER TABLE `nothi_archive_requests`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `nothi_decisions`
--
ALTER TABLE `nothi_decisions`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `nothi_updates`
--
ALTER TABLE `nothi_updates`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `notification_events`
--
ALTER TABLE `notification_events`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `notification_tokens`
--
ALTER TABLE `notification_tokens`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `office_domains`
--
ALTER TABLE `office_domains`
  ADD PRIMARY KEY (`id`),
  ADD KEY `office_id` (`office_id`);

--
-- Indexes for table `office_notification_settings`
--
ALTER TABLE `office_notification_settings`
  ADD PRIMARY KEY (`id`),
  ADD KEY `employee_id` (`employee_id`);

--
-- Indexes for table `potrojari_templates`
--
ALTER TABLE `potrojari_templates`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `summary_nothi_users`
--
ALTER TABLE `summary_nothi_users`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `user_roles`
--
ALTER TABLE `user_roles`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `user_signatures`
--
ALTER TABLE `user_signatures`
  ADD PRIMARY KEY (`id`),
  ADD KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `dak_priority_types`
--
ALTER TABLE `dak_priority_types`
  MODIFY `id` int(4) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_security_levels`
--
ALTER TABLE `dak_security_levels`
  MODIFY `id` int(4) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_tracks`
--
ALTER TABLE `dak_tracks`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mig_potrojari_header_settings`
--
ALTER TABLE `mig_potrojari_header_settings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mig_queue_potrojari_request`
--
ALTER TABLE `mig_queue_potrojari_request`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mig_queue_sms_request`
--
ALTER TABLE `mig_queue_sms_request`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mig_view_reports`
--
ALTER TABLE `mig_view_reports`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `module_infos`
--
ALTER TABLE `module_infos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `module_mappings`
--
ALTER TABLE `module_mappings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_archive_requests`
--
ALTER TABLE `nothi_archive_requests`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_decisions`
--
ALTER TABLE `nothi_decisions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_updates`
--
ALTER TABLE `nothi_updates`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `notification_events`
--
ALTER TABLE `notification_events`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `notification_tokens`
--
ALTER TABLE `notification_tokens`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `office_domains`
--
ALTER TABLE `office_domains`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `office_notification_settings`
--
ALTER TABLE `office_notification_settings`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `potrojari_templates`
--
ALTER TABLE `potrojari_templates`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `summary_nothi_users`
--
ALTER TABLE `summary_nothi_users`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user_roles`
--
ALTER TABLE `user_roles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user_signatures`
--
ALTER TABLE `user_signatures`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
