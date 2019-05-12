var map;

function createMap() {
    var options = {
        center: { lat: 43.038902, lng: -87.906471 },
        zoom: 12
    };

    map = new google.maps.Map(document.getElementById('map'), options);
}