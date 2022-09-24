import { BrowserRouter } from "react-router-dom"
import { StaticRouter } from "react-router-dom/server"

function Router(props: { children: any }) {
  return typeof document === 'undefined'
    ? (
      <StaticRouter location={'/'}>
        {props.children}
      </StaticRouter>
    ) 
    : (
      <BrowserRouter>
        {props.children}
      </BrowserRouter>
    )
}

export default Router
