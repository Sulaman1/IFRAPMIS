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
    public class BeneficiaryPDMAController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IBeneficiaryPDMA _context;

        public BeneficiaryPDMAController(IBeneficiaryPDMA context)
        {
            _context = context;
        }

        // GET: BeneficiaryPDMA
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: BeneficiaryPDMA/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiaryPDMA = await _context.GetById(id);
            if (beneficiaryPDMA == null)
            {
                return NotFound();
            }

            return View(beneficiaryPDMA);
        }

        // GET: BeneficiaryPDMA/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BeneficiaryPDMA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BeneficiaryPDMAId,BeneficiaryName,BeneficiaryFather,Gender,CNIC,Mobile,Age,MaritialStatus,IsDisable,CNICAttachment,IsRefugee,District,Tehsil,UnionCouncil, SurveyDate, NextOfKin, NextOfKinCNIC")] BeneficiaryPDMA beneficiaryPDMA, IFormFile ProfilePicture)
        {
            if (ModelState.IsValid)
            {
                var IsExist = _context.Exist(beneficiaryPDMA.CNIC);
                if (IsExist == true)
                {
                    ModelState.AddModelError(nameof(beneficiaryPDMA.BeneficiaryName), "Beneficiary CNIC Already Exists!");
                    return View(beneficiaryPDMA);
                }
                _context.Insert(beneficiaryPDMA, ProfilePicture);
                await _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(beneficiaryPDMA);
        }

        // GET: BeneficiaryPDMA/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiaryPDMA = await _context.GetById(id);
            if (beneficiaryPDMA == null)
            {
                return NotFound();
            }
            return View(beneficiaryPDMA);
        }

        // POST: BeneficiaryPDMA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BeneficiaryPDMAId,BeneficiaryName,BeneficiaryFather,Gender,CNIC,Mobile,Age,MaritialStatus,IsDisable,CNICAttachment,IsRefugee,ProfilePicture,District,Tehsil,UnionCouncil, SurveyDate, NextOfKin, NextOfKinCNIC")] BeneficiaryPDMA beneficiaryPDMA, IFormFile ProfilePicture)
        {
            if (id != beneficiaryPDMA.BeneficiaryPDMAId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(beneficiaryPDMA, ProfilePicture);
                    await _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Exist(beneficiaryPDMA.CNIC))
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
            return View(beneficiaryPDMA);
        }

        // GET: BeneficiaryPDMA/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiaryPDMA = await _context.GetById(id);
                
            if (beneficiaryPDMA == null)
            {
                return NotFound();
            }

            return View(beneficiaryPDMA);
        }

        // POST: BeneficiaryPDMA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beneficiaryPDMA = await _context.GetById(id);
            if (beneficiaryPDMA != null)
            {
                _context.Remove(beneficiaryPDMA);
            }

            await _context.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
