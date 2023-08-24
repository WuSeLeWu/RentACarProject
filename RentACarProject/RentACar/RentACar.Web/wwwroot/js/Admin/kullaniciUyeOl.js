function TumSehirleriGetir() {
    Get("Sehir/TumSehirler", (data) => {
        var sehirdata = data;
        var dropdown = $("#sehirAd");
        $.each(sehirdata, function (index, sehir) {
            dropdown.append($("<option>").val(sehir.id).text(sehir.ad));
        });
    });
}

function KullaniciUyeOl() {
    var uyeol = {
        Ad: $("#kad").val(),
        Soyad: $("#ksoyad").val(),
        SehirId:$("#sehirAd").val(),
        Parola: $("#kparola").val(),
        TelNo: $("#ktelNo").val(),
        TcKimlikNo: $("#ktcNo").val(),
        MailAdress: $("#kmailAdress").val(),
        DogumTarih: new Date($("#kdogumTarih").val()).toISOString(),
        EhliyetAlimTarih: new Date($("#kehliyetTarih").val()).toISOString(),
        AcikAdres: $("#kacikAdres").val(),
    };

    Post("Kullanici/UyeOl", uyeol, (data) => {

    });

}



$(document).ready(function () {
    TumSehirleriGetir();
});