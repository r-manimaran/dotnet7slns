using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectMappersBenchMark.Models;
public class AddressDTO
{
    public string Street { get; set; }
    public string ApartmentOrSuiteNo { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}
