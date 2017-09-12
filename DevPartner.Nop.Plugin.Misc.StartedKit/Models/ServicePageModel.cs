using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models.Basic;
using DevPartner.Nop.Plugin.Core.Models.Basic;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{
    [AdminMenu("DevCommerce/ServicePage")]
    [PublicPage("ServicePage", includeInFooterColumn1: false, includeInFooterColumn2: false, includeInFooterColumn3: false, includeInMyAccountMenu: false, includeInSitemap: false, includeInTopMenu: false, isSEO: true)] // view path// view path
    [SystemName("ServicePage")]
    [Localazible]
    [Icon("fa fa-newspaper-o")]
    [IsSearchable]
    [Parent("Content Management/Service", false)]
    public class ServicePageModel : DPPublicFeaturedContentPageModel
    {

    }
}
