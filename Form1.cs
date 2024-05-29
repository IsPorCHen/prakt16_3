using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;


namespace prakt16_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (int.TryParse(textBox1.Text, out int populationThreshold))
                {
                    if (populationThreshold > 0)
                    {
                        listBox1.Items.Clear();

                        var file = File.ReadAllLines("countries.txt");
                        var countries = new List<Country>();

                        foreach (var line in file)
                        {
                            var split = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            countries.Add(new Country { NameValue = split[0], PopulationValue = int.Parse(split[1]) });
                        }

                        countries = countries.OrderBy(c => c.NameValue.Length).ToList();

                        var filteredCountries = from country in countries
                                                where country.PopulationValue > populationThreshold
                                                select country;

                        foreach (var contry in filteredCountries)
                        {
                            listBox1.Items.Add($"{contry.NameValue} {contry.PopulationValue}");
                        }
                    }
                    else MessageBox.Show("Кол-во людей должно быть больше 0");
                }
                else
                    MessageBox.Show("Не удалось преобразовать в int");
            }
            else MessageBox.Show("Введите значения");
        }

    }
}
