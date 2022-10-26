window.initializeCarousel = () => {
    $('#carouselExampleFade').carousel({ interval: 1000 });

    //see step 2 to understand these news id's:
    $('.carousel-control-prev').click(
        () => $('#carouselExampleFade').carousel('prev'));
    $('.carousel-control-next').click(
        () => $('#carouselExampleFade').carousel('next'));

}