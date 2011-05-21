<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<NewsFormViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

<p>Edit news: </p>
<% Html.RenderPartial("NewsForm", ViewData); %>
</asp:Content>
