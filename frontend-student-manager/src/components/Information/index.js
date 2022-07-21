import PropTypes from "prop-types";
import React from "react";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import Stack from "@mui/material/Stack";
import { Box, Icon } from "@mui/material";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faCakeCandles,
  faEarthAmericas,
  faCalendarCheck,
  faCalendarXmark,
} from "@fortawesome/free-solid-svg-icons";
import courseImage from "../../assets/images/courseImage.png";
import userImage from "../../assets/images/userImage.png";
import ShowStatus from "../ShowStatus";

function Information({ type, student, course }) {
  const { name, Country, Email, BirthDate, Status } = student;
  const { Description, CourseName, StartDate, EndDate } = course;
  return (
    <div>
      {type === "course" ? (
        <Card sx={{ display: "flex", marginTop: "20px" }}>
          <CardMedia
            component="img"
            sx={{ width: 300, marginLeft: "20px" }}
            image={courseImage}
            alt="Course Image"
          />
          <Box sx={{ display: "flex", flexDirection: "column" }}>
            <CardContent sx={{ flex: "1 0 auto" }}>
              <Typography component="div" variant="h5">
                {CourseName}
              </Typography>
              <Typography
                variant="body1"
                color="text.secondary"
                component="div"
              >
                {StartDate}
                <br />
                {EndDate}
              </Typography>
              <ShowStatus State />
            </CardContent>
          </Box>
        </Card>
      ) : (
        <Card sx={{ display: "flex", marginTop: "20px" }}>
          <CardMedia
            component="img"
            sx={{ width: 300, marginLeft: "20px" }}
            image={userImage}
            alt="Course Image"
          />
          <Box sx={{ display: "flex", flexDirection: "column" }}>
            <CardContent sx={{ flex: "1 0 auto" }}>
              <Typography component="div" variant="h4">
                Student Information
              </Typography>
              <Typography gutterBottom variant="body1" component="div">
                {name}
              </Typography>
              <Typography variant="h7" color="#0066C3" gutterBottom>
                {Email}
              </Typography>
              <Stack sx={{ marginTop: "10px" }} direction="row" spacing={2}>
                <Icon>
                  <FontAwesomeIcon icon={faEarthAmericas} color="#0066C3" />
                </Icon>
                <Typography gutterBottom variant="body2" component="div">
                  {Country}
                </Typography>
              </Stack>
              <Stack direction="row" sx={{ marginTop: "10px" }} spacing={2}>
                <Icon>
                  <FontAwesomeIcon icon={faCakeCandles} color="#0066C3" />
                </Icon>
                <Typography variant="body2" color="text.secondary" gutterBottom>
                  {BirthDate}
                </Typography>
              </Stack>
              <ShowStatus State={Status} />
            </CardContent>
          </Box>
          <Box sx={{ display: "flex", flexDirection: "column" }}>
            <CardContent sx={{ flex: "1 0 auto" }}>
              <Typography component="div" variant="h4">
                Course Information
              </Typography>
              <Typography gutterBottom variant="body1" component="div">
                {CourseName}
              </Typography>
              <Typography variant="body2" color="#0066C3" gutterBottom>
                {Description}
              </Typography>
              <Stack sx={{ marginTop: "10px" }} direction="row" spacing={2}>
                <Icon>
                  <FontAwesomeIcon icon={faCalendarCheck} color="#0066C3" />
                </Icon>
                <Typography gutterBottom variant="body2" component="div">
                  {StartDate}
                </Typography>
              </Stack>
              <Stack direction="row" sx={{ marginTop: "10px" }} spacing={2}>
                <Icon>
                  <FontAwesomeIcon icon={faCalendarXmark} color="#0066C3" />
                </Icon>
                <Typography variant="body2" color="text.secondary" gutterBottom>
                  {EndDate}
                </Typography>
              </Stack>
            </CardContent>
          </Box>
        </Card>
      )}
    </div>
  );
}

Information.defaultProps = {
  type: "",
  student: {},
  course: {},
};

Information.propTypes = {
  type: PropTypes.string,
  student: PropTypes.shape({
    name: PropTypes.string,
    Email: PropTypes.string,
    Country: PropTypes.string,
    BirthDate: PropTypes.string,
    Status: PropTypes.bool,
  }),
  course: PropTypes.shape({
    CourseName: PropTypes.string,
    Description: PropTypes.string,
    StartDate: PropTypes.string,
    EndDate: PropTypes.string,
  }),
};

export default Information;
