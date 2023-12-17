using Application.Interface;
using Core.Entities;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class DropDownRepository : IDropDownRepository
    {
        private readonly DatabaseHelper _databaseHelper;

        public DropDownRepository(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            var param = new DynamicParameters();
            return await _databaseHelper.ExecuteQuery<Country>("GetAllCountries", param);
        }

        public async Task<IEnumerable<State>> GetStatesByCountry(int countryId)
        {
            var param = new DynamicParameters();
            param.Add("@CountryId", countryId);
            return await _databaseHelper.ExecuteQuery<State>("GetStatesByCountry", param);
        }
    }
}
