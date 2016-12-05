$(document).ready(function () {
    $('#ProfilePicture').on("change", function () {
        var file = this.files[0];

        if (this.files && file) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#Avatar').attr('src', e.target.result);
            }
            reader.readAsDataURL(file);
        }
    });

    $('#Image').on("change", function () {
        var file = this.files[0];

        if (this.files && file) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#recipeImage').attr('src', e.target.result);
            }
            reader.readAsDataURL(file);
        }
    });
});

