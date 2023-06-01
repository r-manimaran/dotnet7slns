using Riok.Mapperly.Abstractions;
using ObjectMappersBenchMark.Models;

namespace ObjectMappersBenchMark;

    [Mapper]
    public partial class MapperlyMapper
    {
        public partial Employee Map(EmployeeDTO employeeDto);

        //Place over cursor on Map and click F12 for auto generated object mapping
    }
