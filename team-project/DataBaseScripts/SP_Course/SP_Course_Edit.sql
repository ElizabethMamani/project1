CREATE PROCEDURE SP_Course_Edit
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