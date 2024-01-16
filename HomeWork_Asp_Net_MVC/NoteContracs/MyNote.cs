using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteContracs
{
    public class MyNote
    {
        public int Id {  get; set; }

        //[Required(ErrorMessage = "Enter Name Note !!!. [MM/DD/YYYY]")]
        public string Name {  get; set; }

        public string Value { get; set; }

        public int Priority { get; set; }   
    }
}
