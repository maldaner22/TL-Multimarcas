//function showModels(brand) {
//    var select = document.getElementById('selectModelo');
//    var optionSelect = document.createElement('option');
//    select.options.length = 0;
//    optionSelect.innerHTML = "Selecione";
//    select.appendChild(optionSelect);
//    console.log(brand);
//    switch (brand) {
//        case 'Chevrolet':
//            var optionCar = document.createElement('option');
//            optionCar.value = "S10";
//            optionCar.innerHTML = "S10";
//            select.appendChild(optionCar);
//            break;
//        case 'Citroën':
//            var optionCar = document.createElement('option');
//            optionCar.value = "C3";
//            optionCar.innerHTML = "C3";
//            select.appendChild(optionCar);
//            break;
//    }
//}

//function actions() {
//    $("#btnFooter").click(function () {
//        $("html, body").animate({ scrollTop: $(document).height() }, "slow");
//    });

//    $('#selectMarca').change(function () {
//        var e = document.getElementById("selectMarca");
//        var itemSelecionado = e.options[e.selectedIndex].value;
//        showModels(itemSelecionado);
//    });
//}

//$(document).ready(function () {
//    actions();
//});
