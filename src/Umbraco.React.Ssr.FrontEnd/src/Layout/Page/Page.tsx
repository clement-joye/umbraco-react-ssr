import Section from '../Section/Section'
import { PageProps } from './PageProps'

function Page(props: any) {
  const page = props.data as PageProps
  return (
    <div
      className="d-flex flex-column"
      style={{ background: '#282c34', minHeight: '100vh' }}
    >
      {page?.sections?.map((section: any, index: number) => (
        <Section key={index} section={section} />
      ))}
    </div>
  )
}

export default Page
