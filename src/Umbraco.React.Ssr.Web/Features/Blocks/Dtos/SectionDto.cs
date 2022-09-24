namespace Umbraco.React.Ssr.Web.Features.Blocks.Dtos
{
    public class SectionDto
    {
        public string Type { get; set; } = "section";

        public bool FullWidth { get; set; }

        public string BackgroundColor { get; set; } = "";

        public string Title { get; set; } = "";

        public IEnumerable<ContainerDto> Containers { get; set; } = Array.Empty<ContainerDto>();
    }
}
