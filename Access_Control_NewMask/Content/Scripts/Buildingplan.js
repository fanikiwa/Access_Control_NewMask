var BuildingPlanArea;
var levelCaption = "";
var PlanId = 0;
var accessCalenderAssigned = false;
var switchCalenderAssigned = false;
var doorList = null;
var doorAssignedReader = null;
var readerType = null;
var _isDplClick = false;
function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "Gebaudeplan.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}

$(function () {
    BuildingPlanArea = CreatePlan("BuildingAreaDiv");
    init();
    setCheckBoxMode();
    //InitializeDeleteConfirmation();
    //get localized texts
    getLocalizedText("newString");
    var newString = levelCaption;
    $("#btnTake").hide();
    getLocalizedText("entries")
    $('#entries').text(levelCaption);
    getLocalizedText("terminalAssignment")
    $('#terminalAssignment').text(levelCaption);
    getLocalizedText("name2");
    $('#name').text(levelCaption);
    getLocalizedText("rename");
    $('#rename').text(levelCaption);
    getLocalizedText("conclude");
    $('#conclude').text(levelCaption);
    getLocalizedText("information");
    $('#infomation').text(levelCaption);
    getLocalizedText("deleteButton");
    $('#delete').text(levelCaption);
    getLocalizedText("switchingCalender")
    $('#switchingCalender').text(levelCaption);
    getLocalizedText("terminalInfo");
    $('#terminalInfo').text(levelCaption);
    getLocalizedText("newBuilding");
    $('#building').text(levelCaption);
    getLocalizedText("newFloor");
    $('#floor').text(levelCaption);
    getLocalizedText("newRoom");
    $('#room').text(levelCaption);
    getLocalizedText("newDoor");
    $('#door').text(levelCaption);

    loadExistingPlan();

    $('#btnAddLocation').click(function (evt) {
        evt.preventDefault();
        var locationCount = PlanDiagram.findNodesByExample({ level: "1" }).count;
        if (locationCount > 0) {
            getLocalizedText("locationExists");
            alert(levelCaption);
        }
        else {
            AddObjectToPlan(BuildingPlanArea, "Standort");
        }

    });

    $('#btnBack').click(function (evt) {
        evt.preventDefault();
        //var i = $("#dpllPlanNr option:selected").val();
        var i = $("#txtPlanNr").val().trim();
        if (i !== "0" && saveChanges == true && allowZUTEdit) {
            BackButtonConfirm();
        }
        else {

            window.location.href = "/Index.aspx";

        }
    });
    //$('#btnTMK').click(function (evt) {
    //    evt.preventDefault();
    //    //var i = $("#dpllPlanNr option:selected").val();
    //    var i = $("#txtPlanNr").val().trim();
    //    if (i !== "0" && saveChanges == true) {
    //        BackButtonConfirmTermConfig();
    //    }
    //    else {

    //        //RedirectToTermConfig();
    //        PageMethods.RedirectTotermConfig(function(){});

    //    }
    //});

    $("#txtEditor").change(function (e) {
        e.preventDefault();
        edit_mode = true;
        var curobj = PlanDiagram.selection.iterator.first();
        if (curobj == null) return;
        if (curobj.data.level === "2") {
            RenameFloors(curobj);
        }


    });



    $('#btnAddBuilding').click(function (evt) {
        evt.preventDefault();

        addChild(BuildingPlanArea);
    });

    $('#btnZoomIn').click(
       function (evt) {
           evt.preventDefault();
           BuildingPlanArea.commandHandler.increaseZoom();
       });
    $('#btnZoomOut').click(
        function (evt) {
            evt.preventDefault();
            BuildingPlanArea.commandHandler.decreaseZoom();
        });

    $('#btnSave').click(
        function (evt) {
            evt.preventDefault();
            if ($("#txtPlanNr").val().trim() === "" || $("#txtPlanNr").val().trim() === "0") {

                getLocalizedText("noSelection");

                alert(levelCaption);
            } else if ($("#txtPlanName").val().trim() === "" || $("#txtPlanNr").val().trim() === "keine") {

                getLocalizedText("noSelection");

                alert(levelCaption);
            }
            else {
                save();
                saveChanges = false;
                //$("#dpllPlanNr").removeAttr("disabled");
                //$("#dplPlanName").removeAttr("disabled");
                dpllPlanNr.SetEnabled(true);
                dplPlanName.SetEnabled(true);
                if (allowZUTEdit) $("#btnNew").removeAttr("disabled");
                if (allowZUTEdit) $("#btnCancelDel").removeAttr("disabled");
            }

            BuildNavMenus();
        });

    $('#btnNew').click(
        function (evt) {
            evt.preventDefault();
            SetControlsOnNew();
            dplPlanName.SetValue(0);
            dpllPlanNr.SetValue(0);
            $("#txtPlanName").focus();
            setNextPlanNo();
            AddObjectToPlan(BuildingPlanArea, "Standort");
            saveChanges = true;

        });

    $('#btnEdit').click(
        function (evt) {
            evt.preventDefault();
            if ($("#txtPlanNr").val().trim() === "" || $("#txtPlanNr").val().trim() === "0") {

                getLocalizedText("noSelection");

                alert(levelCaption);
            } else { SetControlsOnEdit(); }

        });
    $("#chkTerminal").click(function () {
        if ($("#chkTerminal")[0].checked === true) {
            var readerStatus = true;
            ActivateDeactivateReader(readerStatus);
            saveChanges = true;
        }
        else if ($("#chkTerminal")[0].checked === false) {
            var readerStatus = false;
            ActivateDeactivateReader(readerStatus);
            saveChanges = true;
        }
    });

    $("#chkHideLocation").click(function () {
        if ($("#chkHideLocation")[0].checked === true) {
            $("#chkHideLocBuilding")[0].checked = false;
            var _visibility = false;
            HideShowLocation(_visibility);
            var _buildingVisibility = true;
            HideShowBuilding(_buildingVisibility);
        }
        else if ($("#chkHideLocation")[0].checked === false) {
            var _visibility = true;
            HideShowLocation(_visibility);
            HideShowBuilding(_visibility);
        }
        setCheckboxStates();
    });
    $("#chkHideLocBuilding").click(function () {
        if ($("#chkHideLocBuilding")[0].checked === true) {
            $("#chkHideLocation")[0].checked = false;
            var _visibility = false;
            HideShowLocation(_visibility);
            HideShowBuilding(_visibility);
        }
        else if ($("#chkHideLocBuilding")[0].checked === false) {
            var _visibility = true;
            HideShowLocation(_visibility);
            HideShowBuilding(_visibility);
        }
        setCheckboxStates();
    });

    $('#btnCancelDel').click(
        function (evt) {
            evt.preventDefault();
            if (!allowZUTEdit) return;
            if ($("#txtPlanNr").val().trim() === "" || $("#txtPlanNr").val().trim() === "0") {

                getLocalizedText("noSelection");

                alert(levelCaption);
            }

            else {

                getLocalizedText("buildingPlanDeleteWarning");
                ConfirmDelete(levelCaption);

            }

        });

    $("#btnFullScreenMode").css("background-image", "url('../../Images/FormImages/maximize.png')");
    $("#btnFullScreenMode").click(function (evt) {
        //DOM Loaded
        //var headerStatus = $("#MainHeader").css("display");

        //Do not postback
        evt.preventDefault();

        //$("#btnFullScreenMode").text = "Standard";
        //$("#btnFullScreenMode").css("background-image", "url('../../Images/FormImages/minimize.png')");

        //screenMode(headerStatus);

    });
    $("#txtPlanNr").change(function (e) {
        e.preventDefault();
        saveChanges = true;
    });
    $("#txtPlanName").change(function (e) {
        e.preventDefault();
        saveChanges = true;
    });
});

