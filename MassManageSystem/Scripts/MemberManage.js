$(document).ready(function () {
    //alert("MemberManage js");
    getMemberInfo();
});

// get Memberinfo data and show this data
function getMemberInfo() {
    $.ajax({
        type: "GET",
        url: "../MemberManage/GetMemberInfo",
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

            { "mData": "Name" },
            { "mData": "Contact" },
            { "mData": "Email" },
            { "mData": "Image" },
            { "mData": "Parent Contact" },
            { "mData": "Status" },
            // { "mData": "CourseId" },
            //{
            //    "mData": "CourseId",
            //    "render": function (CourseId, type, full, meta) {
            //        //debugger
            //        return '<a href="#" onclick="AddEditCourse(' + CourseId + ')"><i class="glyphicon glyphicon-pencil"></i></a>'
            //    }
            //},
          
        ]

    });
}

// Add Memberinfo Partialview calling
function AddMember() {
    var url = "../MemberManage/AddMemberInfo"

    $("#myModalBodyDiv").load(url, function () {
        $("#myModal").modal("show");
    })
}

// Add Memberinfo partialview data save
function SaveMember() {
    var name = $("#Name").val();
    var Contact = $("#Contact").val();
    var Email = $("#Email").val();
    var Image = $("#Image").val();
    var ParentContact = $("#ParentContact").val();
    var Status = $("#Status").val();
    var UserName = $("#UserName").val();
    var Password = $("#Password").val();
  
}