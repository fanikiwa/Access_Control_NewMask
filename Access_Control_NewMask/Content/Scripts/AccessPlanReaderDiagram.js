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
var selectedNodeKey = 0;
var objectLevel = 0;
var assigned = 0;
var readerIsActive = false;
var accessPlanActive = false;
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


function CreatePlan(divHtmlElement) {
    //ref: http://www.gojs.net/latest/intro/buildingObjects.html

    PlanDiagram = $$(go.Diagram, divHtmlElement,
      {
          allowMove: false,
          allowDelete: false,
          allowCopy: false,
          allowTextEdit: false,
          initialContentAlignment: go.Spot.TopLeft,
          "InitialLayoutCompleted": loadDiagramProperties,
          "toolManager.mouseWheelBehavior": go.ToolManager.WheelZoom,
          //"clickCreatingTool.archetypeNodeData": { text: "new node" }

      });

    // 1. location node
    var locationTemplate =
     $$(go.Node, "Horizontal",
             { background: "white" },
              { width: 205, height: 70 },
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

    //Initial Door Node
    //    //5. door  node
    //    var doorTemplate =
    //    $$(go.Node, "Horizontal",
    //              { background: "white" },
    //               { width: 385, height: 70 },

    //                $$(go.Picture,
    //                { margin: 1, width: 40, height: 40, background: "white" },
    //                new go.Binding("source")),
    //                 // level property
    //                $$(go.TextBlock, "0", { row: 0, column: 0, visible: false }, new go.Binding("text", "level")),

    //   $$(go.Panel, "Auto",
    //   $$(go.Shape, { fill: "white", stroke: "black", strokeWidth: 1, height: 60, width: 120 }),
    //            $$(go.Panel, "Table",
    //          { defaultAlignment: go.Spot.Left, defaultColumnSeparatorStroke: "black" },
    //          // level property
    //                $$(go.TextBlock, "0", { row: 0, column: 0, visible: false }, new go.Binding("text", "level")),
    //                //node name property property
    //                $$(go.TextBlock, "DefaultText",
    //                { row: 1, column: 0, margin: 1, stroke: "black", font: "12px sans-serif", width: 100, editable: true, name: "FirstDescription", isMultiline: false },
    //                new go.Binding("text", "text").makeTwoWay()),
    //                 //node name property property
    //                $$(go.TextBlock, "DefaultText",
    //                { row: 2, column: 0, margin: 1, stroke: "black", font: "12px sans-serif", width: 100, editable: true, name: "SecondDescription", isMultiline: false },
    //                new go.Binding("text", "firstDescription").makeTwoWay()),
    //                 //node name property property
    //                $$(go.TextBlock, "DefaultText",
    //                { row: 3, column: 0, margin: 1, stroke: "black", font: "12px sans-serif", width: 100, editable: true, name: "ThirdDescription", isMultiline: false },
    //                new go.Binding("text", "secondDescription").makeTwoWay())
    //)

    //  ),
    //   $$(go.Panel, "Auto",
    //   $$(go.Shape, { fill: "white", stroke: "black", strokeWidth: 1, height: 60, width: 169 }),
    //           $$(go.Panel, "Table",
    //          { defaultAlignment: go.Spot.Left, defaultColumnSeparatorStroke: "black", defaultRowSeparatorStroke: "black" },

    //         $$(go.RowColumnDefinition,
    //          { row: 1, separatorStrokeWidth: 1, separatorStroke: "black" }),
    //        $$(go.RowColumnDefinition,
    //          { column: 1, separatorStrokeWidth: 1, separatorStroke: "black" }),
    //          $$(go.Panel, "TableRow", { row: 1 },
    //          $$(go.TextBlock, "Leser", { column: 0, margin: 2 }),
    //          $$("CheckBoxPanel", "laserChoice", { column: 1, margin: 2 }),
    //          $$(go.TextBlock, "", { column: 2, margin: 2 }, new go.Binding("text", "ReaderType")),
    //           $$(go.Picture,
    //              { margin: 2, width: 15, height: 15, column: 3, alignment: go.Spot.Right, background: "white", visible: true },
    //              new go.Binding("source", "readerStatusImg"))
    //        ),
    //        $$(go.Panel, "TableRow", { row: 2 },
    //          $$(go.TextBlock, "Zutrittskalender", { column: 0, margin: 2 }),
    //          $$("CheckBoxPanel", "accessCalenderChoice", { column: 1, margin: 2 }),
    //          $$(go.TextBlock, "aktiv", { column: 2, margin: 2 }),
    //          $$(go.Picture,
    //           { margin: 2, width: 15, height: 15, column: 3, alignment: go.Spot.Right, background: "white" },
    //           new go.Binding("source", "accessCalenderImg"))
    //        ),
    //        $$(go.Panel, "TableRow", { row: 3 },
    //          $$(go.TextBlock, "Schaltzeiten", { column: 0, margin: 2 }),
    //          $$("CheckBoxPanel", "swichTimeChoice", { column: 1, margin: 2 }),
    //          $$(go.TextBlock, "aktiv", { column: 2, margin: 2 }),
    //          $$(go.Picture,
    //              { margin: 2, width: 15, height: 15, column: 3, alignment: go.Spot.Right, background: "white" },
    //              new go.Binding("source", "swichTimeImg"))
    //        )
    //        )


    //  ),
    //  $$(go.Panel, "Auto",
    //   $$(go.Shape, { fill: "white", stroke: "black", strokeWidth: 1, height: 60, width: 45 }),
    //            $$(go.Panel, "Vertical",
    //          {},
    //           $$(go.Picture,
    //                { margin: 2, width: 32, height: 32, background: "white", alignment: go.Spot.Center },
    //                new go.Binding("source", "DoorStatusImg")),
    //              $$("CheckBoxPanel", "DoorStatus", { margin: 2, alignment: go.Spot.Center })
    //)

    //  ),

    //5. door  node
    var doorTemplate =
    $$(go.Node, "Horizontal",
              { background: "white" },
              // { width: 385, height: 70 },
               { width: 395, height: 70 },

                $$(go.Picture,
                { margin: 1, width: 40, height: 40, background: "white" },
                new go.Binding("source")),
                 // level property
                $$(go.TextBlock, "0", { row: 0, column: 0, visible: false }, new go.Binding("text", "level")),

   $$(go.Panel, "Auto",
   $$(go.Shape, { fill: "white", stroke: "black", strokeWidth: 1, height: 60, width: 155 }),
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
   $$(go.Shape, { fill: "white", stroke: "black", strokeWidth: 1, height: 60, width: 40 }),
           $$(go.Panel, "Table",
          { defaultAlignment: go.Spot.Left, defaultColumnSeparatorStroke: "black" },
        $$(go.RowColumnDefinition,
          { column: 1, separatorStrokeWidth: 1, separatorStroke: "black" }),
          $$(go.Panel, "TableRow", { row: 1 },
           $$(go.Picture,
              { margin: 2, width: 30, height: 35, column: 0, alignment: go.Spot.Right, background: "white" },
              new go.Binding("source", "directionImg"))
        )
        )

  ),

     $$(go.Panel, "Auto",
   $$(go.Shape, { fill: "white", stroke: "black", strokeWidth: 1, height: 60, width: 50 }),
           $$(go.Panel, "Table",
          { defaultAlignment: go.Spot.Left, defaultColumnSeparatorStroke: "black" },
        $$(go.RowColumnDefinition,
          { column: 1, separatorStrokeWidth: 1, separatorStroke: "black" }),
          $$(go.Panel, "TableRow", { row: 1 },
           $$(go.Picture,
              { margin: 2, width: 30, height: 30, column: 0, alignment: go.Spot.Right, background: "white" },
              new go.Binding("source", "readerStatusImg"))

        )

        )
  ),

   $$(go.Panel, "Auto",
   $$(go.Shape, { fill: "white", stroke: "black", strokeWidth: 1, height: 60, width: 50 }),
           $$(go.Panel, "Table",
          { defaultAlignment: go.Spot.Left, defaultColumnSeparatorStroke: "black" },
        $$(go.RowColumnDefinition,
          { column: 1, separatorStrokeWidth: 0, separatorStroke: "white" }),
          $$(go.Panel, "TableRow", { row: 1 },
           $$(go.Picture,
           { margin: 2, width: 50, height: 57, column: 0, alignment: go.Spot.Right, background: "white" },
           new go.Binding("source", "accessPlanImg"))
        )
        )
  ),
   $$(go.Panel, "Auto",
   $$(go.Shape, { fill: "white", stroke: "black", strokeWidth: 1, height: 60, width: 50 }),
           $$(go.Panel, "Table",
          { defaultAlignment: go.Spot.Left, defaultColumnSeparatorStroke: "black" },
        $$(go.RowColumnDefinition,
          { column: 1, separatorStrokeWidth: 1, separatorStroke: "black" }),
          $$(go.Panel, "TableRow", { row: 1 },
           $$(go.Picture,
              { margin: 2, width: 40, height: 40, column: 0, alignment: go.Spot.Right, background: "white" },
              new go.Binding("source", "passBackImg"))

        )

        )
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
            var objs = obj.data.key;
            selectedNodeKey = obj.data.key;
            objectLevel = obj.data.level;
            if (obj.data.level === "1") {

                hideMenuItems();
            } else if (obj.data.level === "2") {

                hideMenuItems();
            } else if (obj.data.level === "3") {

                hideMenuItems();
            } else if (obj.data.level === "4") {

                hideMenuItems();
            } else if (obj.data.level === "5") {
                //check if door is assigned a reader
                CheckIfReaderAssigned(dpllPlanNr.GetValue(), selectedNodeKey);

                var i = assigned;
                if (i === 1) {
                    document.getElementById("chkTerminal").disabled = false;
                    document.getElementById("chkTA_Come").disabled = false;
                    document.getElementById("chkTA_Go").disabled = false;
                }
                else {
                    document.getElementById("chkTerminal").disabled = true;
                    document.getElementById("chkTA_Come").disabled = true;
                    document.getElementById("chkTA_Go").disabled = true;
                }
                //check reader pass back number
                CheckPassBackNr(dpllPlanNr.GetValue(), selectedNodeKey);
                var passBackNumber = _PassBackNr;
                switch (passBackNumber) {
                    case 0:
                        document.getElementById("chkFirstReader").disabled = true;
                        document.getElementById("chkSecondReader").disabled = true;
                        break;
                    case 1:
                        document.getElementById("chkFirstReader").disabled = false;
                        document.getElementById("chkSecondReader").disabled = true;
                        break;
                    case 2:
                        document.getElementById("chkFirstReader").disabled = true;
                        document.getElementById("chkSecondReader").disabled = false;
                        break;
                    case 3:
                        document.getElementById("chkFirstReader").disabled = true;
                        document.getElementById("chkSecondReader").disabled = true;
                        document.getElementById("chkNothing").disabled = true;
                        break;
                    default:

                }
                showMenuItems();
                HidePassBackMenus();
            }
        }
        else {

        }

        if (obj !== null) {
            //var objStatus = obj.data.Readerstatus;
            //check if access plan is active
            CheckIfAccessPlanActive(dpllPlanNr.GetValue(), selectedNodeKey, $("#ddlAccessProfileNumber option:selected").val());
            if (accessPlanActive === true) {
                document.getElementById("chkTerminal").checked = true;

            }
            else {
                document.getElementById("chkTerminal").checked = false;
            }
            //check assigned pass back number
            CheckAssignedPassBackNr(dpllPlanNr.GetValue(), selectedNodeKey);
            var assignedPassBackNumber = _assignedPassBackNr;
            switch (assignedPassBackNumber) {
                case 0:
                    document.getElementById("chkFirstReader").checked = false;
                    document.getElementById("chkSecondReader").checked = false;
                    document.getElementById("chkNothing").checked = true;
                    break;
                case 1:
                    document.getElementById("chkFirstReader").checked = true;
                    document.getElementById("chkSecondReader").checked = false;
                    document.getElementById("chkNothing").checked = false;
                    break;
                case 2:
                    document.getElementById("chkFirstReader").checked = false;
                    document.getElementById("chkSecondReader").checked = true;
                    document.getElementById("chkNothing").checked = false;
                    break;
                case 3:
                    document.getElementById("chkFirstReader").checked = false;
                    document.getElementById("chkSecondReader").checked = false;
                    document.getElementById("chkNothing").checked = true;
                    break;
                default:

            }
            GetComeGoValues(dpllPlanNr.GetValue(), selectedNodeKey);
            var comeGoValues = _comeGoValues;
            if (comeGoValues !== null) {
                if (comeGoValues.TA_Come === true) {
                    document.getElementById("chkTA_Come").checked = true;

                }
                else {
                    document.getElementById("chkTA_Come").checked = false;
                }
                if (comeGoValues.TA_Go === true) {
                    document.getElementById("chkTA_Go").checked = true;

                }
                else {
                    document.getElementById("chkTA_Go").checked = false;
                }
            }
        }



        // Show only the relevant buttons given the current state.
        if (obj !== null && allowZUTEdit === true) {
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
                var posY = parseInt(docloc.y);

                var mousePt = diagram.lastInput.viewPoint;
                var ctxmenuposx = parseInt($("#BuildingAreaDiv").position().left) + parseInt(mousePt.x);
                var ctxmenuposy = parseInt($("#BuildingAreaDiv").position().top) + parseInt(mousePt.y);
                //cxElement.style.left = (posX+715) + "px";
                if (ctxmenuposx > 1735) {
                    cxElement.style.left = (ctxmenuposx - 100) + "px";
                }
                else {
                    cxElement.style.left = (ctxmenuposx) + "px";
                }
                //cxElement.style.top = (ctxmenuposy) + "px";
                if (posY < 400) {
                    cxElement.style.top = (posY + 290) + "px";
                }
                else {
                    cxElement.style.top = (posY - 20) + "px";
                }


                // Remember that there is now a context menu showing
                this.currentContextMenu = contextmenu;
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
    PlanDiagram.addDiagramListener("ObjectDoubleClicked",
        function (e) {

            alert("Bezeichnungen können Sie nur \n    im Gebäudeplan ändern.");
        });
    PlanDiagram.addDiagramListener("ObjectSingleClicked",
        function (e) {

            getLocalizedText("newString");
            var newString = levelCaption;

            var part = e.subject.part;
            if (!(part instanceof go.Link))
                if (part.data.level === "1") {
                    getLocalizedText("building");

                    showMessage(newString + " " + levelCaption);

                    //showMessage("Neu Gebäude");
                } else if (part.data.level === "2") {
                    getLocalizedText("floor");

                    showMessage(newString + " " + levelCaption);
                    //showMessage("Neu Ebene");
                } else if (part.data.level === "3") {
                    getLocalizedText("room");

                    showMessage(newString + " " + levelCaption);
                    //showMessage("Neu Raum");
                } else if (part.data.level === "4") {
                    getLocalizedText("door");

                    showMessage(newString + " " + levelCaption);
                    //showMessage("Neu Tür");
                } else if (part.data.level === "5") {
                    var doorText = part.data.text;
                    showMessage(doorText);
                }
        });

    var customEditor = document.getElementById("txtEditor");


    customEditor.onActivate = function () {
        customEditor.width = customEditor.textEditingTool.textBlock.width;
        customEditor.value = customEditor.textEditingTool.textBlock.text;
        // Do a few different things when a user presses a key
        customEditor.addEventListener("keydown", function (e) {
            var keynum = e.which;
            var tool = customEditor.textEditingTool;
            if (tool === null) return;
            if (keynum == 13) { // Accept on Enter
                //tool.acceptText(go.TextEditingTool.Enter);
                tool.acceptText(go.TextEditingTool.Tab);// custom use tab event instead
                e.preventDefault();
                //return
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
function cxcommandAddBuilding(val) {


}

function cxcommandEdit(val) {

    PlanDiagram.commandHandler.editTextBlock();
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
            $("#btnSave").removeAttr("disabled");
            break;

            //case "Info": diagram.commandHandler.pasteSelection(diagram.lastInput.documentPoint); break;
            //case "Delete": diagram.commandHandler.deleteSelection(); break;
            //case "Color": break;
    }
    diagram.currentTool.stopTool();
}

// A custom command, for changing the color of the selected node(s).
function changeStatus(diagram) {
    // the object with the context menu, in this case a Node, is accessible as:
    var cmObj = diagram.toolManager.contextMenuTool.currentObject;
    // but this function operates on all selected Nodes, not just the one at the mouse pointer.

    // Always make changes in a transaction, except when initializing the diagram.
    diagram.startTransaction("changeStatus");
    //node = diagram.selection;
    diagram.selection.each(function (node) {
        if (node instanceof go.Node) {  // ignore any selected Links and simple Parts
            // Examine and modify the data, not the Node directly.
            var data = node.data;
            if (data.color === "red") {
                // Call setDataProperty to support undo/redo as well as
                // automatically evaluating any relevant bindings.
                diagram.model.setDataProperty(data, "color", go.Brush.randomColor());
            } else {
                diagram.model.setDataProperty(data, "color", "red");
            }
        }
    });
    diagram.commitTransaction("changeStatus");
}



function loadDiagramProperties(e) {

}



// save a model to and load a model from Json text, displayed below the Diagram
function save() {
    var str = '{ "position": "' + go.Point.stringify(PlanDiagram.position) + '",\n  "model": ' + PlanDiagram.model.toJson() + ' }';
    //document.getElementById("mySavedDiagram").value = str;
    if (dpllPlanNr.GetValue() === "0") {

    } else {
        PageMethods.UpdateBuildingPlan(dpllPlanNr.GetValue(), $("#txtPlanNr").val(), $("#txtPlanName").val(), str, currentID, OnEdit_Callback);
    }
}



function OnEdit_Callback(response) {
    //$("#dpllPlanNr option:selected").html(response.PlanNr);
    //$("#dplPlanName option:selected").html(response.PlanName);
    //$("#dplPlanName").val(response.ID);
    //$("#dpllPlanNr").val(response.ID);

    //$("#txtPlanNr").val(response.PlanNr);
    //$("#txtPlanName").val(response.PlanName);
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
        var it = PlanDiagram.findTreeRoots();
        while (it.next()) {
            //console.log(it.key + ": " + it.value);
            var part = it.value;  // part is now a Node or a Group or a Link or maybe a simple Part
            if (part instanceof go.Node) { //part.isTreeExpanded = true;
            }
        }
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


    NavDiagram.linkTemplate = $$(go.Link);

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
        console.log(it.key + ": " + it.value);
        var part = it.value;
        if (part instanceof go.Node) {

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


function DoorChangeStatusActive() {
    var diagram = PlanDiagram;
    var obj = diagram.toolManager.contextMenuTool.currentObject;
    diagram.startTransaction("changed status");
    // get the context menu that holds the button that was clicked
    var contextmenu = obj.part;
    // get the node data to which the Node is data bound
    var nodedata = contextmenu.data;
    // assign status
    var newStatus = true;
    var newStatusImg = "../../Images/FormImages/bp_green24px.png";
    // modify the node data
    // this evaluates data Bindings and records changes in the UndoManager
    //diagram.model.setDataProperty(nodedata, "laserChoice", newStatus);
    diagram.model.setDataProperty(nodedata, "readerStatusImg", newStatusImg);
    diagram.commitTransaction("changed status");
}
function DoorChangeStatusInactive() {
    var diagram = PlanDiagram;
    var obj = diagram.toolManager.contextMenuTool.currentObject;
    diagram.startTransaction("changed status");
    // get the context menu that holds the button that was clicked
    var contextmenu = obj.part;
    // get the node data to which the Node is data bound
    var nodedata = contextmenu.data;
    // assign status
    var newStatus = false;
    var newStatusImg = "../../Images/FormImages/bp_red24px.png";
    // modify the node data
    // this evaluates data Bindings and records changes in the UndoManager
    diagram.model.setDataProperty(nodedata, "readerStatusImg", newStatusImg);
    diagram.commitTransaction("changed status");
}
function hideMenuItems() {
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

    $("#lblpassBack").hide();
    $("#passBackLine").hide();
    $("#readerOne").hide();
    $("#readerOneLine").hide();
    $("#readerTwo").hide();
    $("#readerTwoLine").hide();
    $("#nothing").hide();
    $("#nothingLine").hide();
    $("#closeMenuTwo").hide();

    $("#comeMenu").hide();
    $("#comeMenuLine").hide();
    $("#goMenu").hide();
    $("#goMenLine").hide();
}
function showMenuItems() {
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

    $("#lblpassBack").show();
    $("#passBackLine").show();
    $("#readerOne").show();
    $("#readerOneLine").show();
    $("#readerTwo").show();
    $("#readerTwoLine").show();
    $("#nothing").show();
    $("#nothingLine").show();
    $("#closeMenuTwo").show();
    $("#comeMenu").show();
    $("#comeMenuLine").show();
    $("#goMenu").show();
    $("#goMenLine").show();
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
            url: "AccessPlanReader.aspx/PassVariables",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(data),
            success: function () {
                window.location.href = "AccessPlanTerminalInfo.aspx";
            }
        });

    }
    else {
        diagram.currentTool.stopTool();
    }


}
function ActivateReaderStatus() {
    var buildingPlanId = dpllPlanNr.GetValue();
    var doorID = selectedNodeKey;
    var active = true;
    var diagram = PlanDiagram;
    var data = { buildingPlanId: buildingPlanId, doorID: doorID, active: active };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanReader.aspx/ActivateDeactivateReaders",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function () {
            DoorChangeStatusActive();
            save();
        }
    });
}
function DeactiveReaderStatus() {
    var buildingPlanId = dpllPlanNr.GetValue();
    var doorID = selectedNodeKey;
    var active = false;
    var diagram = PlanDiagram;
    var data = { buildingPlanId: buildingPlanId, doorID: doorID, active: active };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanReader.aspx/ActivateDeactivateReaders",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function () {
            DoorChangeStatusInactive();
            save();
        }
    });
}
function CheckIfReaderAssigned(buildingPlanId, doorID) {
    var data = { buildingPlanId: buildingPlanId, doorID: doorID };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanReader.aspx/CheckIfReaderAssigned",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            assigned = result.d;
        }
    });
}
function CheckIfReaderActive(buildingPlanId, doorID) {
    var data = { buildingPlanId: buildingPlanId, doorID: doorID };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanReader.aspx/CheckIfReaderActive",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            readerIsActive = result.d;
        }
    });
}
function ActivateDeactivateAccessProfile(ProfileActive) {
    var diagram = PlanDiagram;
    var obj = diagram.toolManager.contextMenuTool.currentObject;
    var buildingPlanId = dpllPlanNr.GetValue();
    var AccessPlanId = $("#ddlAccessProfileNumber option:selected").val();
    var doorID = selectedNodeKey;
    var active = ProfileActive;

    var data = { buildingPlanId: buildingPlanId, doorID: doorID, AccessPlanId: AccessPlanId, PlanActive: active };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanReader.aspx/ActivateDeactivateAccessProfile",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function () {
            ChangeReaderProfileStatus(obj, active);

        }
    });
}
function ChangeReaderProfileStatus(obj, AccessPlanStatus) {
    if (obj !== null) {
        var diagram = PlanDiagram;
        diagram.startTransaction("access profile");
        var statusImage = "";
        var inactiveImg = "../../Images/FormImages/ClosedDoorRed.png";
        var activeImg = "../../Images/FormImages/OpenDoorGreen.png";


        // access plan image
        if (AccessPlanStatus === true) {
            accessPlanImg = activeImg;
        }
        else {
            accessPlanImg = inactiveImg;
        }

        var nodedata = obj.part.data;
        diagram.model.setDataProperty(nodedata, "accessPlanImg", accessPlanImg);
        diagram.commitTransaction("access profile");
    }

}
function CheckIfAccessPlanActive(buildingPlanId, doorID, accessPlanId) {
    var data = { buildingPlanId: buildingPlanId, doorID: doorID, accessPlanId: accessPlanId };

    $.ajax({
        type: "POST",
        async: false,
        url: "AccessPlanReader.aspx/CheckIfAccessPlanActive",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
            accessPlanActive = result.d;
        }
    });
}
function CloseMenu() {
    var diagram = PlanDiagram;
    diagram.currentTool.stopTool();
}