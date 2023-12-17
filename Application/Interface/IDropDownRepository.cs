using Application.Common;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IDropDownRepository : IScopedService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<IEnumerable<State>> GetStatesByCountry(int countryId);
    }
}
