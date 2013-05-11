// Responsive Menu Tutorial from this guy:
//http://toddmotto.com/building-an-html5-responsive-menu-with-media-queries-javascript/





(function () {

    var $nav = $('.nav');
    var $mobile = $('<div class="nav-mobile" title="Navigation"></div>');

    $mobile.on('click', function () {
        var $ul = $nav.find('ul');

        if ($ul.is(':visible')) {
            $ul.hide('blind');
        } else {
            $ul.show('blind');
        }
    });

    $nav.prepend($mobile);

})();