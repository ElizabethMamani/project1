CREATE PROCEDURE Select_By_Id_Course_Subjects
@CourseId int
AS
BEGIN
 SELECT *
 FROM Subject
 WHERE CourseId=@CourseId
 END
