CREATE PROCEDURE Select_By_Id_Schedule
@SubjectId int
AS
BEGIN
 SELECT *
 FROM Schedule2
 WHERE SubjectId=@SubjectId
 END

