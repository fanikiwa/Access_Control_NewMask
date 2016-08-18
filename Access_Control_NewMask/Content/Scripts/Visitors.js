//var levelCaption = 0;
var grdTranspondersRowNum = -1;
var grdTranspondersSTRowNum = -1;
var _message = "";
var ddlCompanyval = "";
var ConfirmDelete = false;
var isBack = false;
var saveChanges = false;
var _companyVal = "0";
var _companyToVal = "0";
var ClientID = 0;
var _isComDelete = false;
var _isSelection = false;
var _isFilter = false;
var doAfterBind = false;
var _callBackParam = "";
var SelectedTopCompanyVal;
var vehicleTypeIndex = -1;
var clientVisibleIndex = -1;
var TempClickedVehicleName;
var TempClickedvehicleTypeName;
var TempClickedvehicleTypeId = 0;
var applyPhoto = false;
var saveCompanyChanges = false;
var _cobCompanyClick = false;
var _URL = window.URL || window.webkitURL;

$(document).ready(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();

    $("#img").load(function () {
        setImgMargins(this.width, this.height);
    });

    var imageurl = $("#img").attr("Src");
    $("#img").attr("Src", imageurl);

    $("#btnActHelp").click(function (evt) {
        evt.preventDefault();

    }); 

    $("#btnVisitorBookOut").click(function (evt) {
        evt.preventDefault();

    });

    $("#btnSendData").click(function (evt) {
        evt.preventDefault();
        _sendVisitorData(false);
    });

    $("#btnVisitorPlanInfo").click(function (evt) {
        evt.preventDefault();

    });

    $("#btnVisitorBookOut").click(function (evt) {
        evt.preventDefault();
        _checkOutVisitor();
    });

    
    $("#btnSendLoginData").click(function (evt) {
        evt.preventDefault();
        _sendVisitorData(true);
    });
    $("#btnImageVisitorPlanInfo").click(function (evt) {
        evt.preventDefault();
        //var lockId = 1;
        //var planId = cobVisitorPlanNr.GetValue();
        //if (parseInt(planId) > 0) {
        //    document.location.href = String.format("/Content/VisitorPlan.aspx?profileId={0}&lock={1}", planId, lockId);
        //}
    });
    $("#btnApplyCompany").click(function (evt) {
        evt.preventDefault();
        if (parseInt(cobCompanyNr.GetValue()) > 0) {
            $("#txtVisitorCompanyName").val(cobCompanyName.GetText());
            $("#txtVisitorCompanyID").val(cobCompanyNr.GetValue());
            HideCopanyDetails();
        }

    });
    $("#btnApplyVehicleType").click(function (evt) {
        evt.preventDefault();
        var index = grdVehicleModel.GetFocusedRowIndex();
        if (parseInt(index) >= 0) {
            var id = grdVehicleModel.GetRowKey(index);
            var name = grdVehicleModel.GetRow(index).cells[0].childNodes[0].textContent;
            $("#txtVehicleId").val(id);
            $("#txtVehicleTypes").val(name);
            HideVehicleTypes();
        }

    });

    $("#btnSearchVisitors").click(function (evt) {
        evt.preventDefault();
        searchVisitors();

        $("#levelCaption").val(1);
    });

    $("#btnAcceptAccessPlan").click(function (evt) {
        evt.preventDefault();
        var index = grdVisitorDescription.GetFocusedRowIndex();
        if (parseInt(index) >= 0) {
            var id = grdVisitorDescription.GetRowKey(index);
            if (parseInt(id) > 0) {
                cobVisitorPlanNr.SetValue(id);
                cobVisitorPlanName.SetValue(id);
                hidevisitordata();
                $("#levelCaption").val(0);
            }
        }

    });

    $("#btnApplyVisitorData").click(function (evt) {
        evt.preventDefault();
        var index = grdVisitorsHistory.GetFocusedRowIndex();
        if (parseInt(index) >= 0) {
            var id = grdVisitorsHistory.GetRowKey(index);
            if (parseInt(id) > 0) {
                PageMethods.GetVisitorByIDToEdit(id, GetVisitorByIDToEdit_CallBack);
                HideHistory();
                $("#levelCaption").val(0);
            }
        }

    });

    $("#btnApplyVisitorApplications").click(function (evt) {
        evt.preventDefault();
        var index = grdFilteredVisitors.GetFocusedRowIndex();
        if (parseInt(index) >= 0) {
            var id = grdFilteredVisitors.GetRowKey(index);
            if (parseInt(id) > 0) {
                PageMethods.GetVisitorByInstance(id, OnGetVisitorByInstance_CallBack);
            }
        }
    });

    $("#btnRefresh").click(function (evt) {
        evt.preventDefault();
        //_isFilter = true;
        var id = "";
        var filter = ddlTopCompanyNrHistory.GetValue();
        SelectedTopCompanyVal = ddlTopCompanyNrHistory.GetValue();
        var param = id + ";" + filter;
        ddlVisitorNameHistory.PerformCallback(param);
        ddlVisitorIDHistory.PerformCallback(param);
        //grdFilteredVisitors.PerformCallback(filter);
        //grdSearchVisitors.PerformCallback(filter);
        grdVisitorsHistory.PerformCallback(filter);

    });


    $("#btnAcceptCompany").click(function (evt) {
        evt.preventDefault();
        var index = grdVisitorCompany.GetFocusedRowIndex();
        var ID = grdVisitorCompany.GetRowKey(index);

        if (parseInt(ID) == "undefined") {
            return;
        } else {
            if (parseInt(ID) < 1) return;
        }
        PageMethods.GetCompanyDetails(ID, OnGetCompanyDetails_CallBack);
        HideClienSeach();
        saveChanges = true;
    });


    $("#btnBackCompany").click(function (evt) {
        evt.preventDefault();
        if (saveCompanyChanges === true && allowZUTEdit) {
            ConfirmSaveCompanyDetails();
        }
        else {
            HideCompanyDetails();
        }
    });

    $("#btnDeleteCompany").click(function (evt) {
        evt.preventDefault();
    });

    $("#btnApplyCompanyTo").click(function (evt) {
        evt.preventDefault();
        window.grdClients.GetRowValues(clientVisibleIndex, "ID;Name", GetRowValuesDbClick);
    });

    $("#btnCompanyBack").click(function (evt) {
        evt.preventDefault();
        _isComDelete = false;
        $("#btnEntNew").show();
        $("#btnEntSave").show();
        $("#btnCancelDel").show();
        //ReloaddplCompanyName();
        HideCompanyGrid();
    });
    $('#btnNew').on("click", function (e) {
        e.preventDefault();
        _isComDelete = false;
        ClearControls();
        PageMethods.GetLastInsertedClient(FilltxtClientNr);
    });
    $('#btnNewCompany').on("click", function (e) {
        e.preventDefault();
        ClearCompanyControls();
        EnableControlsOnNew();
        cobCompanyNr.SetValue("0");
        cobCompanyName.SetValue("0");
        cobCompanyNr.SetEnabled(false);
        cobCompanyName.SetEnabled(false);
        PageMethods.GetLastInsertedVisitorCompany(FilltxtCompanyNr);
    });
    $('#btnSave').on("click", function (e) {
        e.preventDefault();
        _isComDelete = false;
        _companyVal = dplCompanyName.GetValue();
        _companyToVal = dplToCompanyNr.GetValue();
        var ClientNr = document.getElementById('txtClientNr').value;
        var ClientName = document.getElementById('txtClientName').value;
        PageMethods.InsertClient(ClientID, ClientNr, ClientName, OnInsertClient_CallBack);

    });
    $('#btnDelete').on("click", function (e) {
        e.preventDefault();
        if (ClientID === 0) return;
        _isComDelete = true;
        _companyVal = dplCompanyName.GetValue();
        _companyToVal = dplToCompanyNr.GetValue();
        PageMethods.DeleteClient(ClientID, OnDeleteClient_CallBack);
    });
    $("#btnBackCarType").click(function (evt) {
        evt.preventDefault();


    });
    $("#btnTakeWebcamPicture").click(function (evt) {
        evt.preventDefault();
        WebcamMode();
    });
    $("#btnCancelPhoto").click(function (evt) {
        evt.preventDefault();
        HideWebCam();
        hiddenStatus = 0;
    });
    $("#btnRegistration").click(function (evt) {
        evt.preventDefault();
        VisitorApplicationGrid();

        $("#levelCaption").val(11);
    });
    $("#btnVisApplication").click(function (evt) {
        evt.preventDefault();
        VisitorApphistory();

        $("#levelCaption").val(15);
    });
    $("#btnSerchClient").click(function (evt) {
        evt.preventDefault();
        serchclint();

        $("#levelCaption").val(18);
    });
    $("#btnSerchmandant").click(function (evt) {
        evt.preventDefault();
        serchmandant();

        $("#levelCaption").val(20);
    });
    $("#imgidentity").click(function (evt) {
        evt.preventDefault();

        $("#levelCaption").val(9);
        $("#tabcontroldiv").hide();
        $(".surchpersonalinfomation").show();
        $('#PageTitleLbl2').text("Ausweißverwaltung");

    });

    $("#ImageButton3").click(function (evt) {
        evt.preventDefault();
    });
    $("#imgSelection").click(function (evt) {
        evt.preventDefault();

        $("#levelCaption").val(10);
        UserSubmitButtons();
        $("#tabcontroldiv").hide();
        $("#ControlSection1").hide();
        $("#btnEntNew").hide();
        $("#btnEntSave").hide();
        $("#btnCancelDel").hide();
        $(".Dailystatement").show();
        $('#PageTitleLbl2').text("");
        $(".ControlSection").removeClass("ControlSectionremoveback");
    });
    $("#imgserchvisitorplan").click(function (evt) {
        evt.preventDefault();
        displayvisitordata();


        $("#levelCaption").val(5);
    });
    $("#btntranData").click(function (evt) {
        evt.preventDefault();
        displaytransponderdata();

        $("#levelCaption").val(6);
    });
    $("#btnsearchvehicle").click(function (evt) {
        evt.preventDefault();
        $("#UpperDiv").hide();
        $(".searchVehicletype").show();
        $("#btnEntNew").hide();
        $("#btnEntSave").hide();
        $("#btnCancelDel").hide();
        $('#btnBack').addClass('btnDeletenew2');
        $('#btnBack').removeClass('btnClose');
        $('#btnActHelp').addClass('btnnewhelp');
        $('#btnActHelp').removeClass('btnHelp');
        $(".BottomFooterBtnsLeft_car").show();
        $(".manufacture").show();
        $(".footerextra").show();
        $("#AEHeaderLeftDiv").hide();
        $(".fulltxtarealbl").hide();
        $(".textsearcharea").hide();
        $(".secLeftTopcartypenew").show();
        getLocalizedText("vehicles");
        $("#pagenamelbl").text(_message);

        $("#levelCaption").val(7);
    })
    $("#btnTakeOver").click(function (evt) {
        evt.preventDefault();
        $("#UpperDiv").show();
        $(".searchVehicletype").hide()
        $("#btnEntNew").show();
        $("#btnEntSave").show();
        $("#btnCancelDel").show();
        $('#btnBack').addClass('btnClose');
        $('#btnBack').removeClass('btnDeletenew2');
        $('#btnActHelp').addClass('btnHelp');
        $('#btnActHelp').removeClass('btnnewhelp');
        $(".BottomFooterBtnsLeft_car").hide();

        $("#levelCaption").val(0);
    })
    $("#imgSearchpersonal").click(function (evt) {
        evt.preventDefault();
        $("#leftdiv").hide();
        $("#grdclient").show();

        $("#levelCaption").val(16);
    })
    $("#btnSearchClient").click(function (evt) {
        evt.preventDefault();
        ddlCompanyval = dplCompanyName.GetText();
        $("#UpperDiv").hide();
        $(".searchclint").hide();
        $("#btnEntNew").hide();
        $("#btnEntSave").hide();
        $(".searchclintnewclint").show();
        $(".ControlSectionnewclient").show();
        $(".btmsecLeftMidcreatenew").show();
        $(".ControlSection").hide();
        $("#btnCancelDel").hide();
        $("#ControlSection1").hide();
        cobCompanyNr.SetEnabled(true);
        cobCompanyName.SetEnabled(true);
        getLocalizedText("creatingvisitorcompany");
        $("#pagenamelbl").text(_message);
        $("#levelCaption").val(19);
    })
    $("#btnSearchClient2").click(function (evt) {
        evt.preventDefault();
        $("#UpperDiv").hide();
        $(".ControlSection").hide();
        $(".searchVehicletype").hide();
        $(".searchclint").hide();
        $("#btnEntNew").hide();
        $(".ControlSectionnewclientmandant").show();
        $(".searchclintnewclintmanant").show();
        $("#btnEntSave").hide();
        $(".ControlSectionnewclient").hide();
        $(".ControlSection").removeClass("ControlSectionremoveback");
        $("#btnCancelDel").hide();

        $("#levelCaption").val(8);
    })
    $("#btnSearchPersonal").click(function (evt) {
        evt.preventDefault();
        searchPersonal();

        $("#levelCaption").val(2);
    });
    $("#btnSecurityCheckBy").click(function (evt) {
        evt.preventDefault();
        searchPersonal();

        $("#levelCaption").val(3);
    });
    $("#btnSecurityTrainedBy").click(function (evt) {
        evt.preventDefault();
        searchPersonal();

        $("#levelCaption").val(4);
    });
    $("#btnDeleteAusweis").click(function (evt) {
        evt.preventDefault();
        if (!isNaN(parseInt(grdTranspondersShortTerm.GetSelectedKeysOnPage()[0]))) {
            var id = parseInt(grdTranspondersShortTerm.GetSelectedKeysOnPage()[0]);
            if (id > 0) {
                var visitorId = ddlVisitorID.GetValue();
                if (parseInt(visitorId) > 0) {
                    ConfirmDeleteAusweis();
                }

            }
        }
    });
    $("#btnSaveCompany").click(function (evt) {
        evt.preventDefault();
        //if (isNaN(parseInt($("#txtCompanyNr").val()))) {
        //    return;
        //    PageMethods.CheckIfVisitorCompanyNrExists(parseInt($("#txtCompanyNr").val()));

        //} else { }
        saveCompanyDetails();


    });


    $("#btnEntSave, #btnSaveAusweis").click(function (evt) {
        evt.preventDefault();

        //grdTransponders.batchEditHelper.EndEdit();
        grdTranspondersShortTerm.batchEditHelper.EndEdit();
        doAfterBind = true;
        if (isNaN(parseInt($("#txtVisitorID").val()))) {
            alert("Geben Sie Besucher -ID");
            return;
        }

        if (parseInt($("#ddlVisitorName").val()) === 0) {
            PageMethods.CheckIfVisitorIdExists(parseInt($("#txtVisitorID").val()), OnCheckIfVisitorIdExists_CallBack);
        }
        else {
            //PageMethods.CheckIfVisitorNrExistsOnEdit(parseInt($("#txtVisitorID").val()), ddlVisitorID.GetValue(), CheckIfVisitorNrExistsOnEdit_CallBack);
            saveVisitorDetails();
            saveChanges = false;
        }

    });

    $("#btnCancelDel").click(function (evt) {
        evt.preventDefault();
        var id = ddlVisitorID.GetValue();
        if (parseInt(id) > 0) {
            Confirm_Delete();
        }
    });


    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        if (($("#levelCaption").val()) == 0) {
            var editStatus = JSON.stringify(grdTranspondersShortTerm.batchEditHelper.updatedValues) == "{}";
            if (editStatus == false) {
                saveChanges = true;
            }
            switch (saveChanges && allowZUTEdit) {
                case true:
                    ConfirmSaveChanges();
                    break;
                case false:
                    document.location.href = "/Index.aspx";
                    break;
            }

        }
        else if (($("#levelCaption").val()) == 1) {
            $("#UpperDiv").show();
            $(".searchVisitors").hide();
            $(".searchPersonToVisit").hide();
            $("#levelCaption").val(0);
        }
        else if (($("#levelCaption").val()) == 2) {
            $("#UpperDiv").show();
            $(".searchVisitors").hide();
            $(".searchPersonToVisit").hide();
            $("#levelCaption").val(0);
        }
        else if (($("#levelCaption").val()) == 3) {
            $("#UpperDiv").show();
            $(".searchVisitors").hide();
            $(".searchPersonToVisit").hide();
            $("#levelCaption").val(0);
        }
        else if (($("#levelCaption").val()) == 5) {
            $("#rightdiv").show();
            $(".rightdivgrid").hide();
            $("#levelCaption").val(0);
        }
        else if (($("#levelCaption").val()) == 6) {
            $("#rightdiv").show();
            $(".rightdivtransponder").hide();
            $("#levelCaption").val(0);
        }
        else if (($("#levelCaption").val()) == 7) {
            $("#UpperDiv").show();
            $(".searchVehicletype").hide()
            $("#btnEntNew").show();
            $("#btnEntSave").show();
            $("#btnCancelDel").show();
            $('#btnBack').addClass('btnClose');
            $('#btnBack').removeClass('btnDeletenew2');
            $('#btnActHelp').addClass('btnHelp');
            $('#btnActHelp').removeClass('btnnewhelp');
            $(".BottomFooterBtnsLeft_car").hide();
            $(".manufacture").hide();
            $(".footerextra").hide();
            $("#AEHeaderLeftDiv").show();
            $(".fulltxtarealbl").show();
            $(".textsearcharea").show();
            $(".secLeftTopcartypenew").hide();
            ResetPageTitle();
            $("#levelCaption").val(0);
        }
        else if (($("#levelCaption").val()) == 8) {
            $("#UpperDiv").show();
            $(".searchclint").hide()
            $("#btnEntNew").show();
            $("#btnEntSave").show();
            $("#btnCancelDel").show();
            $(".searchclintnewclint").hide();
            $(".ControlSection").show();
            $("#btnCancelDel").show();
            $(".ControlSectionnewclientmandant").hide();
            $(".searchclintnewclintmanant").hide()
            $("#levelCaption").val(0);

        }
        else if (($("#levelCaption").val()) == 9) {
            $("#tabcontroldiv").show();
            $(".surchpersonalinfomation").hide();
            $('#PageTitleLbl2').text("");
            $("#levelCaption").val(0);

        }
        else if (($("#levelCaption").val()) == 10) {

            HideSubmitButtons();
            $("#ControlSection1").show();
            $("#tabcontroldiv").show();
            $("#btnEntNew").show();
            $("#btnEntSave").show();
            $("#btnCancelDel").show();
            $(".Dailystatement").hide();
            $('#PageTitleLbl2').text("");
            ResetPageTitle();
            $("#levelCaption").val(0);

            setTimeout(function () { GetActiveSTTransponderNr(); }, 5);
        }
        else if (($("#levelCaption").val()) == 11) {
            HideApplicationsDiv()
        }
        else if (($("#levelCaption").val()) == 15) {
            HideHistory();
            $("#levelCaption").val(0);

        }
        else if (($("#levelCaption").val()) == 16) {
            $("#leftdiv").show();
            $("#grdclient").hide();
            $("#levelCaption").val(0);

        }
        else if (($("#levelCaption").val()) == 17) {
            if (applyPhoto === true) {
                ConfirmApplyPhoto();
            }
            else {
                HideWebCam();
                $("#levelCaption").val(0);
            }


        }
        else if (($("#levelCaption").val()) == 18) {
            HideClienSeach();
            $("#levelCaption").val(0);
        }
        else if (($("#levelCaption").val()) == 19) {
            if (saveCompanyChanges === true && allowZUTEdit) {
                ConfirmSaveCompanyDetails();
            }
            else {
                $("#UpperDiv").show();
                $(".searchclint").hide()
                $("#btnEntNew").show();
                $("#btnEntSave").show();
                $("#btnCancelDel").show();
                $(".ControlSectionnewclient").hide();
                $(".ControlSection").show();
                $(".searchclintnewclint").hide();
                $(".btmsecLeftMidcreatenew").hide();
                $("#btnCancelDel").show();
                $("#ControlSection1").show();
                //ClearCompanyControls();
                $("#txtCompanyNr").val("");
                ResetPageTitle();
                $("#levelCaption").val(0);
            }

        }
        else if (($("#levelCaption").val()) == 20) {
            Hideserchmandant();
            ResetPageTitle();
            $("#levelCaption").val(0);
        }
        else if (($("#levelCaption").val()) == 100) {
            document.location.href = "/Content/VisitorsApplications.aspx";
        }
    });
    $("#btnTKPhoto").click(function (evt) {
        evt.preventDefault();
        applyPhoto = true;
        FreezeWebcam();
    });
    $("#btnClearPhoto").click(function (evt) {
        evt.preventDefault();
        //UnFreezeWebcam();
        ConfirmClearPhoto();
    });
    $("#btnRemovePhoto").click(function (evt) {
        evt.preventDefault();
        ConfirmRemovePhoto();
        //HideWebCam();
        //RemovePhoto();
    });
    $("#btnAccept").click(function (evt) {
        evt.preventDefault();
        saveChanges = true;
        applyPhoto = false;
        AcceptPhoto();
        if (parseInt($("#levelCaption").val()) == 17) {
            HideWebCam();
            $("#levelCaption").val(0);
        }
    });
    $("#btnCancelPhoto").click(function (evt) {
        evt.preventDefault();
        if (parseInt($("#levelCaption").val()) == 17) {
            HideWebCam();
            $("#levelCaption").val(0);
        }
    });


    $("#chkAccessPlanActive").click(function () {
        if ($("#chkAccessPlanActive")[0].checked === true) {
            PageMethods.GetActivationDetails(OnGetActivationDetails_CallBack);
        }
        else if ($("#chkAccessPlanActive")[0].checked === false) {
            PageMethods.RemoveActivationDetails(OnGetActivationDetailsClear_CallBack);
        }

    });
    $("#img").attr("Src", $("#photVal").val());
    $("#photVal").val("");
    $("#btnTriggerFileUpload").click(function (evt) {
        evt.preventDefault();
        triggerFileUpload();
    });
    $('input').change(function () {
        saveChanges = true;
    });
    $("#chkAllVisitors").click(function () {
        if ($("#chkAllVisitors")[0].checked === true) {
            var id = "0";
            ddlTopCompanyNrHistory.SetValue(id);
            ddlPostalCodeHistory.SetValue(id);
            ddlLocationHistory.SetValue(id);

        }
        else if ($("#chkAllVisitors")[0].checked === false) {

        }

    });
    $("#btnApplyRegDates").click(function (evt) {
        evt.preventDefault();
        if (moment(dtpStartDate.GetDate()).isValid()) {
            drpVisitStartDate.SetDate(dtpStartDate.GetDate());
        }
        if (moment(dtpEndDate.GetDate()).isValid()) {
            drpVisitEndDate.SetDate(dtpEndDate.GetDate());
        }
        if (moment(dtpStartDateTime.GetDate()).isValid()) {
            drpVisitStartDateTime.SetDate(dtpStartDateTime.GetDate());
        }
        if (moment(dtpEndDateTime.GetDate()).isValid()) {
            drpVisitEndDateTime.SetDate(dtpEndDateTime.GetDate());
        }
        //PageMethods.ApplyDates(moment(dtpStartDate.GetDate()).format("YYYY-MM-DD"), moment(dtpEndDate.GetDate()).format("YYYY-MM-DD"), ApplyDates_CallBack);
    });
    $("#btnNewManufacturer").click(function (evt) {
        evt.preventDefault();
        $("#txtManufacturerId").val("0");
        $("#txtManufacturer").removeAttr("disabled");
        $("#btnSaveManufacturer").removeAttr("disabled");
        $("#txtManufacturer").focus();
        $("#btnNewModel").attr("disabled", "disabled");
        $("#btnSaveModel").attr("disabled", "disabled");
        $("#btnDeleteModel").attr("disabled", "disabled");
        $("#txtVehicleModelId").val("");
        $("#txtModelType").val("");
        $("#txtModelType").attr("disabled", "disabled");
    });
    $("#btnSaveManufacturer").click(function (evt) {
        evt.preventDefault();
        SaveVehicleManufacturer();
    });
    $("#imgArrow").click(function (evt) {
        evt.preventDefault();
    });
    $("#btnDeleteManufacturer").click(function (evt) {
        evt.preventDefault();
        //DeleteManufacturer();
        ConfirmDeleteManufacturer();

    });
    $("#btnNewModel").click(function (evt) {
        evt.preventDefault();
        $("#txtModelType").removeAttr("disabled");
        $("#btnSaveModel").removeAttr("disabled");
        $("#txtModelType").focus();
        $("#txtVehicleModelId").val("");
        $("#btnNewManufacturer").attr("disabled", "disabled");
        $("#btnSaveManufacturer").attr("disabled", "disabled");
        $("#btnDeleteManufacturer").attr("disabled", "disabled");
        $("#txtManufacturer").val("");
        $("#txtManufacturer").attr("disabled", "disabled");
    });
    $("#btnSaveModel").click(function (evt) {
        evt.preventDefault();
        SaveVehicleModel();
    });
    $("#btnDeleteModel").click(function (evt) {
        evt.preventDefault();
        //DeleteVehicleModel();
        ConfirmDeleteVehicleType();
    });
    $("#chkAutomaticLogout").click(function () {
        if ($("#chkAutomaticLogout")[0].checked === true) {
            
            SetDefaultTime();
        }
        else if ($("#chkAutomaticLogout")[0].checked === false) {
            
        }
    });
    DisableTexbox();
});

