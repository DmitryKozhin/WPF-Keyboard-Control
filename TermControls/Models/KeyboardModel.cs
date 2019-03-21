using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TermControls.Models
{
    /// <summary>
    ///     The keyboard model.
    /// </summary>
    public class KeyboardModel : INotifyPropertyChanged
    {
        /// <summary>
        ///     The text.
        /// </summary>
        private string text;

        /// <summary>
        ///     Gets or sets the content 1.
        /// </summary>
        protected string[] Content1 { get; set; }

        /// <summary>
        ///     Gets or sets the content 1 shift.
        /// </summary>
        protected string[] Content1Shift { get; set; }

        /// <summary>
        ///     Gets or sets the content 2.
        /// </summary>
        protected string[] Content2 { get; set; }

        /// <summary>
        ///     Gets or sets the content 2 shift.
        /// </summary>
        protected string[] Content2Shift { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is shift.
        /// </summary>
        public bool IsShift { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is eng rus.
        /// </summary>
        public bool IsEngRus { get; set; }

        /// <summary>
        ///     Gets the content.
        /// </summary>
        public string[] Content
        {
            get
            {
                if (!IsShift && IsEngRus) return Content1;
                if (IsShift && IsEngRus) return Content1Shift;
                if (!IsShift && !IsEngRus) return Content2;
                if (IsShift && !IsEngRus) return Content2Shift;
                return null;
            }
        }

        /// <summary>
        ///     Gets the buttons raw 1.
        /// </summary>
        public ObservableCollection<ButtonModel> ButtonsRaw1 { get; private set; }

        /// <summary>
        ///     Gets the buttons raw 2.
        /// </summary>
        public ObservableCollection<ButtonModel> ButtonsRaw2 { get; private set; }

        /// <summary>
        ///     Gets the buttons raw 3.
        /// </summary>
        public ObservableCollection<ButtonModel> ButtonsRaw3 { get; private set; }

        /// <summary>
        ///     Gets the buttons raw 4.
        /// </summary>
        public ObservableCollection<ButtonModel> ButtonsRaw4 { get; private set; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        #region Methods

        /// <summary>
        ///     The get button content.
        /// </summary>
        /// <param name="btnName">
        ///     The btn name.
        /// </param>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public string GetButtonContent(string btnName)
        {
            var raw = Convert.ToInt32(btnName[1].ToString()) - 1;
            var col = btnName.Length == 3
                ? Convert.ToInt32(btnName[2].ToString()) - 1
                : Convert.ToInt32(btnName[2] + btnName[3].ToString()) - 1;
            return Content[raw][col].ToString();
        }

        /// <summary>
        ///     The change buttons content.
        /// </summary>
        public void ChangeButtonsContent()
        {
            ChangeButtonsContent(ButtonsRaw1, 0);
            ChangeButtonsContent(ButtonsRaw2, 1);
            ChangeButtonsContent(ButtonsRaw3, 2);
            ChangeButtonsContent(ButtonsRaw4, 3);
        }

        /// <summary>
        ///     The create buttons.
        /// </summary>
        public void CreateButtons()
        {
            ButtonsRaw1 = CreateButtons(0);
            ButtonsRaw2 = CreateButtons(1);
            ButtonsRaw3 = CreateButtons(2);
            ButtonsRaw4 = CreateButtons(3);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="KeyboardModel" /> class.
        /// </summary>
        public KeyboardModel()
        {
            IsShift = false;
            IsEngRus = false;
            InitContent();
        }

        /// <summary>
        ///     The init content.
        /// </summary>
        public virtual void InitContent()
        {
        }

        /// <summary>
        ///     The create buttons.
        /// </summary>
        /// <param name="raw">
        ///     The _raw.
        /// </param>
        /// <returns>
        ///     The <see cref="ObservableCollection" />.
        /// </returns>
        private ObservableCollection<ButtonModel> CreateButtons(int raw)
        {
            var buttons = new ObservableCollection<ButtonModel>();
            for (var j = 1; j <= Content[raw].Length; j++)
            {
                var name = $"b{raw + 1}{j}";
                buttons.Add(new ButtonModel {Name = name, Column = j - 1, Content = GetButtonContent(name)});
            }

            return buttons;
        }

        /// <summary>
        ///     The change buttons content.
        /// </summary>
        /// <param name="buttons">
        ///     The _buttons.
        /// </param>
        /// <param name="_raw">
        ///     The _raw.
        /// </param>
        private void ChangeButtonsContent(ObservableCollection<ButtonModel> buttons, int _raw)
        {
            for (var j = 1; j <= Content[_raw].Length; j++)
                buttons[j - 1].Content = GetButtonContent(buttons[j - 1].Name);
        }

        #endregion

        #region INotifyPropertyChanged Members

        /// <summary>
        ///     The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     The on property changed.
        /// </summary>
        /// <param name="propertyName">
        ///     The property name.
        /// </param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}