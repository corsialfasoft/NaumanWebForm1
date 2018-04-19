<%@ Control 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="TabellaProdotti.ascx.cs" 
    Inherits="NaumanWebForm1.Controls.TabellaProdotti" %>
    
<div class="table">
    <asp:Table
        width="100%"
        ID="ProdottiTable" 
        CellSpacing="15" 
        runat="server"
        GridLines="None"
        HorizontalAlign="Center">
    </asp:Table>
</div>
