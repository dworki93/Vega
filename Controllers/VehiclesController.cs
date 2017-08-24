using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [Route("api/makes")]
        public async Task<IActionResult> GetMakes()
        {
            var makes = await _context.Makes
                .Include(m => m.Models).ToListAsync();

            return Ok(_mapper.Map<List<MakeResource>>(makes));
        }

        [Route("api/features")]
        public async Task<IActionResult> GetFeatures()
        {
            var features = await _context.Features
                .ToListAsync();

            return Ok(_mapper.Map<List<FeatureResource>>(features));
        }
    }
}