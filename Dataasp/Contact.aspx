<%@ Page Title="Leave a Comment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Dataasp.Contact" %>
    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h2><%: Title %>.</h2>
        <h3>We appreciate your feedback.</h3>
        <div class="row">
            <div class="Box">
                <div class="col-md-4 text-center">
                    <div class="well">
                        <div class="input-group">
                            <input type="text" id="userComment" class="form-control input-sm chat-input" placeholder="Write your message here..." />
                            <span class="input-group-btn" onclick="addComment()">     
                        <a href="#" class="btn1 btn-primary1 btn-sm"><span class="glyphicon glyphicon-comment"></span> Add Comment</a>
                        </div>
                        <hr data-brackets-id="12673">
                        <ul data-brackets-id="12674" id="sortable" class="list-unstyled ui-sortable">
                            <strong class="pull-left primary-font">James</strong>
                            <small class="pull-right text-muted">
                            <span class="glyphicon glyphicon-time"></span>7 mins ago</small>
                            </br>
                            <li class="ui-state-default">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. </li>
                            </br>
                            <strong class="pull-left primary-font">Taylor</strong>
                            <small class="pull-right text-muted">
                            <span class="glyphicon glyphicon-time"></span>14 mins ago</small>
                            </br>
                            <li class="ui-state-default">Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</li>
                        </ul>
                    </div>
            </div>
                </div>
            <div class="row">
                <div class="col-md-8">
                    <img alt="Logo" src="~/images/rsz_panda-eating.jpg" runat="server">
                </div>
            </div>
        </div>
    </asp:Content>
