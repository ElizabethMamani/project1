CREATE PROCEDURE getStudent
    @StudentId int
AS
BEGIN
    SELECT *
    FROM Student
    WHERE StudentId=@StudentId
END