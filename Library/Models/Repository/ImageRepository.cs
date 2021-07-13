using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models.Repository
{
    public class ImageRepository : Repository<Image>
    {
        DBEntities context = new DBEntities();
        public Image GetImageData(byte[] data)
        {

            return this.context.Set<Image>().Find(data);

        }



    }
}