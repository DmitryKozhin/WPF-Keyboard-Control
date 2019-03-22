// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnScreenKeyboard.xaml.cs" company="MyCompanyName">
//   The MIT License (MIT)
//   Copyright(c) 2014 Viacheslav Avsenev
// </copyright>
// <summary>
//   The on screen keyboard.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;

namespace TermControls
{
    /// <summary>
    ///     The on screen keyboard.
    /// </summary>
    public partial class OnScreenKeyboard : UserControl
    {
        /// <summary>
        ///     The text property.
        /// </summary>
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text",
            typeof(string),
            typeof(OnScreenKeyboard),
            new UIPropertyMetadata(null));

        /// <summary>
        ///     The command property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command",
            typeof(ICommand),
            typeof(OnScreenKeyboard));

        /// <summary>
        ///     Initializes a new instance of the <see cref="OnScreenKeyboard" /> class.
        /// </summary>
        public OnScreenKeyboard()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        public string Text
        {
            get => (string) GetValue(TextProperty);

            set => SetValue(TextProperty, value);
        }

        /// <summary>
        ///     Gets or sets the command.
        /// </summary>
        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);

            set => SetValue(CommandProperty, value);
        }
    }
}