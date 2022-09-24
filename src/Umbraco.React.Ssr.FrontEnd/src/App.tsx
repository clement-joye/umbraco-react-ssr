import NavBar from './Layout/NavBar/NavBar'
import Router from './Layout/Router/Router'
import Switch from './Layout/Switch/Switch'
import './App.scss'

export default function App(props: { data?: any | undefined }) { // our payload is injected here
  const data = props?.data
  return(
    <div className="App">
      <Router>
        <NavBar />
        <Switch data={data}/>
      </Router>
    </div>
  )
}
