﻿using Application.Business.Abstract;
using Application.Core.Utilities.DataTransferObjects_DTO_;
using Application.Core.Utilities.DataTransferObjects_DTO_.App;
using Microsoft.AspNetCore.Mvc;

namespace AppController.MVC.Controllers;

public class AppController: Controller
{
    private readonly IAppManager _appManager;
    
    public AppController(IAppManager appManager)
    {
        _appManager = appManager;
    }
    
    public IActionResult GetById(Guid id)
    {
        var response = _appManager.GetById(id);

        if (response is null || !response.IsSuccess)
        {
            return View("Error");
        }
        
        return Json(response);
    }
    
    public IActionResult InsertApp(AppRequest request)
    {
        var response = _appManager.Insert(request);

        if (response is null || !response.IsSuccess)
        {
            return View("Error");
        }
        
        return Json(response);
    }
    
    public IActionResult GetList()
    {
        var response = _appManager.GetList();

        if (response is null || !response.IsSuccess)
        {
            return View("Error");
        }
        
        return Json(response);
    }
    
    public IActionResult Remove(RemoveEntityDTO removeEntityDto)
    {
        var response = _appManager.Remove(removeEntityDto);

        if (response is null || !response.IsSuccess)
        {
            return View("Error");
        }
        
        return Json(response);
    }
}