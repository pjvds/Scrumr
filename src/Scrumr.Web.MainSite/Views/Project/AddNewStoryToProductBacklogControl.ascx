<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Scrumr.Commands.AddNewStoryToProductBacklog>" %>

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