function screenMode(_headerStatus) {

    //Take Status Grid into Full Scree mode by hiding Header and Footer Content
    if (_headerStatus !== "none") {
        $("#MainHeader").hide(100);
        //$("#InfoFooter").hide(100);
        $("#InfoHeader").hide(100);
        $("#SideNavDiv").hide(100);
        $("#MainContentDiv").css("height", "99%");
        $("#MainContentDiv").css("width", "99%");
        //$("#MainContentDiv").css("margin-top", "4px");
        $("#ContentAreaDiv").css("height", "95%");
        $("#ContentAreaDiv").css("width", "100%");
        $("#MainContentAreaDiv").css("height", "99%");
        $("#MainContentAreaDiv").css("width", "99%");
        $("#btnFullScreenMode").attr("value", "Standard");
        $("#btnFullScreenMode").css("background-image", "url('../../Images/FormImages/minimize.png')");

    }

        //Take Status Grid back to Standard Mode
    else if (_headerStatus === "none") {
        $("#MainHeader").show(100);
        $("#InfoFooter").show(100);
        $("#InfoHeader").show(100);
        $("#SideNavDiv").show(100);
        $("#MainContentAreaDiv").css("width", "87.5%");
        $("#MainContentAreaDiv").css("height", "99%");
        $("#ContentAreaDiv").css("height", "77%");
        $("#MainContentDiv").css("height", "94%");
        $("#MainContentDiv").css("width", "99.5%");
        $("#MainContentAreaDiv").css("height", "94%");
        $("#MainContentAreaDiv").css("width", "87%");
        $("#btnFullScreenMode").attr("value", "Vollbild");
        $("#btnFullScreenMode").css("background-image", "url('../../Images/FormImages/maximize.png')");
        //$("#lblFullScreenClock").hide(100);
        $(window).resize();
    }

    //alert("Jetzt Presse F11.");
}

