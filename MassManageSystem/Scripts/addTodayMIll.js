$(document).ready(function () {
    //alert("JS loaded");
    
    var currentTime = new Date()
    var minDate = new Date(currentTime.getFullYear(), currentTime.getMonth(), +1); //one day next before month
    var maxDate = new Date(currentTime.getFullYear(), currentTime.getMonth() + 1, +2); // one day before next month
    $("#date").datepicker({
        minDate: minDate,
        maxDate: maxDate,
        dateFormat: 'yy-dd-mm'
    });


    getMemberInfo();
    getMemberInfoBazar();
});

function getMemberInfo() {
    $.ajax({
        type: "GET",
        url: "../MillManage/GetMemberInfo",
        success: function (data) {
            var sep1 = $('#Member');
            $.each(data, function (k, v) {
                sep1.append('<option value="' + v.MemberInfoId + '">' + v.Name + '</option>');
                //console.log(JSON.stringify(v.Name));
            });
        }

    })
}
function getMemberInfoBazar() {
    $.ajax({
        type: "GET",
        url: "../MillManage/GetMemberInfo",
        success: function (data) {
            var sep1 = $('#MemberForBazar');
            $.each(data, function (k, v) {
                sep1.append('<option value="' + v.MemberInfoId + '">' + v.Name + '</option>');
                //console.log(JSON.stringify(v.Name));
            });
        }

    })
}

jQuery(document).delegate('.add-record', 'click', function (e) {
    e.preventDefault();
    //alert("Add function call");
    var Memberval = $('#Member').val()
    var Mirning = $('#Mirning').val();
    var Lunch = $('#Lunch').val();
    var Dinner = $('#Dinner').val();

    if (Memberval == null || typeof (Memberval) == 'undefined' || Memberval == '') {
        alert('Please Select Member');
        return;
    }
    var MemberText = jQuery("#Member option:selected").text();
    var invalidMember = false;

    $('#resultTable tr').each(function () {
        var MemberInfoId = $(this).find(".Member").html();
        if (MemberText == MemberInfoId) {
            invalidMember = true;
            return;
        }
    });
    if (invalidMember === true) {
        alert('Member Aleady Added to Today Mill Sheet.');
        return;
    }


    if (Mirning == null || typeof (Mirning) == 'undefined' || Mirning == '') {
        alert('Please Insert Mirning mill');
        return;
    }
    if (Lunch == null || typeof (Lunch) == 'undefined' || Lunch == '') {
        alert('Please Insert Lunch mill');
        return;
    }
    if (Dinner == null || typeof (Dinner) == 'undefined' || Dinner == '') {
        alert('Please Insert Dinner mill');
        return;
    }

    var content = jQuery('#sample_table tr'),
        size = jQuery('#resultTable >tbody >tr').length - 1,
        element = null,
        element = content.clone();

    element.attr('id', 'rec-' + size);
    element.find('.delete-record').attr('data-id', size);
    element.appendTo('#resultTable_body');
   // var i=element.find('id');
    //alert();

    element.find('.sn').html(size);
    element.find('.Member').html(MemberText);
    element.find('.MemberInfoId').html(Memberval);
    element.find('.Mirning').html(Mirning);
    element.find('.Lunch').html(Lunch);
    element.find('.Dinner').html(Dinner);

    $('#Member').val('');
    $('#Mirning').val('');
    $('#Lunch').val('');
    $('#Dinner').val('');

    //alert(Mirning);
    //console.log(JSON.stringify(content));
    var totalMorning = calculateTotalMorning();
    var totalLunch = calculateTotalLunch();
    var totalDinner = calculateTotalDinner();

    $('#totalMorning').html(totalMorning);
    $('#totalLunch').html(totalLunch);
    $('#totalDinner').html(totalDinner);
    //$('#total2').html(sgpa);
    //$("#course option[value='" + courseValue +"']").remove();

});

jQuery(document).delegate('.edit-record', 'click', function (e) {
    var element = $(this).parents('tr');
    var id = element.attr('data-id');
    var Member = element.find('.Member').html();
    var MemberInfoId = element.find('.MemberInfoId').html();
    var Mirning = element.find('.Mirning').html();
    var Lunch = element.find('.Lunch').html();
    var Dinner = element.find('.Dinner').html();
    /*$("#course option:contains(" + course + ")").attr('selected', 'selected');*/
    $('#id').val(id);
    $('#Mirning').val(Mirning);
    $('#Lunch').val(Lunch);
    $('#Dinner').val(Dinner);
    $('#Member').val(MemberInfoId);
    element.remove();


    var totalMorning = calculateTotalMorning();
    var totalLunch = calculateTotalLunch();
    var totalDinner = calculateTotalDinner();

    $('#totalMorning').html(totalMorning);
    $('#totalLunch').html(totalLunch);
    $('#totalDinner').html(totalDinner);
    //$('#course').find("select option:contains('" + courseID + "')").attr('selected', true);
});

