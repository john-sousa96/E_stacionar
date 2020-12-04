<%@ Page Title="" Language="C#" MasterPageFile="~/tabela.Master" AutoEventWireup="true" CodeBehind="gerenciar-veiculos.aspx.cs" Inherits="WebEstacionamento.gerenciar_veiculos" %>
<%@ MasterType VirtualPath="~/tabela.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Tabela_title" runat="server">Gerenciar Veículos · Estacionamento</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Tabela_head" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Tabela_PreGrid" runat="server">
    <%-- Breadcrumb --%>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./dashboard.aspx">Painel</a></li>
            <li class="breadcrumb-item active" aria-current="page">Veículos</li>
        </ol>
    </nav>

    <%-- Alerta de sucesso --%>
    <div id="alertaSucesso" class="alert alert-success collapse" role="alert">
        <span id="txtAlertaSucesso"></span>
    </div>

    <h4><i class="fas fa-car"></i> Gerenciar Veículos</h4>
    <hr>
</asp:Content>

<%-- Entre esses dois placeholders estará o gridview da Child Master Page 'Tabela' --%>

<asp:Content ID="Content4" ContentPlaceHolderID="Tabela_PostGrid" runat="server">
    <a id="btnAdicionar" class="btn btn-success" href="./cadastro-veiculo.aspx" role="button"><i class="fas fa-plus"></i> Adicionar</a>

    <div id="ModalConfirmarExclusao" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="ModalConfirmarExclusao" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Desativar Veículo</h5>
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
                            <p>Deseja realmente desativar o veículo selecionado?</p>
                        </div>
                        <div class="modal-footer">
                            <span id="loadingRemover" class="mr-2 text-danger" runat="server" clientidmode="static" hidden><i class="fas fa-spinner fa-spin"></i></span>
                            <asp:Button ID="btnDesativarVeiculo" CssClass="btn btn-danger" runat="server" Text="Desativar" ToolTip="Desativar Veículo" OnClientClick="removerSelecao(this);" OnClick="btnDesativarVeiculo_Click" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnDesativarVeiculo" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Tabela_PostBodyContent" runat="server"></asp:Content>