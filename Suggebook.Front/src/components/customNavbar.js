import React from "react";
import { Navbar, Nav, NavItem } from "react-bootstrap";
import {Link} from 'react-router-dom'

function CustomNavbar() {
  return (
    <Navbar collapseOnSelect variant="dark" expand="lg">
      <Navbar.Brand href="/">SuggeBook</Navbar.Brand>
      <Nav className="mr-auto justify-content-center">
        <NavItem>
          <Link to="/">Accueil</Link>
        </NavItem>
      </Nav>
    </Navbar>
  );
}

export default CustomNavbar;
