using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationsApi.Models
{
    public record City (string CityName, string CityCode);

    public record State(string StateName, string StateCode);
}
