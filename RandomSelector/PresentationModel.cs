using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RandomSelector
{
    public class PresentationModel
    {
        public delegate void FormChanged();

        public event FormChanged FormChangedEvent;

        private const string DEFUALT_ITEM = "0 0";

        readonly RandomSelectorModel _model;
        readonly Random _random = new Random();

        private bool _isSelecting;
        public bool IsBeginSelect
        {
            get;
            private set;
        }
        public string Display
        {
            get;
            private set;
        }
        public StringBuilder UnselectNumbers
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

        public void UpdateForm(string item)
        {
            if (item == null)
                item = DEFUALT_ITEM;
            Display = item;
            SetUnselcectNumber();
            FormChangedEvent?.Invoke();
        }

        public void CheckNumber(int maximum)
        {
            if (IsBeginSelect)
                return;
            _model.ClearList();
            for (int i = 1; i <= maximum; i++)
            {
                _model.AddItem($"{i / 10} {i % 10}");
            }
            IsBeginSelect = true;
            LoadForm();
        }

        private void SetUnselcectNumber()
        {
            List<string> list = _model.GetList();
            UnselectNumbers = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                UnselectNumbers.Append($"{list[i]}, ");
                if ((i+1) % 6 == 0)
                    UnselectNumbers.AppendLine();
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

                if(selectedNumber==null)
                {
                    UpdateForm(DEFUALT_ITEM);
                    _isSelecting = false;
                    return;
                }

                int tempNumber;
                const int TOTAL_MILLISECONDS = 2000;
                const int NUMBER_OF_TRANSITION = 20;

                for (int i = 0; i < NUMBER_OF_TRANSITION; i++)
                {
                    tempNumber = _random.Next(99) + 1;
                    UpdateForm($"{tempNumber / 10} {tempNumber % 10}");
                    Thread.Sleep(TOTAL_MILLISECONDS / NUMBER_OF_TRANSITION / 2);
                }

                for (int i = 0; i < NUMBER_OF_TRANSITION; i++)
                {
                    tempNumber = _random.Next(99) + 1;
                    UpdateForm($"{selectedNumber[0]} {tempNumber % 10}");
                    Thread.Sleep(TOTAL_MILLISECONDS / NUMBER_OF_TRANSITION / 2);
                }

                _model.RemoveItem(selectedNumber);
                UpdateForm(selectedNumber);

                _isSelecting = false;
            });
        }
    }
}
