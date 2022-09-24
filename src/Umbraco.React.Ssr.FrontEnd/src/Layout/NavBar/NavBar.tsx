import React from 'react'
import { Link } from 'react-router-dom'
import { apiRequest } from '../../Helpers/ApiHelper'
import Container from 'react-bootstrap/Container'
import Navbar from 'react-bootstrap/Navbar'
import Nav from 'react-bootstrap/Nav'
import logo from '../../logo.svg'

function NavBar() {
  const [items, setitems] = React.useState<
    { isVisible: boolean; text: string; link: string }[]
  >([])

  React.useEffect(() => {
    apiRequest('NavigationItems').then((response) => {
      setitems(response?.data?.items)
    })
  }, [])

  return (
    <>
      <Navbar bg="dark" variant="dark">
        <Container>
          <Navbar.Brand href="/">
            <img
              alt=""
              src={logo}
              width="30"
              height="30"
              className="d-inline-block align-top"
            />{' '}
            SSR Umbraco React
          </Navbar.Brand>
          <Nav className="me-auto">
            {items
              ?.filter((x: any) => x.isVisible)
              .map((x: any, index: number) => {
                return (
                  <Link key={index} className="nav-link" to={x.link}>{x.text}</Link>
                )
              })}
          </Nav>
        </Container>
      </Navbar>
    </>
  )
}

export default NavBar
