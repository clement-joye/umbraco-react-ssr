using Umbraco.React.Ssr.Web.Features.Blocks.Dtos;
using System.Text.Json;

namespace Umbraco.React.Ssr.Web.Features.Blocks.Extensions
{
    public static class BlockJsonWriterExtensions
    {
        public static void WriteTextBlock(this Utf8JsonWriter writer, TextBlockDto block)
        {
            writer.WriteStartObject();
            writer.WriteString(CamelCase(nameof(block.Type)), block.Type);
            writer.WriteString(CamelCase(nameof(block.Text)), block.Text);
            writer.WriteString(CamelCase(nameof(block.TextColor)), block.TextColor);
            writer.WriteEndObject();
        }

        public static void WriteImageBlock(this Utf8JsonWriter writer, ImageBlockDto block)
        {
            writer.WriteStartObject();
            writer.WriteString(CamelCase(nameof(block.Type)), block.Type);
            writer.WriteString(CamelCase(nameof(block.ImageSrc)), block.ImageSrc);
            writer.WriteString(CamelCase(nameof(block.ImageAlt)), block.ImageAlt);
            writer.WriteEndObject();
        }

        public static void WriteCallToActionBlock(this Utf8JsonWriter writer, CallToActionBlockDto block)
        {
            writer.WriteStartObject();
            writer.WriteString(CamelCase(nameof(block.Type)), block.Type);
            writer.WriteString(CamelCase(nameof(block.Title)), block.Title);
            writer.WriteString(CamelCase(nameof(block.TitleColor)), block.TitleColor);
            writer.WriteString(CamelCase(nameof(block.BackgroundColor)), block.BackgroundColor);
            writer.WriteString(CamelCase(nameof(block.ButtonColor)), block.ButtonColor);
            writer.WriteString(CamelCase(nameof(block.ButtonText)), block.ButtonText);
            writer.WriteString(CamelCase(nameof(block.ButtonTextColor)), block.ButtonTextColor);
            writer.WriteString(CamelCase(nameof(block.ButtonLink)), block.ButtonLink);
            writer.WriteString(CamelCase(nameof(block.Text)), block.Text);
            writer.WriteString(CamelCase(nameof(block.TextColor)), block.TextColor);
            writer.WriteEndObject();
        }

        public static void WriteLatestNewsBlock(this Utf8JsonWriter writer, ListNewsBlockDto block)
        {
            writer.WriteStartObject();
            writer.WriteString(CamelCase(nameof(block.Type)), block.Type);
            writer.WriteString(CamelCase(nameof(block.BackgroundColor)), block.BackgroundColor);
            writer.WriteString(CamelCase(nameof(block.Display)), block.Display);
            writer.WriteString(CamelCase(nameof(block.DefaultNumber)), block.DefaultNumber);
            writer.WriteString(CamelCase(nameof(block.ShowDate)), block.ShowDate);
            writer.WriteString(CamelCase(nameof(block.ShowLabel)), block.ShowLabel);
            writer.WriteString(CamelCase(nameof(block.ShowIntro)), block.ShowIntro);
            writer.WriteString(CamelCase(nameof(block.ShowLink)), block.ShowLink);
            writer.WriteString(CamelCase(nameof(block.Title)), block.Title);
            writer.WriteString(CamelCase(nameof(block.TextColor)), block.TextColor);
            writer.WriteEndObject();
        }

        public static string CamelCase(string str)
        {
            return char.ToLowerInvariant(str[0]) + str[1..];
        }
    }
}
