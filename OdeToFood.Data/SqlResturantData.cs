using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class SqlResturantData : IResturantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlResturantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public Resturant Add(Resturant newResturant)
        {
            db.Resturants.Add(newResturant);
            return newResturant;
        }

        public Resturant Delete(int id)
        {
            var resturant = GetById(id);
            if (resturant != null)
            {
                db.Resturants.Remove(resturant);
            }
            return resturant;
        }

        public Resturant GetById(int id)
        {
            return db.Resturants.Find(id);
        }

        public IEnumerable<Resturant> GetResturantByName(string name)
        {
            var query = from r in db.Resturants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public Resturant Update(Resturant updatedResturant)
        {
            var resturant = db.Resturants.Attach(updatedResturant);
            resturant.State = EntityState.Modified;
            return updatedResturant;
        }
    }

}
