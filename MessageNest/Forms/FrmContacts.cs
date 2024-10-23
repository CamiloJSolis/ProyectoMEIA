using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageNest.Forms
{
    public partial class FrmContacts : Form
    {
        public FrmContacts()
        {
            InitializeComponent();
        }

        private void MostrarRegistros()
        {
            try
            {
                //DgvContacts.DataSource
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al mostrar los contactos: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
