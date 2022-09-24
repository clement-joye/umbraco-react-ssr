import React from "react"
import { useLocation } from "react-router-dom"
import { apiRequest } from "../../Helpers/ApiHelper"
import NewsItem from "../NewsItem/NewsItem"
import Page from "../Page/Page"

function Switch(props: { data: any }) {

  const [data, setData] = React.useState<any>(props.data)
  const location = useLocation()
  
  React.useEffect(() => {
    apiRequest(`Page?path=${location.pathname ?? "/"}`).then((response) => {
      setData(response?.data)
    })
  }, [location])

  switch (data?.type) {
    case 'page':
      return (<Page data={data} />)
    case 'newsItem':
      return (<NewsItem data={data} />)
  }
  return (null)
}

export default Switch
