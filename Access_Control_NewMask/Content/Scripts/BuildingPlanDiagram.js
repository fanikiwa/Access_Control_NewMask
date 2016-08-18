/*
 * Methods to create object using go js
 */
var $$ = go.GraphObject.make;
var PlanDiagram = null;
var NavDiagram = null;

var currentID = 0;
var planNo = 0;

var levelCaption = "";
var imageString = " ";
var objectLevel = 0;
var selectedNodeKey = 0;
var editMode = false;
var saveChanges = false;
var readerIsActive = false;
var assigned = 0;
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


function CreatePlan(divHtmlElement) {
    //ref: http://www.gojs.net/latest/intro/buildingObjects.html
    var $$ = go.GraphObject.make;
    PlanDiagram = $$(go.Diagram, divHtmlElement,
      {
          allowMove: false,
          //allowHorizontalScroll:false,
          "commandHandler.deletesTree": true,//deletes node with its subtrees
          initialContentAlignment: go.Spot.TopLeft,
          "InitialLayoutCompleted": loadDiagramProperties,
          "toolManager.mouseWheelBehavior": go.ToolManager.WheelZoom,
          //"clickCreatingTool.archetypeNodeData": { text: "new node" }
          "undoManager.isEnabled": true

      });
    // 1. location node
    var locationTemplate =
     $$(go.Node, "Horizontal",
             { background: "white" },
              { width: 205, height: 70 },
              {
                  doubleClick:  // here the second argument is this object, which is this Node
                    function (e, node) { saveChanges = true; }
              },
             $$(go.Picture,
               { margin: 5, width: 40, height: 40, background: "white" },
               new go.Binding("source")),

             $$(go.Panel, "Table",
            { defaultAlignment: go.Spot.Left },

               //node name
               $$(go.TextBlock, "Default Text",
               { row: 2, column: 0, margin: 2, stroke: "black", font: "12px sans-serif", width: 135, editable: true, name: "ButtonName", isMultiline: false },
               new go.Binding("text", "text").makeTwoWay()),
               //Address
                $$(go.TextBlock, " ",
               { row: 3, column: 0, margin: 2, stroke: "black", font: "12px sans-serif", width: 135, editable: true, name: "AddressName", isMultiline: false },
               new go.Binding("text", "Address").makeTwoWay()),
                //Street
                $$(go.TextBlock, " ",
               { row: 4, column: 0, margin: 2, stroke: "black", font: "12px sans-serif", width: 135, editable: true, name: "StreetName", isMultiline: false },
               new go.Binding("text", "Street").makeTwoWay()),
               $$(go.TextBlock, "0", { row: 6, column: 0, visible: false }, new go.Binding("text", "level"))

      ),
       //changes contextmenu and tree expander button
     {
         contextMenu: $$(go.Adornment)
     },

             $$("TreeExpanderButton",
           {
               width: 14,
               "ButtonIcon.stroke": "black",

           }, {
               click: function (e, obj) {
                   var node = obj.part;  // OBJ is this button
                   if (node instanceof go.Adornment) node = node.adornedPart;
                   if (!(node instanceof go.Node)) return;
                   var diagram = node.diagram;
                   if (diagram === null) return;
                   var cmd = diagram.commandHandler;
                   if (node.isTreeExpanded) {
                       if (!cmd.canCollapseTree(node)) return;
                   } else {
                       if (!cmd.canExpandTree(node)) return;
                   }
                   e.handled = true;
                   if (node.isTreeExpanded) {
                       cmd.collapseTree(node);
                       NavDiagram.commandHandler.collapseTree(NavDiagram.findNodeForKey(node.data.key));
                   } else {
                       cmd.expandTree(node);
                       NavDiagram.commandHandler.expandTree(NavDiagram.findNodeForKey(node.data.key));
                   }
               }



           })
    );
    //2. building node
    var buildingTemplate =
    $$(go.Node, "Horizontal",
            { background: "white" },
             { width: 205, height: 70 },
              {
                  doubleClick:  // here the second argument is this object, which is this Node
                    function (e, node) { saveChanges = true; }
              },
            $$(go.Picture,
              { margin: 5, width: 40, height: 40, background: "white" },
              new go.Binding("source")),

            $$(go.Panel, "Table",
           { defaultAlignment: go.Spot.Left },

              //node name
              $$(go.TextBlock, "Default Text",
              { row: 2, column: 0, margin: 2, stroke: "black", font: "12px sans-serif", width: 135, editable: true, name: "ButtonName", isMultiline: false },
              new go.Binding("text", "text").makeTwoWay()),
              //Address
               $$(go.TextBlock, " ",
              { row: 3, column: 0, margin: 2, stroke: "black", font: "12px sans-serif", width: 135, editable: true, name: "AddressName", isMultiline: false },
              new go.Binding("text", "Address").makeTwoWay()),
               //Street
               $$(go.TextBlock, " ",
              { row: 4, column: 0, margin: 2, stroke: "black", font: "12px sans-serif", width: 135, editable: true, name: "StreetName", isMultiline: false },
              new go.Binding("text", "Street").makeTwoWay()),
              $$(go.TextBlock, "0", { row: 6, column: 0, visible: false }, new go.Binding("text", "level"))

     ),
      //changes
         {
             contextMenu: $$(go.Adornment)
         },

              $$("TreeExpanderButton",
            {
                width: 14,
                "ButtonIcon.stroke": "black",

            }, {
                click: function (e, obj) {
                    var node = obj.part;  // OBJ is this button
                    if (node instanceof go.Adornment) node = node.adornedPart;
                    if (!(node instanceof go.Node)) return;
                    var diagram = node.diagram;
                    if (diagram === null) return;
                    var cmd = diagram.commandHandler;
                    if (node.isTreeExpanded) {
                        if (!cmd.canCollapseTree(node)) return;
                    } else {
                        if (!cmd.canExpandTree(node)) return;
                    }
                    e.handled = true;
                    if (node.isTreeExpanded) {
                        cmd.collapseTree(node);
                        NavDiagram.commandHandler.collapseTree(NavDiagram.findNodeForKey(node.data.key));
                    } else {
                        cmd.expandTree(node);
                        NavDiagram.commandHandler.expandTree(NavDiagram.findNodeForKey(node.data.key));
                    }
                }



            })
   );
    // 3. floor node
    var floorTemplate =
  $$(go.Node, "Horizontal",
         { background: "white" },
          { width: 205, height: 70 },
           {
               doubleClick:  // here the second argument is this object, which is this Node
                 function (e, node) { saveChanges = true; }
           },
         $$(go.Picture,
           { margin: 5, width: 40, height: 40, background: "white" },
           new go.Binding("source")),

         $$(go.Panel, "Table",
        { defaultAlignment: go.Spot.Left },

           //node name
           $$(go.TextBlock, "Default Text",
           { row: 2, column: 0, margin: 2, stroke: "black", font: "12px sans-serif", width: 135, editable: true, name: "ButtonName", isMultiline: false },
           new go.Binding("text", "text").makeTwoWay()),
           //Address
            $$(go.TextBlock, " ",
           { row: 3, column: 0, margin: 2, stroke: "black", font: "12px sans-serif", width: 135, editable: true, name: "AddressName", isMultiline: false },
           new go.Binding("text", "Address").makeTwoWay()),
            //Street
            $$(go.TextBlock, " ",
           { row: 4, column: 0, margin: 2, stroke: "black", font: "12px sans-serif", width: 135, editable: true, name: "StreetName", isMultiline: false },
           new go.Binding("text", "Street").makeTwoWay()),
           $$(go.TextBlock, "0", { row: 6, column: 0, visible: false }, new go.Binding("text", "level"))

  ),
   //changes
         {
             contextMenu: $$(go.Adornment)
         },

              $$("TreeExpanderButton",
            {
                width: 14,
                "ButtonIcon.stroke": "black",

            }, {
                click: function (e, obj) {
                    var node = obj.part;  // OBJ is this button
                    if (node instanceof go.Adornment) node = node.adornedPart;
                    if (!(node instanceof go.Node)) return;
                    var diagram = node.diagram;
                    if (diagram === null) return;
                    var cmd = diagram.commandHandler;
                    if (node.isTreeExpanded) {
                        if (!cmd.canCollapseTree(node)) return;
                    } else {
                        if (!cmd.canExpandTree(node)) return;
                    }
                    e.handled = true;
                    if (node.isTreeExpanded) {
                        cmd.collapseTree(node);
                        NavDiagram.commandHandler.collapseTree(NavDiagram.findNodeForKey(node.data.key));
                    } else {
                        cmd.expandTree(node);
                        NavDiagram.commandHandler.expandTree(NavDiagram.findNodeForKey(node.data.key));
                    }
                }



            })
  );
    //4. room  node
    var roomTemplate =
  $$(go.Node, "Horizontal",
         { background: "white" },
          { width: 205, height: 70 },
           {
               doubleClick:  // here the second argument is this object, which is this Node
                 function (e, node) { saveChanges = true; }
           },
         $$(go.Picture,
           { margin: 5, width: 40, height: 40, background: "white" },
           new go.Binding("source")),

         $$(go.Panel, "Table",
        { defaultAlignment: go.Spot.Left },

           //node name property
           $$(go.TextBlock, "Default Text",
           { row: 2, column: 0, margin: 2, stroke: "black", font: "12px sans-serif", width: 135, editable: true, name: "ButtonName", isMultiline: false },
           new go.Binding("text", "text").makeTwoWay()),
           //Address property
            $$(go.TextBlock, " ",
           { row: 3, column: 0, margin: 2, stroke: "black", font: "12px sans-serif", width: 135, editable: true, name: "AddressName", isMultiline: false },
           new go.Binding("text", "Address").makeTwoWay()),
            //Street propety
            $$(go.TextBlock, " ",
           { row: 4, column: 0, margin: 2, stroke: "black", font: "12px sans-serif", width: 135, editable: true, name: "StreetName", isMultiline: false },
           new go.Binding("text", "Street").makeTwoWay()),
           // level property
           $$(go.TextBlock, "0", { row: 6, column: 0, visible: false }, new go.Binding("text", "level"))

  ),
   //changes
         {
             contextMenu: $$(go.Adornment)
         },

              $$("TreeExpanderButton",
            {
                width: 14,
                "ButtonIcon.stroke": "black",

            }, {
                click: function (e, obj) {
                    var node = obj.part;  // OBJ is this button
                    if (node instanceof go.Adornment) node = node.adornedPart;
                    if (!(node instanceof go.Node)) return;
                    var diagram = node.diagram;
                    if (diagram === null) return;
                    var cmd = diagram.commandHandler;
                    if (node.isTreeExpanded) {
                        if (!cmd.canCollapseTree(node)) return;
                    } else {
                        if (!cmd.canExpandTree(node)) return;
                    }
                    e.handled = true;
                    if (node.isTreeExpanded) {
                        cmd.collapseTree(node);
                        NavDiagram.commandHandler.collapseTree(NavDiagram.findNodeForKey(node.data.key));
                    } else {
                        cmd.expandTree(node);
                        NavDiagram.commandHandler.expandTree(NavDiagram.findNodeForKey(node.data.key));
                    }
                }



            })
  );

    //5. door  node
    var doorTemplate =
    $$(go.Node, "Horizontal",
              { background: "white" },
              // { width: 385, height: 70 },
               { width: 305, height: 70 },
                {
                    doubleClick:  // here the second argument is this object, which is this Node
                      function (e, node) { saveChanges = true; }
                },

                $$(go.Picture,
                { margin: 1, width: 40, height: 40, background: "white" },
                new go.Binding("source")),
                 // level property
                $$(go.TextBlock, "0", { row: 0, column: 0, visible: false }, new go.Binding("text", "level")),
                $$(go.TextBlock, "0", { row: 0, column: 0, visible: false }, new go.Binding("text", "readerAssigned")),

   $$(go.Panel, "Auto",
   $$(go.Shape, { fill: "white", stroke: "black", strokeWidth: 1, height: 60, width: 160 }),
            $$(go.Panel, "Table",
          { defaultAlignment: go.Spot.Left, defaultColumnSeparatorStroke: "black" },
          // level property
                $$(go.TextBlock, "0", { row: 0, column: 0, visible: false }, new go.Binding("text", "level")),
                //node name property property
                $$(go.TextBlock, "DefaultText",
                { row: 1, column: 0, margin: 1, stroke: "black", font: "12px sans-serif", width: 135, editable: true, name: "FirstDescription", isMultiline: false },
                new go.Binding("text", "text").makeTwoWay()),
                 //node name property property
                $$(go.TextBlock, "DefaultText",
                { row: 2, column: 0, margin: 1, stroke: "black", font: "12px sans-serif", width: 135, editable: true, name: "SecondDescription", isMultiline: false },
                new go.Binding("text", "firstDescription").makeTwoWay()),
                 //node name property property
                $$(go.TextBlock, "DefaultText",
                { row: 3, column: 0, margin: 1, stroke: "black", font: "12px sans-serif", width: 135, editable: true, name: "ThirdDescription", isMultiline: false },
                new go.Binding("text", "secondDescription").makeTwoWay())
)

  ),
   $$(go.Panel, "Auto",
   $$(go.Shape, { fill: "white", stroke: "black", strokeWidth: 1, height: 60, width: 50 }),
           $$(go.Panel, "Table",
          //{ defaultAlignment: go.Spot.Left, defaultColumnSeparatorStroke: "black", defaultRowSeparatorStroke: "black" },
          { defaultAlignment: go.Spot.Left, defaultColumnSeparatorStroke: "black" },

         //$$(go.RowColumnDefinition,
         // { row: 1, separatorStrokeWidth: 0, separatorStroke: "black" }),
        $$(go.RowColumnDefinition,
          { column: 1, separatorStrokeWidth: 1, separatorStroke: "black" }),
          $$(go.Panel, "TableRow", { row: 1 },
           $$(go.Picture,
              { margin: 2, width: 40, height: 35, column: 0, alignment: go.Spot.Right, background: "white" },
              new go.Binding("source", "directionImg"))
          //$$(go.TextBlock, "Leser", { column: 0, margin: 2 }),
          //$$(go.TextBlock, "", { column: 2, margin: 1 }, new go.Binding("text", "ReaderType")),
           //$$(go.Picture,
           //   { margin: 2, width: 40, height: 35, column: 1, alignment: go.Spot.Right, background: "white" },
           //   new go.Binding("source", "readerStatusImg")),
          //$$("CheckBoxPanel", "laserChoice", { column: 2, margin: 2 })

        )

        //$$(go.Panel, "TableRow", { row: 2 },
        //  $$(go.TextBlock, "Zutrittskalender", { column: 0, margin: 2 }),
        //  $$("CheckBoxPanel", "accessCalenderChoice", { column: 1, margin: 2 }),
        //  $$(go.TextBlock, "aktiv", { column: 2, margin: 2 }),
        //  $$(go.Picture,
        //   { margin: 2, width: 15, height: 15, column: 3, alignment: go.Spot.Right, background: "white" },
        //   new go.Binding("source", "accessCalenderImg"))
        //),
        //$$(go.Panel, "TableRow", { row: 3 },
        //  $$(go.TextBlock, "Schaltzeiten", { column: 0, margin: 2 }),
        //  $$("CheckBoxPanel", "swichTimeChoice", { column: 1, margin: 2 }),
        //  $$(go.TextBlock, "aktiv", { column: 2, margin: 2 }),
        //  $$(go.Picture,
        //      { margin: 2, width: 15, height: 15, column: 3, alignment: go.Spot.Right, background: "white" },
        //      new go.Binding("source", "swichTimeImg"))
        //)
        )


  ),





     $$(go.Panel, "Auto",
     $$(go.Shape, { fill: "white", stroke: "black", strokeWidth: 1, height: 60, width: 50 }),
           $$(go.Panel, "Table",
          //{ defaultAlignment: go.Spot.Left, defaultColumnSeparatorStroke: "black", defaultRowSeparatorStroke: "black" },
          { defaultAlignment: go.Spot.Left, defaultColumnSeparatorStroke: "black" },

         //$$(go.RowColumnDefinition,
         // { row: 1, separatorStrokeWidth: 0, separatorStroke: "black" }),
        $$(go.RowColumnDefinition,
          { column: 1, separatorStrokeWidth: 1, separatorStroke: "black" }),
          $$(go.Panel, "TableRow", { row: 1 },
           //$$(go.Picture,
           //   { margin: 2, width: 40, height: 35, column: 0, alignment: go.Spot.Right, background: "white" },
           //   new go.Binding("source", "readerStatusImg")),
          //$$(go.TextBlock, "Leser", { column: 0, margin: 2 }),
          //$$(go.TextBlock, "", { column: 2, margin: 1 }, new go.Binding("text", "ReaderType")),
           $$(go.Picture,
              { margin: 2, width: 30, height: 30, column: 0, alignment: go.Spot.Right, background: "white" },
              new go.Binding("source", "readerStatusImg"))
          //$$("CheckBoxPanel", "laserChoice", { column: 2, margin: 2 })

        )


        )

  ),



  // $$(go.Panel, "Auto",
  // $$(go.Shape, { fill: "white", stroke: "black", strokeWidth: 1, height: 60, width: 50 }),
  //         $$(go.Panel, "Table",
  //        //{ defaultAlignment: go.Spot.Left, defaultColumnSeparatorStroke: "black", defaultRowSeparatorStroke: "black" },
  //        { defaultAlignment: go.Spot.Left, defaultColumnSeparatorStroke: "black" },

  //       //$$(go.RowColumnDefinition,
  //       // { row: 1, separatorStrokeWidth: 0, separatorStroke: "black" }),
  //      $$(go.RowColumnDefinition,
  //        { column: 1, separatorStrokeWidth: 0, separatorStroke: "white" }),
  //        $$(go.Panel, "TableRow", { row: 1 },
  //         //$$(go.Picture,
  //         //   { margin: 2, width: 40, height: 35, column: 0, alignment: go.Spot.Right, background: "white" },
  //         //   new go.Binding("source", "readerStatusImg")),
  //        //$$(go.TextBlock, "Leser", { column: 0, margin: 2 }),
  //        //$$(go.TextBlock, "", { column: 2, margin: 1 }, new go.Binding("text", "ReaderType")),
  //         //$$(go.Picture,
  //         //   { margin: 2, width: 40, height: 35, column: 0, alignment: go.Spot.Right, background: "white" },
  //         //   new go.Binding("source", "readerStatusImg"))
  //        $$("CheckBoxPanel", "laserChoice", { column: 0, margin: 2 })

  //      )


  //      )

  //),







//  $$(go.Panel, "Auto",
//   $$(go.Shape, { fill: "white", stroke: "black", strokeWidth: 1, height: 60, width: 45 }),
//            $$(go.Panel, "Vertical",
//          {},
//           $$(go.Picture,
//                { margin: 2, width: 32, height: 32, background: "white", alignment: go.Spot.Center },
//                new go.Binding("source", "DoorStatusImg")),
//              $$("CheckBoxPanel", "DoorStatus", { margin: 2, alignment: go.Spot.Center })
//)

  //),

   //changes
         {
             contextMenu: $$(go.Adornment)
         },

              $$("TreeExpanderButton",
            {
                width: 14,
                "ButtonIcon.stroke": "black",

            }, {
                click: function (e, obj) {
                    var node = obj.part;  // OBJ is this button
                    if (node instanceof go.Adornment) node = node.adornedPart;
                    if (!(node instanceof go.Node)) return;
                    var diagram = node.diagram;
                    if (diagram === null) return;
                    var cmd = diagram.commandHandler;
                    if (node.isTreeExpanded) {
                        if (!cmd.canCollapseTree(node)) return;
                    } else {
                        if (!cmd.canExpandTree(node)) return;
                    }
                    e.handled = true;
                    if (node.isTreeExpanded) {
                        cmd.collapseTree(node);
                        NavDiagram.commandHandler.collapseTree(NavDiagram.findNodeForKey(node.data.key));
                    } else {
                        cmd.expandTree(node);
                        NavDiagram.commandHandler.expandTree(NavDiagram.findNodeForKey(node.data.key));
                    }
                }



            })
            );
    //default template
    var defaultTemplate =
          $$(go.Node, "Horizontal",
            { background: "white" },
             { width: 190 },
            $$(go.Picture,
              { margin: 10, width: 50, height: 50, background: "white" },
              new go.Binding("source")),

            $$(go.Panel, "Table",
        { defaultAlignment: go.Spot.Left },
          //node name
              $$(go.TextBlock, "Default Text",
              { row: 0, column: 0, margin: 2, stroke: "black", font: "12px sans-serif", width: 100, editable: true, name: "ButtonName", isMultiline: false },
              new go.Binding("text", "text").makeTwoWay()),
               //node level
              $$(go.TextBlock, "0", { row: 1, column: 0, visible: false }, new go.Binding("text", "level"))

      ),
    //changes
       {
           contextMenu: $$(go.Adornment)
       },

            $$("TreeExpanderButton",
          {
              width: 14,
              "ButtonIcon.stroke": "black",

          }, {
              click: function (e, obj) {
                  var node = obj.part;  // OBJ is this button
                  if (node instanceof go.Adornment) node = node.adornedPart;
                  if (!(node instanceof go.Node)) return;
                  var diagram = node.diagram;
                  if (diagram === null) return;
                  var cmd = diagram.commandHandler;
                  if (node.isTreeExpanded) {
                      if (!cmd.canCollapseTree(node)) return;
                  } else {
                      if (!cmd.canExpandTree(node)) return;
                  }
                  e.handled = true;
                  if (node.isTreeExpanded) {
                      cmd.collapseTree(node);
                      NavDiagram.commandHandler.collapseTree(NavDiagram.findNodeForKey(node.data.key));
                  } else {
                      cmd.expandTree(node);
                      NavDiagram.commandHandler.expandTree(NavDiagram.findNodeForKey(node.data.key));
                  }
              }



          })
  );
    // create the nodeTemplateMap, holding three node templates:
    var templmap = new go.Map("string", go.Node);
    // for each of the node categories, specify which template to use
    templmap.add("location", locationTemplate);
    templmap.add("building", buildingTemplate);
    templmap.add("floor", floorTemplate);
    templmap.add("room", roomTemplate);
    templmap.add("door", doorTemplate);
    templmap.add("", defaultTemplate);
    PlanDiagram.nodeTemplateMap = templmap;


    // This is a dummy context menu for the whole Diagram:
    PlanDiagram.contextMenu = $$(go.Adornment);

    // This is the actual HTML context menu:
    var cxElement = document.getElementById("contextMenu");

    // We don't want the div acting as a context menu to have a (browser) context menu!
    cxElement.addEventListener("contextmenu", function (e) {
        e.preventDefault();
        return false;
    },
    false);
    cxElement.addEventListener("blur", function (e) {
        //cxMenu.stopTool();
        PlanDiagram.currentTool.stopTool();
    }, false);

    // Override the ContextMenuTool.showContextMenu and hideContextMenu methods
    // in order to modify the HTML appropriately.
    var cxTool = PlanDiagram.toolManager.contextMenuTool;

    // This is the override of ContextMenuTool.showContextMenu:
    // This does not not need to call the base method.
    cxTool.showContextMenu = function (contextmenu, obj, e) {
        var diagram = this.diagram;
        if (diagram === null) return;


        // Hide any other existing context menu
        if (contextmenu !== this.currentContextMenu) {
            this.hideContextMenu();
        }
        if (obj !== null) {
            selectedNodeKey = obj.data.key;
            objectLevel = obj.data.level;
            var objs = obj.data.key;
            if (obj.data.level === "1") {
                LocationLevel();
                hideMenuItems();
            } else if (obj.data.level === "2") {
                BuildingLevel();
                hideMenuItems();
            } else if (obj.data.level === "3") {
                FloorLevel();
                hideMenuItems();
            } else if (obj.data.level === "4") {
                RoomLevel();
                hideMenuItems();
            } else if (obj.data.level === "5") {
                DoorLevel();
                showMenuItems();
                CopyCurrentGridValueFromDiag(obj);
                CopyRestGridValuesFromDiag(obj);
                //check if door is assigned a reader
                CheckIfReaderAssigned(dpllPlanNr.GetValue(), selectedNodeKey);
                var i = assigned;
                if (i === 1) {
                    document.getElementById("chkTerminal").disabled = false;
                }
                else {
                    document.getElementById("chkTerminal").disabled = true;
                }

                //check if reader is active
                CheckIfReaderActive(dpllPlanNr.GetValue(), selectedNodeKey);
                if (readerIsActive === true) {
                    document.getElementById("chkTerminal").checked = true;

                }
                else {
                    document.getElementById("chkTerminal").checked = false;
                }
            }
        }
        else {

        }
        //var objs = obj.data.key;
        // Show only the relevant buttons given the current state.
        var cmd = diagram.commandHandler;



        // Now show the whole context menu element
        if (obj !== null && allowZUTEdit == true) {

            if (obj.data.level === "5") {

                cxElement.style.display = "block";
                // we don't bother overriding positionContextMenu, we just do it here:
                var obj = PlanDiagram.selection.iterator.first();
                //var objPosition = obj.actualBounds;
                //var rightPost = parseInt(objPosition.right);
                var position = obj.part.location
                var docloc = diagram.transformDocToView(position);
                //var posX = parseInt(docloc.x.toFixed(2));
                var posX = parseInt(docloc.x);
                var posY = parseInt(docloc.y);
                var objPosition = PlanDiagram.selection.iterator.first().diagram.viewportBounds.right;
                var rightPost = parseInt(objPosition);

                //var posX = parseInt(docloc.y);
                //var objPositionY = PlanDiagram.selection.iterator.first().diagram.viewportBounds.right;
                //var rightPost = parseInt(objPosition);


                var mousePt = diagram.lastInput.viewPoint;
                var ctxmenuposx = parseInt($("#BuildingAreaDiv").position().left) + parseInt(mousePt.x);
                var ctxmenuposy = parseInt($("#BuildingAreaDiv").position().top) + parseInt(mousePt.y);
                //cxElement.style.left = (posX + 720) + "px";
                cxElement.style.left = (ctxmenuposx) + "px";
                //cxElement.style.top = (ctxmenuposy) + "px";
                if (posY < 500) {
                    cxElement.style.top = (posY + 200) + "px";
                }
                else {
                    cxElement.style.top = (posY - 60) + "px";
                }



                // Remember that there is now a context menu showing
                this.currentContextMenu = contextmenu;
            }
            else {
                cxElement.style.display = "block";
                // we don't bother overriding positionContextMenu, we just do it here:


                var mousePt = diagram.lastInput.viewPoint;
                var ctxmenuposx = parseInt($("#BuildingAreaDiv").position().left) + parseInt(mousePt.x);
                var ctxmenuposy = parseInt($("#BuildingAreaDiv").position().top) + parseInt(mousePt.y);
                cxElement.style.left = ctxmenuposx + "px";
                cxElement.style.top = ctxmenuposy + "px";

                // Remember that there is now a context menu showing
                this.currentContextMenu = contextmenu;
            }
        }
        else {

            cxElement.style.display = "none";
            this.currentContextMenu = contextmenu;

        }
    }

    // This is the corresponding override of ContextMenuTool.hideContextMenu:
    // This does not not need to call the base method.
    cxTool.hideContextMenu = function () {
        if (this.currentContextMenu === null) return;
        cxElement.style.display = "none";
        this.currentContextMenu = null;
    }

    PlanDiagram.layout = $$(go.TreeLayout);

    var nodeDataArray = [];
    var linkDataArray = [];

    PlanDiagram.model = new go.GraphLinksModel(nodeDataArray, linkDataArray);

    PlanDiagram.model.undoManager.isEnabled = true;
    function showMessage(s) {
        $("#btnAddBuilding").val(s);
    }
    PlanDiagram.addDiagramListener("TextEdited",
        function (e) {
            var _currObject = PlanDiagram.selection.iterator.first();
            if (_currObject != null) {
                if (_currObject.data.level === "1") {
                    RenameBuildingFloors(_currObject);
                }
                if (_currObject.data.level === "2") {
                    RenameFloors(_currObject);
                }
            }
        });
    PlanDiagram.addDiagramListener("ObjectSingleClicked",
        function (e) {

            getLocalizedText("newString");
            var newString = levelCaption;

            var part = e.subject.part;
            if (!(part instanceof go.Link))
                if (part.data.level === "1") {
                    getLocalizedText("newBuilding");
                    showMessage(levelCaption);
                    if (allowZUTEdit) $("#btnAddBuilding").removeAttr("disabled");
                    $("#btnAddBuilding").css("font-size", "12px");

                } else if (part.data.level === "2") {
                    getLocalizedText("newFloor");
                    showMessage(levelCaption);
                    if (allowZUTEdit) $("#btnAddBuilding").removeAttr("disabled");
                    $("#btnAddBuilding").css("font-size", "14px");

                } else if (part.data.level === "3") {
                    getLocalizedText("newRoom");
                    showMessage(levelCaption);
                    if (allowZUTEdit) $("#btnAddBuilding").removeAttr("disabled");
                    $("#btnAddBuilding").css("font-size", "14px");

                } else if (part.data.level === "4") {
                    getLocalizedText("newDoor");
                    showMessage(levelCaption);
                    if (allowZUTEdit) $("#btnAddBuilding").removeAttr("disabled");
                    $("#btnAddBuilding").css("font-size", "14px");

                } else if (part.data.level === "5") {
                    getLocalizedText("inactive");
                    if (allowZUTEdit) $("#btnAddBuilding").attr("disabled", "disabled");
                    showMessage(levelCaption);

                }
        });
    //var customEditor = document.createElement("input");
    var customEditor = document.getElementById("txtEditor");
    //var customEditorDoor = document.getElementById("txtEditorDoor");


    customEditor.onActivate = function () {


        customEditor.width = customEditor.textEditingTool.textBlock.width;
        customEditor.value = customEditor.textEditingTool.textBlock.text;

        saveChanges = true;
        // Do a few different things when a user presses a key
        customEditor.addEventListener("keydown", function (e) {
            var keynum = e.which;
            var tool = customEditor.textEditingTool;
            if (tool === null) return;
            if (keynum == 13) { // Accept on Enter
                //tool.acceptText(go.TextEditingTool.Enter);
                tool.acceptText(go.TextEditingTool.Tab);// custom use tab event instead
                e.preventDefault();

                return false;
            } else if (keynum == 9) { // Accept on Tab
                tool.acceptText(go.TextEditingTool.Tab);
                e.preventDefault();

                return false;
            } else if (keynum === 27) { // Cancel on Esc
                tool.doCancel();
                if (tool.diagram) tool.diagram.focus();
            }

        }, false);
        customEditor.addEventListener("LostFocus", function (e) {

        }, false);
        var loc = customEditor.textEditingTool.textBlock.getDocumentPoint(go.Spot.TopLeft);
        var pos = PlanDiagram.transformDocToView(loc);
        var mousePt = PlanDiagram.lastInput.viewPoint;
        var ctxmenuposx = parseInt($("#BuildingAreaDiv").position().left) + parseInt(mousePt.x);
        var ctxmenuposy = parseInt($("#BuildingAreaDiv").position().top) + parseInt(mousePt.y);
        //customEditor.style.left = ctxmenuposx + "px";
        //customEditor.style.top = ctxmenuposy + "px";
        customEditor.style.left = pos.x + "px";
        customEditor.style.top = pos.y + "px";
    }
    PlanDiagram.model.copiesArrays = true;
    PlanDiagram.model.copiesArrayObjects = true;
    PlanDiagram.model.addChangedListener(function (e) {
        if (e.isTransactionFinished)
            var i = 1;
    });
    PlanDiagram.toolManager.textEditingTool.defaultTextEditor = customEditor;
    return PlanDiagram;
}
// returns a unique key
function makeUnique() {
    // really simple, just returns a number (skipping odd numbers)
    currentID = currentID + 1;
    return currentID;
}
// This is the general menu command handler, parameterized by the name of the command.

