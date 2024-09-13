using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IFRAPMIS.Models;

namespace IFRAPMIS.Controllers;

public class IconsController : Controller
{
  public IActionResult Tabler() => View();
  public IActionResult FontAwesome() => View();
}