//function CheckIfVisitorNrExistsOnEdit_CallBack(value){
//    if (value === false) {
//        saveVisitorDetails();
//        saveChanges = false;
//    }
//    else {
//        alert("Besucher-ID ist bereits vorhanden");
//        return;
//    }
//}

function OnCheckIfVisitorIdExists_CallBack(value) {
    if (value === false) {
        saveVisitorDetails();
        setTimeout(function (ev) { grdTransponders.UpdateEdit() }, 1);
        setTimeout(function (ev) { grdTranspondersShortTerm.UpdateEdit() }, 1);
        saveChanges = false;
    }
    else {
        alert("Besucher-ID ist bereits vorhanden");
        return;
    }
}

function displaytransponderdata() {
    $("#rightdiv").hide();
    $(".rightdivtransponder").show();

}

function displayvisitordata() {
    $("#rightdiv").hide();
    $(".rightdivgrid").show();
    $(".ControlSection").removeClass("ControlSectionremoveback");
}

function hidevisitordata() {
    $("#rightdiv").show();
    $(".rightdivgrid").hide();
}

function searchVisitors() {
    $("#UpperDiv").hide();
    $(".searchPersonToVisit").hide();
    $(".searchVisitors").show();
    $(".ControlSection").removeClass("ControlSectionremoveback");
}
function searchVisitors() {
    $("#UpperDiv").hide();
    $(".searchPersonToVisit").hide();
    $(".searchVisitors").show();
    $(".ControlSection").removeClass("ControlSectionremoveback");
}
function VisitorApplicationGrid() {
    $("#tabcontroldiv").hide();
    $(".Visitorsapplication").show();
    $("#btnEntNew").hide();
    $("#btnEntSave").hide();
    $("#btnCancelDel").hide();
    $("#AEHeaderRightDivnew").hide();
    $("#AEHeaderRightDiv").hide();
    $("#lblDateTo").show();
    $("#lblAllbooking").show();
    getLocalizedText("visitorLogin");
    $("#pagenamelbl").text(_message);
    $("#txtvoltext").show();
    $(".chkActivationnew").show();
    $("#btnApplyVisitorApplications").show();
    $(".ControlSection").hide();
    $("#ControlSection1").hide();
}
function VisitorApphistory() {
    $("#tabcontroldiv").hide();
    $(".Visitorsapplicationnewvishis").show();
    $("#btnEntNew").hide();
    $(".ControlSectionhistory").show();
    $(".ControlSection").hide();
    $("#btnEntSave").hide();
    $(".empFormViewNavrefresh").show();
    $("#btnCancelDel").hide();

    getLocalizedText("visitorData_new");
    $("#pagenamelbl").text(_message);
    $("#ControlSection1").hide();
    $("#btnSaveAusweis").hide();
    $("#btnDeleteAusweis").hide();
    $("#btnApplyVisitorData").show();

}
function serchclint() {
    $("#tabcontroldiv").hide();
    $(".Visitorsapplicationnewvishis").hide();
    $(".Visitorclient").show();
    $("#btnAcceptCompany").show();
    $("#btnAcceptCompany").show();
    $("#btnEntNew").hide();
    $("#btnEntSave").hide();
    $("#btnCancelDel").hide();
    $("#lblPersNo").hide();
    $("#lblEmployeeName").hide();
    $("#ddlVisitorID").hide();
    $("#ddlVisitorName").hide();
    $(".serchClintfilter").hide();
    $("#ControlSection1").hide();
    $(".ControlSection1").hide();
    $("#AEHeaderRightDiv").hide();
    $("#AEHeaderLeftDiv").hide();
    $(".fulltxtarealbl").hide();
    $(".textsearcharea").hide();
    $(".ControlSection").addClass("ControlSectionremoveback");
    getLocalizedText("visitorcompanydata");
    $("#pagenamelbl").text(_message);
}
function serchmandant() {
    $("#tabcontroldiv").hide();
    $(".Visitorsapplicationnewvishis").hide();
    $(".Visitorclient").hide();
    $("#btnEntNew").hide();
    $("#ControlSection1").hide();
    $(".serchClintfiltermandant").hide();
    $("#btnEntSave").hide();
    $("#btnCancelDel").hide();
    $("#lblPersNo").hide();
    $("#lblEmployeeName").hide();
    $("#ddlVisitorID").hide();
    $("#ddlVisitorName").hide();
    $(".serchClintfilter").hide();
    $("#AEHeaderRightDiv").hide();
    $("#AEHeaderLeftDiv").hide();
    $(".ControlSection").addClass("ControlSectionremoveback");
    $(".serchClintfiltermandant").show();
    $(".Visitormandant").show();
    $("#btnApplyCompanyTo").show();
    $(".fulltxtarealbl").hide();
    $(".textsearcharea").hide();
    getLocalizedText("visitorDataSearch");
    $("#pagenamelbl").text(_message);
}
function grdSearchVisitorsDblClick(s, e) {

    var id = grdSearchVisitors.GetRowKey(e.visibleIndex);
    PageMethods.GetVisitorByID(id, OnGetVisitorByID_CallBack);
}

//visitorData
function grdVisitorDataDblClick(s, e) {
    //window.grdVisitorDescription.GetRowValues(e.visibleIndex, "ID;VisitorPlanNr;VisitorPlanDescription", searchVisitorDataRowValues1)

    $("#rightdiv").show();
    $(".rightdivgrid").hide();
    $("#levelCaption").val(0);
    var visitorPlanID = grdVisitorDescription.GetRowKey(e.visibleIndex);
    cobVisitorPlanNr.SetValue(visitorPlanID);
    cobVisitorPlanName.SetValue(visitorPlanID);
}

function searchVisitorDataRowValues1(values) {
    var visitorPlanID = values[0].toString();
    var visitorPlanNr = values[1].toString();
    var visitorPlanDescription = values[2].toString();
}

function setPesrdet(response) {

    var pid = response.IdentificationNr;
    var fname = response.FirstName;
    var lname = response.LastName;

    $("#txtPersVisited").val(String.format('{0}-{1}{2}', pid, fname, lname));
}

function setSecdet(response) {
    var pid = response.IdentificationNr;
    var fname = response.FirstName;
    var lname = response.LastName;

    $("#txtSecurityChecked").val(String.format('{0}-{1}{2}', pid, fname, lname));

}

function setTraindet(response) {
    var pid = response.IdentificationNr;
    var fname = response.FirstName;
    var lname = response.LastName;

    $("#txtTrainingBy").val(String.format('{0}-{1}{2}', pid, fname, lname));

}

