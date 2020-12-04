<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebEstacionamento.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">Login · Estacionamento</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!-- Mascara de CPF e CNPJ -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js" integrity="sha512-pHVGpX7F/27yZ0ISY+VVjyULApbDlD0/X0rgGbTqCE7WFW5MezNTWG/dnhtbBuICzsd0WQPgpE4REBLv+UqChw==" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="server">
    <!--- Login Section -->
    <section class="container-fluid h-75">
        <section class="row justify-content-center">
            <section class="col-12 col-sm-6 col-md-3 pt-3 pb-3">
                <div class="form-container padding">
                    <!-- <a href="./index.html"><img src="img/logo.png" height="100px" width="100px"></a> -->

                    <h4 class="text-center padding">Login</h4>

                    <div class="form-group">
                        <asp:Label id="lblLogin" runat="server" Text="CPF/CNPJ" AssociatedControlID="txtLogin" />
                        <asp:TextBox id="txtLogin" runat="server" type="text" inputmode="decimal" class="form-control" MaxLength="18" required />
                    </div>

                    <div class="form-group">
                        <asp:Label id="lblSenha" runat="server" Text="Senha" AssociatedControlID="txtSenha" />
                        <asp:TextBox id="txtSenha" runat="server" type="password" class="form-control" required />
                    </div>

                    <div id="alertaLoginFalhou" class="alert alert-warning alert-dismissible collapse" role="alert">
                        Credenciais inválidas. Tente novamente.
						<button id="alertClose" type="button" class="close" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

                    <asp:Button ID="btnEntrar" cssClass="btn btn-primary btn-block" runat="server" Text="Entrar" OnClick="btnEntrar_Click"/>
                </div>

                <a href="./cadastro-selecao.aspx" id="btnSignUp" role="button" class="btn btn-primary btn-block">Cadastre-se</a>
            </section>
        </section>
    </section>

    <script type="text/javascript">
        // script de alerta de falha no login
        var AlertarLoginFalhou = function () {
            $('#alertaLoginFalhou').show('fade');

            setTimeout(function () {
                $('#alertaLoginFalhou').hide('fade');
            }, 3000);
        };
	</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PostBodyContent" runat="server">
    <script type="text/javascript">
        // Mascara pro campo login
        var CpfCnpjMaskBehavior = function (val) {
            return val.replace(/\D/g, '').length <= 11 ? '000.000.000-009' : '00.000.000/0000-00';
        },
            cpfCnpjpOptions = {
                onKeyPress: function (val, e, field, options) {
                    field.mask(CpfCnpjMaskBehavior.apply({}, arguments), options);
                }
            };

        $(document).ready(function () {
            // automatiza a classe 'active' da navbar
            $('a.nav-link[href^="./' + location.pathname.split("/")[1] + '"]').addClass('active');

            // fecha o alerta de falha no login ao apertar o botao X dentro do alerta
            $('#alertClose').click(function () {
                $('#alertaLoginFalhou').hide('fade');
            });

            // Mascara de CPF e CNPJ
            $('#BodyContent_txtLogin').mask(CpfCnpjMaskBehavior, cpfCnpjpOptions);
        });
    </script>
</asp:Content>