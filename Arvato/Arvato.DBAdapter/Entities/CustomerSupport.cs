namespace Arvato.DBAdapter.Entities
{
    public class CustomerSupport
       {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public int Number { get; set; }

        public EInquiry Inquiry { get; set; }

        public string DescriptionSupport { get; set; }

        public bool Aggreement { get; set; }

    }   

    public enum EInquiry
    {
        ApplyForaJob = 1,
        BookSiteVisit = 2,
        DiscussBackOffice = 3,
        DiscussCustomerChallenge = 4,
        ContactHRTeam = 5,
        OfferSupplierServices = 6,
        RequestPilot = 7,
        SpeakCommunicationsTeam = 8,
        Other = 9
    }
    
}
