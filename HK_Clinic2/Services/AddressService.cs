using HK_Clinic2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HK_Clinic2.Services
{
    public class AddressService
    {
        // Instance of the db context
        private readonly HKClinicDbContext db;

        // Constructor using dependency injection
        public AddressService(HKClinicDbContext context)
        {
            db = context;
        }

        public List<Address> GetAddresses()
        {
            return db.Address.ToList();
        }

        public Address GetAddress(int id)
        {
            return db.Address.SingleOrDefault(c => c.AddressId == id);
        }

        public bool AddAddress(Address address)
        {
            if (address != null)
            {
                db.Address.Add(address);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteAddress(int id)
        {
            var address = db.Address.Find(id);
            if (address != null)
            {
                db.Address.Remove(address);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateAddress(Address address)
        {
            db.Entry(address).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}
