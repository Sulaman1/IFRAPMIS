using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IFRAPMIS.Models;

namespace IFRAPMIS.Controllers;

public class LogisticsController : Controller
{
  public IActionResult Dashboard() => View();
  public IActionResult Fleet() => View();
}
