// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeyboardModelRuEng.cs" company="MyCompanyName">
//   The MIT License (MIT)
//   Copyright(c) 2014 Viacheslav Avsenev
// </copyright>
// <summary>
//   Defines the KeyboardModelRuEng type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TermControls.Models
{
    /// <summary>
    ///     The keyboard model russian english.
    /// </summary>
    public class KeyboardModelSymbols : KeyboardModel
    {
        /// <summary>
        ///     The initialize content.
        /// </summary>
        protected override void InitContent()
        {
            Content1 = new[] {"йцукенгшщзхъ", "фывапролджэ", "ячсмитьбю"};
            Content1Shift = new[] {"ЙЦУКЕНГШЩЗХЪ", "ФЫВАПРОЛДЖЭ", "ЯЧСМИТЬБЮ"};
            Content2 = new[] {"qwertyuiop", "asdfghjkl", "zxcvbnm"};
            Content2Shift = new[] {"QWERTYUIOP", "ASDFGHJKL", "ZXCVBNM"};

            Content3 = new[] { "1234567890", "-/:;()\"@*#", "%&+!,.?" };
        }
    }
}