<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<XAIL.Core.News>" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h3><%: Model.Title %></h3>
    <%: Html.Raw(Model.Body) %>
    Created At: <%: Model.CreatedAt %> Category: <%: Model.NewsCategory.Name %>
    <br />
    <% using (Html.BeginForm<NewsController>(c => c.Delete(Model.Id))) { %>
        <%= Html.AntiForgeryToken() %>
        <input type="submit" value="Delete" onclick="return confirm('Are you sure?');" />
    <% } %>
    <%: Html.ActionLink("Edit", "Edit", new { id = Model.Id }) %> | 
    <%: Html.ActionLink("go back to all news", "Index") %>
</asp:Content>
