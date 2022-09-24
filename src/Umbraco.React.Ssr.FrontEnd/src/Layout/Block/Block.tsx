import CallToAction from '../../Components/CallToAction/CallToAction'
import Image from '../../Components/Image/Image'
import ListNews from '../../Components/ListNews/ListNews'
import Text from '../../Components/Text/Text'

function Block(props: { block: any }) {
  const block = props.block
  switch (block.type) {
    case 'text':
      return <Text block={block} />
    case 'image':
      return <Image block={block} />
    case 'callToAction':
      return <CallToAction block={block} />
    case 'listNews':
      return <ListNews block={block} />
    default:
      return null
  }
}

export default Block
