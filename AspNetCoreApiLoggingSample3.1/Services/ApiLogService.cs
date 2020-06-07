using AspNetCoreApiLoggingSample.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApiLoggingSample.Services
{
    public class ApiLogService
    {
        private readonly AppDbContext _db;

        public ApiLogService(AppDbContext db)
        {
            _db = db;
        }

        public async Task Log(ApiLogItem apiLogItem)
        {
            _db.ApiLogs.Add(apiLogItem);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApiLogItem>> Get()
        {
            var items  = from i in _db.ApiLogs
                         orderby i.Id descending
                         select i;

            return await items.ToListAsync();
        }
    }
}
