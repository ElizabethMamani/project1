CREATE PROCEDURE SP_Course_SelectAll
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