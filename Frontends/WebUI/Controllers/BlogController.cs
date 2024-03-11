﻿using Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
	public class BlogController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public BlogController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.v1 = "Blogs";
			ViewBag.v2 = "Blogs of Writers";
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7199/api/Blogs/GetAllBlogsWithAuthor");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public async Task<IActionResult> BlogDetail(int id)
		{
            ViewBag.v1 = "Blogs";
            ViewBag.v2 = "Blog Details & Comments";
            return View();
		}
	}
}
