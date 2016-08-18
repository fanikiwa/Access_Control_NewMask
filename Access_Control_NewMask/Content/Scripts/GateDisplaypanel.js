$(function () {
    $("#chkPersonnel").click(function () {
        if ($("#chkPersonnel")[0].checked === true) {
            $("#chkVisitor")[0].checked = false;
            $("#chkMember")[0].checked = false;
            $("#chkShowAll")[0].checked = false;
            FilterBookings();
        }
        else if ($("#chkPersonnel")[0].checked === false) {
            $("#chkShowAll")[0].checked = true;
            FilterBookings();
        }
    });

    $("#chkMember").click(function () {
        if ($("#chkMember")[0].checked === true) {
            $("#chkVisitor")[0].checked = false;
            $("#chkPersonnel")[0].checked = false;
            $("#chkShowAll")[0].checked = false;
            FilterBookings();
        }
        else if ($("#chkMember")[0].checked === false) {
            $("#chkShowAll")[0].checked = true;
            FilterBookings();
        }
    });

    $("#chkVisitor").click(function () {
        if ($("#chkVisitor")[0].checked === true) {
            $("#chkPersonnel")[0].checked = false;
            $("#chkMember")[0].checked = false;
            $("#chkShowAll")[0].checked = false;
            FilterBookings();
        }
        else if ($("#chkVisitor")[0].checked === false) {
            $("#chkShowAll")[0].checked = true;
            FilterBookings();
        }
    });

    $("#chkShowAll").click(function () {
        if ($("#chkShowAll")[0].checked === true) {
            $("#chkVisitor")[0].checked = false;
            $("#chkMember")[0].checked = false;
            $("#chkPersonnel")[0].checked = false;
            FilterBookings();
        }
        else if ($("#chkShowAll")[0].checked === false) {
            $("#chkShowAll")[0].checked = true;
            FilterBookings();
        }
    });
    $("#chkPresent").click(function () {
        if ($("#chkPresent")[0].checked === true) {
            //$("#chkAbsent")[0].checked = false;
           
            FilterBookings();
        }
        else if ($("#chkPresent")[0].checked === false) {
          
            FilterBookings();
        }
    });
    $("#chkAbsent").click(function () {
        if ($("#chkAbsent")[0].checked === true) {
            //$("#chkPresent")[0].checked = false;

            FilterBookings();
        }
        else if ($("#chkAbsent")[0].checked === false) {

            FilterBookings();
        }
    });
    $("#btnHelp").click(function (e) {
        e.preventDefault();
    });
});
function FilterBookings() {
    var filter = 0;
    if ($("#chkPersonnel")[0].checked === true) {
        filter = 1;
    }
    if ($("#chkVisitor")[0].checked === true) {
        filter = 2;
    }
    if ($("#chkMember")[0].checked === true) {
        filter = 3;
    }
    if ($("#chkShowAll")[0].checked === true) {
        filter = 0;
    }
    var isPresent = 0;
    if ($("#chkAbsent")[0].checked === true) {
        isPresent = 1;
    }
    if ($("#chkPresent")[0].checked === true) {
        isPresent = 2;
    }
    if ($("#chkPresent")[0].checked === false && $("#chkAbsent")[0].checked === false) {
        isPresent = 3;
    }
    if ($("#chkPresent")[0].checked === true && $("#chkAbsent")[0].checked === true) {
        isPresent = 4;
    }
    
    var param = filter + ";" + isPresent;
    grdBookings.PerformCallback(param);
}