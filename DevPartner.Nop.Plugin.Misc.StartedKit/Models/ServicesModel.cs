using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models.Basic;
using Nop.Core.Domain.Media;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{

    [AdminMenu("DevCommerce/Services")]
    [PublicPage("Services")] // todo view 
    [SystemName("Services")]
    [Localazible]
    [Icon("fa-wrench")]
    [Parent("Content Management/Service")]
    public class ServicesModel : DPPublicContentPageModel
    {
        public Picture ThumbnailImageHome { get; set; }
        
        public string HeroContent { get; set; }
        public string HeroIcon { get; set; }
        [DPParent]
        public ServicesModel Parent { get; set; }
        public string NavigationTitle { get; set; }
        [AttExtRefType("ProductTag")]
        [EditorTemplate("DropdownList")]
        public int[] Tags { get; set; }
    }
}
