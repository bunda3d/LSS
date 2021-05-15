import 'https://api.mapbox.com/mapbox-gl-js/v2.1.1/mapbox-gl.js';
/**
  import 'https://api.mapbox.com/mapbox-gl-js/v1.12.0/mapbox-gl.js';
*/

// TO MAKE THE MAP APPEAR YOU MUST ADD YOUR ACCESS TOKEN FROM 
// https://account.mapbox.com


mapboxgl.accessToken = 'pk.eyJ1IjoiYnVuZGEzZCIsImEiOiJja29uc3czcDIwM3dtMnZxcjNrYTUxeWJwIn0.hYU42u4miD6eQfrhxWprmQ';

export function addMapToElement(element) {
  return new mapboxgl.Map({
    container: element,
    style: 'mapbox://styles/mapbox/streets-v11',
    center: [-74.5, 40],
    zoom: 9,
    latitude: (47.608013), 
    longitude: (- 122.335167)
  });
}

export function setMapCenter(map, latitude, longitude) {
  map.setCenter([longitude, latitude]);
}
