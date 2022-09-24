import { parseHtml } from '../../Helpers/ApiHelper'
import { CallToActionProps } from './CallToActionProps'

function CallToAction(props: { block: CallToActionProps }) {
  const block = props.block
  return (
    <div
      className="h-100 d-flex flex-row justify-content-center align-items-center"
      style={{
        background:
          block.backgroundColor !== undefined
            ? `#${block.backgroundColor}`
            : '',
      }}
    >
      <div className="col-md-8 p-lg-8 mx-auto my-5">
        <h1 className="display-4 fw-normal">{block.title}</h1>
        <p className="lead fw-normal">{parseHtml(block.text)}</p>
        <a
          style={{
            background:
              block.buttonColor !== undefined ? `#${block.buttonColor}` : '',
            color:
              block.buttonTextColor !== undefined
                ? `#${block.buttonTextColor}`
                : '',
          }}
          className="btn"
          href="/"
        >
          {block.buttonText}
        </a>
      </div>
    </div>
  )
}

export default CallToAction
