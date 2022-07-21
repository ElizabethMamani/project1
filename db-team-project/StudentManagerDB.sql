CREATE DATABASE [StudentManagerDB]
GO
USE [StudentManagerDB]
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](30) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[ImageId] [varchar](20) NOT NULL,
 CONSTRAINT [pk_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Schedule](
	[SubjectId] [int] NOT NULL,
	[ScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[Day] [varchar](50) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
 CONSTRAINT [pk_Schedule] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC,
	[ScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NULL,
	[StudentName] [varchar](40) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[Country] [varchar](20) NOT NULL,
	[ImageId] [varchar](20) NULL,
 CONSTRAINT [pk_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Subject](
	[CourseId] [int] NOT NULL,
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [varchar](40) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[Instructorname] [varchar](40) NOT NULL,
	[ImageId] [varchar](20) NOT NULL,
 CONSTRAINT [pk_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [fk_Student_has_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [fk_Student_has_Course]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [fk_Subject_have_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [fk_Subject_have_Course]
GO

CREATE PROCEDURE [dbo].[Add_Subject]
@CourseId int, 
@SubjectName  varchar(30), 
@StartDate  datetime, 
@Instructorname  varchar(30), 
@ImageId  varchar(30)
AS
BEGIN
 INSERT Subject (CourseId, SubjectName, StartDate, Instructorname, ImageId)
 VALUES (@CourseId, @SubjectName, @StartDate, @Instructorname, @ImageId)
 END
GO

CREATE PROCEDURE [dbo].[createStudent]
       @StudentName VARCHAR(40),
       @CourseId int =NULL,
       @Email varchar(30),
       @BirthDate datetime,
       @Country varchar(20),
       @ImageId varchar(20)
AS
BEGIN
DECLARE @StudentId int
IF @CourseId != NULL
       INSERT  INTO Student
              (StudentName,CourseId,Email,BirthDate,Country,ImageId)
       VALUES
              (@StudentName, @CourseId, @Email, @BirthDate, @Country, @ImageId)
ELSE
       INSERT  INTO Student
              (StudentName,Email,BirthDate,Country,ImageId)
       VALUES
              (@StudentName, @Email, @BirthDate, @Country, @ImageId)

SET @StudentId =SCOPE_IDENTITY ()
SELECT * FROM  Student WHERE StudentId=@StudentId
END
GO

CREATE PROCEDURE [dbo].[getStudent]
    @StudentId int
AS
BEGIN
    SELECT *
    FROM Student
    WHERE StudentId=@StudentId
END
GO

CREATE PROCEDURE [dbo].[relationStudentCourse]
    @StudentId int,
    @CourseId int
AS
BEGIN
    UPDATE Student
    SET CourseId=@CourseId
    WHERE StudentId=@StudentId
END
GO

CREATE PROCEDURE [dbo].[Select_By_Id_Course_Subjects]
@CourseId int
AS
BEGIN
 SELECT *
 FROM Subject
 WHERE CourseId=@CourseId
 END
GO

CREATE PROCEDURE [dbo].[Select_By_Id_Schedule]
@SubjectId int
AS
BEGIN
 SELECT *
 FROM Schedule
 WHERE SubjectId=@SubjectId
 END

GO

CREATE PROCEDURE [dbo].[Select_By_Id_Subject]
@SubjectId int
AS
BEGIN
 SELECT *
 FROM Subject
 WHERE SubjectId=@SubjectId
 END
GO

CREATE PROCEDURE [dbo].[Select_By_Name_Subject]
@SubjectName varchar(30)
AS
BEGIN
 SELECT SubjectId
 FROM Subject
 WHERE SubjectName=@SubjectName
 END
GO

CREATE PROCEDURE [dbo].[Add_Schedule] 
@SubjectId int, 
@Day  varchar(30), 
@StartTime  datetime, 
@EndTime  datetime
AS
BEGIN
 INSERT Schedule (SubjectId, Day, StartTime, EndTime)
 VALUES (@SubjectId, @Day, @StartTime, @EndTime)
 END
GO

CREATE PROCEDURE [dbo].[SP_Course_Create]
	@CourseName VARCHAR(30),
	@StartDate DATETIME,
	@EndDate DATETIME,
	@Description VARCHAR(50),
	@ImageId VARCHAR(20)
AS 
BEGIN
DECLARE @CourseId INT
INSERT INTO Course ( CourseName, StartDate, EndDate, Description, ImageId)
VALUES ( @CourseName, @StartDate, @EndDate, @Description, @ImageId)
SET @CourseId = SCOPE_IDENTITY()
SELECT CourseId, CourseName, StartDate, EndDate, Description, ImageId
FROM Course
WHERE CourseId = @CourseId
END
GO

CREATE PROCEDURE [dbo].[SP_Course_Delete]
	@CourseId INT
AS 
BEGIN
DELETE FROM Course
WHERE CourseId = @CourseId
END
GO

CREATE PROCEDURE [dbo].[SP_Course_Edit]
	@CourseId INT,
	@CourseName VARCHAR(30) = NULL,
	@StartDate DATETIME = NULL,
	@EndDate DATETIME = NULL,
	@Description VARCHAR(50) = NULL,
	@ImageId VARCHAR(20) = NULL
AS 
BEGIN
UPDATE Course
	SET CourseName = ISNULL(@CourseName, CourseName),
		StartDate = ISNULL(@StartDate, StartDate),
		EndDate = ISNULL(@EndDate, EndDate),
		Description = ISNULL(@Description, Description),
		ImageId = ISNULL(@ImageId, ImageId)
WHERE CourseId = @CourseId
END
GO

CREATE PROCEDURE [dbo].[SP_Course_Select]
	@CourseId INT
AS 
BEGIN
SELECT CourseId, CourseName, StartDate, EndDate, Description, ImageId
FROM Course
WHERE CourseId = @CourseId
END
GO

CREATE PROCEDURE [dbo].[SP_Course_SelectAll]
	@StartDate DATETIME = NULL,
	@EndDate DATETIME = NULL,
	@CourseName VARCHAR(30) = NULL
AS 
BEGIN
SELECT CourseId, CourseName, StartDate, EndDate, Description, ImageId
FROM Course
WHERE (@StartDate IS NULL OR StartDate = @StartDate)
	AND(@EndDate IS NULL OR EndDate = @EndDate)
	AND(@CourseName IS NULL OR CourseName = @CourseName)
END
GO

CREATE PROCEDURE [dbo].[getAllStudents]
AS
SELECT StudentId, CourseId,	StudentName, Email, BirthDate, Country, ImageId
FROM Student
GO

EXEC SP_Course_Create 'Dev 35 - Level 2', '2022-01-25', '2022-12-25','The objective of this course is to train full stack developers.', 'URL for image'
go
EXEC SP_Course_SelectAll
go
EXEC Add_Subject 1, 'Backend', '2022-04-25', 'Raul Gamarra', 'URL for photography'
EXEC Add_Subject 1, 'Frontend', '2022-04-25', 'Amilkar Contreras', 'URL for photography'
EXEC Add_Subject 1, 'DevOps', '2022-04-25', 'Alejandro Sanchez', 'URL for photography'
EXEC Add_Subject 1, 'Monitoring', '2022-04-25', 'Jose Ecos', 'URL for photography'
go

EXEC Add_Schedule 1, 'Tuesday', '1999-01-01 16:30:00', '1999-01-01 18:00:00'
EXEC Add_Schedule 1, 'Thursday', '1999-01-01 16:30:00', '1999-01-01 18:00:00'
EXEC Add_Schedule 2, 'Monday', '1999-01-01 17:00:00', '1999-01-01 18:00:00'
EXEC Add_Schedule 2, 'Wednesday', '1999-01-01 17:00:00', '1999-01-01 18:00:00'
EXEC Add_Schedule 2, 'Friday', '1999-01-01 17:00:00', '1999-01-01 18:00:00'
EXEC Add_Schedule 3, 'Monday', '1999-01-01 09:00:00', '1999-01-01 10:00:00'
EXEC Add_Schedule 3, 'Wednesday', '1999-01-01 09:00:00', '1999-01-01 10:00:00'
EXEC Add_Schedule 3, 'Friday', '1999-01-01 09:00:00', '1999-01-01 10:00:00'
EXEC Add_Schedule 4, 'Monday', '1999-01-01 10:00:00', '1999-01-01 11:00:00'
EXEC Add_Schedule 4, 'Tuesday', '1999-01-01 10:00:00', '1999-01-01 11:00:00'
EXEC Add_Schedule 4, 'Wednesday', '1999-01-01 10:00:00', '1999-01-01 11:00:00'
EXEC Add_Schedule 4, 'Thursday', '1999-01-01 10:00:00', '1999-01-01 11:00:00'
EXEC Add_Schedule 4, 'Friday', '1999-01-01 10:00:00', '1999-01-01 11:00:00'

EXEC createStudent 'Esteban Alberto Casablanca Contreras', null, 'estebancasablanca@gmail.com', '1996-05-12', 'Bolivia', 'URL for photography'
EXEC createStudent 'Juana Carolina Monasterios Diaz', null, 'carolinamonasterios@gmail.com', '1998-12-28', 'Bolivia', 'URL for photography'
EXEC createStudent 'Magadalena Sofia Flores Hidalgo', null, 'magisofiafloreshidalgo@gmail.com', '1996-03-17', 'Peru', 'URL for photography'

EXEC getAllStudents

EXEC relationStudentCourse 1, 1
EXEC relationStudentCourse 2, 1
EXEC relationStudentCourse 3, 1