function cxcommandEntries() {
    var diagram = PlanDiagram;
    if (!(diagram.currentTool instanceof go.ContextMenuTool)) return;

    diagram.currentTool.stopTool();
}
function cxcommandTerminalAssignment() {
    if (saveChanges === true) {
        // save changes before assigning readers
        saveCustom();
    }
    else {
        AssignReader(dpllPlanNr.GetValue());
    }
}


function cxcommandEdit() {
    var diagram = PlanDiagram;
    if (!(diagram.currentTool instanceof go.ContextMenuTool)) return;
    PlanDiagram.commandHandler.editTextBlock();
    SetControlsOnEdit();
    saveChanges = true;
}
function cxcommandDeleteSelection() {
    resetBuildingAreaDiv();
    var diagram = PlanDiagram;
    if (!(diagram.currentTool instanceof go.ContextMenuTool)) return;
    var nodeToDelete = PlanDiagram.selection.iterator.first();
    if (nodeToDelete.data.level === "5") {

        DeleteAssignedReader(parseInt(dpllPlanNr.GetValue()), parseInt(nodeToDelete.data.key));
    }
    else {
        deleteReadersAssigned(nodeToDelete);
    }

    PlanDiagram.commandHandler.deleteSelection();
    diagram.currentTool.stopTool();
    save();
    saveChanges = false;
}
function cxcommand(val) {
    var diagram = PlanDiagram;
    //PlanDiagram.commandHandler.editTextBlock();
    if (!(diagram.currentTool instanceof go.ContextMenuTool)) return;
    switch (val) {
        case "Gebäude": changeColor(diagram); break;
        case "name": diagram.commandHandler.copySelection(); break;
        case "Info": diagram.commandHandler.copySelection(); break;
        case "delete": diagram.commandHandler.deleteSelection();
            if (allowZUTEdit) $("#btnSave").removeAttr("disabled");
            break;


    }
    diagram.currentTool.stopTool();
}



