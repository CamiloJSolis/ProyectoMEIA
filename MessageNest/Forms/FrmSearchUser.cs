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
    public partial class FrmSearchUser : Form
    {
        public FrmSearchUser()
        {
            InitializeComponent();
        }

        private void SetSearchUserPanelsColor (Color color)
        {
            PnlSearchUsrLeft.BackColor = color;
            PnlSearchtUsrRight.BackColor = color;
            PnlSearchUsrUp.BackColor = color;
            PnlSearchUsrDown.BackColor = color;
        }

        private void TxtSearchUsr_Click(object sender, EventArgs e)
        {
            if (TxtSearchUsr.Text == "Ingrese el usuario a buscar")
            {
                TxtSearchUsr.SelectAll();
            }
        }

        private void TxtSearchUsr_Enter(object sender, EventArgs e)
        {
            SetSearchUserPanelsColor(Color.DeepSkyBlue);
        }

        private void TxtSearchUsr_Leave(object sender, EventArgs e)
        {
            SetSearchUserPanelsColor(Color.FromArgb(50, 50, 50));
        }
    }
}
