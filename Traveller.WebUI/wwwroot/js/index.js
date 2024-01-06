const slider = document.querySelector('.slider');
const prevButton = document.querySelector('.prev-button');
const nextButton = document.querySelector('.next-button');
let slideIndex = 0;

function showSlide(index) {
    if (index < 0) {
        slideIndex = slider.children.length - 1;
    } else if (index >= slider.children.length) {
        slideIndex = 0;
    }
    slider.style.transform = `translateX(-${slideIndex * 100}%)`;
}

function nextSlide() {
    slideIndex++;
    showSlide(slideIndex);
}

function prevSlide() {
    slideIndex--;
    showSlide(slideIndex);
}

nextButton.addEventListener('click', nextSlide);
prevButton.addEventListener('click', prevSlide);

showSlide(slideIndex);