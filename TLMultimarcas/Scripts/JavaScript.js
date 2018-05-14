var veiculos = null;

function goToFooter() {
    $("html, body").animate({ scrollTop: $(document).height() }, "slow");
}

function search() {
    var url = "/Veiculos/Busca/";
    var IdMarca = $('#selectMarca').val();
    var IdModelo = $('#selectModelo').val();
    var Valor = $('#selectValor').val();
    var Veiculo = new Object();
    Veiculo.Marca = null;
    Veiculo.Modelo = null;
    Veiculo.Preco = null;
    if (IdMarca != "") {
        Veiculo.Marca = IdMarca;
        //url = url + IdMarca;
        if (IdModelo != "null") {
            Veiculo.Modelo = IdModelo;
            //url = url + "/" + IdModelo;
        }
    }
    if (Valor != "null") {
        Veiculo.Preco = Valor;
    }

    $.ajax({
        type: "POST",
        url: url,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ idMa: Veiculo.Marca, idMo: Veiculo.Modelo, Val: Veiculo.Preco, dados: Veiculo }),
        success: function (data) {
            console.log(data);
        },
        failure: function (errMsg) {
            alert("I'm AJAX and I don't like to work");
        }
    });
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
            type: 'POST',
            url: url,
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
        ajax("Home/Data", function (result) {
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
