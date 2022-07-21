import React from "react";
import PropTypes from "prop-types";
import Stack from "@mui/material/Stack";
import { faCircle } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Icon } from "@mui/material";
import Typography from "@mui/material/Typography";

function ShowStatus({ State }) {
  return (
    <Stack direction="row" sx={{ marginTop: "10px" }} spacing={2}>
      <Icon>
        <FontAwesomeIcon
          icon={faCircle}
          color={State ? "#1C9027" : "#C1423A"}
        />
      </Icon>
      <Typography variant="body1" color={State ? "#1C9027" : "#C1423A"}>
        {State ? "Active" : "Inactive"}
      </Typography>
    </Stack>
  );
}

ShowStatus.defaultProps = {
  State: false,
};

ShowStatus.propTypes = {
  State: PropTypes.bool,
};

export default ShowStatus;