function addChild(diagram) {
    var selnode = diagram.selection.first();
    if (!(selnode instanceof go.Node)) return;
    diagram.startTransaction("add node and link");
    // have the Model add a new node data
    var newnode = {};
    getLocalizedText("address");
    var address = levelCaption;
    getLocalizedText("street1");
    var street = levelCaption;

    var keynum = selnode.findNodesOutOf().count + 1;
    if (selnode.data.level === "1") {
        getLocalizedText("building");
        var _street = selnode.data.Street;
        var _address = selnode.data.Address;
        newnode = { key: makeUnique(), source: "../../Images/FormImages/Zweispaltig.png", text: levelCaption + " " + keynum, level: "2", category: "building", Address: _address, Street: _street };
        saveChanges = true;
    } else if (selnode.data.level === "2") {
        getLocalizedText("floor");
        var _street = selnode.data.Street;
        var _address = selnode.data.Address;
        newnode = { key: makeUnique(), source: "../../Images/FormImages/Ebene25.png", text: levelCaption + " " + keynum, level: "3", category: "floor", Address: _address, Street: _street };
        saveChanges = true;

    } else if (selnode.data.level === "3") {
        getLocalizedText("room");
        var _room = levelCaption;
        getLocalizedText("room");
        var _room = levelCaption;
        getLocalizedText("firstDecription");
        var _firstDesc = levelCaption;
        getLocalizedText("secondDecription");
        var _secondDesc = levelCaption;
        newnode = { key: makeUnique(), source: "../../Images/FormImages/Raum25.png", text: _room + " " + keynum, level: "4", category: "room", Address: _firstDesc, Street: _secondDesc };
        saveChanges = true;

    } else if (selnode.data.level === "4") {
        getLocalizedText("accessCalendarTitle");
        var accessProfile = levelCaption
        getLocalizedText("switchCalender");
        var switchProfile = levelCaption
        getLocalizedText("door");
        var _door = levelCaption;
        getLocalizedText("firstDecription");
        var _firstDesc = levelCaption;
        getLocalizedText("secondDecription");
        var _secondDesc = levelCaption;
        var InactiveImg = "../../Images/FormImages/bp_red24px.png";
        var DoorCustomImg = "../../Images/FormImages/stopCustom32px.png";
        newnode = { key: makeUnique(), source: "../../Images/FormImages/door-reader100.png", text: _door + " " + keynum, level: "5", category: "door", firstDescription: _firstDesc, secondDescription: _secondDesc, laserChoice: false, accessCalenderChoice: false, swichTimeChoice: false, readerStatusImg: InactiveImg, accessCalenderImg: InactiveImg, swichTimeImg: InactiveImg, ManualOpening: false, DoorStatus: false, DoorStatusImg: DoorCustomImg };
        saveChanges = true;

    } else if (selnode.data.level === "5") {
        return;
    }
    diagram.model.addNodeData(newnode);  // this makes sure the key is unique
    // and then add a link data connecting the original node with the new one
    var newlink = { from: selnode.data.key, to: newnode.key };
    // add the new link to the model
    diagram.model.addLinkData(newlink);
    // finish the transaction
    diagram.commitTransaction("add node and link");

    //disable addtion of more than one building
    //if (selnode.data.level === "1"){
    //var buildingCount = PlanDiagram.findNodesByExample({ level: "2" }).count;
    //if (buildingCount > 0) {
    //    $("#btnAddBuilding").attr("disabled", "disabled");
    //}
    //else {
    //    $("#btnAddBuilding").removeAttr("disabled");
    //}
    //}
    //end disable addtion of more than one building
}

