<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="reservar-vaga.aspx.cs" Inherits="WebEstacionamento.reservar_vaga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">Vagas · Estacionamento</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="./css/maps.css" rel="stylesheet">

    <script type="text/javascript">
        // função chamada pelo code behind; exibe o alerta de sucesso
        var AlertarSucesso = function (mensagem) {
            $('#txtAlertaSucesso').html(mensagem);
            $('#alertaSucesso').show('fade');
            setTimeout(function () {
                window.scrollTo(0, 0);
            }, 1);
        };

        // função chamada pelo code behind; exibe o alerta de erro
        var AlertarErro = function (mensagem) {
            $('#txtAlertaErro').html(mensagem);
            $('#alertaErro').show('fade');
        };
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="server">
    <%-- Script Manager responsável pelo envio das informações da função js para o método no Code Behind --%>
    <asp:ScriptManager ID="smGetDados" runat="server" EnablePageMethods="true" />

    <!-- Modal para informar os serviços da vaga selecionada -->
    <div class="modal fade" id="ModalServicos" tabindex="-1" aria-labelledby="ModalServicos" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Serviços</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p id="modal_est_infos" class="text-muted"></p>
                    <p id="modal_vaga_nome"></p>
                    <ul id="modal_vaga_descr"></ul>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal de confirmação dos dados da reserva -->
    <div class="modal fade" id="ModalConfirmarReserva" tabindex="-1" aria-labelledby="ModalConfirmarReserva" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Confirme sua reserva</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <h6>Estacionamento</h6>
                    <p id="modal_conf_est_infos"></p>
                    <hr />
                    <h6>Vaga</h6>
                    <p id="modal_conf_vaga_nome"></p>
                    <hr />
                    <h6>Data e Hora de Chegada</h6>
                    <p id="modal_conf_dataInicio"></p>
                    <hr />
                    <h6>Data e Hora de Saída</h6>
                    <p id="modal_conf_dataFinal"></p>
                    <hr />
                    <h6>Veículo</h6>
                    <p id="modal_conf_vaiculo"></p>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnConfirmarReserva" CssClass="btn btn-success" runat="server" Text="Confirmar" ToolTip="Confirmar reserva" OnClick="btnConfirmarReserva_Click" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <section class="container pt-3 pb-3">
        <%-- Breadcrumb --%>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="./dashboard.aspx">Painel</a></li>
                <li class="breadcrumb-item"><a href="./gerenciar-reservas.aspx">Reservas</a></li>
                <li class="breadcrumb-item active" aria-current="page">Fazer reserva</li>
            </ol>
        </nav>

        <%-- Alerta de sucesso --%>
        <div id="alertaSucesso" class="alert alert-success collapse" role="alert">
            <span id="txtAlertaSucesso"></span>
        </div>

        <h4 class="mb-3">
            <svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-receipt" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                <path fill-rule="evenodd" d="M1.92.506a.5.5 0 0 1 .434.14L3 1.293l.646-.647a.5.5 0 0 1 .708 0L5 1.293l.646-.647a.5.5 0 0 1 .708 0L7 1.293l.646-.647a.5.5 0 0 1 .708 0L9 1.293l.646-.647a.5.5 0 0 1 .708 0l.646.647.646-.647a.5.5 0 0 1 .708 0l.646.647.646-.647a.5.5 0 0 1 .801.13l.5 1A.5.5 0 0 1 15 2v12a.5.5 0 0 1-.053.224l-.5 1a.5.5 0 0 1-.8.13L13 14.707l-.646.647a.5.5 0 0 1-.708 0L11 14.707l-.646.647a.5.5 0 0 1-.708 0L9 14.707l-.646.647a.5.5 0 0 1-.708 0L7 14.707l-.646.647a.5.5 0 0 1-.708 0L5 14.707l-.646.647a.5.5 0 0 1-.708 0L3 14.707l-.646.647a.5.5 0 0 1-.801-.13l-.5-1A.5.5 0 0 1 1 14V2a.5.5 0 0 1 .053-.224l.5-1a.5.5 0 0 1 .367-.27zm.217 1.338L2 2.118v11.764l.137.274.51-.51a.5.5 0 0 1 .707 0l.646.647.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.509.509.137-.274V2.118l-.137-.274-.51.51a.5.5 0 0 1-.707 0L12 1.707l-.646.647a.5.5 0 0 1-.708 0L10 1.707l-.646.647a.5.5 0 0 1-.708 0L8 1.707l-.646.647a.5.5 0 0 1-.708 0L6 1.707l-.646.647a.5.5 0 0 1-.708 0L4 1.707l-.646.647a.5.5 0 0 1-.708 0l-.509-.51z"/>
                <path fill-rule="evenodd" d="M3 4.5a.5.5 0 0 1 .5-.5h6a.5.5 0 1 1 0 1h-6a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 1 1 0 1h-6a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 1 1 0 1h-6a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 0 1 0 1h-6a.5.5 0 0 1-.5-.5zm8-6a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5z"/>
            </svg> Fazer reserva</h4>
        <hr>

        <section class="row m-0 p-0">
            <div id="mapa" class="col-sm-6"></div>
            <div id="details" class="col-sm-6 pt-3 pt-sm-0">
                <h5>Informações</h5>
                <p id="est_infos">
                    Selecione um estacionamento no mapa
                </p>
                <h5>Vagas Disponíveis</h5>
                <div class="row pb-2">
                    <div class="col-10">
                        <p id="vagas_ocupadas_text" class="vagas-text m-0">
                            <i class="fas fa-circle" style="color: rgba(0,255,0,0.4);"></i>
                            Vagas Livres:
                        </p>
                    </div>
                    <div class="col-2">
                        <p id="vagas_ocupadas_valor" class="vagas-text text-center font-weight-bold m-0">0</p>
                    </div>
                </div>
                <div class="row pb-2">
                    <div class="col-10">
                        <p id="vagas_livres_text" class="vagas-text m-0">
                            <i class="fas fa-circle" style="color: rgba(255,0,0,0.4);"></i>
                            Vagas Ocupadas:
                        </p>
                    </div>
                    <div class="col-2">
                        <p id="vagas_livres_valor" class="vagas-text text-center font-weight-bold m-0">0</p>
                    </div>
                </div>

                <hr class="my-2">

                <asp:UpdatePanel ID="upPanelVaga" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <label for="BodyContent_inputVaga">Vaga desejada</label>
                            <asp:DropDownList ID="inputVaga" runat="server" class="custom-select" autocomplete="off" required>
                                <asp:ListItem Text="Selecione uma vaga..." Value="0" />
                            </asp:DropDownList>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <p>
                    <a id="btnAbrirModal" href="#">Ver serviços da vaga</a>
                </p>

                <div class="form-group">
                    <label for="BodyContent_datepicker_inicial">Hora e Data de Chegada</label>
                    <input id="datepicker_inicial" runat="server" type="datetime-local" class="form-control">
                </div>

                <div class="form-group">
                    <label for="BodyContent_datepicker_final">Hora e Data de Saída</label>
                    <input id="datepicker_final" runat="server" type="datetime-local" class="form-control">
                </div>

                <div class="form-group">
                    <label for="BodyContent_inputVeiculo">Veículo</label>
                    <asp:DropDownList ID="inputVeiculo" runat="server" class="custom-select" data-toggle="tooltip" autocomplete="off" required></asp:DropDownList>
                    <div class="invalid-feedback">Selecione um veículo...</div>
                </div>

                <%-- Alerta de erro --%>
                <div id="alertaCamposInvalidos" class="alert alert-danger alert-dismissible collapse" role="alert">
                    <span id="txtAlertaCamposInvalidos"></span>
                    <button id="alertClose" type="button" class="close" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <asp:Button ID="btnReservar" CssClass="btn btn-primary btn-block" runat="server" Text="Reservar Vaga" ToolTip="Reservar Vaga" OnClick="btnReservar_Click" />
            </div>
        </section>
    </section>
    <script src="js/main.js"></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PostBodyContent" runat="server">
    <script type="text/javascript">
        // função executada ao abrir o modal de serviços
        $('#ModalServicos').on('show.bs.modal', function (event) {
            var est_infos = $("#est_infos").clone();
            var vaga = $("#BodyContent_inputVaga option:selected").text();
            // altera o conteudo do modal
            var modal = $(this)
            modal.find('#modal_est_infos').text("")
            modal.find('#modal_est_infos').html(est_infos)
            modal.find('#modal_vaga_nome').text("Vaga ").append(`<b>${vaga}</b>`)
        })

        // permite a abertura do modal de serviços somente com uma vaga selecionada
        $("#btnAbrirModal").click(function () {
            var aviso = "<p id='aviso-servico' class='text-danger'>Selecione uma vaga para visualizar os serviços</p>"
            $("#aviso-servico").remove();
            if ($("#BodyContent_inputVaga option:selected").val() == "0") {
                $("#btnAbrirModal").parent().after(aviso);
            }
            else {
                $('#ModalServicos').modal('show');
            }
        });

        // evento disparado toda vez que o valor do dropdown de vagas for alterado
        $("#BodyContent_inputVaga").change(function () {
            var id = $(this).val();
            var servicos = [];

            $("#aviso-servico").remove();
            ValidarCampo("#BodyContent_inputVaga", true);

            $.each(JSON.parse(json_servicos), function (key, servico) {
                if (id == servico.id_vaga) {
                    // guardar no array cada serviço da vaga selecionada
                    servicos.push(`${servico.desc_servico} | R$ ${servico.valor_servico}`);
                }
            });

            // ordena o array por ordem alfabetica
            servicos = servicos.sort();

            // adiciona cada serviço da vaga numa <li> dentro do <ul> do ModalServicos
            $("#modal_vaga_descr").text("");
            for (var i = 0; i < servicos.length; i++) {
                $("#modal_vaga_descr").append(
                    $("<li></li>").text(servicos[i])
                );
            }

        });

        // valida se todos os dados foram fornecidos para abrir o modal de confirmação de reserva
        $("#btnReservar").click(function (e) {
            var errorsCount = 0;
            var msgText = "";

            /* Cada validação abaixo somará 1 (um) à variável 'errorsCount' e adicionará um texto de erro à variável 'msgText';
             * Ao final enviará a mensagem completa com todos os problemas a serem resolvidos;
             */

            if ($("#BodyContent_inputVaga option:selected").text() == "Selecione uma vaga..." || $("#BodyContent_inputVaga option:selected").text() == "" || $("#BodyContent_inputVaga option:selecte").val() == "0") {
                ValidarCampo("#BodyContent_inputVaga", false);
                msgText = "<p>&#149; Por favor, selecione uma <mark>Vaga</mark> na lista.</p>";
                errorsCount += 1;
            }

            if ($("#BodyContent_datepicker_inicial").val() == "") {
                ValidarCampo("#BodyContent_datepicker_inicial", false);
                msgText += "<p>&#149; Por favor, insira <mark>Data e Hora de Chegada</mark> no padrão (dd/mm/aaaa hh:mm).</p>";
                errorsCount += 1;
            }

            if ($("#BodyContent_datepicker_final").val() == "") {
                ValidarCampo("#BodyContent_datepicker_final", false);
                msgText += "<p>&#149; Por favor, insira <mark>Data e Hora de Saída</mark> no padrão (dd/mm/aaaa hh:mm).</p>";
                errorsCount += 1;
            }

            if ($("#BodyContent_inputVeiculo").text() == "Selecione uma vaga..." || $("#BodyContent_inputVeiculo").text() == "" || $("#BodyContent_inputVeiculo").val() == 0) {
                ValidarCampo("#BodyContent_inputVeiculo", false);
                msgText += "<p>&#149; Por favor, selecione um <mark>Veículo</mark> na lista.</p>";
                errorsCount += 1;
            }

            // se a soma de erros for maior que zero enviará a mensagem ao usuario atraves da div alert do Bootstrap
            if (errorsCount > 0) {
                console.log(msgText);
                AlertarCamposInvalidos(msgText);
            }
            else {
                ValidarCampo("#BodyContent_inputVaga", true);
                ValidarCampo("#BodyContent_datepicker_inicial", true);
                ValidarCampo("#BodyContent_datepicker_final", true);
                ValidarCampo("#BodyContent_inputVeiculo", true);

                $('#ModalConfirmarReserva').modal('show');
            }
        });
    </script>

    <script type="text/javascript">
        // recebe os json da propriedade asp
        var json_est = '<%=Estacionamentos%>';
        var json_vagas = '<%=VagasLivres%>';
        var json_servicos = '<%=ServicosVagas%>';
        var map;
        var est_infos;
        //var contentInfoView;

        function initMap() {
            // Personalização do mapa
            const styles = [
                {
                    featureType: 'poi',
                    stylers: [{ visibility: 'off' }]
                }
            ]

            /*
            var infowindow = new google.maps.InfoWindow({
                content: contentInfoView,
            });
            */

            // Instancia o mapa
            map = new google.maps.Map(document.getElementById('mapa'), {
                center: { lat: -23.529593, lng: -46.632651 },
                zoom: 12,
                zoomControl: true,
                disableDefaultUI: true,
                styles: styles
            });

            // Imagem dos marcadores
            const icon = {
                url: 'img/logo.png',
                scaledSize: new google.maps.Size(50, 50)
            };

            var estacionamentos = JSON.parse(json_est);
            var vagas = JSON.parse(json_vagas);

            $.each(estacionamentos, function (key, data) {
                // concatena as coordenadas
                var latLng = new google.maps.LatLng(data.lat_est, data.lng_est);

                // Cria o marcador
                var marker = new google.maps.Marker({
                    position: latLng,
                    icon: icon,
                    map: map,
                });

                setInfoWindow();

                // Evento que ocorrerá sempre que um marcador for clicado
                function setInfoWindow() {
                    google.maps.event.addListener(marker, 'click', function (e) {
                        // concatena as informações do estacionamento selecionado no mapa
                        est_infos = `<b>${data.nome_empresa}</b><br>${data.logradouro_est}, ${data.numero_est}`;
                        contentInfoView = `${est_infos}<br>${data.complemento_est} - ${data.CEP_est}, ${data.cidade_est}/${data.estado_est}<br>Telefone: (${data.ddd_tel_est}) ${data.tel_est} R: ${data.ramal_est}`;

                        var iwindow = new google.maps.InfoWindow();
                        iwindow.setContent(contentInfoView);
                        iwindow.close();
                        marker.open = false;
                        iwindow.open(map, this);
                        marker.open = true;

                        // Preenche os elementos com os numeros de vagas livres/ocupadas
                        $("#est_infos").text("");
                        $("#est_infos").append(est_infos);
                        $("#vagas_ocupadas_valor").text(data.vagas_ocupadas);
                        $("#vagas_livres_valor").text(data.vagas_livres);

                        // preenche o dropdown com as vagas do estacionamento selecionado
                        var inputVaga = $("#BodyContent_inputVaga");
                        inputVaga.val("0");
                        inputVaga.text("");
                        inputVaga.append(
                            $("<option value='0'>Selecione uma vaga...</option>")
                        );
                        $.each(vagas, function (key, vaga) {
                            if (vaga.id_estacionamento == data.id_estacionamento) {
                                inputVaga.append(
                                    $("<option></option>").val(vaga.id_vaga).html(vaga.local_vaga)
                                );
                            }
                        });

                        // centraliza o mapa no marcador clicado
                        var coordenadas = e.latLng;
                        map.panTo(coordenadas);

                        // Chama o método ASP para popular os campos
                        PageMethods.GetDetails(coordenadas.lat(), coordenadas.lng());

                        google.maps.event.addListener(map, 'click', function () {
                            iwindow.close();
                            marker.open = false;
                        });
                    });
                }

            });
        }

    </script>
    <script defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDwHnltuFUPTC-F7Zq9CYze1sW8gndsIEY&callback=initMap"></script>
</asp:Content>