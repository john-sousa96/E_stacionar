var endereco;
var map;
var marker;
var icon;
var position;
var geocoder;

function initMap(address, coord) {
    // essa função recebe um endereço formatado ou uma lista de coordenadas (lat e lng)

    // Personalização do mapa
    const styles = [
        {
            featureType: 'poi',
            stylers: [{ visibility: 'off' }]
        }
    ]

    // Instancia o mapa
    map = new google.maps.Map(document.getElementById('mapa'), {
        zoom: 17,
        zoomControl: true,
        disableDefaultUI: true,
        styles: styles
    });

    // Imagem do marcador
    icon = {
        url: 'img/logo.png',
        scaledSize: new google.maps.Size(50, 50)
    };

    // define se o mapa carregará com o endereço do CEP ou
    // com as coordenadas capturadas do textbox 
    if (coord === null) {
        dataToDecode = { 'address': address };
    } else {
        dataToDecode = {
            'location': {
                lat: parseFloat(coord[0]),
                lng: parseFloat(coord[1]),
            }
        };
    }

    geocoder = new google.maps.Geocoder();

    geocoder.geocode(dataToDecode, function (results, status) {
        if (status == 'OK') {
            // armazena as coordenadas do endereço presente no formulário
            position = results[0].geometry.location;

            // centraliza o mapa na nova coordenada
            map.setCenter(position);

            // adiciona o novo marcador
            marker = new google.maps.Marker({
                map: map,
                position: position,
                icon: icon,
                animation: google.maps.Animation.DROP,
                draggable: true,
                title: "Clique e arraste para reposicionar o marcador!"
            });

            // preenche as coordenadas nos textbox
            $("#BodyContent_inputLat").val(position.lat());
            $("#BodyContent_inputLng").val(position.lng());

            // Marker Clicked Event
            marker.addListener('click', function (e) {
                console.log(e.latLng)
            });

            // evento disparado após o usuario soltar o marcador numa nova posição
            marker.addListener('dragend', function (e) {
                // armazena nova posição do marcador
                position = e.latLng;
                // preenche as coordenadas nos textbox
                $("#BodyContent_inputLat").val(position.lat());
                $("#BodyContent_inputLng").val(position.lng());
            })
        } else {
            alert('Geocode error: ' + status);
        }
    });
}

function AtualizarMapa() {
    // função executada quando o usuario clica no botão para abrir o mapa

    // se o CEP estiver vazio ou for inválido mostra um alerta para o usuario
    if ($("#BodyContent_inputCEP").val().length === 0 || $('#BodyContent_inputCEP').is(':invalid')) {
        ValidarCampo('#BodyContent_inputCEP', false);
        AlertarCamposInvalidos("Para visualizar o mapa digite um CEP válido primeiro!");
        $("#BodyContent_inputCEP").focus();
    } else {
        // caso o CEP seja válido concatena os elementos do endereço
        endereco = $('#BodyContent_inputNumero').val() + ", " + $('#BodyContent_inputLogradouro').val(); +
            ", " + $('#BodyContent_inputCidade').val() + ", " + $('#BodyContent_inputEstado').val()

        // altera o texto do botão de 'Abrir Mapa' para 'Atualizar Mapa'
        $('#btnAtualizarMapa').html('Atualizar Mapa');
        
        // se os campos Latitude e Longitude já possuírem valores,
        // carrega o mapa com as coordenadas; caso contrário,
        // carrega o mapa com a posição do endereço
        if ($("#BodyContent_inputLat").val().length === 0 || $('#BodyContent_inputLng').val().length === 0) {
            // passa o argumento das coordenadas como null
            initMap(endereco, null);
        } else {
            // passa as coordenadas como lista
            initMap(endereco, [
                $("#BodyContent_inputLat").val(),
                $('#BodyContent_inputLng').val()]
            );
        }

        // mostra a div contendo o mapa somente se ele não estiver visível
        if ($('#mapa_container').is(':hidden')) {
            $('#mapa_container').show('fade', function () {
                setTimeout(function () {
                    // realiza uma rolagem suave na página até o mapa 
                    document.querySelector("#BodyContent_inputRamal").scrollIntoView({
                        behavior: 'smooth'
                    });
                }, 50);
            });
        }
    }
}