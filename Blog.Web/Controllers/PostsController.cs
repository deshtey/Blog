using Blog.Data;
using Blog.Entities;
using Blog.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IBlogService _repository;
        private readonly UserManager<BlogUser> _userManager;

        public PostsController(IBlogService repository, UserManager<BlogUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var user = _userManager.GetUserId(User);
            return View(await _repository.GetPostsByUserAsync(user));
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
                var userId = _userManager.GetUserId(User);
                Post post = new()
                {
                    PublishedAt = DateTime.Now,
                    AuthorId = userId,
                    Title = postVm.Title,
                    Description = postVm.Description
                };
                var res = await _repository.AddPost(post);
                return RedirectToAction(nameof(Index));
            }
            return View(postVm);
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

    }
}
