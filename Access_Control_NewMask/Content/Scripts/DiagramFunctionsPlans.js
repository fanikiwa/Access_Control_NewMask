
//global variables



// Define a common checkbox button; the first argument is the name of the data property
// to which the state of this checkbox is data bound.  If the first argument is not a string,
// it raises an error.  If no data binding of the checked state is desired,
// pass an empty string as the first argument.
// $("CheckBoxButton", "dataPropertyName", ...)
go.GraphObject.defineBuilder("CheckBoxButton", function (args) {
    // process the one required string argument for this kind of button
    var propname = go.GraphObject.takeBuilderArgument(args);
    var $ = go.GraphObject.make;  // for conciseness in defining templates
    var button = $("Button",
                   {
                       "ButtonBorder.fill": "white",
                       "ButtonBorder.stroke": "gray",
                       width: 14,
                       height: 14
                   },
                   $(go.Shape,
                     {
                         name: "ButtonIcon",
                         geometryString: "M0 4 L3 9 9 0",  // a "check" mark
                         strokeWidth: 2,
                         stretch: go.GraphObject.Fill,  // this Shape expands to fill the Button
                         geometryStretch: go.GraphObject.Uniform,  // the check mark fills the Shape without distortion
                         visible: false  // visible set to false: not checked, unless data.PROPNAME is true
                     },
                     // create a data Binding only if PROPNAME is supplied and not the empty string
                     (propname !== "" ? new go.Binding("visible", propname).makeTwoWay() : []))
                 );
    button.click = function (e, obj) {
        e.handled = true;
        var shape = obj.findObject("ButtonIcon");
        var reader_assigned = obj.part.data.readerAssigned;

        //shape.diagram.startTransaction("checkbox");
        //shape.visible = !shape.visible;  // this toggles data.checked due to TwoWay Binding
        // support extra side-effects without clobbering the click event handler:

        //if (typeof obj["_doClick"] === "function") obj["_doClick"](e, obj);
        //shape.diagram.commitTransaction("checkbox");
        //my changes
        //var ActiveStatus = obj.part.data.laserChoice;
        //var doorId = obj.part.data.key;
        //ChangeReaderStatus(obj, ActiveStatus);
        //ActivateDeactivateReader(obj, ActiveStatus);
        //saveChanges = true;

    };
    return button;
});
// This defines a whole check-box -- including both a "CheckBoxButton" and whatever you want as the check box label.
// Note that mouseEnter/mouseLeave/click events apply to everything in the panel, not just in the "CheckBoxButton".
go.GraphObject.defineBuilder("CheckBoxPanel", function (args) {
    // process the one required string argument for this kind of button
    var propname = go.GraphObject.takeBuilderArgument(args);
    var $ = go.GraphObject.make;  // for conciseness in defining templates
    var button = $("CheckBoxButton", propname,
                   {
                       name: "Button",  // bound to this data property
                       margin: new go.Margin(0, 1, 0, 0)
                   }
                 );
    var box = $(go.Panel, "Horizontal",
                button,
                {
                    isActionable: true,
                    margin: 1,
                    // transfer CheckBoxButton properties over to this new CheckBoxPanel
                    "_buttonFillNormal": button["_buttonFillNormal"],
                    "_buttonStrokeNormal": button["_buttonStrokeNormal"],
                    "_buttonFillOver": button["_buttonFillOver"],
                    "_buttonStrokeOver": button["_buttonStrokeOver"],
                    //mouseEnter: button.mouseEnter,
                    //mouseLeave: button.mouseLeave,
                    click: button.click,
                    "_buttonClick": button.click  // save original Button behavior, for use in a Panel.click event handler
                }
              );
    // avoid potentially conflicting event handlers on the "CheckBoxButton"
    button.mouseEnter = null;
    button.mouseLeave = null;
    button.click = null;
    return box;
});


