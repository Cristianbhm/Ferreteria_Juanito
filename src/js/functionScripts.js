


function cargaTblsProductos() {
    getProductos();
    getUsuarios();
}

function getProductos() {
    $.ajax({
        url: "GetListaProductos",
        type: "POST",
        datatype: "json",
        success: function (data) {
            $("#tblProductos").html('');
            if (data != null) {
                $.each(data, function (index, value) {
                    $("#tblProductos").append(
                        "<tr><td>" + value.idProducto + "</td>"
                        + "<td>" + value.nombreProducto + "</td>"
                        + "<td>" + value.marcaProducto + "</td>"
                        + "<td>" + value.desAdicionalProducto + "</td>"
                        + "<td>" + value.categoriaProducto + "</td>"
                        + "<td>" + value.valorNetoProducto + "</td>"
                        + "<td>" + value.valorIvaProducto + "</td>"
                        + "<td>" + value.valorTotalProducto + "</td>"
                        + "<td>" + value.stockProducto + "</td>"
                        + "<td style='text-align: center;'><a onclick='showDetails(this)'><span class='glyphicon glyphicon-edit'></span></a></td>"
                        + "<td style='text-align: center;'><a onclick='deleteProd(" + value.idProducto + ")'><span class='glyphicon glyphicon-trash'></span></a></td></tr>"
                    );
                });
            }
        }
    });
}


function getUsuarios() {
    $.ajax({
        url: "GetListaUsuarios",
        type: "POST",
        datatype: "json",
        success: function (data) {
            $("#tblUsuarios").html('');
            if (data != null) {
                $.each(data, function (index, value) {
                    $("#tblUsuarios").append(
                        "<tr><td class='hidden'>" + value.idUsuario + "</td>"
                        + "<td>" + value.usuario + "</td>"
                        + "<td>" + value.nombreUsuario + "</td>"
                        + "<td>" + value.apellidoUsuario + "</td>"
                        + "<td>" + value.nomTipoRol + "</td>"
                        + "<td>" + value.mailUsuario + "</td>"
                        + "<td style='text-align: center;'><a onclick='showDetailsUser(this)'><span class='glyphicon glyphicon-edit'></span></a></td>"
                        + "<td style='text-align: center;'><a onclick='deleteUsuario(" + value.idUsuario + ")'><span class='glyphicon glyphicon-trash'></span></a></td>"
                        + "<td class='hidden'>" + value.idRol + "</td></tr>"
                    );
                });
            }
        }
    });
}


function setInsertaProducto() {
    var formContainer = $('#prod-form');
    $.ajax({
        url: "setInsertaProducto",
        type: 'POST',
        datatype: "json",
        data: formContainer.serialize(),
        success: function (result) {
            getProductos();
        }
    });

    return false;
}

function deleteProd(_idProd) {
    $.ajax({
        url: "setDeleteProducto",
        type: 'POST',
        datatype: "json",
        data: { _idProd },
        success: function (result) {
            getProductos();
        }
    });

}


function setUpdateProducto() {
    var formContainer = $('#prod-form');
    $.ajax({
        url: "setUpdateProducto",
        type: 'POST',
        datatype: "json",
        data: formContainer.serialize(),
        success: function (result) {
            getProductos();
            limpaFormProductos();
        }
    });
  
    return false;
}

function setInsertaUsuario() {
    var formContainer = $('#usuarios-form');
    $.ajax({
        url: "setInsertaUsuario",
        type: 'POST',
        datatype: "json",
        data: formContainer.serialize(),
        success: function (result) {
            getUsuarios();
        }
    });

    return false;
}



function setUpdateUsuario() {
    var formContainer = $('#usuarios-form');
    $.ajax({
        url: "setUpdateUsuario",
        type: 'POST',
        datatype: "json",
        data: formContainer.serialize(),
        success: function (result) {
            getUsuarios();
            limpaFormUsuarios();
        }
    });
    return false;
}


