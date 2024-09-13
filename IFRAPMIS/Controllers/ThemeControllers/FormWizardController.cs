using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IFRAPMIS.Models;

namespace IFRAPMIS.Controllers.ThemeControllers;

public class FormWizardController : Controller
{
    public IActionResult Icons() => View();
    public IActionResult Numbered() => View();
}
