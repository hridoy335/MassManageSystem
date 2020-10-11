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
            { "mData": "ParentContact" },
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
    var e;
    var name = $("#Name").val();
    var contact = $("#Contact").val();
    var email = $("#Email").val();
    var image = $("#Image").val();
    var parentContact = $("#ParentContact").val();
    var status = $("#Status").val();
    var userName = $("#UserName").val();
    var password = $("#Password").val();

    debugger
    var data2 = $("#MemForm").serialize();
    //e.preventDefault(); 
    if ($("#MemForm").valid()) {

        $.ajax({
            type: "POST",
            url: "../MemberManage/AddMemberInfo",
            data: {
                Name: name,
                Contact: contact,
                Email: email,
                Image: image,
                ParentContact: parentContact,
                Status: status,
                UserName: userName,
                Password: password

            },
            success: function (data) {
                alert("Save MemberInfo Successfully .. ");
                $("#loaderDiv").hide();
                $("#myModal").modal("hide");
                window.location.href = "/MemberManage/index";
            }
        });
    }

  
    
  
}