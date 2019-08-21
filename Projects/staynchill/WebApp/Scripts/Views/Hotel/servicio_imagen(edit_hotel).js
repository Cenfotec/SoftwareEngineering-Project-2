$(function () {
    let imagenUrl = '';

    $.cloudinary.config({ cloud_name: "qubitscenfo", api_key: "642245495784277" });

    let uploadButton = $("#btnSubirImagenHotel");

    uploadButton.on("click", function (e) {

        cloudinary.openUploadWidget({ cloud_name: "qubitscenfo", upload_preset: "qubitscenfo", tags: ['cgal'] },

            function (error, result) {

                if (error) console.log(error);
                let sectionImages = document.querySelector('#imageConatiner');
                let imagenNueva = document.createElement('img');
                let id = result[0].public_id;
                imagenNueva.setAttribute('id', id);
                imagenNueva.classList.add('d-block');
                imagenNueva.classList.add('w-100');
                console.log(id);
                imagenUrl = "https://res.cloudinary.com/qubitscenfo/image/upload/" + id;
                if (document.querySelector('#txtValue').value == "") {

                    let divCarousel = document.createElement('div');
                    divCarousel.setAttribute('id', 'carouselExampleControls');
                    divCarousel.setAttribute('class', 'carousel slide');
                    divCarousel.setAttribute('data-ride', 'carousel');

                    let divInner = document.createElement('div');
                    divInner.setAttribute('id', 'divinner');
                    divInner.setAttribute('class', 'carousel-inner');

                    let divCarouselActive = document.createElement('div');
                    divCarouselActive.setAttribute('id', 'carouseltype');
                    divCarouselActive.setAttribute('class', 'carousel-item active');

                    let aControlPrev = document.createElement('a');
                    aControlPrev.setAttribute('class', 'carousel-control-prev');
                    aControlPrev.setAttribute('href', '#carouselExampleControls');
                    aControlPrev.setAttribute('role', 'button');
                    aControlPrev.setAttribute('data-slide', 'prev');

                    let spanControlPrev = document.createElement('span');
                    spanControlPrev.setAttribute('class', 'carousel-control-prev-icon');
                    spanControlPrev.setAttribute('aria-hidden', 'true');

                    let spanSrPrevious = document.createElement('span');
                    spanSrPrevious.setAttribute('class', 'sr-only');
                    spanSrPrevious.innerHTML = 'Previous';

                    let aControlNext = document.createElement('a');
                    aControlNext.setAttribute('class', 'carousel-control-next');
                    aControlNext.setAttribute('href', '#carouselExampleControls');
                    aControlNext.setAttribute('role', 'button');
                    aControlNext.setAttribute('data-slide', 'next');

                    let spanControlNext = document.createElement('span');
                    spanControlNext.setAttribute('class', 'carousel-control-next-icon');
                    spanControlNext.setAttribute('aria-hidden', 'true');

                    let spanSrNext = document.createElement('span');
                    spanSrNext.setAttribute('class', 'sr-only');
                    spanSrNext.innerHTML = 'Next';

                    sectionImages.appendChild(divCarousel);
                    divCarousel.appendChild(divInner);
                    aControlPrev.appendChild(spanControlPrev);
                    aControlPrev.appendChild(spanSrPrevious);
                    aControlNext.appendChild(spanControlNext);
                    aControlNext.appendChild(spanSrNext);
                    divInner.appendChild(divCarouselActive);
                    divCarouselActive.appendChild(imagenNueva);
                    divCarousel.appendChild(aControlPrev);
                    divCarousel.appendChild(aControlNext);
                    document.querySelector("#" + id).src = imagenUrl;
                    document.querySelector('#txtValue').value = id;
                } else {
                    let divCarousel = document.querySelector('#carouselExampleControls');
                    let divInner = document.querySelector('#divinner');
                    let divCarouselActive = document.createElement('div');
                    divCarouselActive.setAttribute('id', 'carouseltype');
                    divCarouselActive.setAttribute('class', 'carousel-item');
                    sectionImages.appendChild(divCarousel);
                    divCarousel.appendChild(divInner);
                    divInner.appendChild(divCarouselActive);
                    divCarouselActive.appendChild(imagenNueva);
                    document.querySelector("#" + id).src = imagenUrl;
                    document.querySelector('#txtValue').value = id + "," + document.querySelector('#txtValue').value;
                    $('.carousel').carousel();
                }
                console.log(imagenUrl);
            });
    });
})

function processImage(id) {
    let options = {
        client_hints: true,
    };
    return $.cloudinary.url(id, options);
}