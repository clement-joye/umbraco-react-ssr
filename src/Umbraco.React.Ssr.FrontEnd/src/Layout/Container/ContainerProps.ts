import { ImageProps } from 'react-bootstrap'
import { CallToActionProps } from '../../Components/CallToAction/CallToActionProps'
import { ListNewsProps } from '../../Components/ListNews/ListNewsProps'
import { TextProps } from '../../Components/Text/TextProps'
import { BlockProps } from '../Block/BlockProps'

export interface ContainerProps {
  backgroundColor: string
  width: number
  blocks: (
    | BlockProps
    | TextProps
    | ImageProps
    | CallToActionProps
    | ListNewsProps
  )[]
}
