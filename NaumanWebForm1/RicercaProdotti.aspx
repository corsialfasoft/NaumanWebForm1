<%@ Page Title="Ricerca Prodotti" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="RicercaProdotti.aspx.cs" 
    Inherits="NaumanWebForm1.RicercaProdotti" %>

<%@ Register TagPrefix="TableP" TagName="Table" Src="~/Controls/TabellaProdotti.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="text-warning">
        <h4><%=Message%></h4>
    </div>
    <div class="container">
        <asp:Label  runat="server">CODICE:</asp:Label>
        <asp:TextBox TextMode="Number" id="codice" runat="server"></asp:TextBox>
         <br />
        <asp:Label  runat="server">DESCRIZIONE:</asp:Label>
        <asp:TextBox ID="descrizione" runat="server"></asp:TextBox>
        <asp:Button class="btn btn-default" OnClick="Cerca" text="Cerca" runat="server"/>
    </div>
    <%if(Prodotti!=null){%>
        <br />
        <div class=" container">
            <div class="row">
                <div class="col-md-1 h4">
                    Codice
                </div>
                <div class="col-md-4 h4">
                    Descrizione
                </div>
                <div class="col-md-3 h4">
                    Giacenza
                </div>
                <div class="col-ms-2 h4">
                    Dettagli
                </div>
            </div>
            <br />
        </div>
       <TableP:Table ID="listaProdotti" Detagli=true QtaOrdinata=false Giacenza=true runat="server" />
        
    <%}%>

</asp:Content>
