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
        private int? _editingNumber = null;

        private const int fontWidth = 40;
        private const int fontHeight = 20;
        private const int numberOfMaximum = 99;

        private bool _isSelecting;
        public bool IsBeginSelect
        {
            get;
            private set;
        }
        public bool IsEditMode
        {
            get;
            private set;
        }
        public bool IsEmpty
        {
            get
            {
                return _model.IsEmpty;
            }
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
            IsEditMode = false;
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

        private void UpdateForm()
        {
            DrawUnselcectNumber();
            if (IsEditMode)
                DrawEdittingNumber();
            OnFormChanged?.Invoke();
        }

        private void UpdateForm(string item)
        {
            if (item == null)
                item = DEFUALT_ITEM;

            DrawDisplay(item);

            UpdateForm();
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

        public void SetEditMode(bool status)
        {
            IsEditMode = status;
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

        private void DrawDisplay(string item)
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

        private void DrawUnselcectNumber()
        {
            UnselectNumbers = new Bitmap(300, 500);
            _unselectNumbersGraphics = Graphics.FromImage(UnselectNumbers);

            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            Font font = new Font("微軟正黑體", 16F);

            for (int i = 1, y = 0; i <= numberOfMaximum; y += fontHeight)
            {
                for (int x = 0; x < (UnselectNumbers.Width - fontWidth) && i <= numberOfMaximum; i++, x += fontWidth)
                {
                    string item = $"{i / 10}{i % 10}";
                    if (_model.Contain(item))
                        _unselectNumbersGraphics.DrawString($"{item}, ", font, Brushes.White, x, y);
                }
            }
        }

        private void DrawEdittingNumber()
        {
            if (_editingNumber == null)
                return;

            StringFormat format = new StringFormat();
            Font font = new Font("微軟正黑體", 16F);

            int NumberInARow = UnselectNumbers.Width / fontWidth;
            int indexOfeditingNumber = (int)_editingNumber - 1;
            int x = (int)(fontWidth * (indexOfeditingNumber % NumberInARow));
            int y = (int)(fontHeight * (indexOfeditingNumber / NumberInARow));
            string item = $"{_editingNumber / 10}{_editingNumber % 10}";

            const int rectXOffset = 0;
            const int rectYOffset = 5;

            _unselectNumbersGraphics.DrawRectangle(Pens.DarkSeaGreen, x + rectXOffset, y + rectYOffset, fontWidth, fontHeight);
            if (!_model.Contain(item))
                _unselectNumbersGraphics.DrawString($"{item}, ", font, Brushes.Orange, x, y);
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

        public void SelectEdittingNumber(int x, int y, int width, int height)
        {
            x -= width / 2;
            y -= height / 2;
            if ((1.0 * UnselectNumbers.Width / width) > (1.0 * UnselectNumbers.Height / height))
                height = UnselectNumbers.Height * width/ UnselectNumbers.Width;
            else width = UnselectNumbers.Width * height/ UnselectNumbers.Height;

            x = x * UnselectNumbers.Width / width;
            y = y * UnselectNumbers.Height / height;
            x += UnselectNumbers.Width / 2;
            y += UnselectNumbers.Height / 2;

            int NumberInARow = UnselectNumbers.Width / fontWidth;
            if (x / fontWidth >= NumberInARow)
                _editingNumber = null;
            else
            {
                _editingNumber = (y / fontHeight) * NumberInARow + (x / fontWidth) + 1;
                if (_editingNumber > numberOfMaximum || _editingNumber <= 0)
                    _editingNumber = null;
            }
            UpdateForm();
        }

        public void ChangeNumberStatus()
        {
            if (!IsEditMode || _editingNumber == null)
                return;

            string item = $"{_editingNumber / 10}{_editingNumber % 10}";
            if (_model.Contain(item))
                _model.RemoveItem(item);
            else _model.AddItem(item);
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
