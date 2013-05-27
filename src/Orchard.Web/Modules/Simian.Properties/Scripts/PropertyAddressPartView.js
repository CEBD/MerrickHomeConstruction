$(document).ready(function () {
    var myLatlng = new google.maps.LatLng(propertyaddress_myLat, propertyaddress_myLong);
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
        title: propertyaddress_title
    });
});