using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models.Basic;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{
    [AdminMenu("DevCommerce/Promotion")]
    [PublicPage("PromotionPage", includeInFooterColumn1: false, includeInFooterColumn2: false, includeInFooterColumn3: false, includeInMyAccountMenu: false, includeInSitemap: false, includeInTopMenu: false, isSEO: true)] // view path// view path
    [SystemName("Promotion")]
    [Localazible]
    [Icon("fa fa-newspaper-o")]
    [IsSearchable]
    [Parent("Content Management/Promotion", false)]
    public class PromotionModel : DPPublicFeaturedContentPageModel
    {
    }
}
