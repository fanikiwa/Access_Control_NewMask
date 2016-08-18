var backLevel = 0;
var levelCaption;

$(document).ready(function () {

    $("#img").load(function () {
        setImgMargins(this.width, this.height);
    });

    var imageurl = $("#img").attr("Src");
    $("#img").attr("Src", imageurl);

    $("#btnPersonalSearch").click(function (evt) {
        evt.preventDefault();

        SearchPersonal();
    });

    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        if (backLevel === 0) {
            window.location.href = "/Content/GateMonitor.aspx";
        }
        else if (backLevel === 1) {
            HidePersonal();
        } 
    });

    FetchQueryString();

    $("#btnPersonal").click(function (evt) {
        evt.preventDefault();
    });

    //$("#btnApplyPers").click(function (evt) {
    //    evt.preventDefault(); 
    //    HidePersonal();
    //});

    $("#btnApplyPers").click(function (evt) {
        evt.preventDefault();
        var index = grdSearchPersonal.GetFocusedRowIndex();
        if (parseInt(index) >= 0) {
            var id = grdSearchPersonal.GetRowKey(index);
            if (parseInt(id) > 0) {
                PageMethods.Getpersonal(id, HidePersonalAndSetControls);
            }
        }
        //HidePersonal();
    });

    $("#txtCardNumber").change(function (e) {
        //e.preventDefault();
        SearchPersonalWithCardNumber();
    });

    $("#txtCardNumber").focus();
})

function HidePersonalAndSetControls(Responce) {

    HidePersonal();

    Setcontrals(Responce);
}

function SearchPersonalWithCardNumber()
{
    PageMethods.GetPersonalWithCardNumber($("#txtCardNumber").val(), Setcontrals);
}
function SearchPersonal() {
    $(".midarea1").hide();
    $("#midarea1").hide();
    $(".leftinfo1").hide();
    $(".leftinfo2").hide();
    $(".searchPersonal").show();
    $("#btnApplyPers").show();
    getLocalizedText("personnelsearch");
    $("#pagenamelbl").text(levelCaption);

    backLevel = 1;
}

function HidePersonal() {
    $(".midarea1").show();
    $("#midarea1").hide();
    $(".leftinfo1").hide();
    $(".leftinfo2").hide();
    $(".searchPersonal").hide();
    $("#btnApplyPers").hide();
    getLocalizedText("personnelcheck");
    $("#pagenamelbl").text(levelCaption);

    backLevel = 0;
}

function BindSelectedPers(value) {
    HidePersonal();
    SetValues(value);
}

function SetValues(value) {

    PageMethods.Getpersonal(value, Setcontrals);
}

function GetVisitorCompanyDetails() {
    PageMethods.GetVisCompany(value, SetVisitorCompanyControlsData);
}

function Setcontrals(Responce) {
    try {
        if (Responce.Pers_Nr !== null && Responce.Pers_Nr !== 0) {
            cboPersNr.SetValue(Responce.Pers_Nr);
            if (Responce.ClientID !== null) {
                $("#txtVisitorCompanyName").val(Responce.ClientName);
                $("#txtVisitorCompanyNr").val(Responce.clientNr);
            } else {
                $("#txtVisitorCompanyName").val("keine");
                $("#txtVisitorCompanyNr").val("0");
            }

            $("#txtLastName").val(Responce.LastName);
            $("#txtFirstName").val(Responce.FirstName);
            $("#txtCompany").val(Responce.companyName);
            $("#txtStreet").val(Responce.Street);
            $("#txtStreetNr").val(Responce.StreetNr);
            $("#txtPostalCode").val(Responce.PostalCode);
            $("#txtIdNr").val(Responce.Pers_Nr);
            $("#txtPlace").val(Responce.PhysicalAddress);
            $("#txtCarReg").val(Responce.CarRegnumber);
            $("#txtMemo").val(Responce.Memo);

            $("#txtAccessEntry").val(Responce.AccessEntryDate);
            $("#txtAccessExit").val(Responce.ExitAccessDate);

            $("#txtPersonType").val(Responce.Name);

            $("#img").attr("Src", Responce.PassPhoto);
            $("#txtAccessPlanNr").val(Responce.AccessPlanNr);
            $("#txtAccessPlanDescription").val(Responce.AccessPlanDescription);

            setTimeout(function () { $("#txtCardNumber").focus().select() }, 4);
        }
    } catch (e) { console.log(e); }
}
//$(function () {
//    $("#btnDocument").click(function (evt) {
//        evt.preventDefault();
//        document.location.href = "/Content/GatePersonalDocument.aspx";
//    });
//})

function SetVisitorCompanyControlsData(result) {
    try {
        if (result.ID !== null && result.ID !== 0) {
            if (result.ID !== null) {
                $("#txtVisitorCompanyName").val(result.CompanyName);
                $("#txtVisitorCompanyNr").val(result.CompanyNr);
            } else {
                $("#txtVisitorCompanyName").val("keine");
                $("#txtVisitorCompanyNr").val("0");
            }
        }
    } catch (e) { console.log(e); }
}

function FetchQueryString() {
    var qrStr = window.location.search;
    var spQrStr = qrStr.substring(1);
    var arrQrStr = new Array();

    var arr = spQrStr.split("&");
    for (var i = 0;i < arr.length;i++) {
        var index = arr[i].indexOf("=");
        var key = arr[i].substring(0, index);
        var val = arr[i].substring(index + 1);
        arrQrStr[key] = val;
    }

    if (arrQrStr["0F88"] != null) {
        TempID = arrQrStr["0F88"];

        SetValues(TempID);

    }
    if (arrQrStr["ID"] != null) {
        TempID = arrQrStr["ID"];

        SetValues(TempID);
    }
    if (arrQrStr.length == 0) {
    }
}

function getLocalizedText(key) {
    var data = { key: key };
    $.ajax({
        type: "POST",
        async: false,
        url: "GatePersonal.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}


function setImgMargins(width, height) {
    var img = $get('img');
    var holderHeight = $('#Photoholder').height();
    var holderWidth = $('#Photoholder').width();
    if (img != null) {
        //var width = img.clientWidth;
        //var height = img.clientHeight;

        if (height <= holderHeight) {
            var marginTopBottom = Math.floor(((holderHeight - height) / 2));
            $("#img").attr("margin-top", marginTopBottom + "px");
            $("#img").attr("margin-bottom", marginTopBottom + "px");
        }
        else {
            $("#img").attr("max-height", holderHeight + "px");
            $("#img").attr("width", "100%");
            $("#img").attr("height", "auto");
        }

        if (width <= holderWidth) {
            var marginLeftRight = Math.floor(((holderWidth - width) / 2));
            $("#img").attr("margin-left", marginLeftRight);
            $("#img").attr("margin-right", marginLeftRight);
        }
        else {
            $("#img").attr("max-width", holderWidth + "px");
            $("#img").attr("width", "100%");
            $("#img").attr("height", "auto");
        }
    }
}
