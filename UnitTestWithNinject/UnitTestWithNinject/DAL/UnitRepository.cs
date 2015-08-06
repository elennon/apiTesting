using UnitTestWithNinject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTestWithNinject
{
    public class UnitRepository : IUnitRepository
    {
        public PGEntities db;

        public UnitRepository()
        {
            db = new PGEntities();
        }

        public IEnumerable<Unit> GetUnits()
        {
            return db.Units;//.ToList();
        }

        public Unit GetById(int id)
        {
            return db.Units.ToList().Find(u => u.UnitId == id);
        }

    }
}