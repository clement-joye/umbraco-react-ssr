using AutoMapper;
using Umbraco.React.Ssr.Web.Features.Blocks.Dtos;
using Umbraco.Cms.Core.Models.Blocks;
using ContentModels = Umbraco.Cms.Web.Common.PublishedModels;

namespace Umbraco.React.Ssr.Web.Features.Blocks.Extensions
{
    public static class BlockExtensions
    {
        public static IEnumerable<SectionDto> GetSections(this BlockListModel? sections, IMapper mapper)
        {
            if(sections == null || sections.Count == 0)
            {
                return Array.Empty<SectionDto>();
            }

            return sections
                .Select(x => x.Content)
                .Cast<ContentModels.Section>()
                .Select(x =>
                    new SectionDto
                    {
                        FullWidth = x.FullWidth,
                        BackgroundColor = x.BackgroundColor ?? "",
                        Title = x?.DisplayTitle ?? "",
                        Containers = x?.Containers != null
                            ? x.Containers.GetContainers(mapper)
                            : Array.Empty<ContainerDto>()
                    }
                ).ToArray();
        }

        public static IEnumerable<ContainerDto> GetContainers(this BlockListModel? containers, IMapper mapper)
        {
            if (containers == null || containers.Count == 0)
            {
                return Array.Empty<ContainerDto>();
            }

            return containers
                .Select(x => x.Content)
                .Cast<ContentModels.Container>()
                .Select(x =>
                    new ContainerDto
                    {
                        Width = Convert.ToInt32(x.Width),
                        BackgroundColor = x.BackgroundColor ?? "",
                        Title = x.DisplayTitle ?? "",
                        Blocks = x?.Blocks != null 
                            ? x.Blocks.GetBlocks(mapper) 
                            : Array.Empty<BlockDto>()
                    }
                ).ToArray();
        }

        public static IEnumerable<BlockDto> GetBlocks(this BlockListModel? blocks, IMapper mapper)
        {
            if (blocks == null || blocks.Count == 0)
            {
                return new List<BlockDto>();
            }

            var blockList = blocks.Select(x => x.Content switch
            {
                ContentModels.TextBlock textBlock => textBlock.GetTextBlock(mapper) as BlockDto,
                ContentModels.ImageBlock imageBlock => imageBlock.GetImageBlock(mapper) as BlockDto,
                ContentModels.CallToActionBlock callToActionBlock => callToActionBlock.GetCallToActionBlock(mapper) as BlockDto,
                ContentModels.ListNewsBlock latestNewsBlock => latestNewsBlock.GetLatestNewsBlock(mapper) as BlockDto,
                _ => throw new NotImplementedException()
            }).ToArray();

            return blockList;
        }

        public static TextBlockDto GetTextBlock(this ContentModels.TextBlock? textBlock, IMapper mapper)
        {
            if(textBlock == null)
            {
                return new TextBlockDto();
            }

            return mapper.Map<ContentModels.TextBlock, TextBlockDto>(textBlock);
        }

        private static ImageBlockDto GetImageBlock(this ContentModels.ImageBlock? imageBlock, IMapper mapper)
        {
            if (imageBlock == null)
            {
                return new ImageBlockDto();
            }

            return mapper.Map<ContentModels.ImageBlock, ImageBlockDto>(imageBlock, opts =>
                        opts.AfterMap(
                            (src, dest) => {
                                dest.ImageSrc = imageBlock.Image?.Url() ?? "";
                                dest.ImageAlt = imageBlock.Image?.Name() ?? "";
                            }));
        }

        public static CallToActionBlockDto GetCallToActionBlock(this ContentModels.CallToActionBlock? callToActionBlock, IMapper mapper)
        {
            if (callToActionBlock == null)
            {
                return new CallToActionBlockDto();
            }

            return mapper.Map<ContentModels.CallToActionBlock, CallToActionBlockDto>(callToActionBlock);
        }

        public static ListNewsBlockDto GetLatestNewsBlock(this ContentModels.ListNewsBlock? latestNewsBlock, IMapper mapper)
        {
            if (latestNewsBlock == null)
            {
                return new ListNewsBlockDto();
            }

            return mapper.Map<ContentModels.ListNewsBlock, ListNewsBlockDto>(latestNewsBlock);
        }
    }
}
