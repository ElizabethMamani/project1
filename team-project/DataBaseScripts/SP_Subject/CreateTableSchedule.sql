 DROP TABLE Schedule
CREATE table Schedule (
   SubjectId            int                  not null,
   ScheduleId           int                  identity(1,1) not null,
   Day                  varchar(50)          not null,
   StartTime            datetime             not null,
   EndTime              datetime             not null,
   constraint pk_Schedule primary key (SubjectId, ScheduleId)
)
ALTER TABLE Schedule
ADD FOREIGN KEY(SubjectId) REFERENCES Subject(SubjectId)

 INSERT Schedule2 (SubjectId, Day, StartTime, EndTime)
 VALUES (100,'lunes', '1-5-2022', '1-5-2022')
 EXEC Add_Schedule 15, 'lunes', '1-5-2022', '1-5-2022'
