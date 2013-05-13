﻿$(document).ready(function () {

    console.log('loaded')

    // 100MckenzieDriveWeatherfordOk73096&sensor=false

    var googurl = 'http://maps.googleapis.com/maps/api/geocode/json?address=';

    var $checkGoogleButton = $('#check-google-button');
    var $addressFields = $('.property-address-part-fields').find('input');

    $checkGoogleButton.click(function () {

     
        var args = '';

        $addressFields.each(function (i, e) {

            args += $(this).val();

        });

        if (args) {
            args += '&sensor=false';

            var url = (googurl + args).split(" ").join("");

            $.get(url, null, null, 'json').done(function (data) {
                if (data && data.results[0] && data.status === "OK") {
                    var lat = data.results[0].geometry.location.lat;
                    var lng = data.results[0].geometry.location.lng;
                    $('#PropertyAddress_Latitude').val(lat);
                    $('#PropertyAddress_Longitude').val(lng);
                    var cleanaddress = (data.results[0].formatted_address).split(" ").join("+");
                    var ll = '&ll=' + lat + ',' + lng ;
                    var icon = 'http://maps.google.com/mapfiles/ms/micons/homegardenbusiness.png';
                    var baseurl = ("http://maps.google.com/maps?q=" + cleanaddress + ll + "&hl=en").split(" ").join("");
                    var mapurl =  baseurl + "&output=embed";
                    var linkurl = baseurl + "&spn=0.040679,0.07699&z=14&source=embed";
                    var map = '<iframe width="100%" height="100%" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="'+ mapurl+'"></iframe>';

                    $('.googlemap').html(map);
                }
            });
        }




    });


});