var levelCaption = "";
var saveChanges = false;
$(function () {
    //$( "#PageTitleLbl2" ).text( "Zusatzbogen" );

    //getLocalizedText("applicationForm");
    //$("#PageTitleLbl2").text(levelCaption);

    $('#btnSave').on("click", function (e) {
        e.preventDefault();
        SavepersonaladditionalInfor();
    });


    $('#btnNew').on("click", function (e) {
        e.preventDefault();
        ClearControls();
    });

    $('#btnSearchAllEmp').on("click", function (e) {
        e.preventDefault();
        FindEmployee();
    });


    $('.ListenForChange').on("change", function (e) {
        saveChanges = true;
        e.preventDefault();
        //console.log(this.id);
    });

    $('.txtHidden').on("change", function (e) {
        saveChanges = true;
        e.preventDefault();
        console.log(this.id);
    });

    $('#btnDelete').on("click", function (e) {
        e.preventDefault();

        PersNr = dplIDNr.GetText();
        PageMethods.DeletePers(PersNr, ClearControls);
    });

    $('#btnPersonalStamm').on("click", function (e) {
        e.preventDefault();
        PersNr = dplIDNr.GetText();
        GetQueryStrings()
    });

    $('#btnBack').on("click", function (e) {
        e.preventDefault();
        if (saveChanges === true && allowZUTEdit) {
            BackButtonConfirm();
        }
        else {
            PersNr = dplIDNr.GetText();
            GetQueryStrings()
        }
        //PersNr = dplIDNr.GetText();
        //GetQueryStrings()
    });

    $("#fvNavPrev").click(function (ev) {
        ev.preventDefault();
        navigatePersonal(-1);
    });


    $("#fvNavNext").click(function (ev) {
        ev.preventDefault();
        navigatePersonal(1);
    });

    document.getElementById('txtPersonnelNo').disabled = true;
    document.getElementById('txtTitle').disabled = true;
    document.getElementById('txtSalutation').disabled = true;
    document.getElementById('txtFirstName').disabled = true;
    document.getElementById('txtName').disabled = true;
    document.getElementById('txtPostalCode').disabled = true;
    GetQueryString();
});


function GetQueryStrings() {
    window.location.href = "PersonalInactive.aspx?ID=" + dplIDNr.GetText();
}

function dplClientsSelectedIndexChanged(s, e) {
    selectionChanged = true;
    saveChanges = false;
    // var ClientID = s.GetSelectedItem().texts[0];
    var ClientID = dplClients.GetValue();

    var value = s.GetValue();
    var pass = value + ";" + "1";
    dpllPersName.PerformCallback(pass);
    dplIDNr.PerformCallback(pass);
    dplAusweisNr.PerformCallback(pass);
    window.setTimeout(function i() {
        ResetClientsNameComboValueFromCallback(value);
    }, 1000);

}

function dpllLocationSelectedIndexChanged(s, e) {
    selectionChanged = true;
    saveChanges = false;
    var LocationID = dpllLocation.GetValue();
    PageMethods.GetPersByLocationID(LocationID, fillControls);


    var value = s.GetValue();
    var pass = value + ";" + "2";
    dpllPersName.PerformCallback(pass);
    dplIDNr.PerformCallback(pass);
    dplAusweisNr.PerformCallback(pass);
    window.setTimeout(function i() {
        ResetLocationNameComboValueFromCallback(value);
    }, 1000);


}

function dplDepartmentSelectedIndexChanged(s, e) {
    selectionChanged = true;
    saveChanges = false;
    var DepartmentID = dplDepartment.GetValue();
    PageMethods.GetPersByDepartmentID(DepartmentID, fillControls);

    var value = s.GetValue();
    var pass = value + ";" + "3";
    dpllPersName.PerformCallback(pass);
    dplIDNr.PerformCallback(pass);
    dplAusweisNr.PerformCallback(pass);
    window.setTimeout(function i() {
        ResetDepartmentComboValueFromCallback(value);
    }, 1000);

}

function ResetClientsNameComboValueFromCallback(value) {
    dplClients.SetValue(value);
    ResetPersonalInfoComboValueFromCallback();
}

function ResetLocationNameComboValueFromCallback(value) {
    dpllLocation.SetValue(value);
    ResetPersonalInfoComboValueFromCallback();
}

function ResetDepartmentComboValueFromCallback(value) {
    dplDepartment.SetValue(value);
    ResetPersonalInfoComboValueFromCallback();
}

function ResetPersonalInfoComboValueFromCallback() {
    dpllPersName.SetValue("0");
    dplIDNr.SetValue("0");
    dplAusweisNr.SetValue("0");
    CountPersonal();
}

