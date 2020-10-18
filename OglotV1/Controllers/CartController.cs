using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OglotV1.Helpers;
using OglotV1.Models;

namespace OglotV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        
        private readonly ApplicationDbContext _context;
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        decimal price = 0;
        [HttpPost]
        public async Task<ActionResult<List<PreprationRequestDetailes>>> AddToCart(int id)
        {
            // Subject subjectModel = new Subject();
            if (SessionHelper.GetObjectFromJson<List<PreprationRequestDetailes>>(HttpContext.Session, "cart") == null)
             {
                var subject = await _context.Subject.FindAsync(id);

                if (subject == null)
                {
                    return NotFound();
                }
                List<PreprationRequestDetailes> cart = new List<PreprationRequestDetailes>();
               
                
                cart.Add(new PreprationRequestDetailes
                {
                    SubjectId = id,
                    Subject = _context.Subject.FirstOrDefault(x => x.Id == id),
                    
                });
                //Navigation Loading
                await _context.Subject.Include(a => a.Semester).ThenInclude(b => b.Class).ThenInclude(c => c.Stage).Where(x => x.Id == id).ToListAsync();
                //Navigation Loading
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

                //CalculateCartPrice(cart);
                return  Ok(cart.Select(x => x.Subject));
            }
            else
            {
                var subject = await _context.Subject.FindAsync(id);

                if (subject == null)
                {
                    return NotFound();
                }

                List<PreprationRequestDetailes> cart = SessionHelper.GetObjectFromJson<List<PreprationRequestDetailes>>(HttpContext.Session, "cart");

                int index = isExist(id);

                if (index == -1)
                {
                    
                    cart.Add(new PreprationRequestDetailes
                    {
                        SubjectId = id,
                        Subject = _context.Subject.First(x => x.Id == id),
                       
                    });
                    //Navigation Loading
                    await _context.Subject.Include(a => a.Semester).ThenInclude(b => b.Class).ThenInclude(c => c.Stage).Where(x => x.Id == id).ToListAsync();
                    //Navigation Loading
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

                    //CalculateCartPrice(cart);
                    return Ok(cart.Select(x => x.Subject));
                }
                else
                {
                    return Ok(cart.Select(x => x.Subject));
                }
            }
        
        }

        private int isExist(int id)
        {
            List<PreprationRequestDetailes> cart = SessionHelper.GetObjectFromJson<List<PreprationRequestDetailes>>(HttpContext.Session, "cart");
            
            int index=-1;
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].SubjectId == id)
                {
                    index=i;
                }
               
            }
           
            return index;
        }
        [HttpGet]
        [Route("price")]
        public decimal CalculateCartPrice()
        {
            if (SessionHelper.GetObjectFromJson<List<PreprationRequestDetailes>>(HttpContext.Session, "cart") != null)
            {
                price = SessionHelper.GetObjectFromJson<List<PreprationRequestDetailes>>(HttpContext.Session, "cart").Sum(item => item.Subject.Price);
            }
            return price;
        }
        [HttpDelete]
        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<PreprationRequestDetailes> cart = SessionHelper.GetObjectFromJson<List<PreprationRequestDetailes>>(HttpContext.Session, "cart");
           
            int index = isExist(id);
            cart.RemoveAt(index);
            
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            
            return Ok(cart.Select(x=>x.Subject));
        }


    }

}