function GetBuildingPlan_Callback(result) {
    var response = result.BuildingPlan;
    load(response);
    //dplPlanName.SetValue(response.ID.toString());
    //dpllPlanNr.SetValue(response.ID.toString());
    $("#txtPlanNr").val(response.PlanNr.toString());
    $("#txtPlanName").val(response.PlanName.toString());
    //bind check boxes

    accessCalenderAssigned = result.accessCalendar;
    //CheckIfAccessCalendarAssigned(response.ID);

    var accessAssigned = accessCalenderAssigned;
    switchCalenderAssigned = result.switchCalendar;
    //CheckIfSwitchCalendarAssigned(response.ID);
    var switchAssigned = switchCalenderAssigned;

    doorList = result.doorsList;
    //GetDoorsList(response.ID);

    var doors = doorList;
    if (doors == null) return;
    for (i = 0; i < doors.length; i++) {
        var doorNode = doors[i];
        var nodeKey = parseInt(doorNode.Key);
        var doorObject = PlanDiagram.findNodeForKey(nodeKey);
        SetDefaultProperty(doorObject);
    }

    doorAssignedReader = result.assignedDoorsList;

    //GetDoorsAssignedReader(response.ID);
    var doorAssignedReaderList = doorAssignedReader;
    if (doorAssignedReaderList == null) return;

    for (y = 0; y < doorAssignedReaderList.length; y++) {
        var doorNode = doorAssignedReaderList[y];
        var nodeKey = parseInt(doorNode.doorId);
        var readerDesc = doorNode.readerType;
        var readerDirection = doorNode.readerDirection;
        var ReaderStatus = doorNode.readerStatus;
        var ReaderAssigned = doorNode.readerAssigned;
        var AccessProfile = doorNode.accessProfileActive;
        var SwitchProfile = doorNode.switchProfileActive;
        var ManualOpening = doorNode.manualOpeningActive;
        var doorObject = PlanDiagram.findNodeForKey(nodeKey);
        SetReaderAssignedStatus(doorObject, readerDesc, readerDirection, ReaderAssigned, ReaderStatus, AccessProfile, SwitchProfile, ManualOpening);
    }

    HideShowNodesOnLoad();
}

function SetControlsOnLoad() {
    $("#txtPlanNr").attr("disabled", "disabled");
    $("#txtPlanName").attr("disabled", "disabled");
    $("#btnSave").attr("disabled", "disabled");
    $("#btnAddBuilding").attr("disabled", "disabled");
    $("#btnAddLocation").attr("disabled", "disabled");

    $("#txtPlanNr").val((dpllPlanNr.GetText()));
    $("#txtPlanName").val(dplPlanName.GetText());

    getLocalizedText("deleteButton");
    $("#btnCancelDel").val(levelCaption);

    $("#btnCancelDel").data("mode", "Löschen");

    //$("#btnCancelDel").val("Löschen");

    //$("#dpllPlanNr").removeAttr("disabled");
    //$("#dplPlanName").removeAttr("disabled");
    dpllPlanNr.SetEnabled(true);
    dplPlanName.SetEnabled(true);

    if (allowZUTEdit) $("#btnNew").removeAttr("disabled");
    if (allowZUTEdit) $("#btnCancelDel").attr("disabled", "disabled");
    if (allowZUTEdit) $("#btnEdit").attr("disabled", "disabled");
    editMode = false;
    //$("#btnEdit").removeAttr("disabled");
    //load("{ \"position\": \"-5 -5\",\n  \"model\": { \"class\": \"go.GraphLinksModel\",\n  \"nodeDataArray\": [  ],\n  \"linkDataArray\": [  ]} }");
}
function SetControlsOnNew() {
    if (allowZUTEdit) $("#txtPlanNr").removeAttr("disabled");
    if (allowZUTEdit) $("#txtPlanName").removeAttr("disabled");
    $("#txtPlanNr").val("");
    $("#txtPlanName").val("");
    if (allowZUTEdit) $("#btnSave").removeAttr("disabled");
    if (allowZUTEdit) $("#btnAddBuilding").removeAttr("disabled");
    //$("#btnAddLocation").removeAttr("disabled");
    dpllPlanNr.SetEnabled(false);
    dplPlanName.SetEnabled(false);
    //$("#dpllPlanNr").attr("disabled", "disabled");
    //$("#dplPlanName").attr("disabled", "disabled");

    $("#btnNew").attr("disabled", "disabled");
    $("#btnEdit").attr("disabled", "disabled");

    //getLocalizedText("cancel");
    //$("#btnCancelDel").val(levelCaption);

    $("#btnCancelDel").data("mode", "Abbrechen");
    $("#btnCancelDel").attr("disabled", "disabled");
    editMode = true;
    //$("#btnCancelDel").val("Abbrechen");

    load("{ \"position\": \"-5 -5\",\n  \"model\": { \"class\": \"go.GraphLinksModel\",\n  \"nodeDataArray\": [  ],\n  \"linkDataArray\": [  ]} }");
}
function SetControlsOnEdit() {
    $("#txtPlanNr").removeAttr("disabled");
    $("#txtPlanName").removeAttr("disabled");
    if (allowZUTEdit) $("#btnSave").removeAttr("disabled");
    if (allowZUTEdit) $("#btnAddBuilding").removeAttr("disabled");
    //$("#btnAddLocation").removeAttr("disabled");

    $("#btnNew").attr("disabled", "disabled");
    $("#btnEdit").attr("disabled", "disabled");
    editMode = true;
    //PlanDiagram.allowTextEdit = true;
    //getLocalizedText("cancel");
    //$("#btnCancelDel").val(levelCaption);

    $("#btnCancelDel").data("mode", "Abbrechen");
    if (allowZUTEdit) $("#btnCancelDel").removeAttr("disabled");
    //$("#btnCancelDel").val("Abbrechen");
}

