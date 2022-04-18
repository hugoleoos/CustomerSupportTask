using Arvato.Domain.Models.Enums;

namespace Arvato.Domain.Models
{
    public class CustomerSupport
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public int Number { get; set; }

        public EInquiry? Inquiry { get; set; }

        public string DescriptionSupport { get; set; }

        public bool Aggreement { get; set; }
    }
}
