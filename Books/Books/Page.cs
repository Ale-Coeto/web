using System;
namespace Books
{
	public class Page
	{
		public Page()
		{
		}

        public int page_id { get; set; }

        public int book_id { get; set; }

        public int page_no { get; set; }

        public string page { get; set; }
    }
}

