var qty_school;
var qty_village;
var qty_education;
var qty_social;
var text70_price = 25;
var text166_price = 29;
var text320_price = 35;

function validateValueOrphan(evt) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);
    var regex = /[0-9]|\./;
var regexd = /^\d*(\.\d{1})?\d{0,1}$/;

    if (!regex.test(key) || !regexd.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault)
            theEvent.preventDefault();
    }
}




function getIntValue(field) {
    if (isNaN(field.value)) {
        field.value = "0";
        return 0;
    }
    else if (field.value == "") {
        field.value = "0";
        return 0;
    }
    else {
        return parseFloat(field.value);
    }
}


function roundTwoDecimal(field) {
	var valueToRound;
	valueToRound = field.value;
	var t;
	var s=new String(Math.round(valueToRound*100));
	while (s.length < 3) {
		s = '0'+ s;
	}
	field.value = s.substr(0, t = (s.length - 2)) + '.' + s.substr(t, 2);
}

function calcAmt(frm) { 	 	 
 	 	 
qty_syrial = getIntValue(document.getElementById("text70_qty"));	 	 
qty_village = getIntValue(document.getElementById("text166_qty"));	 	 
qty_social = getIntValue(document.getElementById("text320_qty"));	 	 
document.getElementById("amount").value = qty_syrial * text70_price; 	 	 
document.getElementById("amount1").value = qty_village * text166_price; 	 	 
document.getElementById("amount2").value = qty_social * text320_price; 	 	 
amt_syrial = getIntValue(document.getElementById("amount")); 	 	 
amt_village = getIntValue(document.getElementById("amount1")); 	 	 
amt_social = getIntValue(document.getElementById("amount2"));	

//anyamount = getIntValue(document.getElementById("amount3"));
var total = amt_syrial + amt_village + amt_social;	 	 
document.getElementById("overallTotalText").innerHTML=total.toFixed(2);
 	
}