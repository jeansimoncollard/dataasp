<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dataasp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <!-- Header Carousel -->
    <div id="myCarousel" class="carousel slide">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>
        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active">
                <div class="fill" style="background-image:url('images/panda-eating.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Caption 1</h2>
                </div>
            </div>
            <div class="item">
                <div class="fill" style="background-image:url('images/trees.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Caption 2</h2>
                </div>
            </div>
            <div class="item">
                <div class="fill" style="background-image:url('images/tree.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Caption 3</h2>
                </div>
            </div>
        </div>
        <!-- Controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
            <span class="icon-prev"></span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
            <span class="icon-next"></span>
        </a>
    </div>

    <div>
       <h1> Ajouter un voyage</h1>
        <br />
        from: <asp:TextBox ID="fromTextBox" runat="server"></asp:TextBox>
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

        <h1> Aidez-nous à vous suggérer une alternative durable</h1>
        <p> Distance:</p>
        <p> 
            Long <asp:TextBox ID="distanceSlider" runat="server"></asp:TextBox>
            <ajaxToolkit:SliderExtender ID="distanceSlider_SliderExtender" runat="server" BehaviorID="distanceSlider_SliderExtender" Maximum="100" Minimum="0" TargetControlID="distanceSlider" />
        &nbsp;Short</p>
        <p> 
            <asp:TextBox ID="securitySlider" runat="server"></asp:TextBox>
            <ajaxToolkit:SliderExtender ID="securitySlider_SliderExtender" runat="server" BehaviorID="securitySlider_SliderExtender" Maximum="100" Minimum="0" TargetControlID="securitySlider" />
        </p>
        <p> &nbsp;</p>
        <p> 
            <asp:Button ID="addTripButton" runat="server" Text="Button" OnClick="addTripButton_Click" />
        </p>
        <div id="mapResults" runat="server">
        </div>
        <div id="quickStatsDiv" runat="server"> <!-- Alex's spot to add qucikstat stuff -->
           
        </div>
        <p> &nbsp;</p>
    </div>

    <script>
    $('.carousel').carousel({
        interval: 5000 //changes the speed
    })
    </script>

</asp:Content>