function setNextPlanNo() {
    var maxNo = 0;
    $(function () { // DOM is ready

        var currNo = [];

        //$('#dpllPlanNr option').each(function () {
        //    currNo.push(this.text);
        //});
        for (var i = 0; i < dpllPlanNr.GetItemCount() ; i++) {
            currNo.push(dpllPlanNr.GetItem(i).text);
        }
        maxNo = Math.max.apply(Math, currNo);
        maxNo++;

    });
    $("#txtPlanNr").val(maxNo);
}
$(document).ready(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();
})
function GetPlanID() {
    $.ajax({
        type: "POST",
        async: false,
        url: "Gebaudeplan.aspx/GetPlanID",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            PlanId = result.d;
        }
    });
}
function loadExistingPlan() {
    GetPlanID();
    var buildingPlanId = PlanId;
    if (buildingPlanId != null && buildingPlanId > 0) {
        PageMethods.GetBuildingPlan(buildingPlanId, GetBuildingPlan_Callback);

        if (allowZUTEdit) $("#btnEdit").removeAttr("disabled");
        if (allowZUTEdit) $("#btnCancelDel").removeAttr("disabled");
        //SetControlsOnEdit();
    }
    else {
        $("#btnCancelDel").attr("disabled", "disabled");
        $("#btnEdit").attr("disabled", "disabled");
        load("{ \"position\": \"-5 -5\",\n  \"model\": { \"class\": \"go.GraphLinksModel\",\n  \"nodeDataArray\": [  ],\n  \"linkDataArray\": [  ]} }");
    }
}
// changes 19/8/2015

function CopyGridValues(sourcename, destinationname, visibleIndex, columnIndex, value, text) {

    //if (destinationname === grdSelectedProj.name) {

    //    grdSelectedProj.GetRow(visibleIndex).cells[columnIndex].childNodes[0].textContent = text

    //}
    //else
    if (destinationname === BuildingPlanDetais.name) {
        BuildingPlanDetais.GetRow(visibleIndex).cells[columnIndex].childNodes[0].textContent = text

    }
}

function CopyCurrentGridValueFromDiag(obj) {

    //CopyGridValues("", BuildingPlanDetais.name, 0, 4, obj.data.key, obj.data.key);
    var level = obj.data.level;


    if (!(obj instanceof go.Link)) {

        if (level === "1") {
            CopyGridValues("", BuildingPlanDetais.name, 0, 0, obj.data.key, obj.data.key);
        } else if (level === "2") {
            CopyGridValues("", BuildingPlanDetais.name, 0, 1, obj.data.key, obj.data.key);

        } else if (level === "3") {
            CopyGridValues("", BuildingPlanDetais.name, 0, 2, obj.data.key, obj.data.key);

        } else if (level === "4") {
            CopyGridValues("", BuildingPlanDetais.name, 0, 3, obj.data.key, obj.data.key);

        } else if (level === "5") {
            CopyGridValues("", BuildingPlanDetais.name, 0, 4, obj.data.key, obj.data.key);



        }
    }
}