function loadDiagramProperties(e) {

}

function AddObjectToPlan(diagram, _ObjectName) {//this function adds a location to the plan
    if (_ObjectName === "Standort") {
        var locNum = PlanDiagram.findTreeRoots().count + 1;
        getLocalizedText("address");
        var address = levelCaption;
        getLocalizedText("street1");
        var street = levelCaption;
        getLocalizedText("location2");

        var newnode = { key: makeUnique(), source: "../../Images/FormImages/location.png", text: levelCaption + " " + locNum, level: "1", category: "location", Address: address, Street: street };

        //var newnode = { key: makeUnique(), source: "../../Images/FormImages/location.png", text: "Standort " + locNum, level: "1" };
        diagram.model.addNodeData(newnode);
        saveChanges = true;
    }
}

// save a model to and load a model from Json text, displayed below the Diagram
function save() {
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
    var str = '{ "position": "' + go.Point.stringify(PlanDiagram.position) + '",\n  "model": ' + PlanDiagram.model.toJson() + ' }';
    if (dpllPlanNr.GetValue() === "0") {
        var PlanNrExists = CheckIfPlanNrExists($("#txtPlanNr").val().trim());
        switch (PlanNrExists) {
            case false:
                PageMethods.CreateBuildingPlan($("#txtPlanNr").val(), $("#txtPlanName").val(), str, currentID, OnSave_Callback);
                break;
            case true:
                PlanNumberExistsPrompt();
                break;
            default:
                //do nothing
                break;
        }

    } else {
        PageMethods.UpdateBuildingPlan(dpllPlanNr.GetValue(), $("#txtPlanNr").val(), $("#txtPlanName").val(), str, currentID, OnEdit_Callback);
    }
}

