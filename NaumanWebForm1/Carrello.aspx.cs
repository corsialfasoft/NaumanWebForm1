using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NaumanWebForm1 {
    public partial class Carrello : Page {
        public string Message { get; set; }
        public List<Prodotto> Prodotti { get; set; }

        protected void Page_Load(object sender, EventArgs e) {
            Prodotti = (List<Prodotto>)Session["prodotti"] ?? null;
            listaProdotti.Prodotti= Prodotti;
            listaProdotti.Update();
            Message = Prodotti == null ? "Nessun prodotto tra le richieste di ordine" : null;
        }
        protected void Invia_Oridine(object sender, EventArgs e) {
            IDomainModel Model = new DomainModel();
            Model.InviaOrdine(Prodotti);
            Session["prodotti"] = null;
            Response.Redirect("~/RicercaProdotti.aspx?Message=Ordine è stato confermato");
        }
        protected void Pulisci(object sender, EventArgs e) {
            Session["prodotti"] = null;
            Response.Redirect("~/RicercaProdotti.aspx?Message=Carrello pulito!");
        }

    }
}