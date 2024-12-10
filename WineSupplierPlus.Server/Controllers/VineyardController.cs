using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineSupplierPlus.Server.Data;
using WineSupplierPlus.Server.Model;
using WineSupplierPlus.Server.ViewModel;

namespace WineSupplierPlus.Server.Controllers
{
    public class VineyardController : ControllerBase
    {
        private readonly WineSupplierContext _wineSupplierContext;

        public VineyardController(WineSupplierContext context)
        {
            this._wineSupplierContext = context;
        }


        // GET: VineyardController
        public IActionResult Index(int pageIndex=0,int pageSize=10)
        {
            BaseResponseModel res = new BaseResponseModel();
            try
            {
                var vineyardCount = _wineSupplierContext.Wineiries.Count();
                var vineyardList=_wineSupplierContext.Wineiries.Skip(pageIndex*pageSize).Take(pageSize).ToList();

                res.Status = true;
                res.Message = "Success";
                res.Data = new AllVineyardViewModel(vineyardCount, vineyardList);
                return Ok(res);
            }
            catch (Exception ex)
            {
                res.Status=false;
                res.Message=ex.Message;
                return BadRequest(ex);
            }
        }

        // GET: VineyardController/Details/id
        public async Task<IActionResult> Details(int id)
        {
            BaseResponseModel res = new BaseResponseModel();
            try
            {
                var vineyard = await _wineSupplierContext.Wineiries.Where(x => x.Id == id).FirstOrDefaultAsync();

                if(vineyard == null)
                {
                    res.Status = false;
                    res.Message = "Vineyard not found";
                    return BadRequest(res);
                }

                res.Status = true;
                res.Message = "Vineyard found";
                res.Data = new DetailedVineyardViewModel(vineyard);
                return Ok(res);
            }
            catch (Exception ex) {
                res.Status = false;
                res.Message = ex.Message;
                return BadRequest(ex);
            }
        }




        // POST: VineyardController/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddVineyardViewModel model)
        {
            BaseResponseModel res = new BaseResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    //check for duplicate name in DB...throw error if found
                    var vineyardForDup=await _wineSupplierContext.Wineiries.Where(x=>x.Name == model.Name).FirstOrDefaultAsync();

                    if(vineyardForDup != null)
                    {
                        res.Status=false;
                        res.Message = "Vineyard name already stored in Database.";
                        return BadRequest(res);
                    }

                    //once bottles are added to the db object check to make sure they're part of the db
                    //var bottles = _context.Bottle.Where(x => model.Bottles.Contains(x.Id)).ToList();
                    //if (bottles.Count != model.Bottles.Count)
                    //{
                    //    response.Status = false;
                    //    response.StatusMessage = "Invalid bottle assignmnt.";
                    //    return BadRequest(response);
                    //}

                    var postedModel = new Vineyard()
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Continent = model.Continent,
                        Region = model.Region,
                        // FoundingDate = model.FoundingDate,
                        //Themes = model.Themes
                    };

                    await _wineSupplierContext.Wineiries.AddAsync(postedModel);
                    await _wineSupplierContext.SaveChangesAsync();

                    res.Status = true;
                    res.Message = "Vineyard Created Succussfully";
                    res.Data = postedModel;
                    return Ok(res);
                }
                else
                {
                    res.Status = false;
                    res.Message = "Invalid data provided...";
                    return BadRequest(res);
                }
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Message = ex.Message;
                return BadRequest(res);
            }

        }





        //// GET: VineyardController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: VineyardController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: VineyardController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: VineyardController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
