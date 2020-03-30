CREATE DATABASE Dormitory;

CREATE TABLE Dormitories(
Id int IDENTITY(1,1) PRIMARY KEY ,
Name varchar(64),
Address varchar(64)
);

CREATE TABLE Rooms(
Id int IDENTITY(1,1),
DormitoryId int, 
PRIMARY KEY(Id, DormitoryId),
Name varchar(64),
Floor int
);

CREATE TABLE Students(
Id int IDENTITY(1,1)  PRIMARY KEY ,
Name varchar(64),
Email varchar(64),
RoomId int,
DormitoryId int,
FOREIGN KEY (RoomId, DormitoryId) REFERENCES Rooms(Id, DormitoryId),
FOREIGN KEY (DormitoryId) REFERENCES Dormitories(Id)
);
INSERT INTO Dormitories VALUES(
'Гуртожиток 1', 'Лукаша 1')	
INSERT INTO Dormitories VALUES(
'Гуртожиток 2', 'Лукаша 2')
INSERT INTO Dormitories VALUES(
'Гуртожиток 3', 'Лукаша 3')

Select * FROM Dormitories
Select * FROM Rooms
Select * FROM Students

INSERT INTO Rooms VALUES
('512', 5, 1);	


INSERT INTO Students VALUES('Василь', 'vasyl@gmail.com', 1, 2)
INSERT INTO Students VALUES('Петро', 'petro@gmail.com', 1)