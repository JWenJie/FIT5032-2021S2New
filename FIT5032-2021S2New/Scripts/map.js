let stores;

let xmlHttp = new XMLHttpRequest();
xmlHttp.open("GET", "Stores/ListStores", false);
xmlHttp.send(null);
stores = JSON.parse(xmlHttp.responseText);
console.log(stores);


let map;
const labels = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
let labelIndex = 0;

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

    //auto complete for start function
    var start = document.getElementById("start");
    const autoComplete = new google.maps.places.Autocomplete(start);
    autoComplete.bindTo("bounds", map);

    //direction function
    const directionsRenderer = new google.maps.DirectionsRenderer();
    const directionsService = new google.maps.DirectionsService();
    directionsRenderer.setMap(map);
    directionsRenderer.setPanel(document.getElementById("sidebar"));
    var getDirection = document.getElementById("get-direction");
    getDirection.addEventListener("click", function () {
        directionsService.route({
            origin: {
                query: document.getElementById("start").value
            },
            destination: {
                query: document.getElementById("end").value
            },
            travelMode: google.maps.TravelMode[document.getElementById("mode").value]
        }, (response, status) => {
            if (status == "OK") {
                directionsRenderer.setDirections(response);
            } else {
                window.alert("Sorry! Unable to direct due to " + status);
            }
        });
    });
}

function geodoceAddress(map, store) {
    var geocoder = new google.maps.Geocoder();
    var content = "<h3>" + store.Store_name + "</h3><hr/><p>" + store.Store_address + "</p><p>" + store.Contact_number + "</p>";
    const infowindow = new google.maps.InfoWindow({
        content: content,
    });
    geocoder.geocode({ address: store.Store_address }, function (result, status) {
        if (status === "OK") {
            const image = {
                url: "https://developers.google.com/maps/documentation/javascript/examples/full/images/beachflag.png",
                // This marker is 20 pixels wide by 32 pixels high.
                size: new google.maps.Size(20, 32),
                // The origin for this image is (0, 0).
                origin: new google.maps.Point(0, 0),
                // The anchor for this image is the base of the flagpole at (0, 32).
                anchor: new google.maps.Point(0, 32),
            };
            var marker = new google.maps.Marker({
                map: map,
                icon: image,
                label: labels[labelIndex++ % labels.length],
                animation: google.maps.Animation.DROP,
                position: result[0].geometry.location
            });
        }
        marker.addListener("click", function () { infowindow.open(map, marker) });
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