function saveVisitorDetails() {
    InitialPageLoadPanel.Show();
    var passportData = '';
    var personPhotoInBinary = '';

    var id = ddlVisitorName.GetValue();
    var visitorID = $("#txtVisitorID").val();
    var surName = $("#txtSurName").val();
    var name = $("#txtName").val();
    //var company = dplCompanyName.GetValue();
    var company = $("#txtVisitorCompanyID").val();
    var street = $("#txtStreet").val();
    var postalCode = $("#txtPostalCode").val();
    var location = $("#txtLocation").val();
    var telephone = $("#txtTelephone").val();
    var mobile = $("#txtMobile").val();
    var email = $("#txtEmail").val();
    var vehicleNo = $("#txtVehicleNo").val();
    //var vehicleType = $("#txtVehicleTypes").val();
    var vehicleType = $("#txtVehicleId").val();
    var cardNr = $("#txtCardNumber").val();
    var pinCode = $("#txtCardPinCode").val();
    //var visitorPlanNr = $("#txtVisitorPlangroup").val();
    var visitorPlanNr = cobVisitorPlanNr.GetValue();
    var startDate = drpVisitStartDate.GetDate() !== null ? moment(drpVisitStartDate.GetDate()).format("YYYY-MM-DD") : "";
    var startDateTime = drpVisitStartDateTime.GetDate() != null ? moment(drpVisitStartDateTime.GetDate()).format("HH:mm") : "00:00";
    var endDate = drpVisitEndDate.GetDate() !== null ? moment(drpVisitEndDate.GetDate()).format("YYYY-MM-DD") : "";
    var endDateTime = drpVisitEndDateTime.GetDate() != null ? moment(drpVisitEndDateTime.GetDate()).format("HH:mm") : "00:00";
    var autoDate = drpVisitAutoDate.GetDate() !== null ? moment(drpVisitAutoDate.GetDate()).format("YYYY-MM-DD") : "";
    var autoDateTime = drpAutomaticLogout.GetDate() != null ? moment(drpAutomaticLogout.GetDate()).format("HH:mm") : "";
    var autoDateSTD = $("#txtSTDTime").val();
    var visitInstanceNr = $("#hiddenFieldVisitInstanceIdNr").val();
    var memo = $("#txtMemo").val();
    var planActive = $("#chkAccessPlanActive")[0].checked;
    var V_startDate = moment(dtpStartDate.GetDate()).format("YYYY-MM-DD");
    var V_startDateTime = moment(dtpStartDateTime.GetDate()).format("HH:mm");
    var V_endDate = moment(dtpEndDate.GetDate()).format("YYYY-MM-DD");
    var V_endDateTime = moment(dtpEndDateTime.GetDate()).format("HH:mm");
    var V_regDate = moment(drpRegDate.GetDate()).format("YYYY-MM-DD");
    var V_regDateTime = moment(drpRegTime.GetDate()).format("HH:mm");
    var visitReason = $("#txtVisitReason").val();
    var streetNr = $("#txtStreetNr").val();
    //var companyTo = dplToCompanyNr.GetValue();
    var companyTo = $("#txtToCompanyId").val();
    var persPhoto = $("#img").attr("src");


    var hasimg = document.getElementById("img").hasAttribute("Src");

    if (hasimg) {

        if ($("#img").attr("Src").indexOf('data:image/') > -1) {
            personPhotoInBinary = $("#img").attr("Src").split(",")[1];
        }
        else {
            passportData = $("#img").attr("Src")
        }
    }

    var cardActive = $("#chkCardActive")[0].checked;
    var automaticLogout = $("#chkAutomaticLogout")[0].checked;
    PageMethods.SaveVisitorDetails(personPhotoInBinary, id, visitorID, surName, name, company, street, location, postalCode, telephone, mobile,
        email, cardNr, pinCode, visitorPlanNr, startDate, startDateTime, endDate, endDateTime, autoDate, autoDateTime,
        autoDateSTD, memo, vehicleNo, vehicleType, visitInstanceNr, planActive, V_regDate, V_regDateTime, V_startDate, V_startDateTime,
        V_endDate, V_endDateTime, visitReason, streetNr, companyTo, passportData != undefined ? passportData : "", cardActive, automaticLogout, OnSaveVisitorDetails_CallBack);

}
function OnSaveVisitorDetails_CallBack(insertEdit) {
    if (insertEdit.isEdit === 1) {
        EnableDropdowns();
        saveChanges = false;
        bindDropDownsInsert(insertEdit);
        //PageMethods.Loadetails(insertEdit.visitorId, bindDropDownsInsert);
    }
    else if (insertEdit.isEdit === 2) {
        EnableDropdowns();
        saveChanges = false;
        bindDropDownsEdit(insertEdit);
        //PageMethods.Loadetails(insertEdit.visitorId, bindDropDownsEdit);

    }

}

function bindDropDownsInsert(response) {

    $("#txtVisitorID").attr("disabled", "disabled");
    var id = response.ID.toString();
    var companyId = ddlTopCompanyNr.GetValue();
    var filter = "";
    if (parseInt(companyId) > 0) {
        filter = companyId.toString();
    }
    _callBackParam = id + ";" + filter;
    ddlVisitorID.PerformCallback(_callBackParam);
}

function bindDropDownsEdit(response) {
    $("#txtVisitorID").attr("disabled", "disabled");
    var id = response.ID.toString();
    var companyId = ddlTopCompanyNr.GetValue();
    var filter = "";
    if (parseInt(companyId) > 0) {
        filter = companyId.toString();
    }
    _callBackParam = id + ";" + filter;
    ddlVisitorID.PerformCallback(_callBackParam);
}

function saveVisitorDetailsOnBack() {
    InitialPageLoadPanel.Show();
    var id = ddlVisitorName.GetValue();
    var visitorID = $("#txtVisitorID").val();
    var surName = $("#txtSurName").val();
    var name = $("#txtName").val();
    //var company = dplCompanyName.GetValue();
    var company = $("#txtVisitorCompanyID").val();
    var street = $("#txtStreet").val();
    var postalCode = $("#txtPostalCode").val();
    var location = $("#txtLocation").val();
    var telephone = $("#txtTelephone").val();
    var mobile = $("#txtMobile").val();
    var email = $("#txtEmail").val();
    var vehicleNo = $("#txtVehicleNo").val();
    //var vehicleType = $("#txtVehicleTypes").val();
    var vehicleType = $("#txtVehicleId").val();
    var cardNr = $("#txtCardNumber").val();
    var pinCode = $("#txtCardPinCode").val();
    //var visitorPlanNr = $("#txtVisitorPlangroup").val();
    var visitorPlanNr = cobVisitorPlanNr.GetValue();
    var startDate = drpVisitStartDate.GetDate() !== null ? moment(drpVisitStartDate.GetDate()).format("YYYY-MM-DD") : "";
    var startDateTime = drpVisitStartDateTime.GetDate() != null ? moment(drpVisitStartDateTime.GetDate()).format("HH:mm") : "00:00";
    var endDate = drpVisitEndDate.GetDate() !== null ? moment(drpVisitEndDate.GetDate()).format("YYYY-MM-DD") : "";
    var endDateTime = drpVisitEndDateTime.GetDate() != null ? moment(drpVisitEndDateTime.GetDate()).format("HH:mm") : "00:00";
    var autoDate = drpVisitAutoDate.GetDate() !== null ? moment(drpVisitAutoDate.GetDate()).format("YYYY-MM-DD") : "";
    var autoDateTime = drpAutomaticLogout.GetDate() != null ? moment(drpAutomaticLogout.GetDate()).format("HH:mm") : "";
    var autoDateSTD = $("#txtSTDTime").val();
    var visitInstanceNr = $("#hiddenFieldVisitInstanceIdNr").val();
    var memo = $("#txtMemo").val();
    var planActive = $("#chkAccessPlanActive")[0].checked;
    var V_startDate = moment(dtpStartDate.GetDate()).format("YYYY-MM-DD");
    var V_startDateTime = moment(dtpStartDateTime.GetDate()).format("HH:mm");
    var V_endDate = moment(dtpEndDate.GetDate()).format("YYYY-MM-DD");
    var V_endDateTime = moment(dtpEndDateTime.GetDate()).format("HH:mm");
    var V_regDate = moment(drpRegDate.GetDate()).format("YYYY-MM-DD");
    var V_regDateTime = moment(drpRegTime.GetDate()).format("HH:mm");
    var visitReason = $("#txtVisitReason").val();
    var streetNr = $("#txtStreetNr").val();
    //var companyTo = dplToCompanyNr.GetValue();
    var companyTo = $("#txtToCompanyId").val();
    var persPhoto = $("#img").attr("src");
    var cardActive = $("#chkCardActive")[0].checked;
    var automaticLogout = $("#chkAutomaticLogout")[0].checked;
    PageMethods.SaveVisitorDetails(id, visitorID, surName, name, company, street, location, postalCode, telephone, mobile,
        email, cardNr, pinCode, visitorPlanNr, startDate, startDateTime, endDate, endDateTime, autoDate, autoDateTime,
        autoDateSTD, memo, vehicleNo, vehicleType, visitInstanceNr, planActive, V_regDate, V_regDateTime, V_startDate, V_startDateTime,
        V_endDate, V_endDateTime, visitReason, streetNr, companyTo, persPhoto != undefined ? persPhoto : "", cardActive, automaticLogout, OnSaveVisitorDetailsOnBack_CallBack);

}
function OnSaveVisitorDetailsOnBack_CallBack() {
    isBack = true;
    var editStatus = JSON.stringify(grdTranspondersShortTerm.batchEditHelper.updatedValues) == "{}";
    if (editStatus == false) {
        grdTranspondersShortTerm.UpdateEdit();
    }
    else {
        document.location.href = "/Index.aspx";
    }

}

function ddlVisitorIDEndCallBack(s, e) {
    setTimeout(function (ev) { grdTranspondersShortTerm.UpdateEdit() }, 1);
    var companyId = ddlTopCompanyNr.GetValue();
    ddlVisitorName.PerformCallback(_callBackParam);
    if (parseInt(companyId) > 0) {
        grdFilteredVisitors.PerformCallback(companyId);
        grdSearchVisitors.PerformCallback(companyId);
    }
    else {
        grdFilteredVisitors.PerformCallback();
        grdSearchVisitors.PerformCallback();
    }
    grdVisitorsHistory.PerformCallback();
    setTimeout(function (ev) { InitialPageLoadPanel.Hide() }, 1);
}

function BindDataGridAfterSaving() {
    if (doAfterBind) {

        doAfterBind = false;
    }
}
function searchPersonToVisitDblClick(s, e) {

    //window.grdSearchPersonToVisit.GetRowValues(e.visibleIndex, "ID;Pers_Nr;Card_Nr;LastName;FirstName;LocationName;DepartmentName;CostCenterName", searchPersonToVisitRowValues);
    window.grdSearchPersonToVisit.GetRowValues(e.visibleIndex, "ID;Pers_Nr;LastName;FirstName", searchPersonToVisitRowValues);
    $("#UpperDiv").show();
    $(".searchVisitors").hide();
    $(".searchPersonToVisit").hide();
}

function searchPersonToVisitRowValues(values) {
    var persID = values[0].toString();
    var personnelNr = values[1].toString();
    //var idendification = values[2].toString();
    var lastName = values[2].toString();
    var firstName = values[3].toString();
    //var locationName = values[5].toString();
    //var departmentName = values[6].toString();
    //var costCenterName = values[7].toString();



    if (($("#levelCaption").val()) == 2) {
        $("#txtPersVisited").val(String.format('{0}-{1} {2}', personnelNr, firstName, lastName));
    }
    if (($("#levelCaption").val()) == 3) {
        $("#txtSecurityChecked").val(String.format('{0}-{1} {2}', personnelNr, firstName, lastName));
    }

    if (($("#levelCaption").val()) == 4) {
        $("#txtTrainingBy").val(String.format('{0}-{1} {2}', personnelNr, firstName, lastName));
    }


}
function grdTransponderDblClick(s, e) {
    window.grdTransponder.GetRowValues(e.visibleIndex, "ID;TransponderNr", searchTransponder);
    $("#rightdiv").show();
    $(".rightdivtransponder").hide();
}
function searchTransponder(values) {
    var transponderNr = values[1].toString();
    $("#txtTransponderNr").val(transponderNr);
}

function deleteVisitorDetails() {

    var visitorID = $("#txtVisitorID").val();
    PageMethods.DeleteVisitorDetails(visitorID);

    //PageMethods.Loadetails(visitorID,bindDropDowns);
    document.location.href = "/Content/Visitors.aspx";
}


function searchVehicle(values) {
    var ID = values[0].toString();
    var type = values[1].toString();
    $("#txtVehicleTypes").val(String.format('{1}', ID, type));
    $("#txtVehicleId").val(String.format('{0}', ID, type));
    $("#UpperDiv").show();
    $("#UpperDiv").show();
    $("#btnEntNew").show();
    $("#btnEntSave").show();
    $("#btnCancelDel").show();
    $(".searchVehicletype").hide();
    $("#levelCaption").val(0);
    saveChanges = true;
}

