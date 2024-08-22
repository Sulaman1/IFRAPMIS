using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Models.Domain.MasterSetup;
using IFRAPMIS.Data;
using BAL.IRepository.MasterSetup;
using BAL.IRepository.BeneficiaryVerification;

namespace IFRAPMIS.Controllers.BeneficiaryVerification
{
    public class BeneficiaryIPController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IBeneficiaryIP _context;

        public BeneficiaryIPController(IBeneficiaryIP context)
        {
            _context = context;
        }

        // GET: BeneficiaryIPs
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: BeneficiaryIPs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiaryIP = await _context.GetById(id);
            if (beneficiaryIP == null)
            {
                return NotFound();
            }

            return View(beneficiaryIP);
        }

        // GET: BeneficiaryIPs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BeneficiaryIPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BeneficiaryIPId,BeneficiaryName,BeneficiaryFather,Gender,CNIC,Mobile,Age,MaritialStatus,IsDisable,CNICAttachment,IsRefugee,District,Tehsil,UnionCouncil")] BeneficiaryIP beneficiaryIP, IFormFile ProfilePicture)
        {
            if (ModelState.IsValid)
            {
                var IsExist = _context.Exist(beneficiaryIP.CNIC);
                if (IsExist == true)
                {
                    ModelState.AddModelError(nameof(beneficiaryIP.BeneficiaryName), "Beneficiary CNIC Already Exists!");
                    return View(beneficiaryIP);
                }
                _context.Insert(beneficiaryIP, ProfilePicture);
                await _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(beneficiaryIP);
        }

        // GET: BeneficiaryIPs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiaryIP = await _context.GetById(id);
            if (beneficiaryIP == null)
            {
                return NotFound();
            }
            return View(beneficiaryIP);
        }

        // POST: BeneficiaryIPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BeneficiaryIPId,BeneficiaryName,BeneficiaryFather,Gender,CNIC,Mobile,Age,MaritialStatus,IsDisable,CNICAttachment,IsRefugee,ProfilePicture,District,Tehsil,UnionCouncil")] BeneficiaryIP beneficiaryIP, IFormFile ProfilePicture)
        {
            if (id != beneficiaryIP.BeneficiaryIPId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(beneficiaryIP, ProfilePicture);
                    await _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Exist(beneficiaryIP.CNIC))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(beneficiaryIP);
        }

        // GET: BeneficiaryIPs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiaryIP = await _context.GetById(id);
                
            if (beneficiaryIP == null)
            {
                return NotFound();
            }

            return View(beneficiaryIP);
        }

        // POST: BeneficiaryIPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beneficiaryIP = await _context.GetById(id);
            if (beneficiaryIP != null)
            {
                _context.Remove(beneficiaryIP);
            }

            await _context.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
