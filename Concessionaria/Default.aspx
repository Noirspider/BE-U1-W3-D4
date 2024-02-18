<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Concessionaria._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="d-flex flex-column justify-content-center align-items-center">

            <asp:DropDownList ID="ddlExample" runat="server" CssClass="form-select p-1">
                <asp:ListItem Text="Seleziona un auto" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Compra" CssClass="btn btn-success m-2" Text="More Info" runat="server" OnClick="Compra_Click" />

        </div>
        <div runat="server" class="d-flex flex-column justify-content-center align-items-center">
            <img id="carImage" runat="server" height="300" class="border-1 rounded-1" />
            <h2 id="NameModel" runat="server"></h2>
            <span id="Price" runat="server"></span>
            <div id="garanzia" class="d-none" runat="server">
                <asp:Label runat="server" CssClass="my-2">Quanti anni di Garanzia? </asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select p-1">
                    <asp:ListItem Text="1 anno" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2 anno" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3 anno" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4 anno" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5 anno" Value="5"></asp:ListItem>
                </asp:DropDownList>
                <div class="d-flex flex-column">

                    <div>
                        <span>CerchionInLega </span>
                        <asp:CheckBox ID="CerchionInLega" runat="server"  />
                    </div>
                    <div>
                        <span>VerniceCromata </span>
                        <asp:CheckBox ID="VerniceCromata" runat="server"  />
                    </div>

                    <div>
                        <span>Climatizzatore </span>
                        <asp:CheckBox ID="climatizzatore" runat="server"  />
                    </div>
                    <div>
                        <span>DoppioAirbag </span>
                        <asp:CheckBox ID="DoppioAirbag" runat="server"  />
                    </div>
                    <div>
                        <span>ABS </span>
                        <asp:CheckBox ID="ABS" runat="server"  />
                    </div>
                    <div>
                        <span>Cerchi in lega </span>
                        <asp:CheckBox ID="cerchi" runat="server" />
                    </div>
            <asp:Button ID="CalcolaPreventivo" CssClass="btn btn-success m-2" Text="Calcola Preventivo" runat="server" OnClick="CalcolaPreventivo_Click"/>
                </div>
            </div>
            </div>
        
         <table class="border border-1 my-3 table" runat="server">
     <thead>
         <tr>
             <th class="text-center">Prezzo Base</th>
             <th class="text-center">Cerchi In Lega</th>
             <th class="text-center">Vernice Cromata</th>
             <th class="text-center">Climatizzatore</th>
             <th class="text-center">Doppio Airbag</th>
             <th class="text-center">ABS</th>
             <th class="text-center">Prezzo Garanzia</th>
             <th class="text-center">Prezzo Totale</th>



         </tr>
     </thead>
     <tbody>
         <tr>
             <td class="text-center" id="PrezzoBase" runat="server"></td>
             <td class="text-center" id="CerchiInLega" runat="server"></td>
             <td class="text-center" id="VerniceCromatal" runat="server"></td>
             <td class="text-center" id="Climatizzatorel" runat="server"></td>
             <td class="text-center" id="DoppioAirbagl" runat="server"></td>
             <td class="text-center" id="ABSl" runat="server"></td>
             <td class="text-center" id="PrezzoGaranzia" runat="server"></td>
             <td class="text-center" id="PrezzoTotale" runat="server"></td>


         </tr>
     </tbody>
 </table>

    </main>

</asp:Content>
