ALTER PROCEDURE Select_By_Name_Subject
@SubjectName varchar(30)
AS
BEGIN
 SELECT SubjectId
 FROM Subject
 WHERE SubjectName=@SubjectName
 END