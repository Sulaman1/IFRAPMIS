using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IFRAPMIS.Models;

namespace IFRAPMIS.Controllers.ThemeControllers;

public class FormLayoutsController : Controller
{
    public IActionResult Horizontal() => View();
    public IActionResult Vertical() => View();
    public IActionResult Sticky() => View();
}
