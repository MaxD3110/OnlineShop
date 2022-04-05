
/* ====================================================================== *
        SCROLLING
 * ====================================================================== */    

    $(window).on("scroll touchmove", function () {
    	if($(document).scrollTop() > 0){
    		$('body').addClass('scrolling');
    		$('.fixed').fadeIn(300);
    	}else{
    		$('body').removeClass('scrolling');
    		$('.fixed').fadeOut(300);
    	}
    });

/* ====================================================================== *
        TO TOP BUTTON
 * ====================================================================== */    

    $('.to-top').on('click', function(e){
    	$('html,body').animate({ scrollTop: 0 }, 'fast');
    });

/* ====================================================================== *
        SUBMENU (LIST OF DEMOS)
 * ====================================================================== */    

    /* KEEP MENU OPEN ON CLICK */
    $('ul.nav li.dropdown').on('click', function(e){
        $(this).addClass('open');
        e.stopImmediatePropagation();
    });

    /* OPEN MENU ON HOVER */
    $('ul.nav li.dropdown').hover(function() {
    	$(this).addClass('open');
    }, function() {
    	$(this).removeClass('open');
    });

/* ====================================================================== *
        USAGE EXAMPLES BUTTON
 * ====================================================================== */    

    $('.browse').on('click', function(e){
        e.preventDefault();
        $('html, body').animate({
            //scrollTop: $("#start_browsing").offset().top-56
            scrollTop: $("#start_browsing").offset().top-66
        }, 500);
    });

/* ====================================================================== *
        POPOVER FOR THE SUBMENU
 * ====================================================================== */    

    $('.dropdown-menu-content a').popover({
        placement: 'left',
        html: true,
        trigger: 'hover',
        content: function () {
            return '<div class="popover_img_container"><img src="img/demos/'+$(this).attr('href').split(".html").join('.jpg') + '" /></div>';
        },
    });

    $('body').on('mouseover', '.popover', function(){
        $('ul.nav li.dropdown').removeClass('open');
    })

