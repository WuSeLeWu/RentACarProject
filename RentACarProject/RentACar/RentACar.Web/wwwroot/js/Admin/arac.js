function AraclariGetir() {
    var html = "";

    Get("Arac/AracTamBilgiler", (data) => {
        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<div class="col-sm">
      <div class="card shadow-sm">
    <img  class="bd-placeholder-img card-img-top"
      width="90%"
      height="255"
      src="/img/aracfotolari/${arr[i].foto}" />
        <div class="card-body position-relative">
        <button class="btn btn-link position-absolute top-0 end-0">
                    <i class="bi bi-trash3-fill text-danger px-2 py-2 mx-3 border border-danger" onclick=AracSil(${arr[i].id})></i>
                  </button>
                  <button class="btn btn-link position-absolute top-0 start-0">
                   <i class="bi bi-pencil-square text-primary px-2 py-2 mx-3 border border-primary" onclick='AracDuzenle(
                       ${arr[i].id},"${arr[i].markaId}","${arr[i].modelId}","${arr[i].yakitTipId}","${arr[i].subeId}","${arr[i].aracDurum}","${arr[i].vitesTip}","${arr[i].kmSinir}","${arr[i].depozitoUcret}","${arr[i].koltukSayi}","${arr[i].fiyat}","${arr[i].aciklama}"
                   )'></i>
                  </button>
          <div class="table-title">
            ${arr[i].id} ${arr[i].markaAd} ${arr[i].modelAd}
          </div>
          <table class="table">
            <tbody>
              <tr>
                <th scope="col">Fiyat :</th>
                <td scope="col">${arr[i].fiyat} ₺</td>
              </tr>
              <tr>
                <th scope="row">Şube Adı :</th>
                <td>${arr[i].subeAd}</td>
              </tr>
              <tr>
                <th scope="row">Vites Tipi :</th>
                <td colspan="2">${arr[i].vitesTip ? 'Manuel' : 'Otomatik'}               
                </td>
              </tr>
              <tr>
                <th scope="row">Km Sınırı :</th>
                <td colspan="2">${arr[i].kmSinir}</td>
              </tr>
              <tr>
                <th scope="row">Depozito Ücreti :</th>
                <td colspan="2">${arr[i].depozitoUcret}</td>
              </tr>
              <tr>
                <th scope="row">Yakıt Tipi :</th>
                <td colspan="2">${arr[i].yakitTipAd}</td>
              </tr>
              <tr>
                <th scope="row">Arac Durumu :</th>
                <td colspan="2">
                  <span style="color: ${arr[i].aracDurum ? 'green' : 'red'};">
                         ${arr[i].aracDurum ? 'Aktif' : 'Pasif'}
                     </span>
                </td>
              </tr>
              <tr>
                <th scope="row">Koltuk Sayı :</th>
                <td colspan="2">${arr[i].koltukSayi}</td>
              </tr>
              <tr>
                <th scope="row">Açıklama :</th>
              </tr>
              <tr>
                <td colspan="2">${arr[i].aciklama}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>`;


        }

        $("#divAraclar").html(html);

        $("#ara").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $("#divAraclar .col-sm").each(function () {
                if ($(this).text().toLowerCase().indexOf(value) > -1) {
                    $(this).show();
                } else {
                    $(this).hide();
                }
            });
        });


    });
}

function AraclariGetirAnaSayfa() {
    var html = "";

    Get("Arac/AracTamBilgilerAktif", (data) => {
        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<div class="col aramaDivi">
          <div class="card h-100">
            <img
              src="/img/aracfotolari/${arr[i].foto}"
              class="card-img-top h-100"
              alt="ArabaResmi"
            />
            <div class="card-body">
              <h5 class="card-title d-flex justify-content-center">
                ${arr[i].markaAd} ${arr[i].modelAd}
              </h5>
              <div class="row">
                <div class="col-12 btn btn-success"><h5>${arr[i].fiyat}₺ / Gün</h5></div>
              </div>
            </div>
            <div class="row d-flex">
              <div class="col">
                <ul class="list-group list-group-flush">
                  <li class="list-group-item">
                    <i class="bi bi-controller"></i>
                    ${arr[i].vitesTip ? 'Manuel' : 'Otomatik'}
                  </li>
                  <li class="list-group-item">
                    <i class="bi bi-person-plus"></i>
                    ${arr[i].koltukSayi}
                  </li>
                </ul>
              </div>
              <div class="col">
                <ul class="list-group list-group-flush">
                  <li class="list-group-item">
                    <i class="bi bi-speedometer"></i>
                    ${arr[i].kmSinir} KM
                  </li>
                  <li class="list-group-item">
                    <i class="bi bi-ev-front"></i>
                    ${arr[i].yakitTipAd}
                  </li>
                </ul>
              </div>
              <div class="col-12">
                <ul class="list-group list-group-flush">
                  <li class="list-group-item">
                    <i class="bi bi-shop"></i>
                    ${arr[i].subeAd}
                  </li>
                </ul>
              </div>
              <div class="col-12">
                <ul class="list-group list-group-flush">
                  <li class="list-group-item">
                    <i class="bi bi-tag">Depozito :</i>
                    ${arr[i].depozitoUcret}₺
                  </li>
                </ul>
              </div>
            </div>
            <div class="card-body">
               
              <a class="nav-link active" asp-area="Kiralama" asp-controller="Arac"  href="Detay/${arr[i].id}">
              <button class="btn btn-dark col-12">KİRALA</button>
              </a>
            </div>
          </div>
        </div>`;


        }

        $("#araclarAnaSayfa").html(html);

        $("#arama").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $("#araclarAnaSayfa .aramaDivi").each(function () {
                if ($(this).text().toLowerCase().indexOf(value) > -1) {
                    $(this).show();
                } else {
                    $(this).hide();
                }
            });
        });


    });
}

