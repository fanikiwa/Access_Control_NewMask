
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
var selectedDoors = [];
var backValue = 0;
var doorAssignedGroup = null;
var saveChanges = false;
function getLocalizedText(key) {
    var data = { key: key };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanGroupReader.aspx/GetLocalizedText",
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

    LoadExistingBuildingPlan(cobBuildingPlanLocation.GetValue());

    setTimeout(function () {
        grdBuildingPlanGrid.PerformCallback();
    }, 1);

    getLocalizedText("terminalInfo")
    $('#terminalInfo').text(levelCaption);
    getLocalizedText("conclude");
    $('#conclude').text(levelCaption);
    getLocalizedText("close");
    $('#close').text(levelCaption);
    getLocalizedText("antiPassBackFunction");
    $('#PassBack').text(levelCaption);
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
    $('#btnActHelp').click(
     function (evt) {
         evt.preventDefault();


     });
    $('#btnSaveSelectionDiagram').click(
      function (evt) {
          evt.preventDefault();
          GetSelectedDoors();
          var buldingPlanId = cobBuildingPlanLocation.GetValue();
          var groupId = cobAccessGroupNr.GetValue();
          if (parseInt(buldingPlanId) > 0) {
              PageMethods.MapAccessPlanGroupDoor(groupId, buldingPlanId, selectedDoors, MapAccessPlanGroupDoor_CallBack);
          }
      });
    $('#btnSelectAllDiagram').click(
      function (evt) {
          evt.preventDefault();
          var buldingPlanId = cobBuildingPlanLocation.GetValue();
          if (parseInt(buldingPlanId) > 0) {
              SelectAllDoors();
          }

      });
    $('#btnDeleteSeldctionDiagram').click(
     function (evt) {
         evt.preventDefault();
         var buldingPlanId = cobBuildingPlanLocation.GetValue();
         if (parseInt(buldingPlanId) > 0) {
             ConfirmDeleteSelection();
         }

     });
    $('#btnSaveSelectionGrid').click(
     function (evt) {
         evt.preventDefault();

         if (!isNaN(parseInt(cobAccessGroupNr.GetValue())) && parseInt(cobAccessGroupNr.GetValue()) > 0) {
             PageMethods.SaveAccessGroupGrid(JSON.stringify(GetAccessGroupGridUpdateValues()), cobAccessGroupNr.GetValue(), function (resp) {
                 grdBuildingPlanGrid.PerformCallback();
                 var buildingPlanId = parseInt(cobBuildingPlanLocation.GetValue());

                 if (buildingPlanId > 0) {

                     LoadExistingBuildingPlan(buildingPlanId);
                 }
                 else {
                     load("{ \"position\": \"-5 -5\",\n  \"model\": { \"class\": \"go.GraphLinksModel\",\n  \"nodeDataArray\": [  ],\n  \"linkDataArray\": [  ]} }");
                 }
             }, function (err) {
                 console.log(err);
             });
         }
     });
    $('#btnSelectAllGrid').click(
     function (evt) {
         evt.preventDefault();
         AllAccessGroupGridSelection();

     });
    $('#btnDeleteSeldctionGrid').click(
     function (evt) {
         evt.preventDefault();
         setTimeout(function () { RemoveAccessGroupGridSelection(); }, 1);
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

    $("#btnBack").click(function (evt) {
        evt.preventDefault();
        if (backValue === 0) {
            if (saveChanges === true && allowZUTEdit) {
                BackButtonConfirm();
            }
            else {
                document.location.href = "/Content/AccessPlanGroup.aspx";
            }

        } else if (backValue === 1) {
            showDiagram();
            backValue = 0;
        }

    });

    $("#btnShowGrid").click(function (evt) {
        evt.preventDefault();
        backValue = 1;
        showGrid();
    });

    $("#btnShowDiagram").click(function (evt) {
        evt.preventDefault();
        backValue = 0;
        showDiagram();
    });
});


function GetBuildingPlan_Callback(result) {
    var response = result.BuildingPlan;
    load(response);
    //bind check boxes
    //CheckIfAccessCalendarAssigned(cobBuildingPlanLocation.GetValue());
    //var accessAssigned = accessCalenderAssigned;
    //CheckIfSwitchCalendarAssigned(cobBuildingPlanLocation.GetValue());
    //var switchAssigned = switchCalenderAssigned;

    //GetDoorsList(response.ID);
    doorList = result.doorList;

    var doors = doorList;
    for (i = 0; i < doors.length; i++) {
        var doorNode = doors[i];
        var nodeKey = parseInt(doorNode.Key);
        var doorObject = PlanDiagram.findNodeForKey(nodeKey);
        SetDefaultProperty(doorObject);
    }

    doorAssignedReader = result.doorAssignedReader;

    //GetDoorsAssignedReader(response.ID);
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
        var doorObject = PlanDiagram.findNodeForKey(nodeKey);
        SetReaderAssignedStatus(doorObject, readerDesc, readerDirection, ReaderAssigned, ReaderStatus, AccessProfile, SwitchProfile, ManualOpening);
    }

    //group assigned
    //GetDoorsAssignedGroup(cobAccessGroupNr.GetValue(), response.ID);
    doorAssignedGroup = result.doorAssignedGroup;

    var doorAssignedGroupList = doorAssignedGroup;
    for (y = 0; y < doorAssignedGroupList.length; y++) {
        var groupStatus = true;
        var doorNode = doorAssignedGroupList[y];
        var nodeKey = parseInt(doorNode.DoorId);
        var doorObject = PlanDiagram.findNodeForKey(nodeKey);
        SetReaderGroupStatus(doorObject, groupStatus);
    }
    HideShowNodesOnLoad();
}
function loadAssignedBuildingPlan() {
    var visitorProfileId = getParameterByName("profileId");
    if (visitorProfileId == null) return;
    PageMethods.VisitorPlan(visitorProfileId, LoadVisitorPlan_Callback);
}
function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}
function LoadVisitorPlan_Callback(response) {
    var buildingPlanID
    if (response.BuildingPlanID == null) {
        buildingPlanID = 0;
    }
    else {
        buildingPlanID = response.BuildingPlanID;
    }
    if (buildingPlanID > 0) {

        PageMethods.GetBuildingPlan(cobAccessGroupNr.GetValue(),buildingPlanID, GetBuildingPlan_Callback);
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
        url: "AccessPlanGroupReader.aspx/CheckIfAccessCalendarAssigned",
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
        url: "AccessPlanGroupReader.aspx/CheckIfSwitchCalendarAssigned",
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
        url: "AccessPlanGroupReader.aspx/GetDoorsList",
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
        var isSelected = false;
        var diagram = PlanDiagram;
        diagram.startTransaction("Set default");
        var nodedata = obj.part.data;
        //set default image
        diagram.model.setDataProperty(nodedata, "directionImg", readerDrctn);
        diagram.model.setDataProperty(nodedata, "readerStatusImg", readerImg);
        diagram.model.setDataProperty(nodedata, "groupChoice", isSelected);
        diagram.commitTransaction("Set default");
    }
}
function GetDoorsAssignedReader(buildingPlanId) {
    var data = { buildingPlanId: buildingPlanId };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanGroupReader.aspx/GetDoorsAssignedReader",
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
        url: "AccessPlanGroupReader.aspx/CheckPassBackNr",
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
    var buildingPlanId = cobBuildingPlanLocation.GetValue();
    var pasBack_Nr = passBackNumber;
    if (obj !== null) {
        var doorID = obj.data.key;
        var data = { buildingPlanId: buildingPlanId, doorID: doorID, passBackNr: pasBack_Nr };

        $.ajax({
            type: "POST",
            async: false,
            url: "AccessPlanGroupReader.aspx/AssignPassBackNr",
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
        url: "AccessPlanGroupReader.aspx/CheckAssignedPassBackNr",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            _assignedPassBackNr = result.d;
        }
    });
}
function HideShowLocation(visible) {
    if (cobBuildingPlanLocation.GetValue() !== "0") {
        var _location = PlanDiagram.findNodesByExample({ level: "1" }).first();
        _location.visible = visible;
    }
}
function HideShowBuilding(visible) {
    if (cobBuildingPlanLocation.GetValue() !== "0") {
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
        ASPxClientUtils.DeleteCookie("GRALoc_State");

        ASPxClientUtils.SetCookie("GRALoc_State", "1", (moment(Date(Date.now)).add(1, 'year'))["_d"]);
    }
    else if (!$("#chkHideLocation")[0].checked) {
        ASPxClientUtils.DeleteCookie("GRALoc_State");

        ASPxClientUtils.SetCookie("GRALoc_State", "0", (moment(Date(Date.now)).add(1, 'year'))["_d"]);
    }

    if ($("#chkHideLocBuilding")[0].checked) {
        ASPxClientUtils.DeleteCookie("GRALocBUL_State");

        ASPxClientUtils.SetCookie("GRALocBUL_State", "1", (moment(Date(Date.now)).add(1, 'year'))["_d"]);
    }
    else if (!$("#chkHideLocBuilding")[0].checked) {
        ASPxClientUtils.DeleteCookie("GRALocBUL_State");

        ASPxClientUtils.SetCookie("GRALocBUL_State", "0", (moment(Date(Date.now)).add(1, 'year'))["_d"]);
    }
}
function setCheckBoxMode() {
    if (ASPxClientUtils.GetCookie("GRALoc_State") === "1") {
        $('#chkHideLocation').prop('checked', true);
    }
    else {
        $('#chkHideLocation').prop('checked', false);
    }
    if (ASPxClientUtils.GetCookie("GRALocBUL_State") === "1") {
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

function showGrid() {
    $(".rightbottom").hide();
    $(".standontarea").hide();
    $("#btnShowGrid").hide();
    $("#BuildingAreaDiv").hide();
    $("#LblTable").hide();
    $("#btnSaveSelectionDiagram").hide();
    $("#btnSelectAllDiagram").hide();
    $("#btnDeleteSeldctionDiagram").hide();
    $("#btnShowDiagram").show();
    $("#BuildingGridArea").show();
    $("#LblGrafik").show();
    $("#btnSaveSelectionGrid").show();
    $("#btnSelectAllGrid").show();
    $("#btnDeleteSeldctionGrid").show();
}

function showDiagram() {
    $("#btnShowDiagram").hide();
    $("#BuildingGridArea").hide();
    $("#LblGrafik").hide();
    $("#btnSaveSelectionGrid").hide();
    $("#btnSelectAllGrid").hide();
    $("#btnDeleteSeldctionGrid").hide();
    $(".rightbottom").show();
    $(".standontarea").show();
    $("#btnShowGrid").show();
    $("#BuildingAreaDiv").show();
    $("#LblTable").show();
    $("#btnSaveSelectionDiagram").show();
    $("#btnSelectAllDiagram").show();
    $("#btnDeleteSeldctionDiagram").show();
}
function locationSelectedChanged(s, e) {
    if (parseInt(s.GetValue()) > 0) {
        PageMethods.GetBuildingPlans(cobAccessGroupNr.GetValue(),s.GetValue(), GetBuildingPlan_Callback);
    }
    else {
        load("{ \"position\": \"-5 -5\",\n  \"model\": { \"class\": \"go.GraphLinksModel\",\n  \"nodeDataArray\": [  ],\n  \"linkDataArray\": [  ]} }");
    }

    setTimeout(function () {
        grdBuildingPlanGrid.PerformCallback();
    }, 1);
}
function LoadExistingBuildingPlan(Id) {
    if (parseInt(Id) > 0) {
        PageMethods.GetBuildingPlans(cobAccessGroupNr.GetValue(),Id, GetBuildingPlan_Callback);
    }
}
function GetSelectedDoors() {
    if (cobBuildingPlanLocation.GetValue() !== "0") {
        var _doors = PlanDiagram.findNodesByExample({ level: "5" });

        allDoors = [];
        while (_doors.next()) {
            var building = _doors.value;
            allDoors.push(building);
        }
        selectedDoors = [];
        $.each(allDoors, function () {
            if (this.data.groupChoice === true) {
                GetDoorParentValues(this);
            }
        });
    }
}

function GetDoorParentValues(obj) {
    var _DoorId = obj.data.key;
    var _LocationId = 0;
    var _BuildingId = 0;
    var _FloorId = 0;
    var _RoomId = 0;

    var _NodeKey = obj.data.key;
    var level = obj.data.level;
    while (level != "1" && level != "") {
        try {
            var _parentNode = PlanDiagram.findPartForKey(_NodeKey).findNodesInto().iterator.first();
            _NodeKey = _parentNode.data.key;
            level = _parentNode.data.level;
            if (level === "1") {
                _LocationId = _NodeKey;
            } else if (level === "2") {
                _BuildingId = _NodeKey;
            } else if (level === "3") {
                _FloorId = _NodeKey;

            } else if (level === "4") {
                _RoomId = _NodeKey;
            }
        } catch (e) {
            //Error Processing Parent Node
        }
    }
    selectedDoors.push({
        LocationId: _LocationId,
        BuildingId: _BuildingId,
        FloorId: _FloorId,
        RoomId: _RoomId,
        DoorId: _DoorId
    });
}

function MapAccessPlanGroupDoor_CallBack() {
    saveChanges = false;


    setTimeout(function () {
        grdBuildingPlanGrid.PerformCallback();
    }, 1);
}

function GetDoorsAssignedGroup(groupId, buildingPlanId) {
    var data = { groupId: groupId, buildingPlanId: buildingPlanId };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanGroupReader.aspx/GetDoorsAssignedGroup",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            doorAssignedGroup = result.d;
        }
    });
}
function SetReaderGroupStatus(obj, groupStatus) {
    if (obj !== null) {
        var diagram = PlanDiagram;
        diagram.startTransaction("SetGroupChoice");
        var nodedata = obj.part.data;
        diagram.model.setDataProperty(nodedata, "groupChoice", groupStatus);
        diagram.commitTransaction("SetGroupChoice");
    }
}

