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
        public TipoHab(string n, CheckBox chb)
        {
            this.nombreTipo = n;
            this.chb = chb;
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
        public void alFinal(string n, CheckBox chbF)
        {
            if (next == null)
            {

                next = new TipoHab(n, chbF);
            }
            else
            {
                next.alFinal(n, chbF);
            }
        }



        public void ShowEvery() {
            if (next != null)
            {
                if (chb.Checked == true) {
                    //aqui muestra todos los que estan con palomita
                    txb.Enabled = true;
                }
                else
                    txb.Enabled = false;


                next.ShowEvery();
            }
            else {
                if (chb.Checked == true) {
                    //aqui muestra si el ultimo esta con palomita

                    txb.Enabled = true;
                }
                else
                    txb.Enabled = false;
            }
        }

        public void ShowTextEvery()
        {
            if (next != null)
            {
                //if (chb.Checked == true)
                //{
                //    //aqui muestra todos los que estan con palomita
                //    MessageBox.Show("servicio adicional: "+ nombreTipo);
                //}
                //else
                MessageBox.Show("servicio adicional: " + nombreTipo);

                next.ShowTextEvery();
            }
            else
            {
                MessageBox.Show("servicio adicional: " + nombreTipo);
                //if (chb.Checked == true)
                //{
                //    //aqui muestra si el ultimo esta con palomita

                //    MessageBox.Show("servicio adicional: "+ nombreTipo);

                //}

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
        public void alFinalLista(string n, CheckBox chb)
        {
            if (head == null)
                head = new TipoHab(n, chb);
            else
                head.alFinal(n, chb);
        }

        public void getEvery() {
            if (head != null) {
                head.ShowEvery();
            }
        }
        public void getEveryText()
        {
            if (head != null)
            {
                head.ShowTextEvery();
            }
        }

    }


}
