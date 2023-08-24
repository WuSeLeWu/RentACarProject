function KullaniciGetir() {
    var html = ``;
    Get("Kullanici/KullaniciTamBilgiler", (data) => {
        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<div class="secili accordion accordion-flush" id="accordionFlushExample">
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
            ${arr[i].id} ${arr[i].ad} ${arr[i].soyad}
          </button>
        </h2>
        <div
          id="flush-collapse${arr[i].id}"
          class="accordion-collapse collapse"
          data-bs-parent="#accordionFlushExample"
        >
          <div class="accordion-body">
            <table class="table">
              <thead class="position-relative">
                <tr class="bg-black text-light">
                  <th scope="col">#</th>
                  <th scope="col">#</th>
                  <th scope="col">
                  <button class="btn btn-link position-absolute top-0 end-0">
                   <i class="bi bi-pencil-square text-light px-2 py-2 mx-2 mt-4 border border-light" onclick='KullaniciDuzenle(
                        ${arr[i].id},"${arr[i].sehirId}","${arr[i].rolId}","${arr[i].acikAdres}","${arr[i].ad}","${arr[i].soyad}","${arr[i].parola}","${arr[i].telNo}","${arr[i].tcKimlikNo}","${arr[i].dogumTarih}","${arr[i].ehliyetAlimTarih}","${arr[i].mailAdress}","${arr[i].aktifMi}"
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
                  <th scope="row">Şehir Adı :</th>
                  <td>${arr[i].sehirAd}</td>
                </tr>
                <tr>
                  <th scope="row">Rent A Car Rolü :</th>
                  <td>${arr[i].rolAd}</td>
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
                  <th scope="row">Tc Kimlik No :</th>
                  <td colspan="2">${arr[i].tcKimlikNo}</td>
                </tr>
                <tr>
                  <th scope="row">Doğum Tarihi</th>
                  <td colspan="2">${arr[i].dogumTarih}</td>
                </tr>
                <tr>
                  <th scope="row">Ehliyet Alım Tarihi :</th>
                  <td colspan="2">${arr[i].ehliyetAlimTarih}</td>
                </tr>
                <tr>
                  <th scope="row">Aktiflik Durumu</th>
                  <td colspan="2">
                    <span style="color: ${arr[i].aktifMi ? 'green' : 'red'};">
                         ${arr[i].aktifMi ? 'Aktif' : 'Pasif'}
                     </span>
                  </td>
                </tr>
                <tr>
                  <th scope="row">Açık Adres :</th>
                  <td colspan="2">${arr[i].acikAdres}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>`;

        }
        $("#divKullanici").html(html);

        $("#ara").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $("#divKullanici .accordion").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
            });
        });

    });
}
let selectedId = 0;

function YeniKullanici() {
    selectedId = 0;
    $("#sehirAd").val("");
    $("#aktifMi").val("");
    $("#ad").val("")
    $("#soyad").val("")
    $("#mailAdress").val("");
    $("#parola").val("");
    $("#telNo").val("");
    $("#tcNo").val("");
    $("#acikAdres").val("");
    $("#rolAd").val("");
    $("#dogumTarih").val();
    $("#ehliyetTarih").val();
    $("#staticBackdrop").modal("show");
}

function KullaniciKaydet() {
    var kullanici = {
        Id: selectedId,
        SehirId: $("#sehirAd").val(),
        RolId: $("#rolAd").val(),
        AcikAdres: $("#acikAdres").val(),
        Ad: $("#ad").val(),
        Soyad: $("#soyad").val(),
        Parola: $("#parola").val(),
        TelNo: $("#telNo").val(),
        TcKimlikNo: $("#tcNo").val(),
        MailAdress: $("#mailAdress").val(),
        DogumTarih: new Date($("#dogumTarih").val()).toISOString().replace("T", " ").substr(0, 19),
        EhliyetAlimTarih: new Date($("#ehliyetTarih").val()).toISOString().replace("T", " ").substr(0, 19),
        AktifMi: $("#aktifMi").val()
    };

    Post("Kullanici/Kaydet", kullanici, (data) => {
        SubeleriGetir();
        $("#staticBackdrop").modal("hide");
    });

}

function KullaniciDuzenle(id, sehirId, rolId, acikAdres, ad, soyad, parola, telNo, tcKimlikNo, mailAdress, ehliyetAlimTarih, dogumTarih, aktifMi) {
    selectedId = id;
    $("#sehirAd").val(sehirId);
    $("#rolAd").val(rolId);
    $("#acikAdres").val(acikAdres);
    $("#ad").val(ad);
    $("#soyad").val(soyad);
    $("#parola").val(parola);
    $("#telNo").val(telNo);
    $("#tcNo").val(tcKimlikNo);
    $("#dogumTarih").val(mailAdress);
    $("#mailAdress").val(dogumTarih);
    $("#ehliyetTarih").val(ehliyetAlimTarih);
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

function TumRolleriGetir() {
    Get("Rol/TumRoller", (data) => {
        var roldata = data;
        var dropdown = $("#rolAd");
        $.each(roldata, function (index, rol) {
            dropdown.append($("<option>").val(rol.id).text(rol.ad));
        });
    });
}

$(document).ready(function () {
    KullaniciGetir();
    TumSehirleriGetir();
    TumRolleriGetir();
});