$(document).ready(function () {

    //$("#btnBack").click(function (evt) {
    //    evt.preventDefault();
    //    document.location.href = "/Index.aspx";
    //});

    $("#btnpersonaldaten").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/PersonalInactive.aspx";
    });
    $("#btnpersonalbogen").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/PersonalInactiveAdditionalInfo.aspx";
    });
    $("#btntarif").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/PersonalTarrifInActive.aspx";
    });
    $("#btnaccount").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/PersonalAccountsInActive.aspx";
    });
    $("#btndptcalender").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/PersonalDeptCalenderInative.aspx";
    });
    $("#btnpersonalcalender").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/PersonalCalenderInActive.aspx";
    });
    $("#btnholidaycal").click(function (evt) {
        evt.preventDefault();
        document.location.href = "/Content/PersonalHolidayCalenderInActive.aspx";
    });

})

//function CountPersonal() {
//    try {
//        var persCount = cmbPersName.GetItemCount();
//        var hasKeine = cmbPersName.FindItemByValue(0) != null;

//        persCount = persCount - (hasKeine ? 1 : 0) > 0 ? persCount - (hasKeine ? 1 : 0) : 0;

//        $("#txtFvTotalEntries").val(persCount);
//        var selectedPers = cmbPersName.GetSelectedIndex();
//        selectedPers = selectedPers != -1 ? (hasKeine ? selectedPers : selectedPers + 1) : 0;
//        $("#txtFvCurrentEntry").val(selectedPers);
//    } catch (e) { console.log(e); }
//}

//function SetSelectedPersonNoInSessionStorage() {
//    try {
//        var PersNr = cmbPersName.GetValue();
//        sessionStorage.setItem("PersNr", PersNr);
//    } catch (err) { console.log(err); }
//}

///
///Compare:
///When true: Check if target's value is zero.
///If so change.
///When false: Change target's value
///
function SetDxValue(dxTargetControl, dxSrcControl, compare) {
    try {
        if (typeof dxTargetControl !== "undefined" && typeof dxSrcControl !== "undefined") {
            if (compare) {
                if (dxSrcControl.GetValue() !== 0 && dxTargetControl.GetValue() !== dxSrcControl.GetValue()) return;
            }

            dxTargetControl.SetValue(dxSrcControl.GetValue());
        }
    } catch (e) { console.log(e); }
}

function SetDxDateValue(dxTargetControl, dxSrcControl, compare) {
    try {
        if (typeof dxTargetControl !== "undefined" && typeof dxSrcControl !== "undefined") {
            if (compare) {
                if (dxTargetControl.GetDate() !== null) return;
            }

            dxTargetControl.SetDate(dxSrcControl.GetDate());
        }
    } catch (e) { console.log(e); }
}

function NavigateDxDrp(sender, navDirection) {
    try {
        var nextIndex = sender.GetSelectedIndex() + navDirection;

        if (nextIndex >= 0 && nextIndex < sender.GetItemCount()) {
            var nextValue = sender.GetItem(nextIndex).value;
            if (sender.FindItemByValue(nextValue) !== null) {
                sender.SetValue(nextValue);
            }
        }
    } catch (e) { console.log(e); }
}