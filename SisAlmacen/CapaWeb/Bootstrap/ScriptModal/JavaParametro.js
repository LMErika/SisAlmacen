$("#btnNuevo").click(function (eve) {
    $("#modal-content-body").load("/CrudParametro/Nuevo");
});

$(".btnEditar").click(function (eve) {
    $("#modal-content-body").load("/CrudParametro/Editar?" + $(this).data("idParametro"));
});