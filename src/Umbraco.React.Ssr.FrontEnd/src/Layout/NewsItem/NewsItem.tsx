import { Card } from 'react-bootstrap'
import { useNavigate } from 'react-router-dom'
import { mediaEndpoint } from '../../Helpers/ApiHelper'
import Block from '../Block/Block'
import { NewsItemProps } from './NewsItemProps'

function NewsItem(props: any) {
  const newsItem = props.data as NewsItemProps;
  const navigate = useNavigate();
  return (
    <div style={{ background: '#c5cdd9', minHeight: '100vh' }}>
      <div className="container">
        <div className="d-flex flex-column">
          <Card className="col-md-8 p-lg-8 mx-auto my-5">
            <Card.Img
              variant="top"
              src={`${mediaEndpoint}${newsItem.imageSrc}`}
            />
            <Card.Body>
              <Card.Title>{newsItem.title}</Card.Title>
              <Card.Text>{newsItem.intro}</Card.Text>
            </Card.Body>
          </Card>
          {newsItem.blocks.map((block: any, index: number) => (
            <Block key={index} block={block} />
          ))}
          <button className="btn btn-secondary p-3 mb-5 mx-auto" onClick={() => navigate(-1)}>go back</button>
        </div>
      </div>
    </div>
  )
}

export default NewsItem
