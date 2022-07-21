CREATE PROCEDURE SP_Course_Delete
	@CourseId INT
AS 
BEGIN
DELETE FROM Course
WHERE CourseId = @CourseId
END