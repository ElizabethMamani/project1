import React, { useEffect, useState } from "react";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Box from "@mui/material/Box";
import { useParams } from "react-router-dom";
import { Typography } from "@mui/material";
import Grid from "@mui/material/Grid";
import Title from "../../components/Title";
import Information from "../../components/Information";
import subjects from "../../constants/subjects.constants";
import AppCard from "../../components/Card";
import { getCourseById, getSubjectsById } from "../../services/app.service";
import { getCourseAdapter, getSubjectAdapter } from "../../adapter";

function CoursePage() {
  const { courseId } = useParams();
  const [course, setCourse] = useState();
  const [listSub, setListSub] = useState([]);
  const [value, setValue] = React.useState("sb");
  const listStudents = subjects;
  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  function show(type) {
    switch (type) {
      case "subject":
        if (listSub.length === 0) {
          return (
            <Typography
              sx={{ marginTop: "80px", justifyContent: "center" }}
              variant="h3"
              color="initial"
            >
              Course List is Empty
            </Typography>
          );
        }
        return listSub.map((subject) => {
          return (
            <AppCard
              key={`subject${subject.SubjectId}`}
              name={subject.name}
              Days={subject.Days}
              Instructor={subject.Instructor}
              Horary={subject.Horary}
              StartDate={subject.StartDate}
              type="subject"
            />
          );
        });
      case "student":
        if (listStudents.length === 0) {
          return (
            <Typography
              sx={{ marginTop: "80px", justifyContent: "center" }}
              variant="h3"
              color="initial"
            >
              Student List is Empty
            </Typography>
          );
        }
        return (
          <Grid
            container
            sx={{ justifyContent: "center" }}
            spacing={{ xs: 0, md: 1 }}
            columns={{ xs: 6, sm: 10, md: 14 }}
          >
            {listStudents.map((subject) => {
              return (
                <Grid
                  item
                  xs={2}
                  sm={3}
                  md={4}
                  key={`course${subject.subjectId}`}
                >
                  <AppCard
                    key={`student${subject.subjectId}`}
                    name={subject.name}
                    Days={subject.Days}
                    Instructor={subject.Instructor}
                    Horary={subject.Horary}
                    StartDate={subject.StarDate}
                    type="student"
                  />
                </Grid>
              );
            })}
          </Grid>
        );
      default:
        return "";
    }
  }

  useEffect(() => {
    const getCourse = () => {
      if (course !== null) {
        getCourseById(courseId).then((response) => {
          const ob = getCourseAdapter(response.data);
          setCourse(ob);
        });
      }
    };
    getCourse();
  }, [course, courseId]);

  useEffect(() => {
    const getSubjects = () => {
      getSubjectsById(courseId).then((response) => {
        const list = getSubjectAdapter(response.data);
        console.log(list);
        setListSub(list);
      });
    };
    getSubjects();
  }, [courseId]);

  return (
    <div className="mt-4">
      <Title text="Courses" />
      <Information type="course" course={course} />
      <Box sx={{ width: "100%", marginTop: "20px" }}>
        <Tabs value={value} onChange={handleChange} variant="fullWidth">
          <Tab value="sb" label="Subject list" />
          <Tab value="st" label="Student list" />
        </Tabs>
      </Box>
      {value === "sb" ? show("subject") : show("student")}
    </div>
  );
}

export default CoursePage;
