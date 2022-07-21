INSERT Course(CourseName, StartDate, EndDate, Description, ImageId)
VALUES ('DEV35', ('1-8-2022'),('1-12-2022'), 'DEV35', 'src/image/image3.jpg')
SELECT * FROM Course

INSERT Subject (CourseId, SubjectName, StartDate, Instructorname, ImageId)
VALUES (3,'Ingles', ('1-2-2022'), 'Lisa', 'src/image/image.jpg')
SELECT * FROM Subject

EXEC Select_By_Id_Subject 4
EXEC Add_Subject 3,'NEURONAL', '1-5-2022', 'Margi', 'src/image/image3.jpg'