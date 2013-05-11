$('#site-title').find('.site-title-link').on('mouseenter', function() {

    var $icon = $('.site-title-icon');


    var currentRotation = getRotationDegrees($icon[0]);


    var rotateTo = 355 + currentRotation;

    console.log(rotateTo, currentRotation);

    $('.site-title-icon').css({
        "-webkit-transform": 'rotate(' + rotateTo + 'deg) scale(0.5)',
        'color' : '#fff'
    });

}).on('mouseleave', function() {
    $('.site-title-icon').css({
        "-webkit-transform": 'rotate(0deg) scale(1)',
        'color' : '#000'
    });
});


function getRotationDegrees(element) {
    // get the computed style object for the element
    var style = window.getComputedStyle(element);
    // this string will be in the form 'matrix(a, b, c, d, tx, ty)'
    var transformString = style['-webkit-transform']
                       || style['-moz-transform']
                       || style['transform'];
    if (!transformString || transformString == 'none')
        return 0;
    var splits = transformString.split(',');
    // parse the string to get a and b
    var a = parseFloat(splits[0].substr(7));
    var b = parseFloat(splits[1]);
    // doing atan2 on b, a will give you the angle in radians
    var rad = Math.atan2(b, a);
    var deg = 180 * rad / Math.PI;
    // instead of having values from -180 to 180, get 0 to 360
    if (deg < 0) deg += 360;
    return deg;
}