function dpllPersNameSelectedIndexChanged(s, e) {

    //var PersID = dpllPersName.GetValue();
    //SetValues(PersID);
    //PageMethods.GetPersByNr( PersID, fillControls );

    var value = s.GetValue();
    dplAusweisNr.SetValue(value);
    dplIDNr.SetValue(value);
    SetValues(value);
    CountPersonal();
    var Current = s.GetSelectedIndex();
    $("#txtCurrentPersonnel").val(Current);
    var count = parseInt(s.GetItemCount()) - 1;
    $("#txtTotalPersonnel").val(count);
}


function dplIDNrSelectedIndexChanged(s, e) {

    //var PersID = dplIDNr.GetValue();
    //SetValues(PersID);
    //PageMethods.GetPersByNr( PersID, fillControls );

    var value = s.GetValue();
    dplAusweisNr.SetValue(value);
    dpllPersName.SetValue(value);
    SetValues(value);
    CountPersonal();
    var Current = s.GetSelectedIndex();
    $("#txtCurrentPersonnel").val(Current);
    var count = parseInt(s.GetItemCount()) - 1;
    $("#txtTotalPersonnel").val(count);
}

function dplAusweisNrPersNameSelectedIndexChanged(s, e) {

    //var PersID = dplAusweisNr.GetValue();
    //SetValues(PersID);
    //PageMethods.GetPersByNr( PersID, fillControls );

    var value = s.GetValue();
    dpllPersName.SetValue(value);
    dplIDNr.SetValue(value);
    SetValues(value);
    CountPersonal();
    var Current = s.GetSelectedIndex();
    $("#txtCurrentPersonnel").val(Current);
    var count = parseInt(s.GetItemCount()) - 1;
    $("#txtTotalPersonnel").val(count);
}

function GetQueryString() {
    var qrStr = window.location.search;
    var spQrStr = qrStr.substring(1);
    var arrQrStr = new Array();

    var arr = spQrStr.split("&");
    for (var i = 0; i < arr.length; i++) {
        var index = arr[i].indexOf("=");
        var key = arr[i].substring(0, index);
        var val = arr[i].substring(index + 1);
        arrQrStr[key] = val;
    }

    if (arrQrStr["PersIDNr"] !== null) {
        SetValues(arrQrStr["PersIDNr"]);
        //PageMethods.GetPersByNr(arrQrStr["PersIDNr"], fillControls);

    }

}



function SavepersonaladditionalInfor() {
    var jsonArray = GetPersonalDataFromControls();
    var jsonString = JSON.stringify(jsonArray);

    var jsonArrayDynamic = getDynamicFieldsData();
    var jsonStringDynamic = JSON.stringify(jsonArrayDynamic);

    PageMethods.SavePersonal(jsonString, jsonStringDynamic);
    saveChanges = false;
}

function GetPersonalDataFromControls() {
    var jsonArray = [];
    PersNr = dplIDNr.GetValue();


    jsonArray.push({
        Pers_Nr: PersNr,
        PersonalNumber: PersNr,
        PhysicalAddress: $("#txtPlaceOfResidence").val(),
        Street: $("#txtRoad").val(),
        PalceOfBirth: $("#txtPlaceOfBirth").val(),
        DOB: txtDateOfBirth.GetDate(),
        Gender: $("#txtGender").val(),
        MaritalStatus: $("#txtMaritalStatus").val(),
        Nationality: $("#txtNationality").val(),
        Additonal: $("#txtAdditional").val(),
        Bankname: $("#txtBank").val(),
        AccountOwner: $("#txtAccountHolder").val(),
        BankCode: $("#txtBank").val(),
        AccountNo: $("#txtBankAccount").val(),
        BIC: $("#txtBic").val(),
        IBAN: $("#txtIban").val(),
        DriversLicense: $("#txtDrivingLicense").val(),
        Since: txtSince.GetValue(),
        Children: $("#txtChildren").val(),
        TaxOfficee: $("#txtTaxOffice").val(),
        TaxClass: $("#txtTaxClass").val(),
        HealthInsuarance: $("#txtHealthInsurance").val(),
        HealthInsuaranceNo: $("#txtHealthInsuranceNumber").val(),
        PensionInsuarance: $("#txtPensionInsurance").val(),
        SozVerzNo: $("#txtSozVerseNumber").val(),
        Contract: $("#txtContract").val(),
        EmployedFrom: txtEmployedFrom.GetValue(),
        EmployedAs: $("#txtEmployedAs").val(),
        LearnedOccupation: $("#txtLearnedProfession").val(),
        EmploymentType: $("#txtEmployed").val(),
        ResidencePermit: $("#txtResidencePermit").val(),
        AuthorisedBy: $("#txtAuthhorizedBy").val(),
        ApprovedBy: $("#txtApprovedBy").val(),
        NoOfHours: $("#txtNumberOfHours").val(),
        EndOfContract: txtContractTerminates.GetValue(),
        EliminatedOn: txtElimanatedOn.GetValue(),
        Reason: $("#txtReason").val(),
        CertificateOfEmployment: $("#txtEmploymentReference").val(),
        ClientID: $("#dplClients").val(),
        LocationID: $("#dpllLocation").val(),
        DepartmentID: $("#dplDepartment").val(),

    });

    return jsonArray;
}




