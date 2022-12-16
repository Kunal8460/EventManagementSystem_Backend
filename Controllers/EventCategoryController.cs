using ems.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCategoryController : ControllerBase
    {
        // GET: api/<EventCategoryController>
        private readonly emsContext _context;
        public EventCategoryController(emsContext context)
        {
            _context = context;
        }
        [HttpGet]
        public  Response<List<EventCategory>>  GetAll()
        {
            try
            {
                return new Response<List<EventCategory>>
                {
                    Status = true,
                    Message = "Succesfully Get all!",
                    Data = _context.EventCategory.ToList()
                };

            }
            catch(Exception e)
            {
                return new Response<List<EventCategory>>
                {
                    Status = false,
                    Message = e.Message,
                };
            }                   
        }

        //GET api/<EventCategoryController>/5
        [HttpGet("{id}")]
        public Response<EventCategory> GetCategory(int id)
        {
            try
            {
                return new Response<EventCategory> { 
                     Status=true,
                     Message="Data Get",
                     Data= _context.EventCategory.Where(x=>x.category_id==id).SingleOrDefault()
                };
            }
            catch (Exception e)
            {
                return new Response<EventCategory>
                {
                    Status = false,
                    Message = e.Message,
                    Data = null
                };  
            }
             
        }

        // POST api/<EventCategoryController>
        
        [HttpPost]
        public  Response<EventCategory>  addcategory(EventCategory data)
        {
            try
            { 
                _context.EventCategory.Add(data);
                _context.SaveChanges();
                return new Response<EventCategory>
                {
                    Status=true,
                    Message="Data Post",                   
                    Data= data
                };
            }
            catch (Exception e)
            {
                return new Response<EventCategory>
                {
                    Status = false,
                    Message = e.Message                   
                };
            }
            
        }

        // PUT api/<EventCategoryController>/5
        [HttpPut("{id}")]
        public EventCategory EditCategory(int id,EventCategory data)
        {
            EventCategory UpdateData = _context.EventCategory.Where(x => x.category_id == id).SingleOrDefault();           
            UpdateData.category_name = data.category_name;
            _context.SaveChanges();
            return UpdateData;
        }

        // delete api/<eventcategorycontroller>/5
        [HttpDelete("{id}")]
        public EventCategory delete(int id)
        {
            EventCategory removeddata = _context.EventCategory.Where(x => x.category_id == id).FirstOrDefault();
            _context.EventCategory.Remove(removeddata);
            _context.SaveChanges();
            return removeddata;
        }
    }
}
