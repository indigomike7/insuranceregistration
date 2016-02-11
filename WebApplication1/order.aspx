<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="WebApplication1.Order"  MasterPageFile="~/Site.master"  Title="Order" %>
<%@ Import Namespace="WebApplication1.BLL" %>
<%@ Import Namespace="WebApplication1.DAL" %>
<%@ Import Namespace="WebApplication1.lang" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<%
    EnOrder enorder = new EnOrder();
    MyOrder   myorder = new MyOrder(); 
//    Response.Write(Session["lang"]);
 %>
    <!-- Navigation info -->
    <ul id="nav-info" class="clearfix">
        <li><a href="Default.aspx"><i class="fa fa-home"></i></a></li>
        <li class="active"><a href="Order.aspx"><%=((string)Session["lang"] == "en") ? enorder.order : myorder.order%></a></li>
    </ul>

        <h3 class="page-header page-header-top"><%=((string) Session["lang"]=="en") ? enorder.order : myorder.order%> <small>Data <%=((string) Session["lang"]=="en") ? enorder.order : myorder.order%></small></h3>
	<div>
	        <a href="OrderUpdate.aspx?action=add_new" id="" class="btn btn-success"><i class="fa fa-plus"></i> Add New <%=((string) Session["lang"]=="en") ? enorder.order : myorder.order%></a>
	</div>
    <table id="order-datatables" class="table table-bordered table-hover">
        <thead>
            <tr>
                <th class="cell-small"></th>
                <th class="cell-small text-center hidden-xs hidden-sm">#</th>
                <th><%=((string) Session["lang"]=="en") ? enorder.order : myorder.order%> Id</th>
                <th><%=((string) Session["lang"]=="en") ? enorder.order_name : myorder.order_name%></th>
                <th><%=((string) Session["lang"]=="en") ? enorder.order_date : myorder.order_date%></th>
                <th>KP Number</th>
                <th>Created By</th>
                <th>Created Date</th>
                <th>Updated By</th>
                <th>Updated Date</th>
            </tr>
        </thead>
        <tbody>
            <% COrder oObj = new COrder();
               List<COrder> oList = new List<COrder>();
               oList = oObj.GetOrderAll();
               if(oList.Count > 0)
               {
                   int i = 1;
                   foreach (COrder order in oList)
                   {
                       
                %>
            <tr id="<% Response.Write(order.order_id); %>">
                <td class="text-center">
					<a href="OrderUpdate.aspx?action=update&id=<% Response.Write(order.order_id); %>" data-toggle="tooltip" title="Edit" class="btn btn-xs btn-success"><i class="fa fa-pencil"></i></a>
					<a href="javascript:;" data-toggle="tooltip" title="Delete"  id="delRow<% Response.Write(order.order_id); %>" class="btn btn-xs btn-danger delRow"><i class="fa fa-times"></i></a>
                <td id="id<% Response.Write(order.order_id); %>"><% Response.Write(order.order_id); %></td>
                <td><% Response.Write(order.order_id); %></td>
                <td><% Response.Write(order.order_name); %></td>
                <td><% Response.Write(order.order_tarikh); %></td>
                <td><% Response.Write(order.order_kp_number); %></td>
                <td><% Response.Write(order.created_by); %></td>
                <td><% Response.Write(order.created_date); %></td>
                <td><% Response.Write(order.updated_by); %></td>
                <td><% Response.Write(order.updated_date); %></td>
				<?php } ?>
            </tr>
            <%
                       i++;
                   } 
               }
            %>
        </tbody>
    </table>
    <!-- END Datatables -->
	<div>
	        <a href="OrderUpdate.aspx?action=add_new" id="" class="btn btn-success"><i class="fa fa-plus"></i> Add New <%=((string) Session["lang"]=="en") ? enorder.order : myorder.order%></a>

						
						<!-- Modal itself -->
            <div id="delete-modal" class="modal">
                <!-- Modal Dialog -->
                <div class="modal-dialog">
                    <!-- Modal Content -->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4>Delete Data</h4>
                        </div>
                        <div class="modal-body">
                            <p>Are you sure you want to delete this data?</p>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-success btn-success-delete" type=button>Yes</button>
                            <button class="btn btn-danger" data-dismiss="modal" type=button>No</button>
                        </div>
                    </div>
                    <!-- END Modal Content -->
                </div>
                <!-- END Modal Dialog -->
            </div>
            <!-- END Modal itself -->

	</div>

    <!-- END Datatables in the grid -->

