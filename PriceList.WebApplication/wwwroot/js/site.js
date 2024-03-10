//showInPopUp = (url, title) => {
//    $.ajax(
//        {
//            type: "GET",
//            url: url,
//            success: function (res)
//            {
//                $("#addProductClick .modal-body").html(res);
//                $("#addProductClick .modal-title").html(title);
//                $("#addProductClick").modal('show');
//            }
//        })
//}
function showInPopUp(url, title) {
    alert("dsfdsfdsf");
    $.ajax({
        type: "GET",
        url: url,
        success: function (response) {
            $("#form-modal .modal-body").html(response);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');
            console.log(response);
            console.log(title);
        },
        error: function (response) {
            console.log(response);
        }
    });
}
