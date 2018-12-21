// JavaScript Document

function validateValue(evt) {

    var theEvent = evt || window.event;

    var key = theEvent.keyCode || theEvent.which;

    key = String.fromCharCode(key);

    var regex = /[0-9]|\./;

    if (!regex.test(key)) {

        theEvent.returnValue = false;

        if (theEvent.preventDefault)

            theEvent.preventDefault();

    }

}

$(document).ready(function (e) {
	
    $('.donationModal .quantity').before("<span>Quantity</span>");
    
    $('.donationModal .poundAdd .oTotal').before("<span>&pound;</span>");
		
    //Common Code

    $('li:first-child').addClass('first');

    $('li:last-child').addClass('last');

    $('a[href="#"]').attr('href', 'javascript:;');

    // Add slideDown animation to dropdown

    $('.dropdown').on('show.bs.dropdown', function(e){

    $(this).find('.dropdown-menu').first().stop(true, true).slideDown("fast");

    });

    // Add slideUp animation to dropdown

    $('.dropdown').on('hide.bs.dropdown', function(e){

        $(this).find('.dropdown-menu').first().stop(true, true).slideUp("fast");

    });

    $(".country_selector").countrySelect({

        preferredCountries: ['gb', 'ie', 'us', 'ca']

    });

    $("#onetimeDForm").validate({

    });

    var stickyNavTop = $('.donNav').offset().top;

    var stickyNav = function(){

        var scrollTop = $(window).scrollTop();

        if (scrollTop > stickyNavTop) { 

        $('.donNav').addClass('sticky');

      } else {

        $('.donNav').removeClass('sticky'); 

        }

    };

    stickyNav();

    $(window).scroll(function() {

        stickyNav();

    });

  /*--------------MONTHLY FORM STARTS--------------*/

                /* checked remove when click other monthly amount */
    $('body').on('click','#monthlyDForm #monthly_amount_other',function(){
    
        $('.monthlyStarts .selectAmount input[type=radio]').removeAttr("checked");

        $('#monthlyDForm #monthly_amount_other').attr('required', true);

        $('.monthlyStarts .selectAmount input[type=radio]').removeAttr('required');

    });

                /* empty other amount when select amount radio */    
    $('body').on('click','.monthlyStarts .selectAmount input[type=radio]',function(){
    
        $('#monthlyDForm #monthly_amount_other').val('');

        $('.monthlyStarts .selectAmount input[type=radio]').attr('required', true);

        $('#monthlyDForm #monthly_amount_other').removeAttr('required', true);

    });

                /* calculate tax amount from radio */
    $('body').on('click','.monthlyStarts .selectAmount input[type=radio]',function(){
          
        var taxamount = $('.monthlyStarts .selectAmount input[type=radio]:checked').val();
    
    });

                /* calculate tax amount from amount textbox */    
    $('body').on('click','#monthlyDForm #monthly_amount_other',function(){
    
        var taxamount = $('.monthlyStarts #monthly_amount_other').val();

    });

                /* required error (amount) display none */ 
    
    $('body').on('click','.monthlyStarts .selectAmount input[type=radio]',function(){
    
        $('#mdfund-error').css("display", "none");
        
        $('#mdfund-zero-monthly').css("display", "none");
        
        $('#mdfund-greater-monthly').css("display", "none");
    });

                /* required error (amount) display none */ 
    $('body').on('click','#monthlyDForm #monthly_amount_other',function(){

        $('#mdfund-error').css("display", "none");
        
        $('#mdfund-zero-monthly').css("display", "none");
        
        $('#mdfund-greater-monthly').css("display", "none");

    });
    
    $('body').on('change','#monthlyDForm #companyname_monthly',function(){
 
 	if( $('#monthlyDForm #companyname_monthly').val() !== ''){

            $('#giftaid-monthly').css("display", "none");
        
        }else{
            
            $('#giftaid-monthly').css("display", "block");

	}

    });
        
                /* required error (funds) display none */

    $('.monthlyStarts .selectFtype input[type=radio]').click(function () {

      $('html, body').animate({scrollTop: $("#monthlyDForm .selectAmount").offset().top - 150}, 1000);

      $('#products-error').css("display", "none");

  });

    /*--------------MONTHLY FORM END--------------*/

    /*--------------ONE TIME FORM STARTS--------------*/

            /* checked remove when click other single amount */ 
    $('body').on('click','#onetimeDForm #single_amount_other',function(){

        $('.singleStarts .selectAmount input[type=radio]').removeAttr("checked");

    });

            /* empty other amount when select amount radio */ 
    $('body').on('click','.singleStarts .selectAmount input[type=radio]',function(){
        
        $('#onetimeDForm #single_amount_other').val('');

    });    

            /* required error (amount) display none */ 
    $('body').on('click','#onetimeDForm #single_amount_other',function(){

        $('#mdfund-error-single').css("display", "none");
        
        $('#mdfund-zero-single').css("display", "none");
        
        $('#mdfund-greater-single').css("display", "none");
    });

    $('body').on('change','#onetimeDForm #companyname',function(){

        if( $('#onetimeDForm #companyname').val() !== ''){
            $('#giftaid').css("display", "none");
        }else{
	 $('#giftaid').css("display", "block");

	}

    });
            /* required error (amount) display none */
    $('body').on('click','.singleStarts .selectAmount input[type=radio]',function(){

        $('#mdfund-error-single').css("display", "none");
        
        $('#mdfund-zero-single').css("display", "none");
        
        $('#mdfund-greater-single').css("display", "none");
    });

            /* required error (funds) display none */
    $('.singleStarts .selectFtype input[type=radio]').click(function () {

        $('html, body').animate({scrollTop: $("#onetimeDForm .selectAmount").offset().top - 150}, 1000);

        $('#products-error-single').css("display", "none");

    });

    /*--------------ONE TIME FORM END--------------*/

    $('.btn-dselect').on('click', function () {

        $(this).siblings().removeClass('active')

        $(this).addClass('active');

    })

    $("#btn-monthly").click(function () {

        $("#onetimeDForm").css("display", "none");

        $("#monthlyDForm").css("display", "block");

        $("#monthlyDForm .stepTwo").fadeIn("slow");

        $("#monthlyDForm .nextBtnWrap").fadeIn(100);

        $("#monthlyDForm .nextBtnWrap").animate({top: '0px'}, 800, "easeOutExpo");

        $('html, body').animate({scrollTop: $("#monthlyDForm .stepTwo").offset().top - 150}, 1000);

      //$('#Orphans').wrap("<a  data-toggle='modal' href='#myModal'></a>");

    });

    $("#btn-onetime").click(function () {

        $("#monthlyDForm").css("display", "none");

        $("#onetimeDForm").css("display", "block");
        
        $("#onetimeDForm .stepTwo").fadeIn("slow");

        $("#onetimeDForm .nextBtnWrap").fadeIn(100);

        $("#onetimeDForm .nextBtnWrap").animate({top: '0px'}, 800, "easeOutExpo");

        $('html, body').animate({scrollTop: $("#onetimeDForm .stepTwo").offset().top - 150}, 1000);

    });

    //For Monthly

    $("#monthlyDForm #btn-add-donation-monthly").click(function () {

        if ($('.monthlyStarts .selectFtype input[type=radio]:checked').length == 0 && $('.monthlyStarts .selectAmount input[type=radio]:checked').length == 0 && $("#monthly_amount_other").val() == '') {

            $('#mdfund-error').css("display", "block");

            $('#products-error').css("display", "block");

        } else if ($('.monthlyStarts .selectAmount input[type=radio]:checked').length == 0 && $("#monthly_amount_other").val() == '') {

            $('#mdfund-error').css("display", "block");

        } else if ($('.monthlyStarts .selectFtype input[type=radio]:checked').length == 0) {

            $('#products-error').css("display", "block");

        } else if ($("#monthly_amount_other").val() == "0") {

            $('#mdfund-zero-monthly').css("display", "block");

        } else if ($("#monthly_amount_other").val() >=	 1000) {

            $('#mdfund-greater-monthly').css("display", "block");

        }
        
        else {

            $("#monthlyDForm .stepFive").fadeIn("slow");
            
            if($('.monthlyStarts .selectFtype input[type=radio]:checked').attr('id') != "Orphans"){
            
                $('.stepFive #productholder tr').not($('.stepFive #productholder tr:last')).remove();
                
                var amountsum = "";
                
                var fundsum = $('.monthlyStarts .selectFtype input[type=radio]:checked').attr('id');
                
                var radiosum = $('.monthlyStarts .selectAmount input[type=radio]:checked').val();
                
                var othersum = $('#monthlyDForm #monthly_amount_other').val();
                
                    if ($('.monthlyStarts .selectAmount input[type=radio]:checked').length == 0){ 
                
                        amountsum = othersum;
                
                    }else{
                
                        amountsum = radiosum;
                
                    }
                
                $('.stepFive #productholder tr:last').before("<tr><td style='color: #007bb7;'>Monthly Donation</td><td><span id='m_selected_fund'>"+ fundsum +"</span><td><span>&pound; </span> <span id='m_select_amount'>"+amountsum+"</span></td></td></tr>")	
                
                $('#m_total').html(amountsum);

		$('#tax_amount').text(parseFloat(amountsum).toFixed(2));

	        var taxdetect = parseInt(amountsum) + parseInt(amountsum) * 0.25;

	        $('#tax_detect_amount').text(parseFloat(taxdetect).toFixed(2));

            
            }
            
            $('html, body').animate({scrollTop: $("#monthlyDForm .stepFive").offset().top - 50}, 1000);

        }

    });

    $("#monthlyDForm #next-step-2").one("click", function () { 

        $("#monthlyDForm .stepThree").fadeIn("slow");

        $('html, body').animate({scrollTop: $("#monthlyDForm .stepThree").offset().top - 50}, 1000);

    });

    $("#monthlyDForm #next-step-pinfo").one("click", function () {

        $("#monthlyDForm .stepFour").fadeIn("slow");

        $('html, body').animate({scrollTop: $("#monthlyDForm .stepFour").offset().top - 50}, 1000);

    });
    
    //go back step 1
    
    $("#monthlyDForm #back-step-1").click("click", function () {

        $("#monthlyDForm .stepTwo").fadeIn("slow");

        $('html, body').animate({scrollTop: $("#monthlyDForm .stepTwo").offset().top - 50}, 1000);

    });
    
    //go back step 1
    $("#monthlyDForm #back-step-2").click("click", function () {

        $("#monthlyDForm .stepFive").fadeIn("slow");

        $('html, body').animate({scrollTop: $("#monthlyDForm .stepFive").offset().top - 50}, 1000);

    });
    
    //go back step 3
    $("#monthlyDForm #back-step-3").click("click", function () {

        $("#monthlyDForm .stepThree").fadeIn("slow");

        $('html, body').animate({scrollTop: $("#monthlyDForm .stepThree").offset().top - 50}, 1000);

    });

    //For One Time

    $("#onetimeDForm #btn-add-donation-single").click("click", function (e) {

        if ($('.singleStarts .selectFtype input[type=radio]:checked').length == 0 && $('.singleStarts .selectAmount input[type=radio]:checked').length == 0 && $("#single_amount_other").val() == '') {

            $('#mdfund-error-single').css("display", "block");

            $('#products-error-single').css("display", "block");

        } else if ($('.singleStarts .selectAmount input[type=radio]:checked').length == 0 && $("#single_amount_other").val() == '') {

            $('#mdfund-error-single').css("display", "block");

        } else if ($('.singleStarts .selectFtype input[type=radio]:checked').length == 0) {

            $('#products-error-single').css("display", "block");

        } else if ($("#single_amount_other").val() == "0") {

            $('#mdfund-zero-single').css("display", "block");
            
        }else if ($("#single_amount_other").val() >= 99000 ) {

            $('#mdfund-greater-single').css("display", "block");

        }else {

            var userid = $('#session').val();

            var productid = $('.singleStarts .selectFtype input[type=radio]:checked').val();

	    var pname = $('.singleStarts .selectFtype input[type=radio]:checked').prop('alt');		

            if($('.singleStarts .selectAmount input[type=radio]:checked').length == 0){

                var amount = $("#single_amount_other").val(); 

            }else if($("#single_amount_other").val() == ''){

                var amount = $('.singleStarts .selectAmount input[type=radio]:checked').val();

            }
		
            var url="Ajaxfunctios.html";

            $.ajax({

                type: "POST",

                url: url,

                data: {UserId: userid, ProductID: productid, Amount: amount, Funtype: 'ADD'},

                dataType: 'json',

                success: function (response) {

                   $("#" + response["productid"] + "").remove();

                   if(response["productimage"] == null){

                    var cart_img = 'cart-image-01.html';
                
                } else {
                
                    var cart_img = response["productimage"]
                
                }
		
                $('#productholder li:last').before("<li id='" + response["productid"] + "'><span class='cartImg'><img src='https://www.islamic-relief.org.uk/donation/new-donation/donation-img/" + cart_img + "'/></span><span class='basType'>" + response["productname"] + " </span> <span class='basIcons'><a href='javascript:void(0)'  onclick='Remove(" + response["productid"] + ");'><i class='fa fa-trash'></i> </a></span><span class='basPound' id='amtval'>&#163;" + response["prototal"] + "</span>  </li>");

                $('#total').html(response["totalamount"]);

                $('#cartcount').html(response["count"]);			

                $('.donitems').css("display", "block");		

                $('.emptyCard').css("display", "none");

                var singletaxamount = response["totalamount"];

                $('#single_tax_amount').text(parseFloat(singletaxamount).toFixed(2));

                var singletaxdetect = parseInt(singletaxamount) + parseInt(singletaxamount) * 0.25;

                $('#single_tax_detect_amount').text(parseFloat(singletaxdetect).toFixed(2));

                $('.singleStarts .selectAmount input[type=radio]').removeAttr("checked");

                $('.singleStarts .selectFtype input[type=radio]').removeAttr("checked");

                $('#onetimeDForm #single_amount_other').val('');

                }

            });

            $("#onetimeDForm .stepThree").fadeIn("slow");

            $('html, body').animate({scrollTop: $("#onetimeDForm .stepThree").offset().top - 50}, 1000);

            e.stopPropagation();

            $('.dropdown-toggle').dropdown('toggle');
  
    }

    });

    $("#addother").click("click", function (e) {

        $('html, body').animate({scrollTop: $("#onetimeDForm .stepTwo").offset().top - 150}, 1000);

        e.stopPropagation();

        $('.dropdown-toggle').dropdown('toggle');	

    });

    $("#checkout").click("click", function (e) {

        e.stopPropagation();

        $('.dropdown-toggle').dropdown('toggle');	

        $('html, body').animate({scrollTop: $("#onetimeDForm .stepThree").offset().top - 50}, 1000);		

        $('#title-single').focus();

   });

    $("#Orphans").click("click", function (e) {
        
        $('#myModal').modal('show');
    
    });


    $("#orphan-close-btn").click("click", function (e) {

	    $('html, body').animate({scrollTop: $("#monthlyDForm .stepTwo").offset().top - 150}, 1000);

	$('.monthlyStarts .selectFtype input[type=radio]').removeAttr("checked");

    });

    //Hover

    $(".stepOne #btn-monthly").hover(function () {

        $(".stepOne h5.infoDisplay").html("Start a monthly donation");

    }, function () {

        $(".stepOne h5.infoDisplay").html("&nbsp;");

    });

    $(".stepOne #btn-onetime").hover(function () {

        $(".stepOne h5.infoDisplay").html("Make a one-off donation");

    }, function () {

        $(".stepOne h5.infoDisplay").html("&nbsp;");

    });

});