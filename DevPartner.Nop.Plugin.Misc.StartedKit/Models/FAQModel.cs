using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models.Basic;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{
    [AdminMenu("DevCommerce/FAQ")]
    [SystemName("FAQ")]
    [Localazible]
    [Icon("fa-question")]
    [Parent("Content Management/FAQ", false)]
    public class FAQModel : DPModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        [Group("Published")]
        [ShowOnListPage]
        public bool Published { get; set; }
    }
}
