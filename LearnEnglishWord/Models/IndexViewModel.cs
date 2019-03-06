using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglishWord.Models
{
    public class IndexViewModel
    {
        public List<WordList> viewWordList { get; set; }
        public int trueAnswer { get; set; }
        public int falseAnswer { get; set; }
        public int emptyAnswer { get; set; }
    }
}
