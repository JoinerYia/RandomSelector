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
        private readonly Color[] _buttonColor = { Color.Gray, SystemColors.ButtonHighlight };
        Graphics _graphis;

        public Form1()
        {
            InitializeComponent();

        }

        private void LoadForm(object sender, EventArgs e)
        {
            _graphis = pictureBox_numberDisplay.CreateGraphics();

            _model = new RandomSelectorModel();
            _pModel = new PresentationModel(_model);
            _pModel.OnFormChanged += PModel_FormChangedEvent;
            _pModel.Selecting += PModel_SelctingEvent;
            _pModel.LoadForm();

            StopSelectMusic();
            //this.Cursor = new Cursor();
        }

        private void PModel_FormChangedEvent()
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
                MethodInvoker invoker = new MethodInvoker(PModel_FormChangedEvent);
                this.Invoke(invoker);
            }
            else
            {
                pictureBox_numberDisplay.Image = _pModel.Display;
            }

            PictureBox_unselectNumber.Image = _pModel.UnselectNumbers;
        }

        private void PModel_SelctingEvent()
        {
            StopSelectMusic();
            StartSelectMusic();
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

        private void Label_unselectNumber_Paint(object sender, PaintEventArgs e)
        {
            int width = PictureBox_unselectNumber.Width;
            int height = PictureBox_unselectNumber.Height;

            return;
            for (int x = 0; x < width; x += 30)
            {
                e.Graphics.DrawLine(Pens.Black, x, 0, x, height);
            }

            for (int y = 0; y < height; y += 20)
            {
               e.Graphics.DrawLine(Pens.Black, 0, y, width, y);
            }
        }

        private void KeyInput(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    Btn_Select_Click(null, null);
                    break;
                default:
                    return;
            }
        }

        private void StartSelectMusic()
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void StopSelectMusic()
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void PictureBox_unselectNumber_ReSize(object sender, EventArgs e)
        {
            PictureBox_unselectNumber.BackgroundImage = new Bitmap(Properties.Resources.PADORU, PictureBox_unselectNumber.Size);
        }
    }
}
