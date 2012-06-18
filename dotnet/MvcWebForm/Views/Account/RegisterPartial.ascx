<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcWebForm.Models.RegisterModel>" %>

<hgroup class="title">
    <h1>Register.</h1>
    <h2>Create a new account.</h2>
</hgroup>

<p class="message-info">
    Passwords are required to be a minimum of <%: Membership.MinRequiredPasswordLength %> characters in length.
</p>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary() %>

    <fieldset>
        <legend>Registration Form</legend>
        <ol>
            <li>
                <%: Html.LabelFor(m => m.UserName) %>
                <%: Html.TextBoxFor(m => m.UserName) %>
            </li>
            <li>
                <%: Html.LabelFor(m => m.Email) %>
                <%: Html.TextBoxFor(m => m.Email) %>
            </li>
            <li>
                <%: Html.LabelFor(m => m.Password) %>
                <%: Html.PasswordFor(m => m.Password) %>
            </li>
            <li>
                <%: Html.LabelFor(m => m.ConfirmPassword) %>
                <%: Html.PasswordFor(m => m.ConfirmPassword) %>
            </li>
        </ol>
        <input type="submit" value="Register" />
    </fieldset>
<% } %>
