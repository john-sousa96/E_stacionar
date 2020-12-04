<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="403.aspx.cs" Inherits="WebEstacionamento._403" %>

<!DOCTYPE html>

<html lang="pt-br" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Acesso negado · Estacionamento </title>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
	<script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>
	<link href="./css/style.css" rel="stylesheet">

	<!-- importação dos favicons multiplataforma -->
	<link rel="apple-touch-icon" sizes="180x180" href="/apple-touch-icon.png">
	<link rel="icon" type="image/png" sizes="32x32" href="/favicon-32x32.png">
	<link rel="icon" type="image/png" sizes="16x16" href="/favicon-16x16.png">
	<link rel="manifest" href="/site.webmanifest">
	<link rel="mask-icon" href="/safari-pinned-tab.svg" color="#0b3aaf">
	<meta name="msapplication-TileColor" content="#f5f5f5">
	<meta name="theme-color" content="#ffffff">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid text-center justify-content-center">
			<div class="container">
				<a href="./index.aspx"><img class="mt-2" src="./img/logo.png" height="100px" width="100px"></a>
				<h2>Você não tem permissão para acessar essa página!</h2>
				<img src="img/toll.png" class="img-fluid my-4" alt="ilustração proibido carro" title="ilustração proibido carro"/>
				<a href="./index.aspx"><button type="button" class="btn btn-primary btn-lg btn-block">Voltar a página inicial</button></a>
				<p class="mt-2"><small>Icons made by <a href="https://smashicons.com/" title="Smashicons">Smashicons</a> from <a href="https://www.flaticon.com/" title="Flaticon"> www.flaticon.com</a></small></p>
			</div>
        </div>
    </form>

	<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
	<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
</body>
</html>
