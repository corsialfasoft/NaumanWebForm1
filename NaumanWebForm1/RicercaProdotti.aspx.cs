using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaDB;
namespace NaumanWebForm1 {

	public partial class RicercaProdotti : Page {
		protected void Page_Load(object sender, EventArgs e) {
            Message = Request["Messagge"] ?? null;
		}
		protected string Message { get; set; }
		protected List<Prodotto> Prodotti { get; set; }
        IDomainModel Model = new DomainModel();
		protected void Cerca(object sender, EventArgs e){
			int cod = 0;
			if (codice.Text.Length > 0 && int.TryParse(codice.Text,out cod)) {
				Prodotto prod = Model.GetProdotto(cod);
				if(prod != null){
					Response.Redirect($"~/Detail.aspx?codice={prod.Codice}");
				}
                Message = "Prodotto non trovao";
			} else if (descrizione.Text.Length > 0){
				Prodotti = Model.GetProdotti(descrizione.Text);
                if (Prodotti.Count > 0) {
                    listaProdotti.Prodotti=Prodotti;
                    listaProdotti.Update();
                } else {                     
                    Prodotti= null;
                    Message = "Non è stato trovato un prodotto con questa descrizione";
                }
			}else{
                Message = "Inserire almeno un parametro per la ricerca";
			}
		}
	}
    interface IDomainModel {
        Prodotto GetProdotto(int codice);
        List<Prodotto> GetProdotti(string des);
        void InviaOrdine(List<Prodotto> prodotti);
    }

    public class DomainModel : IDomainModel {
		public Prodotto GetProdotto(int codice){
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@id", SqlDbType.Int);
            para[0].Value = codice;
			return DB.ExecQProcedureReader("seachById", TrasformProdotto, para, "RICHIESTE");
        }
        public Prodotto TrasformProdotto(SqlDataReader reader) {
            if (reader.Read()) {
                return new Prodotto { Codice= reader.GetInt32(0),Descrizione= reader.GetString(1),Giacenza= reader.GetInt32(2)};
            }
            return null;
        }
		public List<Prodotto> GetProdotti(string des){
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@des", SqlDbType.NVarChar);
            para[0].Value = des;
            return DB.ExecQProcedureReader("seachByDescrizione", TrasformProdotti, para, "RICHIESTE");
		}
        public List<Prodotto> TrasformProdotti(SqlDataReader reader) {
            List<Prodotto> list = new List<Prodotto>();
            while (reader.Read()) {
                list.Add(new Prodotto { Codice = reader.GetInt32(0), Descrizione = reader.GetString(1), Giacenza = reader.GetInt32(2) });
            }
            return list;
        }

        public void InviaOrdine(List<Prodotto> prodotti) { 
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@date", SqlDbType.Date);
            para[0].Value = DateTime.Today;
            int idR = DB.ExecQProcedureReader("CreaRichiesta", DB.TrasformInt, para, "RICHIESTE");
            if (idR > 0) {
                bool trovato =false;
                foreach(Prodotto pro in prodotti) {
                    para = new SqlParameter[3];
                    para[0] = new SqlParameter("@idRichiesta", SqlDbType.Int);
                    para[0].Value = idR;
                    para[1] = new SqlParameter("@idProdotti", SqlDbType.Int);
                    para[1].Value = pro.Codice;
                    para[2] = new SqlParameter("@quantita", SqlDbType.Int);
                    para[2].Value = pro.QuantitaOrdinata;
                    int ris = DB.ExecQProcedureReader("CreaOrdine", DB.TrasformInt, para, "RICHIESTE");
                    if (ris != 2) {
                        trovato = true;
                    }
                }
                if (!trovato) {
                    DB.ExecNonQ($"delete RichiesteSet where Id={idR}", "RICHIESTE");
                }
            }
        }
    }
    public class ModelMock : IDomainModel {
        public Prodotto GetProdotto(int codice) {
            return new Prodotto { Codice = 200, Descrizione = "Telefono", Giacenza = 50 };
        }
        public List<Prodotto> GetProdotti(string des) {
            List<Prodotto> prodotti = new List<Prodotto>();
            prodotti.Add(new Prodotto { Codice = 200, Descrizione = "Telefono", Giacenza = 250 });
            prodotti.Add(new Prodotto { Codice = 201, Descrizione = "Televisore", Giacenza = 200 });
            prodotti.Add(new Prodotto { Codice = 500, Descrizione = "Portatile", Giacenza = 110 });
            return prodotti;
        }

        public void InviaOrdine(List<Prodotto> prodotti) {
            return;
        }
    }
    public class Prodotto{
		public int Codice{ get;set;}
		public string Descrizione { get;set;}
		public int Giacenza{ get;set;}
		public int QuantitaOrdinata{ get;set;}
	}
}