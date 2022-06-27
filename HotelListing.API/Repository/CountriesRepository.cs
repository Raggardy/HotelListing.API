using HotelListing.API.Contracts;
using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDbContext _context;

        public CountriesRepository(HotelListingDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries
                // Include the list of hotels from the database column Countries
                .Include(q => q.Hotels)
                // Whilst retreiving the 1st record that has a matching id
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
