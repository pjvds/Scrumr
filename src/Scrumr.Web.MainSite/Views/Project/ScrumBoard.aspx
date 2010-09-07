<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ScrumBoard
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
	<script type="text/javascript" src="../../Scripts/ScrumBoard.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
		<ul id="stories" class="stories ui-helper-reset ui-helper-clearfix">
			<li class="ui-widget-content ui-corner-tr">
				<h5 class="ui-widget-header">Story 1</h5>
			</li>
			<li class="ui-widget-content ui-corner-tr">
				<h5 class="ui-widget-header">Story 2</h5>
			</li>
			<li class="ui-widget-content ui-corner-tr">
				<h5 class="ui-widget-header">Story 3</h5>
			</li>
			<li class="ui-widget-content ui-corner-tr">
				<h5 class="ui-widget-header">Story 4</h5>
			</li>
		</ul>
        <ul id="stages" class="ui-widget-content ui-state-default">
            <li class="ui-widget-header">
				<p>To Do</p>
			</li>
             <li class="ui-widget-header">
				<p>In Progress</p>
			</li>
        </ul>
	</div>
</asp:Content>
