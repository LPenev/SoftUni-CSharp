﻿namespace FastFood.Core.Controllers
{
    using System;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly FastFoodContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(FastFoodContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Register()
        {
            var positions = await _context.Positions
                .ProjectTo<RegisterEmployeeViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return View(positions);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterEmployeeInputModel model)
        {
            // Missing PositionName
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var employee = _mapper.Map<Employee>(model);
            
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            var employees = await _context.Employees
                .ProjectTo<EmployeesAllViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return View(employees);
        }
    }
}
