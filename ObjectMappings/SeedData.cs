using ObjectMappings.Models;

namespace ObjectMappings
{
    public class SeedData
    {
        public static Person GetPerson()
        {
            return new Person()
            {
                Title="Mr.",
                FirstName="Paul",
                LastName="Ravi",
                DOB = new DateTime(1998,1,2),
                Address = new Address()
                {
                    Country="USA",
                    State="NJ",
                    StreetName="Main Street",
                    PostalCode="02334",
                    City="New Jersy"
                }
            };
        }

        internal static ICollection<Person> GetPeople()
        {
            throw new NotImplementedException();
        }
    }
}
