using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IFRAPMIS.Models;

namespace IFRAPMIS.Controllers;

public class ModalsController : Controller
{
  public IActionResult Examples() => View();
}