function fillControls(PersonalData_DTO) {

    if (PersonalData_DTO.PersonalNumber != null) {
        dpllPersName.SetValue(PersonalData_DTO.PersonalNumber);
    }
    else { dpllPersName.SetValue(0); }

    if (PersonalData_DTO.PersonalNumber != null) {
        dplIDNr.SetValue(PersonalData_DTO.PersonalNumber);
    }
    else { dplIDNr.SetValue(0); }


    if (PersonalData_DTO.PersonalNumber != null) {
        dplAusweisNr.SetValue(PersonalData_DTO.PersonalNumber);
    }
    else { dplAusweisNr.SetValue(0); }



    $("#txtPersonnelNo").val(PersonalData_DTO.PersonalNumber);
    $("#txtTitle").val(PersonalData_DTO.Title);
    $("#txtSalutation").val(PersonalData_DTO.Salutation);
    $("#txtFirstName").val(PersonalData_DTO.FirstName);
    $("#txtName").val(PersonalData_DTO.LastName);
    $("#txtPostalCode").val(PersonalData_DTO.PostalCode);

    $("#txtPlaceOfResidence").val(PersonalData_DTO.PhysicalAddress);
    $("#txtRoad").val(PersonalData_DTO.Street);
    $("#txtPlaceOfBirth").val(PersonalData_DTO.PalceOfBirth);
    txtDateOfBirth.SetDate(PersonalData_DTO.DOB);
    $("#txtGender").val(PersonalData_DTO.Gender);
    $("#txtMaritalStatus").val(PersonalData_DTO.MaritalStatus);
    $("#txtNationality").val(PersonalData_DTO.Nationality);
    $("#txtAdditional").val(PersonalData_DTO.Additonal);
    $("#txtBank").val(PersonalData_DTO.Bankname);
    $("#txtAccountHolder").val(PersonalData_DTO.AccountOwner);
    $("#txtBank").val(PersonalData_DTO.BankCode);
    $("#txtBankAccount").val(PersonalData_DTO.AccountNo);
    $("#txtAccountNumber").val(PersonalData_DTO.AccountNo);
    $("#txtBic").val(PersonalData_DTO.BIC);
    $("#txtIban").val(PersonalData_DTO.IBAN);
    $("#txtDrivingLicense").val(PersonalData_DTO.DriversLicense);
    txtSince.SetDate(PersonalData_DTO.Since);
    $("#txtChildren").val(PersonalData_DTO.Children);
    $("#txtTaxOffice").val(PersonalData_DTO.TaxOfficee);
    $("#txtTaxClass").val(PersonalData_DTO.TaxClass);
    $("#txtHealthInsurance").val(PersonalData_DTO.HealthInsuarance);
    $("#txtHealthInsuranceNumber").val(PersonalData_DTO.HealthInsuaranceNo);
    $("#txtPensionInsurance").val(PersonalData_DTO.PensionInsuarance);
    $("#txtSozVerseNumber").val(PersonalData_DTO.SozVerzNo);
    $("#txtContract").val(PersonalData_DTO.Contract);
    txtEmployedFrom.SetDate(PersonalData_DTO.EmployedFrom);
    $("#txtEmployedAs").val(PersonalData_DTO.EmployedAs);
    $("#txtLearnedProfession").val(PersonalData_DTO.LearnedOccupation);
    $("#txtEmployed").val(PersonalData_DTO.EmploymentType);
    $("#txtResidencePermit").val(PersonalData_DTO.ResidencePermit);
    $("#txtAuthhorizedBy").val(PersonalData_DTO.AuthorisedBy);
    $("#txtApprovedBy").val(PersonalData_DTO.ApprovedBy);
    $("#txtNumberOfHours").val(PersonalData_DTO.NoOfHours);
    txtContractTerminates.SetDate(PersonalData_DTO.EndOfContract);
    txtElimanatedOn.SetDate(PersonalData_DTO.EliminatedOn);
    $("#txtReason").val(PersonalData_DTO.Reason);
    $("#txtEmploymentReference").val(PersonalData_DTO.CertificateOfEmployment);

    PageMethods.GetPersonalDynamicFields(PersonalData_DTO.PersonalNumber, DisplayDynamicFieldValues)
}

