jQuery(document).ready(function(){


var 
	form = jQuery('#donation_page_confirm_2'),
	cache_width = form.width(),
	a4  =[ 595.28,  841.89];  // for a4 size paper width and height


jQuery('#create_pdf').on('click',function(){

	var name = jQuery(this).attr('data-value');

	jQuery('html, body').animate({
        	scrollTop: jQuery("#donation_page_confirm_2").offset().top
    	}, 100);
	//jQuery('body').scrollTop(0);
	createPDF(form,name,cache_width);
});

});
//create pdf
function createPDF(form,name,cache_width){



	getCanvas(form).then(function(canvas){
		var 
		img = canvas.toDataURL("image/png"),
		doc = new jsPDF({
          unit:'px', 
          format:'a4'
        });     
        doc.addImage(img, 'JPEG', 20, 20);
        doc.save(name+'.pdf');
        form.width(cache_width);
	});
}

// create canvas object
function getCanvas(form){


	
	form.width((595.28*1.33333) -80).css('max-width','none');
	return html2canvas(form,{
    	imageTimeout:0,
    	removeContainer:true,
    });	
}

