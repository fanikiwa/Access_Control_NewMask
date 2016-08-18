var BuildingPlanArea;
var levelCaption = "";
var accessCalenderAssigned = false;
var switchCalenderAssigned = false;
var doorList = null;
var doorAssignedReader = null;
var readerType = null;
var editMode = false;
var _PassBackNr = 0;
var _assignedPassBackNr = 0;
var saveChanges = false;
var _comeGoValues = null;
var PlanId = 0;
function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanReader.aspx/GetLocalizedText",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            levelCaption = result.d;
        }
    });
}

$(function () {
    getLocalizedText("readerSelection")
    $('#PageTitleLbl2').text(levelCaption);

    BuildingPlanArea = CreatePlan("BuildingAreaDiv");
    init();
    setCheckBoxMode();

    loadAssignedBuildingPlan();

    EnableDisableControls();
    SetControlsOnLoad();
    getLocalizedText("terminalInfo")
    $('#terminalInfo').text(levelCaption);
    getLocalizedText("conclude");
    $('#conclude').text(levelCaption);
    getLocalizedText("close");
    $('#close').text(levelCaption);
    getLocalizedText("antiPassBackFunction");
    $('#PassBack').text(levelCaption);

    $("#btnInformation").click(function (evt) {
        evt.preventDefault();

    });
    $('#btnBack').click(function (evt) {
        evt.preventDefault();
        if (saveChanges == true) {
            var initialPlan = parseInt($("#hiddenFieldInitialPlan").val());
            var currentPlan = parseInt(dpllPlanNr.GetValue());
            if (initialPlan !== currentPlan && allowZUTEdit) {
                BackButtonConfirm();
            }
            else {
                window.location.href = "/Content/AccessPlan.aspx";
            }

        }
        else {
            window.location.href = "/Content/AccessPlan.aspx";
        }
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
            } else {

                saveChanges = false;
                PageMethods.EditAccessPlan($("#ddlAccessProfileNumber option:selected").val(), dpllPlanNr.GetValue())
                //SetControlsOnLoad();
            }

            BuildNavMenus();
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

    $("#btnFullScreenMode").css("background-image", "url('../../Images/FormImages/maximize.png')");
    $("#btnFullScreenMode").click(function (evt) {
        //DOM Loaded
        var headerStatus = $("#MainHeader").css("display");

        //Do not postback
        evt.preventDefault();

        $("#btnFullScreenMode").text = "Standard";
        $("#btnFullScreenMode").css("background-image", "url('../../Images/FormImages/minimize.png')");

        screenMode(headerStatus);

    });

    $("#chkTerminal").click(function () {
        if ($("#chkTerminal")[0].checked === true) {
            var isActive = true;
            ActivateDeactivateAccessProfile(isActive);

        }
        else if ($("#chkTerminal")[0].checked === false) {
            var isActive = false;
            ActivateDeactivateAccessProfile(isActive);

        }
    });
    $("#chkFirstReader").click(function () {
        if ($("#chkFirstReader")[0].checked === true) {
            $('#chkSecondReader').prop('checked', false);
            $('#chkNothing').prop('checked', false);
            var number = 1
            AssignPassBackNr(number);
        }
        else if ($("#chkFirstReader")[0].checked === false) {
            var number = 0
            AssignPassBackNr(number);

        }
    });
    $("#chkSecondReader").click(function () {
        if ($("#chkSecondReader")[0].checked === true) {
            $('#chkFirstReader').prop('checked', false);
            $('#chkNothing').prop('checked', false);
            var number = 2
            AssignPassBackNr(number);
        }
        else if ($("#chkSecondReader")[0].checked === false) {
            var number = 0
            AssignPassBackNr(number);
        }
    });
    $("#chkNothing").click(function () {
        if ($("#chkNothing")[0].checked === true) {
            $('#chkFirstReader').prop('checked', false);
            $('#chkSecondReader').prop('checked', false);
            var number = 0
            AssignPassBackNr(number);
        }
        else if ($("#chkNothing")[0].checked === false) {
            var number = 0
            AssignPassBackNr(number);
        }
    });
    $("#chkTA_Go").click(function () {
        if ($("#chkTA_Go")[0].checked === true) {
            $('#chkTA_Come').prop('checked', false);

            UpdateComeGoValue($("#chkTA_Come")[0].checked, $("#chkTA_Go")[0].checked);
        }
        else if ($("#chkTA_Go")[0].checked === false) {
            UpdateComeGoValue($("#chkTA_Come")[0].checked, $("#chkTA_Go")[0].checked);
        }
    });
    $("#chkTA_Come").click(function () {
        if ($("#chkTA_Come")[0].checked === true) {
            $('#chkTA_Go').prop('checked', false);

            UpdateComeGoValue($("#chkTA_Come")[0].checked, $("#chkTA_Go")[0].checked);
        }
        else if ($("#chkTA_Come")[0].checked === false) {
            UpdateComeGoValue($("#chkTA_Come")[0].checked, $("#chkTA_Go")[0].checked);
        }
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
        $("#MainContentAreaDiv").css("height", "98%");
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
    //bind check boxes
    $("#txtPlanNr").val(response.PlanNr.toString());
    $("#txtPlanName").val(response.PlanName.toString());

    accessCalenderAssigned = result.accessCalendar;
    //CheckIfAccessCalendarAssigned(response.ID);
    var accessAssigned = accessCalenderAssigned;

    switchCalenderAssigned = result.switchCalendar;
    //CheckIfSwitchCalendarAssigned(response.ID);
    var switchAssigned = switchCalenderAssigned;

    doorList = result.doorList;
    //GetDoorsList(response.ID);

    var doors = doorList;
    for (i = 0; i < doors.length; i++) {
        var doorNode = doors[i];
        var nodeKey = parseInt(doorNode.Key);
        var doorObject = PlanDiagram.findNodeForKey(nodeKey);
        SetDefaultProperty(doorObject);
    }

    doorAssignedReader = result.doorsAssignedList;
    //GetDoorsAssignedReader(response.ID, $("#ddlAccessProfileNumber option:selected").val());

    var doorAssignedReaderList = doorAssignedReader;
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
        var AccessPlanStatus = doorNode.accessPlanReaderStatus;
        var passBackNr = doorNode.passBackNr;
        var doorObject = PlanDiagram.findNodeForKey(nodeKey);
        SetReaderAssignedStatus(doorObject, readerDesc, readerDirection, ReaderAssigned, ReaderStatus, AccessProfile, SwitchProfile, ManualOpening, AccessPlanStatus, passBackNr);
    }
    HideShowNodesOnLoad();
}

function SetControlsOnLoad() {
    $("#txtPlanNr").attr("disabled", "disabled");
    $("#txtPlanName").attr("disabled", "disabled");
    $("#btnAddBuilding").attr("disabled", "disabled");
    $("#btnAddLocation").attr("disabled", "disabled");

    $("#txtPlanNr").val(dpllPlanNr.GetText());
    $("#txtPlanName").val(dplPlanName.GetText());

    getLocalizedText("deleteButton");
    $("#btnCancelDel").val(levelCaption);

    $("#btnCancelDel").data("mode", "Löschen");

    $("#btnEdit").removeAttr("disabled");
}

function EnableDisableControls() {
    document.getElementById("btnReader").disabled = true;
    document.getElementById("btnPersonnel").disabled = false;
    document.getElementById("btnAccessProfile").disabled = false;

    document.getElementById("ddlAccessGroupNumber").disabled = true;
    document.getElementById("ddlAccessGroupName").disabled = true;
    document.getElementById("ddlAccessProfileNumber").disabled = true;
    document.getElementById("ddlAccessProfileName").disabled = true;

    document.getElementById("txtAccessGroupNumber").disabled = true;
    document.getElementById("txtAccessGroupName").disabled = true;
    document.getElementById("txtAccessProfileNumber").disabled = true;
    document.getElementById("txtAccessProfileName").disabled = true;


}
function loadAssignedBuildingPlan() {
    var accessProfileId = $("#ddlAccessProfileNumber option:selected").val();
    if (accessProfileId == null) return;
    PageMethods.AccessPlan(accessProfileId, LoadAccessPlan_Callback);
}
function LoadAccessPlan_Callback(response) {
    var buildingPlanID
    if (response.BuildingPlanID == null) {
        buildingPlanID = 0;
    }
    else {
        buildingPlanID = response.BuildingPlanID;
    }
    if (buildingPlanID > 0) {
        //dpllPlanNr.SetValue(buildingPlanID);
        //dplPlanName.SetValue(buildingPlanID);
        //$("#txtPlanNr").val(dpllPlanNr.GetText());
        //$("#txtPlanName").val(dplPlanName.GetText());
        PageMethods.GetBuildingPlan(buildingPlanID,$("#ddlAccessProfileNumber option:selected").val(), GetBuildingPlan_Callback);
    }
    else {
        load("{ \"position\": \"-5 -5\",\n  \"model\": { \"class\": \"go.GraphLinksModel\",\n  \"nodeDataArray\": [  ],\n  \"linkDataArray\": [  ]} }");
    }

}
$(document).ready(function () {
    $(".InfoHeaderFloatRight").show();
    $(".InfoHeaderFloatRightnew").hide();
})
function CheckIfAccessCalendarAssigned(buildingPlanId) {
    var data = { buildingPlanId: buildingPlanId };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanReader.aspx/CheckIfAccessCalendarAssigned",
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
        url: "AccessPlanReader.aspx/CheckIfSwitchCalendarAssigned",
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
        url: "AccessPlanReader.aspx/GetDoorsList",
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
        var accessPlanImg = "../../Images/FormImages/ClosedDoorRed.png";
        var pass_BackImg = "../../Images/FormImages/passBack_0.jpg";
        var diagram = PlanDiagram;
        diagram.startTransaction("Set default");
        var nodedata = obj.part.data;
        //set default image
        diagram.model.setDataProperty(nodedata, "accessPlanImg", accessPlanImg);
        diagram.model.setDataProperty(nodedata, "directionImg", readerDrctn);
        diagram.model.setDataProperty(nodedata, "readerStatusImg", readerImg);
        diagram.model.setDataProperty(nodedata, "passBackImg", pass_BackImg);
        diagram.commitTransaction("Set default");
    }
}
function GetDoorsAssignedReader(buildingPlanId, accessPLanId) {
    var data = { buildingPlanId: buildingPlanId, acccessPlanId: accessPLanId };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanReader.aspx/GetDoorsAssignedReader",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            doorAssignedReader = result.d;
        }
    });
}
function SetReaderAssignedStatus(obj, readerDescription, readerDirection, ReaderAssigned, ReaderStatus, AccessProfile, SwitchProfile, ManualOpening, AccessPlanStatus, PassBackNr) {
    if (obj !== null) {
        var diagram = PlanDiagram;
        diagram.startTransaction("Set readerDesc");
        var readerType = "Keine";
        var readerImg = "";
        var readerDrctn = "";
        var accessImg = "";
        var accessPlanImg = "";
        var accessPlanActiveDooorImg = "../../Images/FormImages/OpenDoorGreen.png";
        var accessPlanInActiveDooorImg = "../../Images/FormImages/ClosedDoorRed.png";
        var switchImg = "";
        var inactiveImg = "../../Images/FormImages/bp_red24px.png";
        var activeImg = "../../Images/FormImages/bp_green24px.png";
        var entryImg = "../../Images/FormImages/arrowgreen-02New.png";
        var exitImg = "../../Images/FormImages/arrowred-01New.png";
        var passBackImg_0 = "../../Images/FormImages/passBack_0.jpg";
        var passBackImg_1 = "../../Images/FormImages/passBack_1.jpg";
        var passBackImg_2 = "../../Images/FormImages/passBack_2.jpg";
        var passBackImg = "../../Images/FormImages/passBack_0.jpg";
        if (ReaderAssigned === true) {
            readerType = readerDescription;
        }
        else {
            readerType = "Keine";
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
        // access plan image
        if (AccessPlanStatus === true) {
            accessPlanImg = accessPlanActiveDooorImg;
        }
        else {
            accessPlanImg = accessPlanInActiveDooorImg;
        }
        switch (PassBackNr) {
            case 0:
                passBackImg = passBackImg_0;
                break;
            case 1:
                passBackImg = passBackImg_1;
                break;
            case 2:
                passBackImg = passBackImg_2;
                break;
            default:
                passBackImg = passBackImg_0;
        }
        var nodedata = obj.part.data;
        diagram.model.setDataProperty(nodedata, "laserChoice", ReaderStatus);
        diagram.model.setDataProperty(nodedata, "ReaderType", readerType);
        diagram.model.setDataProperty(nodedata, "directionImg", readerDrctn);
        diagram.model.setDataProperty(nodedata, "readerStatusImg", readerImg);
        diagram.model.setDataProperty(nodedata, "accessCalenderImg", accessImg);
        diagram.model.setDataProperty(nodedata, "swichTimeImg", switchImg);
        diagram.model.setDataProperty(nodedata, "accessPlanImg", accessPlanImg);
        diagram.model.setDataProperty(nodedata, "passBackImg", passBackImg);
        diagram.commitTransaction("Set readerDesc");
    }
}
function ShowPassBackMenus() {
    $("#lblpassBack").show();
    $("#passBackLine").show();
    $("#readerOne").show();
    $("#readerOneLine").show();
    $("#readerTwo").show();
    $("#readerTwoLine").show();
    $("#nothing").show();
    $("#nothingLine").show();
    $("#closeMenuTwo").show();
    //hide other menus
    $("#entriesMenu").hide();
    $("#entriesLine").hide();
    $("#readerMenu").hide();
    $("#readerLine").hide();
    $("#comeMenu").hide();
    $("#comeMenuLine").hide();
    $("#goMenu").hide();
    $("#goMenLine").hide();
    $("#passBackMenu").hide();
    $("#passBackLineMenu").hide();
    $("#closeMenu").hide();
    $("#closeLine").hide();
    $("#lblInfo").hide();
    $("#infoLine").hide();
    $("#terminalMenu").hide();
    //PlanDiagram.currentContextMenu = contextmenu;
    ShowSecondMenu();

}
function HidePassBackMenus() {
    $("#lblpassBack").hide();
    $("#passBackLine").hide();
    $("#readerOne").hide();
    $("#readerOneLine").hide();
    $("#readerTwo").hide();
    $("#readerTwoLine").hide();
    $("#nothing").hide();
    $("#nothingLine").hide();
    $("#closeMenuTwo").hide();
    //show other menus
    $("#entriesMenu").show();
    $("#entriesLine").show();
    $("#readerMenu").show();
    $("#readerLine").show();
    $("#comeMenu").show();
    $("#comeMenuLine").show();
    $("#goMenu").show();
    $("#goMenLine").show();
    $("#passBackMenu").show();
    $("#passBackLineMenu").show();
    $("#closeMenu").show();
    $("#closeLine").show();
    $("#lblInfo").show();
    $("#infoLine").show();
    $("#terminalMenu").show();
}
function PassBackMenu() {
    ShowPassBackMenus();
}
function CheckPassBackNr(buildingPlanId, doorID) {
    var data = { buildingPlanId: buildingPlanId, doorID: doorID };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanReader.aspx/CheckPassBackNr",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            _PassBackNr = result.d;
        }
    });
}
function ShowSecondMenu() {
    PlanDiagram.currentTool.stopTool();
    var cxTool = PlanDiagram.toolManager.contextMenuTool;
    var contextmenu = PlanDiagram.contextmenu;
    var cxElement = document.getElementById("contextMenu");
    var obj = PlanDiagram.selection.iterator.first();

    var diagram = PlanDiagram;
    if (diagram === null) return;

    // Hide any other existing context menu
    if (contextmenu !== diagram.currentContextMenu) {
        diagram.hideContextMenu();
    }

    // Show only the relevant buttons given the current state.
    if (obj !== null) {
        if (obj.data.level === "5") {


            // Now show the whole context menu element
            cxElement.style.display = "block";
            // we don't bother overriding positionContextMenu, we just do it here:
            var obj = PlanDiagram.selection.iterator.first();
            var objPosition = obj.actualBounds;
            var rightPost = parseInt(objPosition.right);

            var position = obj.part.location
            var docloc = diagram.transformDocToView(position);
            //var posX = parseInt(docloc.x.toFixed(2));
            var posX = parseInt(docloc.x);


            var mousePt = diagram.lastInput.viewPoint;
            var ctxmenuposx = parseInt($("#BuildingAreaDiv").position().left) + parseInt(mousePt.x);
            var ctxmenuposy = parseInt($("#BuildingAreaDiv").position().top) + parseInt(mousePt.y);
            cxElement.style.left = (posX + 615) + "px";
            //cxElement.style.left = (ctxmenuposx+200) + "px";
            cxElement.style.top = ctxmenuposy + "px";

            // Remember that there is now a context menu showing
            diagram.currentContextMenu = contextmenu;
        }
        else {
            // Now show the whole context menu element
            cxElement.style.display = "block";
            // we don't bother overriding positionContextMenu, we just do it here:
            var mousePt = diagram.lastInput.viewPoint;
            var ctxmenuposx = parseInt($("#BuildingAreaDiv").position().left) + parseInt(mousePt.x);
            var ctxmenuposy = parseInt($("#BuildingAreaDiv").position().top) + parseInt(mousePt.y);
            cxElement.style.left = ctxmenuposx + "px";
            cxElement.style.top = ctxmenuposy + "px";

            // Remember that there is now a context menu showing
            diagram.currentContextMenu = contextmenu;
        }
    }
    else {

        cxElement.style.display = "none";
        diagram.currentContextMenu = contextmenu;

    }
}
function CloseMenuTwo() {
    var diagram = PlanDiagram;
    var cxElement = document.getElementById("contextMenu");
    cxElement.style.display = "none";
    //diagram.currentContextMenu = contextmenu;
}
function AssignPassBackNr(passBackNumber) {
    var diagram = PlanDiagram;
    var obj = PlanDiagram.selection.iterator.first();
    var buildingPlanId = dpllPlanNr.GetValue();
    var pasBack_Nr = passBackNumber;
    if (obj !== null) {
        var doorID = obj.data.key;
        var data = { buildingPlanId: buildingPlanId, doorID: doorID, passBackNr: pasBack_Nr };

        $.ajax({
            type: "POST",
            async: false,
            url: "AccessPlanReader.aspx/AssignPassBackNr",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(data),
            success: function (result) {
                updatePassBackNodeImage(pasBack_Nr, obj);
            }
        });
    }
}
function updatePassBackNodeImage(PassBackNr, obj) {
    if (obj !== null) {
        var diagram = PlanDiagram;
        diagram.startTransaction("passback number");
        var passBackImg_0 = "../../Images/FormImages/passBack_0.jpg";
        var passBackImg_1 = "../../Images/FormImages/passBack_1.jpg";
        var passBackImg_2 = "../../Images/FormImages/passBack_2.jpg";
        var passBackImg = "../../Images/FormImages/passBack_0.jpg";
        switch (PassBackNr) {
            case 0:
                passBackImg = passBackImg_0;
                break;
            case 1:
                passBackImg = passBackImg_1;
                break;
            case 2:
                passBackImg = passBackImg_2;
                break;
            default:
                passBackImg = passBackImg_0;
        }
        var nodedata = obj.part.data;
        diagram.model.setDataProperty(nodedata, "passBackImg", passBackImg);
        diagram.commitTransaction("passback number");
    }
}
function CheckAssignedPassBackNr(buildingPlanId, doorID) {
    var data = { buildingPlanId: buildingPlanId, doorID: doorID };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanReader.aspx/CheckAssignedPassBackNr",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            _assignedPassBackNr = result.d;
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
        ASPxClientUtils.DeleteCookie("APLoc_State");

        ASPxClientUtils.SetCookie("APLoc_State", "1", (moment(Date(Date.now)).add(1, 'year'))["_d"]);
    }
    else if (!$("#chkHideLocation")[0].checked) {
        ASPxClientUtils.DeleteCookie("APLoc_State");

        ASPxClientUtils.SetCookie("APLoc_State", "0", (moment(Date(Date.now)).add(1, 'year'))["_d"]);
    }

    if ($("#chkHideLocBuilding")[0].checked) {
        ASPxClientUtils.DeleteCookie("APLocBUL_State");

        ASPxClientUtils.SetCookie("APLocBUL_State", "1", (moment(Date(Date.now)).add(1, 'year'))["_d"]);
    }
    else if (!$("#chkHideLocBuilding")[0].checked) {
        ASPxClientUtils.DeleteCookie("APLocBUL_State");

        ASPxClientUtils.SetCookie("APLocBUL_State", "0", (moment(Date(Date.now)).add(1, 'year'))["_d"]);
    }
}
function setCheckBoxMode() {
    if (ASPxClientUtils.GetCookie("APLoc_State") === "1") {
        $('#chkHideLocation').prop('checked', true);
    }
    else {
        $('#chkHideLocation').prop('checked', false);
    }
    if (ASPxClientUtils.GetCookie("APLocBUL_State") === "1") {
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
function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="CancelOnBackButton(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 35%;width: 130px; margin-right: 0px;"  onclick="SaveAccesPlan()"></button><button id="btnNo" style="margin-left: 10px;width: 160px;"  onclick="No_OnBack()"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}
function SaveAccesPlan() {
    resetWindow();
    saveAcessPlan();

}
function resetWindow() {
    document.getElementById('importantDialog').innerHTML = "";
}
function No_OnBack() {
    resetWindow();
    window.location.href = "/Content/AccessPlan.aspx";
}
function saveAcessPlan() {
    if ($("#txtPlanNr").val().trim() === "" || $("#txtPlanNr").val().trim() === "0") {

        getLocalizedText("noSelection");

        alert(levelCaption);
    } else if ($("#txtPlanName").val().trim() === "" || $("#txtPlanNr").val().trim() === "keine") {

        getLocalizedText("noSelection");

        alert(levelCaption);
    } else {

        saveChanges = false;
        PageMethods.EditAccessPlan($("#ddlAccessProfileNumber option:selected").val(), dpllPlanNr.GetValue(), OnSaveCallBack)

    }
}
function CancelOnBackButton() {
    resetWindow();
}
function OnSaveCallBack() {
    window.location.href = "/Content/AccessPlan.aspx";
}
function UpdateComeGoValue(taCome, taGo) {
    var diagram = PlanDiagram;
    var obj = PlanDiagram.selection.iterator.first();
    var buildingPlanId = dpllPlanNr.GetValue();
    if (obj !== null) {
        var doorID = obj.data.key;
        var data = { buildingPlanId: buildingPlanId, doorID: doorID, _TA_Come: taCome, _TA_Go: taGo };

        $.ajax({
            type: "POST",
            async: false,
            url: "AccessPlanReader.aspx/AssignComeGoValue",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(data),
            success: function (result) {

            }
        });
    }
}
function GetComeGoValues(buildingPlanId, doorID) {
    var data = { buildingPlanId: buildingPlanId, doorID: doorID };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanReader.aspx/GetComeGoValues",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            _comeGoValues = result.d;
        }
    });
}

