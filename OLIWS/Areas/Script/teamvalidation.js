﻿function validate_name(field, Check, min, reg, m) {
    var x = document.getElementById(field).value;
    var text = null;
    var ps = "";
    var regx = null;
    if (reg == "N") {
        regx = /^(([a-zA-Z]([\s ][a-zA-Z])?){3,10})$/;
        text = 'Name';
    } if (reg == "E") {
        regx = /^[A-Z]+(_|\.[a-z])?[a-z0-9]*@[a-z0-9]+\.(com|org|co.uk|pk)$/i;
        text = 'Email';
    } if (reg == "P") {
        regx = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{7,20}$/;
        text = 'Password';

    } if (reg == "AD") {
        regx = /^(([\w+][ ]?){3,200})+$/;
        text = 'address';

    }
    if (reg == "Ph") {
        regx = /^((\+92)|(0092))\d{3}\d{7}$|^((03)|(3))\d{2}\d{7}$|^[0-9]*[1-9][0-9]{8}$/;
        text = 'Phone_Number';
    } if (reg == "C") {
        regx = /^([1-7]{1}([0-9]{3})([0-7]{1})-([0-9]{7})-([0-9]{1}))$/;
        text = 'CNIC';
    }
    if (x == "") {
        border(field, Check, '#d9534f', ' ' + text + ' field is Empty');
        return false;
    }
    if (x.length <= min) {
        border(field, Check, '#d9534f', '' + text + ' Should Be Grater Then ' + min + ' ' + m + '');
        return false;
    }
    if (!regx.test(x)) {
        border(field, Check, '#d9534f', m);
        return false;
    } else {
        border(field, Check, '#00AAFF', '');
        return true;
    }
}
function border(borders, latters, col, mess) {
    document.getElementById(borders).style.borderColor = col;
    document.getElementById(latters).style.color = col;
    document.getElementById(latters).innerHTML = mess;
}

function Validate_Date(field, errors) {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    var t1 = document.getElementById(field).value;
    t1 = t1.split('-');
    //alert("check "+t1+"");
    var cc = yyyy - 5;
    if (t1 == "") {
        // document.getElementById(errors).innerHTML = "Field is empty";
        border(field, errors, '#d9534f', 'Field is empty');
        return false;
    }
    if (t1[0] > yyyy) {
        border(field, errors, '#d9534f', 'Year is Greater Then Current Year');
        return false;
    } if (t1[0] == yyyy) {
        border(field, errors, '#d9534f', 'Year is Equal To Current Year');
        return false;
    } if (t1[0] <= cc) {
        border(field, errors, '#00AAFF', '')
        return true;
    } else {
        //document.getElementById(errors).innerHTML = "very nice";
        border(field, errors, '#d9534f', 'User Shold be 5 years Of Age');
        return false;
    }
}
function Empty_Exists(name, lable, con, checker, mess) {
    var x = document.getElementById(name).value;
    if (x == "") {
        border(name, lable, '#d9534f', 'Field Is Empty');
        return false;
    }
    var c = validate_name(name, lable, 3, 'N', 'Only Alphabets And Two Spaces Allowed.')
    if (c) {
        CheckAvailability(name, lable, con, checker)
        var z = document.getElementById(checker).innerText;
        if (z == 0) {
            border(name, lable, '#00AAFF', 'Success');
            return true;
        } else {
            border(name, lable, '#d9534f', mess);
            return false;
        }
    } else {
        border(name, lable, '#d9534f', 'Enter Valid ' + name + '');
        return false;
    }
}
function CheckAvailability(field, Label, controler, Result) {
    $.post("/Json/" + controler + "",
{
    name: $("#" + field).val()
}, function (data) {
    if (data == 0) {
        $("#" + Result).html("0");
        border(field, Label, '#00AAFF', '')
    } if (data == 2) {
        $("#" + Result).html("2");
        border(field, Label, '#d9534f', '' + field + ' is Empty.')
    } if (data == 1) {
        $("#" + Result).html("1");
        border(field, Label, '#d9534f', '' + field + ' Already Exists.')
    }
});
}
function city() {
    if (document.getElementById("city").value == "Select City..") {
        border('city', 'error_city', '#d9534f', 'Select City...');
        return false;
    }
    else {
        border('city', 'error_city', '#00AAFF', '');
        return true;
    }
}
//function Gender() {
//    if (document.getElementById("Gender").value == "Select Gender..") {
//        border('Gender', 'error_Gender', '#d9534f', 'Select Gender...');
//        return false;
//    }
//    else {
//        border('Gender', 'error_Gender', '#00AAFF', '');
//        return true;
//    }
//}

