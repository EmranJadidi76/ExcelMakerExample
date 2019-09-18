using System.Linq;
using DataLayer;
using DataLayer.Entities;
using ExcelMaker.Contract;
using ExcelMaker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Table;

namespace ExcelMakerExample.Controllers
{
    public class HomeController : Controller
    {
        //************************AddExcelMaker******************************************************
        private readonly IExcelMaker _excelMaker;
        //***********************/AddExcelMaker******************************************************
        private readonly DatabaseContext _db;
        public HomeController(IExcelMaker excelMaker,DatabaseContext db)
        {
            _excelMaker = excelMaker;
            _db = db;
        }

        public IActionResult UseQuery()
        {
            var queryList = new QueryViewModel();

            queryList.AddQuery("select top 100 * from Person where IsMale = 0", "Female Person",TableStyles.Medium2);
            queryList.AddQuery("select * from Country", "Country", TableStyles.Medium20);
            queryList.AddQuery("select * from Car", "Car", TableStyles.Dark2);
            queryList.AddQuery("select top 100 * from Person where IsMale = 1", "Male Person", TableStyles.Dark10);

            // To use this method you need to configure the Dapper
            // See DataLayerConfiguration section
            var file = _excelMaker.ExcelMakeByQuery(queryList.GetList());

            if (file == null) return Json("Excel could not be made");
            
            return File(file, _excelMaker.ContentType(), "MyFile.xlsx");
        }


        public IActionResult UseDynamicList()
        {
            var dynamicList = new DynamicListViewModel();

            dynamicList.AddList<Person>(_db.Person.Where(a => a.IsMale).Take(100), "MalePerson", TableStyles.Dark11);
            dynamicList.AddList<Person>(_db.Person.Where(a => !a.IsMale).Take(100), "FeMalePerson", TableStyles.Dark11);
            dynamicList.AddList<Car>(_db.Car, "Cars", TableStyles.Dark11);
            dynamicList.AddList<Country>(_db.Country, "Country", TableStyles.Dark11);

            var file = _excelMaker.ExcelMakeByList(dynamicList.GetList());

            if (file == null) return Json("Excel could not be made");

            return File(file, _excelMaker.ContentType(), "MyFile.xlsx");
        }
    }
}
