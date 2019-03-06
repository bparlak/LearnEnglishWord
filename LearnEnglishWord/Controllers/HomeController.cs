using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnEnglishWord.Models;
using LearnEnglishWord.Models.Entities;
using LearnEnglishWord.Models.Entities.Manager;
using Microsoft.AspNetCore.Mvc;

namespace LearnEnglishWord.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db;
        public HomeController(DatabaseContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            List<Kelimeler> wordList = new List<Kelimeler>();//genel tüm kelimeler
            List<WordList> viewWordList = new List<WordList>();//son halinde tutacağım liste
            Kelimeler word = new Kelimeler();
            WordList wList;
            var rand = new Random();
            int current = 0;
            wordList = db.Kelimeler.ToList();
            for (int i = 0; i < 10; i++)
            {
                wList = new WordList();
                wList.answerList = new List<Kelimeler>();
                current = rand.Next(wordList.Count);
                while (viewWordList.Where(x => (x.kelimeler.ID - 1) == current).FirstOrDefault() != null)//aynı soru tekrar gelmemesi için
                {
                    current = rand.Next(wordList.Count);
                }
                wList.kelimeler = wordList[current];

                for (int j = 0; j < 4; j++)
                {
                    current = rand.Next(wordList.Count);
                    while (wList.answerList.Where(x => (x.ID - 1) == current).FirstOrDefault() != null)//aynı cevaplar tekrar gelmemesi için
                    {
                        current = rand.Next(wordList.Count);
                    }
                    wList.answer = String.Empty;
                    wList.answerList.Add(wordList[current]);
                }
                wList.answerList.Add(wList.kelimeler);
                wList.answerList = wList.answerList.OrderByDescending(x => x.ID).ToList();
                wList.warning = "active";

                viewWordList.Add(wList);
            }
            IndexViewModel model = new IndexViewModel();
            model.viewWordList = viewWordList;
            model.trueAnswer = 0;
            model.falseAnswer = 0;
            model.emptyAnswer = 0;
            ViewBag.warn = "Mavi alanda verilen kelimelerin karşılığını şıklar arasından seçerek aşağıdaki kontrol et butonu ile cevaplarınızı kontrol edebilirsiniz.";
            ViewBag.color = "primary";
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(IndexViewModel model)
        {
            for (int i = 0; i < model.viewWordList.Count; i++)
            {
                if (Convert.ToInt32(model.viewWordList[i].answer) == model.viewWordList[i].kelimeler.ID)
                {
                    model.viewWordList[i].warning = "list-group-item-success";
                    model.trueAnswer++;
                }
                else if (model.viewWordList[i].answer == null)
                {
                    model.viewWordList[i].warning = "list-group-item-warning";
                    model.emptyAnswer++;
                }
                else
                {
                    model.viewWordList[i].warning = "list-group-item-danger";
                    model.falseAnswer++;
                }

            }
            if (model.trueAnswer == model.viewWordList.Count)
            {
                ViewBag.warn = "Tebrikler tüm sorulara doğru yanıt verdin.";
                ViewBag.color = "success";
            }
            else
            {
                ViewBag.warn = "Yanıtlanmamış yada doğru cevap verilmemiş sorular var.";
                ViewBag.color = "danger";
            }
            return View(model);
        }

    }
}