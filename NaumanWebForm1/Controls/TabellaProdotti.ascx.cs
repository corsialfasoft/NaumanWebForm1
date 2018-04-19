using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NaumanWebForm1.Controls {
    public partial class TabellaProdotti : System.Web.UI.UserControl {
        public List<Prodotto> Prodotti { get;set;}
        public bool Detagli { get;set;}
        public bool QtaOrdinata { get;set;}
        public bool Giacenza { get; set; }
        
        protected void Page_Load(object sender, EventArgs e) {

        }
        public void Update() {
            if (Prodotti != null) { 
                foreach (Prodotto pro in Prodotti) {
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    cell.Controls.Add(new Label { Text = pro.Codice.ToString(), CssClass = "col-ms-2" });
                    row.Cells.Add(cell);
                    cell = new TableCell();
                    cell.Controls.Add(new Label { Text = pro.Descrizione.ToString(), CssClass = "col-ms-6" });
                    row.Cells.Add(cell);
                    if(Detagli){
                        cell = new TableCell();
                        cell.Controls.Add(new Label { Text = pro.Giacenza.ToString(), CssClass = "col-ms-2" });
                        row.Cells.Add(cell);
                    }
                    if(Detagli){
                        cell = new TableCell();
                        cell.Controls.Add(new Button { Text = "Detail", CssClass = "col-ms-3 btn btn-default", PostBackUrl = $"~/Detail?codice={pro.Codice}" });
                        row.Cells.Add(cell);
                    }
                    if (QtaOrdinata) {
                        cell = new TableCell();
                        cell.Controls.Add(new Label { Text = pro.QuantitaOrdinata.ToString(), CssClass = "col-ms-2" });
                        row.Cells.Add(cell);
                    }
                    ProdottiTable.Rows.Add(row);
                }
            }
        }
    }
}