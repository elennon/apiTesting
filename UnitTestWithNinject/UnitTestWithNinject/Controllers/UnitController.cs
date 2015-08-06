using UnitTestWithNinject;
using UnitTestWithNinject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UnitTestWithNinject.Controllers
{
    public class UnitController : ApiController
    {
        
        public IUnitRepository db;

        public UnitController(IUnitRepository repo)
        {
            this.db = repo;
        }

        public IEnumerable<Unit> Get()
        {
            return db.GetUnits();//as  IQueryable<Unit>;
        }

        // GET api/unit/5
        public Unit Get(int id)
        {
            Unit item = db.GetById(id);
            if (item == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return item;
        }

        public IEnumerable<Unit> GetUnitsByAddress(string address)
        {          
            return db.GetUnits().Where(
                u => string.Equals(u.UnitAddress, address, StringComparison.OrdinalIgnoreCase));;
        }

        // POST api/unit
        public void Post([FromBody]string value)
        {
        }

        // PUT api/unit/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/unit/5
        public void Delete(int id)
        {
        }
    }
}
