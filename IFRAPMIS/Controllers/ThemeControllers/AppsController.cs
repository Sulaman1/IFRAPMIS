using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IFRAPMIS.Models;

namespace IFRAPMIS.Controllers.ThemeControllers;

public class AppsController : Controller
{
    public IActionResult Calendar() => View();
    public IActionResult Chat() => View();
    public IActionResult Kanban() => View();
    public IActionResult Email() => View();
}
