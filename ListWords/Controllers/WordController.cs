using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListWords.Models;

namespace ListWords.Controllers
{
    public class WordController : Controller
    {
        // GET: Word
        public ActionResult List()
        {
            var data = new List<Models.Words>();
            data = returnData().OrderByDescending(x => x.Count).Take(10).ToList();
            return View(data);
        }

        public List<Words> returnData()
        {
            string xmlData = Server.MapPath("~/XmlFile/result.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(xmlData);

             var wordList = new List<Words>();
             wordList = (from rows in ds.Tables[0].AsEnumerable()
                         select new Words
                         {
                             Word = rows[0].ToString(),
                             Count = Convert.ToInt32(rows[1].ToString()),
                         }).ToList();

            return wordList;
        }
    }
}