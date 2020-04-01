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


DELETE FROM Dormitories
INSERT INTO Dormitories VALUES
('Гуртожиток №1', 'Лукаша 1'),
('Гуртожиток №2', 'Лукаша 2'),
('Гуртожиток №3', 'Лукаша 3'),
('Гуртожиток №4', 'Лукаша 4'),
('Гуртожиток №5', 'Лукаша 5'),
('Гуртожиток №6', 'Лукаша 6'),
('Гуртожиток №7', 'Лукаша 7'),
('Гуртожиток №8', 'Лукаша 8'),
('Гуртожиток №9', 'Лукаша 9')

INSERT INTO Rooms VALUES
('112', 1, 4),
('212', 2, 5),
('312', 3, 6),
('412', 4, 7),
('512', 5, 8),
('112', 1, 9),
('212', 2, 10),
('312', 3, 11),
('412', 4, 12)

Select * FROM Dormitories
Select * FROM Rooms
Select * FROM Students

INSERT INTO Students VALUES
('Василь', 'vasyl@gmail.com', 4, 4),
('Андрій', 'andriy@gmail.com', 5, 5),
('Олександр', 'alex@gmail.com', 6, 6),
('Юля', 'yulia@gmail.com', 7, 7),
('Катя', 'kate@gmail.com', 8, 8),
('Сергій', 'sergio@gmail.com', 9, 9),
('Вася', 'vasya@gmail.com', 10, 10),
('Олег', 'oleg@gmail.com', 11, 11);