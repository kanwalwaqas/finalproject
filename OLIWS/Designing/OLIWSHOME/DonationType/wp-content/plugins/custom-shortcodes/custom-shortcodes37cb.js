//Custom Shortcode JS

jQuery(document).ready(function(){

	//console.log('I am Loaded');

	qfloadcart();

	jQuery("#qf_country").change(function(){

		var country = jQuery(this).val();

		//console.log(country);

		jQuery('#qf_animal').prop('disabled', 'disabled');
		jQuery('#qf_animal option').eq(0).text('Loading...');
		
		//alert('a');
		//make the ajax call
		jQuery.ajax({
			url: '/wp-content/plugins/custom-shortcodes/ajax.php?action=1&cid='+encodeURIComponent(country),
       		type: 'GET',
			//dataType: 'html',
       		success: function(data) {
				
				//jQuery('#qf_animal').html('');
				//jQuery('#qf_animal option').eq(0).text('Loading1...');
				//jQuery('#qf_animal').html(eval(data));

				//alert('1');
				jQuery('#qf_animal').html('');
				jQuery('#qf_animal').html(eval(data));
				
			},
                	complete: function (data) {
                    		jQuery('#qf_animal').removeAttr('disabled');
                	}
		});		
	});


	jQuery("#qf_animal").change(function(){

		var pamt = jQuery(this).val().split('_');
		jQuery("#qf_amount").val(pamt[1]);

		jQuery("#qf_qty option").eq(1).prop("selected", true);
		//console.log(pamt );
	});

	jQuery("#qf_qty").change(function(){

		var qty = jQuery(this).val();

		var pamt = jQuery("#qf_animal").val().split('_');

		var amt = qty*pamt[1];

		jQuery("#qf_amount").val(amt);
	});

	jQuery("#qf_sub").click(function(e){

		e.preventDefault();

		data = jQuery("#qurbani_form").serialize();

		//make the ajax call
		jQuery.ajax({
			url: '/wp-content/plugins/custom-shortcodes/ajax.php?action=2&isAjax=1&'+data,
       		type: 'GET',
       		success: function(data) {
				//jQuery('#qf_animal').html('');
				//jQuery('#qf_animal').html(eval(data));
				if(data != '')
				{
					jQuery(".qf_msg").html('');
					jQuery(".qf_msg").html('<span class="qfac">Your Qurbani has been added to Cart.</span> <a href="/checkout">Proceed to Checkout</a>');
					jQuery(".qf_cart").html(data);
					if(data){
						jQuery(".qf_cart").append('<a href="/checkout">Checkout</a>');
					}
				}
				
			},
			beforeSend: function () {
                    		jQuery('.qfoverlay').show();
                	},
                	complete: function () {
                    		jQuery('.qfoverlay').hide();
                	}
		});		
	});

	jQuery("#amq").click(function(){
		jQuery("#qf_country option").eq(0).prop("selected", true);
		jQuery("#qf_animal").html('<option value="">Select Animal</option>');
		jQuery("#qf_qty option").eq(0).prop("selected", true);
		jQuery("#qf_amount").val('');
	});



	jQuery(window).bind("pageshow", function() {

		var pathname = window.location.pathname; 

		if( pathname == '/campaign/qurbani/')
		{
			jQuery('form#qurbani_form').get(0).reset(); 
		}
	});


});

	function qfremovedon(pid,cid,tid)
	{
		jQuery.ajax({
			url: '/wp-content/plugins/custom-shortcodes/ajax.php?remove=1&pid='+encodeURIComponent(pid)+'&cid='+encodeURIComponent(cid)+'&tid='+encodeURIComponent(tid),
       		type: 'GET',
       		success: function(data) {
				jQuery(".qf_cart").html(data);
				if(data){
					jQuery(".qf_cart").append('<a href="/checkout">Checkout</a>');
				}
       		}
    		});
	}

	function qfloadcart()
	{
		jQuery.ajax({
			url: '/wp-content/plugins/custom-shortcodes/ajax.php?load=1',
       		type: 'GET',
       		success: function(data) {
				//alert('a');

				
				jQuery(".qf_cart").html(data);

				if(data){
					jQuery(".qf_cart").append('<a href="/checkout">Checkout</a>');
				}
       		}
    		});
	}