function grdFilteredVisitorsRowDbClick(s, e) {
    var id = grdFilteredVisitors.GetRowKey(e.visibleIndex);
    PageMethods.GetVisitorByInstance(id, OnGetVisitorByInstance_CallBack);
}
function OnGetVisitorByInstance_CallBack(result) {
    Populate_Controls(result);
    $("#tabcontroldiv").show();
    $(".Visitorsapplication").hide();
    $('.contInputsbtm').hide();
    $("#tabcontroldiv").show();
    $(".Visitorsapplication").hide();
    $("#btnEntNew").show();
    $("#btnEntSave").show();
    $("#btnCancelDel").show();
    $("#AEHeaderRightDivnew").hide();
    $("#AEHeaderRightDiv").hide();
    $("#lblDateTo").hide();
    $("#lblAllbooking").hide();
    $("#txtvoltext").hide();
    $(".chkActivationnew").hide();
    $("#levelCaption").val(0);
}
function Populate_Controls(values) {
    ddlVisitorName.SetValue(values.ID.toString());
    ddlVisitorID.SetValue(values.ID.toString());
    $("#txtVisitorID").val(values.VisitorID);
    $("#txtSurName").val(values.SurName);
    $("#txtName").val(values.OtherName);
    if (parseInt(values.Company) === 0) {
        $("#txtVisitorCompanyName").val("");
        $("#txtVisitorCompanyID").val("");
    }
    else if (parseInt(values.Company) > 0) {
        $("#txtVisitorCompanyName").val(String.format("{1}", values.VisitorCompanyId, values.VisitorCompanyName));
        $("#txtVisitorCompanyID").val(String.format("{0}", values.VisitorCompanyId, values.VisitorCompanyName));
    }
    dplCompanyName.SetValue(values.Company);
    $("#txtStreet").val(values.CompanyStreetNr);
    $("#txtPostalCode").val(values.PostalCode);
    $("#txtLocation").val(values.Location);
    $("#txtTelephone").val(values.Telephone);
    $("#txtMobile").val(values.Mobile);
    $("#img").attr("Src", values.PersPhoto);
    $("#txtEmail").val(values.Email);
    $("#txtVehicleNo").val(values.VehicleRegNo);
    $("#txtVehicleTypes").val(values.CarType);
    $("#txtVehicleId").val(values.VisitorVehicleId);
    $("#txtCardNumber").val(values.CardNrLongTerm);
    $("#txtCardPinCode").val(values.CardNrShortTerm);
    $("#txtVisitorPlangroup").val(values.VisitPlan);
    drpVisitStartDate.SetDate(values.AccessStartDate);
    drpVisitStartDateTime.SetDate(values.AccessStartDate);
    drpVisitEndDate.SetDate(values.AccessEndDate);
    drpVisitEndDateTime.SetDate(values.AccessEndDate);
    $("#txtSTDTime").val("");
    $("#hiddenFieldVisitInstanceIdNr").val(values.VisitInstance);
    $("#chkAccessPlanActive")[0].checked = values.AcessPlanActive;
    $("#chkCardActive")[0].checked = values.CardActive;
    $("#chkAutomaticLogout")[0].checked = values.AutoLogout;
    dtpStartDate.SetDate(values.vStartDate);
    dtpStartDateTime.SetDate(values.vStartDate);
    dtpEndDate.SetDate(values.vEndDate)
    dtpEndDateTime.SetDate(values.vEndDate)
    drpRegDate.SetDate(values.vRegDate);
    drpRegTime.SetDate(values.vRegDate);
    $("#txtVisitReason").val(values.VisitReason);
    $("#txtStreet").val(values.Street);
    $("#txtStreetNr").val(values.CompanyStreetNr);
    $("#txtPersonalName").val(values.PersName);
    $("#txtPersonnelNumber").val(values.PersNr);
    $("#txtPersPhoneNr").val(values.PersPhoneNr);
    $("#txtPersMobileNr").val(values.PersMobileNr);
    $("#txtPersActivated").val(values.PersActivated);
    $("#txtCardActivatedTime").val(values.DateActivated);
    $("#hiddenFieldVisitInstanceIdNr").val(values.VisitInstanceId);
    if (parseInt(values.CompanyTo) === 0) {
        $("#txtToCompanyName").val("");
        $("#txtToCompanyId").val("");
    }
    else if (parseInt(values.CompanyTo) > 0) {
        $("#txtToCompanyName").val(String.format("{1}", values.CompanyTo, values.CompanyToName));
        $("#txtToCompanyId").val(String.format("{0}", values.CompanyTo, values.CompanyToName));
    }
    dplToCompanyNr.SetValue(values.CompanyTo);
    dplToCompanyName.SetValue(values.CompanyTo);
    cobVisitorPlanNr.SetValue(values.VisitPlan);
    cobVisitorPlanName.SetValue(values.VisitPlan);
    drpAutomaticLogout.SetDate(values.AutoLogoutTime);
    grdTranspondersShortTerm.PerformCallback(values.ID);
}
function Populate_ControlsToEdit(values) {
    ddlVisitorName.SetValue(values.ID.toString());
    ddlVisitorID.SetValue(values.ID.toString());
    $("#txtVisitorID").val(values.VisitorID);
    $("#txtSurName").val(values.SurName);
    $("#txtName").val(values.OtherName);
    if (parseInt(values.Company) === 0) {
        $("#txtVisitorCompanyName").val("");
        $("#txtVisitorCompanyID").val("");
    }
    else if (parseInt(values.Company) > 0) {
        $("#txtVisitorCompanyName").val(String.format("{1}", values.VisitorCompanyId, values.VisitorCompanyName));
        $("#txtVisitorCompanyID").val(String.format("{0}", values.VisitorCompanyId, values.VisitorCompanyName));
    }
    dplCompanyName.SetValue(values.Company);
    $("#txtStreet").val(values.CompanyStreetNr);
    $("#txtPostalCode").val(values.PostalCode);
    $("#txtLocation").val(values.Location);
    $("#txtTelephone").val(values.Telephone);
    $("#txtMobile").val(values.Mobile);
    $("#img").attr("Src", values.PersPhoto);
    $("#txtEmail").val(values.Email);
    $("#txtVehicleNo").val(values.VehicleRegNo);
    $("#txtVehicleTypes").val(values.CarType);
    $("#txtVehicleId").val(values.VisitorVehicleId);
    $("#txtCardNumber").val(values.CardNrLongTerm);
    $("#txtCardPinCode").val(values.CardNrShortTerm);
    $("#txtVisitorPlangroup").val(values.VisitPlan);
    drpVisitStartDate.SetDate(values.vStartDate);
    drpVisitStartDateTime.SetDate(values.vStartDateTime);
    drpVisitEndDate.SetDate(values.vEndDate);
    drpVisitEndDateTime.SetDate(values.vEndDateTime);
    $("#txtSTDTime").val("");
    $("#hiddenFieldVisitInstanceIdNr").val(values.VisitInstance);
    $("#chkAccessPlanActive")[0].checked = values.AcessPlanActive;
    $("#chkCardActive")[0].checked = values.CardActive;
    $("#chkAutomaticLogout")[0].checked = values.AutoLogout;
    dtpStartDate.SetDate(values.vStartDate);
    dtpStartDateTime.SetDate(values.vStartDateTime);
    dtpEndDate.SetDate(values.vEndDate);
    dtpEndDateTime.SetDate(values.vEndDateTime);
    drpRegDate.SetDate(values.vEndDateTime);
    drpRegTime.SetDate(values.vRegDateTime);
    $("#txtVisitReason").val(values.VisitReason);
    $("#txtStreet").val(values.Street);
    $("#txtStreetNr").val(values.CompanyStreetNr);
    $("#txtPersonalName").val(values.PersName);
    $("#txtPersonnelNumber").val(values.PersNr);
    $("#txtPersPhoneNr").val(values.PersPhoneNr);
    $("#txtPersMobileNr").val(values.PersMobileNr);
    $("#txtPersActivated").val(values.PersActivated);
    $("#txtCardActivatedTime").val(values.DateActivated);
    $("#hiddenFieldVisitInstanceIdNr").val(values.VisitInstanceId);
    if (parseInt(values.CompanyTo) === 0) {
        $("#txtToCompanyName").val("");
        $("#txtToCompanyId").val("");
    }
    else if (parseInt(values.CompanyTo) > 0) {
        $("#txtToCompanyName").val(String.format("{1}", values.CompanyTo, values.CompanyToName));
        $("#txtToCompanyId").val(String.format("{0}", values.CompanyTo, values.CompanyToName));
    }
    dplToCompanyNr.SetValue(values.CompanyTo);
    dplToCompanyName.SetValue(values.CompanyTo);
    cobVisitorPlanNr.SetValue(values.VisitPlan);
    cobVisitorPlanName.SetValue(values.VisitPlan);
    drpAutomaticLogout.SetDate(values.AutoLogoutTime);
    grdTranspondersShortTerm.PerformCallback(values.ID);
}
function OnGetVisitorByID_CallBack(result) {
    Populate_Controls(result);
    $("#UpperDiv").show();
    $(".searchVisitors").hide();
    $(".searchPersonToVisit").hide();
}
function saveChangesOnBack() {
    ResetDialog();
    //grdTransponders.batchEditHelper.EndEdit();
    grdTranspondersShortTerm.batchEditHelper.EndEdit();
    if (isNaN(parseInt($("#txtVisitorID").val()))) {
        alert("Geben Sie Besucher -ID");
        return;
    }

    if (parseInt(ddlVisitorID.GetValue()) === 0) {
        PageMethods.CheckIfVisitorIdExists(parseInt($("#txtVisitorID").val()), OnCheckIfVisitorIdExists_CallBack);
    }
    else {
        saveVisitorDetailsOnBack();
        //isBack = true;
        //setTimeout(function (ev) { grdTransponders.UpdateEdit() }, 1000);
        //setTimeout(function (ev) { grdTranspondersShortTerm.UpdateEdit() }, 1000);
    }
}
function ConfirmSaveChanges() {
    getLocalizedText("confirmSaveSend");
    var message = _message;
    //var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox">  <img src="../../Images/FormImages/stop2.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"> <br/>' + message + '<br/> <button id="btnOk"  onclick="saveChangesOnBack(); return false"></button><button id="btnCancel"  onclick="ResetDialog()"></button> <button id="btnNo"  onclick="NoOnBackButton()"></button></div></div></div>';
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop2.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg" style="height:20%;">' + message + '</div> <button id="btnOk"  onclick="saveChangesOnBack(); return false" style="width:90%; float:left; clear:both; margin-bottom:2px; text-align:left !important; margin-top:0; padding-left:0px; color:forestgreen !important;" ></button><button id="btnCancel"  onclick="ResetDialog()" style="width:90%; float:left; clear:both; margin-bottom:2px; text-align:left !important; margin-top:0; color:forestgreen !important; padding-left:10px;"></button> <button id="btnNo"  onclick="NoOnBackButton()" style="width:90%; float:left; clear:both; margin-bottom:2px; text-align:left !important; margin-top:0; padding-left:10px;"></button></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("saveChangesandConfirm");
    $('#btnOk').text(_message);
    getLocalizedText("savelChangesandsend");
    $('#btnCancel').text(_message);
    getLocalizedText("notsaveChangesandsend");
    $('#btnNo').text(_message);
}
function ResetDialog() {
    document.getElementById('importantDialog').innerHTML = "";
}
function NoOnBackButton() {
    ResetDialog();
    document.location.href = "/Index.aspx";
}
function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "Visitors.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            _message = result.d;
        }
    });
}

function WebcamMode() {
    $(".tab1leftsection2Leftpicnew").hide();
    $(".tab1leftsection").hide();
    $(".tab1leftsection2Left").hide();
    $(".webCamMode").show();
    $("#levelCaption").val(17);
    AttachWebcam();
}
function HideWebCam() {
    StopWebcam();
    $(".webCamMode").hide();
    $(".tab1leftsection").show();
    $(".tab1leftsection2Left").show();
    $(".tab1leftsection2Leftpicnew").show();
}
function HideClienSeach() {
    $("#tabcontroldiv").show();
    $(".Visitorsapplicationnewvishis").hide();
    $(".Visitorclient").hide();
    $("#btnAcceptCompany").hide();
    $("#btnAcceptCompany").hide();
    $("#btnEntNew").show();
    $("#btnEntSave").show();
    $("#btnCancelDel").show();
    $("#lblPersNo").show();
    $("#lblEmployeeName").show();
    $("#ddlVisitorID").show();
    $("#ddlVisitorName").show();
    $(".serchClintfilter").hide();
    $("#ControlSection1").show();
    $("#AEHeaderRightDiv").hide();
    $("#AEHeaderLeftDiv").show();
    $(".fulltxtarealbl").show();
    $(".textsearcharea").show();
    $(".ControlSection").removeClass("ControlSectionremoveback");
    ResetPageTitle();
}
function Hideserchmandant() {
    $("#tabcontroldiv").show();
    $(".Visitorsapplicationnewvishis").hide();
    $(".Visitorclient").hide();
    $("#btnEntNew").show();
    $("#btnEntSave").show();
    $("#btnCancelDel").show();
    $("#ControlSection1").show();
    $(".serchClintfiltermandant").hide();
    $("#lblPersNo").show();
    $("#lblEmployeeName").show();
    $("#ddlVisitorID").show();
    $("#ddlVisitorName").show();
    $(".serchClintfilter").hide();
    $(".ControlSection1").show();
    $("#btnApplyCompanyTo").hide();
    $("#AEHeaderRightDiv").hide();
    $("#AEHeaderLeftDiv").show();
    $(".ControlSection").removeClass("ControlSectionremoveback");
    $(".serchClintfiltermandant").hide();
    $(".Visitormandant").hide();
    $(".fulltxtarealbl").show();
    $(".textsearcharea").show();
}

function HideApplicationsDiv() {
    $("#tabcontroldiv").show();
    $(".Visitorsapplication").hide();
    $("#btnEntNew").show();
    $("#btnEntSave").show();
    $("#btnCancelDel").show();
    $("#AEHeaderRightDivnew").hide();
    $("#AEHeaderRightDiv").hide();
    $("#lblDateTo").hide();
    $("#lblAllbooking").hide();
    getLocalizedText("visitorsData");
    $("#pagenamelbl").text(_message);
    $("#txtvoltext").hide();
    $(".chkActivationnew").hide();
    $("#levelCaption").val(0);
    $("#btnApplyVisitorApplications").hide();
    $(".ControlSection").show();
    $("#ControlSection1").show();
}
function dplCompanyNameSelectedIndexChanged(s, e) {
    selectionChanged = true;
    saveChanges = true;
    PageMethods.GetCompanyDetails(s.GetValue(), OnGetCompanyDetails_CallBack);
}
function OnGetCompanyDetails_CallBack(result) {
    if (result !== null) {
        $("#txtStreet").val(result.Street);
        $("#txtPostalCode").val(result.ZipCode);
        $("#txtLocation").val(result.Place);
        $("#txtStreetNr").val(result.StreetNr);
        $("#txtVisitorCompanyName").val(result.Company);
        $("#txtVisitorCompanyID").val(result.VisitorCompanyId);
    }
    else {
        $("#txtStreet").val("");
        $("#txtPostalCode").val("");
        $("#txtLocation").val("");
        $("#txtStreetNr").val("");
        $("#txtVisitorCompanyName").val("");
        $("#txtVisitorCompanyID").val("");
    }

}

function ReloaddplCompanyName(response) {
    dplCompanyName.PerformCallback();
    dplCompanyName.SetValue(ddlCompanyval);
}

function HideCompanyGrid() {
    $("#UpperDiv").show();
    $(".searchVehicletype").hide();
    $("#client").hide();
}
function companyToSelectedIndexChanged(s, e) {
    dplToCompanyNr.SetValue(s.GetValue());
    dplToCompanyName.SetValue(s.GetValue());
    saveChanges = true;
}
function OnGetActivationDetails_CallBack(result) {
    $("#txtPersActivated").val(result.PersName);
    $("#txtCardActivatedTime").val(moment(result.ActivationDate).format("DD.MM.YYYY"));
}
function OnGetActivationDetailsClear_CallBack(result) {
    $("#txtPersActivated").val("");
    $("#txtCardActivatedTime").val("");
}
function visitorPlanSelectedIndexChanged(s, e) {
    cobVisitorPlanNr.SetValue(s.GetValue());
    cobVisitorPlanName.SetValue(s.GetValue());
    saveChanges = true;
}
$(function () {
    $("#UploadPhoto").on("change", function () {
        var files = !!this.files ? this.files : [];
        if (!files.length || !window.FileReader) return; // no file selected, or no FileReader support

        if (/^image/.test(files[0].type)) { // only image file
            var reader = new FileReader(); // instance of the FileReader
            reader.readAsDataURL(files[0]); // read the local file

            reader.onloadend = function () { // set image data as background of div

                $("#img").attr('src', this.result);

                GetImageURl();

                photo = this.result;
            }

            var file, imgTemp;
            if ((file = this.files[0])) {
                imgTemp = new Image();
                imgTemp.onload = function () {
                    //alert(this.width + " " + this.height);
                    setImgMargins(this.width, this.height);
                    //alert(this.width + " " + this.height);
                };
                imgTemp.src = _URL.createObjectURL(file);
            }
        }
    });
});



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

function GetImageURl() {
    var hasimg = document.getElementById("img").hasAttribute("Src");
    //console.log(hasimg);
    var personPhotoInBinary = "";

    if (hasimg) {

        if ($("#img").attr("Src").indexOf('data:image/') > -1) {
            personPhotoInBinary = $("#img").attr("Src").split(",")[1];
            PageMethods.ConvertImageBytesToURL(personPhotoInBinary, ddlVisitorName.GetValue(), ddlVisitorName.GetText(), SetImageUrl);
            personPhotoInBinary = "";
        }
    }
}

function SetImageUrl(imageUrl) {
    if (imageUrl.length > 0) {
        //$("#img").attr("Src", "");
        $("#img").attr("Src", imageUrl);
        //setImgMargins();
        photo = "";
    }
}

function triggerFileUpload() {
    document.getElementById("UploadPhoto").click();
}
function __promptWarning(preventedEvent) {
    $("#promptsPlaceHolder, #__WarningPrompt").show();
    $("#btnWarningPromptOk, #btnWarningPromptNo, #btnWarningPromptCancel").unbind("click");

    $("#btnWarningPromptOk").click(function (ev) {
        ev.preventDefault(); __warnBeforeDeleting(true, preventedEvent);
    });
    $("#btnWarningPromptNo").click(function (ev) {
        ev.preventDefault(); __hidePromptWarning();
    });
    $("#btnWarningPromptCancel").click(function (ev) {
        ev.preventDefault(); __hidePromptWarning();
    });
}

function __hidePromptWarning() {
    $("#promptsPlaceHolder, #__WarningPrompt").hide();
}
function __warnBeforeDeleting(continueEvent, preventedEvent) {
    if (continueEvent) {
        __hidePromptWarning();
        ConfirmDelete = true;
        $('#hiddenFieldVisitorId').val($('#txtVisitorID').val());
        $(preventedEvent.target).trigger(preventedEvent);

    }
}


