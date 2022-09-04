using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.Data;
using Blog.Domain.Entities;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web
{
    public class PostsController : Controller
    {
        private readonly IBlogRepository _repository;

        public PostsController(IBlogRepository repository)
        {
            _repository = repository;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetPostsAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _repository.GetPostsByIdAsync(id);
            
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description")] PostViewModel postVm)
        {
            if (ModelState.IsValid)
            {
                Post post = new()
                {
                    PublicationDate = DateTime.Now,
                    CreatedBy = "SImon",
                    Title = postVm.Title,
                    Description = postVm.Description
                };
                var res = await _repository.AddPost(post);
                return RedirectToAction(nameof(Index));
            }
            return View(postVm);
        }

        
    }
}
