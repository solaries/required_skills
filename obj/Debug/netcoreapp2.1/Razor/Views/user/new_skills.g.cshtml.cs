#pragma checksum "/home/sphinx/code/required skills/Views/user/new_skills.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c60ed49e60005dd22ce4a154ab6f01280d18f87d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_user_new_skills), @"mvc.1.0.view", @"/Views/user/new_skills.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/user/new_skills.cshtml", typeof(AspNetCore.Views_user_new_skills))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c60ed49e60005dd22ce4a154ab6f01280d18f87d", @"/Views/user/new_skills.cshtml")]
    public class Views_user_new_skills : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/home/sphinx/code/required skills/Views/user/new_skills.cshtml"
  
    List<Rs_71.Data.Models.Rs_71listing_site> data0 = (List<Rs_71.Data.Models.Rs_71listing_site>)@ViewBag.data0;

#line default
#line hidden
            BeginContext(130, 344, true);
            WriteLiteral(@"
<div class=""card"">


    <div class=""card-body"">
        <h4 class=""card-title"">New skills</h4>
        <div class=""form-validation"">
            <form id=""widgetu1290"" class=""form-valide"" action=""#"" method=""post"" enctype=""multipart/form-data"">
                <input id=""Skill"" name=""Skill"" type=""hidden"" value="""" />
                ");
            EndContext();
            BeginContext(475, 23, false);
#line 16 "/home/sphinx/code/required skills/Views/user/new_skills.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(498, 648, true);
            WriteLiteral(@"
                <div class=""form-group row"">
                    <label class=""col-lg-4 col-form-label"">Date</label>
                    <div class=""col-lg-6"">
                        <input id=""Date"" name=""Date"" required type=""datetime"" class=""form-control"" placeholder=""date"" />
                    </div>
                </div>

                <div class=""form-group row"">
                    <label class=""col-lg-4 col-form-label"">Site</label>
                    <div class=""col-lg-6"">
                        <select class=""form-control"" id=""Site"" name=""Site"">
                            <option value="""">Select Site</option>
");
            EndContext();
#line 29 "/home/sphinx/code/required skills/Views/user/new_skills.cshtml"
                             foreach (Rs_71.Data.Models.Rs_71listing_site item in data0)
                            {

#line default
#line hidden
            BeginContext(1267, 39, true);
            WriteLiteral("                                <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1306, "\"", 1322, 1);
#line 31 "/home/sphinx/code/required skills/Views/user/new_skills.cshtml"
WriteAttributeValue("", 1314, item.Id, 1314, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1323, 2, true);
            WriteLiteral("> ");
            EndContext();
            BeginContext(1326, 14, false);
#line 31 "/home/sphinx/code/required skills/Views/user/new_skills.cshtml"
                                                     Write(item.Site_name);

#line default
#line hidden
            EndContext();
            BeginContext(1340, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 32 "/home/sphinx/code/required skills/Views/user/new_skills.cshtml"
                            }

#line default
#line hidden
            BeginContext(1382, 11614, true);
            WriteLiteral(@"                        </select>
                    </div>
                </div>
                <!--
                <div class=""form-group row"">
                    <label class=""col-lg-4 col-form-label"">Skill</label>
                    <div class=""col-lg-6"">
                        <input id=""Skill"" name=""Skill"" required onkeyup=""doClean(this)"" type=""text"" class=""form-control""
                            maxlength=""60"" placeholder=""skill"" />
                    </div>
                </div>
                 -->








                <h4 class=""card-title"">Skill</h4>

 
                <div class=""table-responsive"">
                    <table id=""controllers"" class=""table table-striped table-bordered zero-configuration"">
                        <thead>
                            <tr>
                                <th>Skill 
                                </th> 
                            </tr>
                        </thead>
                        <tbody>
       ");
            WriteLiteral(@"                     <tr>
                                <td><input id=""Skill0"" name=""Skill0"" required
                                        onkeyup=""updateRowsControllers()"" type=""text"" class=""form-control""
                                        maxlength=""60"" placeholder=""Skill"" /></td> 
                            </tr>
                        </tbody>
                    </table>
                </div>





                <div class=""form-group row"">
                    <div class=""col-lg-8 ml-auto"">
                        <button type=""button"" class=""btn btn-primary"" onclick=""checkAndGo()"">Submit</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
</div>
<script>




    function updateRowsControllers() {  
        var i = 0;
        while (document.getElementById(""Skill"" + i) != null) {
            doClean(document.getElementById(""Skill"" + i), "" "");   
            i++;
        }  
        updateRowsControllers2()");
            WriteLiteral(@";  
        updateFormStructureControllers(); 

    }

     function updateRowsControllers2(){
            var strData = document.getElementById(""controllers"" ).innerHTML;
            var lenn =  strData.split(""<tr"").length -1;
            var table = document.getElementById(""controllers"");  
            var iii = 0;  
            for (i=0; i < lenn -2; i++){ 
                if(document.getElementById(""Skill"" + (i) ).value.trim().length == 0 ){
                    table.deleteRow(i+1);
                    for (j=i+1; j < lenn; j++){
                        if( table.rows[j ] !=null){
                            if(j%2 ==1){
                            }
                            else{
                            }
                            var row = table.rows[j]; 
                            var a_cell1x = row.cells[0] ;  
                            if(document.getElementById(""Skill""+(j) ) != null){                            
                                document.getElementByI");
            WriteLiteral(@"d(""Skill""+(j)).id =  ""Skill""+(j-1);
                                document.getElementById(""Skill""+(j-1)).name =  ""Skill""+(j-1);  
                            }
                        }
                    }
                    return;	
                } 
            }
 
            for (i=0; i < lenn -2; i++){ 
                for (j=i+1; j < lenn -1; j++){ 
                    if(document.getElementById(""Skill"" + (j)) != null ){
                        if(
                            document.getElementById(""Skill"" + (i) ).value.trim()
                            == 
                            document.getElementById(""Skill"" + (j) ).value.trim()
                        ){ 
                            if(table.rows.item(lenn-1).cells.item(0).firstChild.value == """"){
                                table.deleteRow(lenn -1); 
                            }
                            alert(""One of your skills is being repeated."");
                            return;	
                   ");
            WriteLiteral(@"     } 
                    }
                }
            }            
  
            if(  document.getElementById(""Skill"" + (lenn-2) ).value.trim().length == 0  ){
                    return;	
            } 
            addRowControllers((lenn-1).toString()
            ,'' 
            ); 
        }



    function addRowControllers(field1,field2 ){
            var table = document.getElementById(""controllers""); 
            var strData = document.getElementById(""controllers"" ).innerHTML;
            var lenn =  strData.split(""<tr"").length -1;         
            var row = table.insertRow(lenn );  
            var cell1 = row.insertCell(0);  
            var sel = """";
            cell1.innerHTML = '<input id=""Skill' +  field1 + '"" name=""Skill' +  field1 + '"" required onkeyup=""updateRowsControllers()"" type=""text"" class=""form-control"" maxlength=""60"" placeholder=""Skill"" />';
    }           




    function updateFormStructureControllers(){ 
        var formStructure = document");
            WriteLiteral(@".getElementById(""Skill"").value;
        var table = document.getElementById(""controllers"");  
        var formStructureTemp = """";
        var formStructureList = formStructure.split(""*sphinxrow*"");
        var rowDel = """";
        var foundSal = false;
        var strData = document.getElementById(""controllers"" ).innerHTML;
        var lenn =  strData.split(""<tr"").length -1;
        var iii = 0;  
        var add = false;
        var pos = 0;
        var itemList = """";
        for (i=1; i < lenn-1 ; i++){  
            var val = table.rows[i].cells[0].children[0].value;  
            add = true;
                if(( ""  "" +  itemList).indexOf(String.fromCharCode(3) + val + String.fromCharCode(3)) > -1){ 
                add = false; 
                }
                    if(add){
                        pos++;
                        itemList += String.fromCharCode(3) + val + String.fromCharCode(3) ; 
                        formStructureTemp += rowDel + val; 
                        //fo");
            WriteLiteral(@"rmStructureTemp +=    ""*sphinxcol*"" + val1;
                        //formStructureTemp +=    ""*sphinxcol*"" + val2;
                        //formStructureTemp +=    ""*sphinxcol*"" + val3;
                        rowDel  = ""*sphinxrow*"";  
                        var pageCount =0; 
                    }
        }  
        //pos++;
        //var pageCount =0;
        //if(document.getElementById(""SController"" + pageCount).options[pos] != null){ 
        //    pageCount =0;
        //    while(document.getElementById(""SController"" + pageCount)  != null){ 
        //        document.getElementById(""SController"" + pageCount).removeChild( document.getElementById(""SController"" + pageCount).options[pos]   );
        //        pageCount++;
        //    } 
        //    pageCount =0;
        //}
        formStructure = formStructureTemp;
        document.getElementById(""Skill"").value = formStructure; 
      //  alert(document.getElementById(""Skill"").value);
        return true;
    }   


    ");
            WriteLiteral(@"var selectedRights = """";
    function setRight(id) {
        selectedRights = document.getElementById(""selectedRights"").value;
        if (selectedRights.indexOf(""sphinxcol"" + id + ""sphinxcol"") > -1) {
            selectedRights = selectedRights.split(""sphinxcol"" + id + ""sphinxcol"").join("""");
        }
        else {
            selectedRights += ""sphinxcol"" + id + ""sphinxcol"";
        }
        document.getElementById(""selectedRights"").value = selectedRights;
    }
    function doClean(text) {
        text.value = text.value.split(""'"").join("""");
        text.value = text.value.split("">"").join("""");
        text.value = text.value.split(""<"").join("""");
        text.value = text.value.split(""~"").join("""");
        text.value = text.value.split(""&"").join("""");
        text.value = text.value.split(""\\"").join("""");
        text.value = text.value.split(""_"").join("""");
        text.value = text.value.split(""%"").join("""");
        text.value = text.value.split(""\"""").join("""");
    }
    function doCl");
            WriteLiteral(@"eanN(text) {
        var list = ""0123456789"";
        var data = text.value;
        for (i = 0; i < data.length; i++) {
            if (list.indexOf(data.substring(i, i + 1)) == -1) {
                data = data.split(data.substring(i, i + 1)).join("""");
            }
        }
        text.value = data;
    }
    function msg(txt) {
        sweetAlert(""..."", txt, ""info"");
    }
    function doCleanNumber(textBox) {
        var strVal;
        var strVal1;
        var strVal2;
        var dot;
        var i;
        var strComma;
        strVal2 = """";
        strComma = """";
        strVal1 = """";
        if (isNaN(textBox.value.split("","").join(""""))) {
            textBox.value = parseFloat(textBox.value.split("","").join(""""));
        }
        strVal = textBox.value;
        dot = 0;
        for (i = 0; i < strVal.length; i++) {
            if (strVal.substring(i, i + 1).indexOf('.') > -1) {
                dot = dot + 1;
            }
            if ((strVal.substring(i, i + 1).");
            WriteLiteral(@"indexOf('0') > -1) || (strVal.substring(i, i + 1).indexOf(""1"") > -1) || (strVal.substring(i, i + 1).indexOf(""2"") > -1) || (strVal.substring(i, i + 1).indexOf(""3"") > -1) || (strVal.substring(i, i + 1).indexOf(""4"") > -1) || (strVal.substring(i, i + 1).indexOf(""5"") > -1) || (strVal.substring(i, i + 1).indexOf(""6"") > -1) || (strVal.substring(i, i + 1).indexOf(""7"") > -1) || (strVal.substring(i, i + 1).indexOf(""8"") > -1) || (strVal.substring(i, i + 1).indexOf(""9"") > -1) || ((strVal.substring(i, i + 1).indexOf('.') > -1) && dot <= 1)) {
                strVal1 = strVal1 + strVal.substring(i, i + 1)
            }
        }
        if ((strVal1.indexOf('.') == 0)) {
            strVal1 = ""0"" + strVal1;
        }
        if (strVal1.indexOf('.') > 0) {
            if (((strVal1.length) - (strVal1.indexOf('.') + 1)) > 2) {
                strVal1 = strVal1.substring(0, strVal1.indexOf('.') + 3);
            }
        }
        strVal = """";
        if (strVal1.indexOf('.') != -1) {
            strVal = strV");
            WriteLiteral(@"al1.substring(strVal1.indexOf('.'), strVal1.indexOf('.') + 3);
            strVal1 = strVal1.substring(0, strVal1.indexOf('.'));
        }
        while (strVal1.length > 0) {
            if (strVal1.length > 3) {
                strVal2 = strVal1.substring(strVal1.length - 3, strVal1.length) + strComma + strVal2;
                strVal1 = strVal1.substring(0, strVal1.length - 3);
                strComma = "","";
            }
            else {
                strVal2 = strVal1 + strComma + strVal2;
                strVal1 = """";
            }
        }
        if (strVal2.indexOf('.') > 0) {
            strVal2 = strVal2.substring(0, strVal2.indexOf('.'));
        }
        textBox.value = strVal2 + strVal;
    }
    function checkAndGo() {

        doClean(document.getElementById(""Skill""));
        if (document.getElementById(""Date"").value.trim().length == 0) {
            msg(""Please enter date"");
            return;
        }
        if (document.getElementById(""Site"").value.trim(");
            WriteLiteral(@").length == 0) {
            msg(""Please select site"");
            return;
        }
        if (document.getElementById(""Skill"").value.trim().length == 0) {
            msg(""Please enter skill"");
            return;
        }

        document.getElementById(""widgetu1290"").submit();
    } 
</script>
<script>
    var statusMessage = """);
            EndContext();
            BeginContext(12997, 14, false);
#line 324 "/home/sphinx/code/required skills/Views/user/new_skills.cshtml"
                    Write(ViewBag.status);

#line default
#line hidden
            EndContext();
            BeginContext(13011, 802, true);
            WriteLiteral(@""" || false;
    if (statusMessage != false && statusMessage.length > 0) {
        msg(statusMessage);
    }
</script>

<style>
    #controllers_length , #controllers_filter, #controllers_paginate,#controllers_info
    ,#tables_length , #tables_filter, #tables_paginate,#tables_info
    ,#tableFields_length , #tableFields_filter, #tableFields_paginate,#tableFields_info
    ,#webPages_length , #webPages_filter, #webPages_paginate,#webPages_info
    {
        display: none;
    }

    h4{
        margin-top: 50px;
    }
    td{
        box-sizing: border-box !important;
    }
    input[type=""checkbox""]:after{
        display: none !important;
    }
    input{
        min-width: 150px !important;
    }
    select{
        min-width: 160px !important;
    }

</style>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
