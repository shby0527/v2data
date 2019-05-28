using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataWeb.DbContents;
using DataWeb.DbEntities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataWeb.Controllers
{
    [Route("api/v2data")]
    public class QueryController : Controller
    {
        private readonly V2RayDbContent db;

        public QueryController(V2RayDbContent db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<DataEntity> Query([FromQuery]string name, [FromQuery] DateTime? start, [FromQuery] DateTime? end)
        {
            var data = from p in db.DataEntity select p;
            if (!string.IsNullOrEmpty(name))
            {
                data = data.Where(p => p.User == name);
            }
            if (start != null)
            {
                data = data.Where(p => p.CreateTime >= start);
            }
            if (end != null)
            {
                data = data.Where(p => p.CreateTime <= end);
            }

            return data.ToArray();
        }
    }
}
