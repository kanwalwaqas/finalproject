jQuery(document).ready(function($){

	  $(".total_amount").keypress(function (e) {
     //if the letter is not digit then display error and don't type anything
     if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        //display error message
        alert("digit/number only");
               return false;
    }
	

});  

 $(".total_amount_widget").keypress(function (e) {
     //if the letter is not digit then display error and don't type anything
     if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        //display error message
        alert("digit/number only");
               return false;
 }
}); 
jQuery('.paypal').click(function(){
	var total_amount=jQuery('.total_amount').val();
	var currency=jQuery('#currency').val();
	if (!total_amount)
	{
          alert("please fill amount");

         }
	else{
  var url="https://donate.islamicaid.com?total_amount="+total_amount+"&currency="+currency+"&paymode=paypal";                                    
		window.location.href=url;
	
 

	}



  });
jQuery('.paypal_mobile').click(function(){
var total_amount=jQuery('.total_amount_widget').val();
var currency=jQuery('#currency').val();
	if (!total_amount)
	{
          alert("please fill amount");

         }
	else{
  var url="https://donate.islamicaid.com?total_amount="+total_amount+"&currency="+currency+"&paymode=paypal";                                    
		window.location.href=url;
}

});

jQuery('#give_mobile').click(function(){
var total_amount=jQuery('.total_amount_widget').val();
var currency=jQuery('#currency').val();
	if (!total_amount)
	{
          alert("please fill amount");

         }
	else{
  var url="https://donate.islamicaid.com?total_amount="+total_amount+"&currency="+currency+"&paymode=card";                                    
		window.location.href=url;
}

});
});

