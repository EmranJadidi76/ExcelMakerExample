# ExcelMakerExample
Create Excel By Three Simple Steps

<h2>First</h2>
<p>You Must DownLoad  <a href="https://www.nuget.org/packages/ExcelMaker">ExcelMaker Nuget </P>
<h2>Second</h2>
<p>You Must AddService ExcelMaker in Startup</p>
<hr/>
<b>ExcelMaker.Startup.ConfigureService(services)</b>
<hr/>
<h2>Third : Use Sql Query</h2>
<p>*** Attention : To Use SqlQuery You Need Configure Dapper </p>
<p>Use : <b>var queryList = new QueryViewModel()</b></p>
<p>Add Query : <b>queryList.AddQuery(SqlQuery, Excel Worksheet Name,TableStyles)</b></p>
<p>Use Method : <b>var file = _excelMaker.ExcelMakeByQuery(queryList.GetList())</b></p>
<p>And you must return File : <b>return File(file, _excelMaker.ContentType(), "MyFile.xlsx")</b></p>
<h2>Third : Use Dynamic List</h2>
<p>Use : <b>var dynamicList = new DynamicListViewModel()</b></p>
<p>Add List : <b>dynamicList.AddList<@ListType>(YourList, WorkSheet Name, TableStyles);</b></p>
<p>Use Method : <b>var file = _excelMaker.ExcelMakeByList(dynamicList.GetList());</b></p>
<p>And you must return File : <b>return File(file, _excelMaker.ContentType(), "MyFile.xlsx")</b></p>
