using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IFRAPMIS.Models;

namespace IFRAPMIS.Controllers.ThemeControllers;

public class ChartsController : Controller
{
    public IActionResult Apex() => View();
    public IActionResult Chartjs() => View();
}