function SelectAllDoors() {
    if (cobBuildingPlanLocation.GetValue() !== "0") {
        var _doors = PlanDiagram.findNodesByExample({ level: "5" });

        allDoors = [];
        while (_doors.next()) {
            var building = _doors.value;
            allDoors.push(building);
        }
        $.each(allDoors, function () {
            if (this.data.groupChoice !== true) {
                var groupStatus = true;
                SetReaderGroupStatus(this, groupStatus);
                saveChanges = true;
            }
        });
    }
}
function UnselectSelectAllDoors() {
    if (cobBuildingPlanLocation.GetValue() !== "0") {
        var _doors = PlanDiagram.findNodesByExample({ level: "5" });

        allDoors = [];
        while (_doors.next()) {
            var building = _doors.value;
            allDoors.push(building);
        }
        $.each(allDoors, function () {
            if (this.data.groupChoice === true) {
                var groupStatus = false;
                SetReaderGroupStatus(this, groupStatus);
                saveChanges = true;
            }
        });
    }
}
// back dialog
function BackButtonConfirm() {
    var message = "Willst du die Änderungen speichern";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Zutritts</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save2-02.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnOk"  style="margin-left: 28%;width: 155px; margin-right: 0px;"  onclick="SaveOnBack()"></button><button id="btnNo"  onclick="No_OnBack()"></button><button id="btnCancel"  onclick="ResetDialog(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    getLocalizedText("newSaveWarning");
    $('#btnOk').text(levelCaption);
    getLocalizedText("newNoText");
    $('#btnNo').text(levelCaption);
}
function ResetDialog() {
    document.getElementById('importantDialog').innerHTML = "";
}
function SaveOnBack() {
    ResetDialog();
    GetSelectedDoors();
    var buldingPlanId = cobBuildingPlanLocation.GetValue();
    var groupId = cobAccessGroupNr.GetValue();
    if (parseInt(buldingPlanId) > 0) {
        PageMethods.MapAccessPlanGroupDoor(groupId, buldingPlanId, selectedDoors, MapAccessPlanGroupDoorOnBack_CallBack);
    }
}
function MapAccessPlanGroupDoorOnBack_CallBack() {
    document.location.href = "/Content/AccessPlanGroup.aspx";
}
function No_OnBack() {
    ResetDialog();
    document.location.href = "/Content/AccessPlanGroup.aspx";
}
//end back dialog

// delete selection dialog
function ConfirmDeleteSelection() {
    var message = "Sind Sie sicher, dass Sie die Auswahl entfernen wollen?";
    var box_content = '<div id="overlay"><div id="box_flame"><div id="dialogBox"> <div id="prompttopclose"><label id="lbltitletop">Achtung</label><button id="promptbtnclose"  onclick="ResetDialog(); return false;" /></div><div id="areasavepop"><img src="../../Images/FormImages/stop-save1-01.png" alt="Stop" class="stopPic" height="150" width="150" align="middle"><div id="lbltitlemsg">' + message + '</div> <button id="btnDeleteOk"  style="margin-left: 32%; margin-right: 0px;"  onclick="RemoveSelection()"></button><button id="btnDeleteCancel"  onclick="ResetDialog(); return false;" style=" position: relative;"></button></div></div></div></div>';
    document.getElementById('importantDialog').innerHTML = box_content;
    //getLocalizedText("permitDeleteAccessGroup");
    $('#btnDeleteOk').text("Auswahl löschen");
    //getLocalizedText("cancelAccessGroupDeletion");
    $('#btnDeleteCancel').text("Auswahl nicht löschen");
}
function RemoveSelection() {
    ResetDialog();
    UnselectSelectAllDoors();
}
// end delete selection dialog

function colorGrid() {
    for (var keyCount = 0; keyCount < grdBuildingPlanGrid.keys.length; keyCount++) {
        if (grdBuildingPlanGrid.keys[keyCount].split('-').length == 4) {
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[6]).css("background-color", "PeachPuff");
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[5]).css("background-color", "PeachPuff");
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[4]).css("background-color", "PeachPuff");
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[3]).css("background-color", "PeachPuff");
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[2]).css("background-color", "PeachPuff");
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[1]).css("background-color", "PeachPuff");
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[0]).css("background-color", "PeachPuff");
        }
        else if (grdBuildingPlanGrid.keys[keyCount].split('-').length == 3) {
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[6]).css("background-color", "rgba(227, 244, 251, 1)");
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[5]).css("background-color", "rgba(227, 244, 251, 1)");
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[4]).css("background-color", "rgba(227, 244, 251, 1)");
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[3]).css("background-color", "rgba(227, 244, 251, 1)");
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[2]).css("background-color", "rgba(227, 244, 251, 1)");
        }
        else if (grdBuildingPlanGrid.keys[keyCount].split('-').length == 2) {
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[6]).css("background-color", "#FFE7A2");
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[5]).css("background-color", "#FFE7A2");
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[4]).css("background-color", "#FFE7A2");
            $(grdBuildingPlanGrid.GetRow(keyCount).cells[3]).css("background-color", "#FFE7A2");
        }
    }
}

