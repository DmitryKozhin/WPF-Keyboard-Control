using System.Windows.Input;
using TermControls.Commands;
using TermControls.Models;

namespace TermControls.ViewModels
{
    public class KeyboardViewModel
    {
        public KeyboardViewModel()
        {
            Model = new KeyboardModelRuEng();
            Model.CreateButtons();
        }

        public KeyboardModel Model { get; set; }

        public ICommand ChangeLangCommand => new DelegateCommand(ChangeLangClick);

        public ICommand ShiftCommand => new DelegateCommand(ShiftClick);

        public ICommand DeleteCommand => new DelegateCommand(DeleteClick);

        public ICommand ButtonClickCommand => new DelegateCommand(ButtonClick);

        public ICommand SpaceCommand => new DelegateCommand(SpaceClick);

        public void ChangeLangClick(object param)
        {
            Model.IsEngRus = !Model.IsEngRus;
            Model.ChangeButtonsContent();
        }

        public void ShiftClick(object param)
        {
            Model.IsShift = !Model.IsShift;
            Model.ChangeButtonsContent();
        }

        public void DeleteClick(object param)
        {
            if (!string.IsNullOrEmpty(Model.Text)) Model.Text = Model.Text.Remove(Model.Text.Length - 1);
        }

        public void ButtonClick(object param)
        {
            Model.Text += param.ToString();
        }

        public void SpaceClick(object param)
        {
            Model.Text += " ";
        }
    }
}