function validate_name(field, Check, min, reg,m) {
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
        border(field, Check, '#d9534f', '' + text + ' Should Be Grater Then ' + min +' '+ m +'');
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
function is_checked(field1,field2,field3,field4,errors)
{
    var zakat = document.getElementById('field1');
    var sadqah = document.getElementById('field2').value;
    var zakat_ul_fitr = document.getElementById('field3').value;
    var usher = document.getElementById('field4').value;
    if (zakat.checked == false && sadqah.checked == false && zakat_ul_fitr.checked == false && usher.checked == false) {
        document.getElementById('checkboxerrors').innerHTML="select one";
        return false;
    }
    else {
        return true;
    }

}

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

function pass_match(field,field2, errors) {
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

function Check_AllFields() {
    var ch=false;
    var c=document.getElementById("val").innerText;
    ch=(c==0)?true:false;
    var a = [10];
    a[0] = document.getElementById("fname").innerHTML = validate_name('fname', 'error', 2, 'N', 'For valid name enter elphabet only');
    a[1] = document.getElementById("lname").innerHTML = validate_name('lname', 'Lerror', 2, 'N', 'For valid name enter elphabet only');
    a[2] = document.getElementById("email").innerHTML = validate_name('email', 'Eerror', '', 'E', 'Email formate should be abc@xyz.com');
    a[3] = document.getElementById("pass").innerHTML = validate_name('pass', 'Perror', 6, 'P', 'please enter atleast 1 capital letter & contain these(#$%^&)');
    a[4] = document.getElementById("Cpass").innerHTML = pass_match('pass', 'Cpass', 'CPerror');
    a[5] = document.getElementById("cnic").innerHTML = validate_name('cnic', 'CNPerror', 14, 'C', 'Type CNIC with dashes');
    a[6] = document.getElementById("phn").innerHTML = validate_name('phn', 'Pherror', 10, 'Ph', 'Should be only numeric value');
    a[7] = document.getElementById("dateid").innerHTML = Validate_Date('dateid', 'Derror');
    a[8] = document.getElementById("Adr").innerHTML = validate_name('Adr', 'adrerror', 20, 'AD', 'addres is not valid');
    a[9] = document.getElementById("zakat").innerHTML = is_checked('zakat', 'sadqah', 'usher', 'zakat_ul_fitr', 'checkboxerrors');
    a[10] = ch;
    //a[7] = document.getElementById("city").innerHTML = city();


    if (!a[0]) {
        document.getElementById("fname").focus();
        return false;
    }
    if (!a[1]) {
        document.getElementById("lname").focus();
        return false;
    }
    if (!a[2]) {
        document.getElementById("email").focus();
        return false;
    }
    if (!a[3]) {
        document.getElementById("pass").focus();
        return false;
    }
    if (!a[4]) {
        document.getElementById("Cpass").focus();
        return false;
    }
    if (!a[5]) {
        document.getElementById("cnic").focus();
        return false;
    }
    //if (!a[6]) {
    //    document.getElementById("add").focus();
    //    return false;
    //}

    if (!a[6]) {
        document.getElementById("phn").focus();
        return false;
    }
    if (!a[7]) {
        document.getElementById("dateid").focus();
        return false;
    } if (!a[8]) {
        document.getElementById("Adr").focus();
        return false;
    } if (!a[9]) {
        document.getElementById("checkboxerrors").focus();
        return false;
    }

    if (!a[10]) {
        document.getElementById("email").focus();
        document.getElementById("emailerror").innerHTML="User Already Exists";
        return false;
    //} if (!a[7]) {
    //    //document.getElementById("city").focus();
    //    return false;
    } else {
        return true;
    }
    
}

function Check_AllFi() {

    var v = [11];
    v[0] = document.getElementById("orgname").innerHTML = validate_name('orgname', 'orgrror', 2, 'N', 'For valid name enter elphabet only ');
    v[1] = document.getElementById("orgemail").innerHTML = validate_name('orgemail', 'orgerror', '', 'E', 'Email formate should be abc@xyz.com');
    v[2] = document.getElementById("passwrd").innerHTML = validate_name('passwrd', 'orgPerror', 6, 'P', 'please enter atleast 1 capital letter & contain these(#$%^&)');
    v[3] = document.getElementById("orgCpass").innerHTML = pass_match('passwrd', 'orgCpass', 'CnPerror');
    v[4] = document.getElementById("nAdr").innerHTML = validate_name('nAdr', 'nadrerror', 7, 'AD', 'addres is not valid');
    v[5] = document.getElementById("phnorg").innerHTML = validate_name('phnorg', 'oPherror', 10, 'Ph', 'Should be only numeric value');
    v[6] = document.getElementById("Fname").innerHTML = validate_name('Fname', 'Ferror', 2, 'N', 'For valid name enter elphabet only');
    v[7] = document.getElementById("Lname").innerHTML = validate_name('Lname', 'LLerror', 2, 'N', 'For valid name enter elphabet only');
    v[8] = document.getElementById("eemail").innerHTML = validate_name('eemail', 'eerror', '', 'E', 'Email formate should be abc@xyz.com');
    v[9] = document.getElementById("owadrg").innerHTML = validate_name('owadrg', 'aderogw', 7, 'AD', 'addres is not valid');

    v[10] = document.getElementById("owncnic").innerHTML = validate_name('owncnic', 'ownPerror', 14, 'C', 'Type CNIC with dashes virst digit should not be 0');
    v[11] = document.getElementById("phhn").innerHTML = validate_name('phhn', 'Phherror', 10, 'Ph', 'Should be only numeric value');


    //a[7] = document.getElementById("city").innerHTML = city();


    if (!v[0]) {
        document.getElementById("orgname").focus();
        return false;
    }
    if (!v[1]) {
        document.getElementById("orgemail").focus();
        return false;
    }
    if (!v[2]) {
        document.getElementById("passwrd").focus();
        return false;
    }
    if (!v[3]) {
        document.getElementById("orgCpass").focus();
        return false;
    } if (!v[4]) {
        document.getElementById("nAdr").focus();
        return false;
    }
    if (!v[5]) {
        document.getElementById("phnorg").focus();
        return false;
    }
    if (!v[6]) {
        document.getElementById("Fname").focus();
        return false;
    }
    if (!v[7]) {
        document.getElementById("Lname").focus();
        return false;
    }
    if (!v[8]) {
        document.getElementById("eemail").focus();
        return false;
    } if (!v[9]) {
        document.getElementById("owadrg").focus();
        return false;
    }


    if (!v[10]) {
        document.getElementById("owncnic").focus();
        return false;
    }

    if (!v[11]) {
        document.getElementById("phhn").focus();
        return false;
    }

        //if (!a[12]) {
        //    document.getElementById("eemail").focus();
        //    document.getElementById("eerror").innerHTML = "User Already Exists";
        //    return false;
        //    //} if (!a[7]) {
        //    //    //document.getElementById("city").focus();
        //    //    return false;
        //} 
    else {
        return true;
    }
    function ContactAllField() {
        var c = [0]
        c[0] = document.getElementById("fname").innerHTML = validate_name('fname', 'error', 2, 'N', 'For valid name enter elphabet only');


        if (!c[0]) {
            document.getElementById("fname").focus();
            return false;
        } else {
            return true;
        }
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