function CopyRestGridValuesFromDiag(obj) {
    var _NodeKey = obj.data.key;
    var level = obj.data.level;
    while (level != "1" && level != "") {
        try {
            var _parentNode = PlanDiagram.findPartForKey(_NodeKey).findNodesInto().iterator.first();
            CopyCurrentGridValueFromDiag(_parentNode);
            _NodeKey = _parentNode.data.key;
            level = _parentNode.data.level;
        } catch (e) {
            //Error Processing Parent Node
        }
    }
}

function CheckIfAccessCalendarAssigned(buildingPlanId) {
    var data = { buildingPlanId: buildingPlanId };

    $.ajax({
        type: "POST",
        async: false,
        url: "Gebaudeplan.aspx/CheckIfAccessCalendarAssigned",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            accessCalenderAssigned = result.d;
        }
    });
}
function CheckIfSwitchCalendarAssigned(buildingPlanId) {
    var data = { buildingPlanId: buildingPlanId };

    $.ajax({
        type: "POST",
        async: false,
        url: "Gebaudeplan.aspx/CheckIfSwitchCalendarAssigned",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            switchCalenderAssigned = result.d;
        }
    });
}
function GetDoorsList(buildingPlanId) {
    var data = { buildingPlanId: buildingPlanId };

    $.ajax({
        type: "POST",
        async: false,
        url: "Gebaudeplan.aspx/GetDoorsList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            doorList = result.d;
        }
    });
}
function SetDefaultProperty(obj) {
    if (obj !== null) {
        var readerDrctn = "";
        var readerImg = "../../Images/FormImages/bp_red24px.png";
        var diagram = PlanDiagram;
        diagram.startTransaction("Set default");
        var nodedata = obj.part.data;
        diagram.model.setDataProperty(nodedata, "directionImg", readerDrctn);
        diagram.model.setDataProperty(nodedata, "readerStatusImg", readerImg);
        diagram.commitTransaction("Set default");
    }

}
function GetDoorsAssignedReader(buildingPlanId) {
    var data = { buildingPlanId: buildingPlanId };

    $.ajax({
        type: "POST",
        async: false,
        url: "Gebaudeplan.aspx/GetDoorsAssignedReader",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            doorAssignedReader = result.d;
        }
    });
}
function SetReaderAssignedStatus(obj, readerDescription, readerDirection, ReaderAssigned, ReaderStatus, AccessProfile, SwitchProfile, ManualOpening) {
    if (obj !== null) {
        var diagram = PlanDiagram;
        diagram.startTransaction("Set readerDesc");
        var readerType = "Keine";
        var readerImg = "";
        var readerDrctn = "";
        var accessImg = "";
        var switchImg = "";
        var inactiveImg = "../../Images/FormImages/bp_red24px.png";
        var activeImg = "../../Images/FormImages/bp_green24px.png";
        var entryImg = "../../Images/FormImages/arrowgreen-02New.png";
        var exitImg = "../../Images/FormImages/arrowred-01New.png";
        var readerAssigned = "0";
        if (ReaderAssigned === true) {
            readerType = readerDescription;
            readerAssigned = "1";
        }
        else {
            readerType = "Keine";
            readerAssigned = "0";
        }
        //reader image
        if (ReaderStatus === true) {
            readerImg = activeImg;
        }
        else {
            readerImg = inactiveImg;
        }
        //reader direction image
        if (readerDirection === 0 && ReaderAssigned === true) {
            readerDrctn = entryImg;
        }
        else if (readerDirection === 1 && ReaderAssigned === true) {
            readerDrctn = exitImg;
        }
        // access profile image
        if (AccessProfile === true) {
            accessImg = activeImg;
        }
        else {
            accessImg = inactiveImg;
        }
        // switch profile image
        if (SwitchProfile === true) {
            switchImg = activeImg;
        }
        else {
            switchImg = inactiveImg;
        }

        var nodedata = obj.part.data;
        diagram.model.setDataProperty(nodedata, "laserChoice", ReaderStatus);
        diagram.model.setDataProperty(nodedata, "readerAssigned", readerAssigned);
        diagram.model.setDataProperty(nodedata, "ReaderType", readerType);
        diagram.model.setDataProperty(nodedata, "directionImg", readerDrctn);
        diagram.model.setDataProperty(nodedata, "readerStatusImg", readerImg);
        diagram.model.setDataProperty(nodedata, "accessCalenderImg", accessImg);
        diagram.model.setDataProperty(nodedata, "swichTimeImg", switchImg);
        diagram.commitTransaction("Set readerDesc");
    }

}
function AddNewChildNode() {
    addChild(BuildingPlanArea);
}

