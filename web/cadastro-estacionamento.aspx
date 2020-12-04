<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="cadastro-estacionamento.aspx.cs" Inherits="WebEstacionamento.cadastro_estacionamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">Cadastrar Estacionamento · Estacionamento</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!-- Mascaras dos campos do formulário -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js" integrity="sha512-pHVGpX7F/27yZ0ISY+VVjyULApbDlD0/X0rgGbTqCE7WFW5MezNTWG/dnhtbBuICzsd0WQPgpE4REBLv+UqChw==" crossorigin="anonymous"></script>
    <link href="./css/maps.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="server">
    <!--- Cadastro Estacionamento Section -->
    <section class="container-fluid">
        <section class="row justify-content-center">
            <section class="col-sm-6 pt-3 pb-3">
                <div class="form-container">
                    <%-- Breadcrumb --%>
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="./dashboard.aspx">Painel</a></li>
                            <li class="breadcrumb-item"><a href="./gerenciar-estacionamentos.aspx">Estacionamentos</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Cadastrar Estacionamento</li>
                        </ol>
                    </nav>

                    <%-- Alerta cadastro bem sucedido --%>
                    <div id="alertaCadastroSucedido" class="alert alert-success collapse" role="alert">
                        Estacionamento cadastrado com sucesso!
                    </div>

                    <h4 class="mb-3"><i class="fas fa-parking"></i> Cadastrar estacionamento</h4>
                    <h5>Informações Básicas</h5>
                    <hr>

                    <div class="form-group row">
                        <label for="BodyContent_inputStatus" class="col-2 col-form-label">Status</label>
                        <div class="col-10">
                            <select runat="server" id="inputStatus" class="form-control" autocomplete="off" required>
                                <option value="1">Ativo</option>
                                <option value="0">Inativo</option>
                            </select>
                        </div>
                    </div>

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

                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="BodyContent_inputBairro">Bairro</label>
                            <input runat="server" type="text" class="form-control" id="inputBairro" placeholder="Bairro" autocomplete="off" readonly required>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="BodyContent_inputRegiao">Região</label>
                            <asp:DropDownList ID="inputRegiao" runat="server" class="form-control" autocomplete="off" data-toggle="tooltip" title="Escolher uma região lhe permitirá filtrar seus estacionamentos porteriormente nos relatórios" required></asp:DropDownList>
                            <div class="invalid-feedback">
                                Por favor, selecione uma Região da lista!
                            </div>
                        </div>
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

                    <div class="form-row">
                        <div class="form-group col-3">
                            <label for="BodyContent_inputDDD">DDD</label>
                            <input runat="server" type="tel" class="form-control" id="inputDDD" placeholder="DDD" title="Insira o DDD com 2 dígitos" pattern="[1-9]{1}[1-9]{1}" maxlength="2" autocomplete="off">
                            <div class="invalid-feedback">
                                Por favor, insira um DDD válido!
                            </div>
                        </div>
                        <div class="form-group col-6">
                            <label for="BodyContent_inputTelefone">Telefone</label>
                            <input runat="server" type="tel" class="form-control" placeholder="Telefone" title="Insira um telefone sem o DDD" pattern="(\d){4,5}-?(\d){4}" id="inputTelefone" maxlength="10" autocomplete="off">
                            <div class="invalid-feedback">
                                Por favor, insira um telefone válido sem o DDD!
                            </div>
                        </div>
                        <div class="form-group col-3">
                            <label for="BodyContent_inputRamal">Ramal</label>
                            <input runat="server" type="text" class="form-control" id="inputRamal" placeholder="Ramal" maxlength="10" autocomplete="off">
                        </div>
                    </div>

                    <div id="alertaCamposInvalidos" class="alert alert-danger alert-dismissible collapse" role="alert">
                        <span id="txtAlertaCamposInvalidos"></span>
						<button id="alertClose" type="button" class="close" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

                    <div class="mb-3">
                        <button type="button" id="btnAtualizarMapa" class="btn btn-primary" onclick="AtualizarMapa()">Abrir Mapa</button>
                    </div>

                    <div id="mapa_container" class="collapse">
                        <div id="mapa" class="my-3"></div>

                        <h5>Posição Selecionada <svg id="map-info" data-toggle="tooltip" title="Se necessário, defina uma nova posição no mapa. Essa será a posição mostrada para os seus clientes." xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" width="16" height="16"><path fill-rule="evenodd" d="M8 1.5a6.5 6.5 0 100 13 6.5 6.5 0 000-13zM0 8a8 8 0 1116 0A8 8 0 010 8zm6.5-.25A.75.75 0 017.25 7h1a.75.75 0 01.75.75v2.75h.25a.75.75 0 010 1.5h-2a.75.75 0 010-1.5h.25v-2h-.25a.75.75 0 01-.75-.75zM8 6a1 1 0 100-2 1 1 0 000 2z"></path></svg></h5>
                        <div class="form-row">
                            <div class="form-group col-6">
                                <label for="BodyContent_inputLat">Latitude</label>
                                <input runat="server" type="text" class="form-control" ID="inputLat" placeholder="Latitude" title="Posicione o marcador no mapa" autocomplete="off" readonly required>
                            </div>
                            <div class="form-group col-6">
                                <label for="BodyContent_inputLng">Longitude</label>
                                <input runat="server" type="text" class="form-control" ID="inputLng" placeholder="Longitude" title="Posicione o marcador no mapa" autocomplete="off" readonly required>
                            </div>
                        </div>
                    </div>

                    <div class="mt-3">
                        <asp:Button ID="btnCadastrar" cssClass="btn btn-primary" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click"/>
                    </div>
                </div>
            </section>
        </section>
    </section>

    <script src="js/main.js"></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PostBodyContent" runat="server">
    <script type="text/javascript">
        // Mascara telefone/celular
        var maskBehavior = function (val) {
            return val.replace(/\D/g, '').length === 9 ? '00000-0000' : '0000-00009';
        },
            options = {
                onKeyPress: function (val, e, field, options) {
                    field.mask(maskBehavior.apply({}, arguments), options);
                }
            };

        $(document).ready(function () {
            // Ativa a mascara do campo CEP
            $('#BodyContent_inputCEP').mask('00000-000');
            // Ativa a mascara do campo telefone
            $('#BodyContent_inputTelefone').mask(maskBehavior, options);
        });
    </script>

    <script src="js/gmaps-cadastro.js"></script>
    <script defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDwHnltuFUPTC-F7Zq9CYze1sW8gndsIEY"></script>
</asp:Content>