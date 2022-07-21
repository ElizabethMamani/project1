import React, { useEffect, useState } from "react";
import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import { useDispatch, useSelector } from "react-redux";
import Title from "../../components/Title";
import AppCard from "../../components/Card";
import { fetchStudents } from "../../redux/reducer/students";

function StudentsPage() {
  const [listStudents, setListStudents] = useState([]);
  const dispatch = useDispatch();
  const list = useSelector((state) => state.student.studentsList);
  useEffect(() => {
    if (list.length === 0) {
      dispatch(fetchStudents());
    } else if (list) {
      setListStudents(list);
    }
  }, [dispatch, list]);

  return (
    <div className="mt-4">
      <Title text="Students" />
      <div>
        <Grid
          container
          sx={{ justifyContent: "center" }}
          spacing={{ xs: 0, md: 1 }}
          columns={{ xs: 6, sm: 10, md: 14 }}
        >
          {listStudents.length !== 0 ? (
            listStudents.map((student) => {
              return (
                <Grid item xs={2} sm={4} md={4} key={student.StudentId}>
                  <AppCard
                    name={student.name}
                    Status={student.Status}
                    Country={student.Country}
                    Email={student.Email}
                    BirthDate={student.BirthDate}
                    type="student"
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
              Student List is Empty
            </Typography>
          )}
        </Grid>
      </div>
    </div>
  );
}

export default StudentsPage;
