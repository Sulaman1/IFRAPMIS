using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IFRAPMIS.Models;

namespace IFRAPMIS.Controllers.ThemeControllers;

public class DashboardsController : Controller
{
    public IActionResult Index() => View();

    public IActionResult CRM() => View();
}
