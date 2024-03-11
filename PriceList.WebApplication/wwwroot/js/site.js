function showInPopUp(url, title) {
    $.ajax({
        type: "GET",
        url: url,
        success: function (response) {
            $("#form-modal .modal-body").html(response);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');
            //console.log(response);
            //console.log(title);
        },
        error: function (response) {
            console.log(response);
        }
    });
}
