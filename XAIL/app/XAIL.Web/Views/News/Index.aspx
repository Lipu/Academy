<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Paging.IPagedList<XAIL.Core.News>>" %>
<%@ Import Namespace="Paging" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <p>All News: </p>

    <% if (ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] != null) { %>
        <p id="pageMessage"><%= ViewContext.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()]%></p>
    <% } %>

    <ul>
        <% foreach (var news in Model) { %>
            <li>
                <%: Html.ActionLink(news.Title, "Show", new { id = news.Id }) %>
                Created At: <%: news.CreatedAt %> 
            </li>
         <% } %>
    </ul>

    <div class="pager">
		<%= Html.Pager(ViewData.Model.PageSize, ViewData.Model.PageNumber, ViewData.Model.TotalItemCount) %>
	</div>

    <%: Html.ActionLink("Create news", "Create") %>
</asp:Content>
