function goToFooter() {
    $("#btnFooter").click(function () {
        $("html, body").animate({ scrollTop: $(document).height() }, "slow");
    });
}

function setValues(id, data) {
    var select = document.getElementById('selectModelo');
    select.options.length = 0;
    var defaulOpt = document.createElement('option');
    defaulOpt.value = null;
    defaulOpt.innerHTML = "Selecione";
    select.appendChild(defaulOpt);
    for (var i = 0; i < data.length; i++) {
        if (data[i].Value == id) {
            var opt = document.createElement('option');
            opt.value = data[i].Value;
            opt.innerHTML = data[i].Text;
            select.appendChild(opt);
        }
    }
}

function checkSelectMarca() {
    $('#selectMarca').change(function () {
        var e = document.getElementById("selectMarca");
        var itemSelecionado = e.options[e.selectedIndex].value;
        if (itemSelecionado != '') {
            $.ajax(
                {
                    type: 'GET',
                    url: "/Home/Data",
                    data: { get_param: 'value' },
                    dataType: 'json',
                    success: function (result) {
                        setValues(itemSelecionado, result);
                    },
                    error: function () {
                        alert("No data received");
                    }
                });
        }
    });
}

function actions() {
    checkSelectMarca();
    goToFooter();
}

$(document).ready(function () {
    actions();
});
