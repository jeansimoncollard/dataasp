<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dataasp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <div>
       <h1> Ajouter un voyage</h1>
        <br />
        from: <asp:TextBox ID="fromTextBox" runat="server"></asp:TextBox>
        <br />
        to:<asp:TextBox ID="toTextBox" runat="server"></asp:TextBox>
        <br />
        <br />

        <h1> Aidez-nous à vous suggérer une alternative durable</h1>
        <p> &nbsp;</p>
        <p> 
            <asp:TextBox ID="distanceSlider" runat="server"></asp:TextBox>
        </p>
        <p> 
            <asp:TextBox ID="securitySlider" runat="server"></asp:TextBox>
        </p>
        <div id="mapDiv">
        </div>
        <div id="quickStatsDiv">
        </div>
        <p> &nbsp;</p>
    </div>

    

</asp:Content>
