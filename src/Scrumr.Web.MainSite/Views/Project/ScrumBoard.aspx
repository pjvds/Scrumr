<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Scrumr.Web.MainSite.Models.ScrumBoard>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ScrumBoard
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../../Scripts/ScrumBoard.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <thead>
            <tr>
                <th>
                    Stories
                </th>
                <% foreach (Scrumr.Web.MainSite.Models.Stage stage in Model.Stages)
                   {
                %>
                <th>
                    <%: stage.Name %>
                </th>
                <%      
                    } 
                %>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>
    <ul id="stories" class="ui-widget-content ui-state-default">
        <%--<h5 class="ui-widget-header">Stories</h5>--%>
        <li class="ui-widget-content ui-corner-tr">
            <h5 class="ui-widget-header">
                Task 1</h5>
        </li>
        <li class="ui-widget-content ui-corner-tr">
            <h5 class="ui-widget-header">
                Task 2</h5>
        </li>
        <li class="ui-widget-content ui-corner-tr">
            <h5 class="ui-widget-header">
                Task 3</h5>
        </li>
        <li class="ui-widget-content ui-corner-tr">
            <h5 class="ui-widget-header">
                Task 4</h5>
        </li>
    </ul>
    <ul id="stages" class="ui-widget-content ui-state-default">
        <%--<h5 class="ui-widget-header">Stages</h5>--%>
        <li class="ui-widget-header">
            <p>
                To Do</p>
        </li>
        <li class="ui-widget-header">
            <p>
                In Progress</p>
        </li>
    </ul>
</asp:Content>
