using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NaumanWebForm1 {
	public partial class _Detail : Page {
		public string Message { get; set; }
		public Prodotto Prodotto { get; set; }
		protected void Page_Load(object sender, EventArgs e) {
            IDomainModel Model = new DomainModel(); ;
			int cod = 0;
			if (int.TryParse(Request["codice"], out cod)) {
                qtaRichiesta.MaximumValue= int.MaxValue.ToString();
				Prodotto = Model.GetProdotto(cod);
			}else
                Message ="codice inserito male";
		}
        protected void Aggiungi(object sender, EventArgs e) {
            if (Page.IsValid) { 
                int qta2 = int.Parse(qta.Text);
                IDomainModel Model = new DomainModel();
                Prodotto pro = Model.GetProdotto(Prodotto.Codice);
                List<Prodotto>  list = Session["prodotti"] as List<Prodotto>;
                if(list==null)
                    list =new List<Prodotto>();
                var query= from prodotto in list 
                            where prodotto.Codice==Prodotto.Codice
                            select prodotto;
                if(query.FirstOrDefault() !=null)
                    query.FirstOrDefault().QuantitaOrdinata += qta2;
                else { 
                    pro.QuantitaOrdinata =qta2;
                    list.Add(pro);
                }
                Session["prodotti"]=list;
                Response.Redirect($"~/RicercaProdotti.aspx?Messagge=Prodotto aggiunto al carrello");
            }
        }
    }
}