function AracFiltele() {
    $(document).ready(function () {
        $('#aracSehir').change(function () {
            var selectedSehir = $(this).val();
            getAraclar(selectedSehir);
        });

        function getAraclar(sehir) {
            Get(`Arac/SehirdekiAraclariGetir/${sehir}`, (data) => {
                var arr = data;
                var araclarListesi = $('#araclarAnaSayfa');
                araclarListesi.empty();

                for (var i = 0; i < arr.length; i++) {
                    araclarListesi.append(`<div class="col aramaDivi">
          <div class="card h-100">
            <img
              src="/img/aracfotolari/${arr[i].foto}"
              class="card-img-top h-100"
              alt="ArabaResmi"
            />
            <div class="card-body">
              <h5 class="card-title d-flex justify-content-center">
                ${arr[i].markaAd} ${arr[i].modelAd}
              </h5>
              <div class="row">
                <div class="col-12 btn btn-success"><h5>${arr[i].fiyat}₺ / Gün</h5></div>
              </div>
            </div>
            <div class="row d-flex">
              <div class="col">
                <ul class="list-group list-group-flush">
                  <li class="list-group-item">
                    <i class="bi bi-controller"></i>
                    ${arr[i].vitesTip ? 'Manuel' : 'Otomatik'}
                  </li>
                  <li class="list-group-item">
                    <i class="bi bi-person-plus"></i>
                    ${arr[i].koltukSayi}
                  </li>
                </ul>
              </div>
              <div class="col">
                <ul class="list-group list-group-flush">
                  <li class="list-group-item">
                    <i class="bi bi-speedometer"></i>
                    ${arr[i].kmSinir} KM
                  </li>
                  <li class="list-group-item">
                    <i class="bi bi-ev-front"></i>
                    ${arr[i].yakitTipAd}
                  </li>
                </ul>
              </div>
              <div class="col-12">
                <ul class="list-group list-group-flush">
                  <li class="list-group-item">
                    <i class="bi bi-shop"></i>
                    ${arr[i].subeAd}
                  </li>
                </ul>
              </div>
              <div class="col-12">
                <ul class="list-group list-group-flush">
                  <li class="list-group-item">
                    <i class="bi bi-tag">Depozito :</i>
                    ${arr[i].depozitoUcret}₺
                  </li>
                </ul>
              </div>
            </div>
            <div class="card-body">
             <a class="nav-link active" asp-area="Kiralama" asp-controller="Arac"  href="Detay/${arr[i].id}">
              <button class="btn btn-dark col-12">KİRALA</button>
              </a>
            </div>
          </div>
        </div>`);
                }

            });
        }
    });
}
let selectedId = 0;

function YeniArac() {
    selectedId = 0;
    $("#ddlMarka").val("");
    $("#ddlModel").val("");
    $("#ddlYakitTipAdlari").val("")
    $("#ddlSube").val("");
    $("#ddlAracDurum").val("");
    $("#aracFoto").val("");
    $("#ddlVitesTip").val("");
    $("#validationCustom05").val("");
    $("#validationCustom06").val("");
    $("#validationCustom07").val("");
    $("#validationCustom08").val("");
    $("#ddlAciklama").val();

    $("#staticBackdrop").modal("show");
}

