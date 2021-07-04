using System;
using System.Collections.Generic;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers {

    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly InMemItemsRepository repository;
    
        // Constructor
        public ItemController() 
        {
            repository = new InMemItemsRepository();
        }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return repository.GetItems();

        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item == null) {
                return NotFound();
            }
            return Ok(item);
        }

    }
}