//delete confirmation
function ConfirmDelete(message) {

    var message = "Sind Sie sicher, dass Sie diesen Gebäudeplan löschen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Achtung</label><button id="promptbtnclose"  onclick="resetBuildingAreaDiv(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg" style=" margin-top:0%;" >' + message + '</div><button id="btnDeleteOk" style="margin-left: 28%; margin-top:0%;"  onclick="DeleteBuildingPlan(); return false;" style=" position: relative;"></button> <button id="btnDeleteCancel"  style=" margin-right: 0px; margin-top:0%"  onclick="resetBuildingAreaDiv()"></button></div></div></div></div>';
    document.getElementById('confirmDelete').innerHTML = box_content;
    getLocalizedText("cancelDeleteBuildinPLan");
    $('#btnDeleteCancel').text(levelCaption);
    getLocalizedText("permitDeleteBuildingPlan");
    $('#btnDeleteOk').text(levelCaption);
}
function resetBuildingAreaDiv() {
    document.getElementById('confirmDelete').innerHTML = "";

}
function resetBuildingAreaDiv2() {
    document.getElementById('confirmDelete').innerHTML = "";
    PlanDiagram.currentTool.stopTool();
}
function DeleteBuildingPlan() {
    resetBuildingAreaDiv();
    var selectval = dpllPlanNr.GetValue();
    PageMethods.DeleteBuildingPlan(selectval);
    $("#txtPlanNr").val(0);
    $("#txtPlanName").val("keine");
    load("{ \"position\": \"-5 -5\",\n  \"model\": { \"class\": \"go.GraphLinksModel\",\n  \"nodeDataArray\": [  ],\n  \"linkDataArray\": [  ]} }");
    dpllPlanNr.PerformCallback();
    dplPlanName.PerformCallback()
    getLocalizedText("Addobject");
    $("#btnAddBuilding").val(levelCaption);
    $("#btnAddBuilding").css("font-size", "12px");
    //$("#dpllPlanNr option:selected").remove();
    //$('#dplPlanName option:selected').remove();
    //$("#dplPlanName").val(0);
    //$("#dpllPlanNr").val(0);

}
function cxcommandDelete() {

    var message = "Sind Sie sicher, dass Sie die Auswahl löschen möchten?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="resetBuildingAreaDiv(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg" style=" margin-top:0%;" >' + message + '</div> <button id="btnDeleteOk" style="margin-left: 31%; margin-top:0%; margin-right:0px;"  onclick="cxcommandDeleteSelection(); return false;" style=" position: relative;"></button><button id="btnDeleteCancel"  style="margin-right: 0px; width:160px; margin-top:0%"  onclick="resetBuildingAreaDiv()"></button></div></div></div></div>';
    document.getElementById('confirmDelete').innerHTML = box_content;
    getLocalizedText("cancelDeleteNode");
    $('#btnDeleteCancel').text(levelCaption);
    getLocalizedText("permitDeleteNode");
    $('#btnDeleteOk').text(levelCaption);

}
function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="resetBuildingAreaDiv(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg" style=" margin-top:0%;">' + message + '</div> <button id="btnOk"  style="margin-left: 15%; width: 210px; margin-right: 0px; margin-top:0%;"  onclick="SaveBuildingPlan()"></button><button id="btnNo" style=" margin-top:0%;"  onclick="CancelOnBackButton()"></button><button id="btnCancel"  onclick="resetBuildingAreaDiv(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('confirmDelete').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}
function PlanNumberExistsPrompt() {
    getLocalizedText("PlanNumberAlreadyInUse");
    var message = levelCaption;
    getLocalizedText("differentNumber");
    var advice = levelCaption;
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBoxPrompt"> ' + message + '<br/> <img src="../../Images/FormImages/greeninfo-01.png" alt="Stop" class="existsPrompt" height="50" width="50" align="right"><br/> <h5>' + message + '</h5> <button id="btnOkPrompt"  onclick="resetBuildingAreaDiv()"></button></div></div></div>';
    document.getElementById('confirmDelete').innerHTML = box_content;
    getLocalizedText("yes");
    $('#btnOkPrompt').text(levelCaption);
}
function SaveBuildingPlan() {
    resetBuildingAreaDiv();
    var tool = undefined;
    var customEditor = document.getElementById("txtEditor");
    if (customEditor !== null) {
        tool = customEditor.textEditingTool;
    }
    else {
        tool = undefined;
    }
    if (tool !== undefined) {
        tool.acceptText(go.TextEditingTool.Tab);
    }
    save();
    window.location.href = "/Index.aspx";
    var buttonMode = $("#btnCancelDel").data("mode");
}
function CancelOnBackButton() {
    resetBuildingAreaDiv();
    window.location.href = "/Index.aspx";
}
function ChangeReaderStatus(obj, readerStatus) {
    if (obj !== null) {
        var diagram = PlanDiagram;
        diagram.startTransaction("reader status");
        var statusImage = "";
        var inactiveImg = "../../Images/FormImages/bp_red24px.png";
        var activeImg = "../../Images/FormImages/bp_green24px.png";


        // reader status image
        if (readerStatus === true) {
            statusImage = activeImg;
        }
        else {
            statusImage = inactiveImg;
        }

        var nodedata = obj.part.data;
        diagram.model.setDataProperty(nodedata, "readerStatusImg", statusImage);
        diagram.commitTransaction("reader status");
    }

}
function ActivateDeactivateReader(readerStatus) {
    var buildingPlanId = dpllPlanNr.GetValue();
    var diagram = PlanDiagram;
    var obj = diagram.toolManager.contextMenuTool.currentObject;
    var doorID = obj.part.data.key;
    var active = readerStatus;
    var diagram = PlanDiagram;
    var data = { buildingPlanId: buildingPlanId, doorID: doorID, active: active };

    $.ajax({
        type: "POST",
        async: false,
        url: "Gebaudeplan.aspx/ActivateDeactivateReaders",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function () {
            ChangeReaderStatus(obj, readerStatus);
        }
    });
}
function HideShowLocation(visible) {
    if (dpllPlanNr.GetValue() !== "0") {
        var _location = PlanDiagram.findNodesByExample({ level: "1" }).first();
        _location.visible = visible;
    }

}
function HideShowBuilding(visible) {
    if (dpllPlanNr.GetValue() !== "0") {
        var _buildings = PlanDiagram.findNodesByExample({ level: "2" });

        allBuildings = [];
        while (_buildings.next()) {
            var building = _buildings.value;
            allBuildings.push(building);
        }
        $.each(allBuildings, function () {
            this.visible = visible;
        });
    }
}
function setCheckboxStates() {

    if ($("#chkHideLocation")[0].checked) {
        ASPxClientUtils.DeleteCookie("Loc_State");

        ASPxClientUtils.SetCookie("Loc_State", "1", (moment(Date(Date.now)).add(1, 'year'))["_d"]);
    }
    else if (!$("#chkHideLocation")[0].checked) {
        ASPxClientUtils.DeleteCookie("Loc_State");

        ASPxClientUtils.SetCookie("Loc_State", "0", (moment(Date(Date.now)).add(1, 'year'))["_d"]);
    }

    if ($("#chkHideLocBuilding")[0].checked) {
        ASPxClientUtils.DeleteCookie("LocBUL_State");

        ASPxClientUtils.SetCookie("LocBUL_State", "1", (moment(Date(Date.now)).add(1, 'year'))["_d"]);
    }
    else if (!$("#chkHideLocBuilding")[0].checked) {
        ASPxClientUtils.DeleteCookie("LocBUL_State");

        ASPxClientUtils.SetCookie("LocBUL_State", "0", (moment(Date(Date.now)).add(1, 'year'))["_d"]);
    }
}
function setCheckBoxMode() {
    if (ASPxClientUtils.GetCookie("Loc_State") === "1") {
        $('#chkHideLocation').prop('checked', true);
    }
    else {
        $('#chkHideLocation').prop('checked', false);
    }
    if (ASPxClientUtils.GetCookie("LocBUL_State") === "1") {
        $('#chkHideLocBuilding').prop('checked', true);
    }
    else {
        $('#chkHideLocBuilding').prop('checked', false);
    }

}
function HideShowNodesOnLoad() {
    var planNode = 0;
    if ($('#chkHideLocation').is(':checked')) {
        planNode = 1;
    }
    if ($('#chkHideLocBuilding').is(':checked')) {
        planNode = 2;
    }
    switch (planNode) {
        case 0:
            var _visibility = true;
            HideShowLocation(_visibility);
            HideShowBuilding(_visibility);
            break;
        case 1:
            var _visibility = false;
            HideShowLocation(_visibility);
            var _buildingVisibility = true;
            HideShowBuilding(_buildingVisibility);
            break;
        case 2:
            var _visibility = false;
            HideShowLocation(_visibility);
            HideShowBuilding(_visibility);
            break;
        default:
            var _visibility = true;
            HideShowLocation(_visibility);
            HideShowBuilding(_visibility);
            break;
    }
}
function CheckIfPlanNrExists(PlanNumber) {
    var data = { number: PlanNumber };
    var exists = false;
    $.ajax({
        type: "POST",
        async: false,
        url: "Gebaudeplan.aspx/CheckIfPlanNrExists",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            exists = result.d;
        }
    });
    return exists;
}
//term config
function BackButtonConfirmTermConfig() {

    getLocalizedText("saveChangesConfirmation");
    var message = levelCaption;
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox">  <img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"> <br/>' + message + '<br/> <button id="btnOk"  onclick="SaveBuildingPlanTermConfig()"></button><button id="btnNo"  onclick="CancelOnBackButtonTermConfig()"></button><button id="btnCancel"  onclick="resetBuildingAreaDiv()"></button></div></div></div>';
    document.getElementById('confirmDelete').innerHTML = box_content;
    getLocalizedText("yes");
    $('#btnOk').text(levelCaption);
    getLocalizedText("no");
    $('#btnNo').text(levelCaption);
    getLocalizedText("cancel");
    $('#btnCancel').text(levelCaption);
}
function SaveBuildingPlanTermConfig() {
    resetBuildingAreaDiv();
    var tool = undefined;
    var customEditor = document.getElementById("txtEditor");
    if (customEditor !== null) {
        tool = customEditor.textEditingTool;
    }
    else {
        tool = undefined;
    }
    if (tool !== undefined) {
        tool.acceptText(go.TextEditingTool.Tab);
    }
    save();
    //RedirectToTermConfig();
    PageMethods.RedirectTotermConfig(function () { });
}
//function RedirectToTermConfig() {
//    $.ajax({
//        type: "POST",
//        async: false,
//        url: "Gebaudeplan.aspx/RedirectTotermConfig",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function() {

//        }
//    });

//}
function CancelOnBackButtonTermConfig() {
    resetBuildingAreaDiv();
    RedirectToTermConfig();
}
//end term config

function dplPlanNameSelectedIndexChanged(s, e) {
    if (_isDplClick === true) {
        _isDplClick = false;
        dpllPlanNr.SetValue(s.GetValue());
        $("#txtPlanNr").val(dpllPlanNr.GetText());
        $("#txtPlanName").val(s.GetText());
        if ($("#txtPlanNr").val().trim() !== "" || $("#txtPlanNr").val().trim() !== "0") {
            if (allowZUTEdit) $("#btnEdit").removeAttr("disabled");
            if (allowZUTEdit) $("#btnCancelDel").removeAttr("disabled");
            PageMethods.GetBuildingPlan(s.GetValue(), GetBuildingPlan_Callback);

        } else {
            $("#btnCancelDel").attr("disabled", "disabled");
            $("#btnEdit").attr("disabled", "disabled");
            load("{ \"position\": \"-5 -5\",\n  \"model\": { \"class\": \"go.GraphLinksModel\",\n  \"nodeDataArray\": [  ],\n  \"linkDataArray\": [  ]} }");
        }
    }

}
function dpllPlanNrSelectedIndexChanged(s, e) {
    if (_isDplClick === true) {
        _isDplClick = false;
        dplPlanName.SetValue(s.GetValue());
        $("#txtPlanNr").val(s.GetText());
        $("#txtPlanName").val(dplPlanName.GetText());
        if ($("#txtPlanNr").val().trim() !== "" || $("#txtPlanNr").val().trim() !== "0") {
            if (allowZUTEdit) $("#btnEdit").removeAttr("disabled");
            if (allowZUTEdit) $("#btnCancelDel").removeAttr("disabled");
            PageMethods.GetBuildingPlan(s.GetValue(), GetBuildingPlan_Callback);

        } else {
            $("#btnCancelDel").attr("disabled", "disabled");
            $("#btnEdit").attr("disabled", "disabled");
            load("{ \"position\": \"-5 -5\",\n  \"model\": { \"class\": \"go.GraphLinksModel\",\n  \"nodeDataArray\": [  ],\n  \"linkDataArray\": [  ]} }");
        }
    }

}
function dplClick(s, e) {
    _isDplClick = true;
}
function dpllPlanNrInit(s, e) {
    GetPlanID();
    var buildingPlanId = PlanId;
    if (buildingPlanId != null && buildingPlanId > 0) {
        dpllPlanNr.SetValue(buildingPlanId.toString());

    }
}
function dplPlanNameInit(s, e) {
    GetPlanID();
    var buildingPlanId = PlanId;
    if (buildingPlanId != null && buildingPlanId > 0) {
        dplPlanName.SetValue(buildingPlanId.toString());

    }
}