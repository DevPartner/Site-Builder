using System.Collections.Generic;
using DevPartner.Nop.Plugin.Core.Models.Basic;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models.ViewModels
{
    public class GalleryPageViewModel
    {
        public int? PublicPageTemplate { get; set; }
        public int PageIndex { get; set; }

        public int PageTotal { get; set; }

        public List<DPModel> Models { get; set; }
    }
}
