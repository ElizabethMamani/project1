import React from "react";
import TextField from "@mui/material/TextField";
import { Paper, Typography } from "@mui/material";

function FormCourse() {
  //   const form = useForm({});

  return (
    <div style={{ marginBottom: "20px" }}>
      <Paper elevation={3}>
        <form>
          <div style={{ marginTop: "20px", backgroundColor: "#0066C1" }}>
            <Typography
              variant="h4"
              color="white"
              style={{ marginLeft: "40px" }}
            >
              Form Register Course
            </Typography>
          </div>
          <div style={{ marginLeft: "40px" }}>
            <TextField
              style={{ marginTop: "20px", marginBottom: "20px" }}
              label="Course Name"
            />
            <input type="date" />
          </div>
        </form>
      </Paper>
    </div>
  );
}

export default FormCourse;
