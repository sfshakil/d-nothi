-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Nov 22, 2020 at 03:08 PM
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
-- Database: `nothi_access_db_v2`
--

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
-- Table structure for table `dak_decisions`
--

CREATE TABLE `dak_decisions` (
  `id` int(11) NOT NULL,
  `dak_decision` varchar(255) NOT NULL DEFAULT '',
  `status` tinyint(2) NOT NULL DEFAULT '1',
  `is_default` tinyint(1) NOT NULL DEFAULT '0',
  `employee_record_id` int(11) DEFAULT '0',
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dak_decisions_employees`
--

CREATE TABLE `dak_decisions_employees` (
  `id` int(11) NOT NULL,
  `dak_decision_id` int(11) NOT NULL,
  `employee_id` int(11) DEFAULT '0',
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
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
-- Table structure for table `guard_file_attachments`
--

CREATE TABLE `guard_file_attachments` (
  `id` int(11) NOT NULL,
  `guard_file_id` bigint(20) NOT NULL,
  `name_bng` varchar(255) DEFAULT NULL,
  `attachment_type` varchar(150) NOT NULL,
  `file_name` varchar(255) NOT NULL,
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
  `office_unit_organogram` bigint(20) DEFAULT NULL,
  `created_by` bigint(20) DEFAULT NULL,
  `modified_by` bigint(20) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `guard_file_portals`
--

CREATE TABLE `guard_file_portals` (
  `id` bigint(20) NOT NULL,
  `layer_id` int(11) DEFAULT NULL,
  `type` text,
  `subdomain` varchar(255) DEFAULT NULL,
  `name` text,
  `link` text,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='previously guard files api datas';

-- --------------------------------------------------------

--
-- Table structure for table `login_notice_attachments`
--

CREATE TABLE `login_notice_attachments` (
  `id` bigint(20) NOT NULL,
  `attachment_type` varchar(255) NOT NULL,
  `file_name` varchar(255) NOT NULL,
  `user_file_name` varchar(255) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `login_page_settings`
--

CREATE TABLE `login_page_settings` (
  `id` int(11) NOT NULL,
  `type` tinyint(4) NOT NULL,
  `title` varchar(255) DEFAULT NULL,
  `description` text,
  `attachments` text,
  `status` tinyint(4) NOT NULL DEFAULT '1',
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `mig_messages`
--

CREATE TABLE `mig_messages` (
  `id` int(11) NOT NULL,
  `title` varchar(256) COLLATE utf8_unicode_ci NOT NULL,
  `message` text COLLATE utf8_unicode_ci NOT NULL,
  `message_for` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `related_id` int(11) NOT NULL,
  `message_by` int(11) NOT NULL,
  `is_deleted` int(1) NOT NULL,
  `created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci COMMENT='need to migrate to offce';

-- --------------------------------------------------------

--
-- Table structure for table `mig_message_views`
--

CREATE TABLE `mig_message_views` (
  `id` int(11) NOT NULL,
  `message_id` int(11) NOT NULL,
  `is_view` int(1) NOT NULL,
  `organogram_id` int(11) NOT NULL,
  `view_count` int(11) NOT NULL,
  `created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci COMMENT='need to migrate to offce';

-- --------------------------------------------------------

--
-- Table structure for table `mig_nisponno_records`
--

CREATE TABLE `mig_nisponno_records` (
  `id` int(11) NOT NULL,
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
-- Table structure for table `mig_queue_nothi_archive_attachment_requests`
--

CREATE TABLE `mig_queue_nothi_archive_attachment_requests` (
  `id` int(11) NOT NULL,
  `office_id` int(11) DEFAULT NULL,
  `nothi_master_id` int(11) DEFAULT NULL,
  `requester_organogram_id` int(11) DEFAULT NULL,
  `status` int(11) DEFAULT NULL COMMENT '1 for no action; 2 for running; 3 for done; 4 for failed;',
  `operation_time` datetime DEFAULT NULL,
  `comments` varchar(1024) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `monthly_reports`
--

CREATE TABLE `monthly_reports` (
  `id` int(11) NOT NULL,
  `title` varchar(512) COLLATE utf8_unicode_ci DEFAULT NULL,
  `year` varchar(4) COLLATE utf8_unicode_ci DEFAULT NULL,
  `month` varchar(2) COLLATE utf8_unicode_ci DEFAULT NULL,
  `attachment_path` varchar(256) COLLATE utf8_unicode_ci DEFAULT NULL,
  `status` int(1) DEFAULT NULL,
  `rank` int(11) DEFAULT NULL,
  `created` timestamp NULL DEFAULT NULL,
  `modified` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `nothi_decisions`
--

CREATE TABLE `nothi_decisions` (
  `id` int(11) NOT NULL,
  `decisions` varchar(255) NOT NULL DEFAULT '',
  `status` tinyint(2) NOT NULL DEFAULT '1',
  `creator` int(11) DEFAULT '0',
  `created_by` int(11) DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='previously dak decisions mig';

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
-- Table structure for table `potrojari_groups`
--

CREATE TABLE `potrojari_groups` (
  `id` int(11) NOT NULL,
  `group_name` text NOT NULL,
  `privacy_type` varchar(50) NOT NULL,
  `group_value` longtext NOT NULL,
  `createdby_officer_id` int(11) NOT NULL,
  `createdby_designation_id` int(11) NOT NULL,
  `createdby_unit_id` int(11) NOT NULL,
  `createdby_office_id` int(11) NOT NULL,
  `total_users` int(11) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `potrojari_groups_users`
--

CREATE TABLE `potrojari_groups_users` (
  `id` bigint(20) NOT NULL,
  `group_id` int(11) NOT NULL,
  `group_name` text NOT NULL,
  `office_head` tinyint(2) NOT NULL DEFAULT '0',
  `privacy_type` varchar(50) NOT NULL,
  `office_id` int(11) NOT NULL,
  `office_eng` varchar(255) NOT NULL,
  `office_bng` varchar(255) NOT NULL,
  `office_unit_id` int(11) NOT NULL,
  `office_unit_eng` varchar(255) NOT NULL,
  `office_unit_bng` varchar(255) NOT NULL,
  `designation_id` int(11) NOT NULL,
  `designation_eng` varchar(255) NOT NULL,
  `designation_bng` varchar(255) NOT NULL,
  `officer_id` int(11) NOT NULL,
  `officer_eng` varchar(255) NOT NULL,
  `officer_bng` varchar(255) NOT NULL,
  `officer_email` varchar(255) DEFAULT NULL,
  `officer_mobile` varchar(20) DEFAULT NULL,
  `createdby_officer_id` int(11) NOT NULL,
  `createdby_designation_id` int(11) NOT NULL,
  `createdby_unit_id` int(11) NOT NULL,
  `createdby_office_id` int(11) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `user_signatures`
--

CREATE TABLE `user_signatures` (
  `id` bigint(20) NOT NULL,
  `username` varchar(14) NOT NULL,
  `employee_record_id` bigint(20) NOT NULL DEFAULT '0',
  `encode_sign` text NOT NULL,
  `created` datetime DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `created_by` bigint(20) DEFAULT NULL,
  `modified_by` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

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
-- Indexes for table `dak_decisions`
--
ALTER TABLE `dak_decisions`
  ADD KEY `id` (`id`);

--
-- Indexes for table `dak_decisions_employees`
--
ALTER TABLE `dak_decisions_employees`
  ADD KEY `id` (`id`);

--
-- Indexes for table `guard_files`
--
ALTER TABLE `guard_files`
  ADD PRIMARY KEY (`id`),
  ADD KEY `office_id` (`office_id`);

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
-- Indexes for table `guard_file_portals`
--
ALTER TABLE `guard_file_portals`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `login_notice_attachments`
--
ALTER TABLE `login_notice_attachments`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `login_page_settings`
--
ALTER TABLE `login_page_settings`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mig_messages`
--
ALTER TABLE `mig_messages`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mig_message_views`
--
ALTER TABLE `mig_message_views`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mig_nisponno_records`
--
ALTER TABLE `mig_nisponno_records`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mig_queue_nothi_archive_attachment_requests`
--
ALTER TABLE `mig_queue_nothi_archive_attachment_requests`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `monthly_reports`
--
ALTER TABLE `monthly_reports`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `nothi_decisions`
--
ALTER TABLE `nothi_decisions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `creator` (`creator`);

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
-- Indexes for table `potrojari_groups`
--
ALTER TABLE `potrojari_groups`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `potrojari_groups_users`
--
ALTER TABLE `potrojari_groups_users`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `user_signatures`
--
ALTER TABLE `user_signatures`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

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
-- AUTO_INCREMENT for table `dak_decisions`
--
ALTER TABLE `dak_decisions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dak_decisions_employees`
--
ALTER TABLE `dak_decisions_employees`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `guard_files`
--
ALTER TABLE `guard_files`
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
-- AUTO_INCREMENT for table `guard_file_portals`
--
ALTER TABLE `guard_file_portals`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `login_notice_attachments`
--
ALTER TABLE `login_notice_attachments`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `login_page_settings`
--
ALTER TABLE `login_page_settings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mig_messages`
--
ALTER TABLE `mig_messages`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mig_message_views`
--
ALTER TABLE `mig_message_views`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mig_nisponno_records`
--
ALTER TABLE `mig_nisponno_records`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mig_queue_nothi_archive_attachment_requests`
--
ALTER TABLE `mig_queue_nothi_archive_attachment_requests`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `monthly_reports`
--
ALTER TABLE `monthly_reports`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nothi_decisions`
--
ALTER TABLE `nothi_decisions`
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
-- AUTO_INCREMENT for table `potrojari_groups`
--
ALTER TABLE `potrojari_groups`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `potrojari_groups_users`
--
ALTER TABLE `potrojari_groups_users`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user_signatures`
--
ALTER TABLE `user_signatures`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
