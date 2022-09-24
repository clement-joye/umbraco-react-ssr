import express from 'express'
import React from 'react'
import ReactDOMServer from 'react-dom/server'
import App from '../src/App'

const PORT = 3000

const server = express()
server.use(express.json());
server.use(express.urlencoded({ extended: true }));

const router = express.Router();

router.use('^/$', (req, res, next) => {
  console.log(req.body)
  const component = ReactDOMServer.renderToString(
    React.createElement(App, { data: req.body })
  )
  res.send(component)
});

server.use(router);

server.listen(PORT, () => {
  console.log(`Server running on http://localhost:${PORT}`)
})