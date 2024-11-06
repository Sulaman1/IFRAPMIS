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
            List<BeneficiaryIP> emptyIPBeneficiariesList = new List<BeneficiaryIP>();
            return View(emptyIPBeneficiariesList);
        }
        public async Task<IActionResult> ListBeneficiariesIP()
        {
            var allBeneficiaries = await _context.GetAll();
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { data = allBeneficiaries });
            }
            return View(allBeneficiaries);
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
        public async Task<IActionResult> Create([Bind("BeneficiaryIPId,BeneficiaryName,BeneficiaryFather,Gender,CNIC,Mobile,Age,MaritialStatus,IsDisable,IsRefugee,District,Tehsil,UnionCouncil,SurveyDate, NextOfKin, NextOfKinCNIC")] BeneficiaryIP beneficiaryIP, IFormFile ProfilePicture, IFormFile CNICAttachment)
        {
            if (ModelState.IsValid)
            {
                var IsExist = _context.Exist(beneficiaryIP.CNIC);
                if (IsExist == true)
                {
                    ModelState.AddModelError(nameof(beneficiaryIP.BeneficiaryName), "Beneficiary CNIC Already Exists!");
                    return View(beneficiaryIP);
                }

                if (CNICAttachment != null && CNICAttachment.Length > 0)
                {
                    Random random = new Random();
                    int randomNumber1 = random.Next(999, 100000);
                    var rootPath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\BenIP_" + beneficiaryIP.District + "\\cnic" + randomNumber1.ToString() + "\\");
                    string fileName = Path.GetFileName(CNICAttachment.FileName);
                    int randomNumber2 = random.Next(999, 100000);
                    fileName = "BenIP" + randomNumber2.ToString() + Path.GetExtension(fileName);
                    string sPath = Path.Combine(rootPath);

                    beneficiaryIP.CNICAttachment = Path.Combine("/Documents/BenIP_" + beneficiaryIP.District + "/cnic" + randomNumber1.ToString() + "/" + fileName);

                    if (!System.IO.Directory.Exists(sPath))
                    {
                        System.IO.Directory.CreateDirectory(sPath);
                    }
                    string FullPathWithFileName = Path.Combine(sPath, fileName);
                    using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                    {
                        await CNICAttachment.CopyToAsync(stream);
                    }
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
        public async Task<IActionResult> Edit(int id, [Bind("BeneficiaryIPId,BeneficiaryName,BeneficiaryFather,Gender,CNIC,Mobile,Age,MaritialStatus,IsDisable,CNICAttachment,IsRefugee,ProfilePicture,District,Tehsil,UnionCouncil    ,SurveyDate, NextOfKin, NextOfKinCNIC")] BeneficiaryIP beneficiaryIP, IFormFile ProfilePicture)
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
