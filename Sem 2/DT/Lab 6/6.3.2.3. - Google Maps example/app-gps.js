// Note: This example requires that you consent to location sharing when
// prompted by your browser. If you see the error "The Geolocation service
// failed.", it means you probably did not give permission for the browser to
// locate you.
var map, infoWindow;
const mapStyle = [
  {
    featureType: "water",
    elementType: "geometry",
    stylers: [
      {
        color: "#fc94af", // Set the water color to pink
      },
    ],
  },
  {
    featureType: "road",
    elementType: "geometry",
    stylers: [
      {
        color: "#d89eff", // Set the road color to lavender
      }
    ]
  },
  {
    featureType: "landscape", // Set the landscape color to red
    elementType: "geometry",
    stylers: [
      {
        color: "#803eac"
      },
    ],
  },
];

function initMap() {
  const map = new google.maps.Map(document.getElementById("map"), {
    center: { lat: 47.687123, lng: 22.597747 }, // Set the initial map center
    styles: mapStyle, // Apply the defined map style
    zoom: 12 // Set the initial zoom level
  });

  infoWindow = new google.maps.InfoWindow;

  // Try HTML5 geolocation.
  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(function(position) {
      var pos = {
        lat: position.coords.latitude,
        lng: position.coords.longitude
      };

      infoWindow.setPosition(pos);
      infoWindow.setContent('Location found.');
      infoWindow.open(map);
      map.setCenter(pos);
    }, function() {
      handleLocationError(true, infoWindow, map.getCenter());
    });
  } else {
    // Browser doesn't support Geolocation
    handleLocationError(false, infoWindow, map.getCenter());
  }

  // Create a new polygon
  polygon = new google.maps.Polygon({
    map,
    editable: true, // Allow the user to edit the polygon
  });

  // Add event listener to update the area when the polygon is edited
  google.maps.event.addListener(polygon.getPath(), "set_at", calculateArea);
  google.maps.event.addListener(polygon.getPath(), "insert_at", calculateArea);
}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
  infoWindow.setPosition(pos);
  infoWindow.setContent(browserHasGeolocation ?
                        'Error: The Geolocation service failed.' :
                        'Error: Your browser doesn\'t support geolocation.');
  infoWindow.open(map);
}

function calculateArea() {
  const area = google.maps.geometry.spherical.computeArea(polygon.getPath());
  console.log("Area:", area.toFixed(2), "square meters");
}
