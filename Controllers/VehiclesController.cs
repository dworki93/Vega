using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Domain;
using Vega.Persistence;
using Vega.Resources;

namespace Vega.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;

        public VehiclesController(VegaDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("api/vehicles/makes")]
        public async Task<IActionResult> GetMakes()
        {
            var makes = await _context.Makes
                .Include(m => m.Models).ToListAsync();

            return Ok(_mapper.Map<List<MakeResource>>(makes));
        }

        [HttpGet("api/vehicles/features")]
        public async Task<IActionResult> GetFeatures()
        {
            var features = await _context.Features
                .ToListAsync();

            return Ok(_mapper.Map<List<FeatureResource>>(features));
        }

        [HttpPost("api/vehicles")]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var vehicle = _mapper.Map<Vehicle>(vehicleResource);           
            vehicle.LastUpdate = DateTime.UtcNow;

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPut("api/vehicles/{id}")]
        public async Task<IActionResult> UpdateVehicle([FromBody] VehicleResource vehicleResource, int id) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await _context.Vehicles
                .Include(v => v.Features)
                .SingleOrDefaultAsync(v => v.Id == id);
                            
            if(vehicle == null)
                return NotFound();

            _mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);           
            vehicle.LastUpdate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            var result = _mapper.Map<VehicleResource>(vehicle);
            
            return Ok(result);
        }

        [HttpGet("api/vehicles/{id}")]
        public async Task<IActionResult> GetVehicle(int id) 
        {
            var vehicle = await _context.Vehicles
                .Include(v => v.Features)
                .SingleOrDefaultAsync(v => v.Id == id);
            
            if(vehicle == null)
                return NotFound();

            var vehicleResource = _mapper
                .Map<VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }

        [HttpDelete("api/vehicles/{id}")]
        public async Task<IActionResult> DeleteVehicle(int id) 
        {
            var vehicle = await _context.Vehicles
                .SingleOrDefaultAsync(v => v.Id == id);
            
            if(vehicle == null)
                return NotFound();

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return Ok(id);
        }
    }
}