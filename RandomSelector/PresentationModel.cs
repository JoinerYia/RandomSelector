using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RandomSelector
{
    public class PresentationModel
    {
        public delegate void FormChangedEvent();
        public delegate void SelectEvent();

        public event FormChangedEvent OnFormChanged;
        public event SelectEvent Selecting;
        public event SelectEvent SelectFail;
        public event SelectEvent Selected;

        private const string DEFUALT_ITEM = "00";

        readonly RandomSelectorModel _model;
        readonly Random _random = new Random();
        private Graphics _displayGraphics;
        private Graphics _unselectNumbersGraphics;

        private bool _isSelecting;
        public bool IsBeginSelect
        {
            get;
            private set;
        }
        public Bitmap Display
        {
            get;
            private set;
        }
        public Bitmap UnselectNumbers
        {
            get;
            private set;
        }

        public PresentationModel(RandomSelectorModel model)
        {
            _model = model;
            Reset();
        }

        public void LoadForm()
        {
            UpdateForm(DEFUALT_ITEM);
        }

        public void Reset()
        {
            IsBeginSelect = false;
            _isSelecting = false;
            LoadForm();
        }

        private void UpdateForm(string item)
        {
            if (item == null)
                item = DEFUALT_ITEM;

            SetDisplay(item);
            SetUnselcectNumber();
            OnFormChanged?.Invoke();
        }

        private void OnSelecting()
        {
            Selecting?.Invoke();
        }

        private void OnSelectFail()
        {
            SelectFail?.Invoke();
        }

        private void OnSelected()
        {
            Selected?.Invoke();
        }

        public void CheckNumber(int maximum)
        {
            if (IsBeginSelect)
                return;
            _model.ClearList();
            for (int i = 1; i <= maximum; i++)
            {
                _model.AddItem($"{i / 10}{i % 10}");
            }
            IsBeginSelect = true;
            LoadForm();
        }

        private void SetDisplay(string item)
        {
            Display = new Bitmap(300, 300);
            _displayGraphics = Graphics.FromImage(Display);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            Rectangle rectangle = new Rectangle(0, 0, Display.Width, Display.Height);
            Font font = new Font("微軟正黑體", 72F);

            _displayGraphics.DrawString(item.Insert(1, " "), font, Brushes.WhiteSmoke, rectangle, format);
        }

        private void SetUnselcectNumber()
        {
            UnselectNumbers = new Bitmap(300, 500);
            _unselectNumbersGraphics = Graphics.FromImage(UnselectNumbers);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            Font font = new Font("微軟正黑體", 16F);
            int fontWidth = 40;
            int fontHeight = 20;

            List<string> list = _model.GetList();
            for (int i = 0, y = 0; i < list.Count; y += fontHeight)
            {
                for (int x = 0; x < (UnselectNumbers.Width - fontWidth) && i < list.Count; i++, x += fontWidth)
                {
                    _unselectNumbersGraphics.DrawString($"{list[i]}, ", font, Brushes.WhiteSmoke, x, y);
                }
            }
        }

        public void SelectANumber()
        {
            if (!IsBeginSelect)
                return;
            if (_isSelecting)
                return;
            _isSelecting = true;

            Task.Run(() =>
            {
                string selectedNumber = _model.SelectItem();

                if (selectedNumber == null)
                {
                    UpdateForm(DEFUALT_ITEM);
                    OnSelectFail();
                    _isSelecting = false;
                    return;
                }

                OnSelecting();
                RunSelectTransition(selectedNumber);
                Thread.Sleep(500);
                OnSelected();

                _isSelecting = false;
            });
        }

        private void RunSelectTransition(string selectedNumber)
        {
            int tempNumber;
            const int TOTAL_MILLISECONDS = 2000;
            const int NUMBER_OF_TRANSITION = 20;

            for (int i = 0; i < NUMBER_OF_TRANSITION; i++)
            {
                tempNumber = _random.Next(99) + 1;
                UpdateForm($"{tempNumber / 10}{tempNumber % 10}");
                Thread.Sleep(TOTAL_MILLISECONDS / NUMBER_OF_TRANSITION / 2);
            }

            for (int i = 0; i < NUMBER_OF_TRANSITION; i++)
            {
                tempNumber = _random.Next(99) + 1;
                UpdateForm($"{selectedNumber[0]}{tempNumber % 10}");
                Thread.Sleep(TOTAL_MILLISECONDS / NUMBER_OF_TRANSITION / 2);
            }

            _model.RemoveItem(selectedNumber);
            UpdateForm(selectedNumber);
        }
    }
}