function DisplayDynamicFieldValues(response) {
    var DYNAMIC_FIELD_COUNT = 42

    for (fieldIndex = 1; fieldIndex <= DYNAMIC_FIELD_COUNT; fieldIndex = fieldIndex + 1) {

        if (response.length >= fieldIndex) {
            var dynamicField = response[fieldIndex - 1];
            $("#lblF" + dynamicField.FieldIndex).text(dynamicField.FieldText);
            $("#txtFF" + dynamicField.FieldIndex).val(dynamicField.FieldValue)
        }
        else {
            $("#lblF" + fieldIndex).text('F' + fieldIndex + '..');
            $("#txtFF" + fieldIndex).val('')
        }
    }
}

function ClearControls() {
    document.getElementById('txtPlaceOfResidence').value = "";
    document.getElementById('txtRoad').value = "";
    document.getElementById('txtPlaceOfBirth').value = "";
    txtDateOfBirth.SetDate(moment().toDate());
    document.getElementById('txtGender').value = "";
    document.getElementById('txtMaritalStatus').value = "";
    document.getElementById('txtNationality').value = "";
    document.getElementById('txtAdditional').value = "";
    document.getElementById('txtBank').value = "";
    document.getElementById('txtAccountNumber').value = "";
    document.getElementById('txtAccountHolder').value = "";
    document.getElementById('txtBank').value = "";
    document.getElementById('txtBankAccount').value = "";
    document.getElementById('txtBic').value = "";
    document.getElementById('txtIban').value = "";
    document.getElementById('txtDrivingLicense').value = "";
    txtSince.SetDate(moment().toDate());
    document.getElementById('txtChildren').value = "";
    document.getElementById('txtTaxOffice').value = "";
    document.getElementById('txtTaxClass').value = "";
    document.getElementById('txtHealthInsurance').value = "";
    document.getElementById('txtHealthInsuranceNumber').value = "";
    document.getElementById('txtPensionInsurance').value = "";
    document.getElementById('txtSozVerseNumber').value = "";
    document.getElementById('txtContract').value = "";
    txtEmployedFrom.SetDate(moment().toDate());
    document.getElementById('txtEmployedAs').value = "";
    document.getElementById('txtLearnedProfession').value = "";
    document.getElementById('txtEmployed').value = "";
    document.getElementById('txtResidencePermit').value = "";
    document.getElementById('txtAuthhorizedBy').value = "";
    document.getElementById('txtApprovedBy').value = "";
    document.getElementById('txtNumberOfHours').value = "";
    txtContractTerminates.SetDate(moment().toDate());
    txtElimanatedOn.SetDate(moment().toDate());
    document.getElementById('txtReason').value = "";
    document.getElementById('txtEmploymentReference').value = "";
}

function getDynamicFieldsData() {
    var jsonArray = [];
    var DYNAMIC_FIELD_COUNT = 42

    for (fieldIndex = 1; fieldIndex <= DYNAMIC_FIELD_COUNT; fieldIndex = fieldIndex + 1) {
        jsonArray.push({
            PersonalNumber: dplIDNr.GetValue(),
            FieldIndex: fieldIndex,
            FieldText: $("#lblF" + fieldIndex).text(),
            FieldValue: $("#txtFF" + fieldIndex).val(),
        });
    }

    return jsonArray;
}
//function BackButtonConfirm() {
//    //getLocalizedText("saveChangesConfirmation");
//    //var message = levelCaption;
//    var message = "Änderungen speichern";
//    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox">  <img src="../../Images/FormImages/infoblue2.png" alt="Stop" class="stopPic" height="50" width="50" align="middle">  <br/>  <br/>  <br/>' + message + '<br/> <br/> <button id="btnOk"  onclick="SaveChangesOnBack()"></button><button id="btnNo"  onclick="CancelOnBackButtton()"></button></div></div></div>';
//    document.getElementById('importantDialog').innerHTML = box_content;
//    getLocalizedText("yes");
//    $('#btnOk').text("speichern");
//    getLocalizedText("no");
//    $('#btnNo').text("nicht speichern");
//    //getLocalizedText("cancel");
//    //$('#btnCancel').text(levelCaption);
//}

