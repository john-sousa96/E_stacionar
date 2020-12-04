<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="cadastro-funcionario.aspx.cs" Inherits="WebEstacionamento.cadastro_funcionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">Cadastrar Funcionário(a) · Estacionamento</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!-- Mascara do CPF -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js" integrity="sha512-pHVGpX7F/27yZ0ISY+VVjyULApbDlD0/X0rgGbTqCE7WFW5MezNTWG/dnhtbBuICzsd0WQPgpE4REBLv+UqChw==" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="server">
    <!--- Cadastrar Funcionário Section -->
    <section class="container-fluid">
        <section class="row justify-content-center">
            <section class="col-sm-6 pt-3 pb-3">
                <%-- Breadcrumb --%>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="./dashboard.aspx">Painel</a></li>
                        <li class="breadcrumb-item"><a href="./gerenciar-funcionarios.aspx">Funcionários</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Cadastrar Funcionário</li>
                    </ol>
                </nav>

                <%-- Alerta cadastro bem sucedido --%>
                <div id="alertaCadastroSucedido" class="alert alert-success collapse" role="alert">
                    Funcionário(a) cadastrado(a) com sucesso!
                </div>

                <h4 class="mb-3"><i class="far fa-address-card"></i> Cadastrar funcionário</h4>
                <h5>Dados do Funcionário</h5>
                <hr>

                <div class="form-container">
                    <div class="form-group row">
                        <label for="BodyContent_inputStatus" class="col-2 col-form-label">Status</label>
                        <div class="col-10">
                            <select runat="server" id="inputStatus" class="form-control" autocomplete="off" required>
                                <option value="1">Ativo</option>
                                <option value="0">Inativo</option>
                            </select>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="BodyContent_inputEstacionamento">Estacionamento</label>
                        <asp:DropDownList ID="inputEstacionamento" runat="server" class="form-control" autocomplete="off" data-toggle="tooltip" title="Selecione o estacionamento onde esse funcionário trabalha" required></asp:DropDownList>
                        <div class="invalid-feedback">
                            Por favor, selecione um Estacionamento da lista!
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="BodyContent_inputNome">Nome Completo</label>
                        <input runat="server" type="text" class="form-control" id="inputNome" placeholder="Nome do(a) Funcionário(a)" autocomplete="off" required>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="BodyContent_inputCPF">CPF</label>
                            <input runat="server" type="text" class="form-control" id="inputCPF" placeholder="CPF do(a) Funcionário(a)" maxlength="14" autocomplete="off" required>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="BodyContent_inputCargo">Cargo</label>
                            <input runat="server" type="text" class="form-control" id="inputCargo" placeholder="Cargo do(a) Funcionário(a)" autocomplete="off" required>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="BodyContent_inputSenha">Senha</label>
                            <input runat="server" type="password" class="form-control" id="inputSenha" placeholder="Crie uma senha" autocomplete="off" required>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="BodyContent_inputConfSenha">Confirme a Senha</label>
                            <input runat="server" type="password" class="form-control" id="inputConfSenha" placeholder="Confirme a senha" autocomplete="off" required>
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
        });
    </script>
</asp:Content>