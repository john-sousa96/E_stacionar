<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="cadastro-veiculo.aspx.cs" Inherits="WebEstacionamento.cadastro_veiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">Cadastrar Veículo · Estacionamento</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        #BodyContent_inputPlaca {
            text-transform: uppercase;
        }

        #BodyContent_inputPlaca::-webkit-input-placeholder { /* WebKit browsers */
            text-transform: none;
        }

        #BodyContent_inputPlaca:-moz-placeholder { /* Mozilla Firefox 4 to 18 */
            text-transform: none;
        }

        #BodyContent_inputPlaca::-moz-placeholder { /* Mozilla Firefox 19+ */
            text-transform: none;
        }

        #BodyContent_inputPlaca:-ms-input-placeholder { /* Internet Explorer 10+ */
            text-transform: none;
        }

        #BodyContent_inputPlaca::placeholder { /* Recent browsers */
            text-transform: none;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            // exibe a mensagem de sucesso ao carregar a pagina, se a variavel asp nao estiver vazia
            msgSucesso = "<%= MsgSucesso %>";

            if (msgSucesso.length > 0) {
                AlertarSucesso(msgSucesso);
            }
        });

        // função chamada pelo code behind; exibe o alerta de sucesso
        var AlertarSucesso = function (mensagem) {
            $('#alertaSucesso').hide();
            $('#alertaErro').hide();
            $('#txtAlertaSucesso').html(mensagem);
            $('#alertaSucesso').show('fade');
            setTimeout(function () {
                window.scrollTo(0, 0);
            }, 1);
        };

        // função chamada pelo code behind; exibe o alerta de erro
        var AlertarErro = function (mensagem) {
            $('#alertaErro').hide();
            $('#alertaSucesso').hide();
            $('#txtAlertaErro').html(mensagem);
            $('#alertaErro').show('fade');
        };
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="server">
    <asp:ScriptManager ID="ScriptManagerVeiculo" runat="server"></asp:ScriptManager>

    <div id="ModalConfirmarToken" class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-labelledby="ModalConfirmarToken" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Confirmar Token</h5>
                    <button type="button" class="close" title="Fechar" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <asp:UpdatePanel ID="updatePanelModal" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <p>Identificamos que a Placa <b><asp:Literal ID="lblPlaca" runat="server"></asp:Literal></b> já consta em nosso sistema!</p>
                            <p>Por favor, confirme que você possui permissão para cadastrar este veículo inserindo, no campo abaixo, o código do token que pertence a esse veículo.</p>
                            <form id="formConfirmarToken">
                                <div class="form-group">
                                    <label for="txtIDToken">Código do Token</label>
                                    <input id="txtIDToken" class="form-control" type="text" runat="server" clientidmode="static"/>
                                </div>
                            </form>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnConfirmarToken" CssClass="btn btn-success" runat="server" Text="Confirmar" ToolTip="Confirmar Token" OnClick="btnConfirmarToken_Click" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConfirmarToken" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <!--- Cadastrar Veículo Section -->
    <section class="container-fluid">
        <section class="row justify-content-center">
            <section class="col-sm-6 pt-3 pb-3">
                <%-- Breadcrumb --%>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="./dashboard.aspx">Painel</a></li>
                        <li class="breadcrumb-item"><a href="./gerenciar-veiculos.aspx">Veículos</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Cadastrar Veículo</li>
                    </ol>
                </nav>

                <%-- Alerta de sucesso --%>
                <div id="alertaSucesso" class="alert alert-success collapse" role="alert">
                    <span id="txtAlertaSucesso"></span>
                </div>

                <h4><i class="fas fa-car"></i> Cadastrar Veículo</h4>
                <hr>

                <div class="form-container">
                    <div class="form-group">
                        <label for="BodyContent_inputProprietario">Proprietário do Veículo</label>
                        <input runat="server" type="text" class="form-control" id="inputProprietario" placeholder="Nome do Proprietário do Veículo" disabled>

                        <div class="form-check pt-2">
                            <input runat="server" class="form-check-input" type="radio" name="rdbPropVeiculo" id="rdbPropVeiculoSim" value="1" checked>
                            <label class="form-check-label" runat="server" for="BodyContent_rdbPropVeiculoSim">
                                Este veículo está em meu nome
                            </label>
                        </div>
                        <div class="form-check">
                            <input runat="server" class="form-check-input" type="radio" name="rdbPropVeiculo" id="rdbPropVeiculoNao" value="0">
                            <label class="form-check-label" runat="server" for="BodyContent_rdbPropVeiculoNao">
                                Este veículo <strong>não</strong> está em meu nome
                            </label>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <label for="BodyContent_inputPlaca">Placa</label>
                            <asp:UpdatePanel ID="updatePanelPlaca" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="inputPlaca" runat="server" AutoPostBack="true" OnTextChanged="inputPlaca_Changed" type="text" class="form-control" placeholder="Placa do Veículo" title="Insira a placa sem espaços ou traços" pattern="[A-Za-z]{3}[0-9][0-9A-Za-z][0-9]{2}" maxlength="7" autocomplete="off"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="invalid-feedback">
                                A placa inserida não é válida!
                            </div>
                        </div>
                        <div class="form-group col-md-4">
                            <label for="BodyContent_inputMarca">Marca</label>
                            <input runat="server" type="text" class="form-control" id="inputMarca" placeholder="Marca do Veículo" autocomplete="off">
                        </div>
                        <div class="form-group col-md-4">
                            <label for="BodyContent_inputModelo">Modelo</label>
                            <input runat="server" type="text" class="form-control" id="inputModelo" placeholder="Modelo do Veículo" autocomplete="off">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <label for="BodyContent_inputCor">Cor</label>
                            <input runat="server" type="text" class="form-control" id="inputCor" placeholder="Cor do Veículo" autocomplete="off">
                        </div>
                        <div class="form-group col-5 col-md-3">
                            <label for="BodyContent_inputUF">UF</label>
                            <asp:DropDownList ID="inputUF" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="inputUF_Changed" autocomplete="off"></asp:DropDownList>
                            <div class="invalid-feedback">
                                Por favor, selecione uma Região da lista!
                            </div>
                        </div>
                        <div class="form-group col-7 col-md-5">
                            <label for="BodyContent_inputCidade">Cidade</label>
                            <asp:DropDownList ID="inputCidade" runat="server" class="form-control" autocomplete="off"></asp:DropDownList>
                            <div class="invalid-feedback">
                                Por favor, selecione uma Cidade da lista!
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="form-check">
                            <input runat="server" class="form-check-input" type="checkbox" id="checkSeguro">
                            <label class="form-check-label" for="BodyContent_checkSeguro">
                                Este veículo possui seguro
                            </label>
                        </div>
                    </div>

                    <%-- Alerta de erro --%>
                    <div id="alertaErro" class="alert alert-danger alert-dismissible collapse" role="alert">
                        <span id="txtAlertaErro"></span>
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
            /* Popula o campo 'Proprietario do Veiculo' com o nome do usuario logado
             * variavel 
             */
            var nomeProp = '<%= userNome %>';

            if ($("#BodyContent_rdbPropVeiculoSim").is(':checked')) {
                $("#BodyContent_inputProprietario").val(nomeProp);
            } else {
                $("#BodyContent_inputProprietario").prop("disabled", false);
            }

            /* Preenche ou limpa o campo 'Proprietario do Veiculo'
            de acordo com o Radio Button selecionado
            */
            $("#BodyContent_rdbPropVeiculoSim").change(function () {
                $("#BodyContent_inputProprietario").prop("disabled", true);
                $("#BodyContent_inputProprietario").val(nomeProp);
            });

            $("#BodyContent_rdbPropVeiculoNao").change(function () {
                $("#BodyContent_inputProprietario").prop("disabled", false);
                $("#BodyContent_inputProprietario").val("");
            });

            // Impede caracteres especiais no campo 'Placa'
            $('#BodyContent_inputPlaca').keypress(function (e) {
                // caracteres permitidos: letras e numeros, backspace/delete
                const regex = RegExp('[0-9a-zA-Z]');
                if (!regex.test(e.key) && e.key != 'backspace') {
                    e.preventDefault();
                }
            });
        });
    </script>
</asp:Content>
