using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IResturantData
    {
        IEnumerable<Resturant> GetResturantByName(string Name);
        Resturant GetById(int id);
        Resturant Update(Resturant updatedResturant);
        int SaveChanges();
    }
    public class InMemoryResturantData : IResturantData
    {
        List<Resturant> _resturants;
        public InMemoryResturantData()
        {
            _resturants = new List<Resturant>()
            {
                new Resturant { Id = 0, Name = "Li's Pizza", Location="Rome", Cuisine=CuisineType.Italian},
                new Resturant { Id = 1, Name = "Shuang's Tacco", Location="Mexico City", Cuisine=CuisineType.Mexican},
                new Resturant { Id = 2, Name = "Jennifer's Curry", Location="New Delhi", Cuisine=CuisineType.Indian},
            };
        }
        public IEnumerable<Resturant> GetResturantByName(string name = null)
        {
            return from r in _resturants
                   where string.IsNullOrWhiteSpace(name) ||r.Name.ToLower().StartsWith(name.ToLower())
                   orderby r.Name 
                   select r;
        }
        
        public Resturant GetById(int id)
        {
            return _resturants.SingleOrDefault(r => r.Id == id);
        }

        public Resturant Update(Resturant updatedResturant)
        {
            throw new NotImplementedException();
        }
    }

}
