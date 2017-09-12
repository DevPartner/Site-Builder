using System.ComponentModel.DataAnnotations;
using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models.Basic;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{
    /// <summary>
    /// represent a image or video entity
    /// </summary>
    [PublicPage("ImageVideo")] // view 
    [SystemName("ImageVideo")]
    [Localazible]
    public class ImageVideoModel : DPPublicContentPageModel
    {
        /// <summary>
        /// Gets or sets the ImageVideoType
        /// </summary>
        [AttRefType("ImageVideoType")]
        [EditorTemplate("RadioButton")]
        [Required]
        public virtual int ImageVideoType { get; set; }
        /// <summary>
        /// Gets or sets the External Url
        /// </summary>
        public virtual string ExternalUrl { get; set; }

        [DPParent]
        public GalleryModel Parent { get; set; }
    }
}
