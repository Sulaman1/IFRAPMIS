using DAL.Models.Domain.MasterSetup;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IFRAPMIS.Controllers.BeneficiaryVerification
{
    public class BeneficiaryVerifiedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeneficiaryVerifiedController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BeneficiaryVerifiedss
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.BeneficiaryVerifieds.Where(a => a.BeneficiaryTypeId == 1).Select(a => new BeneficiaryVerifieds { BeneficiaryVerifiedsId = a.BeneficiaryVerifiedsId, BeneficiaryVerifiedsName = a.BeneficiaryVerifiedsName, FatherName = a.FatherName, CNIC = a.CNIC, CellNo = a.CellNo, Gender = a.Gender });
            var applicationDbContext = await _context.BeneficiaryVerifieds.ToListAsync();

            return View(applicationDbContext);
        }

        // GET: BeneficiaryVerifiedss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BeneficiaryVerifieds == null)
            {
                return NotFound();
            }

            var member = await _context.BeneficiaryVerifieds
                //.Include(m => m.BeneficiaryType)
                .FirstOrDefaultAsync(m => m.BeneficiaryVerifiedId == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }
        public async Task<IActionResult> Edit2(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.BeneficiaryVerifieds.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Districts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit2(int id, BeneficiaryVerified member)
        {
            if (id != member.BeneficiaryVerifiedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var IsExist = _context.BeneficiaryVerifieds.Count(a => a.CNIC == member.CNIC);
                    if (IsExist > 1)
                    {
                        ModelState.AddModelError(nameof(member.CNIC), "Already exist with same name!");
                        return View(member);
                    }
                    //_context.Entry(district).CurrentValues.SetValues(district);
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                    //await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                    /*_context.Update(district);
                    await _context.SaveChangesAsync();*/
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }
    }
}
