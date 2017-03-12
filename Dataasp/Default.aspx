<%@ Page Title="Welcome to Ecobecois!" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dataasp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12 element-top-30 element-bottom-30">
            <h1 class="page-header">Travel Now!</h1>
        </div>
    </div>
    <div class="row element-bottom-20">
        <div class="col-md-6">
            <div class="container">
                <p>Location:</p><input id="autocomplete" placeholder="Enter your location" onfocus="geolocate()" type="text" runat="server" clientidmode="Static"></input>
                <script>
                    var placeSearch, autocomplete;

                    function initAutocomplete() {
                        // Create the autocomplete object, restricting the search to geographical
                        // location types.
                        autocomplete = new google.maps.places.Autocomplete(
                            /** @type {!HTMLInputElement} */(document.getElementById('autocomplete')),
                            { types: ['geocode'] });

                        // When the user selects an address from the dropdown, populate the address
                        // fields in the form.
                        autocomplete.addListener('place_changed', fillInAddress);

                        // Create the autocomplete object, restricting the search to geographical
                        // location types.
                        autocomplete2 = new google.maps.places.Autocomplete(
                            /** @type {!HTMLInputElement} */(document.getElementById('autocomplete2')),
                            { types: ['geocode'] });

                        // When the user selects an address from the dropdown, populate the address
                        // fields in the form.
                        autocomplete2.addListener('place_changed', fillInAddress2);
                    }

                    function fillInAddress() {
                        // Get the place details from the autocomplete object.
                        var place = autocomplete.getPlace();
                        document.getElementById(fromTextBox).value = place;

                    }

                    // Bias the autocomplete object to the user's geographical location,
                    // as supplied by the browser's 'navigator.geolocation' object.
                    function geolocate() {
                        if (navigator.geolocation) {
                            navigator.geolocation.getCurrentPosition(function (position) {
                                var geolocation = {
                                    lat: position.coords.latitude,
                                    lng: position.coords.longitude
                                };
                                var circle = new google.maps.Circle({
                                    center: geolocation,
                                    radius: position.coords.accuracy
                                });
                                autocomplete.setBounds(circle.getBounds());
                            });
                        }
                    }

                    function fillInAddress2() {
                        // Get the place details from the autocomplete object.
                        var place2 = autocomplete2.getPlace();
                        document.getElementById(toTextBox).value = place2;

                    }

                    // Bias the autocomplete object to the user's geographical location,
                    // as supplied by the browser's 'navigator.geolocation' object.
                    function geolocate2() {
                        if (navigator.geolocation) {
                            navigator.geolocation.getCurrentPosition(function (position) {
                                var geolocation2 = {
                                    lat: position.coords.latitude,
                                    lng: position.coords.longitude
                                };
                                var circle2 = new google.maps.Circle({
                                    center: geolocation2,
                                    radius: position.coords.accuracy
                                });
                                autocomplete2.setBounds(circle.getBounds());
                            });
                        }
                    }
                </script>
                <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCyeTwU64siTHFVrI_h9bJX7VlMdReWvbc&libraries=places&callback=initAutocomplete"
                    async defer></script>


                <p>Destination:</p><input id="autocomplete2" placeholder="Enter Destination" onfocus="geolocate2()" type="text" runat="server" clientidmode="Static"></input>
                <br>
                <br>
                <div class="clearfix">
                    <select id="travelModeComboBox" runat="server">
                        <option value="DRIVING">Car</option>
                        <option value="TRANSIT">Public Transport</option>
                        <option value="BICYCLING">Bicycle</option>
                        <option value="WALKING">Walking</option>
                    </select>
                </div>
                <p class="clearfix"><b>Help us provide you with a sustainable alternative</b></p>


                <p>Distance:</p><input class="slider" id="distanceSlider" runat="server" type="range" min="0" max="100" value="50" style="width: 20%;" />

                <p>Saving Fuel:</p><input class="slider" id="savingFuelSlider" runat="server" type="range" min="0" max="100" value="50" style="width: 20%;" />
                <p>Avoid Construction:</p>

                <input class="slider" id="constructionSlider" runat="server" type="range" min="0" max="100" value="50" style="width: 20%;" />

                <p>Avoid Speed Traps:</p><input class="slider" id="photoRadarSlider" runat="server" type="range" min="0" max="100" value="50" style="width: 20%;" />
                <br>
                <asp:Button ID="addTripButton" runat="server" Text="Trip Calculator" OnClick="addTripButton_Click" />
                <div id="quickStatsDiv" runat="server">
                    <!-- Alex's spot to add qucikstat stuff -->
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div id="mapResults" runat="server">
            </div>
        </div>
    </div>
</asp:Content>
