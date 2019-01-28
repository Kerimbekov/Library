
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class VydachaBindingModel
    {
        //vybiraetsya odin chitetel i odin libo neskolko knig
        public Reader SelectedValue { get; set; }
        public IEnumerable<Book> MultiValue { get; set; }

        public IEnumerable<Reader> ReaderItems { get; set; }
        
        public IEnumerable<Book> BookItems { get; set; }

       
    }
}
