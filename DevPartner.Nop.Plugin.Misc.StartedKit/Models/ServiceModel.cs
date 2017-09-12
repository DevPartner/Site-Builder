using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models.Basic;
using Nop.Core.Domain.Media;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{
    [PublicPage("Service")] // todo view 
    [SystemName("Service")]
    [Parent("Content Management/Services")]
    [Localazible]
    public class ServiceModel : DPPublicContentPageModel
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
