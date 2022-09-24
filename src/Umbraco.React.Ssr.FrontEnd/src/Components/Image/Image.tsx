import { mediaEndpoint } from '../../Helpers/ApiHelper'
import { ImageProps } from './ImageProps'

function Image(props: { block: ImageProps }) {
  const block = props.block
  return (
    <div className="w-100 h-100 d-flex flex-row justify-content-center align-items-center">
      <img
        src={mediaEndpoint + block.imageSrc}
        className="img-fluid image-spin"
        alt={block.imageAlt}
      ></img>
    </div>
  )
}

export default Image
