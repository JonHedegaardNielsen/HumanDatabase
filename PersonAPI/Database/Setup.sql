DROP TABLE IF EXISTS person;

CREATE TABLE person (
	personId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	firstName TEXT NOT NULL,
	lastName TEXT NOT NULL,
	age INTEGER NOT NULL,
	gender INTEGER NOT NULL,
	height INTEGER NOT NULL,
	personWeight INTEGER NOT NULL,
	dayOfBirth TEXT NOT NULL,
	photo BLOB,
)