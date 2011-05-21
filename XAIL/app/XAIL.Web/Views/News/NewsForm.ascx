﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<NewsFormViewModel>" %>

<% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
    <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
<% } %>  <%= Html.ValidationSummary() %>  <% using (Html.BeginForm()) { %>     <%= Html.AntiForgeryToken()%>     <%= Html.Hidden("News.Id", (ViewData.Model != null) ? ViewData.Model.Id : 0)%>     <label for="Title">Title:</label> 	<div> 		<%= Html.TextBox("Title", (ViewData.Model != null) ? ViewData.Model.Title : "")%> 	</div> 	<%= Html.ValidationMessage("Title")%><br />     <label for="Body">Body:</label> 	<div> 		<%= Html.TextArea("Body", (ViewData.Model != null) ? ViewData.Model.Body : "")%> 	</div> 	<%= Html.ValidationMessage("Body")%><br />     <%= Html.SubmitButton("btnSave", "Save News")%> <% } %>