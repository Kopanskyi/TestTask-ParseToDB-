using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask_ParseToDB_.Models
{
    public class Sentences
    {
        [Key]
        public int Id { set; get; }
        public string WordToSearch { set; get; }
        public string Sentence { set; get; }
        public int TimesWordOccursInSentence { set; get; }
    }
}
