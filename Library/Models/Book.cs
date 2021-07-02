//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.Genres = new HashSet<Genre>();
        }
    
        public int Id { get; set; }

        [Required(ErrorMessage = "*book title can't be empty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "*author can't be empty")]
        public string Author { get; set; }

        [Required(ErrorMessage = "*book edition required")]
        public string Edition { get; set; }


        [Required(ErrorMessage = "*book price required")]
        public double Price { get; set; }
        public string File { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Genre> Genres { get; set; }
    }
}
