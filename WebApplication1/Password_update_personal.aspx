<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Password_update_personal.aspx.cs" Inherits="WebApplication1.Password_update_personal"   MasterPageFile="~/Site.master"  Title="Order Update"%>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <!-- Navigation info -->
    <ul id="nav-info" class="clearfix">
        <li><a href="Default.aspx"><i class="fa fa-home"></i></a></li>
        <li class="active"><a href="Password_update_personal.aspx">Change Password</a></li>
    </ul>

    <div id="form_validation" class="form-horizontal form-box remove-margin">
            <!-- Form Header -->
        <h4 class="form-box-header">Password Update Form <small>Update Password in this Form</small></h4>
        <asp:Literal ID="ltrlmsg" runat="server"></asp:Literal>
        <!-- Form Content -->
		<p align="left" style="margin-left:20px;"><a href="default.aspx" class="btn btn-default"><i class="fa fa-reply"></i> Back</a></p>
        <fieldset class="form" id="signup">
        <div class="form-box-content">
            <div class="form-group">
                <label class="control-label col-md-2" for="val_number">Username </label>
                <div class="col-md-4">
                    <div class="input-group">
						<%=Session["user_name"] %>
                    </div>
                </div>
            </div>


            <div class="form-group">
                <label class="control-label col-md-2" for="val_username">Email </label>
                <div class="col-md-4">
                    <div class="input-group">
						<%=Session["user_email"] %>

                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2" for="val_number">Old Password *</label>
                <div class="col-md-4">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="old_password" CssClass="form-control required" runat="server" 
                            TextMode="Password"></asp:TextBox> 
<!--                        <input type="password" id="old_password" name="old_password" class="form-control">-->
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2" for="val_number">New Password *</label>
                <div class="col-md-4">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="new_password" CssClass="form-control required" runat="server" 
                            TextMode="Password"></asp:TextBox> 
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2" for="val_number">Confirm Password *</label>
                <div class="col-md-4">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="confirm_password" CssClass="form-control required" runat="server" 
                            TextMode="Password"></asp:TextBox> 
                    </div>
                </div>
            </div>
            <div class="form-group form-actions">
                <div class="col-md-10 col-md-offset-2">
                    <button type="reset" class="btn btn-danger"><i class="fa fa-repeat"></i> Reset</button>
                    <button type="submit" class="btn btn-success submit" runat="server" onclick="$('#form1').validateWebForm(); if($(form).valid()) { return true; } else { return false; }" id="btnSubmit" clientidmode="Static"><i class="fa fa-check"></i> Submit</button>
                </div>
            </div>
		<p align="left" style="margin-left:20px;"><a href="default.aspx" class="btn btn-default"><i class="fa fa-reply"></i> Back</a></p>
        </div>
        </fieldset>
        <!-- END Form Content -->
        </div>
<!-- Javascript code only for this page -->
<!-- Javascript code only for this page -->
<script>
/*
    $(function () {

        /* For advanced usage and examples please check out
        *  Jquery Validation   -> https://github.com/jzaefferer/jquery-validation
        */

        /* Initialize Form Validation 
        $('form').validate({
            errorClass: 'help-block',
            errorElement: 'span',
            errorPlacement: function (error, e) {
                e.parents('.form-group > div').append(error);
            },
            highlight: function (e) {
                $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
                $(e).closest('.help-block').remove();
            },
            success: function (e) {
                // You can use the following if you would like to highlight with green color the input after successful validation!
                e.closest('.form-group').removeClass('has-success has-error'); // e.closest('.form-group').removeClass('has-success has-error').addClass('has-success');
                e.closest('.help-block').remove();
                e.closest('.help-inline').remove();
            },
            rules: {
                '<%=old_password.UniqueID %>': {
                    required: true,
                    minlength: 8
                },
                '<%=new_password.UniqueID %>': {
                    required: true,
                    minlength: 8
                },
                '<%=confirm_password.UniqueID %>': {
                    required: true,
                    equalTo: '#<%=new_password.UniqueID %>'
                }
            },
            messages: {
                '<%=old_password.UniqueID %>': {
                    required: 'Please enter Old Password',
                    minlength: 'Your Old Password must consist of at least 8 characters'
                },
                '<%=new_password.UniqueID %>': {
                    required: 'Please enter new Password',
                    minlength: 'Your new Password must consist of at least 8 characters'
                },
                '<%=confirm_password.UniqueID %>': {
                    required: 'Please enter field "Confirm Password"',
                    equalTo: 'Confirm Password must be the same value to New Password'
                }
            }
        });

          $("#<%=btnSubmit.ClientID %>").click(function(evt) {
    // Validate the form and retain the result.
    var isValid = $("form").valid();
 
    // If the form didn't validate, prevent the
    //  form submission.
    if (!isValid)
      evt.preventDefault();
  });
    });
    

    */ 
    
    $(function () {
        $("#form1").validateWebForm();
    });
    
</script>

</asp:Content>