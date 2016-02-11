<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login"%>
<!DOCTYPE html>
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!--> <html class="no-js"> <!--<![endif]-->
    <head>
        <meta charset="utf-8">

        <title>Malaysian Insurance App - LOGIN</title>

        <meta name="description" content="Malaysian Insurance App - Login">
        <meta name="author" content="Michael Butarbutar - indigomike7@gmail.com - http://web-software-developer.com">
        <meta name="robots" content="noindex, nofollow">

        <meta name="viewport" content="width=device-width,initial-scale=1">

        <!-- Icons -->
        <!-- The following icons can be replaced with your own, they are used by desktop and mobile browsers -->
        <link rel="shortcut icon" href="img/favicon.ico">
        <link rel="apple-touch-icon" href="img/icon57.png" sizes="57x57">
        <link rel="apple-touch-icon" href="img/icon72.png" sizes="72x72">
        <link rel="apple-touch-icon" href="img/icon76.png" sizes="76x76">
        <link rel="apple-touch-icon" href="img/icon114.png" sizes="114x114">
        <link rel="apple-touch-icon" href="img/icon120.png" sizes="120x120">
        <link rel="apple-touch-icon" href="img/icon144.png" sizes="144x144">
        <link rel="apple-touch-icon" href="img/icon152.png" sizes="152x152">
        <!-- END Icons -->

        <!-- Stylesheets -->
        <!-- Bootstrap is included in its original form, unaltered -->
        <link rel="stylesheet" href="css/bootstrap.css">

        <!-- Related styles of various javascript plugins -->
        <link rel="stylesheet" href="css/plugins.css">

        <!-- The main stylesheet of this template. All Bootstrap overwrites are defined in here -->
        <link rel="stylesheet" href="css/main.css">
        <!-- END Stylesheets -->

        <!-- Modernizr (browser feature detection library) & Respond.js (Enable responsive CSS code on browsers that don't support it, eg IE8) -->
        <script src="js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>
    </head>

    <body class="login">
        <!-- Login Container -->
        <div id="login-container">
            <div id="login-logo">
                <a href="">
                    <!--<img src="img/logo-pln.jpg" width="200" alt="logo">-->
                </a>
            </div>

            <!-- Login Buttons 
            <div id="login-buttons">
                <h5 class="page-header-sub">Login with..</h5>
                <button id="login-btn-facebook" class="btn btn-primary"><i class="fa fa-facebook"></i> Facebook</button>
                <button id="login-btn-twitter" class="btn btn-info"><i class="fa fa-twitter"></i> Twitter</button>
                <button id="login-btn-email" class="btn btn-default">or Email <i class="fa fa-envelope"></i></button>
            </div>-->
            <!-- END Login Buttons -->

            <!-- Login Form -->
            <form id="login_form" class="form-horizontal" runat=server>
                <div class="form-group">
                <div ID="ltrl_error" ></div>
                    <!--<a href="javascript:void(0)" class="login-back"><i class="fa fa-arrow-left"></i></a>-->
                </div>
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="input-group">
                            <asp:TextBox ID="login_email" runat="server" CssClass="form-control"  ClientIDMode=Static></asp:TextBox>
                            <span class="input-group-addon"><i class="fa fa-user-md fa-fw"></i></span>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="input-group">
                            <asp:TextBox ID="login_password" runat="server" CssClass="form-control" ClientIDMode=Static TextMode=Password></asp:TextBox>
                            <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        </div>
                    </div>
                </div>
                <div class="clearfix">
                    <div class="btn-group btn-group-sm pull-right">
                        <button type="button" id="login-button-pass" class="btn btn-warning" data-toggle="tooltip" title="Forgot pass?"><i class="fa fa-lock"></i></button>
                        <button type="submit"  onclick='Submit();return false;'  id="submit" clientidmode=Static class="btn btn-success" runat="server"><i class="fa fa-arrow-right"></i> Login</button>
                    </div>
                    <div class="input-switch pull-left" data-toggle="tooltip" title="Remember me" data-on="success" data-off="danger" data-on-label="<i class='fa fa-check fa-white'></i>" data-off-label="<i class='fa fa-times'></i>">
                        <input type="checkbox" name="remember_me" value="Yes" id="remember_me" runat="server" clientidmode=Static>
                    </div>
					<div class="col-xs-12" style="text-align:right;">
					<br/><br/><br/>
					<a href="register.aspx">Register &gt;&gt;</a>
					</div>
                </div>
<asp:ScriptManager ID='ScriptManager1' runat='server' EnablePageMethods='true' />
            </form>
				<div class="form-group">
				</div>
            <!-- END Login Form -->
        </div>
        <!-- END Login Container -->

        <!-- Include Jquery library from Google's CDN but if something goes wrong get Jquery from local file (Remove 'http:' if you have SSL) -->
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
        <script>            !window.jQuery && document.write(unescape('%3Cscript src="js/vendor/jquery-1.11.0.min.js"%3E%3C/script%3E'));</script>

        <!-- Bootstrap.js -->
        <script src="js/vendor/bootstrap.min.js"></script>

        <!-- Jquery plugins and custom javascript code -->
        <script src="js/plugins.js"></script>
        <script src="js/main.js"></script>

        <!-- Javascript code only for this page -->
        <script>
            $(function () {
                var loginButtons = $('#login-buttons');
                var loginForm = $('#login-form');

                // Reveal login form
                $('#login-btn-email').click(function () {
                    loginButtons.slideUp(600);
                    loginForm.slideDown(450);
                });

                // Hide login form
                $('.login-back').click(function () {
                    loginForm.slideUp(450);
                    loginButtons.slideDown(600);
                });
            });

        </script>
<script type='text/javascript'>
    function Submit() {
        //        alert($("#remember_me"));
        var checked = false;
        if (document.getElementById('remember_me').checked) {
            checked = true;
        } else {
            checked = false;
        }
        PageMethods.Submit($("#login_email").val(),$("#login_password").val(),checked,OnGetMessageSuccess, OnGetMessageFailure);
    }
    function OnGetMessageSuccess(result, userContext, methodName) {
        if (result != "") {
            $("#ltrl_error").show();
            $("#ltrl_error").html(result);
            $("#ltrl_error").fadeOut(8000);
        }
        else {
            document.location = "Default.aspx"; 
        }
    }
    function OnGetMessageFailure(error, userContext, methodName) {
        alert(error.get_message());
    }
    </script>
        </body>

</html>
