using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rekenmachine//Dit is voorla gebaszeerd op oefening 1 en ik heb gewoon een vertaler toe gevoegd
{
    public partial class frmRekenmachine : Form
    {
        //
        //Vars
        //

        public bool isFirst = true;
        public bool isSecond = false;
        public bool isFirstCijfer = true;
        public int cijfer01;
        public int cijfer02 = 0;
        public int cijfer03;
        private int prevAns;
        public bool Plus;
        public bool Min;
        public bool Deel;
        public bool Keer;

        public frmRekenmachine()
        {
            InitializeComponent();
        }

        //
        //Methodes
        //
        //Hier zetten we de nummers om naar romeinse cijfers to 4000
        private string CConvert(int nummer)
        {
            string Out = "";
            string[] romeinseCijfers = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };//Hier maken we een string array met alle romeinsecijfers.
            int[] normaleCijfers = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };//Hier vullen we een int array met de corrosponderende nummers.

            if (nummer > 4000) // Hier zorgen we dat als het nummer boven 4000 is we een error terug geven.
            {
                Out = "Error: Nummer is groter dan 4000";

            }
            else
            {
                for (int i = 0; i < normaleCijfers.Length; i++)//We maken een loop die alle nummers afgaat.
                {
                    while (nummer >= normaleCijfers[i])//Hier kijken we of het nummer groter is of even groot is.
                    {
                        Out = Out + romeinseCijfers[i];//Hier voegen we het goede romeinse cijfer toe aan een string.
                        nummer = nummer - normaleCijfers[i];//Hier verminderen we het nummer met het nummer  dat net gebruikt is.
                    }
                }
            }
            return Out;
        }
        private void Cijfer01()
        {
            if (isFirst)
            {
                try { cijfer01 = int.Parse(txbIO.Text); }
                catch (Exception e) { MessageBox.Show("ERROR" + e); }
                isFirst = false;
                isSecond = true;
                Clear();
            }
            if (isSecond)
            {
                isFirst = true;
                isSecond = false;
                Clear();
            }
        }
        private void Verwijder()
        {
            Clear();
            cijfer01 = 0;
            cijfer02 = 0;
        }
        private void Clear()
        {
            txbIO.Text = "0";
            isFirstCijfer = true;
        }
        private void Clean()
        {
            cijfer01 = 0;
            cijfer02 = 0;
            isFirstCijfer = true;
        }
        private void IOPlus()
        {
            if (txbIO.Text.Length > 13)
            {
                txbIO.Text = txbIO.Text.Remove(0, 1);
            }
        }
        private void AddCijfer(char inputCijfer)
        {
            if (isFirst)
            {
                if (isFirstCijfer)
                {
                    txbIO.Text = inputCijfer.ToString();
                    isFirstCijfer = false;
                }
                else { txbIO.Text = txbIO.Text + inputCijfer.ToString(); IOPlus(); }
            }
            if (isSecond)
            {
                if (isFirstCijfer)
                {
                    txbIO.Text = inputCijfer.ToString();
                    isFirstCijfer = false;
                }
                else { txbIO.Text = txbIO.Text + inputCijfer.ToString(); IOPlus(); }
            }

        }
        private void Antwoordt()
        {
            if (cijfer01 != 0)
            {
                try { cijfer02 = int.Parse(txbIO.Text); }
                catch (Exception e) { MessageBox.Show("ERROR" + e); }
            }
            if (cijfer02 == 0)
            {
                cijfer03 = cijfer01;
                Clean();
                txbIO.Text = CConvert(cijfer03);
                prevAns = cijfer03;
                cijfer03 = 0;
            }
            else
            {
                if (Plus)
                {
                    cijfer03 = cijfer01 + cijfer02;
                    isFirst = true;
                    isSecond = false;
                    Plus = false;
                }
                if (Min)
                {
                    cijfer03 = cijfer01 - cijfer02;
                    isFirst = true;
                    isSecond = false;
                    Min = false;
                }
                if (Keer)
                {
                    cijfer03 = cijfer01 * cijfer02;
                    isFirst = true;
                    isSecond = false;
                    Keer = false;
                }
                Clean();
                txbIO.Text = CConvert(cijfer03);
                prevAns = cijfer03;
                cijfer03 = 0;
            }
        }

        //
        //In/Out
        //
        private void btn1_Click(object sender, EventArgs e)
        {
            AddCijfer('1');
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            AddCijfer('2');
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            AddCijfer('3');
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AddCijfer('4');
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AddCijfer('5');
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AddCijfer('6');
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AddCijfer('7');
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            AddCijfer('8');
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AddCijfer('9');
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            AddCijfer('0');
        }

        private void btnComma_Click(object sender, EventArgs e)
        {
            AddCijfer(',');
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Verwijder();
        }

        private void btnPlus_Click_1(object sender, EventArgs e)
        {
            Cijfer01();
            Plus = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Cijfer01();
            Min = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Antwoordt();
        }

        private void btnKeer_Click(object sender, EventArgs e)
        {
            Cijfer01();
            Keer = true;
        }
    }
}

//
// Input
//      -Cijfers
//      -Plus, Min etc.
//
//Output
//      -Temp-Antwoord
//      -Antwoord
//
//
//
//
//
//
//
//