function UserSubmitButtons() {
    $(".BottomFooterBtnsLeft").hide();
    $(".btndata").hide();

    $(".btnAuswesNew").show();
    $(".btnAuswesSave").show();
    $(".btnAuswesDelete").show();

    $('#btnBack').addClass('btnClosenew');
    $('#btnBack').removeClass('btnClose');
    $('#btnActHelp').addClass('btnHelpnew');
    $('#btnActHelp').removeClass('btnHelp');

    getLocalizedText("ShortTermCardTitle");
    $("#pagenamelbl").text(_message);
}
function datePickerDateChanged(s, e) {
    saveChanges = true;
}
function grdClientsRowDBClick(s, e) {
    window.grdClients.GetRowValues(e.visibleIndex, "ID;Name", GetRowValuesDbClick);
}
function GetRowValuesDbClick(values) {
    $("#txtToCompanyId").val(values[0]);
    $("#txtToCompanyName").val(values[1]);
    Hideserchmandant();
    $("#levelCaption").val(0);
    saveChanges = true;
}
function HideSubmitButtons() {
    $(".btnAuswesNew").hide();
    $(".btnAuswesSave").hide();
    $(".btnAuswesDelete").hide();

    $(".BottomFooterBtnsLeft").show();
    $(".btndata").show();

    $('#btnBack').addClass('btnClose');
    $('#btnBack').removeClass('btnClosenew');
    $('#btnActHelp').addClass('btnHelp');
    $('#btnActHelp').removeClass('btnHelpnew');
}
function ClearControls() {

    document.getElementById('txtClientNr').value = "";
    document.getElementById('txtClientName').value = "";
}

function grdClientsRowClick(s, e) {
    //window.grdClients.GetRowValues(e.visibleIndex, "ID;Client_Nr;Name", GetRowValues);
}
function loadGridAfterUpdate(response) {
    grdClients.PerformCallback();

}

function GetRowValues(values) {
    var vtemrID = values[0].toString();
    var VtermGrpNr = values[1].toString();
    var VtermName = values[2].toString();
    document.getElementById('txtClientNr').value = VtermGrpNr;
    document.getElementById('txtClientName').value = VtermName;
    ClientID = values[0].toString();
}

function FilltxtClientNr(response) {
    document.getElementById('txtClientNr').value = response;
}

function FilltxtCompanyNr(response) {
    document.getElementById('txtCompanyNr').value = response;
    saveCompanyChanges = true;
}

function ReloaddplCompanyName(response) {
    dplCompanyName.PerformCallback();
    dplCompanyName.SetValue(ddlCompanyval);
}
function OnInsertClient_CallBack() {
    grdClients.PerformCallback();
    dplCompanyName.PerformCallback();
    dplToCompanyNr.PerformCallback();
    dplToCompanyName.PerformCallback();


}
function dplToCompanyNrEndCallBack(s, e) {
    if (_isComDelete === true) {
        if (dplToCompanyNr.FindItemByValue(_companyToVal) != null) {
            dplToCompanyNr.SetValue(_companyToVal);
        }
        else {
            dplToCompanyNr.SetValue("0");
        }
    }
    else {
        dplToCompanyNr.SetValue(_companyToVal);
    }
}
function dplToCompanyNameEndCallBack(s, e) {
    if (_isComDelete === true) {
        if (dplToCompanyName.FindItemByValue(_companyToVal) != null) {
            dplToCompanyName.SetValue(_companyToVal);
        }
        else {
            dplToCompanyName.SetValue("0");
        }
    }
    else {
        dplToCompanyName.SetValue(_companyToVal);
    }
}
function dplCompanyNameEndCallback(s, e) {
    if (_isComDelete === true) {
        if (dplCompanyName.FindItemByValue(_companyVal) != null) {
            dplCompanyName.SetValue(_companyVal);
        }
        else {
            dplCompanyName.SetValue("0");
        }
    }
    else {
        dplCompanyName.SetValue(_companyVal);
    }

}
function OnDeleteClient_CallBack() {
    _isComDelete = true;
    ClientID = 0;
    $("#txtClientNr").val("");
    $("#txtClientName").val("");
    grdClients.PerformCallback();
    dplCompanyName.PerformCallback();
    dplToCompanyNr.PerformCallback();
    dplToCompanyName.PerformCallback();

}
function ddlTopCompanyNrSelectedChanged(s, e) {
    ddlPostalCode.SetValue(s.GetValue());
    ddlLocation.SetValue(s.GetValue());
    _isFilter = true;
    var id = "";
    var filter = s.GetValue();
    SelectedTopCompanyVal = s.GetValue();
    var param = id + ";" + filter;
    ddlVisitorName.PerformCallback(param);
    ddlVisitorID.PerformCallback(param);
    grdFilteredVisitors.PerformCallback(filter);
    grdSearchVisitors.PerformCallback(filter);
}
function ddlVisitorNameSelectionChanged(s, e) {
    if (_isSelection === true) {
        var id = s.GetValue();
        _isSelection = false;
        if (parseInt(id) === 0) {
            clearControls();
        }
        else if (parseInt(id) > 0) {
            PageMethods.GetVisitorByID(id, OnGetCurrentVisitor_CallBack);
        }

    }

}
function ddlVisitorIDSelectionChanged(s, e) {
    if (_isSelection === true) {
        var id = s.GetValue();
        _isSelection = false;
        if (parseInt(id) === 0) {
            clearControls();
        }
        else if (parseInt(id) > 0) {
            PageMethods.GetVisitorByID(id, OnGetCurrentVisitor_CallBack);
        }

    }
}
function ddlCompanySelectionChanged(s, e) {
    if (_isSelection === true) {
        var id = s.GetValue();
        _isSelection = false;
        if (parseInt(id) === 0) {
            clearControls();
        }
        else if (parseInt(id) > 0) {
            PageMethods.GetVisitorByID(id, OnGetCurrentVisitor_CallBack);
        }

    }
}
function ddlLocationSelectionChanged(s, e) {
    ddlPostalCode.SetValue(s.GetValue());
    ddlTopCompanyNr.SetValue(s.GetValue());
    _isFilter = true;
    var id = "";
    var filter = s.GetValue();
    SelectedTopCompanyVal = s.GetValue();
    var param = id + ";" + filter;
    ddlVisitorName.PerformCallback(param);
    ddlVisitorID.PerformCallback(param);
    grdFilteredVisitors.PerformCallback(filter);
    grdSearchVisitors.PerformCallback(filter);
}
function ddlPostalCodeSelectionChaged(s, e) {
    ddlLocation.SetValue(s.GetValue());
    ddlTopCompanyNr.SetValue(s.GetValue());
    _isFilter = true;
    var id = "";
    var filter = s.GetValue();
    SelectedTopCompanyVal = s.GetValue();
    var param = id + ";" + filter;
    ddlVisitorName.PerformCallback(param);
    ddlVisitorID.PerformCallback(param);
    grdFilteredVisitors.PerformCallback(filter);
    grdSearchVisitors.PerformCallback(filter);
}
function OnGetCurrentVisitor_CallBack(result) {
    Populate_Controls(result);
}
function clearControls() {
    ddlVisitorName.SetValue("0");
    ddlVisitorID.SetValue("0");
    ddlLocation.SetValue("0");
    ddlPostalCode.SetValue("0");
    $("#txtVisitorID").val("");
    $("#txtSurName").val("");
    $("#txtName").val("");
    dplCompanyName.SetValue("0");
    $("#txtStreet").val("");
    $("#txtPostalCode").val("");
    $("#txtLocation").val("");
    $("#txtTelephone").val("");
    $("#txtMobile").val("");
    $("#txtEmail").val("");
    $("#txtVehicleNo").val("");
    $("#txtCardNumber").val("");
    $("#txtCardPinCode").val("");
    $("#txtVisitorPlangroup").val("");
    drpVisitStartDate.SetDate(null);
    drpVisitStartDateTime.SetDate(null);
    drpVisitEndDate.SetDate(null);
    drpVisitEndDateTime.SetDate(null);
    $("#txtSTDTime").val("");
    $("#hiddenFieldVisitInstanceIdNr").val("");
    $("#chkAccessPlanActive")[0].checked = false;
    dtpStartDate.SetDate(null);
    dtpStartDateTime.SetDate(null);
    dtpEndDate.SetDate(null)
    dtpEndDateTime.SetDate(null)
    drpRegDate.SetDate(null);
    drpRegTime.SetDate(null);
    $("#txtVisitReason").val("");
    $("#txtStreetNr").val("");
    $("#txtPersonalName").val("");
    $("#txtPersonnelNumber").val("");
    $("#txtPersPhoneNr").val("");
    $("#txtPersMobileNr").val("");
    $("#txtPersActivated").val("");
    $("#txtCardActivatedTime").val("");
    $("#txtVisitorCompanyName").val("");
    $("#txtVisitorCompanyID").val("");
    $("#txtToCompanyName").val("");
    $("#txtToCompanyId").val("");
    $("#txtVehicleTypes").val("");
    $("#chkCardActive")[0].checked = false;
    $("#chkAutomaticLogout")[0].checked = false;
    drpAutomaticLogout.SetDate(null);
    dplToCompanyNr.SetValue("0");
    dplToCompanyName.SetValue("0");
    cobVisitorPlanNr.SetValue("0");
    cobVisitorPlanName.SetValue("0");
    RemovePhoto();

    $("#img").attr("src", "");
}
function visitorDropdown(s, e) {
    _isSelection = true;
}
function ddlVisitorNameEndCallback(s, e) {
    var id = s.GetValue();
    if (_isFilter === true) {
        var id = s.GetValue();
        _isFilter = false;
        if (parseInt(id) === 0) {
            clearControls();
        }
        else if (parseInt(id) > 0) {
            PageMethods.GetVisitorByID(id, OnGetCurrentVisitor_CallBack);
        }

    }
}
function grdSearchVisitorEndCallBack(s, e) {
    //setTimeout(function (ev) { InitialPageLoadPanel.Hide() }, 1000);

}
function grdVisitorsHistoryDblClick(s, e) {
    var id = grdVisitorsHistory.GetRowKey(e.visibleIndex);
    HideHistory();
    $("#levelCaption").val(0);
    PageMethods.GetVisitorByIDToEdit(id, GetVisitorByIDToEdit_CallBack);
}
function grdVisitorsHistoryEndCallBack(s, e) {

}
function GetVisitorByIDToEdit_CallBack(result) {
    //Populate_ControlsToEdit(result);
    Populate_Controls(result);
    $("#tabcontroldiv").show();
    $(".Visitorsapplicationnewvishis").hide();
    $("#btnEntNew").show();
    $("#btnEntSave").show();
    $("#btnCancelDel").show();
}
function HideHistory() {
    $("#tabcontroldiv").show();
    $(".Visitorsapplicationnewvishis").hide();
    $("#btnEntNew").show();
    $("#btnEntSave").show();
    $("#btnCancelDel").show();
    $("#btnApplyVisitorData").hide();
    getLocalizedText("visitorsData");
    $("#pagenamelbl").text(_message);
    $("#ControlSection1").show();
    $(".ControlSectionhistory").hide();
    $(".ControlSection").show();
}
function ddlTopCompanyNrHistorySelectedChanged(s, e) {
    ddlPostalCodeHistory.SetValue(s.GetValue());
    ddlLocationHistory.SetValue(s.GetValue());
    SetCompanyDropdownValue(s.GetValue());
}
function ddlPostalCodeHistorySelectionChaged(s, e) {
    ddlTopCompanyNrHistory.SetValue(s.GetValue());
    ddlLocationHistory.SetValue(s.GetValue());
    SetCompanyDropdownValue(s.GetValue());
}
function ddlLocationHistorySelectionChanged(s, e) {
    ddlPostalCodeHistory.SetValue(s.GetValue());
    ddlTopCompanyNrHistory.SetValue(s.GetValue());
    SetCompanyDropdownValue(s.GetValue());
}
function ddlVisitorIDHistoryInit(s, e) {
    var count = s.GetItemCount();
    if (count > 0) {
        s.SetSelectedIndex(1);
    }
}
function ddlVisitorNameHistoryInit(s, e) {
    var count = s.GetItemCount();
    if (count > 0) {
        s.SetSelectedIndex(1);
    }
}
function ddlVisitorIDHistorySelectionChanged(s, e) {
    ddlVisitorNameHistory.SetValue(s.GetValue());
}
function ddlVisitorNameHistorySelectionChanged(s, e) {
    ddlVisitorIDHistory.SetValue(s.GetValue());
}
function SetCompanyDropdownValue(company) {
    var _checked = false
    if (company === "0") {
        _checked = true;
    }
    $("#chkAllVisitors")[0].checked = _checked
}


function saveCompanyDetails() {
    var companyId = cobCompanyNr.GetValue();
    var CompanyName = $("#txtCompanyName").val();
    var CompanyNr = $("#txtCompanyNr").val();
    var CompanyMemo = $("#txtCompanyMemo").val();
    var CompanyEmail = $("#txtCompanyEmail").val();
    var CompanyPersName = $("#txtCompanyPersName").val();
    var CompanyZipCode = $("#txtCompanyZipCode").val();
    var CompanyStreet = $("#txtCompanyStreet").val();
    var CompanyTel = $("#txtCompanyTel").val();
    var CompanyMob = $("#txtCompanyMob").val();
    var CompanyHouseNr = $("#txtCompanyHouseNr").val();
    var CompanyFunct = $("#txtCompanyFunct").val();
    var CompanyPlace = $("#txtCompanyPlace").val();
    var CompanyPlaceState = cboCompanyState.GetValue();

    PageMethods.SaveVisitorCompanyDetails(companyId,CompanyName, CompanyNr, CompanyMemo, CompanyEmail, CompanyPersName, CompanyZipCode, CompanyStreet, CompanyTel, CompanyMob,
        CompanyHouseNr, CompanyFunct, CompanyPlace, CompanyPlaceState, OnSaveCompanyDetails_CallBack);
}

function OnSaveCompanyDetails_CallBack(InsertEditCompamy) {
    if (InsertEditCompamy.editMode === 1) {
        //PageMethods.LoadCompanyDetails(InsertEditCompamy.visitorCompId);
        saveCompanyChanges = false;
    }
    else if (InsertEditCompamy.editMode === 2) {
        //PageMethods.LoadCompanyDetails(InsertEditCompamy.visitorCompId);
        saveCompanyChanges = false;
    }
    _cobCompanyClick = false;
    grdVisitorCompany.PerformCallback();
    dplCompanyName.PerformCallback();
    cboVisitorCompany.PerformCallback();
    cobVisitorCompanyNr.PerformCallback();
    cboVisitorPostalCode.PerformCallback();
    cboVisitorLocation.PerformCallback();
    cobCompanyNr.SetEnabled(true);
    cobCompanyName.SetEnabled(true);
    cobCompanyNr.PerformCallback(InsertEditCompamy.visitorCompId);
    cobCompanyName.PerformCallback(InsertEditCompamy.visitorCompId);

    //var Nr = $("#txtCompanyNr").val();
    //PageMethods.GetCompanyDetailsByNr(Nr, OnGetCompanyDetailsCallBack);
}
function OnGetCompanyDetailsCallBack(result) {
    if (result !== null) {
        $("#txtStreet").val(result.Street);
        $("#txtPostalCode").val(result.ZipCode);
        $("#txtLocation").val(result.Place);
        $("#txtStreetNr").val(result.StreetNr);
        $("#txtVisitorCompanyName").val(result.Company);
        $("#txtVisitorCompanyID").val(result.VisitorCompanyId);
        cobCompanyNr.SetEnabled(true);
        cobCompanyName.SetEnabled(true);
        cobCompanyNr.PerformCallback(result.VisitorCompanyId);
        cobCompanyName.PerformCallback(result.VisitorCompanyId);
    }
    else {
        $("#txtStreet").val("");
        $("#txtPostalCode").val("");
        $("#txtLocation").val("");
        $("#txtStreetNr").val("");
        $("#txtVisitorCompanyName").val("");
        $("#txtVisitorCompanyID").val("");
    }
}
function ClearCompanyControls() {
    $("#txtCompanyName").val("");
    $("#txtCompanyMemo").val("");
    $("#txtCompanyEmail").val("");
    $("#txtCompanyPersName").val("");
    $("#txtCompanyZipCode").val("");
    $("#txtCompanyStreet").val("");
    $("#txtCompanyTel").val("");
    $("#txtCompanyMob").val("");
    $("#txtCompanyHouseNr").val("");
    $("#txtCompanyFunct").val("");
    $("#txtCompanyPlace").val("");
}

