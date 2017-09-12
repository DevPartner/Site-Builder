using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models;
using Nop.Core.Domain.Media;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{
    [AdminEntityTab("News")]
    [SystemName("NewsAttributes")]
    public class NewsModel : IDPTabModel
    {
        public Picture ThumbnailImageHome { get; set; }
    }
}