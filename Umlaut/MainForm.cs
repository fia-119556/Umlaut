using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umlaut
{
    public partial class MainForm : System.Windows.Forms.Form
    {

        private HookAndInput hookAndInput;

        public MainForm()
        {
            InitializeComponent();
            hookAndInput = new HookAndInput();
            //フック開始
            hookStartMenuItem_Click(null,null);
        }

        /// <summary>
        /// フック開始クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hookStartMenuItem_Click(object sender, EventArgs e)
        {
            hookAndInput.Hook();

            hookStartMenuItem.Enabled = false;
            hookEndMenuItem.Enabled = true;
        }

        /// <summary>
        /// フック終了クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hookEndMenuItem_Click(object sender, EventArgs e)
        {
            hookAndInput.HookEnd();
            hookStartMenuItem.Enabled = true;
            hookEndMenuItem.Enabled = false;
        }

        /// <summary>
        /// プログラム終了クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitItem_Click(object sender, EventArgs e)
        {
            hookEndMenuItem_Click(sender,e);
            Application.Exit();
        }
    }
}
