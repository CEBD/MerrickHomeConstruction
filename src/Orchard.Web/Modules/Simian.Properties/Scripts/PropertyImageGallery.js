$(document).ready(function () {


    var $propertyImageGallery = $('.property-imagegallery:first');

    var $propertyImageGallerySlidingframe = $propertyImageGallery.find('.property-imagegallery-slidingframe:first');

    var $propertyImageGalleryImageFrame = $propertyImageGallerySlidingframe.find('.property-imagegallery-image-frame');

    var frameWidth = $propertyImageGallery.width(); //960


    $propertyImageGallerySlidingframe.width(frameWidth * $propertyImageGalleryImageFrame.length);




});