function EnableControlsOnNew() {
    $("#txtCompanyNr").prop('disabled', false);
    $("#txtCompanyZipCode").prop('disabled', false);
    $("#txtCompanyStreet").prop('disabled', false);

    cboCompanyState.SetEnabled(true);

    $("#txtCompanyPersName").prop('disabled', false);
    $("#txtCompanyFunct").prop('disabled', false);
    $("#txtCompanyTel").prop('disabled', false);
    $("#txtCompanyMob").prop('disabled', false);
    $("#txtCompanyEmail").prop('disabled', false);

    $("#txtCompanyName").prop('disabled', false);
    $("#txtCompanyPlace").prop('disabled', false);
    $("#txtCompanyHouseNr").prop('disabled', false);
    $("#txtCompanyMemo").prop('disabled', false);

    $("#txtCompanyName").focus();
}
function DisableCompanyControls() {
    $("#txtCompanyNr").prop('disabled', true);
    $("#txtCompanyZipCode").prop('disabled', true);
    $("#txtCompanyStreet").prop('disabled', true);

    cboCompanyState.SetEnabled(false);

    $("#txtCompanyPersName").prop('disabled', true);
    $("#txtCompanyFunct").prop('disabled', true);
    $("#txtCompanyTel").prop('disabled', true);
    $("#txtCompanyMob").prop('disabled', true);
    $("#txtCompanyEmail").prop('disabled', true);

    $("#txtCompanyName").prop('disabled', true);
    $("#txtCompanyPlace").prop('disabled', true);
    $("#txtCompanyHouseNr").prop('disabled', true);
    $("#txtCompanyMemo").prop('disabled', true);
}
function EnableCompanyControls() {
    $("#txtCompanyNr").prop('disabled', false);
    $("#txtCompanyZipCode").prop('disabled', false);
    $("#txtCompanyStreet").prop('disabled', false);

    cboCompanyState.SetEnabled(true);

    $("#txtCompanyPersName").prop('disabled', false);
    $("#txtCompanyFunct").prop('disabled', false);
    $("#txtCompanyTel").prop('disabled', false);
    $("#txtCompanyMob").prop('disabled', false);
    $("#txtCompanyEmail").prop('disabled', false);

    $("#txtCompanyName").prop('disabled', false);
    $("#txtCompanyPlace").prop('disabled', false);
    $("#txtCompanyHouseNr").prop('disabled', false);
    $("#txtCompanyMemo").prop('disabled', false);
}
function cboVisitorCompanySelectedChanged(s, e) {
    cobVisitorCompanyNr.SetValue(s.GetValue());
    cboVisitorCompany.SetValue(s.GetValue());
    grdVisitorCompany.PerformCallback(s.GetValue());
}
function cboVisitorPostalCodeSelectionChaged(s, e) {

}
function cboVisitorLocationSelectionChanged(s, e) {

}
function grdVisitorCompanyDblClick(s, e) {
    var id = s.GetRowKey(e.visibleIndex);
    dplCompanyName.SetValue(id);
    PageMethods.GetCompanyDetails(id, OnGetCompanyDetails_CallBack);
    HideClienSeach();
    saveChanges = true;
}
function cboCarTypesSelectedIndexChanged(s, e) {

}
function cboCarTypesEndCallBack(s, e) {

}
function SaveVehicleType() {
    PageMethods.InsertEditVehicleType($("#txtVehicleTypeId").val(), $("#txtVehicle_Type").val(), $("#txtVehicle_RegNr").val(), OnInsertEditVehicleType_CallBack);
}

function grdVehiclesRowValues(values) {
    $("#txtVehicleTypeId").val(values[0]);
    $("#txtVehicle_Type").val(values[1]);
    $("#txtVehicle_RegNr").val(values[2]);
}

function ApplyDates_CallBack(values) {
    drpVisitStartDate.SetDate(values.vStartDate);
    drpVisitStartDateTime.SetDate(values.vStartDateTime);
    drpVisitEndDate.SetDate(values.vEndDate);
    drpVisitEndDateTime.SetDate(values.vEndDateTime);
}


function grdClientsRowClick(s, e) {
    clientVisibleIndex = e.visibleIndex;
}

function ConfirmVehicleTypeDelete(message) {
    var box_content = '<div id="overlayDelete"><div id="box_flameDelete"><div id="dialogBoxDelete">  <img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPicDelete" height="150" width="150" align="middle"> <br/>' + message + '<br/><br/> <button id="btnOkDelete"  onclick="_DeleteVehicleType()"></button><button id="btnNoDelete"  onclick="ResetDialog()"></button><button id="btnCancelDelete"  onclick="ResetDialog()"></button></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("yes");
    $('#btnOkDelete').text(_message);
    getLocalizedText("no");
    $('#btnNoDelete').text(_message);
    getLocalizedText("cancel");
    $('#btnCancelDelete').text(_message);

}
function ConfirmVehicleModelDelete(message) {
    var box_content = '<div id="overlayDelete"><div id="box_flameDelete"><div id="dialogBoxDelete">  <img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPicDelete" height="150" width="150" align="middle"> <br/>' + message + '<br/><br/> <button id="btnOkDelete"  onclick="_DeleteVehicleModel()"></button><button id="btnNoDelete"  onclick="ResetDialog()"></button><button id="btnCancelDelete"  onclick="ResetDialog()"></button></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("yes");
    $('#btnOkDelete').text(_message);
    getLocalizedText("no");
    $('#btnNoDelete').text(_message);
    getLocalizedText("cancel");
    $('#btnCancelDelete').text(_message);

}
function _DeleteVehicleType() {
    ResetDialog();

}

function cboVisitorNameSearchSelectionChanged(s, e) {
    if (!isNaN(parseInt(s.GetValue()))) {
        var id = s.GetValue();
        //console.log("id: " + id);
        ddlVisitorID.SetValue(id);
        ddlVisitorName.SetValue(id);
        var Current = ddlVisitorID.GetSelectedIndex();
        //console.log("Current: " + Current);
        $("#txtFvCurrentEntry").val(Current);
        PageMethods.GetVisitorByID(id, OnGetCurrentVisitor_CallBack);
    }

}
//transponders methods
function SetGrdRowNum(sender, evt) {
    switch (sender.name) {
        case "grdTransponders":
            grdTranspondersRowNum = evt.visibleIndex;
            try {
                if (typeof grdTransponders.batchEditHelper.updatedValues[grdTransponders.keys[grdTranspondersRowNum]] == "undefined") {
                    var lnkText = ". . .";
                    if (grdTransponders.batchEditHelper.pageServerValues[grdTransponders.keys[grdTranspondersRowNum]][6] != null) {
                        lnkText = moment(grdTransponders.batchEditHelper.pageServerValues[grdTransponders.keys[grdTranspondersRowNum]][6]).format("DD.MM.YYYY");
                    }

                    var lnkNode = typeof grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[0].childNodes[1] == 'undefined' ?
                        grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[1] : grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[0].childNodes[1];
                    if (typeof grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[1].childNodes[1] != 'undefined') {
                        lnkNode = grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[1].childNodes[1];
                    }
                    window[lnkNode.id].SetText(lnkText);
                } else {
                    var lnkText = ". . .";
                    if (typeof grdTransponders.batchEditHelper.updatedValues[grdTransponders.keys[grdTranspondersRowNum]][6] != 'undefined') {
                        lnkText = grdTransponders.batchEditHelper.updatedValues[grdTransponders.keys[grdTranspondersRowNum]][6][1];
                    }

                    var lnkNode = typeof grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[0].childNodes[1] == 'undefined' ?
                        grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[1] : grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[0].childNodes[1];
                    if (typeof grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[1].childNodes[1] != 'undefined') {
                        lnkNode = grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[1].childNodes[1];
                    }
                    window[lnkNode.id].SetText(lnkText);
                }
            } catch (e) { console.log(e); }
            break;
        case "grdTranspondersShortTerm":
            grdTranspondersSTRowNum = evt.visibleIndex;
            break;
    }
}

function GetActiveTransponderNr() {
    $("#txtLongTermCardNr").val("");
    setTimeout(function (ev) { GetTransponderAusweisCount() }, 1);

    for (var rowCount = 0;rowCount < grdTransponders.keys.length;rowCount++) {
        var checked = false;
        if (grdTransponders.GetRow(rowCount).cells[2].childNodes[0].childNodes.length > 0) {
            checked = grdTransponders.GetRow(rowCount).cells[2].childNodes[0].childNodes[0].className.toString().indexOf("CheckBoxChecked") != -1;
        } else {
            checked = grdTransponders.GetRow(rowCount).cells[2].childNodes[0].className.toString().indexOf("CheckBoxChecked") != -1;
        }

        if (checked) {
            $("#txtLongTermCardNr").val(grdTransponders.GetRow(rowCount).cells[1].childNodes[0].textContent);
            return;
        }
    }
}

function ausweisChanged(sender, evt, senderNr) {
    var _senderGrd = senderNr == 1 ? grdTransponders : grdTranspondersShortTerm;
    var currentRowNum = senderNr == 1 ? grdTranspondersRowNum : grdTranspondersSTRowNum;
    var checkedClass = 'dxWeb_edtCheckBoxChecked_Office2003Blue'; var uncheckedClass = 'dxWeb_edtCheckBoxUnchecked_Office2003Blue';
    var checkUpdateValueText = '<span class="dxWeb_edtCheckBoxChecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys"></span>';
    var uncheckUpdateValueText = '<span class="dxWeb_edtCheckBoxUnchecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys"></span>';
    var checkLogicalCellNr = 3; var inactiveCheckLogicalCellNr = 7; var inactiveDateLogicalCellNr = 8;

    for (var rowCount = 0;rowCount < _senderGrd.keys.length;rowCount++) {
        var checked = false;
        var nextRowIndex = rowCount + 1 < _senderGrd.keys.length ? rowCount + 1 : rowCount;
        var chkNode = !_senderGrd.GetRow(rowCount).cells[2].childNodes[0].childNodes[0] ?
                        _senderGrd.GetRow(rowCount).cells[2].childNodes[0] : _senderGrd.GetRow(rowCount).cells[2].childNodes[0].childNodes[0];
        if (senderNr == 1) {
            var inactiveChkNode = !_senderGrd.GetRow(rowCount).cells[6].childNodes[0].childNodes[0] ?
                        _senderGrd.GetRow(rowCount).cells[6].childNodes[0] : _senderGrd.GetRow(rowCount).cells[6].childNodes[0].childNodes[0];
            var inactiveDateNode = !_senderGrd.GetRow(rowCount).cells[7].childNodes[0].childNodes[0] ?
                        _senderGrd.GetRow(rowCount).cells[7].childNodes[0] : _senderGrd.GetRow(rowCount).cells[7].childNodes[0].childNodes[0];
        }
        var chkClassName = chkNode.className;

        if (nextRowIndex != rowCount) {
            var nextAusweisText = _senderGrd.GetRow(nextRowIndex).cells[1].childNodes[0].textContent;
            var ausweisText = _senderGrd.GetRow(rowCount).cells[1].childNodes[0].textContent;

            if (chkClassName.indexOf(checkedClass) != -1 || rowCount <= currentRowNum) {
                if (rowCount == currentRowNum) {
                    _senderGrd.batchEditHelper.SetCellValue(rowCount, checkLogicalCellNr, true, checkUpdateValueText);
                    try {
                        chkNode.className = chkClassName.replace(uncheckedClass, checkedClass);
                        chkActive.SetChecked(true);
                        if (senderNr == 1) {
                            inactiveChkNode.className = chkClassName.replace(checkedClass, uncheckedClass);
                            _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveCheckLogicalCellNr, false, uncheckUpdateValueText);
                            chkInactive.SetChecked(false);
                            inactiveDateNode.textContent = "";
                            drpGrdInactiveDate.SetDate(null);
                            _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveDateLogicalCellNr, null, "");
                        }
                    } catch (e) { }

                } else if (nextAusweisText.trim() != "" || rowCount < currentRowNum || ausweisText.trim != "") {
                    _senderGrd.batchEditHelper.SetCellValue(rowCount, checkLogicalCellNr, false, uncheckUpdateValueText);
                    if (senderNr == 1) _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveCheckLogicalCellNr, true, checkUpdateValueText);
                    if (senderNr == 1) _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveDateLogicalCellNr, moment().toDate(), moment().format("DD.MM.YYYY"));
                    try {
                        chkNode.className = chkClassName.replace(checkedClass, uncheckedClass);
                        if (senderNr == 1) {
                            inactiveChkNode.className = chkClassName.replace(uncheckedClass, checkedClass);
                            inactiveDateNode.textContent = moment().format("DD.MM.YYYY");
                        }
                    } catch (e) { }
                }
            }
        }
    }
}

function SetActive(sender, evt, checkCtrl) {
    try { grdTranspondersRowNum = grdTranspondersRowNum < 0 ? $(sender.GetMainElement()).parents("tr")[0].rowIndex - 1 : grdTranspondersRowNum } catch (e) { }
    if (grdTranspondersRowNum >= 0) {
        var checkUpdateValueText = '<span class="dxWeb_edtCheckBoxChecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys"></span>';
        var checkLogicalCellNr = -1;
        if (checkCtrl) {
            if (sender.GetChecked()) {
                checkLogicalCellNr = 7;
                chkInactive.SetChecked(false);
                grdTransponders.batchEditHelper.SetCellValue(grdTranspondersRowNum, checkLogicalCellNr, false, checkUpdateValueText);
                try {
                    var chkClassName = grdTransponders.GetRow(0).cells[6].childNodes[0].childNodes[0].className.replace('dxWeb_edtCheckBoxChecked_Office2003Blue', 'dxWeb_edtCheckBoxUnchecked_Office2003Blue');
                    grdTransponders.GetRow(0).cells[6].childNodes[0].childNodes[0].className = chkClassName;
                } catch (e) { }
                activeCheckedChanged(sender, evt, 1);
            }
        } else {
            if (sender.GetChecked()) {
                checkLogicalCellNr = 3;
                chkActive.SetChecked(false);
                grdTransponders.batchEditHelper.SetCellValue(grdTranspondersRowNum, checkLogicalCellNr, false, checkUpdateValueText);
                try {
                    var chkClassName = grdTransponders.GetRow(0).cells[2].childNodes[0].childNodes[0].className.replace('dxWeb_edtCheckBoxChecked_Office2003Blue', 'dxWeb_edtCheckBoxUnchecked_Office2003Blue');
                    grdTransponders.GetRow(0).cells[2].childNodes[0].childNodes[0].className = chkClassName;
                } catch (e) { }
            }
            if ($(sender.GetMainElement()).parents("table[id='grdTransponders']").length > 0) {
                SetInactiveDate(sender);
            }
        }
    }
}

function SetInactiveDate(sender) {
    if (sender.GetChecked()) {
        drpGrdInactiveDate.SetDate(moment().toDate());
    } else {
        drpGrdInactiveDate.SetDate(null);
    }
}

