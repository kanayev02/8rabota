using System;
using System.Collections.Generic;
using System.IO;
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

namespace _8rabota
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BaseClass> Student = new List<BaseClass>();
        int i;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Zapisat_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("Students.csv", true))
            {
                sw.Write(Imy.Text + ";");
                sw.Write(Famil.Text + ";");
                ComboBoxItem item = (ComboBoxItem)Class.SelectedItem;
                sw.Write(item.Content + ";");
                if (Den.IsChecked == true)
                {
                    sw.Write("Дневная;");
                }
                if (Noch.IsChecked == true)
                {
                    sw.Write("Вечерняя;");
                }
                sw.Write(Rus.Text + ";");
                sw.Write(Mat.Text + ";");
                sw.Write(Fiz.Text + "\n");
            }
            MessageBox.Show("Записано", "Записано");
        }

        private void Posmotret_Click(object sender, RoutedEventArgs e)
        {
            Posm.Visibility = Visibility.Visible;
            Kartinka.Visibility = Visibility.Collapsed;
            using (StreamReader sr = new StreamReader("Students.csv"))
            {
                while (sr.EndOfStream != true)
                {
                    string[] Sarr = sr.ReadLine().Split(';');
                    Student.Add(new BaseClass()
                    { Name = Sarr[0], Fam = Sarr[1], Class = Sarr[2], Forma = Sarr[3], Russk = Sarr[4], Matem = Sarr[5], Fizika = Sarr[6] });
                    i = 0;
                    Imy2.Text = Student[0].Name;
                    Famil2.Text = Student[0].Fam;
                    Class2.Text = Student[0].Class;
                    Forma2.Text = Student[0].Forma;
                    Rus2.Text = Student[0].Russk;
                    Mat2.Text = Student[0].Matem;
                    Fiz2.Text = Student[0].Fizika;
                }
            }
        }

        private void Pervaya_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Imy2.Text = Student[0].Name;
                Famil2.Text = Student[0].Fam;
                Class2.Text = Student[0].Class;
                Forma2.Text = Student[0].Forma;
                Rus2.Text = Student[0].Russk;
                Mat2.Text = Student[0].Matem;
                Fiz2.Text = Student[0].Fizika;
            }
            catch
            {
                MessageBox.Show("Первая запись");
            }
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                i--;
                Imy2.Text = Student[i].Name;
                Famil2.Text = Student[i].Fam;
                Class2.Text = Student[i].Class;
                Forma2.Text = Student[i].Forma;
                Rus2.Text = Student[i].Russk;
                Mat2.Text = Student[i].Matem;
                Fiz2.Text = Student[i].Fizika;
            }
            catch
            {
                MessageBox.Show("Первая запись");
            }
        }

        private void Vpered_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                i++;
                Imy2.Text = Student[i].Name;
                Famil2.Text = Student[i].Fam;
                Class2.Text = Student[i].Class;
                Forma2.Text = Student[i].Forma;
                Rus2.Text = Student[i].Russk;
                Mat2.Text = Student[i].Matem;
                Fiz2.Text = Student[i].Fizika;
            }
            catch
            {
                MessageBox.Show("Последняя запись");
            }
        }

        private void Posl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                i = Student.Count - 1;
                Imy2.Text = Student[i].Name;
                Famil2.Text = Student[i].Fam;
                Class2.Text = Student[i].Class;
                Forma2.Text = Student[i].Forma;
                Rus2.Text = Student[i].Russk;
                Mat2.Text = Student[i].Matem;
                Fiz2.Text = Student[i].Fizika;
            }
            catch
            {
                MessageBox.Show("Последняя запись");
            }
        }
        private void Naiti_Click(object sender, RoutedEventArgs e)
        {
            List<BaseClass> Poisk = new List<BaseClass>();
            for (int i = 0; i < Student.Count; i++)
            {
                if (Poi.Text == Student[i].Fam)
                {
                    BaseClass Poisk2 = new BaseClass
                    {
                        Name = Student[i].Name,
                        Fam = Student[i].Fam,
                        Class = Student[i].Class,
                        Forma = Student[i].Forma,
                        Russk = Student[i].Russk,
                        Matem = Student[i].Matem,
                        Fizika = Student[i].Fizika,
                    };
                    Poisk.Add(Poisk2);
                }
            }
            try
            {
                Imy2.Text = Poisk[0].Name;
                Famil2.Text = Poisk[0].Fam;
                Class2.Text = Poisk[0].Class;
                Forma2.Text = Poisk[0].Forma;
                Rus2.Text = Poisk[0].Russk;
                Mat2.Text = Poisk[0].Matem;
                Fiz2.Text = Poisk[0].Fizika;
            }
            catch
            {
                MessageBox.Show("Не найдено", "Поиск");
            }

        }
    }
}
