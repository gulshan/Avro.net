using PhoneticLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePad
{
    public class MainForm : Form
    {
        private readonly PhoneticEditor editor;
        private TextBox textBoxPhonetic;

        public MainForm()
        {
            editor = new PhoneticEditor();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            textBoxPhonetic = new TextBox
            {
                Font = new Font("Siyam Rupali", 14F, GraphicsUnit.Point),
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
                var givenCursorPosition = textBoxPhonetic.SelectionStart;
                var newChar = textBoxPhonetic.Text[givenCursorPosition - 1];
                var result = editor.PutNewChar(givenCursorPosition, newChar);

                if (result.replaceStartPosition < result.newCursorPosition)
                {
                    textBoxPhonetic.Text = textBoxPhonetic.Text
                        .Remove(result.replaceStartPosition, givenCursorPosition - result.replaceStartPosition)
                        .Insert(result.replaceStartPosition, result.output);

                    textBoxPhonetic.Select(result.newCursorPosition, 0);
                }
            }
        }
    }
}
