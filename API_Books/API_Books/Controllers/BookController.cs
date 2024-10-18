using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Books.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        // GET: api/values
        [HttpGet]
        [Route("GetBooks")]
        public IEnumerable<Book> GetBooks()
        {
            List<Book> bookList = new List<Book>();
            bookList = DatabaseManager.GetBooks();
            Console.Write(bookList);

            return bookList;
        }

        // GET: api/values
        [HttpGet("{id}")]
        public Book GetBook(int id)
        {
            Book bk = new Book();
            bk = DatabaseManager.GetBook(id);
            return bk;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book book)
        {
            DatabaseManager.UpdateBook(id, book);
        }

    }
}

