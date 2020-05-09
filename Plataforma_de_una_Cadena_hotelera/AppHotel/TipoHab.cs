using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AppHotel
{
    class TipoHab
    {
        
        public string nombreTipo;
        public CheckBox chb;
        public TextBox txb;
        public int id;
        public TipoHab before, next;

        public TipoHab(string n,CheckBox chb, TextBox txb)
        {
            this.nombreTipo = n;
            this.chb = chb;
            this.txb = txb;
            next = null;
        }
        public void alFinal(string n,CheckBox chbF, TextBox txbF) {
            if (next == null) {
               
                next = new TipoHab (n,chbF,txbF);
            }
            else {
                next.alFinal(n,chbF, txbF);
            }
        }



        public void ShowEvery() {
            if (next != null)
            {
                if (chb.Checked == true)
                    txb.Enabled = true;
                else
                    txb.Enabled = false;


                next.ShowEvery();
            }
            else {
                if (chb.Checked == true)
                    txb.Enabled = true;
                else
                    txb.Enabled = false;
            }
        }

    }
     class TipoHabLista
    {

        public TipoHab head;

        public TipoHabLista() { head = null; }

        public void alFinalLista(string n,CheckBox chb, TextBox txb) {
            if (head == null)
                head = new TipoHab(n,chb, txb);
            else
                head.alFinal(n,chb, txb);
        }

        public void getEvery() {
            if (head != null) {
                head.ShowEvery();
            }
        }


    }


}
