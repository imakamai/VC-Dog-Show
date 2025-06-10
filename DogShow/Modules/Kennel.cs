namespace DogShow.Modules
{
    public class Kennel
    {
        public Kennel()
        {
        }

        public Kennel(int id, string name, Owner owner, string dogsBread, string location, string facilitiDescription, string phone, string email, bool isMemberOfNationalKennelClub, string nationalKennelClubName, string nationalKennelClubMembershipNumber, bool hasDogShowCertification, string dogShowCertificationDetails, decimal registrationFeeAmount, DateTime registrationDate, byte[] pdfDocument, string pdfDocumentOriginalFileName, string pdfDocumentContentType, byte[] digitalSignedDeclaration, string digitalSignedDeclarationOriginalFileName, string digitalSignedDeclarationContentType, int submittedByPersonalId, DateTime submissionDateTime)
        {
            Id = id;
            Name = name;
            Owner = owner;
            DogsBread = dogsBread;
            Location = location;
            FacilitiDescription = facilitiDescription;
            Phone = phone;
            Email = email;
            IsMemberOfNationalKennelClub = isMemberOfNationalKennelClub;
            NationalKennelClubName = nationalKennelClubName;
            NationalKennelClubMembershipNumber = nationalKennelClubMembershipNumber;
            HasDogShowCertification = hasDogShowCertification;
            DogShowCertificationDetails = dogShowCertificationDetails;
            RegistrationFeeAmount = registrationFeeAmount;
            RegistrationDate = registrationDate;
            PdfDocument = pdfDocument;
            PdfDocumentOriginalFileName = pdfDocumentOriginalFileName;
            PdfDocumentContentType = pdfDocumentContentType;
            DigitalSignedDeclaration = digitalSignedDeclaration;
            DigitalSignedDeclarationOriginalFileName = digitalSignedDeclarationOriginalFileName;
            DigitalSignedDeclarationContentType = digitalSignedDeclarationContentType;
            SubmittedByPersonalId = submittedByPersonalId;
            SubmissionDateTime = submissionDateTime;
        }

        public int Id { get; set; } 
        public string Name { get; set; }
        public Owner Owner { get; set; } 
        public string DogsBread { get; set; }
        public string Location { get; set; }
        public string FacilitiDescription { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; } 
        public bool IsMemberOfNationalKennelClub { get; set; }
        public string NationalKennelClubName { get; set; }
        public string NationalKennelClubMembershipNumber { get; set; }

        public bool HasDogShowCertification { get; set; }
        public string DogShowCertificationDetails { get; set; }

        public decimal RegistrationFeeAmount { get; set; } 
        public DateTime RegistrationDate { get; set; } 

        
        public byte[] PdfDocument { get; set; } 
        public string PdfDocumentOriginalFileName { get; set; } 
        public string PdfDocumentContentType { get; set; }

        public byte[] DigitalSignedDeclaration { get; set; } 
        public string DigitalSignedDeclarationOriginalFileName { get; set; } 
        public string DigitalSignedDeclarationContentType { get; set; } 

        
        public int SubmittedByPersonalId { get; set; } 
        public DateTime SubmissionDateTime { get; set; } 
    }
}