function GetActiveSTTransponderNr() {
    $("#txtCardPinCode").val("");
    setTimeout(function (ev) { GetTransponderSTAusweisCount() }, 1);

    for (var rowCount = 0;rowCount < grdTranspondersShortTerm.keys.length;rowCount++) {
        var checked = false;
        if (grdTranspondersShortTerm.GetRow(rowCount).cells[2].childNodes[0].childNodes.length > 0) {
            checked = grdTranspondersShortTerm.GetRow(rowCount).cells[2].childNodes[0].childNodes[0].className.toString().indexOf("CheckBoxChecked") != -1;
        } else {
            checked = grdTranspondersShortTerm.GetRow(rowCount).cells[2].childNodes[0].className.toString().indexOf("CheckBoxChecked") != -1;
        }

        if (checked) {
            $("#txtCardPinCode").val(grdTranspondersShortTerm.GetRow(rowCount).cells[1].childNodes[0].textContent);
            return;
        }
    }
}

function activeCheckedChanged(sender, evt, senderNr) {
    var _senderGrd = senderNr == 1 ? grdTransponders : grdTranspondersShortTerm;
    var currentRowNum = senderNr == 1 ? grdTranspondersRowNum : grdTranspondersSTRowNum;
    try { currentRowNum = $(sender.mainElement).parents("tr")[0].rowIndex - 1 } catch (e) { }
    var checkedClass = 'dxWeb_edtCheckBoxChecked_Office2003Blue'; var uncheckedClass = 'dxWeb_edtCheckBoxUnchecked_Office2003Blue';
    var checkUpdateValueText = '<span class="dxWeb_edtCheckBoxChecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys"></span>';
    var uncheckUpdateValueText = '<span class="dxWeb_edtCheckBoxUnchecked_Office2003Blue dxICheckBox_Office2003Blue dxichSys"></span>';
    var checkLogicalCellNr = 3; var inactiveCheckLogicalCellNr = 7; var inactiveDateLogicalCellNr = 8;

    for (var rowCount = 0;rowCount < _senderGrd.keys.length;rowCount++) {
        var checked = false;
        var chkNode = !_senderGrd.GetRow(rowCount).cells[2].childNodes[0].childNodes[0] ?
                        _senderGrd.GetRow(rowCount).cells[2].childNodes[0] : _senderGrd.GetRow(rowCount).cells[2].childNodes[0].childNodes[0];
        if (senderNr == 1) {
            var inactiveChkNode = !_senderGrd.GetRow(rowCount).cells[6].childNodes[0].childNodes[0] ?
                        _senderGrd.GetRow(rowCount).cells[6].childNodes[0] : _senderGrd.GetRow(rowCount).cells[6].childNodes[0].childNodes[0];
            var inactiveDateNode = !_senderGrd.GetRow(rowCount).cells[7].childNodes[0].childNodes[0] ?
                        _senderGrd.GetRow(rowCount).cells[7].childNodes[0] : _senderGrd.GetRow(rowCount).cells[7].childNodes[0].childNodes[0];
        }
        var chkClassName = chkNode.className;
        var ausweisText = _senderGrd.GetRow(rowCount).cells[1].childNodes[0].textContent;

        if (ausweisText.trim() != "") {
            if (rowCount != currentRowNum) {
                _senderGrd.batchEditHelper.SetCellValue(rowCount, checkLogicalCellNr, false, uncheckUpdateValueText);
                if (senderNr == 1) _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveCheckLogicalCellNr, true, checkUpdateValueText);
                if (senderNr == 1) _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveDateLogicalCellNr, moment().toDate(), moment().format("DD.MM.YYYY"));
                try {
                    chkNode.className = chkClassName.replace(checkedClass, uncheckedClass);
                    if (senderNr == 1) {
                        inactiveChkNode.className = chkClassName.replace(uncheckedClass, checkedClass);
                        inactiveDateNode.textContent = moment().format("DD.MM.YYYY");
                    }
                } catch (e) { }
            } else {
                if (senderNr == 1) _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveCheckLogicalCellNr, false, uncheckUpdateValueText);
                try {
                    if (senderNr == 1) {
                        inactiveChkNode.className = chkClassName.replace(checkedClass, uncheckedClass);
                        inactiveDateNode.textContent = "";
                        drpGrdInactiveDate.SetDate(null);
                        //try { grdTransponders.batchEditHelper.updatedValues[currentRowNum + 1][8] } catch (e) { }
                        _senderGrd.batchEditHelper.SetCellValue(rowCount, inactiveDateLogicalCellNr, null, "");
                    }
                } catch (e) { }
            }
        }
    }

    //$("#chkWeekpass")[0].checked = senderNr == 1;
    $("#chkCardActive")[0].checked = senderNr != 1;
    inActivateOtherTransponderGrd(senderNr);
}

function inActivateOtherTransponderGrd(senderNr) {
    var sender = senderNr == 1 ? grdTranspondersShortTerm : grdTransponders;

    try {
        for (var x = 0;x < sender.keys.length;x++) {
            var activeCheckNode = sender.GetRow(x).cells[2].childNodes[0];
            if (sender.GetRow(x).cells[2].childNodes[0].childNodes.length != 0) {
                activeCheckNode = sender.GetRow(x).cells[2].childNodes[0].childNodes[0];
            }

            if (activeCheckNode.className.toString().indexOf("edtCheckBoxChecked") != -1) {
                setTimeout((function (checkNode) {
                    $(checkNode).click();
                })(activeCheckNode), 1);

                if (senderNr != 1) {
                    var inActiveCheckNode = grdTransponders.GetRow(x).cells[6].childNodes[0];
                    if (grdTransponders.GetRow(x).cells[6].childNodes[0].childNodes.length != 0) {
                        inActiveCheckNode = grdTransponders.GetRow(x).cells[6].childNodes[0].childNodes[0];
                    }

                    setTimeout((function (checkNode) {
                        $(checkNode).click();
                    })(inActiveCheckNode), 1);
                }
            }
        }
    } catch (e) { console.log(e); }

    sender.batchEditHelper.EndEdit()
}

function CheckTransponderInactiveDate(sender, evt) {
    try {
        var currentRowIndex = evt.visibleIndex; //$(sender.GetMainElement()).parents("tr")[0].rowIndex - 1;
        var transponderId = grdTransponderInactiveHist.keys[currentRowIndex];

        if (parseInt(transponderId) > 0) {
            drpGrdHistInactiveDate.SetEnabled(false);
        } else {
            drpGrdHistInactiveDate.SetEnabled(true);
        }
    } catch (e) { }
}

function SetTransponderInactiveDate(sender, evt) {
    try {
        var currentRowIndex = $(sender.GetMainElement()).parents("tr")[0].rowIndex - 1;
        var transponderId = grdTransponderInactiveHist.keys[currentRowIndex];

        if (parseInt(transponderId) < 0) {
            grdTransponders.batchEditHelper.SetCellValue(grdTranspondersRowNum, 6, drpGrdHistInactiveDate.GetDate(), moment(drpGrdHistInactiveDate.GetDate()).format("DD.MM.YYYY"));
            window[grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[0].childNodes[1].id].SetText(moment(drpGrdHistInactiveDate.GetDate()).format("DD.MM.YYYY"));
            try {
                window[grdTransponders.GetRow(grdTranspondersRowNum).cells[5].childNodes[1].childNodes[1].id].SetText(moment(drpGrdHistInactiveDate.GetDate()).format("DD.MM.YYYY"));
            } catch (e) { }
            UpdateHistoryUpdateObject(grdTranspondersRowNum, moment(drpGrdHistInactiveDate.GetDate()).format("YYYY-MM-DDT00:00:00.000"));
        }
    } catch (e) { console.log(e); }
}
function ShowEndingDates(sender, evt) {
    try {

    } catch (e) { }
    var top = parseFloat($(sender.GetMainElement()).position()["top"]) + parseFloat($(sender.GetMainElement()).height());
    var left = parseFloat($(sender.GetMainElement()).position()["left"]);
    var width = parseFloat($(sender.GetMainElement()).width());
    var currentRowIndex = $(sender.GetMainElement()).parents("tr")[0].rowIndex - 1;
    var transponderId = grdTransponders.keys[currentRowIndex];
    var transponderNr = grdTransponders.GetRow(currentRowIndex).cells[1].childNodes[0].textContent;

    if (!isNaN(parseInt(transponderId)) && parseInt(transponderId) > 0) {
        transponderNr = parseInt(transponderNr); transponderNr = isNaN(transponderNr) || transponderNr < 0 ? 0 : transponderNr;
    } else {
        transponderNr = 0;
    }

    $("#transponderInactiveHist").css({
        "position": "absolute", "top": top + "px", "left": left + "px", "width": width < 140 ? 140 : width + "px"
    }).toggle();

    grdTransponderInactiveHist.PerformCallback(String.format('{{"memberId": "{0}", "transponderNr": "{1}"}}', cobMemberNr.GetValue(), transponderNr));

    //setTimeout(function (ev) {
    //    $("#transponderInactiveHist").focus();
    //}, 200);
}
function GetTransponderSTAusweisCount() {
    var ausweisCount = 0;
    for (var rowCount = 0;rowCount < grdTranspondersShortTerm.keys.length;rowCount++) {
        var rowKey = grdTranspondersShortTerm.keys[rowCount];
        if (parseInt(rowKey) > 0 && !(isNaN(parseInt(rowKey)))) {
            ausweisCount = ausweisCount + 1;
        }
    }

    $("#lblAusweisCount").text(ausweisCount);
}

function GetTransponderAusweisCount() {
    var ausweisCount = 0, actionCount = 0;
    for (var rowCount = 0;rowCount < grdTransponders.keys.length;rowCount++) {
        var rowKey = grdTransponders.keys[rowCount];
        if (parseInt(rowKey) > 0 && !(isNaN(parseInt(rowKey)))) {
            ausweisCount = ausweisCount + 1;
            var rowActionCount = grdTransponders.GetRow(rowCount).cells[8].childNodes[0].textContent;
            if (parseInt(rowActionCount) > 0 && !(isNaN(parseInt(rowActionCount)))) {
                actionCount = actionCount + parseInt(rowActionCount);
            }
        }
    }

    $("#lblCardCount").text(ausweisCount);
    $("#lblActionCount").text(actionCount);
}
function UpdateHistoryUpdateObject(rowIndex, rowValue) {
    try {
        if (histUpdate == null) CreateHistoryUpdateObject();
        histUpdate[0][grdTransponders.keys[grdTranspondersRowNum]] = rowValue;
    } catch (e) { }
    grdTransponderInactiveHist.batchEditHelper.EndEdit();
}
function CreateHistoryUpdateObject() {
    try {

        histUpdate = [{}];
    } catch (e) { }
}
// end transponders
//Begin vehicles
function cboVehicleTypesSelectionChanged(s, e) {
    $("#lblVehicleManu").text(s.GetText());
    grdManufacturer.PerformCallback(s.GetSelectedIndex());
    grdVehicleModel.PerformCallback(s.GetText());
}
function grdManufacturerRowClick(s, e) {
    window.grdManufacturer.GetRowValues(e.visibleIndex, "ID;Name", GetManufacturerName);
}
function grdVehicleModelRowClick(s, e) {
    window.grdVehicleModel.GetRowValues(e.visibleIndex, "ID;Type", GetModelName);

}
function GetManufacturerName(value) {
    cboVehicleTypes.SetValue(value[0]);
    $("#txtManufacturer").removeAttr("disabled");
    $("#btnSaveManufacturer").removeAttr("disabled");
    $("#txtManufacturerId").val(value[0]);
    $("#lblVehicleManu").text(value[1]);
    $("#txtManufacturer").val(value[1]);
    $("#txtVehicleModelId").val("");
    $("#txtModelType").val("");
    $("#txtModelType").attr("disabled", "disabled");
    grdVehicleModel.PerformCallback(value[1]);
}
function GetModelName(value) {
    $("#txtModelType").removeAttr("disabled");
    $("#txtVehicleModelId").val(value[0]);
    $("#txtModelType").val(value[1]);
    $("#btnSaveModel").removeAttr("disabled");
    $("#txtManufacturerId").val("");
    $("#txtManufacturer").val("");
    $("#txtManufacturer").attr("disabled", "disabled");
}
function SaveVehicleManufacturer() {
    if ($("#txtManufacturer").val().trim() === "") return;
    $("#btnNewModel").removeAttr("disabled");
    $("#btnSaveModel").removeAttr("disabled");
    $("#btnDeleteModel").removeAttr("disabled");
    var id = 0;
    if (isNaN(parseInt($("#txtManufacturerId").val()))) {
        id = 0;
    }
    else {
        id = parseInt($("#txtManufacturerId").val());
    }
    var manufacturer = $("#txtManufacturer").val();
    var holder = cboVehicleTypes.GetText();
    PageMethods.SaveManufacturer(id, manufacturer, holder, OnSaveManufacturer_CallBack);
}
function OnSaveManufacturer_CallBack(result) {
    $("#txtManufacturer").val("");
    $("#txtManufacturer").attr("disabled", "disabled");
    cboVehicleTypes.PerformCallback(result);
}
function SaveVehicleModel() {
    if ($("#txtModelType").val().trim() === "") return;
    $("#btnNewManufacturer").removeAttr("disabled");
    $("#btnSaveManufacturer").removeAttr("disabled");
    $("#btnDeleteManufacturer").removeAttr("disabled");
    var id = 0;
    if (isNaN(parseInt($("#txtVehicleModelId").val()))) {
        id = 0;
    }
    else {
        id = parseInt($("#txtVehicleModelId").val());
    }
    var manufacturer = cboVehicleTypes.GetText();
    var model = $("#txtModelType").val();
    PageMethods.SaveVehicleModel(id, manufacturer, model, OnSaveVehicleModel_CallBack);
}
function OnSaveVehicleModel_CallBack(result) {
    $("#txtVehicleModelId").val("");
    $("#txtModelType").val("");
    $("#txtModelType").attr("disabled", "disabled");
    grdVehicleModel.PerformCallback(cboVehicleTypes.GetText());
}
function DisableTexbox() {
    $("#txtManufacturer").attr("disabled", "disabled");
    $("#txtModelType").attr("disabled", "disabled");
}
function grdManufacturerEndCallBack(s, e) {

}

function DeleteManufacturer() {
    window.grdManufacturer.GetRowValues(grdManufacturer.GetFocusedRowIndex(), "ID;Name", GetManufacturerRow);
}
function GetManufacturerRow(value) {
    if (value[1].trim() === "") return;
    PageMethods.DeleteManufacturer(value[1], OnDeleteManufacturer_CallBack);
}
function OnDeleteManufacturer_CallBack() {
    $("#txtManufacturer").val("");
    $("#txtManufacturer").attr("disabled", "disabled");
    cboVehicleTypes.PerformCallback();
}
function DeleteVehicleModel() {
    var id = grdVehicleModel.GetRowKey(grdVehicleModel.GetFocusedRowIndex());
    if (isNaN(parseInt(id))) return;
    PageMethods.DeleteModel(id, OnDeleteModel_CallBack);
}
function OnDeleteModel_CallBack() {
    $("#txtModelType").val("");
    $("#txtModelType").attr("disabled", "disabled");
    grdVehicleModel.PerformCallback(cboVehicleTypes.GetText());
}
function cboVehicleTypesEndCallBack(s, e) {

}
function SaveAlert(message) {
    //getLocalizedText("buildingPlanDeleteWarning");
    //var message = levelCaption;
    var box_content = '<div id="overlay"><div id="box_flame"><div id="saveAlertBox">  <img src="../../Images/FormImages/save50px.png" alt="Stop" class="stopPic" height="50" width="50" align="right"> <br/>' + message + '<br/> <button id="btnOkAlert"  onclick="SaveAlertOnClick()"></button></div></div></div>';
    document.getElementById('saveAlert').innerHTML = box_content;
    getLocalizedText("yes");
    $('#btnOkAlert').text(levelCaption);
}
function SaveAlertOnClick() {
    document.getElementById('saveAlert').innerHTML = "";
}
function grdVehicleModelRowDbClick(s, e) {
    var index = e.visibleIndex;
    if (parseInt(index) >= 0) {
        var id = grdVehicleModel.GetRowKey(index);
        var name = grdVehicleModel.GetRow(index).cells[0].childNodes[0].textContent;
        $("#txtVehicleId").val(id);
        $("#txtVehicleTypes").val(name);
        HideVehicleTypes();
    }
}
// end vehicles

