<%@ Page Title="Welcome to Ecobecois!" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dataasp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12 element-top-30 element-bottom-30">
            <h1 class="page-header">Travel Now!</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="container">
                <p>Departing from:</p>
                <asp:TextBox ID="fromTextBox" runat="server"></asp:TextBox>
                <p>Destination:</p>
                <asp:TextBox ID="toTextBox" runat="server"></asp:TextBox>
                <ajaxToolkit:ComboBox ID="travelModeComboBox" runat="server">
                    <asp:ListItem Value="DRIVING">Car</asp:ListItem>
                    <asp:ListItem Value="TRANSIT">Public Transport</asp:ListItem>
                    <asp:ListItem Value="BICYCLING">Bicycle</asp:ListItem>
                    <asp:ListItem Value="WALKING">Walking</asp:ListItem>
                </ajaxToolkit:ComboBox>
                <br />
                <p><b>Help us provide you with a sustainable alternative</b></p>
                <p>Distance of your travel:</p>
                <div>
                    Long
                        <asp:TextBox ID="distanceSlider" runat="server"></asp:TextBox>
                    <ajaxToolkit:SliderExtender ID="distanceSlider_SliderExtender" runat="server" BehaviorID="distanceSlider_SliderExtender" Maximum="100" Minimum="0" TargetControlID="distanceSlider" />
                    Short
                </div>
                <div>
                    <asp:TextBox ID="securitySlider" runat="server"></asp:TextBox>
                    <ajaxToolkit:SliderExtender ID="securitySlider_SliderExtender" runat="server" BehaviorID="securitySlider_SliderExtender" Maximum="100" Minimum="0" TargetControlID="securitySlider" />
                </div>
                <asp:Button ID="addTripButton" runat="server" Text="Button" OnClick="addTripButton_Click" />
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
