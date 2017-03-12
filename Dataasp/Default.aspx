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
                <p>Departing from:</p>
                <asp:TextBox ID="fromTextBox" runat="server"></asp:TextBox>
                <p>Destination:</p>
                <asp:TextBox ID="toTextBox" runat="server"></asp:TextBox>
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
