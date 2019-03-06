using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglishWord.Models.Entities
{
    public class Kelimeler
    {
        public int ID { get; set; }
        public string Ingilizce { get; set; }
        public string Turkce { get; set; }
        public string YanAnlam { get; set; }
        public string Tip { get; set; }
        public int Derece { get; set; }
    }
}
