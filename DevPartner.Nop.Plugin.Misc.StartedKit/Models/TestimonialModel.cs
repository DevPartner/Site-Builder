using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models.Basic;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{
    [AdminMenu("DevCommerce/Testimonial")]
    [PublicPage("TestimonialPage")] // todo view 
    [SystemName("Testimonial")]
    [Parent("Content Management/Testimonial")]
    [Icon("fa-thumbs-up")]
    [Localazible]
    public class TestimonialModel : DPPublicContentPageModel
    {
        public string ClientName { get; set; }
        public string ClientTitle { get; set; }
        public string ClientContactName { get; set; }

    }
}
