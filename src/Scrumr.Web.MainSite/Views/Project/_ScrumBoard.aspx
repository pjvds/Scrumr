<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Scrumr.Web.MainSite.ReadModel.Scrumboard>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ScrumBoard
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../../Scripts/ScrumBoard.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table id="board">
        <thead>
            <tr>
                <th>
                    Stories
                </th>
                <% foreach (var stage in Model.Stages)
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
            <% foreach (var story in Model.Stories)
               {
            %>
            <tr>
                <td>
                    <%: story.Description %>
                </td>
                <% foreach (var stage in Model.Stages)
                   {
                       var tasks = story.Tasks.Where(t => t.Stage.Id == stage.Id);

                %>
                <td class="storystage">
                    <%
                        foreach (var task in tasks)
                        {
                    %>
                    <div class="task ui-widget-content ui-corner-tr">
                        <h5 class="ui-widget-header">
                            Task</h5>
                        <%: task.Description%>
                    </div>
                    <%      
                        }
                    %>
                </td>
                <%
                    } 
                %>
            </tr>
            <%      
                } 
            %>
        </tbody>
    </table>
</asp:Content>