function planSelectedChanged(s, e) {
    dplPlanName.SetValue(s.GetValue());
    dpllPlanNr.SetValue(s.GetValue());
    $("#txtPlanNr").val(dpllPlanNr.GetText());
    $("#txtPlanName").val(dplPlanName.GetText());
    if ($("#txtPlanNr").val().trim() !== "" || $("#txtPlanNr").val().trim() !== "0") {
        PageMethods.GetBuildingPlan(s.GetValue(),$("#ddlAccessProfileNumber option:selected").val(), GetBuildingPlan_Callback);
        saveChanges = true;
    } else {
        load("{ \"position\": \"-5 -5\",\n  \"model\": { \"class\": \"go.GraphLinksModel\",\n  \"nodeDataArray\": [  ],\n  \"linkDataArray\": [  ]} }");

    }
}

function dpllPlanNrInit(s, e) {
    var id = $("#ddlAccessProfileNumber option:selected").val();
    PageMethods.GetBuildinPlanId(id, GetBuildinPlanId_CallBack);
}
function dplPlanNameInit(s, e) {
    var id = $("#ddlAccessProfileNumber option:selected").val();
    PageMethods.GetBuildinPlanId(id, GetBuildinPlanId_CallBack);

}
function GetBuildinPlanId_CallBack(id) {
    if (id > 0) {
        dpllPlanNr.SetValue(id.toString());
        dplPlanName.SetValue(id.toString());
        $("#hiddenFieldInitialPlan").attr("value", id.toString());
    }
}