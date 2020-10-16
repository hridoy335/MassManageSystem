$(document).ready(function () {
  //  alert("MillManage js load");
    //getMemberInfo();
});

function AddTodayMill() {
    var url = "../MillManage/AddTodayMill"

    $("#myModalBodyDiv").load(url, function () {
        $("#myModal").modal("show");
    })
    getMemberInfo();
}

function getMemberInfo() {
    $.ajax({
        type: "GET",
        url: "../MillManage/GetMemberInfo",
        success: function (data) {
            var sep1 = $('#Member');
            $.each(data, function (k, v) {
                sep1.append('<option value="' + v.MemberInfoId + '">' + v.Name + '</option>');
                console.log(JSON.stringify(v.Name));
            });
        }

    })
}