function OnSave_Callback(response) {
    //$("#dpllPlanNr").append($('<option></option>').val(response.ID).html(response.PlanNr));
    //$("#dplPlanName").append($('<option></option>').val(response.ID).html(response.PlanName));

    //$("#dplPlanName").val(response.ID);
    //$("#dpllPlanNr").val(response.ID);

    $("#txtPlanNr").val(response.PlanNr);
    $("#txtPlanName").val(response.PlanName);
    dpllPlanNr.PerformCallback(response.ID);
    dplPlanName.PerformCallback(response.ID);
}

function OnEdit_Callback(response) {
    //$("#dpllPlanNr option:selected").html(response.PlanNr);
    //$("#dplPlanName option:selected").html(response.PlanName);
    //$("#dplPlanName").val(response.ID);
    //$("#dpllPlanNr").val(response.ID);

    $("#txtPlanNr").val(response.PlanNr);
    $("#txtPlanName").val(response.PlanName);

    dpllPlanNr.PerformCallback(response.ID);
    dplPlanName.PerformCallback(response.ID);
    //PageMethods.UpdateAssignedReader(response.ID);
}

function load(str) {
    //var str = document.getElementById("mySavedDiagram").value;
    try {
        if (typeof str.LastNodeKey === "undefined") {
            currentID = 0;
        } else { currentID = str.LastNodeKey; }

        var json = JSON.parse(str.PlanDefinition);
        PlanDiagram.initialPosition = go.Point.parse(json.position || "0 0");
        PlanDiagram.model = go.Model.fromJson(json.model);
        //PlanDiagram.findNodeForKey("L2").isTreeExpanded = false;
        //14.07.2014
        //var it = PlanDiagram.findTreeRoots();
        //while (it.next()) {
        //    console.log(it.key + ": " + it.value);
        //    var part = it.value;  // part is now a Node or a Group or a Link or maybe a simple Part
        //    if (part instanceof go.Node) { //part.isTreeExpanded = true;
        //    }
        //}
        PlanDiagram.model.undoManager.isEnabled = true;
    } catch (ex) {
        //alert(ex);
        //error
        var nodeDataArray = [];
        var linkDataArray = [];

        PlanDiagram.model = new go.GraphLinksModel(nodeDataArray, linkDataArray);
    }
    //myDiagram = null;
    BuildNavMenus();
}
function init() {
    //var $$ = go.GraphObject.make;  // for conciseness in defining templates

    NavDiagram =
      $$(go.Diagram, "BuildingAreaNav",
        {
            allowMove: false,
            allowCopy: false,
            allowDelete: false,
            allowHorizontalScroll: false,
            layout:
              $$(go.TreeLayout,
                {
                    alignment: go.TreeLayout.AlignmentStart,
                    angle: 0,
                    compaction: go.TreeLayout.CompactionNone,
                    layerSpacing: 16,
                    layerSpacingParentOverlap: 1,
                    nodeIndent: 4,
                    nodeIndentPastParent: 0.88,
                    nodeSpacing: 4,
                    setsPortSpot: false,
                    setsChildPortSpot: false
                })
        });

    NavDiagram.nodeTemplate =
      $$(go.Node,
        // no Adornment: instead change panel background color by binding to Node.isSelected
        { selectionAdorned: false, selectionChanged: onSelectionChanged },
        $$("TreeExpanderButton",
        $$(go.Shape,  // the icon
          {
              name: "ButtonIcon",
              figure: "MinusLine",  // default value for isTreeExpanded is true
              desiredSize: new go.Size(6, 6)
          }),
          {
              width: 14,
              "ButtonIcon.stroke": "black",

          }, {
              click: function (e, obj) {
                  var node = obj.part;  // OBJ is this button
                  if (node instanceof go.Adornment) node = node.adornedPart;
                  if (!(node instanceof go.Node)) return;
                  var diagram = node.diagram;
                  if (diagram === null) return;
                  var cmd = diagram.commandHandler;
                  if (node.isTreeExpanded) {
                      if (!cmd.canCollapseTree(node)) return;
                  } else {
                      if (!cmd.canExpandTree(node)) return;
                  }
                  e.handled = true;
                  if (node.isTreeExpanded) {
                      cmd.collapseTree(node);
                      PlanDiagram.commandHandler.collapseTree(PlanDiagram.findNodeForKey(node.data.key));
                  } else {
                      cmd.expandTree(node);
                      PlanDiagram.commandHandler.expandTree(PlanDiagram.findNodeForKey(node.data.key));
                  }
              }
          }),
        $$(go.Panel, "Horizontal",
          { position: new go.Point(16, 0) },
          new go.Binding("background", "isSelected", function (s) { return (s ? "lightblue" : "white"); }).ofObject(),
          $$(go.Picture,
            {
                width: 14, height: 14,
                margin: new go.Margin(0, 4, 0, 0),
                imageStretch: go.GraphObject.Uniform,
                source: "../../Images/FormImages/folder2-02.png"
            }),
          $$(go.TextBlock,
            new go.Binding("text", "text", function (s) { return "" + s; }))
        )  // end Horizontal Panel
      );  // end Node

    //NavDiagram.addDiagramListener("ObjectSingleClicked",
    //  function (e) {
    //      var part = e.subject.part;
    //      if (!(part instanceof go.Link)) alert("Clicked on " + part.data.key);
    //  });
    //NavDiagram.addDiagramListener("ChangedSelection",
    //  function (e) {
    //      console.log(e);

    //  });
    // without lines
    NavDiagram.linkTemplate = $$(go.Link);
    //myDiagram.linkTemplate =
    //  $(go.Link,
    //    { selectable: false,
    //      routing: go.Link.Orthogonal,
    //      fromEndSegmentLength: 4,
    //      toEndSegmentLength: 4,
    //      fromSpot: new go.Spot(0.001, 1, 7, 0),
    //      toSpot: go.Spot.Left },
    //    $(go.Shape,
    //      { stroke: "lightgray" }));
    //// with lines
    //myDiagram.linkTemplate =
    //  $$(go.Link,
    //    { selectable: false,
    //      routing: go.Link.Orthogonal});

    //var nodeDataArray = buildNavBar();//PlanDiagram.model.nodeDataArray;//[{ key: 0 }];
    //var linkDataArray = PlanDiagram.model.linkDataArray;
    // var max = 499;
    // var count = 0;
    // while (count < max) {
    // count = makeTree(3, count, max, nodeDataArray, nodeDataArray[0]);
    // }
    //NavDiagram.model = new go.TreeModel(nodeDataArray);
}

