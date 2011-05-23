<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<XAIL.Core.NewsCategory>>" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <p>All News Categories: </p>

    <% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
        <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
    <% } %>

    <ul>
        <% foreach (var category in Model) { %>
            <li>
                <%: Html.ActionLink(category.Name, "Edit", new { id = category.Id })%>
            </li>
         <% } %>
    </ul>

    <%: Html.ActionLink("Create News Category", "Create") %>
</asp:Content>
