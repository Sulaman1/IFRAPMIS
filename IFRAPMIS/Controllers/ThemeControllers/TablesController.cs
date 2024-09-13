using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IFRAPMIS.Models;

namespace IFRAPMIS.Controllers;

public class TablesController : Controller
{
  public IActionResult Basic() => View();
  public IActionResult DatatablesAdvanced() => View();
  public IActionResult DatatablesBasic() => View();
  public IActionResult DatatablesExtensions() => View();
}
