<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Scrumr.Commands.AddNewStoryToProductBacklog>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AddToProductBacklog
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AddToProductBacklog</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ProductId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ProductId) %>
                <%: Html.ValidationMessageFor(model => model.ProductId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.StoryId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.StoryId) %>
                <%: Html.ValidationMessageFor(model => model.StoryId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.StoryDescription) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.StoryDescription) %>
                <%: Html.ValidationMessageFor(model => model.StoryDescription) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

