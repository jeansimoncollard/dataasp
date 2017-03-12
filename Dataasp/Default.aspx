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
                <input id="autocomplete" placeholder="Enter your address" onfocus="geolocate()" type="text" runat="server" clientidmode="Static"></input>
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


                <p>Destination:</p>
                <input id="autocomplete2" placeholder="Enter your address" onfocus="geolocate2()" type="text" runat="server" clientidmode="Static"></input>
                <div class="clearfix">
                    <ajaxToolkit:ComboBox ID="travelModeComboBox" runat="server">
                        <asp:ListItem Value="DRIVING">Car</asp:ListItem>
                        <asp:ListItem Value="TRANSIT">Public Transport</asp:ListItem>
                        <asp:ListItem Value="BICYCLING">Bicycle</asp:ListItem>
                        <asp:ListItem Value="WALKING">Walking</asp:ListItem>
                    </ajaxToolkit:ComboBox>
                </div>
                <p class="clearfix"><b>Help us provide you with a sustainable alternative</b></p>
                <p>Saving Fuel:</p>

                <asp:TextBox ID="distanceSlider" runat="server" Text="50"></asp:TextBox>
                <ajaxToolkit:SliderExtender ID="distanceSlider_SliderExtender" runat="server" BehaviorID="distanceSlider_SliderExtender" Maximum="100" Minimum="0" TargetControlID="distanceSlider" />

                <p>Avoid Construction:</p>
                <asp:TextBox ID="constructionSlider" runat="server" Text="50"></asp:TextBox>
                <ajaxToolkit:SliderExtender ID="constructionSlider_SliderExtender" runat="server" BehaviorID="constructionSlider_SliderExtender" Maximum="100" Minimum="0" TargetControlID="constructionSlider" />

                <p>Avoid Speed Traps:</p>
                <asp:TextBox ID="photoRadarSlider" runat="server" Text="50"></asp:TextBox>
                <ajaxToolkit:SliderExtender ID="photoRadarSlider_SliderExtender" runat="server" BehaviorID="photoRadarSlider_SliderExtender" Maximum="100" Minimum="0" TargetControlID="photoRadarSlider" />
                <asp:Button ID="addTripButton" runat="server" Text="Trip Calculator" OnClick="addTripButton_Click"/>
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
