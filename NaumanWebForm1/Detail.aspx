<%@ Page Title="Detalio Prodotto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="NaumanWebForm1._Detail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="text-warning">
        <h4><%=Message%></h4>
    </div>
<%if(Prodotto !=null){%>
<div class=" container">
        <div class="row">
            <div class="col-md-2 h4">
                Codice
            </div>
            <div class="col-md-5">
                <%=Prodotto.Codice %> 
            </div>
        </div>
        <div class="row">
            <div class="col-md-2 h4">
                Descrizione
            </div>
            <div class="col-md-5">
                    <%=Prodotto.Descrizione %> 
            </div>
        </div>
        <div class="row">
            <div class="col-md-2 h4">
                Giacenza
            </div>
            <div class="col-md-5">
                <%=Prodotto.Giacenza %> 
            </div>
        </div><br />
        <div class="row">
            <div class="col-md-2 h4">
                Quantità richiesta
            </div>
            <div class="col-md-5">
                <asp:TextBox TextMode="Number" ID="qta" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator 
                    id="Required"
                    ControlToValidate="qta"
                    Display="Static"
                    CssClass="text-danger h4"
                    ErrorMessage="*"
                    runat="server"/> 
                <asp:RangeValidator
                    runat="server"
                    id="qtaRichiesta"
                    ControlToValidate="qta"
                    Display="Static"
                    CssClass="text-danger"
                    ErrorMessage="Deve essere nel Range(1,2147483647)"
                    type="Integer"
                    MinimumValue="1"
                    MaximumValue="10"
                    />
            </div>
        </div>
        <div class="row">
            <div>
                <asp:Button OnClick="Aggiungi" runat="server" class="btn btn-default" Text="Aggiungi"/>
                <asp:Button class="btn btn-default" PostBackUrl="~/RicercaProdotto.aspx" Text="Annulla" runat="server"/>
            </div>
        </div>
    </div>
<%} %>
</asp:Content>