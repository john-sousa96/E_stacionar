<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebEstacionamento.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">Estacionamento</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="./css/home.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="server">
	<!--- Welcome Section -->
	<div id="home">
		<div class="landing-text">
			<h1 class="display-2">E-STACIONAR</h1>
			<h3>SOLUÇÕES INFORMATIZADAS PARA ESTACIONAMENTOS</h3>
			<a href="./login.aspx"><button type="button" class="btn btn-primary btn-lg">Login</button></a>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PostBodyContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			// automatiza a classe active da navbar
            $('a.nav-link[href^="./' + location.pathname.split("/")[1] + '"]').addClass('active');
        });
	</script>
</asp:Content>