function OnDeleteCard_CallBack() {
    grdTranspondersShortTerm.PerformCallback(ddlVisitorID.GetValue());
    InitialPageLoadPanel.Hide();
}
function EnableDropdowns() {
    ddlTopCompanyNr.SetEnabled(true);
    ddlPostalCode.SetEnabled(true);
    ddlLocation.SetEnabled(true);
    ddlVisitorID.SetEnabled(true);
    ddlVisitorName.SetEnabled(true);
}
// delete dialog
function Confirm_Delete() {
    var message = "Sind Sie sicher das Sie das Besucher löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Achtung</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 40%; margin-right: 0px;"  onclick="DeleteVisitor()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitVisitorDeletion");
    $('#btnOk').text(_message);
    getLocalizedText("cancelVisitorDeletion");
    $('#btnCancel').text(_message);
}
function DeleteVisitor() {
    ResetDialog();
    var visitorId = ddlVisitorID.GetValue();
    PageMethods.DeleteVisitor(visitorId, OnDeleteVisitor_CallBack);
}
function OnDeleteVisitor_CallBack() {
    ddlTopCompanyNr.SetValue("0");
    ddlPostalCode.SetValue("0");
    ddlLocation.SetValue("0");
    var filter = 0;
    var id = 0;
    _callBackParam = id + ";" + filter;
    ddlVisitorID.PerformCallback(_callBackParam);
    clearControls();
}
function CancelOnBackButton() {
    ResetDialog();
}
function ConfirmRemovePhoto() {
    var message = "Sind Sie sicher das Sie das Foto tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 44%; margin-right: 0px;"  onclick="Remove_Photo()"></button><button id="btnCancel" style="width: 134px;"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitPhotoDeletion");
    $('#btnOk').text(_message);
    getLocalizedText("cancelPhotoDelete");
    $('#btnCancel').text(_message);
}
function Remove_Photo() {
    ResetDialog();
    HideWebCam();
    RemovePhoto();
    saveChanges = true;
    if (parseInt(ddlVisitorID.GetValue()) > 0) {
        $('#btnEntSave').click();
    }
}
function ConfirmClearPhoto() {
    var message = "Sind Sie sicher, dass Sie löschen möchten";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 76%; margin-right: 0px;"  onclick="Clear_Photo()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("yes");
    $('#btnOk').text(_message);
    getLocalizedText("cancel");
    $('#btnCancel').text(_message);
}
function Clear_Photo() {
    ResetDialog();
    UnFreezeWebcam();
}
// end delete dialog
function grdShortTermEndCallBack(s, e) {
    if (isBack == true) {
        isBack = false;
        document.location.href = "/Index.aspx";
    }
    GetActiveSTTransponderNr();
    setTimeout(function (ev) { BindDataGridAfterSaving() }, 1);
}
function HideVehicleTypes() {
    ResetPageTitle();
    $("#UpperDiv").show();
    $(".searchVehicletype").hide()
    $("#btnEntNew").show();
    $("#btnEntSave").show();
    $("#btnCancelDel").show();
    $('#btnBack').addClass('btnClose');
    $('#btnBack').removeClass('btnDeletenew2');
    $('#btnActHelp').addClass('btnHelp');
    $('#btnActHelp').removeClass('btnnewhelp');
    $(".BottomFooterBtnsLeft_car").hide();
    $(".manufacture").hide();
    $(".footerextra").hide();
    $("#AEHeaderLeftDiv").show();
    $(".fulltxtarealbl").show();
    $(".textsearcharea").show();
    $(".secLeftTopcartypenew").hide();
    $("#levelCaption").val(0);
}

//function ConfirmApplyPhoto() {
//    var message = "Übernehmen Foto?";
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 76%; margin-right: 0px;"  onclick="ApplyPhoto()"></button><button id="btnCancel"  onclick="CancelApplyPhoto(); return false;" style=" position: relative;"></button></div></div></div></div>';
//    document.getElementById('importantDialog').innerHTML = box_content;
//    getLocalizedText("yes");
//    $('#btnOk').text(_message);
//    getLocalizedText("cancel");
//    $('#btnCancel').text(_message);
//}

function ConfirmApplyPhoto() {
    var message = "Übernehmen Foto?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 35%; width:130px; color: forestgreen !important; margin-right: 0px;"  onclick="ApplyPhoto()"></button><button id="btnCancel" style="width: 175px; color: red !important; margin-left: 0px;" onclick="CancelApplyPhoto(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnOk').text(_message);
    getLocalizedText("newNoText");
    $('#btnCancel').text(_message);
}
function CancelApplyPhoto() {
    ResetDialog();
    HideWebCam();
    applyPhoto = false;
    $("#levelCaption").val(0);
}

function ApplyPhoto() {
    saveChanges = true;
    applyPhoto = false;
    ResetDialog();
    AcceptPhoto();
    if (parseInt($("#levelCaption").val()) == 17) {
        HideWebCam();
        $("#levelCaption").val(0);
    }
}
//function ConfirmDeleteAusweis() {
//    var message = "Sind Sie sicher, dass Sie löschen möchten";
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 76%; margin-right: 0px;"  onclick="DeleteAusweis()"></button><button id="btnCancel"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
//    document.getElementById('importantDialog').innerHTML = box_content;
//    getLocalizedText("yes");
//    $('#btnOk').text(_message);
//    getLocalizedText("cancel");
//    $('#btnCancel').text(_message);
//}


function ConfirmDeleteAusweis() {
    var message = "Sind Sie sicher das Sie das Ausweis tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 42%; margin-right: 0px;"  onclick="DeleteAusweis()"></button><button id="btnCancel" style="margin-left: 1px;"  onclick="CancelOnBackButton(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitCardDeletion");
    $('#btnOk').text(_message);
    getLocalizedText("cancelCardDeletion");
    $('#btnCancel').text(_message);
}

function DeleteAusweis() {
    ResetDialog();
    if (!isNaN(parseInt(grdTranspondersShortTerm.GetSelectedKeysOnPage()[0]))) {
        var id = parseInt(grdTranspondersShortTerm.GetSelectedKeysOnPage()[0]);
        if (id > 0) {
            var visitorId = ddlVisitorID.GetValue();
            if (parseInt(visitorId) > 0) {
                InitialPageLoadPanel.Show();
                PageMethods.DeleteCard(id, visitorId, OnDeleteCard_CallBack);
            }

        }
    }
}
function HideCompanyDetails() {
    ResetDialog();
    $("#UpperDiv").show();
    $(".searchclint").hide()
    $("#btnEntNew").show();
    $("#btnEntSave").show();
    $("#btnCancelDel").show();
    $(".ControlSectionnewclient").hide();
    $(".ControlSection").show();
    $(".searchclintnewclint").hide();
    $("#btnCancelDel").show();
    $("#ControlSection1").show();
    $("#txtCompanyNr").val("");
    ClearCompanyControls();
    $("#levelCaption").val(0);
}
//confirm save company details
//function ConfirmSaveCompanyDetails() {
//    var message = "Willst du die Änderungen speichern";
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick=" CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 76%; margin-right: 0px;"  onclick="saveCompanyDetailsConfirm()"></button><button id="btnCancel"  onclick=" HideCompanyDetails(); return false;" style=" position: relative;"></button></div></div></div></div>';
//    document.getElementById('importantDialog').innerHTML = box_content;
//    getLocalizedText("yes");
//    $('#btnOk').text(_message);
//    getLocalizedText("no");
//    $('#btnCancel').text(_message);
//}

function ConfirmSaveCompanyDetails() {
    var message = "Willst du die Änderungen speichern?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 30%;width: 155px; margin-right: 0px;"  onclick="saveCompanyDetailsConfirm()"></button><button id="btnBackNo"  onclick="No_OnBack()"></button><button id="btnCancel"  onclick="HideCompanyDetails(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnBackOk').text(_message);
    getLocalizedText("newNoText");
    $('#btnBackNo').text(_message);
}
function No_OnBack() {
    ResetDialog();
    // window.location.href = "/Index.aspx";
    HideCompanyDetails();
    saveCompanyChanges = false;
}

function saveCompanyDetailsConfirm() {
    ResetDialog();
    var companyId = cobCompanyNr.GetValue();
    var CompanyName = $("#txtCompanyName").val();
    var CompanyNr = $("#txtCompanyNr").val();
    var CompanyMemo = $("#txtCompanyMemo").val();
    var CompanyEmail = $("#txtCompanyEmail").val();
    var CompanyPersName = $("#txtCompanyPersName").val();
    var CompanyZipCode = $("#txtCompanyZipCode").val();
    var CompanyStreet = $("#txtCompanyStreet").val();
    var CompanyTel = $("#txtCompanyTel").val();
    var CompanyMob = $("#txtCompanyMob").val();
    var CompanyHouseNr = $("#txtCompanyHouseNr").val();
    var CompanyFunct = $("#txtCompanyFunct").val();
    var CompanyPlace = $("#txtCompanyPlace").val();
    var CompanyPlaceState = cboCompanyState.GetValue();

    PageMethods.SaveVisitorCompanyDetails(companyId, CompanyName, CompanyNr, CompanyMemo, CompanyEmail, CompanyPersName, CompanyZipCode, CompanyStreet, CompanyTel, CompanyMob,
        CompanyHouseNr, CompanyFunct, CompanyPlace, CompanyPlaceState, OnSaveCompanyDetailsConfirm_CallBack);
}

function ResetPageTitle() {
    getLocalizedText("visitor");
    $("#pagenamelbl").text(_message);
}

function OnSaveCompanyDetailsConfirm_CallBack(InsertEditCompamy) {
    if (InsertEditCompamy.editMode === 1) {
        PageMethods.LoadCompanyDetails(InsertEditCompamy.visitorCompId);
        saveCompanyChanges = false;
    }
    else if (InsertEditCompamy.editMode === 2) {
        PageMethods.LoadCompanyDetails(InsertEditCompamy.visitorCompId);
        saveCompanyChanges = false;
    }
    _cobCompanyClick = false;
    grdVisitorCompany.PerformCallback();
    dplCompanyName.PerformCallback();
    cboVisitorCompany.PerformCallback();
    cobVisitorCompanyNr.PerformCallback();
    cboVisitorPostalCode.PerformCallback();
    cboVisitorLocation.PerformCallback();
    cobCompanyNr.PerformCallback(InsertEditCompamy.visitorCompId);
    cobCompanyName.PerformCallback(InsertEditCompamy.visitorCompId);

    //var Nr = $("#txtCompanyNr").val();
    //PageMethods.GetCompanyDetailsByNr(Nr, OnGetCompanyDetailsCallBackConfirm);
}
function OnGetCompanyDetailsCallBackConfirm(result) {
    if (result !== null) {
        $("#txtStreet").val(result.Street);
        $("#txtPostalCode").val(result.ZipCode);
        $("#txtLocation").val(result.Place);
        $("#txtStreetNr").val(result.StreetNr);
        $("#txtVisitorCompanyName").val(result.Company);
        $("#txtVisitorCompanyID").val(result.VisitorCompanyId);
    }
    else {
        $("#txtStreet").val("");
        $("#txtPostalCode").val("");
        $("#txtLocation").val("");
        $("#txtStreetNr").val("");
        $("#txtVisitorCompanyName").val("");
        $("#txtVisitorCompanyID").val("");
    }
    HideCompanyDetails();
}
//end confirm save company details
function companySelectionChanged(s, e) {
    if (_cobCompanyClick === true) {

        cobCompanyNr.SetValue(s.GetValue());
        cobCompanyName.SetValue(s.GetValue());
        var id = parseInt(s.GetValue());
        if (id > 0) {
            PageMethods.GetCompanyByID(s.GetValue(), OnGetCompanyByID_CallBack);
        }
        else {
            $("#txtCompanyNr").val("");
            ClearCompanyControls();
            DisableCompanyControls();
        }
    }
}
function OnGetCompanyByID_CallBack(result) {
    $("#txtCompanyName").val(result.CompanyName);
    $("#txtCompanyNr").val(result.CompanyNr);
    $("#txtCompanyMemo").val(result.Memo);
    $("#txtCompanyEmail").val(result.Email);
    $("#txtCompanyPersName").val(result.Name);
    $("#txtCompanyZipCode").val(result.ZipCode);
    $("#txtCompanyStreet").val(result.Street);
    $("#txtCompanyTel").val(result.Telephone);
    $("#txtCompanyMob").val(result.Mobile);
    $("#txtCompanyHouseNr").val(result.HouseNr);
    $("#txtCompanyFunct").val(result.PersFunction);
    $("#txtCompanyPlace").val(result.Place);
    cboCompanyState.SetValue(result.FederalState);
    EnableCompanyControls();
}
function cobCompanyClick(s, e) {
    _cobCompanyClick = true;
}
function HideCopanyDetails() {
    $("#UpperDiv").show();
    $(".searchclint").hide()
    $("#btnEntNew").show();
    $("#btnEntSave").show();
    $("#btnCancelDel").show();
    $(".ControlSectionnewclient").hide();
    $(".ControlSection").show();
    $(".searchclintnewclint").hide();
    $(".btmsecLeftMidcreatenew").hide();
    $("#btnCancelDel").show();
    $("#ControlSection1").show();
    //ClearCompanyControls();
    $("#txtCompanyNr").val("");
    $("#levelCaption").val(0);
}
function grdVisitorCompanyRowClick(s, e) {
    var id = s.GetRowKey(e.visibleIndex);
    cobVisitorCompanyNr.SetValue(id);
    cboVisitorCompany.SetValue(id);
}
//vehicle type dialogs
function ConfirmDeleteManufacturer() {
    var message = "Sind Sie sicher das Sie das Hersteller tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 40%; margin-right: 0px; width:120px;"  onclick="DeleteManuConfirmed()"></button><button id="btnCancel" style="margin-left: 1px; width:160px;"  onclick="ResetDialog(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitDeleteManufacturer");
    $('#btnOk').text(_message);
    getLocalizedText("cancelDeleteManufacturer");
    $('#btnCancel').text(_message);
}
function ConfirmDeleteVehicleType() {
    var message = "Sind Sie sicher das Sie das Fahrzeugtyp tatsächlich löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 35%; margin-right: 0px; width:125px;"  onclick="DeleteTypeConfirmed()"></button><button id="btnCancel" style="margin-left: 1px; width:172px;"  onclick="ResetDialog(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("permitDeleteVehicleType");
    $('#btnOk').text(_message);
    getLocalizedText("cancelDeleteVehicleType");
    $('#btnCancel').text(_message);
}
function DeleteManuConfirmed() {
    ResetDialog();
    DeleteManufacturer();
}
function DeleteTypeConfirmed() {
    ResetDialog();
    DeleteVehicleModel();
}

function _sendVisitorData(addBooking)
{
    if (parseInt(ddlVisitorID.GetText()) > 0)
    {
        var visitorID = parseInt(ddlVisitorID.GetText());
        showLoadingPanel();
        PageMethods.SendVisitorDataToTerminals(visitorID, addBooking, OnTerminalAction_CallBack);
    }
}

function _checkOutVisitor() {
    if (parseInt(ddlVisitorID.GetText()) > 0) {
        var visitorID = parseInt(ddlVisitorID.GetText());
        showLoadingPanel();
        PageMethods.CheckOutVisitor(visitorID, OnTerminalAction_CallBack);
        alert('');
    }
}

function showLoadingPanel() {
    LoadingPanel.Show();
}

function OnTerminalAction_CallBack(messageText) {
    LoadingPanel.Hide();
    alert(messageText);
}

//end vehicle type dialogs
function SetDefaultTime() {
    var todayDate = new Date();
    var todayDate2 = new Date();
    drpVisitStartDate.SetDate(todayDate);
    drpVisitEndDate.SetDate(todayDate);
    //modify time
    todayDate.setHours(23);
    todayDate2.setHours(00);
    todayDate.setMinutes(59);
    todayDate2.setMinutes(00);
    todayDate.setSeconds(00);
    todayDate2.setSeconds(00);
    drpVisitStartDateTime.SetDate(todayDate2);
    drpVisitEndDateTime.SetDate(todayDate);
}