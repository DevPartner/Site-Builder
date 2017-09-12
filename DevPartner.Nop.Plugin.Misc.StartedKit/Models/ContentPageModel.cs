using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models.Basic;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{
    [SystemName("ContentPage")]
    [PublicPage("ContentPage", isSEO: true)]
    [AdminMenu("DevCommerce/Content")]
    [Parent("Content Management")]
    [Icon("fa-book")]
    [Localazible]
    [IsSearchable]
    public class ContentPageModel : DPPublicNavigationPageModel
    {
        [DPParent]
        public ContentPageModel Parent { get; set; }
    }
}
