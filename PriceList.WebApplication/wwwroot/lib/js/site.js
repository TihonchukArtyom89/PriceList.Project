showInPopUp = (url, title) => {
    $.ajax(
        {
            type: "GET",
            url: url,
            success: function (res)
            {
                $("#addProductClick .modal-body").html(res);
                $("#addProductClick .modal-title").html(title);
                $("#addProductClick").modal('show');
            }
        })
}