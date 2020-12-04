<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="WebEstacionamento.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">Painel · Estacionamento</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="./css/dashboard.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- Dashboard Content -->
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <!-- meta -->
                    <div class="profile-user-box card-box bg-custom">
                        <div class="row">
                            <div class="col-sm-6">
                                <span class="float-left mr-3">
                                    <div class="thumb-lg">
                                        <svg width="88" height="88" viewBox="0 0 16 16" class="bi bi-person-fill" fill="#FFC141" xmlns="http://www.w3.org/2000/svg">
                                            <path fill-rule="evenodd" d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6z"/>
                                        </svg>
                                    </div>
                                </span>
                                <div class="media-body text-white">
                                    <h4 class="mt-1 mb-1 font-18"><asp:Literal ID="header_nome" runat="server"></asp:Literal></h4>
                                    <p class="font-13 text-light"><asp:Literal ID="header_cargo" runat="server"></asp:Literal></p>
                                    <p class="text-light mb-0"><asp:Literal ID="header_empresa" runat="server"></asp:Literal></p>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="text-right">
                                    <a class="btn btn-light waves-effect" href="./account-settings.aspx" role="button">Editar Perfil</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--/ meta -->
                </div>
            </div>
            <!-- end row -->
            <div class="row">
                <div class="col">
                    <div class="row">
                        <div id="card_reservas" runat="server" class="col-sm-4" title="Gerenciar reservas">
                            <div class="card-box tilebox-one"><i class="icon-layers float-right text-muted"></i>
                                <h6 class="text-muted text-uppercase mt-0">
                                    <svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-receipt" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                            <path fill-rule="evenodd" d="M1.92.506a.5.5 0 0 1 .434.14L3 1.293l.646-.647a.5.5 0 0 1 .708 0L5 1.293l.646-.647a.5.5 0 0 1 .708 0L7 1.293l.646-.647a.5.5 0 0 1 .708 0L9 1.293l.646-.647a.5.5 0 0 1 .708 0l.646.647.646-.647a.5.5 0 0 1 .708 0l.646.647.646-.647a.5.5 0 0 1 .801.13l.5 1A.5.5 0 0 1 15 2v12a.5.5 0 0 1-.053.224l-.5 1a.5.5 0 0 1-.8.13L13 14.707l-.646.647a.5.5 0 0 1-.708 0L11 14.707l-.646.647a.5.5 0 0 1-.708 0L9 14.707l-.646.647a.5.5 0 0 1-.708 0L7 14.707l-.646.647a.5.5 0 0 1-.708 0L5 14.707l-.646.647a.5.5 0 0 1-.708 0L3 14.707l-.646.647a.5.5 0 0 1-.801-.13l-.5-1A.5.5 0 0 1 1 14V2a.5.5 0 0 1 .053-.224l.5-1a.5.5 0 0 1 .367-.27zm.217 1.338L2 2.118v11.764l.137.274.51-.51a.5.5 0 0 1 .707 0l.646.647.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.509.509.137-.274V2.118l-.137-.274-.51.51a.5.5 0 0 1-.707 0L12 1.707l-.646.647a.5.5 0 0 1-.708 0L10 1.707l-.646.647a.5.5 0 0 1-.708 0L8 1.707l-.646.647a.5.5 0 0 1-.708 0L6 1.707l-.646.647a.5.5 0 0 1-.708 0L4 1.707l-.646.647a.5.5 0 0 1-.708 0l-.509-.51z"/>
                                            <path fill-rule="evenodd" d="M3 4.5a.5.5 0 0 1 .5-.5h6a.5.5 0 1 1 0 1h-6a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 1 1 0 1h-6a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 1 1 0 1h-6a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 0 1 0 1h-6a.5.5 0 0 1-.5-.5zm8-6a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5z"/>
                                    </svg> Reservas</h6>
                                <h2><asp:Literal ID="numReservas" runat="server"></asp:Literal></h2><span class="badge badge-custom">+11% </span><span class="text-muted">From previous period</span>
                                <a href="./gerenciar-reservas.aspx" class="stretched-link"></a>
                            </div>
                        </div>
                        <div id="card_vagas" runat="server" class="col-sm-4" title="Gerenciar vagas">
                            <div class="card-box tilebox-one"><i class="icon-rocket float-right text-muted"></i>
                                <h6 class="text-muted text-uppercase mt-0">
                                    <svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-file-fill" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                        <path fill-rule="evenodd" d="M4 0h8a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H4a2 2 0 0 1-2-2V2a2 2 0 0 1 2-2z"/>
                                    </svg> Vagas</h6>
                                <h2><asp:Literal ID="numVagas" runat="server"></asp:Literal></h2><span class="badge badge-custom">+89% </span><span class="text-muted">Last year</span>
                                <a href="./gerenciar-vagas.aspx" class="stretched-link"></a> <!-- página não criada -->
                            </div>
                        </div>
                        <div id="card_veiculos" runat="server" class="col-sm-4" title="Gerenciar veículos">
                            <div class="card-box tilebox-one"><i class="icon-paypal float-right text-muted"></i>
                                <h6 class="text-muted text-uppercase mt-0">
                                    <i class="fas fa-car"></i> Veículos</h6>
                                <h2><asp:Literal ID="numVeiculos" runat="server"></asp:Literal></h2><span class="badge badge-danger">-29% </span><span class="text-muted">From previous period</span>
                                <a href="./gerenciar-veiculos.aspx" class="stretched-link"></a>
                            </div>
                        </div>
                        <div id="card_estacionamentos" runat="server" class="col-sm-4" title="Gerenciar estacionamentos">
                            <div class="card-box tilebox-one"><i class="icon-rocket float-right text-muted"></i>
                                <h6 class="text-muted text-uppercase mt-0">
                                    <i class="fas fa-parking"></i> Estacionamentos</h6>
                                <h2><asp:Literal ID="numEstacionamentos" runat="server"></asp:Literal></h2><span class="badge badge-custom">+89% </span><span class="text-muted">Last year</span>
                                <a href="./gerenciar-estacionamentos.aspx" class="stretched-link"></a>
                            </div>
                        </div>
                        <div id="card_funcionarios" runat="server" class="col-sm-4" title="Gerenciar funcionários">
                            <div class="card-box tilebox-one"><i class="icon-rocket float-right text-muted"></i>
                                <h6 class="text-muted text-uppercase mt-0">
                                    <i class="far fa-address-card"></i> Funcionários</h6>
                                <h2><asp:Literal ID="numFuncionarios" runat="server"></asp:Literal></h2><span class="badge badge-custom">+89% </span><span class="text-muted">Last year</span>
                                <a href="./gerenciar-funcionarios.aspx" class="stretched-link"></a>
                            </div>
                        </div>
                        <div id="card_equipamentos" runat="server" class="col-sm-4" title="Gerenciar equipamentos">
                            <div class="card-box tilebox-one"><i class="icon-rocket float-right text-muted"></i>
                                <h6 class="text-muted text-uppercase mt-0">
                                    <i class="fas fa-microchip"></i> Equipamentos</h6>
                                <h2><asp:Literal ID="numEquipamentos" runat="server"></asp:Literal></h2><span class="badge badge-custom">+89% </span><span class="text-muted">Last year</span>
                                <a href="./gerenciar-equipamentos.aspx" class="stretched-link"></a> <!-- página não criada -->
                            </div>
                        </div>
                        <div id="card_servicos" runat="server" class="col-sm-4" title="Gerenciar serviços">
                            <div class="card-box tilebox-one"><i class="icon-rocket float-right text-muted"></i>
                                <h6 class="text-muted text-uppercase mt-0">
                                    <i class="fas fa-dolly"></i> Serviços</h6>
                                <h2><asp:Literal ID="numServicos" runat="server"></asp:Literal></h2><span class="badge badge-custom">+89% </span><span class="text-muted">Last year</span>
                                <a href="./gerenciar-servicos.aspx" class="stretched-link"></a> <!-- página não criada -->
                            </div>
                        </div>
                        <div id="card_usuarios" runat="server" class="col-sm-4" title="Gerenciar usuários">
                            <div class="card-box tilebox-one"><i class="icon-rocket float-right text-muted"></i>
                                <h6 class="text-muted text-uppercase mt-0">
                                    <i class="fas fa-user-friends"></i> Usuários</h6>
                                <h2><asp:Literal ID="numUsuarios" runat="server"></asp:Literal></h2><span class="badge badge-custom">+89% </span><span class="text-muted">Last year</span>
                                <a href="./gerenciar-usuarios.aspx" class="stretched-link"></a> <!-- página não criada -->
                            </div>
                        </div>
                        <div id="card_empresas" runat="server" class="col-sm-4" title="Gerenciar empresas">
                            <div class="card-box tilebox-one"><i class="icon-rocket float-right text-muted"></i>
                                <h6 class="text-muted text-uppercase mt-0">
                                    <i class="far fa-building"></i> Empresas</h6>
                                <h2><asp:Literal ID="numEmpresas" runat="server"></asp:Literal></h2><span class="badge badge-custom">+89% </span><span class="text-muted">Last year</span>
                                <a href="./gerenciar-empresas.aspx" class="stretched-link"></a> <!-- página não criada -->
                            </div>
                        </div>
                        <div id="card_tokens" runat="server" class="col-sm-4" title="Gerenciar tokens">
                            <div class="card-box tilebox-one"><i class="icon-rocket float-right text-muted"></i>
                                <h6 class="text-muted text-uppercase mt-0">
                                    <i class="fas fa-ticket-alt"></i> Tokens</h6>
                                <h2><asp:Literal ID="numTokens" runat="server"></asp:Literal></h2><span class="badge badge-custom">+89% </span><span class="text-muted">Last year</span>
                                <a href="./gerenciar-tokens.aspx" class="stretched-link"></a> <!-- página não criada -->
                            </div>
                        </div>
                    </div>
                    <!-- end row -->
                </div>
                <!-- end col -->
            </div>
            <!-- end row -->
        </div>
        <!-- container -->
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PostBodyContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            // automatiza a classe active da navbar
            $('a.nav-link[href^="./' + location.pathname.split("/")[1] + '"]').addClass('active');

            // destacar cards

            // variavel do code-behind com o ID do elemento a ser destacado
            var elementID = '<%= elementID %>';

            if (elementID != '') {
                // cria um objeto jquery para o id do elemento recebido
                var element = $(elementID);
                // armazena a cor original do fundo
                var pastColor = $(element).children().css("background-color");

                // aplica transição do css ao elemento
                $(element).children().css(
                    "transition", "background-color 1.2s ease-in-out"
                );

                // essa funcao é um loop infinito sem estouro de pilha
                function destacar() {
                    setTimeout(function () {
                        $(element).children().css("background-color", pastColor);

                        setTimeout(function () {
                            // chama a funcao novamente
                            destacar();
                        }, 1200);
                    }, 1200);

                    // define a cor de fundo para um amarelo com 20% de opacidade
                    $(element).children().css("background-color", "rgba(255, 255, 0, .2)");
                }

                // chama a funcao para definir a cor de fundo do card
                destacar();
            }
        });
    </script>
</asp:Content>
