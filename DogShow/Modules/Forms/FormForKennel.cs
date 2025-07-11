namespace DogShow.Modules.Forms
{
    public class FormForKennel
    {
        public FormForKennel()
        {
        }

        public FormForKennel(string name, string dogsBread, string location, string facilitiDescription, int personalId, string phone, string ownerName, string ownerEmail, bool isMemberOfNationalKennelClub, string nationalKennelClubName, string nationalKennelClubMembershipNumber, bool hasDogShowCertification, string dogShowCertificationDetails, decimal registrationFee, string pdfDocumentFileName, string digitalSignedDeclarationFileName)
        {
            Name = name;
            DogsBread = dogsBread;
            Location = location;
            FacilitiDescription = facilitiDescription;
            PersonalId = personalId;
            Phone = phone;
            OwnerName = ownerName;
            OwnerEmail = ownerEmail;
            IsMemberOfNationalKennelClub = isMemberOfNationalKennelClub;
            NationalKennelClubName = nationalKennelClubName;
            NationalKennelClubMembershipNumber = nationalKennelClubMembershipNumber;
            HasDogShowCertification = hasDogShowCertification;
            DogShowCertificationDetails = dogShowCertificationDetails;
            RegistrationFee = registrationFee;
            PdfDocumentFileName = pdfDocumentFileName;
            DigitalSignedDeclarationFileName = digitalSignedDeclarationFileName;
        }

        public string Name { get; set; }
        public string DogsBread { get; set; } 
        public string Location { get; set; }
        public string FacilitiDescription { get; set; }
        public int PersonalId { get; set; } 
        public string Phone { get; set; } 

        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }

        public bool IsMemberOfNationalKennelClub { get; set; }
        public string NationalKennelClubName { get; set; }
        public string NationalKennelClubMembershipNumber { get; set; }

        public bool HasDogShowCertification { get; set; }
        public string DogShowCertificationDetails { get; set; }

        public decimal RegistrationFee { get; set; } 

        public string PdfDocumentFileName { get; set; } 
        public string DigitalSignedDeclarationFileName { get; set; } 
    }
}

