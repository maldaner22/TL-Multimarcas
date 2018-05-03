function mountURL(itemSelecionado) {
    var apiURL = "http://localhost:62960/";
    var apiInf = "Api/Modelo/";
    var param = itemSelecionado;
    var reqURL = (apiURL + apiInf + param);
    console.log(reqURL);
}

function checkSelectMarca() {
    $('#selectMarca').change(function () {
        var e = document.getElementById("selectMarca");
        var itemSelecionado = e.options[e.selectedIndex].value;
        if (itemSelecionado != '') {
            mountURL(itemSelecionado);
        }
    });
}

function actions() {
    checkSelectMarca();
}
    
$(document).ready(function () {
    actions();
});
