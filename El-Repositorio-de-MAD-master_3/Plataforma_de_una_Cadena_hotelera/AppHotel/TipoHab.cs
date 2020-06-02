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
        static int total;
        static int cantTipHab;
        static int cantServi;
        static int contador;
        static int Num;
        static string nameh;
        static string nameS;
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
        public void ShowTextEveryNumber()
        {
            if (next != null)
            {
                if (chb.Checked == true)
                {
                    //aqui muestra todos los que estan con palomita
                    //total
                    if (txb.Text != "")
                    {
                        int num = Int32.Parse(txb.Text);

                        total += num;
                    }
                }

                next.ShowTextEveryNumber();
            }
            else
            {
                if (chb.Checked == true)
                {
                    //aqui muestra todos los que estan con palomita
                    if (txb.Text != "") { 
                        int num = Int32.Parse(txb.Text);
                        total += num;
                    }
                    
                   
                }


               
            }
        }

        public void ShowTextEveryNumber2()
        {
            if (next != null)
            {
                if (chb.Checked == true)
                {
                    //aqui muestra todos los que estan con palomita
                    //total
                    if (txb.Text != "")
                    {

                        cantTipHab += 1;
                    }
                }


                next.ShowTextEveryNumber2();
            }
            else
            {
                if (chb.Checked == true)
                {
                    //aqui muestra todos los que estan con palomita
                    if (txb.Text != "")
                    {
                        cantTipHab += 1;
                    }


                }

            }
        }

        public void ShowTextEveryNumber3(int BuscCanth)
        {
            if (next != null)
            {
                if (chb.Checked == true)
                {
                    //aqui muestra todos los que estan con palomita
                    //total
                    if (txb.Text != "")
                    {
                        int num = Int32.Parse(txb.Text);
                        if (contador == BuscCanth)
                        {

                            Num = num;
                            nameh=chb.Text;
                            goto alFinal;
                        }
                            contador += 1;
                    }
                }

                next.ShowTextEveryNumber3(BuscCanth);
            }
            else
            {
                if (chb.Checked == true)
                {
                    //aqui muestra todos los que estan con palomita
                    if (txb.Text != "")
                    {
                        int num = Int32.Parse(txb.Text);
                        if (contador == BuscCanth)
                        {

                            Num = num;
                            nameh = chb.Text;
                            goto alFinal;
                        }
                        contador += 1;

                    }


                }


                //como me salgo xD
                //jaja arriba te debe venir la opcion creoya vi
            }

        alFinal:
            contador = contador;
        }

        public void ShowTextEveryNumber4()
        {
            if (next != null)
            {
                if (chb.Checked == true)
                {
                    //aqui muestra todos los que estan con palomita
                    //total
                    cantServi += 1;
                }


                next.ShowTextEveryNumber4();
            }
            else
            {
                if (chb.Checked == true)
                {
                    //aqui muestra todos los que estan con palomita
                    cantServi += 1;
                }


            }
        }

        public void ShowTextEveryNumber5(int buscaS)
        {
            if (next != null)
            {
                if (chb.Checked == true)
                {
                    if (buscaS==contador) {
                    nameS = chb.Text;
                        goto FinS;
                    }
                    contador++;
                }


                next.ShowTextEveryNumber5(buscaS);
            }
            else
            {
                if (chb.Checked == true)
                {
                    if (buscaS == contador)
                    {
                        nameS = chb.Text;
                        goto FinS;
                    }
                    contador++;
                }


            }

        FinS:
            contador = contador;
        }

        public int GetTotal (){
            return total;
        }
        public int GetCantHab()
        {
            return cantTipHab;
        }
        public int GetNumHab()
        {
            return Num;
        }
        public string GetNameHab()
        {
            return nameh;
        }
        public void Setcontador0() {
            contador = 0;
        }
        public int GetCantServ()
        {
            return cantServi;
        }
        public string GetNameServ()
        {
            return nameS;
        }

        public void allto0()
        {
            contador = 0;
            nameh = "";
            Num = 0;
            cantTipHab = 0;
            total = 0;
        }
        public void allto02()
        {
            contador = 0;
            nameS = "";
            Num = 0;
            cantTipHab = 0;
            total = 0;
            cantServi = 0;
        }
    }



    class TipoHabLista
    {

        public TipoHab head;
        public int totalCant;
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
        public int ShowTextEveryNumber()
        {

            if (head != null)
            {
                head.ShowTextEveryNumber();
            }
            return head.GetTotal();
        }
        public int ShowTextEveryNumber2()
        {

            if (head != null)
            {
                head.ShowTextEveryNumber2();
            }
            return head.GetCantHab();
        }
        public int ShowTextEveryNumber3(int busc)
        {

            if (head != null)
            {
                head.ShowTextEveryNumber3(busc);
            }
            return head.GetNumHab();
        }
        public string ShowTextEveryNumber4(int busc)
        {
            head.Setcontador0();//contador
            if (head != null)
            {
                head.ShowTextEveryNumber5(busc);
            }
            return head.GetNameServ();
        }

        public int ShowTextEveryNumber6()
        {

            if (head != null)
            {
                head.ShowTextEveryNumber4();
            }
            return head.GetCantServ();
        }

        public void limpieza() {
            head.allto0();
        }
        public void limpieza2()
        {
            head.allto02();
        }

    }


}
