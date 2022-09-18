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
        IEnumerable<Resturant> GetAll();
    }
    public class InMemoryResturantData : IResturantData
    {
        List<Resturant> _resturants;
        public InMemoryResturantData()
        {
            _resturants = new List<Resturant>();
            {
                new Resturant { Id = 0, Name = ""}
            }
        }
        IEnumerable<Resturant> IResturantData.GetAll()
        {
            throw new NotImplementedException();
        }
    }

}
