$(document).ready(function () {
    //alert("JS loaded");
    getMemberInfo();
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

    alert(Mirning);
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