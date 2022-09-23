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
        Resturant Add(Resturant newResturant);
        Resturant Delete(int id);
        int GetCountOfResturants();
        int SaveChanges();
    }
}
