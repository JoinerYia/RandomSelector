using System;
using System.Drawing;
using System.Threading;
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
            _pModel.Selecting += PModel_SelectingEvent;
            _pModel.Selected += PModel_SelectedEvent;
            _pModel.LoadForm();
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

            pictureBox_unselectNumber.Image = _pModel.UnselectNumbers;
        }

        private void PModel_SelectingEvent()
        {
            StopSelectMusic();
            StartSelectMusic();
        }

        private void PModel_SelectedEvent()
        {
            if (!_pModel.IsEmpty)
                return;
            StopSelectMusic();
            axWindowsMediaPlayer1.URL = ".\\Padoru.mp3";
            StartSelectMusic();
            Thread.Sleep(13000);
            axWindowsMediaPlayer1.URL = ".\\抽獎音效.mp3";
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
            int width = pictureBox_unselectNumber.Width;
            int height = pictureBox_unselectNumber.Height;
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
            pictureBox_unselectNumber.BackgroundImage = new Bitmap(Properties.Resources.PADORU, pictureBox_unselectNumber.Size);
        }

        private void SelectEdittingNumber(object sender, MouseEventArgs e)
        {
            _pModel.SelectEdittingNumber(e.X, e.Y, pictureBox_unselectNumber.Width, pictureBox_unselectNumber.Height);
        }

        private void pictureBox_unselectNumber_MouseLeave(object sender, EventArgs e)
        {
            _pModel.SelectEdittingNumber(-100, -100, pictureBox_unselectNumber.Width, pictureBox_unselectNumber.Height);
        }

        private void 開啟ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _pModel.SetEditMode(true);
        }

        private void 關閉ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _pModel.SetEditMode(false);
        }

        private void 說明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string message = "編輯模式開啟時，點擊右側數字可以新增或移除數字。";
            MessageBox.Show(message, "說明");
        }

        private void ChangeNumberStatus(object sender, EventArgs e)
        {
            if(!_pModel.IsBeginSelect)
            {
                MessageBox.Show("請確定數字範圍", "提醒");
                return;
            }
            _pModel.ChangeNumberStatus();
        }
    }
}
