import PropTypes from "prop-types";
import React from "react";
import { Card, Box, Icon, Stack, Typography } from "@mui/material";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import CardContent from "@mui/material/CardContent";
import { faUserSecret, faClock } from "@fortawesome/free-solid-svg-icons";

function ScheduleCard({ subject }) {
  const { name, horary, Instructor } = subject;
  return (
    <Card
      sx={{
        display: "flex",
        marginTop: "30px",
        maxHeight: 200,
      }}
    >
      <Box sx={{ display: "flex", flexDirection: "column" }}>
        <CardContent sx={{ flex: "1 0 auto", justifyContent: "center" }}>
          <Typography component="div" variant="h5">
            {name}
          </Typography>
          <Stack sx={{ marginTop: "10px" }} direction="row" spacing={2}>
            <Icon>
              <FontAwesomeIcon icon={faClock} color="#0066C3" />
            </Icon>
            <Typography gutterBottom variant="body2" component="div">
              {horary}
            </Typography>
          </Stack>
          <Stack sx={{ marginTop: "10px" }} direction="row" spacing={2}>
            <Icon>
              <FontAwesomeIcon icon={faUserSecret} color="#0066C3" />
            </Icon>
            <Typography gutterBottom variant="body2" component="div">
              {Instructor}
            </Typography>
          </Stack>
        </CardContent>
      </Box>
    </Card>
  );
}
ScheduleCard.defaultProps = {
  subject: {},
};

ScheduleCard.propTypes = {
  subject: PropTypes.shape({
    name: PropTypes.string,
    horary: PropTypes.string,
    Instructor: PropTypes.string,
  }),
};

export default ScheduleCard;
