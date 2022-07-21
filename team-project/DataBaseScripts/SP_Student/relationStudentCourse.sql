CREATE PROCEDURE relationStudentCourse
    @StudentId int,
    @CourseId int
AS
BEGIN
    UPDATE Student
    SET CourseId=@CourseId
    WHERE StudentId=@StudentId
END