function GetAccessGroupGridUpdateValues() {
    var updateObject = [];

    for (var keyCount = 0; keyCount < grdBuildingPlanGrid.keys.length; keyCount++) {
        if (grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0].childNodes.length == 0) {
            var _DoorID = grdBuildingPlanGrid.keys[keyCount];
            var _Checked = $(grdBuildingPlanGrid.GetRow(keyCount).cells[6]).children("span")[0].className.indexOf("CheckBoxChecked") > -1;

            if (_Checked) updateObject.push(_DoorID);
        } else {
            var _DoorID = grdBuildingPlanGrid.keys[keyCount];
            var _Checked = $(grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0]).children("span")[0].className.indexOf("CheckBoxChecked") > -1;

            if (_Checked) updateObject.push(_DoorID);
        }
    }

    return updateObject;
}

function RemoveAccessGroupGridSelection() {
    var unCheckUpdateValueText = '<span class="dxWeb_edtCheckBoxUnchecked dxICheckBox dxichSys"></span>';
    grdBuildingPlanGrid.batchEditHelper.updatedValues = {};

    for (var keyCount = 0; keyCount < grdBuildingPlanGrid.keys.length; keyCount++) {
        if (grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0].childNodes.length == 0) {
            var _DoorID = grdBuildingPlanGrid.keys[keyCount];
            var _Checked = grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0].className.indexOf("CheckBoxChecked") > -1;

            if (_Checked) { //$($(grdBuildingPlanGrid.GetRow(keyCount).cells[6]).children("span")[0]).click();
                try {
                    var chkClassName = grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0].className.replace('dxWeb_edtCheckBoxChecked', 'dxWeb_edtCheckBoxUnchecked');
                    grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0].className = chkClassName;
                } catch (e) { console.log(e); }
                grdBuildingPlanGrid.batchEditHelper.SetCellValue(keyCount, 7, false, unCheckUpdateValueText);
            }
        } else {
            var _DoorID = grdBuildingPlanGrid.keys[keyCount];
            var _Checked = grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0].childNodes[0].className.indexOf("CheckBoxChecked") > -1;

            if (_Checked) {//$($(grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0]).children("span")[0]).click();
                try {
                    var chkClassName = grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0].childNodes[0].className.replace('dxWeb_edtCheckBoxChecked', 'dxWeb_edtCheckBoxUnchecked');
                    grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0].childNodes[0].className = chkClassName;
                } catch (e) { console.log(e); }
                grdBuildingPlanGrid.batchEditHelper.SetCellValue(keyCount, 7, false, unCheckUpdateValueText);
            }
        }
    }
}

