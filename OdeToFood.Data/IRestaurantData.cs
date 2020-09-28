using System;
using System.Linq;
using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetRestaurantById(int id);
        void UpdateRestaurant(Restaurant updatedRestaurant);
        Restaurant CreateRestaurant(Restaurant createdRestaurant);
        void DeleteRestaurant(Restaurant deletedRestaurant);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Vinny's Pizza", Location = "Dekalb", Cuisine = "Italian"},
                new Restaurant { Id = 2, Name = "Chipotle", Location = "Downers Grove", Cuisine = "Mexican"},
                new Restaurant { Id = 3, Name = "Jerusalem Cafe", Location = "Lombard", Cuisine = "Palestinian"}
            };
        }

        public Restaurant CreateRestaurant(Restaurant createdRestaurant)
        {
            restaurants.Add(createdRestaurant);
            createdRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return createdRestaurant;
        }

        public void DeleteRestaurant(Restaurant deletedRestaurant)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == deletedRestaurant.Id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
        }
    }
}
