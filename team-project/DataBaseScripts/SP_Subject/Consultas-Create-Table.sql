CREATE TABLE Subject (
  SubjectId int identity (1,1), 
  SubjectName varchar(30)
 )
 INSERT Subject (SubjectName)
 VALUES ('Ingles'),
		('DevOps'),
		('Frontend'),
		('Backend'),
		('Monitoring')
 EXEC Add_Subject 'DATABASE'
 EXEC Select_By_Id_Subject 5


DELETE Subject
DROP TABLE Subject
TRUNCATE TABLE Subject
SELECT * FROM Subject