$(document).ready(function () {
   alert("MillManage js load");
    //getMemberInfo();
    getMillThisMonth() 
});

function AddTodayMill() {
    var url = "../MillManage/AddTodayMill"

    $("#myModalBodyDiv").load(url, function () {
        $("#myModal").modal("show");
    })
    //getMemberInfo();
}

//function getMemberInfo() {
//    $.ajax({
//        type: "GET",
//        url: "../MillManage/GetMemberInfo",
//        success: function (data) {
//            var sep1 = $('#Member');
//            $.each(data, function (k, v) {
//                sep1.append('<option value="' + v.MemberInfoId + '">' + v.Name + '</option>');
//                console.log(JSON.stringify(v.Name));
//            });
//        }

//    })
//}

function getMillThisMonth() {
    alert("call getMillThisMonth")
    $.ajax({
        type: "GET",
        url: "../MillManage/GetMillThisMonth",
        success: function (response) {
              console.log(JSON.stringify(response));
            BindgetMemberInfodata(response);
        }

    })
}

function BindgetMemberInfodata(response) {
    $("#MyDataTable").DataTable({

        "aaData": response,
        "aoColumns": [

            { "mData": "MemberInfoId" },
            { "mData": "Morning" },
            { "mData": "Lunch" },
            { "mData": "Dinner" },
            { "mData": "Date" },
            //{ "mData": "MemberInfoId" },
            //{
            //    "mData": "MemberInfoId",
            //    "render": function (MemberInfoId, type, full, meta) {
            //        //debugger
            //        return '<a href="#" onclick="AddEditMemberInfo(' + MemberInfoId + ')"><i class="glyphicon glyphicon-pencil"></i></a>'
            //    }
            //},

        ]

    });
}