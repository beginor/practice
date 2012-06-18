<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcWebForm.Models.LoginModel>" %>

<hgroup class="title">
    <h1>Log in.</h1>
    <h2>Enter your user name and password.</h2>
</hgroup>

<% using (Html.BeginForm(new { ReturnUrl = ViewBag.ReturnUrl })) { %>
    <%: Html.ValidationSummary(true, "Log in was unsuccessful. Please correct the errors and try again.") %>

    <fieldset>
        <legend>Log in Form</legend>
        <ol>
            <li>
                <%: Html.LabelFor(m => m.UserName) %>
                <%: Html.TextBoxFor(m => m.UserName) %>
            </li>
            <li>
                <%: Html.LabelFor(m => m.Password) %>
                <%: Html.PasswordFor(m => m.Password) %>
            </li>
            <li>
                <%: Html.CheckBoxFor(m => m.RememberMe) %>
                <%: Html.LabelFor(m => m.RememberMe, new { @class = "checkbox" }) %>
            </li>
        </ol>
        <input type="submit" value="Log in" />
    </fieldset>
    <p>
        <%: Html.ActionLink("Register", "Register") %> if you don't have an account.
    </p>
<% } %>
