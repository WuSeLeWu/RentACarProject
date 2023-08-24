function RolleriGetir() {
    Get("Rol/TumRoller", (data) => {
        var html = `<div class="container-fluid"><table id="liste" class="table table-hover">` +
            `<thead class="text-light bg-black"><tr><th>Id</th><th>Rol Adı</th><th></th></tr></thead>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr id="arama">`;
            html += `<td>${arr[i].id}</td><td>${arr[i].ad}</td>`;
            html += `<td><i class="bi bi-trash text-danger px-2 py-2 mx-3 border border-danger " onclick='RolSil(${arr[i].id})'></i><i class="bi bi-pencil-square text-primary px-2 py-2 mx-3 border border-primary" onclick='RolDuzenle(
                "${arr[i].id}","${arr[i].ad}"
            )'></i></td>`;
            html += `</tr>`
        }
        html += `</table></div>`;

        $("#divRoller").html(html);

        $(function () {
            $("#ara").keyup(function () {
                var deger = $(this).val().toLowerCase();
                $("#liste #arama").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(deger) > -1);
                });
            });
        });
    });
}

let selectedRolId = 0;

function YeniRol() {
    selectedRolId = 0;
    $("#inputRolAd").val("");
    $("#rolModal").modal("show");
}
function RolKaydet() {
    var rol = {
        Id: selectedRolId,
        Ad: $("#inputRolAd").val()
    };
    Post("Rol/Kaydet", rol, (data) => {
        RolleriGetir();
        $("#rolModal").modal("hide");
    });
}


function RolSil(id) {
    Delete(`Rol/Sil?id=${id}`, (data) => {
        RolleriGetir();
    });
}

function RolDuzenle(id, ad) {
    selectedRolId = id;
    $("#inputRolAd").val(ad);
    $("#rolModal").modal("show");
}

$(document).ready(function () {
    RolleriGetir();
});
