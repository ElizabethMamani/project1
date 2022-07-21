CREATE PROCEDURE SP_Course_Create
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