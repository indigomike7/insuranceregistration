<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderReport.aspx.cs" Inherits="WebApplication1.OrderReport"  MasterPageFile="~/Site.master"  Title="Order Report" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <!-- Navigation info -->
    <ul id="nav-info" class="clearfix">
        <li><a href="Default.aspx"><i class="fa fa-home"></i></a></li>
        <li class="active"><a href="Order.aspx">Order</a></li>
        <li class="active"><a href="OrderReport.aspx">Report</a></li>
    </ul>

    <div id="form_validation" class="form-horizontal form-box remove-margin">
            <!-- Form Header -->
        <h4 class="form-box-header">Order Report <small>Generate Report here</small></h4>
		<p align="left" style="margin-left:20px;"><a href="order.aspx" class="btn btn-default"><i class="fa fa-reply"></i> Back</a></p>
        <asp:Literal ID="ltrlmsg" runat="server"></asp:Literal>
        <!-- Form Content -->
        <fieldset class="form" id="signup">
        <div class="form-box-content">
           <div class="form-group">
                <label class="control-label col-md-2" for="val_date">Start From *</label>
                <div class="col-md-2">
                    <div class="input-group date input-datepicker" data-date="javascript:document.write(date_now());" data-date-format="mm-dd-yyyy">
                        <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                        <asp:TextBox ID="start_from" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
           <div class="form-group">
                <label class="control-label col-md-2" for="val_date">End To *</label>
                <div class="col-md-2">
                    <div class="input-group date input-datepicker" data-date="javascript:document.write(date_now());" data-date-format="mm-dd-yyyy">
                        <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                        <asp:TextBox ID="end_to" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
            <div class="form-group form-actions">
                <div class="col-md-10 col-md-offset-2">
                    <button type="reset" class="btn btn-danger"><i class="fa fa-repeat"></i> Reset</button>
                    <button id="Button1" type="submit" class="btn btn-success submit" runat="server" onclick="$('#form1').validateWebForm(); if($(form).valid()) { return true; } else { return false; }"  ><i class="fa fa-check"></i> Submit</button>
                    <br />
                    <br />
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                        AutoDataBind="true" />
                </div>
            </div>
        </div>
		<p align="left" style="margin-left:20px;"><a href="order.aspx" class="btn btn-default"><i class="fa fa-reply"></i> Back</a></p>
        <!-- END Form Content -->
        </fieldset>
        </div>
<!-- Javascript code only for this page -->
<script>
    $(function () {
        $("#form1").validateWebForm();
    });

    function datenow() {
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!

        var yyyy = today.getFullYear();
        if (dd < 10) {
            dd = '0' + dd
        }
        if (mm < 10) {
            mm = '0' + mm
        }
        var today = dd + '/' + mm + '/' + yyyy;
        return today;
    }
    function Submit() {
        //        alert($("#remember_me"));
        var checked = false;
        /*        if (document.getElementById('').checked) {
        checked = true;
        } else {
        checked = false;
        }
        */
        PageMethods.Submit($("#full_name").val(), $("#address").val(), $("#address").val(), OnGetMessageSuccess, OnGetMessageFailure);
    }
    function OnGetMessageSuccess(result, userContext, methodName) {
        if (result != "") {
            $("#ltrl_error").show();
            $("#ltrl_error").html(result);
            $("#ltrl_error").fadeOut(8000);
        }
        else {
            document.location = "order.aspx";
        }
    }
    function OnGetMessageFailure(error, userContext, methodName) {
        alert(error.get_message());
    }
</script>

</asp:Content>