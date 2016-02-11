<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderUpdate.aspx.cs" Inherits="WebApplication1.OrderUpdate"  MasterPageFile="~/Site.master"  Title="Order Update"%>
<%@ Import Namespace="WebApplication1.lang" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<%
    EnOrder enorder = new EnOrder();
    MyOrder   myorder = new MyOrder(); 
//    Response.Write(Session["lang"]);
 %>    <!-- Navigation info -->
    <ul id="nav-info" class="clearfix">
        <li><a href="Default.aspx"><i class="fa fa-home"></i></a></li>
        <li class="active"><a href="Order.aspx"><%=((string)Session["lang"] == "en") ? enorder.order : myorder.order%></a></li>
    </ul>

    <div id="form_validation" class="form-horizontal form-box remove-margin">
            <!-- Form Header -->
        <h4 class="form-box-header"><%=((string)Session["lang"] == "en") ? enorder.order : myorder.order%> <small>Insert / Update <%=((string)Session["lang"] == "en") ? enorder.order : myorder.order%> in this Form</small></h4>
		<p align="left" style="margin-left:20px;"><a href="order.aspx" class="btn btn-default"><i class="fa fa-reply"></i> Back</a></p>
        <asp:Literal ID="ltrlmsg" runat="server"></asp:Literal>
        <!-- Form Content -->
        <fieldset class="form" id="signup">
        <div class="form-box-content">
            <div class="form-group">
                <label class="control-label col-md-2" for="full_name">Full Name *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="full_name" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2" for="adress">Address *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="address" CssClass="form-control required" ClientIDMode="Static" runat="server" TextMode="MultiLine"></asp:TextBox> 
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2" for="zip_code">ZIP Code *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="zip_code" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2" for="zip_code">Area *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="area" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2" for="zip_code">Country *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:DropDownList ID="country" ClientIDMode="Static" CssClass="form-control required" runat="server">
                            <asp:ListItem value="">Country...</asp:ListItem>
                            <asp:ListItem value="Afganistan">Afghanistan</asp:ListItem>
                            <asp:ListItem value="Albania">Albania</asp:ListItem>
                            <asp:ListItem value="Algeria">Algeria</asp:ListItem>
                            <asp:ListItem value="American Samoa">American Samoa</asp:ListItem>
                            <asp:ListItem value="Andorra">Andorra</asp:ListItem>
                            <asp:ListItem value="Angola">Angola</asp:ListItem>
                            <asp:ListItem value="Anguilla">Anguilla</asp:ListItem>
                            <asp:ListItem value="Antigua &amp; Barbuda">Antigua &amp; Barbuda</asp:ListItem>
                            <asp:ListItem value="Argentina">Argentina</asp:ListItem>
                            <asp:ListItem value="Armenia">Armenia</asp:ListItem>
                            <asp:ListItem value="Aruba">Aruba</asp:ListItem>
                            <asp:ListItem value="Australia">Australia</asp:ListItem>
                            <asp:ListItem value="Austria">Austria</asp:ListItem>
                            <asp:ListItem value="Azerbaijan">Azerbaijan</asp:ListItem>
                            <asp:ListItem value="Bahamas">Bahamas</asp:ListItem>
                            <asp:ListItem value="Bahrain">Bahrain</asp:ListItem>
                            <asp:ListItem value="Bangladesh">Bangladesh</asp:ListItem>
                            <asp:ListItem value="Barbados">Barbados</asp:ListItem>
                            <asp:ListItem value="Belarus">Belarus</asp:ListItem>
                            <asp:ListItem value="Belgium">Belgium</asp:ListItem>
                            <asp:ListItem value="Belize">Belize</asp:ListItem>
                            <asp:ListItem value="Benin">Benin</asp:ListItem>
                            <asp:ListItem value="Bermuda">Bermuda</asp:ListItem>
                            <asp:ListItem value="Bhutan">Bhutan</asp:ListItem>
                            <asp:ListItem value="Bolivia">Bolivia</asp:ListItem>
                            <asp:ListItem value="Bonaire">Bonaire</asp:ListItem>
                            <asp:ListItem value="Bosnia &amp; Herzegovina">Bosnia &amp; Herzegovina</asp:ListItem>
                            <asp:ListItem value="Botswana">Botswana</asp:ListItem>
                            <asp:ListItem value="Brazil">Brazil</asp:ListItem>
                            <asp:ListItem value="British Indian Ocean Ter">British Indian Ocean Ter</asp:ListItem>
                            <asp:ListItem value="Brunei">Brunei</asp:ListItem>
                            <asp:ListItem value="Bulgaria">Bulgaria</asp:ListItem>
                            <asp:ListItem value="Burkina Faso">Burkina Faso</asp:ListItem>
                            <asp:ListItem value="Burundi">Burundi</asp:ListItem>
                            <asp:ListItem value="Cambodia">Cambodia</asp:ListItem>
                            <asp:ListItem value="Cameroon">Cameroon</asp:ListItem>
                            <asp:ListItem value="Canada">Canada</asp:ListItem>
                            <asp:ListItem value="Canary Islands">Canary Islands</asp:ListItem>
                            <asp:ListItem value="Cape Verde">Cape Verde</asp:ListItem>
                            <asp:ListItem value="Cayman Islands">Cayman Islands</asp:ListItem>
                            <asp:ListItem value="Central African Republic">Central African Republic</asp:ListItem>
                            <asp:ListItem value="Chad">Chad</asp:ListItem>
                            <asp:ListItem value="Channel Islands">Channel Islands</asp:ListItem>
                            <asp:ListItem value="Chile">Chile</asp:ListItem>
                            <asp:ListItem value="China">China</asp:ListItem>
                            <asp:ListItem value="Christmas Island">Christmas Island</asp:ListItem>
                            <asp:ListItem value="Cocos Island">Cocos Island</asp:ListItem>
                            <asp:ListItem value="Colombia">Colombia</asp:ListItem>
                            <asp:ListItem value="Comoros">Comoros</asp:ListItem>
                            <asp:ListItem value="Congo">Congo</asp:ListItem>
                            <asp:ListItem value="Cook Islands">Cook Islands</asp:ListItem>
                            <asp:ListItem value="Costa Rica">Costa Rica</asp:ListItem>
                            <asp:ListItem value="Cote DIvoire">Cote D'Ivoire</asp:ListItem>
                            <asp:ListItem value="Croatia">Croatia</asp:ListItem>
                            <asp:ListItem value="Cuba">Cuba</asp:ListItem>
                            <asp:ListItem value="Curaco">Curacao</asp:ListItem>
                            <asp:ListItem value="Cyprus">Cyprus</asp:ListItem>
                            <asp:ListItem value="Czech Republic">Czech Republic</asp:ListItem>
                            <asp:ListItem value="Denmark">Denmark</asp:ListItem>
                            <asp:ListItem value="Djibouti">Djibouti</asp:ListItem>
                            <asp:ListItem value="Dominica">Dominica</asp:ListItem>
                            <asp:ListItem value="Dominican Republic">Dominican Republic</asp:ListItem>
                            <asp:ListItem value="East Timor">East Timor</asp:ListItem>
                            <asp:ListItem value="Ecuador">Ecuador</asp:ListItem>
                            <asp:ListItem value="Egypt">Egypt</asp:ListItem>
                            <asp:ListItem value="El Salvador">El Salvador</asp:ListItem>
                            <asp:ListItem value="Equatorial Guinea">Equatorial Guinea</asp:ListItem>
                            <asp:ListItem value="Eritrea">Eritrea</asp:ListItem>
                            <asp:ListItem value="Estonia">Estonia</asp:ListItem>
                            <asp:ListItem value="Ethiopia">Ethiopia</asp:ListItem>
                            <asp:ListItem value="Falkland Islands">Falkland Islands</asp:ListItem>
                            <asp:ListItem value="Faroe Islands">Faroe Islands</asp:ListItem>
                            <asp:ListItem value="Fiji">Fiji</asp:ListItem>
                            <asp:ListItem value="Finland">Finland</asp:ListItem>
                            <asp:ListItem value="France">France</asp:ListItem>
                            <asp:ListItem value="French Guiana">French Guiana</asp:ListItem>
                            <asp:ListItem value="French Polynesia">French Polynesia</asp:ListItem>
                            <asp:ListItem value="French Southern Ter">French Southern Ter</asp:ListItem>
                            <asp:ListItem value="Gabon">Gabon</asp:ListItem>
                            <asp:ListItem value="Gambia">Gambia</asp:ListItem>
                            <asp:ListItem value="Georgia">Georgia</asp:ListItem>
                            <asp:ListItem value="Germany">Germany</asp:ListItem>
                            <asp:ListItem value="Ghana">Ghana</asp:ListItem>
                            <asp:ListItem value="Gibraltar">Gibraltar</asp:ListItem>
                            <asp:ListItem value="Great Britain">Great Britain</asp:ListItem>
                            <asp:ListItem value="Greece">Greece</asp:ListItem>
                            <asp:ListItem value="Greenland">Greenland</asp:ListItem>
                            <asp:ListItem value="Grenada">Grenada</asp:ListItem>
                            <asp:ListItem value="Guadeloupe">Guadeloupe</asp:ListItem>
                            <asp:ListItem value="Guam">Guam</asp:ListItem>
                            <asp:ListItem value="Guatemala">Guatemala</asp:ListItem>
                            <asp:ListItem value="Guinea">Guinea</asp:ListItem>
                            <asp:ListItem value="Guyana">Guyana</asp:ListItem>
                            <asp:ListItem value="Haiti">Haiti</asp:ListItem>
                            <asp:ListItem value="Hawaii">Hawaii</asp:ListItem>
                            <asp:ListItem value="Honduras">Honduras</asp:ListItem>
                            <asp:ListItem value="Hong Kong">Hong Kong</asp:ListItem>
                            <asp:ListItem value="Hungary">Hungary</asp:ListItem>
                            <asp:ListItem value="Iceland">Iceland</asp:ListItem>
                            <asp:ListItem value="India">India</asp:ListItem>
                            <asp:ListItem value="Indonesia">Indonesia</asp:ListItem>
                            <asp:ListItem value="Iran">Iran</asp:ListItem>
                            <asp:ListItem value="Iraq">Iraq</asp:ListItem>
                            <asp:ListItem value="Ireland">Ireland</asp:ListItem>
                            <asp:ListItem value="Isle of Man">Isle of Man</asp:ListItem>
                            <asp:ListItem value="Israel">Israel</asp:ListItem>
                            <asp:ListItem value="Italy">Italy</asp:ListItem>
                            <asp:ListItem value="Jamaica">Jamaica</asp:ListItem>
                            <asp:ListItem value="Japan">Japan</asp:ListItem>
                            <asp:ListItem value="Jordan">Jordan</asp:ListItem>
                            <asp:ListItem value="Kazakhstan">Kazakhstan</asp:ListItem>
                            <asp:ListItem value="Kenya">Kenya</asp:ListItem>
                            <asp:ListItem value="Kiribati">Kiribati</asp:ListItem>
                            <asp:ListItem value="Korea North">Korea North</asp:ListItem>
                            <asp:ListItem value="Korea Sout">Korea South</asp:ListItem>
                            <asp:ListItem value="Kuwait">Kuwait</asp:ListItem>
                            <asp:ListItem value="Kyrgyzstan">Kyrgyzstan</asp:ListItem>
                            <asp:ListItem value="Laos">Laos</asp:ListItem>
                            <asp:ListItem value="Latvia">Latvia</asp:ListItem>
                            <asp:ListItem value="Lebanon">Lebanon</asp:ListItem>
                            <asp:ListItem value="Lesotho">Lesotho</asp:ListItem>
                            <asp:ListItem value="Liberia">Liberia</asp:ListItem>
                            <asp:ListItem value="Libya">Libya</asp:ListItem>
                            <asp:ListItem value="Liechtenstein">Liechtenstein</asp:ListItem>
                            <asp:ListItem value="Lithuania">Lithuania</asp:ListItem>
                            <asp:ListItem value="Luxembourg">Luxembourg</asp:ListItem>
                            <asp:ListItem value="Macau">Macau</asp:ListItem>
                            <asp:ListItem value="Macedonia">Macedonia</asp:ListItem>
                            <asp:ListItem value="Madagascar">Madagascar</asp:ListItem>
                            <asp:ListItem value="Malaysia">Malaysia</asp:ListItem>
                            <asp:ListItem value="Malawi">Malawi</asp:ListItem>
                            <asp:ListItem value="Maldives">Maldives</asp:ListItem>
                            <asp:ListItem value="Mali">Mali</asp:ListItem>
                            <asp:ListItem value="Malta">Malta</asp:ListItem>
                            <asp:ListItem value="Marshall Islands">Marshall Islands</asp:ListItem>
                            <asp:ListItem value="Martinique">Martinique</asp:ListItem>
                            <asp:ListItem value="Mauritania">Mauritania</asp:ListItem>
                            <asp:ListItem value="Mauritius">Mauritius</asp:ListItem>
                            <asp:ListItem value="Mayotte">Mayotte</asp:ListItem>
                            <asp:ListItem value="Mexico">Mexico</asp:ListItem>
                            <asp:ListItem value="Midway Islands">Midway Islands</asp:ListItem>
                            <asp:ListItem value="Moldova">Moldova</asp:ListItem>
                            <asp:ListItem value="Monaco">Monaco</asp:ListItem>
                            <asp:ListItem value="Mongolia">Mongolia</asp:ListItem>
                            <asp:ListItem value="Montserrat">Montserrat</asp:ListItem>
                            <asp:ListItem value="Morocco">Morocco</asp:ListItem>
                            <asp:ListItem value="Mozambique">Mozambique</asp:ListItem>
                            <asp:ListItem value="Myanmar">Myanmar</asp:ListItem>
                            <asp:ListItem value="Nambia">Nambia</asp:ListItem>
                            <asp:ListItem value="Nauru">Nauru</asp:ListItem>
                            <asp:ListItem value="Nepal">Nepal</asp:ListItem>
                            <asp:ListItem value="Netherland Antilles">Netherland Antilles</asp:ListItem>
                            <asp:ListItem value="Netherlands">Netherlands (Holland, Europe)</asp:ListItem>
                            <asp:ListItem value="Nevis">Nevis</asp:ListItem>
                            <asp:ListItem value="New Caledonia">New Caledonia</asp:ListItem>
                            <asp:ListItem value="New Zealand">New Zealand</asp:ListItem>
                            <asp:ListItem value="Nicaragua">Nicaragua</asp:ListItem>
                            <asp:ListItem value="Niger">Niger</asp:ListItem>
                            <asp:ListItem value="Nigeria">Nigeria</asp:ListItem>
                            <asp:ListItem value="Niue">Niue</asp:ListItem>
                            <asp:ListItem value="Norfolk Island">Norfolk Island</asp:ListItem>
                            <asp:ListItem value="Norway">Norway</asp:ListItem>
                            <asp:ListItem value="Oman">Oman</asp:ListItem>
                            <asp:ListItem value="Pakistan">Pakistan</asp:ListItem>
                            <asp:ListItem value="Palau Island">Palau Island</asp:ListItem>
                            <asp:ListItem value="Palestine">Palestine</asp:ListItem>
                            <asp:ListItem value="Panama">Panama</asp:ListItem>
                            <asp:ListItem value="Papua New Guinea">Papua New Guinea</asp:ListItem>
                            <asp:ListItem value="Paraguay">Paraguay</asp:ListItem>
                            <asp:ListItem value="Peru">Peru</asp:ListItem>
                            <asp:ListItem value="Phillipines">Philippines</asp:ListItem>
                            <asp:ListItem value="Pitcairn Island">Pitcairn Island</asp:ListItem>
                            <asp:ListItem value="Poland">Poland</asp:ListItem>
                            <asp:ListItem value="Portugal">Portugal</asp:ListItem>
                            <asp:ListItem value="Puerto Rico">Puerto Rico</asp:ListItem>
                            <asp:ListItem value="Qatar">Qatar</asp:ListItem>
                            <asp:ListItem value="Republic of Montenegro">Republic of Montenegro</asp:ListItem>
                            <asp:ListItem value="Republic of Serbia">Republic of Serbia</asp:ListItem>
                            <asp:ListItem value="Reunion">Reunion</asp:ListItem>
                            <asp:ListItem value="Romania">Romania</asp:ListItem>
                            <asp:ListItem value="Russia">Russia</asp:ListItem>
                            <asp:ListItem value="Rwanda">Rwanda</asp:ListItem>
                            <asp:ListItem value="St Barthelemy">St Barthelemy</asp:ListItem>
                            <asp:ListItem value="St Eustatius">St Eustatius</asp:ListItem>
                            <asp:ListItem value="St Helena">St Helena</asp:ListItem>
                            <asp:ListItem value="St Kitts-Nevis">St Kitts-Nevis</asp:ListItem>
                            <asp:ListItem value="St Lucia">St Lucia</asp:ListItem>
                            <asp:ListItem value="St Maarten">St Maarten</asp:ListItem>
                            <asp:ListItem value="St Pierre &amp; Miquelon">St Pierre &amp; Miquelon</asp:ListItem>
                            <asp:ListItem value="St Vincent &amp; Grenadines">St Vincent &amp; Grenadines</asp:ListItem>
                            <asp:ListItem value="Saipan">Saipan</asp:ListItem>
                            <asp:ListItem value="Samoa">Samoa</asp:ListItem>
                            <asp:ListItem value="Samoa American">Samoa American</asp:ListItem>
                            <asp:ListItem value="San Marino">San Marino</asp:ListItem>
                            <asp:ListItem value="Sao Tome &amp; Principe">Sao Tome &amp; Principe</asp:ListItem>
                            <asp:ListItem value="Saudi Arabia">Saudi Arabia</asp:ListItem>
                            <asp:ListItem value="Senegal">Senegal</asp:ListItem>
                            <asp:ListItem value="Serbia">Serbia</asp:ListItem>
                            <asp:ListItem value="Seychelles">Seychelles</asp:ListItem>
                            <asp:ListItem value="Sierra Leone">Sierra Leone</asp:ListItem>
                            <asp:ListItem value="Singapore">Singapore</asp:ListItem>
                            <asp:ListItem value="Slovakia">Slovakia</asp:ListItem>
                            <asp:ListItem value="Slovenia">Slovenia</asp:ListItem>
                            <asp:ListItem value="Solomon Islands">Solomon Islands</asp:ListItem>
                            <asp:ListItem value="Somalia">Somalia</asp:ListItem>
                            <asp:ListItem value="South Africa">South Africa</asp:ListItem>
                            <asp:ListItem value="Spain">Spain</asp:ListItem>
                            <asp:ListItem value="Sri Lanka">Sri Lanka</asp:ListItem>
                            <asp:ListItem value="Sudan">Sudan</asp:ListItem>
                            <asp:ListItem value="Suriname">Suriname</asp:ListItem>
                            <asp:ListItem value="Swaziland">Swaziland</asp:ListItem>
                            <asp:ListItem value="Sweden">Sweden</asp:ListItem>
                            <asp:ListItem value="Switzerland">Switzerland</asp:ListItem>
                            <asp:ListItem value="Syria">Syria</asp:ListItem>
                            <asp:ListItem value="Tahiti">Tahiti</asp:ListItem>
                            <asp:ListItem value="Taiwan">Taiwan</asp:ListItem>
                            <asp:ListItem value="Tajikistan">Tajikistan</asp:ListItem>
                            <asp:ListItem value="Tanzania">Tanzania</asp:ListItem>
                            <asp:ListItem value="Thailand">Thailand</asp:ListItem>
                            <asp:ListItem value="Togo">Togo</asp:ListItem>
                            <asp:ListItem value="Tokelau">Tokelau</asp:ListItem>
                            <asp:ListItem value="Tonga">Tonga</asp:ListItem>
                            <asp:ListItem value="Trinidad &amp; Tobago">Trinidad &amp; Tobago</asp:ListItem>
                            <asp:ListItem value="Tunisia">Tunisia</asp:ListItem>
                            <asp:ListItem value="Turkey">Turkey</asp:ListItem>
                            <asp:ListItem value="Turkmenistan">Turkmenistan</asp:ListItem>
                            <asp:ListItem value="Turks &amp; Caicos Is">Turks &amp; Caicos Is</asp:ListItem>
                            <asp:ListItem value="Tuvalu">Tuvalu</asp:ListItem>
                            <asp:ListItem value="Uganda">Uganda</asp:ListItem>
                            <asp:ListItem value="Ukraine">Ukraine</asp:ListItem>
                            <asp:ListItem value="United Arab Erimates">United Arab Emirates</asp:ListItem>
                            <asp:ListItem value="United Kingdom">United Kingdom</asp:ListItem>
                            <asp:ListItem value="United States of America">United States of America</asp:ListItem>
                            <asp:ListItem value="Uraguay">Uruguay</asp:ListItem>
                            <asp:ListItem value="Uzbekistan">Uzbekistan</asp:ListItem>
                            <asp:ListItem value="Vanuatu">Vanuatu</asp:ListItem>
                            <asp:ListItem value="Vatican City State">Vatican City State</asp:ListItem>
                            <asp:ListItem value="Venezuela">Venezuela</asp:ListItem>
                            <asp:ListItem value="Vietnam">Vietnam</asp:ListItem>
                            <asp:ListItem value="Virgin Islands (Brit)">Virgin Islands (Brit)</asp:ListItem>
                            <asp:ListItem value="Virgin Islands (USA)">Virgin Islands (USA)</asp:ListItem>
                            <asp:ListItem value="Wake Island">Wake Island</asp:ListItem>
                            <asp:ListItem value="Wallis &amp; Futana Is">Wallis &amp; Futana Is</asp:ListItem>
                            <asp:ListItem value="Yemen">Yemen</asp:ListItem>
                            <asp:ListItem value="Zaire">Zaire</asp:ListItem>
                            <asp:ListItem value="Zambia">Zambia</asp:ListItem>
                            <asp:ListItem value="Zimbabwe">Zimbabwe</asp:ListItem>

                        </asp:DropDownList> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Phone *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="phone" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Mobile Phone *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="mobile_phone" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">ID Card Number *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="id_card_number" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
           <div class="form-group">
                <label class="control-label col-md-2" for="val_date">Birth Date *</label>
                <div class="col-md-2">
                    <div class="input-group date input-datepicker" data-date="javascript:document.write(date_now());" data-date-format="mm-dd-yyyy">
                        <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                        <asp:TextBox ID="birth_date" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Height *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="height" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Weight *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="weight" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Gender *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:RadioButtonList  ID="gender" CssClass="form-control required" ClientIDMode="Static" runat="server">
                            <asp:ListItem Text="Male" Value="male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="female"></asp:ListItem>
                        </asp:RadioButtonList> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Marriage Status *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:RadioButtonList ID="marriage_status" CssClass="form-control required" ClientIDMode="Static" runat="server">
                            <asp:ListItem Text="Single" Value="single"></asp:ListItem>
                            <asp:ListItem Text="Married" Value="married"></asp:ListItem>
                            <asp:ListItem Text="Divorce" Value="divorce"></asp:ListItem>
                        </asp:RadioButtonList> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Haji ? *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:RadioButtonList ID="haji" CssClass="form-control required" ClientIDMode="Static" runat="server">
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="0"></asp:ListItem>
                        </asp:RadioButtonList> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Inherit Name *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="pewaris_name" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Inherit ID Card Number *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="pewaris_id_card_number" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Inherit Relation *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="pewaris_relation" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Inherit Gender *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:RadioButtonList ID="pewaris_gender" CssClass="form-control required" ClientIDMode="Static" runat="server">
                            <asp:ListItem Text="Male" Value="male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="female"></asp:ListItem>
                        </asp:RadioButtonList> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Inherit Phone *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="pewaris_phone" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Inherit Payment For *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="pewaris_payment_for" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Amount *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="order_money" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Cheque Number *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="check_number" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone"><%=((string)Session["lang"] == "en") ? enorder.order_name : myorder.order_name%> *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="order_name" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
           <div class="form-group">
                <label class="control-label col-md-2" for="val_date"><%=((string)Session["lang"] == "en") ? enorder.order_date : myorder.order_date%> *</label>
                <div class="col-md-2">
                    <div class="input-group date input-datepicker" data-date="javascript:document.write(date_now());" data-date-format="mm-dd-yyyy">
                        <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                        <asp:TextBox ID="order_tarikh" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">KP Number *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="order_kp_number" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Representative Name *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="wakil_name" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
           <div class="form-group">
                <label class="control-label col-md-2" for="val_date">Representative Date *</label>
                <div class="col-md-2">
                    <div class="input-group date input-datepicker" data-date="javascript:document.write(date_now());" data-date-format="mm-dd-yyyy">
                        <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                        <asp:TextBox ID="wakil_tarikh" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2" for="phone">Representative Code *</label>
                <div class="col-md-3">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-asterisk fa-fw"></i></span>
                        <asp:TextBox ID="wakil_code" CssClass="form-control required" ClientIDMode="Static" runat="server"></asp:TextBox> 
                    </div>
                </div>
            </div>
            <div class="form-group form-actions">
                <div class="col-md-10 col-md-offset-2">
                    <button type="reset" class="btn btn-danger"><i class="fa fa-repeat"></i> Reset</button>
                    <button type="submit" class="btn btn-success submit" runat="server" onclick="$('#form1').validateWebForm(); if($(form).valid()) { return true; } else { return false; }"  ><i class="fa fa-check"></i> Submit</button>
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

        /* For advanced usage and examples please check out
        *  Jquery Validation   -> https://github.com/jzaefferer/jquery-validation
        */

        /* Initialize Form Validation 
        $('#form1').validate({
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
                Submit();
            },
            rules: {
                <%=full_name.UniqueID %>: {
                    required: true,
                    minlength: 3
                },
                <%=address.UniqueID %>: {
                    required: true,
                    minlength: 3
                },
                <%=zip_code.UniqueID %>: {
                    required: true,
                    minlength: 3,
                    digits:true
                },
                <%=area.UniqueID %>: {
                    required: true,
                    minlength:3
                },
                <%=country.UniqueID %>: {
                    required: true
                },
                <%=phone.UniqueID %>: {
                    required: true,
                    minlength:3,
                    digits:true
                },
                <%=mobile_phone.UniqueID %>: {
                    required: true,
                    minlength: 3,
                    digits:true
                },
                <%=id_card_number.UniqueID %>: {
                    required: true,
                    minlength: 3
                },
                <%=birth_date.UniqueID %>: {
                    required: true,
                    date: true
                },
                <%=height.UniqueID %>: {
                    required: true,
                },
                <%=weight.UniqueID %>: {
                    required: true
                },
                <%=gender.UniqueID %>: {
                    required: true
                },
                <%=marriage_status.UniqueID %>: {
                    required: true
                },
                <%=haji.UniqueID %>: {
                    required: true
                },
                <%=pewaris_name.UniqueID %>: {
                    required: true,
                    minlength: 3
                },
                <%=pewaris_id_card_number.UniqueID %>: {
                    required: true,
                    minlength: 3
                },
                <%=pewaris_relation.UniqueID %>: {
                    required: true,
                    minlength: 3
                },
                <%=pewaris_gender.UniqueID %>: {
                    required: true
                },
                <%=pewaris_phone.UniqueID %>: {
                    required: true,
                    minlength: 3,
                    digits:true
                },
                <%=pewaris_payment_for.UniqueID %>: {
                    required: true,
                    minlength: 3
                },
                <%=order_money.UniqueID %>: {
                    required: true,
                    minlength: 3
                },
                <%=check_number.UniqueID %>: {
                    required: true,
                    minlength: 3
                },
                <%=order_name.UniqueID %>: {
                    required: true,
                    minlength: 3
                },
                <%=order_tarikh.UniqueID %>: {
                    required: true,
                    date: true
                },
                <%=order_kp_number.UniqueID %>: {
                    required: true,
                    minlength: 3
                },
                <%=wakil_name.UniqueID %>: {
                    required: true,
                    minlength: 3
                },
                <%=wakil_tarikh.UniqueID %>: {
                    required: true,
                    date:true
                },
                <%=wakil_code.UniqueID %>: {
                    required: true,
                    minlength: 3
                }
            },
            messages: {
                <%=full_name.UniqueID %>: {
                    required: "Full Name is required",
                    minlength: "Minimum Full Name length is 3 character"
                },
                <%=address.UniqueID %>: {
                    required: "Address is required",
                    minlength: "Minimum Address length is 3 character"
                },
                <%=zip_code.UniqueID %>: {
                    required: "ZIP Code is required",
                    minlength: "Minimum ZIP Code length is 3 digits",
                    digits:"ZIP Code is digits"
                },
                <%=area.UniqueID %>: {
                    required: "Area is required",
                    minlength:"Minimum Area length is 3 character"
                },
                <%=country.UniqueID %>: {
                    required: "Country is required"
                },
                <%=phone.UniqueID %>: {
                    required: "Phone is required",
                    minlength:"Minimum Phone length is 3 digits",
                    digits:"Phone is digits"
                },
                <%=mobile_phone.UniqueID %>: {
                    required: "Phone is required",
                    minlength: "Minimum Phone length is 3 digits",
                    digits:"Phone is digits"
                },
                <%=id_card_number.UniqueID %>: {
                    required: "ID Card Number is required",
                    minlength: "Minimum ID Card length is 3 character"
                },
                <%=birth_date.UniqueID %>: {
                    required: "Birth Date is required",
                    date: "Format Birth Date is invalid"
                },
                <%=height.UniqueID %>: {
                    required: "Height is required",
                },
                <%=weight.UniqueID %>: {
                    required: "Weight is required"
                },
                <%=gender.UniqueID %>: {
                    required: "Gender is required"
                },
                <%=marriage_status.UniqueID %>: {
                    required: "Marriage is required"
                },
                <%=haji.UniqueID %>: {
                    required: "Haji is Required"
                },
                <%=pewaris_name.UniqueID %>: {
                    required: "Inherit Name is required",
                    minlength: "Minimum Inherit Name length is 3 character"
                },
                <%=pewaris_id_card_number.UniqueID %>: {
                    required: "Inherit ID Card Number is required",
                    minlength: "Minimum ID Card Number length is 3 character"
                },
                <%=pewaris_relation.UniqueID %>: {
                    required: "Inherit Relation is required",
                    minlength: "Minimum Inherit Relation length is 3 character"
                },
                <%=pewaris_gender.UniqueID %>: {
                    required: "Gender is required"
                },
                <%=pewaris_phone.UniqueID %>: {
                    required: "Inherit phone is required",
                    minlength: "Minimum Inherit phone length is 3 character",
                    digits:""
                },
                <%=pewaris_payment_for.UniqueID %>: {
                    required: "Payment for is required",
                    minlength: "Minimum Payment for is 3 character"
                },
                <%=order_money.UniqueID %>: {
                    required: "Amount is required",
                    minlength: "Minimum amount length is 3 digits"
                },
                <%=check_number.UniqueID %>: {
                    required: "Cheque is required",
                    minlength: "Minimum Cheque Number length is 3 character"
                },
                <%=order_name.UniqueID %>: {
                    required: "Order Name is required",
                    minlength: "Minimum Order Name is required"
                },
                <%=order_tarikh.UniqueID %>: {
                    required: "Order Date is required",
                    date: "Format Order date is invalid"
                },
                <%=order_kp_number.UniqueID %>: {
                    required: "KP Number is required",
                    minlength: "Minimum KP Number length is 3 character"
                },
                <%=wakil_name.UniqueID %>: {
                    required: "Representative is required",
                    minlength: "Minimum Representative Name length is 3 character"
                },
                <%=wakil_tarikh.UniqueID %>: {
                    required: "Representative code is required",
                    date:"Format Representative Date is invalid"
                },
                <%=wakil_code.UniqueID %>: {
                    required: "Wakil Code is required",
                    minlength: "Minimum Representative Code length is 3 character"
                }
            }
        });*/



    });

    $(function () {
        $("#form1").validateWebForm();
    });

    function datenow() 
    {
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
        PageMethods.Submit($("#full_name").val(),$("#address").val(),$("#address").val(),OnGetMessageSuccess, OnGetMessageFailure);
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