function onSelectionChanged(node) {
    //var icon = node.findObject("Icon");
    if (node !== null) {
        if (node.isSelected) {
            //hide other nodes
            SetNodesVisibility(node.data.key, false);

        } else {
            //show all nodes
            SetNodesVisibility(0, true);

        }
    }
}

function SetNodesVisibility(skipNodeKey, visibilityStatus) {
    var it = PlanDiagram.findTreeRoots();

    while (it.next()) {
        console.log(it.key + ": " + it.value);
        var part = it.value;
        if (part instanceof go.Node) {
            if (part.data.key === skipNodeKey) {
                //return;
            } else {

                part.visible = visibilityStatus;

                nodeIteratorForVisibility(part, skipNodeKey, visibilityStatus);
            }
        }
    }
}
function nodeIteratorForVisibility(part, skipNodeKey, visibilityStatus) {
    var it = part.findNodesOutOf();

    while (it.next()) {
        var part2 = it.value;
        if (part2 instanceof go.Node) {
            if (part2.data.key === skipNodeKey) {
                //return;
            } else {

                part2.visible = visibilityStatus;

                nodeIteratorForVisibility(part2, skipNodeKey, visibilityStatus);
            }
        }
    }
}

function BuildNavMenus() {
    var nodeDataArray = buildNavBar();
    NavDiagram.model = new go.TreeModel(nodeDataArray);
}

function buildNavBar() {
    var it = PlanDiagram.findTreeRoots();
    var nodeDataArray = [];
    //var i = 0;
    while (it.next()) {
        //console.log(it.key + ": " + it.value);
        var part = it.value;
        if (part instanceof go.Node) {
            // i++;
            //part.isTreeExpanded = false;
            //var childdata = [{ key: '', text: '' }];
            //nodeDataArray.push(childdata);
            nodeDataArray = nodeIterator(nodeDataArray, part, part.data);
        }
    }
    return nodeDataArray;
}

function nodeIterator(nodeDataArray, part, parentdata) {
    nodeDataArray = makeTree(nodeDataArray, part, parentdata);
    var it = part.findNodesOutOf();
    while (it.next()) {
        var part2 = it.value;
        if (part2 instanceof go.Node) {
            nodeIterator(nodeDataArray, part2, part.data);
        }
    }
    return nodeDataArray;
}

