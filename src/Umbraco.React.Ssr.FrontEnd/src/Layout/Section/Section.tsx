import Container from '../Container/Container'
import { SectionProps } from './SectionProps'

function Section(props: { section: SectionProps }) {
  const section = props.section
  return (
    <div
      style={{
        background:
          section.backgroundColor !== undefined
            ? `#${section.backgroundColor}`
            : '',
      }}
      className={`d-flex flex-row flex-wrap px-0 ${
        section.fullWidth === true ? 'w-100' : 'container'
      }`}
    >
      {section.containers.map((container: any, index: number) => (
        <Container key={index} container={container} />
      ))}
    </div>
  )
}

export default Section
