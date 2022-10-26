
//$(document).ready(function initializeCarousel() {
//    $('#motorcycle-carousel-indicators').carousel({ interval: 2000 });

//    //see step 2 to understand these news id's:
//    $('#motorcycle-carousel-indicators-prev').click(
//        () => $('#motorcycle-carousel-indicators').carousel('prev'));
//    $('#motorcycle-carousel-indicators-next').click(
//        () => $('#motorcycle-carousel-indicators').carousel('next'));
//});


//window.initializeCarousel = () => {
//    $('#motorcycle-carousel-indicators').carousel({ interval: 2000 });

//    //see step 2 to understand these news id's:
//    $('#motorcycle-carousel-indicators-prev').click(
//        () => $('#motorcycle-carousel-indicators').carousel('prev'));
//    $('#motorcycle-carousel-indicators-next').click(
//        () => $('#motorcycle-carousel-indicators').carousel('next'));

//}


window.initializeCarousel = () => {
    $('#carouselExampleIndicators').carousel({ interval: 2000 });

    //see step 2 to understand these news id's:
    $('#carouselExampleIndicators-prev').click(
        () => $('#carouselExampleIndicators').carousel('prev'));
    $('#carouselExampleIndicators-next').click(
        () => $('#carouselExampleIndicators').carousel('next'));

}