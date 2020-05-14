$(document).ready(function() {
    $("#txtcep").focusout(function(){
        var cep = $("#txtcep").val();
        cep = cep.replace("-","");
        cep = cep.replace(".","");
        var urlStr = "https://viacep.com.br/ws/"+ cep +"/json/";

        $.ajax({
            url : urlStr,
            type : "get",
            dataType : "json",
            success :  function(data){
                console.log(data);
                $("#logradouro").val(data.logradouro);
                $("#bairro").val(data.bairro);
                $("#cidade").val(data.localidade);
                $("#uf").val(data.uf);
                

            },
            error : function(erro){
                alert("CEP Não encontrado");
            }
        });

    });
});

