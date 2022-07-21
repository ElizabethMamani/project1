CREATE PROCEDURE Add_Schedule 
@SubjectId int, 
@Day  varchar(30), 
@StartTime  datetime, 
@EndTime  datetime
AS
BEGIN
 INSERT Schedule (SubjectId, Day, StartTime, EndTime)
 VALUES (@SubjectId, @Day, @StartTime, @EndTime)
 END
