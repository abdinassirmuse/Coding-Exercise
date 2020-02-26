--CREATE DATABASE CodingAssessmentDB

USE CodingAssessmentDB



CREATE TABLE Users
(
UserName VARCHAR(20) PRIMARY KEY,
UserRole VARCHAR(20) NOT NULL,
UserPassword VARCHAR(25) NOT NULL
);
GO



INSERT INTO Users
Values('testc', 'Coordinator', 'password')
INSERT INTO Users
Values('abdinassir', 'Coordinator', 'password')
INSERT INTO Users
Values('testa', 'Attendee', 'password')


--DROP TABLE USERS

SELECT * FROM Users



CREATE TABLE EventList
(
EventId INT PRIMARY KEY IDENTITY(1,1),
EventName VARCHAR(50) NOT NULL,
EventDescription VARCHAR(150) NOT NULL,
EventStartDate DATE NOT NULL,
EventEndDate DATE CONSTRAINT check_eventenddate CHECK(EventEndDate > GETDATE()),
AddedBy VARCHAR(20) CONSTRAINT fk_username_eventadd REFERENCES Users(UserName)
);
GO

--DROP TABLE EventList


INSERT INTO EventList
VALUES('test event', 'This is a test event', '02-24-2020', '02-26-2020', 'abdinassir')
SELECT * FROM EventList
