function resizeMaxHeight(element){
    var maxHeight = 0;
    jQuery(element).each(function(){
        var height = jQuery(this).outerHeight();
        if(height > maxHeight) maxHeight = height;
    });
    jQuery(element).each(function(){
        jQuery(this).outerHeight(maxHeight);
    });
}

function resizeMinHeight(element){
    var minHeight = 0;
    var count = 0;
    jQuery(element).each(function(){
    	count++;
        var height = jQuery(this).outerHeight();
        if(count === 1){
    		minHeight = height;
    	}
    	else {
    		if(height < minHeight) minHeight = height;
    	}
    });
    jQuery(element).each(function(){
        jQuery(this).outerHeight(minHeight);
    });
}

function resizing(){
    if(jQuery("#social").length){
        var twitterHeight = jQuery('#social #twitter').height();
        jQuery("#social #facebook").mCustomScrollbar({
            setHeight: twitterHeight,
            theme:"minimal-dark"
        });
        resizeMaxHeight(jQuery("#social .container > div"));
        setTimeout(function(){
            resizeMaxHeight(jQuery("#social .container > div"));
        }, 1000);
/*
        var fbHeight = jQuery('#facebook').height();
        var postHeight = fbHeight / 2;
        jQuery('.fb_post').height((postHeight));

        jQuery('.fb_post').each(function(){
            var fbHeaderHeight = jQuery(this).children('div.fb_header').height();
            jQuery(this).children('div.fb_text').height(((postHeight - fbHeaderHeight) / 100 * 20));
            jQuery(this).children('div.fb_img').height(((postHeight - fbHeaderHeight) / 100 * 80));
        });
*/
    }
}
jQuery(document).ready(function(){
	resizing();
    jQuery('#sidebar .menu_icon').click(function(){
        jQuery('#sidebar').toggleClass('active');
    });
    jQuery('.has_sub_menu').click(function(){
        jQuery(this).parent().children('ul.sub_menu_section').toggleClass('expand');
    });
    jQuery('#header_bottom .menu_icon').click(function(){
        jQuery("nav#main_menu").toggleClass('expand');
    });
});
jQuery(window).resize(function(){
    resizing();
})

