function SubeleriGetir() {
    var html = "";
    Get("Sube/SubeTamBilgiler", (data) => {
        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<div class="accordion accordion-flush" id="accordionFlushExample">
      <div class="accordion-item">
        <h2 class="accordion-header border border-black">
          <button
            class="accordion-button collapsed"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#flush-collapse${arr[i].id}"
            aria-expanded="false"
            aria-controls="flush-collapseOne"
          >
            ${arr[i].id} ${arr[i].ad}
          </button>
        </h2>
        <div
          id="flush-collapse${arr[i].id}"
          class="accordion-collapse collapse"
          data-bs-parent="#accordionFlushExample"
        >
          <div class="accordion-body">
            <table class="table border border-black">
              <thead class="position-relative">
                <tr class="bg-black text-light">
                  <th scope="col">#</th>
                  <th scope="col">#</th>
                  <th scope="col">
                  <button class="btn btn-link position-absolute top-0 end-0">
                   <i class="bi bi-pencil-square text-light px-2 py-2 mx-2 mt-4 border border-light" onclick='SubeDuzenle(
                        ${arr[i].id},"${arr[i].sehirId}","${arr[i].acikAdres}","${arr[i].ad}","${arr[i].parola}","${arr[i].telNo}","${arr[i].mailAdress}","${arr[i].aktifMi}"
                   )'></i>
                  </button>
                  </th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <th scope="row">Parola :</th>
                  <td>${arr[i].parola}</td>
                </tr>
                <tr>
                  <th scope="row">Kullanıcı Rolü :</th>
                  <td>${arr[i].rolAd}</td>
                </tr>
                <tr>
                  <th scope="row">Şube Adresi :</th>
                  <td>${arr[i].acikAdres}</td>
                </tr>
                <tr>
                  <th scope="row">Mail Adres :</th>
                  <td>${arr[i].mailAdress}</td>
                </tr>
                <tr>
                  <th scope="row">Tel No :</th>
                  <td colspan="2">${arr[i].telNo}</td>
                </tr>
                 <tr>
                  <th scope="row">Sehir Ad :</th>
                  <td colspan="2">${arr[i].sehirAd}</td>
                </tr>
                <tr>
                  <th scope="row">Kayıt Tarihi :</th>
                  <td colspan="2">${arr[i].kayitTarih}</td>
                </tr>
                <tr>
                  <th scope="row">Aktiflik Durumu</th>
                  <td colspan="2">
                     <span style="color: ${arr[i].aktifMi ? 'green' : 'red'};">
                         ${arr[i].aktifMi ? 'Aktif' : 'Pasif'}
                     </span>
                 </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>`;

        }
        $("#divSubeler").html(html);

        $("#ara").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $("#divSubeler .accordion").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
            });
        });

    });
}
let selectedId = 0;

function YeniSube() {
    selectedId = 0;
    $("#sehirAd").val("");
    $("#aktifMi").val("");
    $("#subeAd").val("")
    $("#mailAdress").val("");
    $("#parola").val("");
    $("#telNo").val("");
    $("#acikAdres").val("");

    $("#staticBackdrop").modal("show");
}

function SubeKaydet() {
    var sube = {
        Id: selectedId,
        SehirId: $("#sehirAd").val(),
        AcikAdres: $("#acikAdres").val(),
        Ad: $("#subeAd").val(),
        Parola: $("#parola").val(),
        TelNo: $("#telNo").val(),
        MailAdress: $("#mailAdress").val(),
        AktifMi: $("#aktifMi").val()
    };

    Post("Sube/Kaydet", sube, (data) => {
        SubeleriGetir();
        $("#staticBackdrop").modal("hide");
    });

}

function SubeDuzenle(id, sehirId, acikAdres, ad, parola, telNo, mailAdress, aktifMi) {
    selectedId = id;
    $("#sehirAd").val(sehirId);
    $("#acikAdres").val(acikAdres);
    $("#subeAd").val(ad);
    $("#parola").val(parola);
    $("#telNo").val(telNo);
    $("#mailAdress").val(mailAdress);
    $("#aktifMi").val(aktifMi);

    $("#staticBackdrop").modal("show");
}

function TumSehirleriGetir() {
    Get("Sehir/TumSehirler", (data) => {
        var sehirdata = data;
        var dropdown = $("#sehirAd");
        $.each(sehirdata, function (index, sehir) {
            dropdown.append($("<option>").val(sehir.id).text(sehir.ad));
        });
    });
}


$(document).ready(function () {
    SubeleriGetir();
    TumSehirleriGetir();

});