function GetFileNameFromPath(filePath) {
    var startIndex = (filePath.indexOf('\\') >= 0 ? filePath.lastIndexOf('\\') : filePath.lastIndexOf('/'));
    var fileName = filePath.substring(startIndex);
    if (fileName.indexOf('\\') === 0 || fileName.indexOf('/') === 0) {
        fileName = fileName.substring(1);
    }
    return fileName;
}

function AracKaydet() {
    var arac = {
        Id: selectedId,
        MarkaId: $("#ddlMarka").val(),
        ModelId: $("#ddlModel").val(),
        YakitTipId: $("#ddlYakitTipAdlari").val(),
        SubeId: $("#ddlSube").val(),
        AracDurum: $("#ddlAracDurum").val(),
        Foto: GetFileNameFromPath($("#aracFoto").val()), // Sadece dosya adını al
        VitesTip: $("#ddlVitesTip").val(),
        KmSinir: $("#validationCustom05").val(),
        DepozitoUcret: $("#validationCustom06").val(),
        KoltukSayi: $("#validationCustom07").val(),
        Fiyat: $("#validationCustom08").val(),
        Aciklama: $("#ddlAciklama").val()
    };

    Post("Arac/Kaydet", arac, (data) => {
        AraclariGetir();
        $("#staticBackdrop").modal("hide");
    });

}




function AracSil(id) {
    Delete(`Arac/Sil?id=${id}`, (data) => {
        AraclariGetir();
    });
}

function AracDuzenle(id, markaId, modelId, yakitTipId, subeId, aracDurum,/*foto,*/ vitesTip, kmSinir, depozitoUcret, koltukSayi, fiyat, aciklama) {
    selectedId = id;
    $("#ddlMarka").val(markaId);
    $("#ddlModel").val(modelId);
    $("#ddlYakitTipAdlari").val(yakitTipId);
    $("#ddlSube").val(subeId);
    $("#ddlAracDurum").val(aracDurum);
/*    $("#aracFoto").val(foto);*/
    $("#ddlVitesTip").val(vitesTip);
    $("#validationCustom05").val(kmSinir);
    $("#validationCustom06").val(depozitoUcret);
    $("#validationCustom07").val(koltukSayi);
    $("#validationCustom08").val(fiyat);
    $("#ddlAciklama").val(aciklama);
    $("#staticBackdrop").modal("show");
}

function TumSubeAdlariGetir() {
    Get("Sube/TumSubeler", (data) => {
        var ddlSube = data;
        var dropdown = $("#ddlSube");
        $.each(ddlSube, function (index, sube) {
            dropdown.append($("<option>").val(sube.id).text(sube.ad));
        });
    });
}

function TumYakitTipleriniGetir() {
    Get("YakitTip/TumYakitTipleri", (data) => {
        var ddlYakitTipAdlari = data;
        var dropdown = $("#ddlYakitTipAdlari");
        $.each(ddlYakitTipAdlari, function (index, yakit) {
            dropdown.append($("<option>").val(yakit.id).text(yakit.ad));
        });
    });
}

function TumSehirleriGetir() {
    Get("Sehir/TumSehirler", (data) => {
        var sehirdata = data;
        var dropdown = $("#aracSehir");
        $.each(sehirdata, function (index, sehir) {
            dropdown.append($("<option>").val(sehir.id).text(sehir.ad));
        });
    });
}

$(document).ready(function () {
    Get("MarkaModel/TumMarkalar", (data) => {
        var markalar = data;
        var ddlMarka = $("#ddlMarka");
        $.each(markalar, function (index, marka) {
            ddlMarka.append($("<option>").val(marka.id).text(marka.ad));
        });
    });
    $("#ddlMarka").change(function () {
        var markaId = $(this).val();
        var ddlModel = $("#ddlModel");
        ddlModel.empty();
        if (markaId !== "") {
            Get(`MarkaModel/ModellereGoreMarkalar/${markaId}`, (data) => {
                var modeller = data;
                $.each(modeller, function (index, model) {
                    ddlModel.append($("<option>").val(model.id).text(model.ad));
                });
            });
        }
    });

    $("#aracEkleForm").submit(function (event) {
        event.preventDefault();
        var selectedMarkaId = $("#ddlMarka").val();
        var selectedModelId = $("#ddlModel").val();
    });
});

$(document).ready(function () {
    AraclariGetir();
    AraclariGetirAnaSayfa();
    TumYakitTipleriniGetir();
    TumSubeAdlariGetir();
    TumSehirleriGetir();

    AracFiltele();
});