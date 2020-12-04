// validação do bootstrap abaixo do campo
var ValidarCampo = function (elementID, booleano) {
    if (booleano) {
        $(elementID).removeClass('is-invalid');
        $(elementID).addClass('is-valid');
    }
    else {
        $(elementID).removeClass('is-valid');
        $(elementID).addClass('is-invalid');
    }
};

// função chamada pelo code behind; recebe um texto para exibir uma mensagem ao usuario
var AlertarCamposInvalidos = function (mensagem) {
    $('#txtAlertaCamposInvalidos').html(mensagem);
    $('#alertaCamposInvalidos').show('fade');
};

// função chamada pelo code behind; exibe o alerta de cadastro bem sucedido
var AlertaCadastroBemSucedido = function () {
    $('#alertaCadastroSucedido').show('fade');
    setTimeout(function () {
        window.scrollTo(0, 0);
    }, 5);
};

$(document).ready(function () {
    // ativa tooltip em todos os campos que o possuem (procurando pela tag 'data-toggle')
    $('[data-toggle="tooltip"]').tooltip()

    // fecha o alerta de campos invalidos ao apertar o botao X dentro do alerta
    $('#alertClose').click(function () {
        $('#alertaCamposInvalidos').hide('fade');
    });
});
