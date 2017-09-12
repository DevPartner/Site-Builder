using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models.Basic;
using Nop.Core.Domain.Media;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{
    [SystemName("DownloadModel")]
    [Parent("Content Management/Download", false)]
    [AdminMenu("DevCommerce/Download")]
    [Localazible]
    [SubjectToAcl]
    [Icon("fa-file")]
    public class DownloadModel : DPModel
    {
        public Download Download { get; set; }
    }
}
