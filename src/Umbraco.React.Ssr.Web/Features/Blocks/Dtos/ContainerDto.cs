namespace Umbraco.React.Ssr.Web.Features.Blocks.Dtos
{
    public class ContainerDto
    {
        public string Type { get; set; } = "container";

        public int Width { get; set; }

        public string BackgroundColor { get; set; } = "";

        public string Title { get; set; } = "";

        public IEnumerable<BlockDto> Blocks { get; set; } = Array.Empty<BlockDto>();
    }
}
