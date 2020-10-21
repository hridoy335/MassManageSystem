$(document).ready(function () {
    //alert("Bazar manage js +");
    GetBazarinfo();
});

//Get bazar information
function GetBazarinfo() {
    $.ajax({
        type: "GET",
        url: "../BazarManage/GetBazarinfo",
        success: function (response) {
            //console.log(JSON.stringify(response));
             BindgetMemberInfodata(response);
        }
    })
}

function BindgetMemberInfodata(response) {
    $("#MyDataTable").DataTable({

        "aaData": response,
        "aoColumns": [

            { "mData": "MemberInfoId" },
            { "mData": "TotalBazar" },
            { "mData": "Image" },
            {
                "mData": "Date",
                "render": function (d) {
                    // debugger
                    var date = new Date(+d.replace(/\D/ig, ""));
                    var month = date.getMonth() + 1;
                    return date.getFullYear() + "/" + month + "/" + date.getDate();
                },
            },
            {
                "mData": "BazarInfoId",
                "render": function (BazarInfoId, type, full, meta) {
                    //debugger
                    return '<a href="#" onclick="AddEditBazarInfo(' + BazarInfoId + ')"><i class="glyphicon glyphicon-pencil"></i></a>'
                }
            },

        ]

    });
}

