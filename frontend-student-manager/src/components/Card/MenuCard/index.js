import PropTypes from "prop-types";
import React from "react";
// import Button from "@mui/material/Button";
import Menu from "@mui/material/Menu";
import MenuItem from "@mui/material/MenuItem";
import IconButton from "@mui/material/IconButton";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faEllipsisVertical,
  faEye,
  faPen,
  faTrash,
} from "@fortawesome/free-solid-svg-icons";
import { Button } from "@mui/material";

function MenuCard({ id }) {
  const [anchorEl, setAnchorEl] = React.useState(null);
  const open = Boolean(anchorEl);
  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };
  // const redirect = `/courses/${id}`;
  return (
    <div>
      <IconButton
        id="basic-button"
        aria-label="settings"
        aria-controls={open ? "basic-menu" : undefined}
        aria-expanded={open ? "true" : undefined}
        onClick={handleClick}
      >
        <FontAwesomeIcon icon={faEllipsisVertical} />
      </IconButton>
      <Menu
        id="basic-menu"
        anchorEl={anchorEl}
        open={open}
        onClose={handleClose}
        transformOrigin={{
          horizontal: "right",
          vertical: "top",
        }}
        MenuListProps={{
          "aria-labelledby": "basic-button",
        }}
      >
        <MenuItem>
          <FontAwesomeIcon icon={faEye} />
          <Button href={`/courses/${id}`}>&nbsp;View</Button>
        </MenuItem>

        <MenuItem onClick={handleClose}>
          <FontAwesomeIcon icon={faPen} />
          &nbsp;Edit
        </MenuItem>
        <MenuItem onClick={handleClose}>
          <FontAwesomeIcon icon={faTrash} />
          &nbsp;Delete
        </MenuItem>
      </Menu>
    </div>
  );
}

MenuCard.defaultProps = {
  id: 0,
};

MenuCard.propTypes = {
  id: PropTypes.number,
};

export default MenuCard;
