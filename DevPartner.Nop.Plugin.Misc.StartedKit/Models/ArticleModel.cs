using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models.Basic;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{
    [AdminMenu("DevCommerce/Article")]
    [PublicPage("ArticlePage", includeInFooterColumn1: false, includeInFooterColumn2: false, includeInFooterColumn3: false, includeInMyAccountMenu: false, includeInSitemap: false, includeInTopMenu: false, isSEO: true)] // view path// view path
    [SystemName("Article")]
    [Localazible]
    [Icon("fa fa-newspaper-o")]
    [IsSearchable]
    [Parent("Content Management/Article", false)]
    public class ArticleModel : DPPublicFeaturedContentPageModel
    {
    }
}