</div>
<!-- END Page Content -->
<?php include 'inc/footer.php';  ?>
<script type="text/javascript">
    $(function () {

        // Hold our table to a variable
        var exampleDatatable = $('#order-datatables');

        /*
        * Function for handing the data after a cell has been edited
        *
        * From here you can send the data with ajax (for example) to handle in your backend
        *
        */
        var reqHandle = function (value, settings) {

            // this, the edited td element
            console.log(this);

            // $(this).attr('id'), get the id of the edited td
            console.log($(this).attr('id'));

            // $(this).parent('tr').attr('id'), get the id of the row
            console.log($(this).parent('tr').attr('id'));

            // value, the new value the user submitted
            console.log(value);

            // settings, the settings of jEditable
            console.log(settings);

            // Here you can send and handle the data in your backend
            // ...

            // For this example, just return the data the user submitted
            return (value);
        };

        /*
        * Function for initializing jEditable handlers to the table
        *
        * For advance usage you can check http://www.appelsiini.net/projects/jeditable
        *
        */
        var initEditable = function (rowID) {

            // Hold the elements that the jEditable with be initialized
            var elements;

            // If we don't have a rowID apply to all td elements with .editable-td class
            if (!rowID)
                elements = $('td.editable-td', editableTable.fnGetNodes());
            else
                elements = $('td.editable-td', editableTable.fnGetNodes(rowID));

            elements.editable(reqHandle, {
                "callback": function (sValue, y) {
                    // Update the table cell after the edit has been processed
                    var aPos = editableTable.fnGetPosition(this);
                    editableTable.fnUpdate(sValue, aPos[0], aPos[1]);

                    // Little fix for responsive table after edit
                    exampleDatatable.css('width', '100%');
                },
                "submitdata": function (value, settings) {
                    // Sent some extra data
                    return {
                        "row_id": this.parentNode.getAttribute('id'),
                        "column": editableTable.fnGetPosition(this)[2]
                    };
                },
                indicator: '<i class="fa fa-spinner fa-spin"></i>',
                cssclass: 'remove-margin',
                submit: 'Ok',
                cancel: 'Cancel'
            });
        };

        /*
        * Function for deleting table row
        *
        */

        var delHandle = function () {

            // When the user clicks on a delete button
            $('body').on('click', 'a.delRow', function () {

                var aPos = editableTable.fnGetPosition(this.parentNode);
                var aData = editableTable.fnGetData(aPos[0]);
                var rowID = $(this).parents('tr').attr('id');
                $('#delete-modal').modal('show');
                $(".btn-success-delete").click(
					function () {
					    editableTable.fnDeleteRow(aPos[0]);
					    $.ajax
							({
							    url: "order_delete_ajax.aspx"
								, data: "id=" + rowID
								, dataType: "json"
								, method: "POST"
							}).done(function () {
							    //document.location = "order.aspx";
							});

							    $('#delete-modal').modal('hide');

					}
				);
            });
        };

        /*
        * Function for adding table row
        *
        */
        var addHandle = function () {

            // When the user clicks on the 'Add New User' button
            $("#addRow").click(function () {

                // Here you can handle your backend data (eg: adding a row to database and return the id of the row)

                // ..

                // Create a new row and set it up
                var rowID = editableTable.fnAddData(['', '', '', '', '']);

                // Example id, here you should add the one you created in your backend
                var id = rowID[0] + 1;

                // Update the id cell, so that our table redraw and resort (new row goes first in datatable)
                editableTable.fnUpdate(id, rowID[0], 1);

                // Get the new row
                var nRow = editableTable.fnGetNodes(rowID[0]);

                /*
                * In the following section you should set up your cells
                */
                // Add id to tr element
                $(nRow).attr('id', id);

                // Setup first cell with the delete button
                $(nRow)
                    .children('td:nth-child(1)')
                    .addClass('text-center')
                    .html('<a href="javascript:void(0)" id="delRow' + id + '" class="btn btn-xs btn-danger delRow"><i class="fa fa-times"></i></a>');

                // Setup second cell (id)
                $(nRow)
                    .children('td:nth-child(2)')
                    .attr('id', 'id' + id)
                    .addClass('text-center');

                // Setup third cell (username)
                $(nRow)
                    .children('td:nth-child(3)')
                    .addClass('editable-td')
                    .attr('id', 'username' + id);

                // Setup fourth cell (email)
                $(nRow)
                    .children('td:nth-child(4)')
                    .addClass('editable-td')
                    .addClass('hidden-xs hidden-sm')
                    .attr('id', 'email' + id);

                // Setup fifth cell (notes)
                $(nRow)
                    .children('td:nth-child(5)')
                    .addClass('editable-td')
                    .addClass('hidden-xs hidden-sm')
                    .attr('id', 'notes' + id);

                // Setup your other cells the same way (if you have more)
                // ...

                // Initialize jEditable to the new row
                initEditable(rowID[0]);

                // Little fix for responsive table after adding a new row
                exampleDatatable.css('width', '100%');
            });
        };

        // Initialize Datatables
        var editableTable = exampleDatatable.dataTable({
            "aaSorting": [[1, 'desc']],
            "aoColumnDefs": [{
                "bSortable": false,
                "aTargets": [0]
            }]
        });
        $('.dataTables_filter input').addClass('form-control').attr('placeholder', 'Search');

        // Initialize jEditable
        initEditable();

        // Handle rows deletion
        delHandle();

        // Handle new rows
        addHandle();
    });
</script>


</asp:Content>

