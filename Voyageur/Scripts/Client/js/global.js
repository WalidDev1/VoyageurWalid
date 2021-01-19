(function ($) {
    'use strict';
    /*==================================================================
        [ Daterangepicker ]*/
    
    
    try {
    
        $('#input-start').datepicker();
        $('#input-end').datepicker();
    
    
    } catch(er) {console.log(er);}
    /*==================================================================
        [ Input Number ]*/
    
    try {
    
        var inputCon = $('.js-number-input');
    
        inputCon.each(function () {
            var that = $(this);
    
            var btnPlus = that.find('.plus');
            var btnMinus = that.find('.minus');
            var qtyInput = that.find('.quantity');
    
    
            btnPlus.on('click', function () {
                var oldValue = parseInt(qtyInput.val());
                var newVal = oldValue + 1;
                qtyInput.val(refineString(newVal));
            });
    
            btnMinus.on('click', function () {
                var min = 0;
    
                var oldValue = parseInt(qtyInput.val());
                if (oldValue <= min) {
                    var newVal = oldValue;
                } else {
                    var newVal = oldValue - 1;
                }
                qtyInput.val(refineString(newVal));
            });
        });
    
        function refineString(s) {
            if(parseInt(s) <= 1) return parseInt(s) + " Personne";
            else return parseInt(s) + " Personnes";
        }
    
    }catch (e) {
        console.log(e);
    }

})(jQuery);