using PhoneticLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePad
{
    public class MainForm : Form
    {
        private readonly PhoneticEditor editor;
        private readonly TextBox textBoxPhonetic;

        public MainForm()
        {
            editor = new PhoneticEditor();

            SuspendLayout();

            textBoxPhonetic = new TextBox
            {
                Font = new Font("Siyam Rupali", 14),
                Dock = DockStyle.Fill,
                Multiline = true,
                Name = "textBoxPhonetic",
                TabIndex = 0
            };
            textBoxPhonetic.TextChanged += TextBoxPhonetic_TextChanged;

            // Initialize MainForm
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Padding = new Padding(5);
            Controls.Add(textBoxPhonetic);
            Name = "MainForm";
            Text = "AvroPad";

            ResumeLayout(false);
            PerformLayout();
        }

        private void TextBoxPhonetic_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPhonetic.Modified && textBoxPhonetic.SelectionStart > 0)
            {
                var cursorPosition = textBoxPhonetic.SelectionStart;
                var newChar = textBoxPhonetic.Text[cursorPosition - 1];
                var result = editor.PutNewChar(cursorPosition, newChar);

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
    }
}
