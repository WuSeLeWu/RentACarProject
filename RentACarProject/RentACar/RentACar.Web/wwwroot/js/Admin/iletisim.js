function MesajlariGetir() {
    var html = "";
    Get("Iletisim/TumMesajlar", (data) => {
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
            ${arr[i].id} ${arr[i].konuBasligi}
          </button>
        </h2>
        <div
          id="flush-collapse${arr[i].id}"
          class="accordion-collapse collapse"
          data-bs-parent="#accordionFlushExample"
        >
          <div class="accordion-body">
            <table class="table border border-black">
              <thead>
                <tr class="bg-black text-light">
                  <th scope="col">#</th>
                  <th scope="col">#</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <th scope="row">Ad Soyad :</th>
                  <td>${arr[i].adSoyad}</td>
                </tr>
                <tr>
                  <th scope="row">Telefon Numarası :</th>
                  <td>${arr[i].telNo}</td>
                </tr>
                <tr>
                  <th scope="row">Mail Adresi :</th>
                  <td>${arr[i].mailAdress}</td>
                </tr>
                <tr>
                  <th scope="row">Mesaj :</th>
                  <td>${arr[i].mesaj}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>`;

        }
        $("#divIletisim").html(html);

        $("#ara").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $("#divIletisim .accordion").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
            });
        });

    });
}


let selectedId = 0;
function IletisimKaydet() {
    var iletisim = {
        Id: selectedId,
        AdSoyad: $("#adSoyad").val(),
        MailAdress: $("#email").val(),
        KonuBasligi: $("#konuBaslik").val(),
        TelNo: $("#telNo").val(),
        Mesaj: $("#mesaj").val()

    };

    Post("Iletisim/Kaydet", iletisim, (data) => {
        MesajlariGetir()
    });
}

$(document).ready(function () {
    MesajlariGetir();
});