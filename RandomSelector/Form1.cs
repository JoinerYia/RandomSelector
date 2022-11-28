using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomSelector
{
    public partial class Form1 : Form
    {
        private RandomSelectorModel _model;
        private PresentationModel _pModel;
        private readonly Color[] _buttonColor = { SystemColors.ButtonFace, SystemColors.ButtonHighlight };

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadForm(object sender, EventArgs e)
        {
            _model = new RandomSelectorModel();
            _pModel = new PresentationModel(_model);
            _pModel.FormChangedEvent += PModel_formChangedEvent;
            _pModel.LoadForm();
        }

        private void PModel_formChangedEvent()
        {
            if (_pModel.IsBeginSelect)
            {
                btn_CheckNumber.BackColor = _buttonColor[0];
                btn_Select.BackColor = _buttonColor[1];
            }
            else
            {
                btn_CheckNumber.BackColor = _buttonColor[1];
                btn_Select.BackColor = _buttonColor[0];
            }

            if (this.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(PModel_formChangedEvent);
                this.Invoke(invoker);
            }
            else
                label_numberDisplay.Text = _pModel.Display;

            label_unselectNumber.Text = _pModel.UnselectNumbers.ToString();
        }

        private void Btn_CheckNumber_Click(object sender, EventArgs e)
        {
            _pModel.CheckNumber((int)numUpDown.Value);
        }

        private void Tool_reset_Click(object sender, EventArgs e)
        {
            _pModel.Reset();
        }

        private void Btn_Select_Click(object sender, EventArgs e)
        {
            _pModel.SelectANumber();
        }
    }
}
