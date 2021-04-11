/*
Created: 22/03/2021
Modified: 30/03/2021
Model: MySQL 8.0
Database: MySQL 8.0
*/

-- Create tables section -------------------------------------------------

-- Table books

CREATE TABLE `books`
(
  `id_b` Serial NOT NULL,
  `title` Text NOT NULL,
  `summary` Text,
  `year` Varchar(20),
  `lost` Int,
  `genre_id` Serial NOT NULL,
  `publisher_id` Serial NOT NULL
)
;

CREATE INDEX `IX_Relationship3` ON `books` (`genre_id`)
;

CREATE INDEX `IX_Relationship7` ON `books` (`publisher_id`)
;

ALTER TABLE `books` ADD PRIMARY KEY (`id_b`)
;

-- Table rents

CREATE TABLE `rents`
(
  `id_r` Serial NOT NULL,
  `state` Int,
  `date` Text,
  `book_id` Serial NOT NULL,
  `user_id` Serial NOT NULL
)
;

CREATE INDEX `IX_Relationship1` ON `rents` (`book_id`)
;

CREATE INDEX `IX_Relationship2` ON `rents` (`user_id`)
;

ALTER TABLE `rents` ADD PRIMARY KEY (`id_r`)
;

-- Table users

CREATE TABLE `users`
(
  `id_u` Serial NOT NULL,
  `name` Varchar(56) NOT NULL,
  `surname` Varchar(56) NOT NULL,
  `tel` Text NOT NULL,
  `address` Text NOT NULL,
  `email` Text,
  `username` Varchar(35),
  `password` Varchar(20),
  `notes` Text,
  `location_id` Serial NOT NULL
)
;

CREATE INDEX `IX_Relationship4` ON `users` (`location_id`)
;

ALTER TABLE `users` ADD PRIMARY KEY (`id_u`)
;

-- Table genre

CREATE TABLE `genre`
(
  `id_g` Serial NOT NULL,
  `genretype` Text NOT NULL
)
;

ALTER TABLE `genre` ADD PRIMARY KEY (`id_g`)
;

-- Table authors

CREATE TABLE `authors`
(
  `id_a` Serial NOT NULL,
  `name` Text NOT NULL,
  `surname` Text NOT NULL
)
;

ALTER TABLE `authors` ADD PRIMARY KEY (`id_a`)
;

-- Table locations

CREATE TABLE `locations`
(
  `id_l` Serial NOT NULL,
  `name` Text NOT NULL,
  `postalcode` Text
)
;

ALTER TABLE `locations` ADD PRIMARY KEY (`id_l`)
;

-- Table book_authors

CREATE TABLE `book_authors`
(
  `author_id` Serial NOT NULL,
  `book_id` Serial NOT NULL
)
;

CREATE INDEX `IX_Relationship5` ON `book_authors` (`author_id`)
;

CREATE INDEX `IX_Relationship6` ON `book_authors` (`book_id`)
;

-- Table publishers

CREATE TABLE `publishers`
(
  `id_p` Serial NOT NULL,
  `name` Text NOT NULL
)
;

ALTER TABLE `publishers` ADD PRIMARY KEY (`id_p`)
;

-- Create foreign keys (relationships) section -------------------------------------------------

ALTER TABLE `rents` ADD CONSTRAINT `Relationship1` FOREIGN KEY (`book_id`) REFERENCES `books` (`id_b`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `rents` ADD CONSTRAINT `Relationship2` FOREIGN KEY (`user_id`) REFERENCES `users` (`id_u`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `books` ADD CONSTRAINT `Relationship3` FOREIGN KEY (`genre_id`) REFERENCES `genre` (`id_g`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `users` ADD CONSTRAINT `Relationship4` FOREIGN KEY (`location_id`) REFERENCES `locations` (`id_l`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `book_authors` ADD CONSTRAINT `Relationship5` FOREIGN KEY (`author_id`) REFERENCES `authors` (`id_a`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `book_authors` ADD CONSTRAINT `Relationship6` FOREIGN KEY (`book_id`) REFERENCES `books` (`id_b`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `books` ADD CONSTRAINT `Relationship7` FOREIGN KEY (`publisher_id`) REFERENCES `publishers` (`id_p`) ON DELETE RESTRICT ON UPDATE RESTRICT
;


