using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IFRAPMIS.Models;

namespace IFRAPMIS.Controllers;

public class MapsController : Controller
{
  public IActionResult Leaflet() => View();
}
