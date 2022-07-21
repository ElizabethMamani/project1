import React from "react";
import Button from "@mui/material/Button";
import { Stack, IconButton } from "@mui/material";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faHouse } from "@fortawesome/free-solid-svg-icons";
import { Link } from "react-router-dom";

function Header() {
  return (
    <Stack
      direction="row"
      justifyContent="space-around"
      sx={{
        gap: { sm: "50px", xs: "40px" },

        mt: { sm: "32px", xs: "20px" },

        mb: { sm: "10px", xs: "10px" },

        justifyContent: "center",
      }}
      px="20px"
    >
      <Link
        to="/"
        style={{
          textDecoration: "none",
        }}
      >
        <IconButton>
          <FontAwesomeIcon icon={faHouse} color="#0066C3" />
        </IconButton>
      </Link>

      <Link
        to="/"
        style={{
          textDecoration: "none",
          color: "white",
        }}
      >
        <Button variant="contained"> Courses</Button>
      </Link>

      <Link
        to="/students"
        style={{
          textDecoration: "none",
          color: "white",
        }}
      >
        <Button variant="contained"> Students</Button>
      </Link>
    </Stack>
  );
}

export default Header;
