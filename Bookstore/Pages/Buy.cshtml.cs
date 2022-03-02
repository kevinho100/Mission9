using System;
using System.Linq;
using Bookstore.Infrastructure;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
    public class BuyModel : PageModel
    {
        private IBooksRepository repo { get; set; }

        public BuyModel(IBooksRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public Basket basket { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books p = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            
            basket.AddItem(p, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Books.BookId == bookId).Books);

            return RedirectToPage(new {ReturnUrl = returnUrl});
        }

    }
}
