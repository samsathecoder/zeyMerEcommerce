﻿using Microsoft.AspNetCore.Mvc;
using ZeyMer.Application.Interfaces;

namespace ZeyMer.API.Controller
{
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }
    }
}
