using System;
using System.Collections.Generic;
using System.Text;
using EnsureThat;

namespace Lab
{
    class Todo
    {
        private ICollection<Book> bookRepository;

        public Todo(ICollection<Book> bookRepo)
        {
            EnsureArg.IsNotNull(bookRepo);
            bookRepository = bookRepo;
        }

 
    }
}
