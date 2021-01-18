using HK_Clinic2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HK_Clinic2.Services
{
    public class InventoryService
    {
        // Instance of the db context
        private readonly HKClinicDbContext db;

        // Constructor using dependency injection
        public InventoryService(HKClinicDbContext context)
        {
            db = context;
        }

        public List<Inventory_Equipment> GetInventories()
        {
            return db.Inventory_Equipment.ToList();
        }

        public Inventory GetInventory(int id)
        {
            return db.Inventory.SingleOrDefault(c => c.InventoryId == id);
        }

        public bool AddInventory(Inventory inventory)
        {
            if (inventory != null)
            {
                db.Inventory.Add(inventory);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteInventory(int id)
        {
            var inventory = db.Inventory.Find(id);
            if (inventory != null)
            {
                db.Inventory.Remove(inventory);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateInventory(Inventory inventory)
        {
            db.Entry(inventory).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
