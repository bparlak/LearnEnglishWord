using LearnEnglishWord.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglishWord.Models
{
    public class WordList
    {
        public Kelimeler kelimeler { get; set; }
        public List<Kelimeler> answerList { get; set; }
        public string answer { get; set; }
        public string warning { get; set; }
    }
}
