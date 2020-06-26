using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreApiLogging.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApiLogging.Controllers
{
    public class LogsController : Controller
    {
        private readonly ApiLogService _apiLogService;

        public LogsController(ApiLogService apiLogService)
        {
            _apiLogService = apiLogService;
        }

        public async Task<IActionResult> Index()
        {
            var apiLogItems = await _apiLogService.Get();
            return View(apiLogItems);
        }
    }
}