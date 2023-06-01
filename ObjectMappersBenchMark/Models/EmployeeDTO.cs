using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectMappersBenchMark.Models;
public class EmployeeDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmployeeId { get; set; }
    public string Email { get; set; }
    public DateTime DateOfJoin { get; set; }
    public int YearsOfExperience { get; set; }
    public string[] Skills { get; set; }
    public AddressDTO Address { get; set; }
}
