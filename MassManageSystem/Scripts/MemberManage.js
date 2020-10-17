$(document).ready(function () {
    //alert("MemberManage js");
    getMemberInfo();
});

// get Memberinfo data and show this data
function getMemberInfo() {
  //  alert("yes");
    $.ajax({
        type: "GET",
        url: "../MemberManage/GetMemberInfo",
        success: function (response) {
           // console.log(JSON.stringify(response));
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
            //{ "mData": "MemberInfoId" },
            {
                "mData": "MemberInfoId",
                "render": function (MemberInfoId, type, full, meta) {
                    //debugger
                    return '<a href="#" onclick="AddEditMemberInfo(' + MemberInfoId + ')"><i class="glyphicon glyphicon-pencil"></i></a>'
                }
            },
          
        ]

    });
}

 //Add Memberinfo Partialview calling
function AddMember() {
    var url = "../MemberManage/AddMemberInfo"

    $("#myModalBodyDiv").load(url, function () {
        $("#myModal").modal("show");
    })
}

// Add Memberinfo partialview data save
function SaveMember() {
    var er=0;
    var name = $("#Name").val();
    var contact = $("#Contact").val();
    var email = $("#Email").val();
    var image = $("#Image").val();
    var parentContact = $("#ParentContact").val();
    var status = $("#Status").val();
    var userName = $("#UserName").val();
    var password = $("#Password").val();

    //if (name == null || name == "" || name == undefined)
    //{
    //  alert("Name required..")
    //}
    //if (contact == null || contact == "" || contact == undefined)
    //{
    // alert("Contact required..")
    //}
    //if (email == null || email == "" || email == undefined)
    // {
    // alert("Email required..")
    //}
    //if (image == null || image == "" || image == undefined)
    // {
    //  alert("Image required..")
    //}
    //if (parentContact == null || parentContact == "" || parentContact == undefined)
    // {
    //   alert("Parent Contact required..")
    //}
    //if (userName == null || userName == "" || userName == undefined)
    // {
    //   alert("Username required..")
    //}
    //if (password == null || password=="" || password == undefined)
    // {
    //  alert("Password required..")
    // }

         
    //debugger
    //var data2 = $("#MemForm").serialize();
    ////e.preventDefault(); 
    //if ($("#MemForm").valid()) {

      
    //}
    
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
            if (data == true) {
                alert("Save MemberInfo Successfully .. ");
                $("#loaderDiv").hide();
                $("#myModal").modal("hide");
                window.location.href = "/MemberManage/index";
            }
            else {
                alert("Data Not Insert ..");
                $("#myModal").modal("show");
            }
            
        }
    });
  
    
  
}

// AddEditMemberInfo 
function AddEditMemberInfo(MemberInfoId) {
    var url = "/MemberManage/PartialAddEditMemberInfo?MemberInfoId=" + MemberInfoId;

    $("#myModalBodyDiv1").load(url, function () {
        $("#myModal1").modal("show");

    })
}

function PartialAddEditMemberInfo() {
    var name = $("#Name").val();
    var contact = $("#Contact").val();
    var email = $("#Email").val();
    var image = $("#Image").val();
    var parentContact = $("#ParentContact").val();
    var status1 = $("#Status").val();
    var userName = $("#Username").val();
    var password = $("#Password").val();
    var MemberId = $("#Memberid").val();
    console.log(JSON.stringify(userName))
    //var status;
    //if (status1 == true) {
    //     status = true;
        
    //}
    
    //else { status = false; }

    console.log(JSON.stringify(status));

    $.ajax({
        type: "POST",
        url: "../MemberManage/PartialAddEditMemberInfo",
        data: {
            MemberInfoId: MemberId,
            Name: name,
            Contact: contact,
            Email: email,
            Image: image,
            ParentContact: parentContact,
            Status: status1,
            UserName: userName,
            Password: password

        },
        success: function (data) {
            if (data == true) {
                alert("Save MemberInfo Successfully .. ");
                $("#loaderDiv").hide();
                $("#myModal").modal("hide");
                window.location.href = "/MemberManage/index";
            }
            else {
                alert("Data Not Insert ..");
                $("#myModal").modal("hide");
            }

        }
    });
}