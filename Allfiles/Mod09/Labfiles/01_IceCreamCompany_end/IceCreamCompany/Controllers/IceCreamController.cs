﻿using IceCreamCompany.Data;
using IceCreamCompany.Models;
using IceCreamCompany.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IceCreamCompany.Controllers;

public class IceCreamController : Controller
{
    private IRepository _repository;
    private IWebHostEnvironment _environment;

    public IceCreamController(IRepository repository, IWebHostEnvironment environment)
    {
        _repository = repository;
        _environment = environment;
    }

    public IActionResult Index()
    {
        return View(_repository.GetIceCreamFlavors());
    }

    [HttpGet]
    public IActionResult Buy()
    {
        return View();
    }

    [HttpPost, ActionName("Buy")]
    public IActionResult BuyPost(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _repository.BuyIceCreamFlavor(customer);
            return RedirectToAction(nameof(ThankYou));
        }
        return View(customer);
    }

    public IActionResult ThankYou()
    {
        return View();
    }

    public IActionResult GetImage(int iceCreamId)
    {
        IceCream? requestedPhoto = _repository.GetIceCreamFlavorById(iceCreamId);
        if (requestedPhoto != null)
        {
            string webRootpath = _environment.WebRootPath;
            string folderPath = "\\images\\";
            string fullPath = webRootpath + folderPath + requestedPhoto.PhotoFileName;

            FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return File(fileBytes, requestedPhoto.ImageMimeType!);
        }
        else
        {
            return NotFound();
        }
    }
}