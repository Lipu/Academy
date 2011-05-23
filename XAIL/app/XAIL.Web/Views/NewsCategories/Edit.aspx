<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<NewsCategoryFormViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

<p>Edit news category: </p>
<% Html.RenderPartial("NewsCategoryForm", ViewData); %>
</asp:Content>
