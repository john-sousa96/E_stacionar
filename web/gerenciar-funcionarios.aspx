<%@ Page Title="" Language="C#" MasterPageFile="~/tabela.Master" AutoEventWireup="true" CodeBehind="gerenciar-funcionarios.aspx.cs" Inherits="WebEstacionamento.gerenciar_funcionarios" %>
<%@ MasterType VirtualPath="~/tabela.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Tabela_title" runat="server">Gerenciar Funcionários · Estacionamento</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Tabela_head" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Tabela_PreGrid" runat="server">
    <%-- Breadcrumb --%>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./dashboard.aspx">Painel</a></li>
            <li class="breadcrumb-item active" aria-current="page">Funcionários</li>
        </ol>
    </nav>

    <%-- Alerta de sucesso --%>
    <div id="alertaSucesso" class="alert alert-success collapse" role="alert">
        <span id="txtAlertaSucesso"></span>
    </div>

    <h4><i class="far fa-address-card"></i> Gerenciar Funcionários</h4>
    <hr>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Tabela_PostGrid" runat="server">
    <a id="btnAdicionar" class="btn btn-success" href="./cadastro-funcionario.aspx" role="button"><i class="fas fa-plus"></i> Adicionar</a>

    <div id="ModalConfirmarExclusao" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="ModalConfirmarExclusao" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Desativar Funcionário</h5>
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
                            <p>Deseja realmente desativar o funcionário selecionado?</p>
                        </div>
                        <div class="modal-footer">
                            <span id="loadingRemover" class="mr-2 text-danger" runat="server" clientidmode="static" hidden><i class="fas fa-spinner fa-spin"></i></span>
                            <asp:Button ID="btnDesativarFuncionario" CssClass="btn btn-danger" runat="server" Text="Desativar" ToolTip="Desativar Funcionário" OnClientClick="removerSelecao(this);" OnClick="btnDesativarFuncionario_Click" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnDesativarFuncionario" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Tabela_PostBodyContent" runat="server"></asp:Content>