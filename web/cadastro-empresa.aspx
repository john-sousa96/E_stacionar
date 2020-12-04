<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="cadastro-empresa.aspx.cs" Inherits="WebEstacionamento.cadastro_empresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">Cadastro Empresa · Estacionamento</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!-- Mascaras dos campos do formulário -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js" integrity="sha512-pHVGpX7F/27yZ0ISY+VVjyULApbDlD0/X0rgGbTqCE7WFW5MezNTWG/dnhtbBuICzsd0WQPgpE4REBLv+UqChw==" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="server">
    <!--- Cadastro Empresa Section -->
    <section class="container-fluid">
        <section class="row justify-content-center">
            <section class="col-sm-6 pt-3 pb-3">
                <%-- Breadcrumb --%>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="./cadastro-selecao.aspx">Cadastro</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Cadastro Empresa</li>
                    </ol>
                </nav>

                <%-- Alerta cadastro bem sucedido --%>
                <div id="alertaCadastroSucedido" class="alert alert-success collapse" role="alert">
                    Cadastrado com Sucesso! <a href="./login.aspx" class="alert-link">Faça login!</a>
                </div>

                <h4 class="mb-3"><i class="fas fa-building"></i> Cadastre sua empresa</h4>
                <h5>Informações Básicas</h5>
                <hr>

                <div class="form-container">
                    <div class="form-group">
                        <label for="BodyContent_inputNome">Nome da Empresa</label>
                        <input runat="server" type="text" class="form-control" id="inputNome" placeholder="Nome da Empresa" autocomplete="off" required>
                    </div>
                    <div class="form-group">
                        <label for="BodyContent_inputProprietario">Nome do Proprietário</label>
                        <input runat="server" type="text" class="form-control" id="inputProprietario" placeholder="Responsável pela Empresa" autocomplete="off" required>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-3">
                            <label for="BodyContent_inputDDD">DDD</label>
                            <input runat="server" type="tel" class="form-control" id="inputDDD" placeholder="DDD" title="Insira o DDD com 2 dígitos" pattern="[1-9]{1}[1-9]{1}" maxlength="2" autocomplete="off" required>
                            <div class="invalid-feedback">
                                Por favor, insira um DDD válido!
                            </div>
                        </div>
                        <div class="form-group col-6">
                            <label for="BodyContent_inputTelefone">Telefone</label>
                            <input runat="server" type="tel" class="form-control" placeholder="Telefone" title="Insira um telefone sem o DDD" pattern="(\d){4}-?(\d){4}" id="inputTelefone" maxlength="9" autocomplete="off" required>
                            <div class="invalid-feedback">
                                Por favor, insira um telefone válido sem o DDD!
                            </div>
                        </div>
                        <div class="form-group col-3">
                            <label for="BodyContent_inputRamal">Ramal</label>
                            <input runat="server" type="text" class="form-control" id="inputRamal" placeholder="Ramal" maxlength="10" autocomplete="off">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="BodyContent_inputCNPJ">CNPJ</label>
                            <input runat="server" type="text" class="form-control" id="inputCNPJ" placeholder="CNPJ da empresa" maxlength="14" autocomplete="off" required>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="BodyContent_inputEmail">Email</label>
                            <input runat="server" type="email" class="form-control" id="inputEmail" placeholder="Digite seu email" autocomplete="off" required>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="BodyContent_inputSenha">Senha</label>
                            <input runat="server" type="password" class="form-control" id="inputSenha" placeholder="Crie uma senha" autocomplete="off" required>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="BodyContent_inputConfSenha">Confirmar a Senha</label>
                            <input runat="server" type="password" class="form-control" id="inputConfSenha" placeholder="Confirme sua senha" autocomplete="off" required>
                        </div>
                    </div>

                    <h5>Endereço da Sede</h5>
                    <hr>

                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <label for="BodyContent_inputCEP">CEP</label>
                            <asp:TextBox ID="inputCEP" runat="server" AutoPostBack="true" OnTextChanged="inputCEP_Changed" type="text" class="form-control" title="Insira o CEP" pattern="[0-9]{5}-?[0-9]{3}" maxlength="9" placeholder="Digite o CEP" autocomplete="postal-code" required></asp:TextBox>
                            <div class="invalid-feedback">
                                Por favor, insira um CEP válido!
                            </div>
                        </div>
                        <div class="form-group col-md-8">
                            <label for="BodyContent_inputLogradouro">Nome do Logradouro</label>
                            <input runat="server" type="text" class="form-control" id="inputLogradouro" placeholder="Nome do Logradouro" autocomplete="off" readonly required>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-4">
                            <label for="BodyContent_inputNumero">Número</label>
                            <input runat="server" type="tel" class="form-control" id="inputNumero" placeholder="Número" title="Insira o número do logradouro ou deixe em branco" maxlength="10" autocomplete="off">
                        </div>
                        <div class="form-group col-8">
                            <label for="BodyContent_inputComplemento">Complemento</label>
                            <input runat="server" type="text" class="form-control" id="inputComplemento" placeholder="Complemento" maxlength="200" autocomplete="off">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="BodyContent_inputBairro">Bairro</label>
                        <input runat="server" type="text" class="form-control" id="inputBairro" placeholder="Bairro" autocomplete="off" readonly required>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-7">
                            <label for="BodyContent_inputCidade">Cidade</label>
                            <input ID="inputCidade" runat="server" class="form-control" placeholder="Cidade" autocomplete="off" readonly required>
                        </div>
                        <div class="form-group col-5">
                            <label for="BodyContent_inputUF">UF</label>
                            <input ID="inputUF" runat="server" class="form-control" placeholder="UF" autocomplete="off" readonly required>
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
        $(document).ready(function () {          // Ativa a mascara do campo CNPJ
            $('#BodyContent_inputCNPJ').mask('00.000.000/0000-00', { reverse: true });
            // Ativa a mascara do campo Telefone
            $('#BodyContent_inputTelefone').mask('0000-0000');
            // Ativa a mascara do campo CEP
            $('#BodyContent_inputCEP').mask('00000-000');
        });
    </script>
</asp:Content>