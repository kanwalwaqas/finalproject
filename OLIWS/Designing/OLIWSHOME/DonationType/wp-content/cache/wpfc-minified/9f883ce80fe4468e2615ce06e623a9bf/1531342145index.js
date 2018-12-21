// source --> https://www.muslimcharity.org.uk/wp-content/plugins/the-events-calendar/src/resources/js/tribe-events.min.js?ver=4.6.11.1 
var tribe_ev=window.tribe_ev||{},tribe_debug=!0;window.debug=function(){function e(e){!r||!a&&s&&s.log||r.apply(i,e)}function t(e){return d>0?d>e:l.length+d<=e}for(var r,a,i=this,n=Array.prototype.slice,s=i.console,o={},d=9,l=["error","warn","info","debug","log"],u="assert clear count dir dirxml exception group groupCollapsed groupEnd profile profileEnd table time timeEnd trace".split(" "),c=u.length,b=[];--c>=0;)!function(e){o[e]=function(){0!==d&&s&&s[e]&&s[e].apply(s,arguments)}}(u[c]);for(c=l.length;--c>=0;)!function(r,a){o[a]=function(){var o=n.call(arguments),d=[a].concat(o);b.push(d),e(d),s&&t(r)&&(s.firebug?s[a].apply(i,o):s[a]?s[a](o):s.log(o))}}(c,l[c]);return o.setLevel=function(e){d="number"==typeof e?e:9},o.setCallback=function(){var t=n.call(arguments),i=b.length,s=i;for(r=t.shift()||null,a="boolean"==typeof t[0]&&t.shift(),s-="number"==typeof t[0]?t.shift():i;s<i;)e(b[s++])},o}(),Object.prototype.hasOwnProperty.call(window,"tribe_ev")&&(tribe_ev.diagnostics={init:[]});var tribe_storage,t_fail,t_uid;try{t_uid=new Date,(tribe_storage=window.localStorage).setItem(t_uid,t_uid),t_fail=tribe_storage.getItem(t_uid)!=t_uid,tribe_storage.removeItem(t_uid),t_fail&&(tribe_storage=!1)}catch(e){tribe_storage=!1}var tribeDateFormat=function(){var e=/d{1,4}|m{1,4}|yy(?:yy)?|([HhMsTt])\1?|[LloSZ]|"[^"]*"|'[^']*'/g,t=/\b(?:[PMCEA][SDP]T|(?:Pacific|Mountain|Central|Eastern|Atlantic) (?:Standard|Daylight|Prevailing) Time|(?:GMT|UTC)(?:[-+]\d{4})?)\b/g,r=/[^-+\dA-Z]/g,a=function(e,t){for(e=String(e),t=t||2;e.length<t;)e="0"+e;return e};return function(i,n,s){var o=tribeDateFormat;if(1!=arguments.length||"[object String]"!=Object.prototype.toString.call(i)||/\d/.test(i)||(n=i,i=void 0),"string"==typeof i&&(i=i.replace(/-/g,"/")),i=i?new Date(i):new Date,!isNaN(i)){n=String(o.masks[n]||n||o.masks["default"]),"UTC:"==n.slice(0,4)&&(n=n.slice(4),s=!0);var d=s?"getUTC":"get",l=i[d+"Date"](),u=i[d+"Day"](),c=i[d+"Month"](),b=i[d+"FullYear"](),y=i[d+"Hours"](),v=i[d+"Minutes"](),_=i[d+"Seconds"](),m=i[d+"Milliseconds"](),f=s?0:i.getTimezoneOffset(),p={d:l,dd:a(l),ddd:o.i18n.dayNames[u],dddd:o.i18n.dayNames[u+7],m:c+1,mm:a(c+1),mmm:o.i18n.monthNames[c],mmmm:o.i18n.monthNames[c+12],yy:String(b).slice(2),yyyy:b,h:y%12||12,hh:a(y%12||12),H:y,HH:a(y),M:v,MM:a(v),s:_,ss:a(_),l:a(m,3),L:a(m>99?Math.round(m/10):m),t:y<12?"a":"p",tt:y<12?"am":"pm",T:y<12?"A":"P",TT:y<12?"AM":"PM",Z:s?"UTC":(String(i).match(t)||[""]).pop().replace(r,""),o:(f>0?"-":"+")+a(100*Math.floor(Math.abs(f)/60)+Math.abs(f)%60,4),S:["th","st","nd","rd"][l%10>3?0:(l%100-l%10!=10)*l%10]};return n.replace(e,function(e){return e in p?p[e]:e.slice(1,e.length-1)})}}}();tribeDateFormat.masks={"default":"ddd mmm dd yyyy HH:MM:ss",tribeQuery:"yyyy-mm-dd",tribeMonthQuery:"yyyy-mm",0:"yyyy-mm-dd",1:"m/d/yyyy",2:"mm/dd/yyyy",3:"d/m/yyyy",4:"dd/mm/yyyy",5:"m-d-yyyy",6:"mm-dd-yyyy",7:"d-m-yyyy",8:"dd-mm-yyyy",9:"yyyy.mm.dd",10:"mm.dd.yyyy",11:"dd.mm.yyyy",m0:"yyyy-mm",m1:"m/yyyy",m2:"mm/yyyy",m3:"m/yyyy",m4:"mm/yyyy",m5:"m-yyyy",m6:"mm-yyyy",m7:"m-yyyy",m8:"mm-yyyy"},tribeDateFormat.i18n={dayNames:["Sun","Mon","Tue","Wed","Thu","Fri","Sat","Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"],monthNames:["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec","January","February","March","April","May","June","July","August","September","October","November","December"]};var tribeUtils={getQueryVars:function(e){var t={},e=e||location;return e.search.substr(1).split("&").forEach(function(e){t[e.split("=")[0]]=e.split("=")[1]}),t}};Date.prototype.format=function(e,t){return tribeDateFormat(this,e,t)},function(){function e(e,t){var r=arguments.callee;return r.cache[e]||(r.cache[e]=function(){var t=e,a=/^[\w\-]+$/.test(e)?r.get(e):(t="template(string)",e),i=1,n=("try { "+(r.variable?"var "+r.variable+" = this.stash;":"with (this.stash) { ")+"this.ret += '"+a.replace(/\[\[/g,"").replace(/\]\]/g,"").replace(/'(?![^\x11\x13]+?\x13)/g,"\\x27").replace(/^\s*|\s*$/g,"").replace(/\n/g,function(){return"';\nthis.line = "+ ++i+"; this.ret += '\\n"}).replace(/\x11=raw(.+?)\x13/g,"' + ($1) + '").replace(/\x11=(.+?)\x13/g,"' + this.escapeHTML($1) + '").replace(/\x11(.+?)\x13/g,"'; $1; this.ret += '")+"'; "+(r.variable?"":"}")+"return this.ret;} catch (e) { throw 'TemplateError: ' + e + ' (on "+t+"' + ' line ' + this.line + ')'; } //@ sourceURL="+t+"\n").replace(/this\.ret \+= '';/g,""),s=new Function(n),o={"&":"&amp;","<":"&lt;",">":"&gt;",'"':"&#x22;","'":"&#x27;"},d=function(e){return(""+e).replace(/[&<>\'\"]/g,function(e){return o[e]})};return function(e){return s.call(r.context={escapeHTML:d,line:1,ret:"",stash:e})}}()),t?r.cache[e](t):r.cache[e]}function t(t,r){var a=function(r){return r.include=function(t,r){var a={};for(var i in e.context.stash)e.context.stash.hasOwnProperty(i)&&(a[i]=e.context.stash[i]);if(r)for(var i in r)r.hasOwnProperty(i)&&(a[i]=r[i]);var n=e.context;n.ret+=e(t,a),e.context=n},r.wrapper=function(t,r){var a=e.context.ret;e.context.ret="",r.apply(e.context);var i=e.context.ret,n=e.context.stash.content;e.context.stash.content=i,e.context.ret=a+e(t,e.context.stash),e.context.stash.content=n},e(t,r)};return r?a(r):a}e.cache={},e.get=function(e){return document.getElementById(e).innerHTML},e.get=function(e){var r=t.get;return r?r(e):document.getElementById(e).innerHTML},this.tribe_tmpl=e,this.tribe_tmpl_extended=t}(),function(e,t){if(e.fn.tribe_clear_form=function(){return this.each(function(){var t=this.type,r=this.tagName.toLowerCase();return"form"==r?e(":input",this).tribe_clear_form():void("text"==t||"password"==t||"textarea"==r?this.value="":"checkbox"==t||"radio"==t?this.checked=!1:"select"==r&&(this.selectedIndex=0))})},e.fn.tribe_has_attr=function(e){return this.attr(e)!==t},e.fn.tribe_spin=function(){var t=e(".tribe-events-ajax-loading:first").clone().addClass("tribe-events-active-spinner");t.prependTo(document.getElementById("tribe-events-content")),e(this).addClass("tribe-events-loading").css("opacity",.25)},"undefined"!=typeof e.fn.datepicker&&"undefined"!=typeof e.fn.datepicker.noConflict){var r=e.fn.datepicker.noConflict();e.fn.bootstrapDatepicker=r}"undefined"!=typeof tribe_bootstrap_datepicker_strings&&null!=tribe_bootstrap_datepicker_strings.dates&&(e.fn.bootstrapDatepicker.dates.en=tribe_bootstrap_datepicker_strings.dates)}(jQuery),function(e,t,r,a,i,n){tribe_ev.fn={current_date:function(){var e=new Date,t=e.getDate(),r=e.getMonth()+1,a=e.getFullYear();return t<10&&(t="0"+t),r<10&&(r="0"+r),a+"-"+r+"-"+t},disable_inputs:function(e,t){r(e).find(t).prop("disabled",!0),r(e).find(".select2-container").length&&r(e).find(".select2-container").each(function(){var e=r(this).attr("id"),t=r("#"+e);t.select2("disable")})},disable_empty:function(e,t){r(e).find(t).each(function(){""===r(this).val()&&r(this).prop("disabled",!0)})},enable_inputs:function(e,t){r(e).find(t).prop("disabled",!1),r(e).find(".select2-container").length&&r(e).find(".select2-container").each(function(){var e=r(this).attr("id"),t=r("#"+e);t.select2("enable")})},execute_resize:function(){var e=tribe_ev.data.v_width;tribe_ev.fn.update_viewport_variables(),e!==tribe_ev.data.v_width&&(tribe_ev.fn.mobile_class(),r(tribe_ev.events).trigger("tribe_ev_resizeComplete"),r(tribe_ev.events).trigger("resize-complete.tribe"))},get_base_url:function(){var a="",i=r(t.getElementById("tribe-events-header")),n=r('link[rel="canonical"]');return a=n.length?n.attr("href"):i.length?i.data("baseurl"):e.location.origin+e.location.path},update_base_url:function(e){var a=r(t.getElementById("tribe-events-header")),i=r('link[rel="canonical"]');i.length?i.attr("href",e):a.length&&a.data("baseurl",e).attr("data-baseurl",e)},get_category:function(){return tribe_ev.fn.is_category()?r(t.getElementById("tribe-events")).data("category"):""},get_day:function(){var e="";return r(t.getElementById("tribe-bar-date")).length&&(e=r(t.getElementById("tribe-bar-date-day")).val()),a&&debug.info('TEC Debug: tribe_ev.fn.get_day returned this date: "'+e+'".'),e},get_params:function(){return location.search.substr(1)},get_url_param:function(e){return decodeURIComponent((new RegExp("[?|&]"+e+"=([^&;]+?)(&|#|;|$)").exec(location.search)||[,""])[1].replace(/\+/g,"%20"))||null},in_params:function(e,t){return e.toLowerCase().indexOf(t)},invalid_date:function(e){return e=new Date(e),isNaN(e)},invalid_date_in_params:function(e){if(e.hasOwnProperty("tribe-bar-date")){var t=new Date(e["tribe-bar-date"]);return isNaN(t)}return!1},is_category:function(){var e=r(t.getElementById("tribe-events"));return!(!e.length||!e.tribe_has_attr("data-category")||""===e.data("category"))},is_featured:function(){return"1"==r(t.getElementById("tribe-events")).data("featured")},mobile_class:function(){var e=r("body");tribe_ev.data.v_width<=tribe_ev.data.mobile_break?e.addClass("tribe-mobile"):e.removeClass("tribe-mobile")},maybe_default_view_change:function(){if(!tribe_ev.data.default_view||!tribe_ev.data.default_mobile_view||tribe_ev.data.default_view==tribe_ev.data.default_mobile_view||!tribe_ev.state.view||tribe_ev.data.default_mobile_view==tribe_ev.state.view||tribe_ev.data.cur_url==tribe_ev.data.base_url)return!1;var e=r("body");if(!e.hasClass("tribe-mobile"))return!1;var t=r(".tribe-bar-views-option"),a=".tribe-bar-views-option-"+tribe_ev.data.default_mobile_view,i=t.filter(a);i.trigger("click")},parse_string:function(e){var t={};return e.replace(/([^&=]+)=?([^&]*)(?:&+|$)/g,function(e,r,a){(t[r]=t[r]||[]).push(a)}),a&&debug.info("TEC Debug: tribe_ev.fn.parse_string returned this map:",t),t},pre_ajax:function(e){e&&"function"==typeof e&&e()},scroll_to:function(e,t,a){r("html, body").stop().animate({scrollTop:r(e).offset().top-t},{duration:a})},serialize:function(e,t){tribe_ev.fn.enable_inputs(e,t),tribe_ev.fn.disable_empty(e,t);var i=r(e).serialize();return tribe_ev.fn.disable_inputs(e,t),a&&i&&debug.info('TEC Debug: tribe_ev.fn.serialize returned these params: "'+i),i},set_form:function(e){var i=r("body"),n=r(t.getElementById("tribe-bar-form"));i.addClass("tribe-reset-on"),n.length&&n.tribe_clear_form(),e=tribe_ev.fn.parse_string(e),r.each(e,function(e,t){if("action"!==e){var a=decodeURIComponent(e),i="";if(1===t.length)Array.isArray(t)&&(t=t[0]),t=decodeURIComponent(t.replace(/\+/g,"%20")),r('[name="'+a+'"]').is('input[type="text"], input[type="hidden"]')?r('[name="'+a+'"]').val(t):r('[name="'+a+'"][value="'+t+'"]').is(":checkbox, :radio")?r('[name="'+a+'"][value="'+t+'"]').prop("checked",!0):r('[name="'+a+'"]').is("select")&&r('select[name="'+a+'"] option[value="'+t+'"]').attr("selected",!0);else for(var n=0;n<t.length;n++)i=r('[name="'+a+'"][value="'+t[n]+'"]'),i.is(":checkbox, :radio")?i.prop("checked",!0):r('select[name="'+a+'"] option[value="'+t[n]+'"]').attr("selected",!0)}}),i.removeClass("tribe-reset-on"),a&&debug.info('TEC Debug: tribe_ev.fn.set_form fired these params: "'+e)},setup_ajax_timer:function(e){var t=500;clearTimeout(tribe_ev.state.ajax_timer),tribe_ev.tests.reset_on()||(tribe_ev.state.ajax_timer=setTimeout(function(){e()},t),a&&debug.info('TEC Debug: tribe_ev.fn.setup_ajax_timer fired with a timeout of "'+t+'" ms'))},snap:function(e,t,a){r(t).on("click",a,function(t){t.preventDefault(),r("html, body").animate({scrollTop:r(e).offset().top-120},{duration:0})})},tooltips:function(){var a=r(t.getElementById("tribe-events")),i=r("body"),n=a.hasClass("tribe-events-shortcode"),s=a.hasClass("view-month")||i.hasClass("events-gridview"),o=a.hasClass("view-week")||i.hasClass("tribe-events-week"),d=a.hasClass("view-photo")||i.hasClass("tribe-events-photo"),l=a.hasClass("view-day")||i.hasClass("tribe-events-day"),u=a.hasClass("view-list")||i.hasClass("events-list"),c=(a.hasClass("view-map")||i.hasClass("tribe-events-map"),i.hasClass("single-tribe_events"));a.on("mouseenter",'div[id*="tribe-events-event-"], div.event-is-recurring',function(){var t,a=0,i=r(this);if(s?a=i.find("a").outerHeight()+18:c||l||u?a=i.outerHeight()+12:d&&(a=i.outerHeight()+10),i.parents(".tribe-events-calendar-widget").length&&(a=i.outerHeight()-6),!o||n)if(s||n){if(t=i.find(".tribe-events-tooltip"),!t.length){var b=i.data("tribejson");"string"==typeof b&&(b=r.parseJSON(b));var y=i.hasClass("tribe-event-featured")?"tribe_tmpl_tooltip_featured":"tribe_tmpl_tooltip";i.append(tribe_tmpl(y,b)),t=i.find(".tribe-events-tooltip")}var v=i.offset().top-(r(e).scrollTop()+50),_=t.outerHeight();v<_&&(a=-_,t.addClass("tribe-events-tooltip-flipdown")),t.css("bottom",a).show()}else i.find(".tribe-events-tooltip").css("bottom",a).show()}).on("mouseleave",'div[id*="tribe-events-event-"], div[id*="tribe-events-daynum-"]:has(a), div.event-is-recurring',function(){var e=r(this).find(".tribe-events-tooltip");e.stop(!0,!1).fadeOut(200,function(){e.removeClass("tribe-events-tooltip-flipdown")})})},update_picker:function(t){var i=r("#tribe-bar-date");r().bootstrapDatepicker&&i.length?(tribe_ev.state.updating_picker=!0,e.attachEvent&&!e.addEventListener&&(i.bootstrapDatepicker("remove"),i.val(""),i.bootstrapDatepicker(tribe_ev.data.datepicker_opts)),i.bootstrapDatepicker("setDate",t),tribe_ev.state.updating_picker=!1,a&&debug.info('TEC Debug: tribe_ev.fn.update_picker sent "'+t+'" to the boostrapDatepicker')):i.length?(i.val(t),a&&debug.warn('TEC Debug: tribe_ev.fn.update_picker sent "'+t+'" to '+i)):a&&debug.warn('TEC Debug: tribe_ev.fn.update_picker couldnt send "'+t+'" to any object.')},update_viewport_variables:function(){tribe_ev.data.v_height=r(e).height(),tribe_ev.data.v_width=r(e).width()},url_path:function(e){return e.split("?")[0]},equal_height:function(e){var t=0;e.css("height","auto"),e.each(function(){var e=r(this).outerHeight();e>t&&(t=e)}),setTimeout(function(){e.css("height",t)},100)}},tribe_ev.tests={live_ajax:function(){var e=r(t.getElementById("tribe-events"));return!(!e.length||!e.tribe_has_attr("data-live_ajax")||"1"!=e.data("live_ajax"))},map_view:function(){return!("undefined"==typeof GeoLoc||!GeoLoc.map_view)},no_bar:function(){return r("body").is(".tribe-bar-is-disabled")},pushstate:!(!e.history||!history.pushState),reset_on:function(){return r("body").is(".tribe-reset-on")},starting_delim:function(){return tribe_ev.state.cur_url.indexOf("?")!=-1?"&":"?"},webkit:"WebkitAppearance"in t.documentElement.style},tribe_ev.data={ajax_response:{},base_url:"",cur_url:tribe_ev.fn.url_path(t.URL),cur_date:tribe_ev.fn.current_date(),datepicker_formats:{main:["yyyy-mm-dd","m/d/yyyy","mm/dd/yyyy","d/m/yyyy","dd/mm/yyyy","m-d-yyyy","mm-dd-yyyy","d-m-yyyy","dd-mm-yyyy","yyyy.mm.dd","mm.dd.yyyy","dd.mm.yyyy"],month:["yyyy-mm","m/yyyy","mm/yyyy","m/yyyy","mm/yyyy","m-yyyy","mm-yyyy","m-yyyy","mm-yyyy","yyyy.mm","mm.yyyy","mm.yyyy"]},datepicker_opts:{},default_permalinks:!i.permalink_settings.length,initial_url:tribe_ev.fn.url_path(t.URL),mobile_break:768,default_mobile_view:null,default_view:null,params:tribe_ev.fn.get_params(),v_height:0,v_width:0},tribe_ev.events={},tribe_ev.state={ajax_running:!1,ajax_timer:0,ajax_trigger:"",category:"",date:"",datepicker_format:"0",do_string:!1,featured:!1,filters:!1,filter_cats:!1,initial_load:!0,mdate:"",paged:1,page_title:"",params:{},popping:!1,pushstate:!0,pushcount:0,recurrence:!1,updating_picker:!1,url_params:{},view:"",view_target:""}}(window,document,jQuery,tribe_debug,tribe_js_config),function(e,t,r,a,i,n,s,o,d){r(t).ready(function(){function l(){r(".tribe-events-list").length&&r(".tribe-events-list-separator-month").prev(".vevent").addClass("tribe-event-end-month")}function u(){var e=!0;if("undefined"!=typeof tribe_js_config.force_filtered_ical_link&&(e=!tribe_js_config.force_filtered_ical_link),e){var a=t.URL,i="?";a.indexOf("?")>0&&(i="&");var n=a+i+"ical=1&tribe_display="+s.view;r("a.tribe-events-ical").attr("href",n)}}d&&debug.info("TEC Debug: Tribe Events JS init, Init Timer started from tribe-events.js."),n.update_viewport_variables();var c,b=r("body"),y=r(t.getElementById("tribe-events")),v=(r(t.getElementById("tribe-events-content")),r(t.getElementById("tribe-events-header")));y.removeClass("tribe-no-js"),s.category=n.get_category(),a.base_url=n.get_base_url(),s.page_title=t.title;var _=n.get_url_param("tribe_event_display");if(_?s.view=_:v.length&&v.tribe_has_attr("data-view")&&(s.view=v.data("view")),y.tribe_has_attr("data-datepicker_format")&&1===y.attr("data-datepicker_format").length&&(s.datepicker_format=y.attr("data-datepicker_format")),s.view&&d&&debug.time("Tribe JS Init Timer"),r(i).on("tribe_ev_collectParams",function(){if("undefined"!=typeof tribe_ev.state&&"undefined"!=typeof tribe_ev.state.params&&(-1!==tribe_ev.fn.in_params(tribe_ev.state.params,"eventdate")||-1!==tribe_ev.fn.in_params(tribe_ev.state.params,"tribe_event_display"))&&r(t.getElementById("tribe-events")).is(".tribe-events-shortcode")){var a=r(t.getElementById("tribe-events-header")),i=r('link[rel="canonical"]'),n=null;if(n=i.length?i.attr("href"):a.length?a.data("baseurl"):e.location.origin+e.location.path,tribe_ev.state.params+="&baseurl="+n,a.length){var s=/tribe_events_cat=([^&]*)/gi.exec(a.data("baseurl"));if(s=s&&"undefined"!=typeof s[1]?s[1]:null){var o=new RegExp("tribe_event_category="+s);tribe_ev.state.params.match(o)||(tribe_ev.state.params+="&tribe_event_category="+s),"string"!=typeof tribe_ev.state.url_params||tribe_ev.state.url_params.match(o)||(tribe_ev.state.url_params+="&tribe_event_category="+s)}}}}),y.length){var m=y.tribe_has_attr("data-mobilebreak");m=!1===m?y.find("[data-mobilebreak]").eq(0):y,m.length&&(a.mobile_break=parseInt(m.data("mobilebreak"),10));var f=y.tribe_has_attr("data-default-mobile-view");f=!1===f?y.find("[data-default-mobile-view]").eq(0):y,f.length&&(a.default_mobile_view=f.data("defaultMobileView"),a.default_view=f.data("defaultView"))}y.length&&a.mobile_break>0&&b.addClass("tribe-is-responsive"),r(".tribe-events-calendar-widget").not(":eq(0)").hide(),n.tooltips(),n.mobile_class(),l(),r(".tribe-events-list .tribe-events-notices").length&&r("#tribe-events-header .tribe-events-sub-nav").empty(),r(".tribe-events-list").length&&r(".tribe-events-list-separator-month").prev(".vevent").addClass("tribe-event-end-month"),r(i).on("tribe_ev_ajaxSuccess",function(){r(".tribe-events-active-spinner").remove(),l()}),r(i).on("tribe_ev_ajaxSuccess",function(){u()}),u(),r(e).resize(function(){clearTimeout(c),c=setTimeout(n.execute_resize,200)}),d&&(debug.groupCollapsed("TEC Debug: Browser and events settings information:"),debug.log('User agent reported as: "'+navigator.userAgent),debug.log('Live ajax returned its state as: "'+o.live_ajax()),s.view&&debug.log('Tribe js detected the view to be: "'+s.view),debug.log('Supports pushstate: "'+o.pushstate),debug.groupEnd(),debug.info("TEC Debug: tribe-events.js successfully loaded"))})}(window,document,jQuery,tribe_ev.data,tribe_ev.events,tribe_ev.fn,tribe_ev.state,tribe_ev.tests,tribe_debug);
// source --> https://www.muslimcharity.org.uk/wp-content/plugins/js_composer/assets/js/vendors/woocommerce-add-to-cart.js?ver=4.11.2 
window.jQuery( document ).ready( function ( $ ) {
	$( 'body' ).on( 'adding_to_cart', function ( event, $button, data ) {
		$button && $button.hasClass( 'vc_gitem-link' ) && $button
			.addClass( 'vc-gitem-add-to-cart-loading-btn' )
			.parents( '.vc_grid-item-mini' )
			.addClass( 'vc-woocommerce-add-to-cart-loading' )
			.append( $( '<div class="vc_wc-load-add-to-loader-wrapper"><div class="vc_wc-load-add-to-loader"></div></div>' ) );
	} ).on( 'added_to_cart', function ( event, fragments, cart_hash, $button ) {
		if ( 'undefined' === typeof($button) ) {
			$button = $( '.vc-gitem-add-to-cart-loading-btn' );
		}
		$button && $button.hasClass( 'vc_gitem-link' ) && $button
			.removeClass( 'vc-gitem-add-to-cart-loading-btn' )
			.parents( '.vc_grid-item-mini' )
			.removeClass( 'vc-woocommerce-add-to-cart-loading' )
			.find( '.vc_wc-load-add-to-loader-wrapper' ).remove();
	} );
} );