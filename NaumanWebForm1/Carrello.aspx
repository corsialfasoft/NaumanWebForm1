<%@ Page  Title="Carrello"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrello.aspx.cs" 
    Inherits="NaumanWebForm1.Carrello" %>
<%@ Register TagPrefix="TableP" TagName="Table" Src="~/Controls/TabellaProdotti.ascx" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <div class="text-warning">
        <h4><%=Message %></h4>
    </div>
    <%if(Prodotti!=null){%>
        <div class=" container">
            <div class="row">
                <div class="col-md-2 h4">
                    Codice
                </div>
                <div class="col-md-6 h4">
                    Descrizione
                </div>
                <div class="col-md-2 h4">
                    Quantita Ordinata
                </div>
            </div>
            <br />
         <TableP:Table ID="listaProdotti" Detagli=false QtaOrdinata=true Giacenza=false runat="server" />
        <hr />
        </div>
        <asp:Button runat="server" OnClick="Invia_Oridine" class="btn btn-default" Text="INVIA ORDINE" /> 
        <asp:Button runat="server" OnClick="Pulisci" class="btn btn-default" Text="PULISCI CARRELLO" />
        <asp:Button class="btn btn-default" PostBackUrl="~/RicercaProdotto.aspx" Text="ANNULLA" runat="server"/>
    <%} %>
</asp:Content>