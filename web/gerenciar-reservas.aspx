<%@ Page Title="" Language="C#" MasterPageFile="~/tabela.Master" AutoEventWireup="true" CodeBehind="gerenciar-reservas.aspx.cs" Inherits="WebEstacionamento.gerenciar_reservas" %>
<%@ MasterType VirtualPath="~/tabela.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Tabela_title" runat="server">Gerenciar Reservas · Estacionamento</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Tabela_head" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Tabela_PreGrid" runat="server">
    <%-- Breadcrumb --%>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./dashboard.aspx">Painel</a></li>
            <li class="breadcrumb-item active" aria-current="page">Reservas</li>
        </ol>
    </nav>

    <%-- Alerta de sucesso --%>
    <div id="alertaSucesso" class="alert alert-success collapse" role="alert">
        <span id="txtAlertaSucesso"></span>
    </div>

    <h4>
        <svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-receipt" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
            <path fill-rule="evenodd" d="M1.92.506a.5.5 0 0 1 .434.14L3 1.293l.646-.647a.5.5 0 0 1 .708 0L5 1.293l.646-.647a.5.5 0 0 1 .708 0L7 1.293l.646-.647a.5.5 0 0 1 .708 0L9 1.293l.646-.647a.5.5 0 0 1 .708 0l.646.647.646-.647a.5.5 0 0 1 .708 0l.646.647.646-.647a.5.5 0 0 1 .801.13l.5 1A.5.5 0 0 1 15 2v12a.5.5 0 0 1-.053.224l-.5 1a.5.5 0 0 1-.8.13L13 14.707l-.646.647a.5.5 0 0 1-.708 0L11 14.707l-.646.647a.5.5 0 0 1-.708 0L9 14.707l-.646.647a.5.5 0 0 1-.708 0L7 14.707l-.646.647a.5.5 0 0 1-.708 0L5 14.707l-.646.647a.5.5 0 0 1-.708 0L3 14.707l-.646.647a.5.5 0 0 1-.801-.13l-.5-1A.5.5 0 0 1 1 14V2a.5.5 0 0 1 .053-.224l.5-1a.5.5 0 0 1 .367-.27zm.217 1.338L2 2.118v11.764l.137.274.51-.51a.5.5 0 0 1 .707 0l.646.647.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.509.509.137-.274V2.118l-.137-.274-.51.51a.5.5 0 0 1-.707 0L12 1.707l-.646.647a.5.5 0 0 1-.708 0L10 1.707l-.646.647a.5.5 0 0 1-.708 0L8 1.707l-.646.647a.5.5 0 0 1-.708 0L6 1.707l-.646.647a.5.5 0 0 1-.708 0L4 1.707l-.646.647a.5.5 0 0 1-.708 0l-.509-.51z"/>
            <path fill-rule="evenodd" d="M3 4.5a.5.5 0 0 1 .5-.5h6a.5.5 0 1 1 0 1h-6a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 1 1 0 1h-6a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 1 1 0 1h-6a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 0 1 0 1h-6a.5.5 0 0 1-.5-.5zm8-6a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5z"/>
        </svg> Gerenciar Reservas
    </h4>
    <hr>
</asp:Content>

<%-- Entre esses dois placeholders estará o gridview da Child Master Page 'Tabela' --%>

<asp:Content ID="Content4" ContentPlaceHolderID="Tabela_PostGrid" runat="server">
    <a id="btnAdicionar" class="btn btn-success" href="./reservar-vaga.aspx" role="button"><i class="fas fa-plus"></i> Nova Reserva</a>

    <div id="ModalConfirmarExclusao" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="ModalConfirmarExclusao" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Cancelar Reserva</h5>
                    <button type="button" class="close" title="Fechar" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <asp:UpdatePanel ID="upDeletar" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <form id="formDeletarSelecionado">
                                <div class="d-none form-group row my-2">
                                    <label for="idSelecionado" class="col-3 col-form-label">ID Selecionado</label>
                                    <div class="col-9">
                                        <input id="txtIdSelecionado" class="form-control" type="text" runat="server" clientidmode="static" readonly />
                                    </div>
                                </div>
                            </form>
                            <p>Deseja realmente cancelar a reserva selecionada?</p>
                        </div>
                        <div class="modal-footer">
                            <span id="loadingRemover" class="mr-2 text-danger" runat="server" clientidmode="static" hidden><i class="fas fa-spinner fa-spin"></i></span>
                            <asp:Button ID="btnCancelarReserva" CssClass="btn btn-danger" runat="server" Text="Cancelar" ToolTip="Cancelar Reserva" OnClientClick="removerSelecao(this);" OnClick="btnCancelarReserva_Click" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnCancelarReserva" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Tabela_PostBodyContent" runat="server"></asp:Content>