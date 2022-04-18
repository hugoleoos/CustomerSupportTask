using System.ComponentModel.DataAnnotations;

namespace Arvato.WebAPI.Dtos
{
    /// <summary>
    /// CustomerSupportDto
    /// </summary>
    public class CustomerSupportDto
    {
        /// <summary>
        /// Customer Email to open a support contact
        /// </summary>
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        /// <summary>
        /// Customer first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Customer lst name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Customer Phone
        /// </summary>
        [Required(ErrorMessage = "Phone is Required")]
        public string Phone { get; set; }

        /// <summary>
        /// Customer number
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Type of Inquiry to a support contact
        /// </summary>
        [Required(ErrorMessage = "Inquiry is Required")]
        public EInquiry? Inquiry { get; set; }

        /// <summary>
        /// Description to open a support contact
        /// </summary>
        [Required(ErrorMessage = "Description is Required")]
        public string DescriptionSupport { get; set; }

        /// <summary>
        /// term of agreement to open a support contact
        /// </summary>
        [Required(ErrorMessage = "Agreement is Required")]
        public bool Aggreement { get; set; }

        /// <summary>
        /// Type of Inquiry to a support contact
        ///  </summary>
        public enum EInquiry
        {
            /// <summary>
            /// Apply for as job
            /// </summary>
            ApplyForaJob = 1,
            /// <summary>
            /// Book a site visit
            /// </summary>
            BookSiteVisit = 2,
            /// <summary>
            /// Discuss a back office project
            /// </summary>
            DiscussBackOffice = 3,
            /// <summary>
            /// Discuss a customer service challenge
            /// </summary>
            DiscussCustomerChallenge = 4,
            /// <summary>
            /// Contact the HR team
            /// </summary>
            ContactHRTeam = 5,
            /// <summary>
            /// Offer supplier services
            /// </summary>
            OfferSupplierServices = 6,
            /// <summary>
            /// Request a pilot
            /// </summary>
            RequestPilot = 7,
            /// <summary>
            /// Speak to your communications teams
            /// </summary>
            SpeakCommunicationsTeam = 8,
            /// <summary>
            /// Other
            /// </summary>
            Other = 9
        }
    }
}
