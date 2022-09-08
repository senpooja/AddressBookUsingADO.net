using AddressBookAdo;

namespace AddressBookTest
{
    [TestClass]
    public class UnitTest1
    {
        // [TestMethod]
        //public void AddPersonDetail()
        // {
        //     PersonRepo Repo = new PersonRepo();
        //     PersonModel person = new PersonModel()
        //     {
        //         First_Name = "Rajat",
        //         Last_Name = "Tiwari",
        //         Address="Golghar",
        //         City="Gorakhpur",
        //         State="UP",
        //         Zip=224211,
        //         Phone_Num=871227361,
        //         Email="Rajat@gmail.com",
        //         Type="Family"
        //     };
        //    var result=Repo.AddPersonDetails(person);

        // }
        [TestMethod]
        public void GetPersonDetail()
        {
            PersonRepo Repo = new PersonRepo();
            var person = Repo.GetPersonDetails();
            Assert.IsTrue(person);
        }
        [TestMethod]
        public void GetSelectedPersonDetail()
        {
            PersonRepo Repo = new PersonRepo();
            var person = Repo.GetSelectedPersonDetails();
            Assert.IsTrue(person);
        }
    }
}