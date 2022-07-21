CREATE PROCEDURE createStudent
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