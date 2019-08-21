$(function() {
    let imagenUrl = '';

    $.cloudinary.config({ cloud_name: "qubitscenfo", api_key: "642245495784277" });

    let uploadButton = $("#btnSeleccionarImagen");

    uploadButton.on("click", function(e) {

        cloudinary.openUploadWidget({ cloud_name: "qubitscenfo", upload_preset: "qubitscenfo", tags: ['cgal'] },

            function(error, result) {
                if (error) console.log(error);

                let id = result[0].public_id;
                imagenUrl = "https://res.cloudinary.com/qubitscenfo/image/upload/" + id;
                document.querySelector("#image_preview").src = imagenUrl;
            });
    });
})

function processImage(id) {
    let options = {
        client_hints: true,
    };
    return $.cloudinary.url(id, options);
}
