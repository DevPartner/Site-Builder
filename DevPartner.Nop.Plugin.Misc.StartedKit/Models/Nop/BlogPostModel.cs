using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models;
using Nop.Core.Domain.Media;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models.Nop
{
    [AdminEntityTab("blog-post")]
    [SystemName("BlogPostAttributes")]
    public class BlogPostModel : IDPTabModel
    {
        public Picture BlogThumbnailImage { get; set; }
        //[AttExtRefType("ProductTag")]
        //[EditorTemplate("SuggestionList")]
        //public int[] Tags { get; set; }
    }
}