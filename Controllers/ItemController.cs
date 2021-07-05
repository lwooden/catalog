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
        // private readonly InMemItemsRepository repository;
        private readonly IItemsRepository repository;
    
        // Constructor
        public ItemController(IItemsRepository repository) 
        {
            // repository = new InMemItemsRepository();
            this.repository = repository;
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