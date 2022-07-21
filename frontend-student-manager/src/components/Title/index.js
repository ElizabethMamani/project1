import PropTypes from "prop-types";
import React from "react";
import { Typography } from "@mui/material";

function Title({ text }) {
  return (
    <div
      style={{
        backgroundColor: "#0066C3",
        textAlign: "start",
        borderRadius: "4px",
      }}
    >
      <Typography
        variant="h2"
        component="div"
        style={{
          fontStyle: "bold",
          color: "white",
          marginLeft: "40px",
        }}
      >
        {text}
      </Typography>
    </div>
  );
}

Title.defaultProps = {
  text: "",
};

Title.propTypes = {
  text: PropTypes.string,
};

export default Title;
