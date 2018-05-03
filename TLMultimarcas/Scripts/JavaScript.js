$("#btnFooter").click(function () {
    $("html, body").animate({ scrollTop: $(document).height() }, "slow");
});

$('#selectMarca').change(function () {
    var e = document.getElementById("selectMarca");
    var itemSelecionado = e.options[e.selectedIndex].value;
    if (itemSelecionado != '') {
        console.log(itemSelecionado);
    }
});