namespace PetClinic.Tests
{
    internal class TestPet
    {
        public string OwnerFirstName { get; set; }

        public string OwnerValidName { get; set; }

        public string PetName { get; set; }

        public string BirthDate { get; set; }

        public PetTypes GenderType { get; set; }
        
    }
    internal class NewUser
    {
        public string NewOwnerName { get; set; }

        public string NewOwnerSurname { get; set; }

        public string NewOwnerStreet { get; set; }

        public string NewOwnerCity { get; set; }

        public string NewOwnerPhone { get; set; }
    }

    internal class NewVisitt
    {
        public string NewDateVisit { get; set; }

        public string NewDescription { get; set; }
    }

}