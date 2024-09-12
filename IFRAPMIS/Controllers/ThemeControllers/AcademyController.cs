using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IFRAPMIS.Models;

namespace IFRAPMIS.Controllers.ThemeControllers;

public class AcademyController : Controller
{
    public IActionResult Dashboard() => View();
    public IActionResult MyCourse() => View();
    public IActionResult CourseDetails() => View();
}
