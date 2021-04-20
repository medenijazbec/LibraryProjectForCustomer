/*
Created: 10. 04. 2021
Modified: 10. 04. 2021
Model: SQLite 3.7
Database: SQLite 3.7
*/

-- Create tables section -------------------------------------------------

-- Table books

CREATE TABLE books
(
  id_b INTEGER NOT NULL,
  title TEXT NOT NULL,
  summary TEXT,
  year TEXT,
  lost INTEGER,
  genre_id INTEGER NOT NULL,
  publisher_id INTEGER NOT NULL,
  CONSTRAINT PK_books PRIMARY KEY (id_b),
  CONSTRAINT Relationship1
    FOREIGN KEY (genre_id)
    REFERENCES genre (id_g),
  CONSTRAINT Relationship2
    FOREIGN KEY (publisher_id)
    REFERENCES publishers (id_p)
)
;

CREATE INDEX IX_Relationship1
  ON books (genre_id)
;

CREATE INDEX IX_Relationship2
  ON books (publisher_id)
;

-- Table rents

CREATE TABLE rents
(
  id_r INTEGER NOT NULL,
  state INTEGER,
  date TEXT,
  book_id INTEGER NOT NULL,
  user_id INTEGER NOT NULL,
  CONSTRAINT PK_rents PRIMARY KEY (id_r),
  CONSTRAINT Relationship7
    FOREIGN KEY (book_id)
    REFERENCES books (id_b),
  CONSTRAINT Relationship9
    FOREIGN KEY (user_id)
    REFERENCES users (id_u)
)
;

CREATE INDEX IX_Relationship7
  ON rents (book_id)
;

CREATE INDEX IX_Relationship9
  ON rents (user_id)
;

-- Table users

CREATE TABLE users
(
  id_u INTEGER NOT NULL,
  name TEXT NOT NULL,
  surname TEXT NOT NULL,
  tel TEXT NOT NULL,
  address TEXT NOT NULL,
  email TEXT,
  username TEXT,
  password TEXT,
  notes TEXT,
  location_id INTEGER NOT NULL,
  CONSTRAINT PK_users PRIMARY KEY (id_u),
  CONSTRAINT Relationship8
    FOREIGN KEY (location_id)
    REFERENCES locations (id_l)
)
;

CREATE INDEX IX_Relationship8
  ON users (location_id)
;

-- Table genre

CREATE TABLE genre
(
  id_g INTEGER NOT NULL,
  genretype TEXT NOT NULL,
  CONSTRAINT PK_genre PRIMARY KEY (id_g)
)
;

-- Table authors

CREATE TABLE authors
(
  id_a INTEGER NOT NULL,
  name TEXT NOT NULL,
  surname TEXT NOT NULL,
  CONSTRAINT PK_authors PRIMARY KEY (id_a)
)
;

-- Table locations

CREATE TABLE locations
(
  id_l INTEGER NOT NULL,
  name TEXT NOT NULL,
  postalcode TEXT,
  CONSTRAINT PK_locations PRIMARY KEY (id_l)
)
;

-- Table book_authors

CREATE TABLE book_authors
(
  author_id INTEGER NOT NULL,
  book_id INTEGER NOT NULL,
  CONSTRAINT Relationship5
    FOREIGN KEY (author_id)
    REFERENCES authors (id_a),
  CONSTRAINT Relationship6
    FOREIGN KEY (book_id)
    REFERENCES books (id_b)
)
;

CREATE INDEX IX_Relationship5
  ON book_authors (author_id)
;

CREATE INDEX IX_Relationship6
  ON book_authors (book_id)
;

-- Table publishers

CREATE TABLE publishers
(
  id_p INTEGER NOT NULL,
  name TEXT NOT NULL,
  CONSTRAINT PK_publishers PRIMARY KEY (id_p)
)
;

