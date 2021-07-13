using MaharChildrenAcademyService.Interfaces;
using MaharChildrenAcademyService.Models;
using MaharChildrenAcademyService.Models.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaharChildrenAcademyService.Areas.MaharAdmin.Controllers
{

        [Route("Service/MaharAdmin/[controller]")]
        [ApiController]
        public class GalleryController : ControllerBase
        {
            private readonly MaharChildrenAcademyDBContext _context;
        private readonly IMaharAdmin _admin;
            

            public GalleryController(MaharChildrenAcademyDBContext context,IMaharAdmin admin)
            {
                _context = context;
            _admin = admin;                
            }
        [HttpPost("All")]
        public async Task<ActionResult<IEnumerable<CustomAlbum>>> GetAlbums()
        {
        //    var stocks = await _stocks.GetAllStocks();
          return Ok();
        }

        [HttpPost("album/{id}")]
        public async Task<ActionResult<CustomAlbum>> GetAlbumById([FromRoute] long id)
        {
            //var stock = await _stocks.GetStock(id);

            return Ok();
        }

        [HttpPost("Add")]
        public async Task<ActionResult<bool>> PostAlbum(CustomAlbum album)
        {
            var result = await _admin.AddAlbum(album);
            return Ok(result);

        }
    }
}
