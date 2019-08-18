using System;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hamgooonWebServerV1.Data;
using hamgooonWebServerV1.Models;
using System.IO;

namespace hamgooonWebServerV1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        private readonly IHostingEnvironment _appEnvironment;
        private readonly HamgooonContext _context;
        public ImagesController(IHostingEnvironment appEnvironment, HamgooonContext context)

        {

            //----< Init: Controller >----

            _appEnvironment = appEnvironment;
            _context = context;
            //----</ Init: Controller >----

        }

        public class FIleUploadAPI
        {
            public IFormFile files { get; set; }
        }


        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImage()
        {
            return await _context.Image.ToListAsync();
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(long id)
        {
            var image = await _context.Image.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }

        [HttpPost("upload")] //Postback

        public async Task<IActionResult> Post(IFormFile file)
        {
            //--------< Upload_ImageFile() >--------

            //< check >

            if (file == null || file.Length == 0) return Content("file not selected");

            //</ check >



            //< get Path >

            string path_Root = _appEnvironment.WebRootPath;

            string path_to_Images = path_Root + "\\Images\\" + file.FileName;

            //</ get Path >



            //< Copy File to Target >

            using (var stream = new FileStream(path_to_Images, FileMode.Create))

            {

                await file.CopyToAsync(stream);

            }

            //</ Copy File to Target >



            //< output >



            return Ok(file.FileName.ToString());


        }

        // POST: api/Images
        [HttpPost]
        public async Task<ActionResult<Image>> PostImage(Image image)
        {
            _context.Image.Add(image);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImage", new { id = image.Id }, image);
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Image>> DeleteImage(long id)
        {
            var image = await _context.Image.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Image.Remove(image);
            await _context.SaveChangesAsync();

            return image;
        }

        private bool ImageExists(long id)
        {
            return _context.Image.Any(e => e.Id == id);
        }

        private string url(string url)
        {
            return url ;
        }
    }
}
