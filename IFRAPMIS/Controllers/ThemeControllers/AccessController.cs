using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IFRAPMIS.Models;

namespace IFRAPMIS.Controllers.ThemeControllers;

public class AccessController : Controller
{
    public IActionResult Permission() => View();
    public IActionResult Roles() => View();
}
