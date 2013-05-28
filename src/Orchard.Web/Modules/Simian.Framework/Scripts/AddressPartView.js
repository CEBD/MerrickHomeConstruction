$(document).ready(function () {


    if (simian && simian.address) {
        var myLatlng = new google.maps.LatLng(simian.address.latitude, simian.address.longitude);
        
        console.log(simian, myLatlng)

        var iconBase = 'https://maps.google.com/mapfiles/kml/shapes/';
        var myOptions = {
            center: myLatlng,
            zoom: 18,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var gMap = new google.maps.Map($('.googlemap')[0], myOptions);
        var marker = new google.maps.Marker({
            position: myLatlng,
            map: gMap,
            icon: iconBase + 'schools_maps.png',
            shadow: iconBase + 'schools_maps.shadow.png',
            title: simian.address.title
        });
    }

   
    


});