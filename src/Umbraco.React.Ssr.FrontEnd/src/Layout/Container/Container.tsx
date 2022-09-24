import Block from '../Block/Block'
import { ContainerProps } from './ContainerProps'

function Container(props: { container: ContainerProps }) {
  const container = props.container
  return (
    <div
      className={`d-flex col-12 col-md-${container.width}`}
      style={{
        background:
          container.backgroundColor !== undefined
            ? `#${container.backgroundColor}`
            : '',
      }}
    >
      {container.blocks.map((block: any, index: number) => (
        <Block key={index} block={block} />
      ))}
    </div>
  )
}

export default Container
