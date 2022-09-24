import React from 'react'
import { Link } from 'react-router-dom'
import { apiRequest } from '../../Helpers/ApiHelper'
import { ListNewsProps } from './ListNewsProps'
import { NewsItem } from './NewsItem'

function ListNews(props: { block: ListNewsProps }) {
  const [news, setNews] = React.useState<NewsItem[]>()

  React.useEffect(() => {
    apiRequest('News').then((response) => {
      setNews(response?.data)
    })
  }, [])

  const block = props.block

  return (
    <div className="container my-5 px-3">
      <h2
        style={{
          color: block.textColor !== undefined ? `#${block.textColor}` : '',
        }}
        className="mb-5"
      >
        News
      </h2>
      <ul className="list-group list-group-flush">
        {news?.map((item: NewsItem, index: number) => (
          <li
            key={index}
            className="list-group-item text-start bg-transparent px-0"
          >
            <Link to={item.url}>{item.title}</Link>
            <p
              style={{
                color:
                  block.textColor !== undefined ? `#${block.textColor}` : '',
              }}
            >
              {item.intro}
            </p>
          </li>
        ))}
      </ul>
    </div>
  )
}

export default ListNews