function makeTree(nodeDataArray, node, parentdata) {

    var childdata = { key: node.data.key, parent: parentdata.key, text: node.data.text };
    nodeDataArray.push(childdata);

    return nodeDataArray;
}

function makeTreeExpanderButton() {
    var $$ = go.GraphObject.make;
    var button =
      $$("Button",  // NOTE: this creates a "Button" and extends it
        $$(go.Shape,  // the icon
          {
              name: "ButtonIcon",
              figure: "MinusLine",  // default value for isTreeExpanded is true
              desiredSize: new go.Size(6, 6)
          },
          // bind the Shape.figure to the Node.isTreeExpanded value using this converter:
          new go.Binding("figure", "isTreeExpanded",
                      function (exp, node) {
                          var fig = null;
                          var button = node.panel;
                          if (button) fig = exp ? button["_treeExpandedFigure"] : button["_treeCollapsedFigure"];
                          if (!fig) fig = exp ? "MinusLine" : "PlusLine";
                          return fig;
                      })
              .ofObject()),
        // assume initially not visible because there are no links coming out
        { visible: false },
        // bind the button visibility to whether it's not a leaf node
        new go.Binding("visible", "isTreeLeaf",
                       function (leaf) { return !leaf; })
            .ofObject()
      );

    // tree expand/collapse behavior
    button.click = function (e, obj) {
        var node = obj.part;  // OBJ is this button
        if (node instanceof go.Adornment) node = node.adornedPart;
        if (!(node instanceof go.Node)) return;
        var diagram = node.diagram;
        if (diagram === null) return;
        var cmd = diagram.commandHandler;
        if (node.isTreeExpanded) {
            if (!cmd.canCollapseTree(node)) return;
        } else {
            if (!cmd.canExpandTree(node)) return;
        }
        e.handled = true;
        if (node.isTreeExpanded) {
            cmd.collapseTree(node);
        } else {
            cmd.expandTree(node);
        }
    };
    return button;
}
// A custom command, for adding a new node to the building plan.
function Build(diagram) {
    // the object with the context menu, in this case a Node, is accessible as:
    var cmObj = PlanDiagram.toolManager.contextMenuTool.currentObject;
    var bnewnode = {};
    // but this function operates on all selected Nodes, not just the one at the mouse pointer.
    // Always make changes in a transaction, except when initializing the diagram.
    PlanDiagram.startTransaction("New Build");
    PlanDiagram.selection.each(function (e) {
        if (node instanceof go.Node) {  // ignore any selected Links and simple Parts
            // Examine and modify the data, not the Node directly.
            var part = e.subject.part;
            if (!(part instanceof go.Link))
                if (part.data.level === "1") {
                    alert("Neu Gebäude");
                } else if (part.data.level === "2") {
                    alert("Neu Ebene");
                } else if (part.data.level === "3") {
                    alert("Neu Raum");
                } else if (part.data.level === "4") {
                    alert("Neu Tür");
                } else if (part.data.level === "5") {
                    showMessage(" ");
                }
        }
    });
    PlanDiagram.commitTransaction("New Build");
}
function TerminalControls() {
    $("#ControlSection1").hide();
    $("#BuildingAreaDivNav").hide();
    $("#BuildingAreaDiv").hide();
    $("#btnNew").hide();
    $("#btnEdit").hide();
    $("#btnAddLocation").hide();
    $("#btnAddBuilding").hide();
    $("#btnSave").hide();
    $("#btnCancelDel").hide();
    $("#terminalDIV").show();
    $("#btnTake").show();
}
function BuildingPlanControls() {
    $("#ControlSection1").show();
    $("#BuildingAreaDivNav").show();
    $("#BuildingAreaDiv").show();
    $("#btnNew").show();
    $("#btnEdit").show();
    $("#btnAddLocation").show();
    $("#btnAddBuilding").show();
    $("#btnSave").show();
    $("#btnCancelDel").show();
    $("#terminalDIV").hide();
    $("#btnTake").hide();
}
function deleteNode() {
    // TAKE NOTE - This will get all selections so you need to handel  this
    // If you have multiple select enabled
    var nodeToDelete = PlanDiagram.selection.iterator.first();
    //var childNodes = getChildNodes(deletedItem);
    var childNodes = getChildNodes(nodeToDelete);
    //Remove linked children
    $.each(childNodes, function () {
        PlanDiagram.remove(this);
    });

    // Then also delete the actual node after the children was deleted
    // TAKE NOTE - This will delete all selections so you need to handle this
    // If you have multiple select enabled
    PlanDiagram.commandHandler.deleteSelection();
    saveChanges = true;
}
function getChildNodes(deleteNode) {
    var children = [];
    var allConnected = deleteNode.findNodesConnected();

    while (allConnected.next()) {
        var child = allConnected.value;

        // Check to see if this node is a child:
        if (isChildNode(deleteNode, child)) {
            // add the current child
            children.push(child);

            // Now call the recursive function again with the current child
            // to get its sub children
            //var subChildren = getChildrenNodes(child);
            var subChildren = getChildNodes(child);

            // add all the children to the children array
            $.each(subChildren, function () {
                children.push(this);
            });
        }
    }

    // return the children array
    return children;
}
function isChildNode(currNode, currChild) {
    var links = PlanDiagram.links.iterator;
    while (links.next()) {
        // Here simply look at the link to determine the direction by checking the direction against the currNode and the child node. If from is the current node and to the child node
        // then you know its a vhild
        var currentLinkModel = links.value.data;
        if (currentLinkModel.from === currNode.data.key && currentLinkModel.to === currChild.data.key) {
            return true;
        }
    }
    return false;
}
function deleteReadersAssigned(nodeToDelete) {
    var childNodes = getChildNodes(nodeToDelete);
    //$.each(childNodes, function () {
    //    //PlanDiagram.remove(this);
    //    if (this.data.level === "5") {
    //        var _nodeKey = this.data.key;
    //    }
    //});
    for (i = 0; i < childNodes.length; i++) {
        var _Node = childNodes[i];
        if (_Node.data.level === "5") {
            var _nodeKey = _Node.data.key;
            var buildingPlanId = dpllPlanNr.GetValue();
            DeleteAssignedReader(buildingPlanId, _nodeKey);
        }
    }
}
function RenameFloors(nodeToRename) {
    if (nodeToRename == null) return;
    var childNodes = getChildNodes(nodeToRename);
    for (i = 0; i < childNodes.length; i++) {
        var _Node = childNodes[i];
        if (_Node.data.level === "3") {
            var diagram = PlanDiagram;
            diagram.startTransaction("Set Desc");
            var nodedata = _Node.part.data;
            diagram.model.setDataProperty(nodedata, "Address", nodeToRename.data.Address);
            diagram.model.setDataProperty(nodedata, "Street", nodeToRename.data.Street);
            diagram.commitTransaction("Set Desc");

        }
    }
}
function RenameBuildingFloors(nodeToRename) {
    if (nodeToRename == null) return;
    var childNodes = getChildNodes(nodeToRename);
    for (i = 0; i < childNodes.length; i++) {
        var _Node = childNodes[i];
        if (_Node.data.level === "2" || _Node.data.level === "3") {
            var diagram = PlanDiagram;
            diagram.startTransaction("Set Desc");
            var nodedata = _Node.part.data;
            diagram.model.setDataProperty(nodedata, "Address", nodeToRename.data.Address);
            diagram.model.setDataProperty(nodedata, "Street", nodeToRename.data.Street);
            diagram.commitTransaction("Set Desc");

        }
    }
}
function hideMenuItems() {
    $("#readerMenu").hide();
    $("#readerLine").hide();
    $("#closeLine").show();
    $("#lblInfo").hide();
    $("#infoLine").hide();
    $("#switchingMenu").hide();
    $("#switchingLine").hide();
    $("#terminalMenu").hide();
    $("#terminalLine").hide();
    $("#readerActiveMenu").hide();
    $("#readerActiveLine").hide();

}
function showMenuItems() {

    $("#closeLine").show();
    $("#lblInfo").show();
    $("#infoLine").show();
    $("#terminalMenu").show();
    $("#terminalLine").show();
    $("#readerMenu").show();
    $("#readerLine").show();
    $("#deleteMenu").show();
    $("#deleteLine").show();
    $("#readerActiveMenu").show();
    $("#readerActiveLine").show();

    $("#switchingMenu").show();

}
function LocationLevel() {

    $("#newBuilding").show();
    $("#buildingLine").show();
    $("#deleteMenu").show();
    $("#deleteLine").show();
    $("#newFloor").hide();
    $("#floorLine").hide();
    $("#newRoom").hide();
    $("#roomLine").hide();
    $("#newDoor").hide();
    $("#doorLine").hide();
    $("#deleteLine").hide();

}
function BuildingLevel() {
    $("#newBuilding").hide();
    $("#buildingLine").hide();

    $("#newFloor").show();
    $("#floorLine").show();
    $("#deleteMenu").show();
    $("#deleteLine").show();
    $("#newRoom").hide();
    $("#roomLine").hide();
    $("#newDoor").hide();
    $("#doorLine").hide();
    $("#deleteLine").hide();
}
function FloorLevel() {
    $("#newBuilding").hide();
    $("#buildingLine").hide();
    $("#newFloor").hide();
    $("#floorLine").hide();

    $("#newRoom").show();
    $("#roomLine").show();
    $("#deleteMenu").show();

    $("#newDoor").hide();
    $("#doorLine").hide();
    $("#deleteLine").hide();
}
function RoomLevel() {
    $("#newBuilding").hide();
    $("#buildingLine").hide();
    $("#newFloor").hide();
    $("#floorLine").hide();
    $("#newRoom").hide();
    $("#roomLine").hide();
    $("#newDoor").show();
    $("#doorLine").show();
    $("#deleteMenu").show();
    $("#deleteLine").hide();
}
function DoorLevel() {
    $("#newBuilding").hide();
    $("#buildingLine").hide();
    $("#newFloor").hide();
    $("#floorLine").hide();
    $("#newRoom").hide();
    $("#roomLine").hide();
    $("#newDoor").hide();
    $("#doorLine").hide();
    $("#deleteLine").show();
}
function CloseTreeNodes() {
    var obj = PlanDiagram.selection.iterator.first();
    var node = obj.part;
    if (node instanceof go.Adornment) node = node.adornedPart;
    if (!(node instanceof go.Node)) return;

    var diagram = node.diagram;
    if (diagram === null) return;
    var cmd = diagram.commandHandler;
    if (node.isTreeExpanded) {
        if (!cmd.canCollapseTree(node)) return;
    } else {
        //if (!cmd.canExpandTree(node)) return;
    }
    //e.handled = true;
    if (node.isTreeExpanded) {
        cmd.collapseTree(node);
        NavDiagram.commandHandler.collapseTree(NavDiagram.findNodeForKey(node.data.key));
    } else {
        //cmd.expandTree(node);
        //NavDiagram.commandHandler.expandTree(NavDiagram.findNodeForKey(node.data.key));
    }
    diagram.currentTool.stopTool();
}
function CloseMenu() {
    var diagram = PlanDiagram;
    diagram.currentTool.stopTool();
}
function cxcommandTerminalInfo() {
    var BuildingPlanId = dpllPlanNr.GetValue();
    var DoorNodeKey = selectedNodeKey;
    var diagram = PlanDiagram;
    if (!(diagram.currentTool instanceof go.ContextMenuTool)) return;
    if (objectLevel == 5) {

        diagram.currentTool.stopTool();

        var data = { BuildingPlanId: BuildingPlanId, DoorNodeKey: DoorNodeKey };

        $.ajax({
            type: "POST",
            async: false,
            url: "Gebaudeplan.aspx/PassVariablesInfo",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(data),
            success: function () {
                window.location.href = "BuildingPlanTerminalInfo.aspx";
            }
        });

    }
    else {
        diagram.currentTool.stopTool();
    }

}
function AssignReader(id) {
    //var BuildingPlanId = dpllPlanNr.GetValue();
    var BuildingPlanId = id;
    var DoorNodeKey = selectedNodeKey;
    var LocationId = BuildingPlanDetais.GetRow(0).cells[0].childNodes[0].textContent;
    var BuildingId = BuildingPlanDetais.GetRow(0).cells[1].childNodes[0].textContent;
    var FloorID = BuildingPlanDetais.GetRow(0).cells[2].childNodes[0].textContent
    var RoomId = BuildingPlanDetais.GetRow(0).cells[3].childNodes[0].textContent
    var diagram = PlanDiagram;
    if (!(diagram.currentTool instanceof go.ContextMenuTool)) return;
    if (objectLevel == 5) {
        //TerminalControls();
        diagram.currentTool.stopTool();


        var data = { BuildingPlanId: BuildingPlanId, DoorNodeKey: DoorNodeKey, LocationId: LocationId, BuildingId: BuildingId, FloorId: FloorID, RoomId: RoomId };

        $.ajax({
            type: "POST",
            async: false,
            url: "Gebaudeplan.aspx/PassVariables",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(data),
            success: function () {
                window.location.href = "AssignReader.aspx";
            }
        });

    }
    else {
        diagram.currentTool.stopTool();
    }
}

