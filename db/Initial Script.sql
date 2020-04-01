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
('���������� �1', '������ 1'),
('���������� �2', '������ 2'),
('���������� �3', '������ 3'),
('���������� �4', '������ 4'),
('���������� �5', '������ 5'),
('���������� �6', '������ 6'),
('���������� �7', '������ 7'),
('���������� �8', '������ 8'),
('���������� �9', '������ 9')

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
('������', 'vasyl@gmail.com', 4, 4),
('�����', 'andriy@gmail.com', 5, 5),
('���������', 'alex@gmail.com', 6, 6),
('���', 'yulia@gmail.com', 7, 7),
('����', 'kate@gmail.com', 8, 8),
('�����', 'sergio@gmail.com', 9, 9),
('����', 'vasya@gmail.com', 10, 10),
('����', 'oleg@gmail.com', 11, 11);