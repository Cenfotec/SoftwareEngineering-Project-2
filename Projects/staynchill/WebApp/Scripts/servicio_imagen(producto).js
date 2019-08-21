$(function () {
    let imagenUrl = '';

    $.cloudinary.config({ cloud_name: "qubitscenfo", api_key: "642245495784277" });

    let uploadButton = $("#btnUploadProductImage");

    uploadButton.on("click", function (e) {

        cloudinary.openUploadWidget({ cloud_name: "qubitscenfo", upload_preset: "qubitscenfo", tags: ['cgal'] },

            function (error, result) {
                if (error) console.log(error);
                let sectionImages = document.querySelector('#imageConatiner');
                if (document.querySelector('#txtImage').value == undefined) {
                    let imagenNueva = document.createElement('img');
                    let id = result[0].public_id;
                    imagenNueva.setAttribute('id', id);
                    console.log(id);
                    imagenUrl = "https://res.cloudinary.com/qubitscenfo/image/upload/" + id;
                    sectionImages.appendChild(imagenNueva);
                    document.querySelector("#" + id).src = imagenUrl;
                    document.querySelector('#txtImage').value = id;
                    console.log(imagenUrl);
                } else {
                    sectionImages.innerHTML = '';
                    let imagenNueva = document.createElement('img');
                    let id = result[0].public_id;
                    imagenNueva.setAttribute('id', id);
                    console.log(id);
                    imagenUrl = "https://res.cloudinary.com/qubitscenfo/image/upload/" + id;
                    sectionImages.appendChild(imagenNueva);
                    document.querySelector("#" + id).src = imagenUrl;
                    document.querySelector('#txtImage').value = id;
                    console.log(imagenUrl);
                }

            });
    });
})

function processImage(id) {
    let options = {
        client_hints: true,
    };
    return $.cloudinary.url(id, options);
}