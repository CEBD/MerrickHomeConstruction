$(document).ready(function () {
    //change this to desired target
    var $h3S = $('.projection-page').find('h3');
    var $menu = $('<ul>');
    var scrollSpeed = 500;
    var menuScrollSpeed = 750;
    var $htmlBody = $('html,body');
    var $taxonomyMenu = $('.taxonomy-menu');
    var minBodyWidth = 480;
    var activeClass = 'active';

    $h3S.each(function () {
        var message = $(this).text();
        var linkId = 'linkMenu_' + message.replace(new RegExp(' ', 'g'), '').toLowerCase();
        $(this).attr('id', linkId);
        var $menuItem = '<li><a href="#' + linkId + '" class="linkMenu_a">' + message + '</a></li>';
        $menu.append($menuItem);
    });

    $menu.find('.linkMenu_a').on('click', function (ev) {
        ev.preventDefault();
        $menu.find('.linkMenu_a').removeClass(activeClass);
        $(this).addClass(activeClass);

        var $target = $(this.hash);
        $h3S.removeClass(activeClass);
        $target.addClass(activeClass);
        $htmlBody.animate({ scrollTop: $target.offset().top }, scrollSpeed);
    });

    $('.tax-menu-navigation').html($menu);
    var taxonomyMenuPadding = 15;
    var headerheight = $('#pageHeader').height() + taxonomyMenuPadding;
    var scrollTimeout = null;


    var handleMenu = function() {
        if (scrollTimeout) {
            clearTimeout(scrollTimeout);
        }

        scrollTimeout = setTimeout(function() {
            if ($('body').width() > minBodyWidth && $taxonomyMenu.is(':hidden')) {
                $taxonomyMenu.show('fade');
            } else if ($('body').width() < minBodyWidth) {
                $taxonomyMenu.hide();
            }

            if ($(window).scrollTop() < headerheight) {
                $taxonomyMenu.animate({ 'top': headerheight });
            } else {
                $taxonomyMenu.animate({ 'top': taxonomyMenuPadding });
            }
        }, 50);
    };

    $(window).on('scroll', handleMenu).on('resize', handleMenu);
});

    
