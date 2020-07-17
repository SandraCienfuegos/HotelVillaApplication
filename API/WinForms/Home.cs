using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Home : Form
    {
        private static readonly Dictionary<string, Control> TabPagesData = new Dictionary<string, Control>()
        {
            {"Reservations", new ReservationView()},
        };

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            foreach (var (name, control) in TabPagesData.Select(x => (x.Key, x.Value)))
            {
                var tabPage = new TabPage(name);
                tabPage.Controls.Add(control);
                control.Dock = DockStyle.Fill;
                tabControl.TabPages.Add(tabPage);
            }
        }
    }
}