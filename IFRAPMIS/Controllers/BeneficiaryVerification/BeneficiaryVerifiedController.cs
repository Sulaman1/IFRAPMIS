using DAL.Models.Domain.Damage;
using DAL.Models.Domain.MasterSetup;
using Humanizer;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

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

        public IActionResult ListBeneficiaries(string error="none")
        {
            List<BeneficiaryListViewModel> emptyBeneficiariesList = new List<BeneficiaryListViewModel>();
            return View(emptyBeneficiariesList);
        }

        public IActionResult ListBeneficiariesVerify()
        {
            // Fetch data from context, ensuring non-null lists
            var beneficiariesIP = _context.BeneficiaryIPs?.ToList() ?? new List<BeneficiaryIP>();
            var beneficiariesPDMA = _context.BeneficiaryPDMAs?.ToList() ?? new List<BeneficiaryPDMA>();
            // Fetch DamageIP and DamagePDMA data, using null-coalescing to ensure non-null lists
            var damageIP = _context.DamageIPs?.ToList() ?? new List<DamageIP>(); // Initialize as empty list if null
            var damagePDMA = _context.DamagePDMAs?.ToList() ?? new List<DamagePDMA>(); // Initialize as empty list if null

            var allBeneficiaries = beneficiariesIP
               .GroupJoin(
                   beneficiariesPDMA,
                   ip => ip.CNIC,
                   pdma => pdma.CNIC,
                   (ip, pdmaGroup) => new
                   {
                       BeneficiaryIP = ip,
                       PDMAGroup = pdmaGroup.DefaultIfEmpty() // Allows for a default value if no match is found
                   })
               .SelectMany(
                   x => x.PDMAGroup,
                   (x, pdma) => new BeneficiaryListViewModel
                   {
                       BeneficiaryIPId = x.BeneficiaryIP.BeneficiaryIPId,
                       BeneficiaryPDMAId = pdma?.BeneficiaryPDMAId ?? 0, // Default to 0 if null
                       BeneficiaryNameIP = x.BeneficiaryIP.BeneficiaryName,
                       BeneficiaryNamePDMA = pdma?.BeneficiaryName ?? "N/A",
                       CNIC = x.BeneficiaryIP.CNIC,
                       BeneficiaryFatherIP = x.BeneficiaryIP.BeneficiaryFather,
                       BeneficiaryFatherPDMA = pdma?.BeneficiaryFather ?? "N/A",
                       GenderIP = x.BeneficiaryIP.Gender,
                       GenderPDMA = pdma?.Gender ?? "N/A",
                       MobileIP = x.BeneficiaryIP.Mobile,
                       MobilePDMA = pdma?.Mobile ?? "N/A",
                       AgeIP = x.BeneficiaryIP.Age,
                       AgePDMA = pdma?.Age ?? 0,
                       MaritialStatusIP = x.BeneficiaryIP.MaritialStatus,
                       MaritialStatusPDMA = pdma?.MaritialStatus ?? "N/A",
                       IsDisableIP = x.BeneficiaryIP.IsDisable,
                       IsDisablePDMA = pdma?.IsDisable ?? false,
                       CNICAttachmentIP = x.BeneficiaryIP.CNICAttachment,
                       CNICAttachmentPDMA = pdma?.CNICAttachment,
                       IsRefugeeIP = x.BeneficiaryIP.IsRefugee,
                       IsRefugeePDMA = pdma?.IsRefugee ?? false,
                       ProfilePictureIP = x.BeneficiaryIP.ProfilePicture,
                       ProfilePicturePDMA = pdma?.ProfilePicture,
                       DistrictIP = x.BeneficiaryIP.District,
                       DistrictPDMA = pdma?.District ?? "N/A",
                       TehsilIP = x.BeneficiaryIP.Tehsil,
                       TehsilPDMA = pdma?.Tehsil ?? "N/A",
                       UnionCouncilIP = x.BeneficiaryIP.UnionCouncil,
                       UnionCouncilPDMA = pdma?.UnionCouncil ?? "N/A",
                       SurveyDateIP = x.BeneficiaryIP.SurveyDate,
                       SurveyDatePDMA = pdma?.SurveyDate,
                       NextOfKinIP = x.BeneficiaryIP.NextOfKin,
                       NextOfKinPDMA = pdma?.NextOfKin ?? "N/A",
                       NextOfKinCNICIP = x.BeneficiaryIP.NextOfKinCNIC,
                       NextOfKinCNICPDMA = pdma?.NextOfKinCNIC ?? "N/A",
                       IsVerifiedIP = x.BeneficiaryIP.IsVerified,
                       IsVerifiedPDMA = pdma?.IsVerified ?? false,
                       IsRejectedIP = x.BeneficiaryIP.IsRejected,
                       IsRejectedPDMA = pdma?.IsRejected ?? false,
                       IsOnHoldIP = x.BeneficiaryIP.IsOnHold,
                       IsOnHoldPDMA = pdma?.IsOnHold ?? false
                   })
               .Union(
                   beneficiariesPDMA
                       .GroupJoin(
                           beneficiariesIP,
                           pdma => pdma.CNIC,
                           ip => ip.CNIC,
                           (pdma, ipGroup) => new
                           {
                               BeneficiaryPDMA = pdma,
                               IPGroup = ipGroup.DefaultIfEmpty() // Allows for a default value if no match is found
                           })
                       .SelectMany(
                           x => x.IPGroup,
                           (x, ip) => new BeneficiaryListViewModel
                           {
                               BeneficiaryIPId = ip?.BeneficiaryIPId ?? 0,
                               BeneficiaryPDMAId = x.BeneficiaryPDMA.BeneficiaryPDMAId,
                               BeneficiaryNameIP = ip?.BeneficiaryName ?? "N/A",
                               BeneficiaryNamePDMA = x.BeneficiaryPDMA.BeneficiaryName,
                               CNIC = x.BeneficiaryPDMA.CNIC,
                               BeneficiaryFatherIP = ip?.BeneficiaryFather ?? "N/A",
                               BeneficiaryFatherPDMA = x.BeneficiaryPDMA.BeneficiaryFather,
                               GenderIP = ip?.Gender ?? "N/A",
                               GenderPDMA = x.BeneficiaryPDMA.Gender,
                               MobileIP = ip?.Mobile ?? "N/A",
                               MobilePDMA = x.BeneficiaryPDMA.Mobile,
                               AgeIP = ip?.Age ?? 0,
                               AgePDMA = x?.BeneficiaryPDMA.Age ?? 0,
                               MaritialStatusIP = ip?.MaritialStatus ?? "N/A",
                               MaritialStatusPDMA = x.BeneficiaryPDMA.MaritialStatus,
                               IsDisableIP = ip?.IsDisable ?? false,
                               IsDisablePDMA = x.BeneficiaryPDMA.IsDisable,
                               CNICAttachmentIP = ip?.CNICAttachment,
                               CNICAttachmentPDMA = x.BeneficiaryPDMA.CNICAttachment,
                               IsRefugeeIP = ip?.IsRefugee ?? false,
                               IsRefugeePDMA = x.BeneficiaryPDMA.IsRefugee,
                               ProfilePictureIP = ip?.ProfilePicture,
                               ProfilePicturePDMA = x.BeneficiaryPDMA.ProfilePicture,
                               DistrictIP = ip?.District ?? "N/A",
                               DistrictPDMA = x.BeneficiaryPDMA.District,
                               TehsilIP = ip?.Tehsil ?? "N/A",
                               TehsilPDMA = x.BeneficiaryPDMA.Tehsil,
                               UnionCouncilIP = ip?.UnionCouncil ?? "N/A",
                               UnionCouncilPDMA = x.BeneficiaryPDMA.UnionCouncil,
                               SurveyDateIP = ip?.SurveyDate,
                               SurveyDatePDMA = x.BeneficiaryPDMA.SurveyDate,
                               NextOfKinIP = ip?.NextOfKin ?? "N/A",
                               NextOfKinPDMA = x.BeneficiaryPDMA.NextOfKin,
                               NextOfKinCNICIP = ip?.NextOfKinCNIC ?? "N/A",
                               NextOfKinCNICPDMA = x.BeneficiaryPDMA.NextOfKinCNIC,
                               IsVerifiedPDMA = ip?.IsVerified ?? false,
                               IsVerifiedIP = x.BeneficiaryPDMA.IsVerified,
                               IsRejectedPDMA = ip?.IsRejected ?? false,
                               IsRejectedIP = x.BeneficiaryPDMA.IsRejected,
                               IsOnHoldPDMA = ip?.IsOnHold ?? false,
                               IsOnHoldIP = x.BeneficiaryPDMA.IsOnHold
                           })


               )
               .GroupBy(b => b.CNIC) // Group by CNIC to remove duplicates
               .Select(g => g.First()) // Select the first record from each group

               .ToList(); // Execute the query and convert to a list


            // Check if the request is AJAX
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { data = allBeneficiaries });
            }

            return Json(new { data = allBeneficiaries });
        }

        public IActionResult CompareBeneficiaries(string id)
        {
            var beneficiaryIP = _context.BeneficiaryIPs
                                .FirstOrDefault(b => b.CNIC == id);
            var beneficiaryPDMA = _context.BeneficiaryPDMAs
                                .FirstOrDefault(b => b.CNIC == id);
            DamageIP damageIP = null;// = new DamageIP();
            DamagePDMA damagePDMA = null ;// = new DamagePDMA();

            if (beneficiaryIP != null)
            {
                damageIP = _context.DamageIPs
                                .Where(ip => ip.BeneficiaryIPId == beneficiaryIP.BeneficiaryIPId)
                                .FirstOrDefault();
            }
            if(beneficiaryPDMA != null)
            {
                damagePDMA = _context.DamagePDMAs
                                  .Where(pdma => pdma.BeneficiaryPDMAId == beneficiaryPDMA.BeneficiaryPDMAId)
                                  .FirstOrDefault();
            }

            var viewModel = new CompareBeneficiaryViewModel
            {
                BeneficiaryIP = beneficiaryIP,
                BeneficiaryPDMA = beneficiaryPDMA,
                DamageIP = damageIP,
                DamagePDMA = damagePDMA
            };

            return View(viewModel);
        }        

        [HttpPost]
        public async Task<IActionResult> CompareBeneficiaries(CompareBeneficiaryViewModel model, IFormFile VerifiedCNICAttachment)
        {            
            // Remove the fields from ModelState to exclude them from validation
            ModelState.Remove("BeneficiaryIP");
            ModelState.Remove("BeneficiaryPDMA");             
            ModelState.Remove("DamageIP");
            ModelState.Remove("DamagePDMA");
            ModelState.Remove("BeneficiaryIPId");
            ModelState.Remove("BeneficiaryPDMAId");
            ModelState.Remove("DamageIPId");
            ModelState.Remove("DamagePDMAId");
            ModelState.Remove("VerifiedCNICAttachment");             

            var beneficiaryPDMA = await _context.BeneficiaryPDMAs
                                    .FirstOrDefaultAsync(b => b.CNIC == model.VerifiedCNIC);
            var beneficiaryIP = await _context.BeneficiaryIPs
                                .FirstOrDefaultAsync(b => b.CNIC == model.VerifiedCNIC);

            if (ModelState.IsValid)
            {
                if (beneficiaryPDMA != null)
                {
                    beneficiaryPDMA.IsVerified = true;
                    beneficiaryPDMA.IsRejected = false;
                    beneficiaryPDMA.IsOnHold = false;

                    ////Add Damage Data into Damage Table
                    //var damagePDMA = new DamagePDMA
                    //{
                    //    DamageHouseNoOfRooms = model.VerifiedDamageHouseNoOfRooms,
                    //    DamageHouseCategory = model.VerifiedDamageHouseCategory,
                    //    DamageShopNoOfRooms = model.VerifiedDamageHouseNoOfRooms,
                    //    DamageShopCategory = model.VerifiedDamageShopCategory,
                    //    DamageOtherNoOfRooms = model.VerifiedDamageHouseNoOfRooms,
                    //    DamageOtherCategory = model.VerifiedDamageOtherCategory,
                    //    CropLandArea = model.VerifiedCropLandArea,
                    //    OtherLandName = model.VerifiedOtherLandName,
                    //    OtherLandArea = model.VerifiedCropLandArea,
                    //    NumberOfTrees = model.VerifiedNumberOfTrees,
                    //    OtherTreeName = model.VerifiedOtherTreeName,
                    //    OtherTreeNumber = model.VerifiedOtherTreeNumber,
                    //    NumberOfAnimals = model.VerifiedNumberOfAnimals,
                    //    OtherAnimalName = model.VerifiedOtherAnimalName,
                    //    OtherAnimalNumber = model.VerifiedOtherAnimalNumber,
                    //    Attachment = model.VerifiedAttachment,
                    //    BeneficiaryPDMAId = model.BeneficiaryPDMAId ?? 0,
                    //    /**
                    //     * DamageAssessments Fields
                    //     */
                    //};

                }
                if (beneficiaryIP != null)
                {
                    beneficiaryIP.IsVerified = true;
                    beneficiaryIP.IsRejected = false;
                    beneficiaryIP.IsOnHold = false;

                    ////Add Damage Data into Damage Table
                    //var damageIP = new DamageIP
                    //{
                    //    DamageHouseNoOfRooms = model.VerifiedDamageHouseNoOfRooms,
                    //    DamageHouseCategory = model.VerifiedDamageHouseCategory,
                    //    DamageShopNoOfRooms = model.VerifiedDamageHouseNoOfRooms,
                    //    DamageShopCategory = model.VerifiedDamageShopCategory,
                    //    DamageOtherNoOfRooms = model.VerifiedDamageHouseNoOfRooms,
                    //    DamageOtherCategory = model.VerifiedDamageOtherCategory,
                    //    CropLandArea = model.VerifiedCropLandArea,
                    //    OtherLandName = model.VerifiedOtherLandName,
                    //    OtherLandArea = model.VerifiedCropLandArea,
                    //    NumberOfTrees = model.VerifiedNumberOfTrees,
                    //    OtherTreeName = model.VerifiedOtherTreeName,
                    //    OtherTreeNumber = model.VerifiedOtherTreeNumber,
                    //    NumberOfAnimals = model.VerifiedNumberOfAnimals,
                    //    OtherAnimalName = model.VerifiedOtherAnimalName,
                    //    OtherAnimalNumber = model.VerifiedOtherAnimalNumber,
                    //    Attachment = model.VerifiedAttachment,
                    //    BeneficiaryIPId = model.BeneficiaryIPId ?? 0,
                    //    /**
                    //     * DamageAssessments Fields
                    //     */
                    //};
                
                }

                // If no existing record, create a new one.
                var verifiedData = new BeneficiaryVerified
                {
                    BeneficiaryName = model.VerifiedName,
                    BeneficiaryFather = model.VerifiedFather,
                    Gender = model.VerifiedGender,
                    CNIC = model.VerifiedCNIC,                    
                    Mobile = model.VerifiedMobile,
                    Age = model.VerifiedAge ?? 0,
                    MaritialStatus = model.VerifiedMaritialStatus,
                    IsDisable = model.VerifiedIsDisable,
                    IsRefugee = model.VerifiedIsRefugee,
                    District = model.VerifiedDistrict,
                    Tehsil = model.VerifiedTehsil,
                    UnionCouncil = model.VerifiedUnionCouncil,
                    SurveyDate = model.VerifiedSurveyDate,
                    NextOfKin = model.VerifiedNextOfKin,
                    NextOfKinCNIC = model.VerifiedNextOfKinCNIC,
                    BeneficiaryIdentifiedFor = model.VerifiedIdentifiedFor,
                    SurveyTeamIPId = model.SurveyTeamIPId,
                    SurveyTeamPDMAId = model.SurveyTeamPDMAId,
                    BeneficiaryIPId = model.BeneficiaryIPId,
                    BeneficiaryPDMAId = model.BeneficiaryPDMAId
                };
                
                var dataFromValue = Request.Form["datafrom"].ToString();
                if (dataFromValue == "ip" && (VerifiedCNICAttachment == null || VerifiedCNICAttachment.Length == 0))
                {
                    verifiedData.CNICAttachment = beneficiaryIP.CNICAttachment;
                    //fileName = Path.GetFileName(beneficiaryIP.CNICAttachment);
                }
                if (dataFromValue == "pdma" && (VerifiedCNICAttachment == null || VerifiedCNICAttachment.Length == 0))
                {
                    verifiedData.CNICAttachment = beneficiaryPDMA.CNICAttachment;
                    //fileName = Path.GetFileName(beneficiaryPDMA.CNICAttachment);
                }

                if (VerifiedCNICAttachment != null && VerifiedCNICAttachment.Length > 0)
                {
                    Random random = new Random();
                    int randomNumber1 = random.Next(999, 100000);
                    var rootPath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\BenVerified_" + model.VerifiedDistrict + "\\cnic" + randomNumber1.ToString() + "\\");
                    string fileName = Path.GetFileName(VerifiedCNICAttachment.FileName);
                    int randomNumber2 = random.Next(999, 100000);
                    fileName = "BenVerified" + randomNumber2.ToString() + Path.GetExtension(fileName);
                    string sPath = Path.Combine(rootPath);

                    verifiedData.CNICAttachment = Path.Combine("/Documents/BenVerified_" + model.VerifiedDistrict + "/cnic" + randomNumber1.ToString() + "/" + fileName);

                    if (!System.IO.Directory.Exists(sPath))
                    {
                        System.IO.Directory.CreateDirectory(sPath);
                    }
                    string FullPathWithFileName = Path.Combine(sPath, fileName);
                    using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                    {
                        await VerifiedCNICAttachment.CopyToAsync(stream);
                    }
                }
               
                await _context.BeneficiaryVerifieds.AddAsync(verifiedData);
                await _context.SaveChangesAsync();

                return RedirectToAction("ListBeneficiaries", "BeneficiaryVerified"); // Redirect as needed
            }            

            var viewModel = new CompareBeneficiaryViewModel
            {
                BeneficiaryIP = beneficiaryIP,
                BeneficiaryPDMA = beneficiaryPDMA,

                VerifiedName = model.VerifiedName,
                VerifiedFather = model.VerifiedFather,
                VerifiedGender  = model.VerifiedGender,
                VerifiedCNIC = model.VerifiedCNIC,
                VerifiedMobile = model.VerifiedMobile,
                VerifiedAge  = model.VerifiedAge ?? 0,
                VerifiedMaritialStatus = model.VerifiedMaritialStatus,
                VerifiedIsDisable = model.VerifiedIsDisable,
                VerifiedIsRefugee = model.VerifiedIsRefugee,
                VerifiedDistrict = model.VerifiedDistrict,
                VerifiedTehsil = model.VerifiedTehsil,
                VerifiedUnionCouncil = model.VerifiedUnionCouncil,
                VerifiedSurveyDate = model.VerifiedSurveyDate,
                VerifiedNextOfKin = model.VerifiedNextOfKin,
                VerifiedNextOfKinCNIC = model.VerifiedNextOfKinCNIC,
                VerifiedIdentifiedFor = model.VerifiedIdentifiedFor,
                SurveyTeamIPId = model.SurveyTeamIPId,
                SurveyTeamPDMAId = model.SurveyTeamPDMAId,
                BeneficiaryIPId = model.BeneficiaryIPId,
                BeneficiaryPDMAId = model.BeneficiaryPDMAId
            };
            if (VerifiedCNICAttachment != null && VerifiedCNICAttachment.Length > 0)
            {
                if (Path.GetExtension(VerifiedCNICAttachment.FileName) != ".pdf")
                {
                    ModelState.AddModelError(nameof(viewModel.VerifiedCNICAttachment), "Please attach only Pdf file format.");
                }
            }

            return View(viewModel);
        }

        public async Task<IActionResult> RejectBeneficiary(string id, string comment)
        {
            var beneficiaryIP = await _context.BeneficiaryIPs
                                .FirstOrDefaultAsync(b => b.CNIC == id);
            var beneficiaryPDMA = await _context.BeneficiaryPDMAs
                                .FirstOrDefaultAsync(b => b.CNIC == id);

            if (beneficiaryPDMA != null)
            {
                beneficiaryPDMA.IsRejected = true;
                beneficiaryPDMA.IsOnHold = false;
                beneficiaryPDMA.IsVerified = false;
                beneficiaryPDMA.Comments = comment;
            }
            if (beneficiaryIP != null)
            {
                beneficiaryIP.IsRejected = true;
                beneficiaryIP.IsOnHold = false;
                beneficiaryIP.IsVerified = false;
                beneficiaryIP.Comments = comment;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("ListBeneficiaries");
        }
        public async Task<IActionResult> OnHoldBeneficiary(string id, string comment)
        {
            var beneficiaryIP = await _context.BeneficiaryIPs
                                .FirstOrDefaultAsync(b => b.CNIC == id);
            var beneficiaryPDMA = await _context.BeneficiaryPDMAs
                                .FirstOrDefaultAsync(b => b.CNIC == id);

            if (beneficiaryPDMA != null)
            {
                beneficiaryPDMA.IsOnHold = true;
                beneficiaryPDMA.IsRejected = false;
                beneficiaryPDMA.IsVerified = false;
                beneficiaryPDMA.Comments = comment;
            }
            if (beneficiaryIP != null)
            {
                beneficiaryIP.IsOnHold = true;
                beneficiaryIP.IsRejected = false;
                beneficiaryIP.IsVerified = false;
                beneficiaryIP.Comments = comment;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("ListBeneficiaries");
        }

        public async Task<ActionResult> BenefDetails(string? id)
        {
            var beneficiaryIP = await _context.BeneficiaryIPs
                                .FirstOrDefaultAsync(b => b.CNIC == id);
            var beneficiaryPDMA = await _context.BeneficiaryPDMAs
                                .FirstOrDefaultAsync(b => b.CNIC == id);

            if (beneficiaryPDMA != null)
            {
                return View(beneficiaryPDMA);
            }
            else
            {
                // Create a new instance of BeneficiaryPDMA
                var beneficiaryIPnew = new BeneficiaryPDMA
                {
                    BeneficiaryPDMAId = beneficiaryIP.BeneficiaryIPId, // Adjust if needed
                    CNIC = beneficiaryIP.CNIC,
                    BeneficiaryName = beneficiaryIP.BeneficiaryName,
                    BeneficiaryFather = beneficiaryIP.BeneficiaryFather,
                    Gender = beneficiaryIP.Gender,
                    Mobile = beneficiaryIP.Mobile,
                    Age = beneficiaryIP.Age,
                    MaritialStatus = beneficiaryIP.MaritialStatus,
                    IsDisable = beneficiaryIP.IsDisable,
                    CNICAttachment = beneficiaryIP.CNICAttachment,
                    IsRefugee = beneficiaryIP.IsRefugee,
                    District = beneficiaryIP.District,
                    Tehsil = beneficiaryIP.Tehsil,
                    UnionCouncil = beneficiaryIP.UnionCouncil,
                    SurveyDate = beneficiaryIP.SurveyDate,
                    NextOfKin = beneficiaryIP.NextOfKin,
                    NextOfKinCNIC = beneficiaryIP.NextOfKinCNIC,
                    ProfilePicture = beneficiaryIP.ProfilePicture
                };
                return View(beneficiaryIPnew);
            }
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
        // To protect from overposting attacks; enable the specific properties you want to bind to.
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
