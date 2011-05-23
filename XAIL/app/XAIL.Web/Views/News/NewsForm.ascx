<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<NewsFormViewModel>" %>

<% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
    <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
<% } %>

<%= Html.ValidationSummary() %>

<% using (Html.BeginForm()) { %>
    <%= Html.AntiForgeryToken()%>
    <%= Html.Hidden("News.Id", Model.Id)%>
    <label for="Title">Title:</label>
	<div>
		<%= Html.TextBox("Title", Model.Title)%>
	</div>
	<%= Html.ValidationMessage("Title")%><br />
    
    <label for="Body">Body:</label>
	<div>
		<%: Html.TextAreaFor(model => model.Body, new { @class = "rich-text-editor" })%>
	</div>
	<%= Html.ValidationMessage("Body")%><br />

    <%: Html.LabelFor(model => model.SelectedCategoryId, "News Category:") %>
	<div>
        <%: Html.DropDownList("SelectedCategoryId", new SelectList(Model.NewsCategories, "Id", "Name", Model.SelectedCategoryId)) %>
	</div>
	<%= Html.ValidationMessage("SelectedCategoryId")%><br />

    <%= Html.SubmitButton("btnSave", "Save News")%>
<% } %>