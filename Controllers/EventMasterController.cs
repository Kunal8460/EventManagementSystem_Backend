using ems.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventMasterController : ControllerBase
    {
        private readonly emsContext _context;
        public EventMasterController(emsContext context)
        {
            _context = context;
        }
        // GET: api/<EventMasterController>
        [HttpGet]
        public Response<List<EventMaster>> GetAll()
        {
            try {
                return new Response<List<EventMaster>>
                {
                    Status = true,
                    Message = "All Event Get",
                    Data = _context.EventMaster.ToList()
                };
            }
            catch (Exception e) {
                return new Response<List<EventMaster>>
                {
                    Status = false,
                    Message = "Data Not Get",
                    Data = null
                };
            }
           
        }

        // GET api/<EventMasterController>/5
        [HttpGet("{id}")]
        public async Task<Response<EventMaster>> GetEvent(int id)
        {
            try
            {
                EventMaster data = await _context.EventMaster.Include(x => x.Category).SingleOrDefaultAsync(x => x.event_id == id);
                //data.Category = await _context.EventCategory.SingleOrDefaultAsync(x=>x.category_id == data.category_id);
                return new Response<EventMaster>
                {
                    Status = true,
                    Message = "Event Get",
                    Data = data
                };
            }
            catch (Exception e)
            {
                return new Response<EventMaster>
                {
                    Status = false,
                    Message = "Data Not Get",
                    Data = null
                };
            }

        } 

        [HttpPost]
        public Response<EventMaster> AddEvent(EventMaster em)
        {
            try
            {
                _context.EventMaster.Add(em);
                _context.SaveChanges();
                return new Response<EventMaster>
                {
                    Status = true,
                    Message = "Data Addedd",
                    Data = em
                };
            }
            catch (Exception e)
            {
                return new Response<EventMaster>
                {
                    Status = false,
                    Message = "Not Added",
                };
            }
        }

        [HttpPut("{id}")]
        public Response<EventMaster> EditEvent(int id,EventMaster data)
        {
            try {
                EventMaster updateData = _context.EventMaster.Where(x => x.event_id == id).SingleOrDefault();
                updateData.event_title = data.event_title;
                updateData.category_id = data.category_id;
                updateData.event_description = data.event_description;
                updateData.event_start_date = data.event_start_date;
                updateData.event_end_date = data.event_end_date;
                updateData.event_start_time = data.event_start_time;
                updateData.event_end_time = data.event_end_time;
                updateData.event_venue = data.event_venue;
                updateData.city = data.city;
                updateData.state = data.state;
                updateData.country = data.country;
                updateData.ThumbnailImage = data.ThumbnailImage;
                updateData.GalleryImage = data.GalleryImage;
                updateData.CreatedAt = data.CreatedAt;
                updateData.UpdatedAt = data.UpdatedAt;
                updateData.CustomerEmail = data.CustomerEmail;
                _context.SaveChanges();
                return new Response<EventMaster>
                {
                    Status = true,
                    Message="Updated Succesfully",
                    Data=updateData
                };
            }
            catch (Exception e) {
                return new Response<EventMaster>
                {
                   Status=false,
                   Message=e.Message,
                   Data=null
                };
            }  
        }

        // DELETE api/<EventMasterController>/5
        [HttpDelete("{id}")]
        public Response<EventMaster> Delete(int id)
        {
            try
            {
               EventMaster removedata= _context.EventMaster.Where(x => x.event_id == id).SingleOrDefault();
                _context.EventMaster.Remove(removedata);
                return new Response<EventMaster>
                {
                    Status = true,
                    Message = "Deleted",
                    Data = removedata
                };
            }
            catch (Exception e)
            {
                return new Response<EventMaster>
                {
                    Status=false,
                    Message=e.Message,
                    Data=null
                }; 
            }
        }
    }
}