function deleteUsuario(_idUsuario) {
    $.ajax({
        url: "setDeleteUsuario",
        type: 'POST',
        datatype: "json",
        data: { _idUsuario },
        success: function (result) {
            getUsuarios();
        }
    });
}

function limpaFormProductos() {
    $('#btnActualizarProd').fadeOut();
    $('#btnGuardarProd').fadeIn();
    $("#idProducto").val('');
    $("#idNombreProducto").val('');
    $("#idCategoria").val('');
    $("#idDescripcion").val('');
    $("#idValorNeto").val('');
    $("#idValorIva").val('');
    $("#idValorTotal").val('');
    $("#idStock").val('');
    $("#idMarca").val('');
}



function limpaFormUsuarios() {
    $('#btnActualizarUsuario').fadeOut();
    $('#btnGuardarUsuario').fadeIn();
    $("#idUsuarioPk").val('');
    $("#idUsuario").val('');
    $("#idPassword").val('');
    $("#idNombre").val('');
    $("#idApellido").val('');
    $("#idEmail").val('');
    $("#idRol").val('1');
}



function showDetails(x) {
    $('#btnGuardarProd').fadeOut();
    $('#btnActualizarProd').fadeIn();

    var fila = x.parentNode.parentNode;
    var idProd = fila.children[0].innerHTML;
    var nombreProd = fila.children[1].innerHTML;
    var marcaProd = fila.children[2].innerHTML;
    var desProd = fila.children[3].innerHTML;
    var categoriaProd = fila.children[4].innerHTML;
    var valorNetoProd = fila.children[5].innerHTML;
    var valorIvaProd = fila.children[6].innerHTML;
    var valorTotalProd = fila.children[7].innerHTML;
    var stockProd = fila.children[8].innerHTML;

    $("#idProducto").val(idProd);
    $("#idNombreProducto").val(nombreProd)
    $("#idCategoria").val(categoriaProd);
    $("#idDescripcion").val(desProd);
    $("#idValorNeto").val(valorNetoProd);
    $("#idValorIva").val(valorIvaProd);
    $("#idValorTotal").val(valorTotalProd);
    $("#idStock").val(stockProd);
    $("#idMarca").val(marcaProd);
}

function showDetailsUser(x) {
    $('#btnActualizarUsuario').fadeIn();
    $('#btnGuardarUsuario').fadeOut();

    var fila = x.parentNode.parentNode;
    var idUsuario = fila.children[0].innerHTML;
    var usuario = fila.children[1].innerHTML;
    var nombreUsuario = fila.children[2].innerHTML;
    var apellidoUsuario = fila.children[3].innerHTML;
    var email = fila.children[5].innerHTML;
    var idRol = fila.children[8].innerHTML;

    $("#idUsuarioPk").val(idUsuario);
    $("#idUsuario").val(usuario);
    $("#idPassword").val('');
    $("#idNombre").val(nombreUsuario);
    $("#idApellido").val(apellidoUsuario);
    $("#idEmail").val(email);
    $("#idRol").val(idRol);
}


function listaProductos() {

    function mostrarCatalogo() {
        const catalogoDiv = $("#catalogo");
        $.ajax({
            url: "Mantenedor/GetListaProductos",
            type: "POST",
            datatype: "json",
            success: function (data) {
               
                $.each(data, function (index, value) {

                    const rutaImg = "../src/img/2098325.jpeg"
                    const imgProdStandar = $("<img width='200px' src=" + rutaImg + " />")
                    const productDiv = $("<div style='display: inline-block; margin: 10px;'>").addClass("product");
                    const nombreProducto = $("<h3>").text(value.nombreProducto);
                    const precioProducto = $("<p>").text(`$${value.valorTotalProducto}`);
                    const codProd = $("<p>").text("Cod: " + value.idProducto);
                    const addcarrito = $("<Button class='btn btn-success'>").text('Comprar')
                    productDiv.append(imgProdStandar, nombreProducto, precioProducto, codProd, addcarrito);
                    catalogoDiv.append(productDiv);
               
                });
             
            }
           
        });
    }

    $(document).ready(mostrarCatalogo);
}