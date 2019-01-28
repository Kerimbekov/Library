using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class Reader
    {
        public int ReaderId { get; set; }
        [Required] //obrobota oshibki vvoda
        public string Name { get; set; }
        
        public string Adress { get; set; }
        public int BiletId { get; set; }
        public int BirthYear { get; set; }
        [Phone]//prinimaetsua tolko tel.nomer
        public int PhomeNumber { get; set; }
        public List<Book> ReaderBooks { get; set; }
    }
}
