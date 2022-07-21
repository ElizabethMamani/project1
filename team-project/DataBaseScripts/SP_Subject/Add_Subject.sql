ALTER PROCEDURE Add_Subject 
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