﻿using OdeToFood.Core;
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

        public Resturant Add(Resturant newResturant)
        {
            _resturants.Add(newResturant);
            newResturant.Id = _resturants.Max(r => r.Id) + 1;
            return newResturant;
        }

        public Resturant Update(Resturant updatedResturant)
        {
            var resturant = _resturants.SingleOrDefault(r => r.Id == updatedResturant.Id);
            if(resturant != null)
            {
                resturant.Name = updatedResturant.Name;
                resturant.Location = updatedResturant.Location;
                resturant.Cuisine = updatedResturant.Cuisine;
            }
            return resturant;
        }

        public int SaveChanges()
        {
            return 0;
        }
    }

}
