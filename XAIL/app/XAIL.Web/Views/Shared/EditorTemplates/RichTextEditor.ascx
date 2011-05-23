<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<%: Html.TextArea("", Model, new { @class = "rich-text-editor" })%>