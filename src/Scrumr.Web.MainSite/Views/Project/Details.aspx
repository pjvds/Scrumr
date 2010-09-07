<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Scrumr.Web.MainSite.ReadModel.ProjectModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script language="javascript" type="text/javascript">
    function showAddNewProductBacklogItem() {
        $("#newProductBacklogItem").dialog();
        return false;
    }
</script>

    <h2>Details</h2>

    <fieldset>
        <a href="" onclick="return showAddNewProductBacklogItem()">show</a>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%: Model.Name %></div>
        
        <ul>
            <% foreach (var story in Model.ProductBacklog.Stories)
               {%>
                <li><%= story.Description %></li>
            <%
               }%>

            <% Html.RenderPartial("AddNewStoryToProductBacklogControl"); %>

        </ul>
    </fieldset>
    <p>
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>


    <div id="newProductBacklogItem" class="flora" title="Title :)">I'm a dialog!</div>
</asp:Content>

