import { ImageProps } from 'react-bootstrap'
import { CallToActionProps } from '../../Components/CallToAction/CallToActionProps'
import { ListNewsProps } from '../../Components/ListNews/ListNewsProps'
import { TextProps } from '../../Components/Text/TextProps'
import { BlockProps } from '../Block/BlockProps'

export interface NewsItemProps {
  id: number
  type: string
  title: string
  intro: string
  url: string
  imageSrc: string
  labels: string[]
  blocks: (
    | BlockProps
    | TextProps
    | ImageProps
    | CallToActionProps
    | ListNewsProps
  )[]
}
