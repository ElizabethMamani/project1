CREATE PROCEDURE SP_Course_Select
	@CourseId INT
AS 
BEGIN
SELECT CourseId, CourseName, StartDate, EndDate, Description, ImageId
FROM Course
WHERE CourseId = @CourseId
END