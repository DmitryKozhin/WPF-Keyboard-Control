using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using TermControls.Commands;
using TermControls.Models;

namespace TermControls.ViewModels
{
    public class KeyboardViewModel : INotifyPropertyChanged
    {
        private PackIconKind _kind;
        private string _spaceContent;
        private string _enterContent;
        private string _switchLangContent;
        private string _changeSymbolsButtonContent;
        public event PropertyChangedEventHandler PropertyChanged;


        public KeyboardViewModel()
        {
            Model = new KeyboardModelSymbols();
            Model.CreateButtons();

            ShiftKind = PackIconKind.AppleKeyboardShift;
            SpaceButtonContent = "space";
            EnterButtonContent = "return";
            SwitchLangButtonContent = "ru";
            ChangeSymbolsButtonContent = "123";
        }

        public KeyboardModel Model { get; set; }

        public ICommand ChangeLangCommand => new DelegateCommand(ChangeLangClick);

        public ICommand ShiftCommand => new DelegateCommand(ShiftClick);

        public ICommand DeleteCommand => new DelegateCommand(DeleteClick);

        public ICommand ButtonClickCommand => new DelegateCommand(param => Model.Text += param.ToString());

        public ICommand SpaceCommand => new DelegateCommand(param => Model.Text += " ");
        public ICommand ChangeSymbolsCommand => new DelegateCommand(param =>
        {
            Model.IsSymbols = !Model.IsSymbols;
            ChangeSymbolsButtonContent = Model.IsSymbols ? "ABC" : "123";
            Model.ChangeButtonsContent();
        });

        public PackIconKind ShiftKind
        {
            get => _kind;
            set
            {
                _kind = value;
                OnPropertyChanged(nameof(ShiftKind));
            }
        }

        public string SpaceButtonContent
        {
            get => _spaceContent;
            set
            {
                _spaceContent = value;
                OnPropertyChanged(nameof(SpaceButtonContent));
            }
        }

        public string EnterButtonContent
        {
            get => _enterContent;
            set
            {
                _enterContent = value;
                OnPropertyChanged(nameof(EnterButtonContent));
            }
        }

        public string SwitchLangButtonContent
        {
            get => _switchLangContent;
            set
            {
                _switchLangContent = value;
                OnPropertyChanged(nameof(SwitchLangButtonContent));
            }
        }

        public string ChangeSymbolsButtonContent
        {
            get => _changeSymbolsButtonContent;
            set
            {
                _changeSymbolsButtonContent = value;
                OnPropertyChanged(nameof(ChangeSymbolsButtonContent));
            }
        }

        private void ChangeLangClick(object param)
        {
            Model.IsEngRus = !Model.IsEngRus;
            if (!Model.IsEngRus)
            {
                SwitchLangButtonContent = "en";
                SpaceButtonContent = "space";
                EnterButtonContent = "return";
            }
            else
            {
                SwitchLangButtonContent = "ru";
                SpaceButtonContent = "пробел";
                EnterButtonContent = "готово";

            }
            Model.ChangeButtonsContent();
        }

        private void ShiftClick(object param)
        {
            Model.IsShift = !Model.IsShift;
            ShiftKind = Model.IsShift ? PackIconKind.AppleKeyboardCaps : PackIconKind.AppleKeyboardShift;
            Model.ChangeButtonsContent();
        }

        private void DeleteClick(object param)
        {
            if (!string.IsNullOrEmpty(Model.Text))
                Model.Text = Model.Text.Remove(Model.Text.Length - 1);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}