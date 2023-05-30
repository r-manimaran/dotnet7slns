using Mapster;
using ObjectMappings.Models;

namespace ObjectMappings
{
    public static class MappingFun
    {
        private static readonly Person _person =SeedData.GetPerson();
        private static readonly ICollection<Person> _people = SeedData.GetPeople();

        public static PersonDto MapPersonToNewDto()
        {
            var personDto = _person.Adapt<PersonDto>();
            return personDto;
        }

        public static PersonDto MapPersonToExistingDto()
        {
            var personDto = new PersonDto();
            _person.Adapt(personDto);
            return personDto;
        }
        //public static IQueryable<PersonDto> MapPersonQueryableToDtoQueryable() 
        //{

        //}
    }

   
}
