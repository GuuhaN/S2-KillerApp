using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmiek___Circustrein
{
    public partial class Form1 : Form
    {
        private List<Animal> AvailableAnimals = new List<Animal>();
        private List<Wagon> AvailableWagons = new List<Wagon>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_AddAnimal_Click(object sender, EventArgs e)
        {
        }
    }
}
