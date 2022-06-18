using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace _3Insys.Assessments.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TShirtsController : ControllerBase
    {
        Data.DemoContext _context;
        public TShirtsController(Data.DemoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new Models.TShirtHomeModel(_context.TShirts.OrderByDescending(m => m.Id).ToList());

            return Ok(model);
        }

        [HttpGet]
        public IActionResult Manage(int id = 0)
        {
            var model = new Models.ManageTShirtModel();
            model.RequestedId = id;

            if (id.Equals(0))
                model.NewTShirt = true;

            else
            {
                var tshirt = _context.TShirts.Where(r => r.Id.Equals(id)).FirstOrDefault();

                if (tshirt != null)
                {

                    model.tShirt = new Models.TShirt(tshirt);
                }
            }

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Models.TShirt tshirt)
        {
            if (tshirt.Id > 0)
            {
                var data = _context.TShirts.Where(r => r.Id.Equals(tshirt.Id)).FirstOrDefault();

                if (data == null)
                {
                    return BadRequest("tshirt not found");
                }

                data.Description = tshirt.Description;
                data.Image = tshirt.Image;
                data.Color = tshirt.Color;
                data.Gender = tshirt.Gender;
                data.Made = tshirt.Made;
                data.Price = tshirt.Price;
                data.Size = tshirt.Size;
                data.Style = tshirt.Style;
            }
            else
            {
                _context.TShirts.Add(new Data.Entities.TShirt()
                {
                    Description = tshirt.Description,
                    Image = tshirt.Image,
                    Color = tshirt.Color,
                    Gender = tshirt.Gender,
                    Made = tshirt.Made,
                    Price = tshirt.Price,
                    Size = tshirt.Size,
                    Style = tshirt.Style
                });
            }

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var movie = _context.TShirts.Where(r => r.Id.Equals(id)).FirstOrDefault();

                if (movie == null)
                    return BadRequest("no movie found");

                _context.TShirts.Remove(movie);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}