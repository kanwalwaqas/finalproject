function donationValidation2(){var flag=true;if(isEmpty(document.getElementById('txtAmount'))||!isDecimal(document.getElementById('txtAmount'))){alert('Plase enter valid amount');flag=false;}else{}if(flag==true)return true;else
return false;}function pageSubmit2(){if(donationValidation2()){document.forms['frm_inner'].submit();return false;}else{return false;}}function isEmpty(str){if(isWhitespace1(str)){return true;}if((str.value==null)||(str.value.length==0)){str.select();return true;}return false;}function isWhitespace1(str){var spaces=" \n\t\r";var i;for(i=0;i<str.value.length;++i){if(spaces.indexOf(str.value.charAt(i))==-1){return false;}}str.select();return true;}function isNumeric(str){for(var i=0;i<str.value.length;i++){var ch=str.value.substring(i,i+1);if((ch<"0"||ch>"9")){return false;}}return true;}function isDecimal(str){for(var i=0;i<str.value.length;i++){var ch=str.value.substring(i,i+1);if((ch<"0"||ch>"9")&&ch!="."){return false;}}return true;}function toggleProjects(srcCtl,trgCtl){if(jQuery(srcCtl).val()=="9"){jQuery(trgCtl).val("").attr("disabled","disabled");}else{jQuery(trgCtl).removeAttr("disabled");}}