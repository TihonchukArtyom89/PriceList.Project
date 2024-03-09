showInPopUp = (url, title) => {
    $.ajax(
        {
            type: "GET",
            url: url,
            success: function (res)
            {
                $("#addProduct .modal-body").html(res);
                $("#addProduct .modal-title").html(title);
                $("#addProduct").modal('show');
            }
        })
}