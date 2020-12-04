<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="cadastro-usuario.aspx.cs" Inherits="WebEstacionamento.cadastro_usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">Cadastro Usuário · Estacionamento</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!-- Mascaras dos campos do formulário -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js" integrity="sha512-pHVGpX7F/27yZ0ISY+VVjyULApbDlD0/X0rgGbTqCE7WFW5MezNTWG/dnhtbBuICzsd0WQPgpE4REBLv+UqChw==" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="server">
    <!--- Cadastro Usuario Section -->
    <section class="container-fluid">
        <section class="row justify-content-center">
            <section class="col-sm-6 pt-3 pb-3">
                <div class="form-container">
                    <%-- Breadcrumb --%>
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="./cadastro-selecao.aspx">Cadastro</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Cadastro Usuário</li>
                        </ol>
                    </nav>

                    <%-- Alerta cadastro bem sucedido --%>
                    <div id="alertaCadastroSucedido" class="alert alert-success collapse" role="alert">
                        Cadastrado com Sucesso! <a href="./login.aspx" class="alert-link">Faça login!</a>
                    </div>

                    <h4 class="mb-3"><i class="fas fa-user"></i> Crie sua conta</h4>
                    <h5>Informações Pessoais</h5>
                    <hr>

                    <div class="form-group">
                        <label for="BodyContent_inputNome">Nome</label>
                        <input runat="server" type="text" class="form-control" id="inputNome" placeholder="Seu nome" required>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="BodyContent_inputCPF">CPF</label>
                            <input runat="server" type="text" class="form-control" id="inputCPF" placeholder="Digite seu CPF" maxlength="14" autocomplete="off" required>
                        </div>
                        <div class="form-group col-3 col-md-2">
                            <label for="BodyContent_inputDDD">DDD</label>
                            <input runat="server" type="tel" class="form-control" id="inputDDD" placeholder="DDD" title="Insira o DDD com 2 dígitos" pattern="[1-9]{1}[1-9]{1}" maxlength="2" autocomplete="off" required>
                            <div class="invalid-feedback">
                                Por favor, insira um DDD válido!
                            </div>
                        </div>
                        <div class="form-group col-9 col-md-4">
                            <label for="BodyContent_inputCelular">Celular</label>
                            <input runat="server" type="tel" class="form-control" placeholder="Celular" title="Insira um celular sem o DDD" pattern="(\d){5}-?(\d){4}" id="inputCelular" maxlength="10" autocomplete="off" required>
                            <div class="invalid-feedback">
                                Por favor, insira um celular válido sem o DDD!
                            </div>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="BodyContent_inputEmail">Email</label>
                            <input runat="server" type="email" class="form-control" id="inputEmail" placeholder="Digite seu email" autocomplete="off" required>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="BodyContent_inputSenha">Senha</label>
                            <input runat="server" type="password" class="form-control" id="inputSenha" placeholder="Crie uma senha" autocomplete="off" required>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="BodyContent_inputConfSenha">Confirmar Senha</label>
                            <input runat="server" type="password" class="form-control" id="inputConfSenha" placeholder="Confirme sua senha" autocomplete="off" required>
                        </div>
                    </div>

                    <div id="alertaCamposInvalidos" class="alert alert-danger alert-dismissible collapse" role="alert">
                        <span id="txtAlertaCamposInvalidos"></span>
                        <button id="alertClose" type="button" class="close" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

                    <asp:Button ID="btnCadastrar" cssClass="btn btn-primary" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click"/>
                </div>
            </section>
        </section>
    </section>

    <script src="js/main.js"></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PostBodyContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            // Ativa a mascara do campo CPF
            $('#BodyContent_inputCPF').mask('000.000.000-00', { reverse: true });
            // Ativa a mascara do campo Celular
            $('#BodyContent_inputCelular').mask('00000-0000');
        });
    </script>
</asp:Content>