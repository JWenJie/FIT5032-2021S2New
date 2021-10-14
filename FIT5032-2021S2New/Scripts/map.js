let stores;

let xmlHttp = new XMLHttpRequest();
xmlHttp.open("GET", "Stores/GetStores", false);
xmlHttp.send(null);
stores = JSON.parse(xmlHttp.responseText);
console.log(stores);


let map;

function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: -34.397, lng: 150.644 },
        zoom: 10,
    });

    // get current location
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(
            position => {
                const pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude
                };
                map.setCenter(pos);
            },
            () => {
                handleLocationError(false, infoWindow, map.getCenter());
            }
        );
    } else {
        handleLocationError(false, infoWindow, map.getCenter());
    }   

    //Mark locations

    for (var i = 0; i < stores.length; i++) {
        console.log(stores[i]);
        geodoceAddress(map, stores[i]);
    }
}

function geodoceAddress(map, store) {
    var geocoder = new google.maps.Geocoder();
    var content = "<h3>" + store.Name + "</h3>";
    const infowindow = new google.maps.InfoWindow({
        content: content,
    });
    geocoder.geocode({ address: store.Address }, function (result, status) {
        if (status === "OK") {
            var marker = new google.maps.Marker({
                map: map,
                position: result[0].geometry.location
            });
        }
        marker.addEventListener("click", function () { infowindow.open(map, marker) });
    });
}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(
        browserHasGeolocation
            ? "Error: The Geolocation service failed."
            : "Error: Your browser doesn't support geolocation."
    );
    infoWindow.open(map);
}