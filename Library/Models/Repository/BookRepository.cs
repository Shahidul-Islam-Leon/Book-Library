using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models.Repository
{
    public class BookRepository : Repository<Book>
    {

        DBEntities context = new DBEntities();

        //public Book GetId(int id)
        //{


        //     var FileById = (from item in GetALLData()
        //                    where item.Id.Equals(id)
        //                    select new { item.PdfName, item.BookData }).ToList().FirstOrDefault();

        //    return this.GetALLData().Where(x =>( x.Id = id).Select()



        //}

    }
}