//using NUnit.Framework;
//using NUnit.Framework.Interfaces;
//using OpenQA.Selenium.Chrome;
//using PetClinic.Helpers;
//using PetClinic.POM_Sites;
//using static PetClinic.POM_Sites.BaseClass;

//namespace PetClinic.Tests
//{
//    [TestFixture]
//    public class GuiTests : ProjectTestBase
//    {
//        private readonly TestPet TheTestPet = new TestPet
//        {
//            OwnerFirstName = "Daviss",
//            OwnerValidName = "Escobito",
//            GenderType = PetTypes.hamster,
//            PetName = "Reksio",
//            BirthDate = "2017/09/03"
//        };

//        private readonly NewUser TheNewOwner = new NewUser
//        {
//            NewOwnerName = "Pawel",
//            NewOwnerSurname = "Marek",
//            NewOwnerStreet = "Grunwaldzka 72",
//            NewOwnerCity = "Warszawa",
//            NewOwnerPhone = "123456789"
//        };

//        private readonly NewVisitt TheNewVisitt = new NewVisitt
//        {
//            NewDateVisit = "2019/09/11",
//            NewDescription = "This is my favourite pet."
//        };
     
//        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(GuiTests));
        
//        //Tests
//        [Test, Order(1)]
//        public void CheckElementsOnHomePage()
//        {
//            var homePage = new Home(Driver);
//            homePage = homePage.NavigateToWebApp();
//            Assert.AreEqual(homePage.Driver.Url, homePage.HomeUrl());
//            Assert.AreEqual(homePage.WelcomeText.Text, "Welcome", "The text on the main page is not correct.");
//            Assert.IsTrue(homePage.CheckPicture(), $"The picture is incorrect. Expected =>{homePage.PictureOnHomePage}");
//            Assert.AreEqual(homePage.CheckMenuItems(), homePage.ExpectedMenuItems(), $"The picture is incorrect. Expected =>{homePage.ExpectedMenuItems()}"); 
//        }
//        [Test, Order(2)]
//        public void FindInvalidPetOwner()
//        {
//            var homePage = new Home(Driver);
//            homePage = homePage.NavigateToWebApp();
//            var findOwners = homePage.ClickFindOwners();
//            findOwners.TypeOwner(TheTestPet).ClickFindOwner();
//            Assert.AreEqual(findOwners.IncorrectValue.Text, "has not been found");
//        }

//        [Test, Order(3)]
//        public void FindEditValidPetOwner()
//        {
//            Home homePage = new Home(Driver);
//            homePage = homePage.NavigateToWebApp();
//            FindOwners findOwners = homePage.ClickFindOwners();
//            findOwners.TypeValidOwner(TheTestPet);
//            var ownerInformation = findOwners.ClickFindOwner();
//            Assert.AreEqual(ownerInformation.Driver.Url, ownerInformation.OwnerInformationUrl());
//            Assert.AreEqual(ownerInformation. OwnerData.Text, "Maria Escobito");
//            ownerInformation.ClickEditOwners();
//            ownerInformation.EditPetOwner(TheNewOwner).ClickUpdateOwner();
//            Assert.AreEqual(ownerInformation.Driver.Url, ownerInformation.OwnerInformationUrl());
//            Assert.AreEqual(ownerInformation.OwnerDataAfterUpdate.Text, "Pawel Marek");
//        }

//        [Test, Order(4)]
//        public void GetNewPetToOwner()
//        {
//            var homePage = new Home(Driver);
//            homePage = homePage.NavigateToWebApp();
//            var findOwners = homePage.ClickFindOwners();       
//            findOwners.Owner(TheNewOwner);
//            var ownerInformation = findOwners.ClickFindOwner();
//            var newPet =  ownerInformation.AddNewPet();          
//            Assert.AreEqual(newPet.Driver.Url, newPet.FindNewPetUrl());

//            newPet.SelectPetType(TheTestPet).ClickNewPet();         

//            CollectionAssert.AreEqual(newPet.AddedNewPet(), newPet.ExpectedNewPet(), "The values aren't that same.");
//        }

//        [Test, Order(5)]
//        public void AddNewVetVisit()
//        {
//            var homePage = new Home(Driver);
//            homePage = homePage.NavigateToWebApp();
//            var findOwners = homePage.ClickFindOwners();
//            findOwners.Owner(TheNewOwner);
//            var ownerInformation = findOwners.ClickFindOwner();
//            var newVisit = ownerInformation.ClickAddNewVisit();
//            newVisit.AddNewVist(TheNewVisitt);
//            Assert.Contains("2019-09-11 This is my favourite pet.", ownerInformation.PetVisits());



//        }

//    }
//}
