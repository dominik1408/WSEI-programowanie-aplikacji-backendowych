﻿using CarSharingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarSharingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CarModelsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CarModelsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarModel>>> GetCarModel()
        {
            return await _context.CarModels.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarModel>> GetCarModel(int id)
        {
            var carModel = await _context.CarModels.FindAsync(id);

            if (carModel == null)
            {
                return NotFound();
            }

            return Ok(carModel);
        }

        [HttpPost]
        public async Task<ActionResult<CarModel>> PostCarModel(CarModel carModel)
        {
            var model = new CarModel
            {
                Name = carModel.Name
            };

            _context.CarModels.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarModel),
                new { id = model.CarModelId },
                model);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarModel(int id)
        {
            var carModel = await _context.CarModels.FindAsync(id);
            if(carModel == null)
            {
                return NotFound();
            }

            _context.CarModels.Remove(carModel);
            await _context.SaveChangesAsync();  

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarModel(CarModel carModel, int id)
        {
            if(id != carModel.CarModelId)
            {
                return BadRequest("This model not exist");
            }

            var model = await _context.CarModels.FindAsync(id);
            if(model == null)
            {
                return NotFound(new { message = "Element not found" });
            }

            model.Name = carModel.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException) when (!CarModelExist(id))
            {
                return NotFound();
            }

            return Ok(model);
        }
        
        private bool CarModelExist(int id)
        {
            return _context.CarModels.Any(a => a.CarModelId == id);
        }
    }
}
