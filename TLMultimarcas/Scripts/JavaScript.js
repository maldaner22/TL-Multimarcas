var veiculos = null;

function goToFooter() {
    $("html, body").animate({ scrollTop: $(document).height() }, "slow");
}

function search() {
    console.log(veiculos);
}

function setValues(id) {
    var select = document.getElementById('selectModelo');
    select.options.length = 0;
    var defaulOpt = document.createElement('option');
    defaulOpt.value = null;
    defaulOpt.innerHTML = "Selecione";
    select.appendChild(defaulOpt);
    for (var i = 0; i < veiculos.length; i++) {
        if (veiculos[i].IdMarca == id) {
            var opt = document.createElement('option');
            opt.value = veiculos[i].IdModelo;
            opt.innerHTML = veiculos[i].NomeModelo;
            select.appendChild(opt);
        }
    }
}

function ajax(url, cb) {
    $.ajax(
        {
            type: 'GET',
            url: "/Home/Data",
            data: { get_param: 'value' },
            dataType: 'json',
            success: function (result) {
                cb(result);
            },
            error: function () {
                alert("No data received");
            }
        });
}

function checkSelectMarca() {
    var e = document.getElementById("selectMarca");
    var itemSelecionado = e.options[e.selectedIndex].value;
    if (itemSelecionado != '') {
        ajax("Home/Index", function (result) {
            veiculos = result;
            setValues(itemSelecionado);
        });
    }
}

function actions() {
    $('#selectMarca').change(function () {
        checkSelectMarca();
    });
    $("#buttonHome").click(function () {
        search();
    });
    $("#btnFooter").click(function () {
        goToFooter();
    });
}

$(document).ready(function () {
    actions();
});
