using System.ComponentModel.DataAnnotations;
using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models.Basic;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{
    [SystemName("RedirectPage")]
    [PublicPage("RedirectPage")]
    [AdminMenu("DevCommerce/RedirectPage")]
    [Parent("Content Management")]
    [Icon("fa-reply")]
    [Localazible]
    public class RedirectPageModel : DPPublicNavigationPageModel
    {
        [Required]
        public string RedirectURL { get; set; }

        [DPParent]
        public ContentPageModel Parent { get; set; }
    }
}
