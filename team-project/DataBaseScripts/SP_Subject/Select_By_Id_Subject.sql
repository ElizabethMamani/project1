ALTER PROCEDURE Select_By_Id_Subject
@SubjectId int
AS
BEGIN
 SELECT *
 FROM Subject
 WHERE SubjectId=@SubjectId
 END