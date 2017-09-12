using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models;
using DevPartner.Nop.Plugin.Core.Models.Basic;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{
    [AdminMenu("DevCommerce/Module/Gallery")]
    [PublicPage("GalleryPage")] // view 
    [SystemName("Gallery")]
    [Localazible]
    [Parent("Content Management/Gallery", false)]
    [Icon("fa fa-picture-o")]
    public class GalleryModel : DPPublicNavigationPageModel
    {
        public GalleryModel()
        {
            PageSize = 5;
        }
        [AttExtRefType("Entity")]
        [DataSource("System/CMS/GalleryPageTemplate")]
        [EditorTemplate("RadioButton")]
        [Required]
        public int? GalleryPageTemplate { get; set; }

        public string PicasaKeyword { get; set; }

        public string FlickrKeysords { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int TotalCount { get; set; }
        [Ignore]
        public List<ImageVideoModel> Models { get; set; }

    }
}
