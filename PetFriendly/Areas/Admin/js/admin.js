function PicturePreview(inputSelector, imgSelector) {

    var oldSrc = $(imgSelector).attr('src');

    var input = $(imgSelector);

    input.change(function () {

        if (this.files && this.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $(imgSelector).attr('src', e.target.result);
            }

            reader.readAsDataURL(this.files[0]);
        }
        else {
            $(imgSelector).attr('src', oldSrc);
        }
    });

}