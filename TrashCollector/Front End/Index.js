var map, infoWindow;

function createMap() {
    var options = {
        center: { lat: 43.038902, lng: -87.906471 },
        zoom: 12
    };
            //start map
    map = new google.maps.Map(document.getElementById('map'), options);


    infoWindow = new google.maps.InfoWindow;

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (p) {
            var position = {
                lat: p.coords.latitude,
                lng: p.coords.longitude
            };
            infoWindow.setPosition(position);
            infoWindow.setContent('Your location!');
            infoWindow.open(map);
        }, function () {
           handleLocationError('Geolocation service failed', map.center());
        })
    } else {
        handleLocationError('no geolocation available', map.center());
    }
}

function handleLocationError(content, position) {
    infoWindow.setPosition(position);
    infoWindow.setContent(content);
    infoWindow.open(map);
}
