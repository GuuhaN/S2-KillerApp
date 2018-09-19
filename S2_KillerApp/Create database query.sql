CREATE TABLE UserAccount(
	Id int NOT NULL IDENTITY,
	Username varchar(50) NOT NULL,
	Password varchar(50) NOT NULL,
	Email varchar(50) NOT NULL,
	LastPlayedSong int NOT NULL,
	LoggedIn BIT NOT NULL,
	PRIMARY KEY (Id)
)

CREATE TABLE Permission(
	Id int NOT NULL,
	Permission varchar(50) NOT NULL
	PRIMARY KEY(Id)
)

CREATE TABLE User_Permission(
	User_Id int NOT NULL,
	Permission_Id int NOT NULL,
	FOREIGN KEY (User_Id) REFERENCES UserAccount(Id),
	FOREIGN KEY (Permission_Id) REFERENCES Permission(Id)
)

CREATE TABLE Playlist(
	Id int NOT NULL IDENTITY,
	User_Id int NOT NULL,
	Title varchar(50) NOT NULL,
	Description varchar(MAX) NOT NULL,
	Privacy BIT NOT NULL,
	PRIMARY KEY(Id),
	FOREIGN KEY(User_Id) REFERENCES UserAccount(Id)
)

CREATE TABLE Song(
	Id int NOT NULL IDENTITY,
	Songname varchar(50) NOT NULL,
	Genre varchar(50) NOT NULL,
	Score int NOT NULL,
	Explicit bit NOT NULL,
	PRIMARY KEY(Id)
)

CREATE TABLE Playlist_Song(
	Playlist_Id INT NOT NULL IDENTITY,
	Song_Id INT NOT NULL,
	FOREIGN KEY(Playlist_Id) REFERENCES Playlist(Id),
	FOREIGN KEY(Song_Id) REFERENCES Song(Id)
)

CREATE TABLE Artist(
	Id INT NOT NULL IDENTITY,
	Name varchar(50) NOT NULL,
	Birthdate Datetime NOT NULL,
	PRIMARY KEY(Id)
)