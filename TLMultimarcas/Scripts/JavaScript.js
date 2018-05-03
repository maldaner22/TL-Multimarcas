$("#btnFooter").click(function () {
    $("html, body").animate({ scrollTop: $(document).height() }, "slow");
});

$('#selectMarca').change(function () {
    var e = document.getElementById("selectMarca");
    var itemSelecionado = e.options[e.selectedIndex].value;
    var select = document.getElementById('selectModelo');
    var optionSelect = document.createElement('option');
    select.options.length = 0;
    optionSelect.innerHTML = "Selecione";
    select.appendChild(optionSelect);
    if (itemSelecionado == 'Chevrolet') {
        console.log(itemSelecionado);
        //for
        var optionCar = document.createElement('option');
        optionCar.value = "S10";
        optionCar.innerHTML = "S10";
        select.appendChild(optionCar);
    }
});
