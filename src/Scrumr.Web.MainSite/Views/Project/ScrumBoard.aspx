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
				<h5 class="ui-widget-header">High Tatras</h5>
			</li>
			<li class="ui-widget-content ui-corner-tr">
				<h5 class="ui-widget-header">High Tatras 2</h5>
			</li>
			<li class="ui-widget-content ui-corner-tr">
				<h5 class="ui-widget-header">High Tatras 3</h5>
			</li>
			<li class="ui-widget-content ui-corner-tr">
				<h5 class="ui-widget-header">High Tatras 4</h5>
			</li>
		</ul>
		<div id="todo" class="ui-widget-content ui-state-default">
			<h4 class="ui-widget-header"><span class="ui-icon ui-icon-trash">To Do</span> To Do</h4>
		</div>
	</div>
</asp:Content>
