using System.ComponentModel.DataAnnotations;
using DevPartner.Nop.Plugin.Core.Attributes;
using DevPartner.Nop.Plugin.Core.Models.Basic;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Models
{
    [SystemName("Request")]
    [Parent("Content Management/Request")]
    [Icon("fa-envelope")]
    public class RequestModel : DPModel
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Not a valid Email Address")]
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
