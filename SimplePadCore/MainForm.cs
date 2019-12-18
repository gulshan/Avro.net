using OkkhorLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePad
{
    public class MainForm : Form
    {
        private const string TITLE_BN = "AvroPad - বাংলা";
        private const string TITLE_EN = "AvroPad - English";

        private readonly PhoneticEditor editor;
        private readonly TextBox textBoxPhonetic;
        private bool phoneticMode = true;

        public MainForm()
        {
            editor = new PhoneticEditor();

            SuspendLayout();

            textBoxPhonetic = new TextBox
            {
                Font = new Font("Siyam Rupali", 14),
                Dock = DockStyle.Fill,
                Multiline = true,
                TabIndex = 0
            };
            textBoxPhonetic.TextChanged += TextBoxPhonetic_TextChanged;
            textBoxPhonetic.KeyDown += Pad_KeyDown;

            // Initialize MainForm
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Padding = new Padding(5);
            Controls.Add(textBoxPhonetic);
            Name = nameof(MainForm);
            Text = TITLE_BN;

            ResumeLayout(true);
        }

        private void TextBoxPhonetic_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPhonetic.Modified && textBoxPhonetic.SelectionStart > 0)
            {
                var cursorPosition = textBoxPhonetic.SelectionStart;
                var newChar = textBoxPhonetic.Text[cursorPosition - 1];
                var result = editor.PutNewChar(newChar, cursorPosition);

                if (result.replaceLength > 0)
                {
                    var replaceStartPosition = cursorPosition - result.replaceLength;
                    textBoxPhonetic.Text = textBoxPhonetic.Text
                        .Remove(replaceStartPosition, result.replaceLength)
                        .Insert(replaceStartPosition, result.output);

                    textBoxPhonetic.Select(replaceStartPosition + result.output.Length, 0);
                }
            }
        }

        private void Pad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                AlterMode();
            }
        }

        private void AlterMode()
        {
            if (phoneticMode)
            {
                textBoxPhonetic.TextChanged -= TextBoxPhonetic_TextChanged;
                Text = TITLE_EN;
                phoneticMode = false;
                editor.Reset();
            }
            else
            {
                textBoxPhonetic.TextChanged += TextBoxPhonetic_TextChanged;
                Text = TITLE_BN;
                phoneticMode = true;
            }
        }
    }
}
