using Dataasp.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.GoogleMaps.MapGeneration
{
    public class MapGenerater
    {

        public string GenerateMap(string start, string end, string waypoint, string transportationMode, bool isUseWayPoint)
        {
            var commentLine = "";//This string is used to comment out waypoint in javascript function if needed

            if (!isUseWayPoint || transportationMode.ToUpper() == "TRANSIT") //If we force a waypoint when there's a but it's gonna give zero results unless the waypoint is on a busstop
            {
                commentLine = "//";
            }

            return
                @"<div class=""row"">
                <div class=""col-md-12"">
                    <div id=""map""></div>
                </div>
            </div>
            <script>



                function initMap()
        {
            var start = " + start + @";
        var end = " + end + @";
        var waypoint = " + waypoint + @";
        var transportationMode = '" + transportationMode + @"'; 

        // Create an array of styles.
            var styles = [
                        {
                            ""elementType"": ""geometry"",
                ""stylers"": [
                                {
                                    ""hue"": ""#ff4400""
                                },
                                {
                                    ""saturation"": -68
                                },
                                {
                                    ""lightness"": -4
                                },
                                {
                                    ""gamma"": 0.72
                                }
                            ]
                        },
                        {
                            ""featureType"": ""road"",
                            ""elementType"": ""labels.icon""
                        },
                        {
                            ""featureType"": ""landscape.man_made"",
                            ""elementType"": ""geometry"",
                            ""stylers"": [
                                {
                                    ""hue"": ""#0077ff""
                                },
                                {
                                    ""gamma"": 3.1
                                }
                            ]
                        },
                        {
                            ""featureType"": ""water"",
                            ""stylers"": [
                                {
                                    ""hue"": ""#00ccff""
                                },
                                {
                                    ""gamma"": 0.44
                                },
                                {
                                    ""saturation"": -33
                                }
                            ]
                        },
                        {
                            ""featureType"": ""poi.park"",
                            ""stylers"": [
                                {
                                    ""hue"": ""#44ff00""
                                },
                                {
                                    ""saturation"": -23
                                }
                            ]
                        },
                        {
                            ""featureType"": ""water"",
                            ""elementType"": ""labels.text.fill"",
                            ""stylers"": [
                                {
                                    ""hue"": ""#007fff""
                                },
                                {
                                    ""gamma"": 0.77
                                },
                                {
                                    ""saturation"": 65
                                },
                                {
                                    ""lightness"": 99
                                }
                            ]
                        },
                        {
                            ""featureType"": ""water"",
                            ""elementType"": ""labels.text.stroke"",
                            ""stylers"": [
                                {
                                    ""gamma"": 0.11
                                },
                                {
                                    ""weight"": 5.6
                                },
                                {
                                    ""saturation"": 99
                                },
                                {
                                    ""hue"": ""#0091ff""
                                },
                                {
                                    ""lightness"": -86
                                }
                            ]
                        },
                        {
                            ""featureType"": ""transit.line"",
                            ""elementType"": ""geometry"",
                            ""stylers"": [
                                {
                                    ""lightness"": -48
                                },
                                {
                                    ""hue"": ""#ff5e00""
                                },
                                {
                                    ""gamma"": 1.2
                                },
                                {
                                    ""saturation"": -23
                                }
                            ]
                        },
                        {
                            ""featureType"": ""transit"",
                            ""elementType"": ""labels.text.stroke"",
                            ""stylers"": [
                                {
                                    ""saturation"": -64
                                },
                                {
                                    ""hue"": ""#ff9100""
                                },
                                {
                                    ""lightness"": 16
                                },
                                {
                                    ""gamma"": 0.47
                                },
                                {
                                    ""weight"": 2.7
                                }
                            ]
                        }
                    ];

                    // Create a new StyledMapType object, passing it the array of styles,
                    // as well as the name to be displayed on the map type control.
                    var styledMap = new google.maps.StyledMapType(styles,
                        {name: ""Styled Map""});

                    // Create a map object, and include the MapTypeId to add
                    // to the map type control.
                    var mapOptions = {
                        zoom: 11,
                        center: start,
                        mapTypeControlOptions: {
                            mapTypeIds: [google.maps.MapTypeId.ROADMAP, 'map_style']
                        }
                    };
                    var map = new google.maps.Map(document.getElementById('map'),
                        mapOptions);

//Associate the styled map with the MapTypeId and set it to display.
map.mapTypes.set('map_style', styledMap);
                    map.setMapTypeId('map_style');


                    var directionsDisplay = new google.maps.DirectionsRenderer({
                        map: map
                    });
                    // Set destination, origin and travel mode.
                    var request = {
                        destination: end,
                        " + commentLine + @"waypoints: [{location: waypoint, stopover: false}],
                        origin: start,
                        travelMode: google.maps.TravelMode[transportationMode]
                    };

                // Pass the directions request to the directions service.
                var directionsService = new google.maps.DirectionsService();
                directionsService.route(request, function(response, status)
                {
                    if (status == 'OK')
                    {
                        // Display the route on the map.
                        directionsDisplay.setDirections(response);
                    }
                    else {        
                      //WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW IMPORTANT COMMENT WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
                      //code to say there was 0 results should be here (if status == 'ZERO_RESULTS')
                      window.alert('Directions request failed due to ' + status);
                    }
                });


                }

            </script>


            <script src = ""https://maps.googleapis.com/maps/api/js?key=AIzaSyCyeTwU64siTHFVrI_h9bJX7VlMdReWvbc&callback=initMap""
                    async defer></script>
    </div>";
        }


    }
}