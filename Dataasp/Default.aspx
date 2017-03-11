<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dataasp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <div>
        <h1>Ajouter un voyage</h1>
        <br />
        from:
        <asp:TextBox ID="fromTextBox" runat="server"></asp:TextBox>
        <br />
        to:<asp:TextBox ID="toTextBox" runat="server"></asp:TextBox>
        <br />
        <ajaxToolkit:ComboBox ID="travelModeComboBox" runat="server">
            <asp:ListItem Value="DRIVING">Car</asp:ListItem>
            <asp:ListItem Value="TRANSIT">Public Transport</asp:ListItem>
            <asp:ListItem Value="BICYCLING">Bicycle</asp:ListItem>
            <asp:ListItem Value="WALKING">Walking</asp:ListItem>
        </ajaxToolkit:ComboBox>
        <br />

        <h1>Aidez-nous à vous suggérer une alternative durable</h1>
        <p>&nbsp;</p>
        <p>
            <asp:TextBox ID="distanceSlider" runat="server"></asp:TextBox>
            <ajaxToolkit:SliderExtender ID="distanceSlider_SliderExtender" runat="server" BehaviorID="distanceSlider_SliderExtender" Maximum="100" Minimum="0" TargetControlID="distanceSlider" />
        </p>
        <p>
            <asp:TextBox ID="securitySlider" runat="server"></asp:TextBox>
            <ajaxToolkit:SliderExtender ID="securitySlider_SliderExtender" runat="server" BehaviorID="securitySlider_SliderExtender" Maximum="100" Minimum="0" TargetControlID="securitySlider" />
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Button ID="addTripButton" runat="server" Text="Button" OnClick="addTripButton_Click" />
        </p>
        
        <div id="mapResults" runat="server">



        </div>


        <div id="quickStatsDiv">
        </div>
        <p>&nbsp;</p>
    </div>



</asp:Content>