jQuery(document).delegate('.delete-record', 'click', function (e) {
    e.preventDefault();
    var didConfirm = confirm("Are you sure You want to delete");
    if (didConfirm == true) {
        var id = jQuery(this).attr('data-id');
        alert(id);
        var targetDiv = jQuery(this).attr('targetDiv');
        jQuery('#rec-' + id).remove();

        //regenerate index number on table
        $('#tbl_posts_body tr').each(function (index) {
            alert(index);
            $(this).find('span.sn').html(index + 1); 
        });
        var totalMorning = calculateTotalMorning();
        var totalLunch = calculateTotalLunch();
        var totalDinner = calculateTotalDinner();

        $('#totalMorning').html(totalMorning);
        $('#totalLunch').html(totalLunch);
        $('#totalDinner').html(totalDinner);
    }

});


function calculateTotalMorning() {
    var total = 0;
    $('#resultTable tr').each(function () {
        var Mirning = $(this).find(".Mirning").html();
        if (Mirning !== null && typeof (Mirning) !== 'undefined') {
            total += parseInt(Mirning);
        }

    });
    return total;
}

function calculateTotalLunch() {
    var total = 0;
    $('#resultTable tr').each(function () {
        var Lunch = $(this).find(".Lunch").html();
        if (Lunch !== null && typeof (Lunch) !== 'undefined') {
            total += parseInt(Lunch);
        }

    });
    return total;
}

function calculateTotalDinner() {
    var total = 0;
    $('#resultTable tr').each(function () {
        var Dinner = $(this).find(".Dinner").html();
        if (Dinner !== null && typeof (Dinner) !== 'undefined') {
            total += parseInt(Dinner);
        }

    });
    return total;
}

function saveData() {
    var date = $('#date').val();
    var bazar = $('#Bazar').val();
    var Membervalforbazar = $('#MemberForBazar').val()

    var rowCount = 0;
    $('#resultTable tr').each(function () {
        var MemberInfoId = $(this).find(".MemberInfoId").html();
        if (MemberInfoId !== null && typeof (MemberInfoId) !== 'undefined') {
            rowCount += 1;
        }
    });
   // console.log(JSON.stringify(rowCount));
    if (date==""|| date == undefined || date == null) {
        alert("Select date first");
        return;
    }
    //alert(data);
    //console.log(JSON.stringify(date));
    if (bazar == "" || bazar == undefined || bazar == null) {
        alert("Insert bazar amount first");
        return;
    }
    if (Membervalforbazar == null || Membervalforbazar == "" || Membervalforbazar == undefined) {
        alert("Select today bazar person first");
        return;
    }

    if (rowCount == 0) {
        alert('Data Grid is empty.. ');
        return;
    }
   // alert(date);

    $.ajax({
        type: "POST",
        url: "../BazarManage/PostBazarInfo",
        data: {
            MemberInfoId: Membervalforbazar,
            TotalBazar: bazar,
            Image: "",
            Date: date
        },
        success: function (data) {
            //if (data> 0) {
            alert("Data saved successfully");
            //} else {
            //    alert("Something went wrong! please try again!");
            //}
        }

    });

    var reportResultList = [];
    $('#resultTable tr').each(function () {
        var MemberInfoId = $(this).find(".MemberInfoId").html();
        var Mirning = $(this).find(".Mirning").html();
        var Lunch = $(this).find(".Lunch").html();
        var Dinner = $(this).find(".Dinner").html();
        if (MemberInfoId !== null && typeof (MemberInfoId) !== 'undefined') {
            var data = {
                //ReportResultId: 1,
                MemberInfoId: MemberInfoId,
                Mirning: Mirning,
                Lunch: Lunch,
                Dinner: Dinner,
                Date: date
            }
            
         //  reportResultList.push(data);
            $.ajax({
                type: "POST",
                url: "../MillManage/PostMillInfo",
                data: data,
                success: function (data) {
                   // if (data > 0) {
                        alert("Data saved successfully");
                   // } else {
                    //    alert("Something went wrong! please try again!");
                    //}

                }
            });
        }

   

    });

  
    //console.log(JSON.stringify(reportResultList));
   
}