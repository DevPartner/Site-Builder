using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models;
using DevPartner.Nop.Plugin.Core.Models.Basic;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{
    [SystemName("GalleryPageTemplate")]
    [Parent("System/CMS/GalleryPageTemplate")]
    [AdminMenu("DevCommerce/Module/GalleryPageTemplate")]
    public class GalleryPageTemplateModel : DPModel, IDPRenderingModel
    {
        public string Path { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