function CheckAvailability() {
    $("#Eerror").html("Checking....");
    $.post("/Json/CheckUsername",
{
    username: $("#email").val()
}, function (data) {
    if (data == 0) {
        $("#Eerror").html('<font color="Green">Available !. You Can Take It</font>');
        $("#email").css("border-color", "Green");
        $("#val").html("0");
    } if (data == 2) {
        border('email', 'Eerror', '#d9534f', 'Email Field Is Empty');
    } if (data == 1) {
        $("#Eerror").html('<font color="Red">User Already Exists</font>');
        $("#email").css("border-color", "Red");
        $("#val").html("1");
    }
});

}

function pass_match(field, field2, errors) {
    var pass = document.getElementById(field).value;
    var pass2 = document.getElementById(field2).value;
    if (pass2 != "") {
        if (pass != pass2) {
            document.getElementById(errors).innerHTML = "not matched";
            border(field, errors, '#d9534f', 'Not Matched');
            return false;
        } else {
            border(field, errors, '#00AAFF', 'Matched')
            return true;
        }
    } else {
        border(field, errors, '#d9534f', 'Field Is Empty');
        return false;
    }
}

function Check_AllFieldstteam() {

    var r = [8];
    r[0] = document.getElementById("vfname").innerHTML = validate_name('vfname', 'verror', 2, 'N', 'For valid name enter elphabet only');
    r[1] = document.getElementById("vlname").innerHTML = validate_name('vlname', 'vLerror', 2, 'N', 'For valid name enter elphabet only');
    r[2] = document.getElementById("vemail").innerHTML = validate_name('vemail', 'vEerror', '', 'E', 'Email formate should be abc@xyz.com');
    r[3] = document.getElementById("vpass").innerHTML = validate_name('vpass', 'vPerror', 6, 'P', 'please enter atleast 1 capital letter & contain these(#$%^&)');
    r[4] = document.getElementById("vCpass").innerHTML = pass_match('vpass', 'vCpass', 'vCPerror');
    r[5] = document.getElementById("cnic").innerHTML = validate_name('cnic', 'CNPerror', 14, 'C', 'Type CNIC with dashes');
    r[6] = document.getElementById("phn").innerHTML = validate_name('phn', 'Pherror', 10, 'Ph', 'Should be only numeric value');
    r[7] = document.getElementById("vAdr").innerHTML = validate_name('vAdr', 'vadrerror', 7, 'AD', 'addres is not valid');

    r[8] = document.getElementById("vdateid").innerHTML = Validate_Date('vdateid', 'vDerror');

    //r[9] = ch;
    //a[7] = document.getElementById("city").innerHTML = city();


    if (!r[0]) {
        document.getElementById("vfname").focus();
        return false;
    }
    if (!r[1]) {
        document.getElementById("vlname").focus();
        return false;
    }
    if (!r[2]) {
        document.getElementById("vemail").focus();
        return false;
    }
    if (!r[3]) {
        document.getElementById("vpass").focus();
        return false;
    }
    if (!r[4]) {
        document.getElementById("vCpass").focus();
        return false;
    }
    if (!r[5]) {
        document.getElementById("cnic").focus();
        return false;
    }
    //if (!a[6]) {
    //    document.getElementById("add").focus();
    //    return false;
    //}

    if (!r[6]) {
        document.getElementById("phn").focus();
        return false;
    } if (!r[7]) {
        document.getElementById("vAdr").focus();
        return false;
    }
    if (!r[8]) {
        document.getElementById("vdateid").focus();
        return false;


        //if (!r[9]) {
        //    document.getElementById("email").focus();
        //    document.getElementById("emailerror").innerHTML = "User Already Exists";
        //    return false;
        //} if (!a[7]) {
        //    //document.getElementById("city").focus();
        //    return false;
    } else {
        return true;
    }

}
