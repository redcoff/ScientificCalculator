using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VědeckáKalkulačka
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        decimal zadaneCislo, posledniZadaneCislo, posledniVysledek; //deklarace
        Key operace;
        bool provedenVypocet, provedenaOperace, zadavatNoveCislo;


        private void Input(string a) //vstup

        {

            if (((hlavni_textbox.Text == "0") || provedenVypocet || zadavatNoveCislo) && a != ",")
            {
                hlavni_textbox.Text = a;
                provedenVypocet = false;
                zadavatNoveCislo = false;
            }
            else
            {
                if ((a == "," && !hlavni_textbox.Text.Contains(",")) || a != ",")
                {
                    hlavni_textbox.Text += a;
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            hlavni_textbox.Text = "0";
            hlavni_textbox.IsEnabled = false; //nelze psát do textboxu
        }

        private void C0_button_Click(object sender, RoutedEventArgs e)
        {
            Input(Convert.ToString(0));
        }

        private void C1_button_Click(object sender, RoutedEventArgs e)
        {
            Input(Convert.ToString(1));
        }

        private void C2_button_Click(object sender, RoutedEventArgs e)
        {
            Input(Convert.ToString(2));
        }

        private void C3_button_Click(object sender, RoutedEventArgs e)
        {
            Input(Convert.ToString(3));
        }

        private void C4_button_Click(object sender, RoutedEventArgs e)
        {
            Input(Convert.ToString(4));
        }

        private void C5_button_Click(object sender, RoutedEventArgs e)
        {
            Input(Convert.ToString(5));
        }

        private void C6_button_Click(object sender, RoutedEventArgs e)
        {
            Input(Convert.ToString(6));
        }

        private void C7_button_Click(object sender, RoutedEventArgs e)
        {
            Input(Convert.ToString(7));
        }

        private void C8_button_Click(object sender, RoutedEventArgs e)
        {
            Input(Convert.ToString(8));
        }

        private void C9_button_Click(object sender, RoutedEventArgs e)
        {
            Input(Convert.ToString(9));
        }

        private void Operace_plus_button_Click(object sender, RoutedEventArgs e)
        {
            operacePlus();
        }

        private void Operace_minus_button_Click(object sender, RoutedEventArgs e)
        {
            operaceMinus();
        }

        private void Operace_krat_button_Click(object sender, RoutedEventArgs e)
        {
            operaceKrat();
        }

        private void Operace_deleno_button_Click(object sender, RoutedEventArgs e)
        {
            operaceDeleno();

        }

        private void operaceZaklad()
        {
            posledniZadaneCislo = zadaneCislo = Convert.ToDecimal(hlavni_textbox.Text);
            if (provedenaOperace && !zadavatNoveCislo)
            {
                Vypocitej();
            }
            posledniZadaneCislo = zadaneCislo = Convert.ToDecimal(hlavni_textbox.Text);
            posledniVysledek = zadaneCislo;
            provedenaOperace = true;
            zadavatNoveCislo = true;
        }

        private void operacePlus()
        {
            try
            {
                operaceZaklad();
                operace = Key.Add;
            }
            catch (OverflowException)
            {
                hlavni_textbox.Text = "Číslo je moc vysoké nebo moc nízké.";
                provedenVypocet = true;
            }
        }

        private void operaceMinus()
        {
            try
            {
                operaceZaklad();
                operace = Key.Subtract;
            }
            catch (OverflowException)
            {
                hlavni_textbox.Text = "Číslo je moc vysoké nebo moc nízké.";
                provedenVypocet = true;
            }
        }


        private void operaceKrat()
        {
            try
            {
                operaceZaklad();
                operace = Key.Multiply;
            }
            catch (OverflowException)
            {
                hlavni_textbox.Text = "Číslo je moc vysoké nebo moc nízké.";
                provedenVypocet = true;
            }
        }

        private void operaceDeleno()
        {
            try
            {
                operaceZaklad();
                operace = Key.Divide;
            }
            catch (OverflowException)
            {
                hlavni_textbox.Text = "Číslo je moc vysoké nebo moc nízké.";
                provedenVypocet = true;
            }
        }

        private void Vypocitej()
        {
            try
            {
                posledniZadaneCislo = zadaneCislo = (provedenVypocet) ? posledniZadaneCislo : Convert.ToDecimal(hlavni_textbox.Text);
                provedenVypocet = true;

            }
            catch (OverflowException)
            {
                hlavni_textbox.Text = "Číslo je moc vysoké nebo moc nízké.";
                provedenVypocet = true;
            }

            try
            {


                switch (operace)
                {
                    case Key.Add:
                        hlavni_textbox.Text = Convert.ToString(posledniVysledek + zadaneCislo);
                        posledniVysledek += zadaneCislo;
                        break;
                    case Key.Subtract:
                        hlavni_textbox.Text = Convert.ToString(posledniVysledek - zadaneCislo);
                        posledniVysledek -= zadaneCislo;
                        break;
                    case Key.Multiply:
                        hlavni_textbox.Text = Convert.ToString(posledniVysledek * zadaneCislo);
                        posledniVysledek = posledniVysledek * zadaneCislo;
                        break;
                    case Key.Divide:
                        if (zadaneCislo != 0)
                        {
                            hlavni_textbox.Text = Convert.ToString(posledniVysledek / zadaneCislo);
                            posledniVysledek = (posledniVysledek / zadaneCislo);
                        }
                        else
                            hlavni_textbox.Text = "Nulou nelze dělit!";
                        break;
                    case Key.Y:
                        hlavni_textbox.Text = Convert.ToString(Math.Pow((double)posledniVysledek, (double)zadaneCislo));
                        break;
                }
            }
            catch (OverflowException)
            {
                hlavni_textbox.Text = "Číslo je moc vysoké nebo moc nízké.";
                provedenVypocet = true;
            }


        }
        private void Vysledek_button_Click(object sender, RoutedEventArgs e)
        {
            Vypocitej();
            provedenaOperace = false;
        }

        private void carkaButton_Click(object sender, RoutedEventArgs e)
        {
            Input(",");
        }

        private void backspace_button_Click(object sender, RoutedEventArgs e)
        {
            backspace();
        }

        private void ZjistiKlavesu(object sender, KeyEventArgs e)
        {

            if ((e.Key == Key.Add) || (e.Key == Key.Subtract) || (e.Key == Key.Multiply) || (e.Key == Key.Divide)) //výběr základní operace
            {
                switch (e.Key)
                {
                    case Key.Add:
                        operacePlus();
                        break;

                    case Key.Subtract:
                        operaceMinus();
                        break;

                    case Key.Multiply:
                        operaceKrat();
                        break;

                    case Key.Divide:
                        operaceDeleno();
                        break;
                }

            }
            else if (jeNumButton(e.Key)) //stlačení klávesy na numerické klávesnici
            {
                Input(((int)e.Key - 74).ToString());
            }
            else if (e.Key == Key.Enter) //klávesa Enter
            {
                Vypocitej();
                provedenaOperace = false;
            }

            else if (e.Key == Key.Delete) //klávesa Delete
            {
                hlavni_textbox.Text = "0";

            }

            else if (e.Key == Key.Back) //klávesa Backspace
            {
                backspace();
            }

            else if (e.Key == Key.Decimal)
            {
                Input(",");
            }

            else if (e.Key == Key.Escape)
            {
                esc();
            }

            else if (e.Key == Key.Y)
            {
                mocnina();
            }
        }

        private void esc() //metoda pro vymazání probíhajícího výsledku
        {
            hlavni_textbox.Text = "0";
            zadaneCislo = 0;
            posledniVysledek = 0;
            posledniZadaneCislo = 0;
            provedenVypocet = false;
            provedenaOperace = false;
        }

        private void backspace() //metoda pro Backspace
        {
            if (!String.IsNullOrEmpty(hlavni_textbox.Text))
            {
                hlavni_textbox.Text = (String.IsNullOrEmpty(hlavni_textbox.Text.Remove(hlavni_textbox.Text.Length - 1))) ? "0" : hlavni_textbox.Text.Remove(hlavni_textbox.Text.Length - 1);
            }
            else
            {
                hlavni_textbox.Text = "0";
            }
        }

        private void faktorial_button_Click(object sender, RoutedEventArgs e) //tlačítko faktoriál
        {
            zadaneCislo = Convert.ToDecimal(hlavni_textbox.Text);
            if (((zadaneCislo % 1) == 0) && (zadaneCislo > 0))
            {// Ukázka odchycení výjimky..
                // Pokud by hrozilo, že bude výsledek vyšší než dovoluje Decimal, tak to obvykle padne na OverflowException
                // Tedy pokud by měla daná výjimka nastat, tak můžeme třeba vypsat text do kalkulačky..
                if (zadaneCislo < 28)
                {
                    try
                    {
                        // Zkusíme jestli se faktorial zadaného čísla vleze do Decimal.. pokud ano, tak se nic neděje.
                        hlavni_textbox.Text = Convert.ToString(faktorial((int)zadaneCislo));
                    }
                    catch (OverflowException)
                    {
                        // Pokud by bylo číslo vyšší než decimal umožňuje, tak se vyvolá výjimka OverflowException.
                        hlavni_textbox.Text = "Faktoriál daného čísla by byl příliš vysoký.";
                    }
                }
                else
                    hlavni_textbox.Text = "Faktoriál daného čísla by byl příliš vysoký.";
            }

            else
                hlavni_textbox.Text = "Zadejte kladné celé číslo.";
            provedenVypocet = true;
        }

        private void log_button_Click(object sender, RoutedEventArgs e) //tlačítko dekadický logaritmus
        {
            try
            {


                zadaneCislo = Convert.ToDecimal(hlavni_textbox.Text);
                if (zadaneCislo > 0)
                {
                    posledniVysledek = (decimal)Math.Log10((double)zadaneCislo);
                    hlavni_textbox.Text = Convert.ToString(posledniVysledek);
                }
                else
                    hlavni_textbox.Text = "Zadejte kladné číslo.";
                provedenVypocet = true;
            }
            catch (OverflowException)
            {
                hlavni_textbox.Text = "Číslo je moc vysoké nebo moc nízké.";
                provedenVypocet = true;
            }

        }

        private void mocnina_button_Click(object sender, RoutedEventArgs e)
        {
            mocnina();
        }

        private void mocnina() //metoda pro mocninu
        {
            try
            {


                posledniZadaneCislo = zadaneCislo = Convert.ToDecimal(hlavni_textbox.Text);
                if (provedenaOperace)
                {
                    hlavni_textbox.Text = Math.Pow((double)posledniVysledek, (double)zadaneCislo).ToString();
                    provedenVypocet = true;
                    posledniVysledek = Convert.ToDecimal(Math.Pow((double)posledniVysledek, (double)zadaneCislo));
                }
                else
                {
                    operace = Key.Y;
                    hlavni_textbox.Text = "0";
                    provedenaOperace = true;
                    posledniVysledek = Convert.ToDecimal(zadaneCislo);

                }
            }
            catch (OverflowException)
            {
                hlavni_textbox.Text = "Číslo je moc vysoké.";
                provedenVypocet = true;
            }

        }

        private void odmocnina_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                zadaneCislo = Convert.ToDecimal(hlavni_textbox.Text);
                if (zadaneCislo >= 0)
                {
                    posledniVysledek = (decimal)(Math.Sqrt((double)zadaneCislo));
                    hlavni_textbox.Text = Convert.ToString(posledniVysledek);
                }
                else
                    hlavni_textbox.Text = "Error! Nelze odmocnit záporné číslo.";

                provedenVypocet = true;
            }
            catch (OverflowException)
            {
                hlavni_textbox.Text = "Číslo je moc nízké.";
                provedenVypocet = true;
            }
        }

        private void sin_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                zadaneCislo = Convert.ToDecimal(hlavni_textbox.Text);
                posledniVysledek = (Decimal)(Math.Sin((Double)zadaneCislo * (Math.PI / 180))); //převod z rad na stupně
                hlavni_textbox.Text = Convert.ToString(posledniVysledek);
                provedenVypocet = true;
            }
            catch (OverflowException)
            {
                hlavni_textbox.Text = "Číslo je moc vysoké nebo moc nízké.";
                provedenVypocet = true;
            }
        }

        private void cos_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                zadaneCislo = Convert.ToDecimal(hlavni_textbox.Text);
                posledniVysledek = (Decimal)(Math.Cos((Double)zadaneCislo * (Math.PI / 180)));
                hlavni_textbox.Text = Convert.ToString(posledniVysledek);
                provedenVypocet = true;
            }
            catch (OverflowException)
            {
                hlavni_textbox.Text = "Číslo je moc vysoké nebo moc nízké.";
                provedenVypocet = true;
            }
        }

        private void hlavni_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tan_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                zadaneCislo = Convert.ToDecimal(hlavni_textbox.Text);
                posledniVysledek = (Decimal)(Math.Tan((Double)zadaneCislo * (Math.PI / 180)));
                hlavni_textbox.Text = Convert.ToString(posledniVysledek);
                provedenVypocet = true;
            }
            catch (OverflowException)
            {
                hlavni_textbox.Text = "Číslo je moc vysoké.";
                provedenVypocet = true;
            }
        }

        private bool jeNumButton(Key k) //metoda pro zjištění, byla stlačena klávesa na numerické klávesnici
        {
            return ((int)k <= 83 && (int)k >= 74);
        }

        private void VButton_Click(object sender, RoutedEventArgs e) //tlačítko C
        {
            esc();
        }

        public decimal faktorial(int zadaneCislo) //metoda faktoriál
        {
            if ((zadaneCislo == 1) || (zadaneCislo == 0))
                return 1;
            else
                return zadaneCislo * faktorial(zadaneCislo - 1);

        }
    }
}
