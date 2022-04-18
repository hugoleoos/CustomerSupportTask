using System.ComponentModel.DataAnnotations;

namespace ArvatoFront.Models
{
    public class CustomerSupportViewModel
    {
        [Required(ErrorMessage = "The field {0} is riquered")]
        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0} is riquered")]
        [Phone]
        public string Phone { get; set; }

        //[Phone]
        public int Number { get; set; }

        [Required(ErrorMessage = "The field {0} is riquered")]
        public EInquiry? Inquiry { get; set; }

        [Required(ErrorMessage = "The field {0} is riquered")]
        public string DescriptionSupport { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "The field {0} is riquered")]
        public bool Aggreement { get; set; }

        public enum EInquiry
        {
            [Display(Name = "Apply for a job")]
            ApplyForaJob = 1,

            [Display(Name = "Book site visit")]
            BookSiteVisit = 2,

            [Display(Name = "Discuss BackOffice")]
            DiscussBackOffice = 3,

            [Display(Name = "Discuss customer challenge")]
            DiscussCustomerChallenge = 4,

            [Display(Name = "Contact HR team")]
            ContactHRTeam = 5,

            [Display(Name = "Offer supplier services")]
            OfferSupplierServices = 6,

            [Display(Name = "Request pilot")]
            RequestPilot = 7,

            [Display(Name = "Speak communications team")]
            SpeakCommunicationsTeam = 8,

            [Display(Name = "Other")]
            Other = 9
        }
    }
}
