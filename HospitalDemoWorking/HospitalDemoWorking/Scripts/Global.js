function showSuccessMsg(msg) {

}
function getCities(cityName,cityId)
{
    $("#cities").html("");
    var params = "{'City':'" + $("[id$='txtCity']").val() + "'}";
        $.ajax({
            url: "../CommanMethods.aspx/GetCities",
            type: "POST",
            dataType: "json",
            data: params,
            contentType: "application/json; charset=utf-8"
        }).done(function (data) {
            
            var city = data.d;
            var html = "<ul>";
            for (var b = 0; b < city.length; b++) {                
                html += '<li onclick="getCity(this,\'' + cityId + '\',\'' + cityName + '\')">' + city[b].City_Name + '<span class="hidden cityId">' + city[b].City_ID + '</span><span  class="hidden cityName">' + city[b].City_Name + '</span></li>';
            }
            html += "</ul>";
            
            $("#cities").html(html).show();
        });
}
function getCity(elem, cityIdParm, cityNameParm) {    
    var cityId = $(elem).find(".cityId").html();
    var cityName = $(elem).find(".cityName").html();
    $("[id$='" + cityNameParm + "']").val(cityName);
    $("[id$='" + cityIdParm + "']").val(cityId);
    $("#cities").hide();
}


function getDepartments(ddlDepartment,firstText, needSubDept, ddlSubDepartment) {
    $.ajax({
        url: "../CommanMethods.aspx/GetDepartments",
        type: "POST",
        dataType: "json",
        data: {},
        contentType: "application/json; charset=utf-8"
    }).done(function (data) {       
        var department = data.d;
        var html = "<ul>";
        if (firstText != null)
        {
            html += "<option value='0'>" + firstText + "</option>";
        }
        for (var d = 0; d < department.length; d++) {
            html += "<option value='" + department[d].Dept_ID + "'>" + department[d].Dept_Name + "</option>";
        }                
        $("[id$='" + ddlDepartment + "']").html(html);
        if(needSubDept)
        {
            
            getSubDepartments(ddlSubDepartment,ddlDepartment);
        }
    });
}
function getSubDepartments(ddlSubDepartment,deptId) {
    var parm = "{'deptId':'" + $("[id$='" + deptId + "']").val() + "'}";
    $.ajax({
        url: "../CommanMethods.aspx/GetSubDepartments",
        type: "POST",
        dataType: "json",
        data: parm,
        contentType: "application/json; charset=utf-8"
    }).done(function (data) {
        
        var department = data.d;
        var html = "<ul>";
        for (var d = 0; d < department.length; d++) {
            html += "<option value='" + department[d].SubDeptID + "'>" + department[d].SubDeptName + "</option>";
        }
        $("[id$='" + ddlSubDepartment + "']").html(html);
    });
}
function showErroMessage(friendlyMsg, errorMsg) {
    $("#divMsg").removeClass().addClass("error").show();
    $("#divMsg").find("div.divfriendlyMsg").html(friendlyMsg);
    $("#divMsg").find("div.divErrorMsg").html(errorMsg);
}
function showHideElem(elem) {
    $("#" + elem).toggle();
}
function showSuccessMsg(msg) {
    $("#divMsg").hide().removeClass().addClass("success").slideDown(1000).fadeOut(9000);
    $("#divMsg").find("div.divfriendlyMsg").html(msg);
}
function closeMessageBox() {
    $("#divMsg").hide();
    $(".message-wrapper").hide();
}

function getCategoriesforDDL(DDL_Category) {
    $.ajax({
        url: "../CommanMethods.aspx/SearchCategories",
        type: "POST",
        dataType: "json",
        data: {},
        contentType: "application/json; charset=utf-8"
    }).done(function (data) {
        var Category = data.d;
        var html = "";
        for (var d = 0; d < Category.length; d++) {
            html += "<option value='" + Category[d].CategoryId + "'>" + Category[d].CategoryName + "</option>";
        }
        $("[id$='" + DDL_Category + "']").html(html);
        
    });
}