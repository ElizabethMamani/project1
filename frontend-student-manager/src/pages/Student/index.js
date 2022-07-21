import React from "react";
// import { useDispatch, useSelector } from "react-redux";
import Grid from "@mui/material/Grid";
import { Icon, Stack, Typography } from "@mui/material";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCalendar } from "@fortawesome/free-solid-svg-icons";
import Title from "../../components/Title";
import Information from "../../components/Information";
import ScheduleCard from "../../components/ScheduleCard";
// import { fetchStudents } from "../../redux/reducer/students";

function StudentPage() {
  const subject = {
    name: "backend",
    horary: "16:30 to 18:00",
    Instructor: "Raul Gamarra",
  };
  return (
    <div className="mt-4">
      <Title text="Student Name" />
      <Information type="student" />
      <Title text="Schendule and subjects" />
      <Grid container spacing={2} sx={{ justifyContent: "center" }}>
        <Grid item xs={2}>
          <Stack sx={{ marginTop: "10px" }} direction="row" spacing={2}>
            <Icon>
              <FontAwesomeIcon icon={faCalendar} color="#0066C3" />
            </Icon>
            <Typography gutterBottom variant="body2" component="div">
              Monday
            </Typography>
          </Stack>
        </Grid>
        <Grid item xs={2}>
          <Stack sx={{ marginTop: "10px" }} direction="row" spacing={2}>
            <Icon>
              <FontAwesomeIcon icon={faCalendar} color="#0066C3" />
            </Icon>
            <Typography gutterBottom variant="body2" component="div">
              Tuesday
            </Typography>
          </Stack>
          <Stack sx={{ marginTop: "10px" }} spacing={2}>
            <ScheduleCard subject={subject} />
          </Stack>
        </Grid>
        <Grid item xs={2}>
          <Stack sx={{ marginTop: "10px" }} direction="row" spacing={2}>
            <Icon>
              <FontAwesomeIcon icon={faCalendar} color="#0066C3" />
            </Icon>
            <Typography gutterBottom variant="body2" component="div">
              Wednesday
            </Typography>
          </Stack>
        </Grid>
        <Grid item xs={2}>
          <Stack sx={{ marginTop: "10px" }} direction="row" spacing={2}>
            <Icon>
              <FontAwesomeIcon icon={faCalendar} color="#0066C3" />
            </Icon>
            <Typography gutterBottom variant="body2" component="div">
              Thursday
            </Typography>
          </Stack>
          <Stack sx={{ marginTop: "10px" }} spacing={2}>
            <ScheduleCard subject={subject} />
          </Stack>
        </Grid>
        <Grid item xs={2}>
          <Stack sx={{ marginTop: "10px" }} direction="row" spacing={2}>
            <Icon>
              <FontAwesomeIcon icon={faCalendar} color="#0066C3" />
            </Icon>
            <Typography gutterBottom variant="body2" component="div">
              Friday
            </Typography>
          </Stack>
        </Grid>
      </Grid>
    </div>
  );
}

export default StudentPage;