function AllAccessGroupGridSelection() {
    var checkUpdateValueText = '<span class="dxWeb_edtCheckBoxChecked dxICheckBox dxichSys"></span>';
    grdBuildingPlanGrid.batchEditHelper.updatedValues = {};

    for (var keyCount = 0; keyCount < grdBuildingPlanGrid.keys.length; keyCount++) {
        if (grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0].childNodes.length == 0) {
            var _DoorID = grdBuildingPlanGrid.keys[keyCount];
            var _Checked = grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0].className.indexOf("CheckBoxUnchecked") > -1;

            if (_Checked) { //$($(grdBuildingPlanGrid.GetRow(keyCount).cells[6]).children("span")[0]).click();
                try {
                    var chkClassName = grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0].className.replace('dxWeb_edtCheckBoxUnchecked', 'dxWeb_edtCheckBoxChecked');
                    grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0].className = chkClassName;
                } catch (e) { console.log(e); }
                grdBuildingPlanGrid.batchEditHelper.SetCellValue(keyCount, 7, true, checkUpdateValueText);
            }
        } else {
            var _DoorID = grdBuildingPlanGrid.keys[keyCount];
            var _Checked = grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0].childNodes[0].className.indexOf("CheckBoxUnchecked") > -1;

            if (_Checked) {//$($(grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0]).children("span")[0]).click();
                try {
                    var chkClassName = grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0].childNodes[0].className.replace('dxWeb_edtCheckBoxUnchecked', 'dxWeb_edtCheckBoxChecked');
                    grdBuildingPlanGrid.GetRow(keyCount).cells[6].childNodes[0].childNodes[0].className = chkClassName;
                } catch (e) { console.log(e); }
                grdBuildingPlanGrid.batchEditHelper.SetCellValue(keyCount, 7, true, checkUpdateValueText);
            }
        }
    }
}