function CheckIfReaderActive(buildingPlanId, doorID) {
    var data = { buildingPlanId: buildingPlanId, doorID: doorID };

    $.ajax({
        type: "POST",
        async: false,
        url: "Gebaudeplan.aspx/CheckIfReaderActive",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            readerIsActive = result.d;
        }
    });
}
function CheckIfReaderAssigned(buildingPlanId, doorID) {
    var data = { buildingPlanId: buildingPlanId, doorID: doorID };

    $.ajax({
        type: "POST",
        async: false,
        url: "Gebaudeplan.aspx/CheckIfReaderAssigned",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            assigned = result.d;
        }
    });
}
// save custom method before assigning terminal readers
function saveCustom() {
    var str = '{ "position": "' + go.Point.stringify(PlanDiagram.position) + '",\n  "model": ' + PlanDiagram.model.toJson() + ' }';
    if (dpllPlanNr.GetValue() === "0") {
        var PlanNrExists = CheckIfPlanNrExists($("#txtPlanNr").val().trim());
        switch (PlanNrExists) {
            case false:
                PageMethods.CreateBuildingPlan($("#txtPlanNr").val(), $("#txtPlanName").val(), str, currentID, OnSaveCustom_Callback);
                break;
            case true:
                PlanNumberExistsPrompt();
                break;
            default:
                //do nothing
                break;
        }

    } else {
        PageMethods.UpdateBuildingPlan(dpllPlanNr.GetValue(), $("#txtPlanNr").val(), $("#txtPlanName").val(), str, currentID, OnEditCustom_Callback);
    }
}

function OnSaveCustom_Callback(response) {
    //$("#dpllPlanNr").append($('<option></option>').val(response.ID).html(response.PlanNr));
    //$("#dplPlanName").append($('<option></option>').val(response.ID).html(response.PlanName));

    //$("#dplPlanName").val(response.ID);
    //$("#dpllPlanNr").val(response.ID);

    $("#txtPlanNr").val(response.PlanNr);
    $("#txtPlanName").val(response.PlanName);
    AssignReader(response.ID);
    dpllPlanNr.PerformCallback(response.ID);
    dplPlanName.PerformCallback(response.ID);
}

function OnEditCustom_Callback(response) {
    //$("#dpllPlanNr option:selected").html(response.PlanNr);
    //$("#dplPlanName option:selected").html(response.PlanName);
    //$("#dplPlanName").val(response.ID);
    //$("#dpllPlanNr").val(response.ID);

    $("#txtPlanNr").val(response.PlanNr);
    $("#txtPlanName").val(response.PlanName);
    AssignReader(response.ID);
    dpllPlanNr.PerformCallback(response.ID);
    dplPlanName.PerformCallback(response.ID);
}
function DeleteAssignedReader(buildingPlanId, doorID) {
    var data = { buildingPlanId: buildingPlanId, doorID: doorID };

    $.ajax({
        type: "POST",
        async: false,
        url: "Gebaudeplan.aspx/DeleteReaderAssigned",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {

        }
    });
}


