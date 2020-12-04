<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="cadastro-selecao.aspx.cs" Inherits="WebEstacionamento.cadastro_selecao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">Cadastro · Estacionamento</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="server">
    <!--- Selecao Tipo Cadastro Section -->
	<section class="container-fluid">
		<section class="row justify-content-center">
			<section class="col-12 col-sm-6 col-md-3 pt-3 pb-3">
				<a class="btn btn-primary btn-lg btn-block" href="./cadastro-usuario.aspx">Usuário</a>
				<a class="btn btn-secondary btn-lg btn-block" href="./cadastro-empresa.aspx">Empresa</a>
			</section>
		</section>
	</section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PostBodyContent" runat="server"></asp:Content>