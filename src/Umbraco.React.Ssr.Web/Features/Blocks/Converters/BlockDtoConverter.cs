using Umbraco.React.Ssr.Web.Features.Blocks.Dtos;
using Umbraco.React.Ssr.Web.Features.Blocks.Extensions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Umbraco.React.Ssr.Web.Features.Blocks.Converters
{
    public class BlockDtoConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(BlockDto);
        }

        public override JsonConverter CreateConverter(
            Type type,
            JsonSerializerOptions options)
        {
            return new BlockDtoJsonConverter();
        }
    }

    public class BlockDtoJsonConverter : JsonConverter<BlockDto>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(BlockDto).IsAssignableFrom(typeToConvert);

        public override BlockDto? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, BlockDto value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case TextBlockDto block:
                    writer.WriteTextBlock(block);
                    break;
                case ImageBlockDto block:
                    writer.WriteImageBlock(block);
                    break;
                case CallToActionBlockDto block:
                    writer.WriteCallToActionBlock(block);
                    break;
                case ListNewsBlockDto block:
                    writer.WriteLatestNewsBlock(block);
                    break;
            }
        }
    }
}