function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="cancelSaveReset(); return true;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnBackOk"  style="margin-left: 28%;width: 155px; margin-right: 0px;"  onclick="SaveChangesOnBack(); return true;"></button><button id="btnNo"  onclick="CancelOnBackButtton(); return true;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnBackOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
    //getLocalizedText("cancel");
    //$('#btnCancel').text(levelCaption);
}

function cancelSaveReset() {
    document.getElementById('importantDialog').innerHTML = "";
}

function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "PersonalFormInactive.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}
function SaveChangesOnBack() {
    ResetDefault();
    var jsonArray = GetPersonalDataFromControls();
    var jsonString = JSON.stringify(jsonArray);

    var jsonArrayDynamic = getDynamicFieldsData();
    var jsonStringDynamic = JSON.stringify(jsonArrayDynamic);

    PageMethods.SavePersonal(jsonString, jsonStringDynamic, OnSavePersonal_CallBack);
}
function OnSavePersonal_CallBack() {
    PersNr = dplIDNr.GetText();
    GetQueryStrings();
}
function ResetDefault() {
    document.getElementById('importantDialog').innerHTML = "";
}
function CancelOnBackButtton() {
    document.getElementById('importantDialog').innerHTML = "";
    PersNr = dplIDNr.GetText();
    GetQueryStrings();
}

function FindEmployee() {
    $("#contentholder").hide();
    $(".upperSectionPersonal").hide();
    $(".searchPersonnelData").show();
    $(".tabcontroldiv").css({ height: "91%" });


    //$( '#btnBack' ).unbind( "click" );
    //$( '#btnBack' ).bind( "click", function ( e ) {
    //    e.preventDefault();
    //    HideSearchEmployee();
    //} );
    //$( '#btnBack' ).unbind( "click" );
}

function HideSearchEmployee() {
    $(".searchPersonnelData").hide();
    $(".upperSectionPersonal").show();
    $("#contentholder").show();
    $(".tabcontroldiv").css({ height: "83%" });
}

function CountPersonal() {
    var persCount = dpllPersName.GetItemCount();
    var hasKeine = dpllPersName.FindItemByValue(0) == null;

    if (hasKeine) persCount = persCount - 1 != -1 ? persCount - 1 : 0;

    $("#txtTotalPersonnel").val(persCount - 1 != -1 ? persCount - 1 : 0);
    var selectedPers = dpllPersName.GetSelectedIndex();
    selectedPers = selectedPers != -1 ? selectedPers : persCount > 1 ? persCount - 1 : 0;
    $("#txtCurrentPersonnel").val(selectedPers);
}

function SetValues(value) {
    selectionChanged = true;
    saveChanges = false;
    CountPersonal();
    PageMethods.GetPersByNr(value, fillControls)
}
function BindSelectedPers(value) {
    HideSearchEmployee();
    dpllPersName.SetValue(value);
    dplAusweisNr.SetValue(value);
    dplIDNr.SetValue(value);
    SetValues(value);
}
function navigatePersonal(navDirection) {
    var nextIndex = dpllPersName.GetSelectedIndex() + navDirection;

    if (nextIndex > 0 && nextIndex < dpllPersName.GetItemCount()) {
        var nextValue = dpllPersName.GetItem(nextIndex).value;
        if (!isNaN(nextValue)) {
            dpllPersName.SetValue(nextValue);
            dplAusweisNr.SetValue(nextValue);
            dplIDNr.SetValue(nextValue);
            SetValues(nextValue);
            //CountPersonal();
            //PageMethods.Getpersonal(nextValue, Setcontrals);
        }
    }
}
//function dplClientsSelectedIndexChanged(value) {
//    var pass = value + ";" + "1";
//    cmbPersName.PerformCallback(pass);
//    cmbIDNr.PerformCallback(pass);
//    cmbAusweisNr.PerformCallback(pass);
//    grdPersData.PerformCallback(pass);
//}
//function dpllLocationSelectedIndexChanged(value) {
//    var pass = value + ";" + "2";
//    cmbPersName.PerformCallback(pass);
//    cmbIDNr.PerformCallback(pass);
//    cmbAusweisNr.PerformCallback(pass);
//    grdPersData.PerformCallback(pass);
//}
//function dplDepartmentSelectedIndexChanged(value) {
//    var pass = value + ";" + "3";
//    cmbPersName.PerformCallback(pass);
//    cmbIDNr.PerformCallback(pass);
//    cmbAusweisNr.PerformCallback(pass);
//    grdPersData.PerformCallback(pass);
//}