<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HomepageViewModel>" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="announcement-wrapper">
        <div id="slideshow"><%: Html.Image("~/Content/Images/slideshow_img.gif") %></div>
        <div id="big-button-list">
            <ul>
                <li id="register_button"><%= Html.ActionLinkForAreas<HomeController>(c => c.Index(), "<span>Register<span><span id='summer_program'>Summer Program</span>")%></li>
                <li class="big-button"><%= Html.ActionLinkForAreas<HomeController>(c => c.Index(), "Alumni")%></li>
                <li class="big-button"><%= Html.ActionLinkForAreas<HomeController>(c => c.Index(), "Seminars")%></li>
                <li class="big-button"><%= Html.ActionLinkForAreas<HomeController>(c => c.Index(), "Publications")%></li>
            </ul>
        </div>
    </div>
    <div class="leftColumn">
        <div id="news-wrapper">
            <a href="<%= Url.Action("Index", "News") %>"><%= Html.Image("~/Content/Images/news-header.jpg", "Xiamen Academy Of International Law News", new { border = "0" }) %></a>
            <% foreach (var news in Model.AcademyNews) { %>
                <div class="news-item">
                    <div class="news-img"><%= Html.Image("~/Content/Images/news-sample-img.jpg") %></div>
                    <h4><%= Html.ActionLinkForAreas<NewsController>(x => x.Show(news.Id), news.Title) %></h4>
                    <div class="news-excerpt"><%: news.Body.Length > 300 ? news.Body.Substring(0, 300) : news.Body %> ...</div>
                    <div class="read-more"><%= Html.ActionLinkForAreas<NewsController>(x => x.Show(news.Id), "Read More") %></div>
                </div>
            <% } %>
            <div class="clear"></div>
        </div>
    </div>
    <!--/leftColumn-->
    <div class="rightColumn">
        <div id="summer-program-wrapper">
            <a href="<%= Url.Action("Index", "News") %>"><%= Html.Image("~/Content/Images/summer-program-header.jpg", "Xiamen Academy Summer Program Information", new { border = "0" }) %></a>
            <ul class="summer-program-links">
                <li><%: Html.ActionLink("Admission", "UnderConstruction")%></li>
                <li><%: Html.ActionLink("Scholarship", "UnderConstruction")%></li>
                <li><%: Html.ActionLink("Curriculum", "UnderConstruction")%></li>
                <li><%: Html.ActionLink("Course Materials", "UnderConstruction")%></li>
            </ul>
            <ul class="summer-program-links">
                <li><%: Html.ActionLink("Timetables", "UnderConstruction")%></li>
                <li><%: Html.ActionLink("Accomodation", "UnderConstruction")%></li>
                <li><%: Html.ActionLink("Visa Guideline", "UnderConstruction")%></li>
                <li><%: Html.ActionLink("Tips", "UnderConstruction")%></li>
            </ul>
        </div>
        <div class="clear"></div>
        <div id="summer-program-news">
            <ul>
                <% foreach(var news in Model.SummerProgramNews) { %>
                    <li><%= Html.ActionLinkForAreas<NewsController>(x => x.Show(news.Id), news.Title) %></li>
                <% } %>
            </ul>
            <div class="read-more"><%: Html.ActionLink("More News", "Index", "News")%></div>
            <div class="clear"></div>
        </div>
    </div><!--/rightColumn-->
</asp:Content>
