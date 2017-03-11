<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Dataasp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <h2><%: Title %>.</h2>
    <h3>We appreciate your feedback.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support: Jean-Simon Collard</strong>   <a href="mailto:Support@example.com">jcollard15@ubishops.ca</a><br />
        <strong>Marketing: Michell Burr Bedard</strong> <a href="mailto:Marketing@example.com">mburr11@ubishops.ca</a>
    </address>
</asp:Content>
