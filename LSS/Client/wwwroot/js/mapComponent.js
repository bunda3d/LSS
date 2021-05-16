import 'https://api.mapbox.com/mapbox-gl-js/v2.1.1/mapbox-gl.js';
// TO MAKE THE MAP APPEAR YOU MUST ADD YOUR ACCESS TOKEN FROM
// https://account.mapbox.com
mapboxgl.accessToken = 'pk.eyJ1IjoiYnVuZGEzZCIsImEiOiJja29uc3czcDIwM3dtMnZxcjNrYTUxeWJwIn0.hYU42u4miD6eQfrhxWprmQ';

export function addMapToElement(element) {
  return new mapboxgl.Map({
    container: element,
    style: 'mapbox://styles/mapbox/streets-v11',
    center: [- 122.335167, 47.608013],
    pitch: 60, // pitch in degrees
    bearing: -60, // bearing in degrees
    zoom: 10,
    latitude: (47.608013), 
    longitude: (- 122.335167)
  });
}

export function setMapCenter(map, latitude, longitude, zoom) {
  map.setCenter([longitude, latitude, zoom]);
}

//export function addMapControl(map) {
//  map.addControl(new mapboxgl.NavigationControl());
//}