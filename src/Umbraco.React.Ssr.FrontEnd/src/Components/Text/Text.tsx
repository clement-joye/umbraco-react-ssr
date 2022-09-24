import { TextProps } from './TextProps'

function Text(props: { block: TextProps }) {
  const block = props.block
  return (
    <div
      className="col-md-8 p-lg-8 mx-auto my-5"
      style={{
        color: block.textColor !== undefined ? `#${block.textColor}` : '',
      }}
      dangerouslySetInnerHTML={{ __html: block.text }}
    />
  )
}

export default Text
