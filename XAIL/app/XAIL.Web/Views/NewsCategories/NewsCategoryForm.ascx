<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<NewsCategoryFormViewModel>" %>

<% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
    <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
<% } %>

<%= Html.ValidationSummary() %>

<% using (Html.BeginForm()) { %>
    <%= Html.AntiForgeryToken()%>
    <%= Html.Hidden("NewsCategory.Id", (ViewData.Model != null) ? ViewData.Model.Id : 0)%>
    <label for="Title">Name:</label>
	<div>
		<%= Html.TextBox("Name", (ViewData.Model != null) ? ViewData.Model.Name : "")%>
	</div>
	<%= Html.ValidationMessage("Name")%><br />

    <%= Html.SubmitButton("btnSave", "Save News")%>
<% } %>