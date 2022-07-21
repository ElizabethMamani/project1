import PropTypes from "prop-types";
import React from "react";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import CardHeader from "@mui/material/CardHeader";
import IconButton from "@mui/material/IconButton";
import { Box, Icon } from "@mui/material";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faEllipsisVertical,
  faCakeCandles,
  faEarthAmericas,
  faCalendar,
  faUserSecret,
  faAddressCard,
  faClock,
} from "@fortawesome/free-solid-svg-icons";
import Stack from "@mui/material/Stack";
import { Link } from "react-router-dom";
import userImage from "../../assets/images/userImage.png";
import courseImage from "../../assets/images/courseImage.png";
import subjectImage from "../../assets/images/subjectImage.jpg";
import ShowStatus from "../ShowStatus";
import MenuCard from "./MenuCard";

function AppCard({
  id,
  name,
  Email,
  BirthDate,
  Instructor,
  Country,
  Horary,
  Days,
  Status,
  StartDate,
  type,
  Description,
}) {
  function renderSwitch() {
    switch (type) {
      case "course":
        return (
          <div>
            <Card sx={{ maxWidth: 345, maxHeight: 500 }}>
              <CardHeader
                action={<MenuCard id={id} />}
                title={name}
                subheader={`Start at ${StartDate}`}
              />
              <CardMedia
                component="img"
                height="140"
                image={courseImage}
                alt="Course image"
              />
              <CardContent>
                <Typography variant="body2" color="text.secondary">
                  {Description}
                </Typography>
                <ShowStatus State={Status} />
              </CardContent>
            </Card>
          </div>
        );
      case "student":
        return (
          <Card sx={{ maxWidth: 345, maxHeight: 500 }}>
            <CardHeader
              action={
                <IconButton aria-label="settings">
                  <FontAwesomeIcon icon={faEllipsisVertical} />
                </IconButton>
              }
            />
            <CardMedia
              component="img"
              height="140"
              image={userImage}
              alt="Student image"
            />
            <CardContent sx={{ flex: "1 0 auto" }}>
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
              <Stack
                direction="row"
                sx={{ marginTop: "10px", justifyContent: "end" }}
                spacing={2}
              >
                <Link
                  to={`/students/${id}`}
                  style={{
                    textDecoration: "none",
                  }}
                >
                  <IconButton>
                    <FontAwesomeIcon icon={faAddressCard} color="#0066C3" />
                    <Typography
                      variant="body2"
                      color="text.secondary"
                      gutterBottom
                    >
                      &nbsp;Perfil
                    </Typography>
                  </IconButton>
                </Link>
              </Stack>
            </CardContent>
          </Card>
        );
      case "subject":
        return (
          <Card
            sx={{
              display: "flex",
              marginTop: "30px",
              maxHeight: 200,
            }}
          >
            <CardMedia
              component="img"
              sx={{
                width: 200,
                height: 200,
                marginLeft: "20px",
                objectPosition: "30% 100%",
                objectFit: "cover",
                borderRadius: "50%",
              }}
              image={subjectImage}
              alt="Subject image"
            />
            <Box sx={{ display: "flex", flexDirection: "column" }}>
              <CardContent sx={{ flex: "1 0 auto", justifyContent: "center" }}>
                <Typography component="div" variant="h5">
                  {name}
                </Typography>
                <Stack sx={{ marginTop: "10px" }} direction="row" spacing={2}>
                  <Icon>
                    <FontAwesomeIcon icon={faCalendar} color="#0066C3" />
                  </Icon>
                  <Typography gutterBottom variant="body2" component="div">
                    {Days}
                  </Typography>
                  <Icon>
                    <FontAwesomeIcon icon={faUserSecret} color="#0066C3" />
                  </Icon>
                  <Typography gutterBottom variant="body2" component="div">
                    {Instructor}
                  </Typography>
                </Stack>
                <Stack sx={{ marginTop: "10px" }} direction="row" spacing={2}>
                  <Icon>
                    <FontAwesomeIcon icon={faClock} color="#0066C3" />
                  </Icon>
                  <Typography gutterBottom variant="body2" component="div">
                    {Horary}
                  </Typography>
                  <Icon>
                    <FontAwesomeIcon icon={faCalendar} color="#0066C3" />
                  </Icon>
                  <Typography gutterBottom variant="body2" component="div">
                    {StartDate}
                  </Typography>
                </Stack>
              </CardContent>
            </Box>
          </Card>
        );
      default:
        return "error";
    }
  }

  return <div>{renderSwitch()}</div>;
}

AppCard.defaultProps = {
  id: 0,
  name: "",
  Email: "",
  BirthDate: "",
  Country: "",
  Status: false,
  type: "",
  Days: "",
  Horary: "",
  Instructor: "",
  StartDate: "",
  Description: "",
};

AppCard.propTypes = {
  id: PropTypes.number,
  name: PropTypes.string,
  Email: PropTypes.string,
  BirthDate: PropTypes.string,
  Country: PropTypes.string,
  Status: PropTypes.bool,
  type: PropTypes.string,
  Days: PropTypes.string,
  Horary: PropTypes.string,
  Instructor: PropTypes.string,
  StartDate: PropTypes.string,
  Description: PropTypes.string,
};

export default AppCard;
