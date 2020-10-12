$(document).ready(function () {
  //  alert("MillManage js load");
});

function AddTodayMill() {
    var url = "../MillManage/AddTodayMill"

    $("#myModalBodyDiv").load(url, function () {
        $("#myModal").modal("show");
    })
}