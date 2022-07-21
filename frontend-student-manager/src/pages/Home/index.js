import React, { useState, useEffect } from "react";
import Grid from "@mui/material/Grid";
import { useDispatch, useSelector } from "react-redux";
import { Typography, Button } from "@mui/material";
import Title from "../../components/Title";
import AppCard from "../../components/Card";
import FormCourse from "../../components/Form";
import { fetchCourses } from "../../redux/reducer/course";

function HomePage() {
  const [listCourses, setListCourses] = useState([]);
  const dispatch = useDispatch();
  const list = useSelector((state) => state.course.coursesList);
  useEffect(() => {
    if (list.length === 0) {
      dispatch(fetchCourses());
    } else {
      setListCourses(list);
    }
  }, [dispatch, list, listCourses]);
  const [registerState, setRegisterState] = useState(false);

  const handleChangeClick = () => {
    setRegisterState(!registerState);
  };
  return (
    <div className="mt-4">
      <Grid container spacing={2}>
        <Grid item xs={11}>
          <Title text="Courses" />
        </Grid>
        <Grid item xs={1}>
          <Button size="large" variant="contained" onClick={handleChangeClick}>
            {!registerState ? "Register Course" : "Cancel Register"}
          </Button>
        </Grid>
      </Grid>
      {registerState ? <FormCourse /> : ""}
      <Grid
        container
        sx={{ justifyContent: "center" }}
        spacing={{ xs: 0, md: 1 }}
        columns={{ xs: 6, sm: 10, md: 14 }}
      >
        {listCourses.length !== 0 ? (
          listCourses.map((course) => {
            return (
              <Grid item xs={2} sm={3} md={4} key={`course${course.CourseId}`}>
                <AppCard
                  id={course.CourseId}
                  name={course.name}
                  Status={course.Status}
                  StartDate={course.StartDate}
                  Description={course.Description}
                  type="course"
                />
              </Grid>
            );
          })
        ) : (
          <Typography
            sx={{ marginTop: "80px", justifyContent: "center" }}
            variant="h3"
            color="initial"
          >
            Course List is Empty
          </Typography>
        )}
      </Grid>
    </div>
  );
}

export default HomePage;
