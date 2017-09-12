using System;
using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models;
using DevPartner.Nop.Plugin.Core.Models.Basic;
using Nop.Core.Domain.Media;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{
    [AdminMenu("DevCommerce/Project")]
    [PublicPage("ProjectPage")] // todo view 
    [SystemName("Project")]
    [Icon("fa-suitcase")]
    [Parent("Content Management/Projects")]
    public class ProjectModel : DPPublicFeaturedContentPageModel
    {
        public DateTime CloseDate { get; set; }
        public string Link { get; set; }
        public int Budget { get; set; }

        public int EstimatedTime { get; set; }

        public int SpentTime { get; set; }

        public string Techniques { get; set; }

        public string Platform { get; set; }
        [EditorTemplate("RichEditor")]
        public string Challenge { get; set; }
        [EditorTemplate("RichEditor")]
        public string Sulution { get; set; }
        [EditorTemplate("RichEditor")]
        public string Results { get; set; }
        [EditorTemplate("RichEditor")]
        public string Benefits { get; set; }

        [AttExtRefType("ProductTag")]
        [EditorTemplate("SuggestionList")]
        public int[] Tags { get; set; }
        public string NavigationTitle { get; set; }

        public Picture[] Pictures { get; set; }
        public Picture ThumbnailImageHome { get; set; }
        [AttExtRefType("Customer")]
        [EditorTemplate("SuggestionList")]
        public int[] Developers { get; set; }

        //[AttExtRefType("Entity")]
        //[DataSource("Content Management/Services")] //todo: select servises? sql?
        //[EditorTemplate("Suggestion")] //VideoList.cshtml, PicasaList.cshtml, GalleriaList.cshtml, GalleryWithAloneImages.cshtml?
        //public int[] ServicesProvided { get; set; }

        [AttExtRefType("Product")]
        [EditorTemplate("Suggestion")]
        public int[] Products { get; set; }

        [AttExtRefType("Entity")]
        [DataSource("Content Management/Testimonial")]
        [EditorTemplate("DropdownList")] //VideoList.cshtml, PicasaList.cshtml, GalleriaList.cshtml, GalleryWithAloneImages.cshtml?
        public int? Testimonial { get; set; }

        [AttExtRefType("Customer")]
        [EditorTemplate("DropdownList")]
        public int? Client { get; set; }

        [AttExtRefType("Customer")]
        [EditorTemplate("DropdownList")]
        public int? Manager { get; set; }
    }
}
