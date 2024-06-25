using System.Drawing;
using System.Windows.Forms;

namespace GUIApp
{
    partial class FootballForm
    {

        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>

        private static DialogResult ShowInputDialogBox(ref string input, string prompt,
                                                   string title = "Title", int width = 300,
                                                   int height = 200)
        {
            // This function creates the custom input dialog box by individually creating the different
            // window elements and adding them to the dialog box

            // Specify the size of the window using the parameters passed
            Size size = new Size(width, height);
            // Create a new form using a System.Windows Form
            Form inputBox = new Form();

            inputBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            // Set the window title using the parameter passed
            inputBox.Text = title;

            // Create a new label to hold the prompt
            Label label = new Label();
            label.Text = prompt;
            label.Location = new Point(5, 5);
            label.Width = size.Width - 10;
            inputBox.Controls.Add(label);

            // Create a textbox to accept the user's input
            TextBox textBox = new TextBox();
            textBox.Size = new Size(size.Width - 10, 23);
            textBox.Location = new Point(5, label.Location.Y + 20);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            // Create an OK Button
            Button okButton = new Button();
            okButton.DialogResult = DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new Point(size.Width - 80 - 80, size.Height - 30);
            inputBox.Controls.Add(okButton);

            // Create a Cancel Button
            Button cancelButton = new Button();
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new Point(size.Width - 80, size.Height - 30);
            inputBox.Controls.Add(cancelButton);

            // Set the input box's buttons to the created OK and Cancel Buttons respectively so the window
            // appropriately behaves with the button clicks
            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            // Show the window dialog box
            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;

            // After input has been submitted, return the input value
            return result;
        }
        private void InitializeComponent()
        {
            this.inputLeague = new System.Windows.Forms.Button();
            this.textLeague = new System.Windows.Forms.TextBox();
            this.listLeague = new System.Windows.Forms.ListBox();
            this.textCom = new System.Windows.Forms.TextBox();
            this.inputCom = new System.Windows.Forms.Button();
            this.textPlayer = new System.Windows.Forms.TextBox();
            this.inputPlayer = new System.Windows.Forms.Button();
            this.comboBoxLeague = new System.Windows.Forms.ComboBox();
            this.listBoxPlayer = new System.Windows.Forms.ListBox();
            this.listBoxCom = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LoadForm = new System.Windows.Forms.Button();
            this.SaveForm = new System.Windows.Forms.Button();
            this.editLeague = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.editCom = new System.Windows.Forms.Button();
            this.labelCom = new System.Windows.Forms.Label();
            this.deleteCom = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.editPlayer = new System.Windows.Forms.Button();
            this.labelPlayer = new System.Windows.Forms.Label();
            this.deletePlayer = new System.Windows.Forms.Button();
            this.picture = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // inputLeague
            // 
            this.inputLeague.Location = new System.Drawing.Point(132, 3);
            this.inputLeague.Name = "inputLeague";
            this.inputLeague.Size = new System.Drawing.Size(95, 22);
            this.inputLeague.TabIndex = 0;
            this.inputLeague.Text = "Добавить лигу";
            this.inputLeague.UseVisualStyleBackColor = true;
            this.inputLeague.Click += new System.EventHandler(this.inputLeague_Click);
            // 
            // textLeague
            // 
            this.textLeague.Location = new System.Drawing.Point(4, 3);
            this.textLeague.Name = "textLeague";
            this.textLeague.Size = new System.Drawing.Size(100, 20);
            this.textLeague.TabIndex = 1;
            // 
            // listLeague
            // 
            this.listLeague.Location = new System.Drawing.Point(0, 0);
            this.listLeague.Name = "listLeague";
            this.listLeague.Size = new System.Drawing.Size(120, 96);
            this.listLeague.TabIndex = 0;
            // 
            // textCom
            // 
            this.textCom.Location = new System.Drawing.Point(4, 20);
            this.textCom.Name = "textCom";
            this.textCom.Size = new System.Drawing.Size(100, 20);
            this.textCom.TabIndex = 4;
            // 
            // inputCom
            // 
            this.inputCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inputCom.Location = new System.Drawing.Point(3, 400);
            this.inputCom.Name = "inputCom";
            this.inputCom.Size = new System.Drawing.Size(112, 22);
            this.inputCom.TabIndex = 3;
            this.inputCom.Text = "Добавить команду";
            this.inputCom.UseVisualStyleBackColor = true;
            this.inputCom.Click += new System.EventHandler(this.inputCom_Click);
            // 
            // textPlayer
            // 
            this.textPlayer.Location = new System.Drawing.Point(4, 20);
            this.textPlayer.Name = "textPlayer";
            this.textPlayer.Size = new System.Drawing.Size(100, 20);
            this.textPlayer.TabIndex = 7;
            // 
            // inputPlayer
            // 
            this.inputPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inputPlayer.Location = new System.Drawing.Point(3, 399);
            this.inputPlayer.Name = "inputPlayer";
            this.inputPlayer.Size = new System.Drawing.Size(112, 22);
            this.inputPlayer.TabIndex = 6;
            this.inputPlayer.Text = "Добавить игрока";
            this.inputPlayer.UseVisualStyleBackColor = true;
            this.inputPlayer.Click += new System.EventHandler(this.inputPlayer_Click);
            // 
            // comboBoxLeague
            // 
            this.comboBoxLeague.FormattingEnabled = true;
            this.comboBoxLeague.Location = new System.Drawing.Point(4, 29);
            this.comboBoxLeague.Name = "comboBoxLeague";
            this.comboBoxLeague.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLeague.TabIndex = 9;
            // 
            // listBoxPlayer
            // 
            this.listBoxPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxPlayer.FormattingEnabled = true;
            this.listBoxPlayer.Location = new System.Drawing.Point(0, 46);
            this.listBoxPlayer.Name = "listBoxPlayer";
            this.listBoxPlayer.Size = new System.Drawing.Size(181, 329);
            this.listBoxPlayer.TabIndex = 11;
            // 
            // listBoxCom
            // 
            this.listBoxCom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxCom.FormattingEnabled = true;
            this.listBoxCom.Location = new System.Drawing.Point(0, 46);
            this.listBoxCom.Name = "listBoxCom";
            this.listBoxCom.Size = new System.Drawing.Size(175, 329);
            this.listBoxCom.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LoadForm);
            this.panel1.Controls.Add(this.SaveForm);
            this.panel1.Controls.Add(this.editLeague);
            this.panel1.Controls.Add(this.comboBoxLeague);
            this.panel1.Controls.Add(this.textLeague);
            this.panel1.Controls.Add(this.inputLeague);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(373, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 54);
            this.panel1.TabIndex = 13;
            // 
            // LoadForm
            // 
            this.LoadForm.Location = new System.Drawing.Point(664, 4);
            this.LoadForm.Name = "LoadForm";
            this.LoadForm.Size = new System.Drawing.Size(111, 23);
            this.LoadForm.TabIndex = 12;
            this.LoadForm.Text = "Загрузить форму";
            this.LoadForm.UseVisualStyleBackColor = true;
            // 
            // SaveForm
            // 
            this.SaveForm.Location = new System.Drawing.Point(547, 4);
            this.SaveForm.Name = "SaveForm";
            this.SaveForm.Size = new System.Drawing.Size(111, 23);
            this.SaveForm.TabIndex = 11;
            this.SaveForm.Text = "Сохранить форму";
            this.SaveForm.UseVisualStyleBackColor = true;
            // 
            // editLeague
            // 
            this.editLeague.Location = new System.Drawing.Point(233, 3);
            this.editLeague.Name = "editLeague";
            this.editLeague.Size = new System.Drawing.Size(146, 23);
            this.editLeague.TabIndex = 10;
            this.editLeague.Text = "Изменить название лиги";
            this.editLeague.UseVisualStyleBackColor = true;
            this.editLeague.Click += new System.EventHandler(this.editLeague_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.editCom);
            this.panel2.Controls.Add(this.labelCom);
            this.panel2.Controls.Add(this.deleteCom);
            this.panel2.Controls.Add(this.textCom);
            this.panel2.Controls.Add(this.listBoxCom);
            this.panel2.Controls.Add(this.inputCom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(175, 495);
            this.panel2.TabIndex = 14;
            // 
            // editCom
            // 
            this.editCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editCom.Location = new System.Drawing.Point(1, 428);
            this.editCom.Name = "editCom";
            this.editCom.Size = new System.Drawing.Size(168, 23);
            this.editCom.TabIndex = 15;
            this.editCom.Text = "Изменить название команды";
            this.editCom.UseVisualStyleBackColor = true;
            this.editCom.Click += new System.EventHandler(this.editCom_Click);
            // 
            // labelCom
            // 
            this.labelCom.AutoSize = true;
            this.labelCom.Location = new System.Drawing.Point(4, 4);
            this.labelCom.Name = "labelCom";
            this.labelCom.Size = new System.Drawing.Size(98, 13);
            this.labelCom.TabIndex = 14;
            this.labelCom.Text = "Название команд";
            // 
            // deleteCom
            // 
            this.deleteCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteCom.Location = new System.Drawing.Point(3, 457);
            this.deleteCom.Name = "deleteCom";
            this.deleteCom.Size = new System.Drawing.Size(111, 26);
            this.deleteCom.TabIndex = 13;
            this.deleteCom.Text = "Удалить команду";
            this.deleteCom.UseVisualStyleBackColor = true;
            this.deleteCom.Click += new System.EventHandler(this.deleteCom_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.editPlayer);
            this.panel3.Controls.Add(this.labelPlayer);
            this.panel3.Controls.Add(this.deletePlayer);
            this.panel3.Controls.Add(this.textPlayer);
            this.panel3.Controls.Add(this.listBoxPlayer);
            this.panel3.Controls.Add(this.inputPlayer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(685, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 495);
            this.panel3.TabIndex = 15;
            // 
            // editPlayer
            // 
            this.editPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editPlayer.Location = new System.Drawing.Point(6, 428);
            this.editPlayer.Name = "editPlayer";
            this.editPlayer.Size = new System.Drawing.Size(139, 23);
            this.editPlayer.TabIndex = 16;
            this.editPlayer.Text = "Изменить ФИО игрока";
            this.editPlayer.UseVisualStyleBackColor = true;
            this.editPlayer.Click += new System.EventHandler(this.editPlayer_Click);
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.Location = new System.Drawing.Point(3, 4);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(85, 13);
            this.labelPlayer.TabIndex = 15;
            this.labelPlayer.Text = "Имена игроков";
            // 
            // deletePlayer
            // 
            this.deletePlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deletePlayer.Location = new System.Drawing.Point(3, 456);
            this.deletePlayer.Name = "deletePlayer";
            this.deletePlayer.Size = new System.Drawing.Size(108, 26);
            this.deletePlayer.TabIndex = 12;
            this.deletePlayer.Text = "Удалить игрока";
            this.deletePlayer.UseVisualStyleBackColor = true;
            this.deletePlayer.Click += new System.EventHandler(this.deletePlayer_Click);
            // 
            // picture
            // 
            this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture.Location = new System.Drawing.Point(175, 54);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(510, 495);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 16;
            this.picture.TabStop = false;
            // 
            // Football
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 549);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Football";
            this.Text = "Футбольчик";
            //this.Load += new System.EventHandler(this.Football_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button inputLeague;
        private System.Windows.Forms.TextBox textLeague;
        private System.Windows.Forms.ListBox listLeague;
        private System.Windows.Forms.TextBox textCom;
        private System.Windows.Forms.Button inputCom;
        private System.Windows.Forms.TextBox textPlayer;
        private System.Windows.Forms.Button inputPlayer;
        private System.Windows.Forms.ComboBox comboBoxLeague;
        private System.Windows.Forms.ListBox listBoxPlayer;
        private System.Windows.Forms.ListBox listBoxCom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button deleteCom;
        private System.Windows.Forms.Button deletePlayer;
        private System.Windows.Forms.Label labelCom;
        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button editLeague;
        private System.Windows.Forms.Button editCom;
        private System.Windows.Forms.Button editPlayer;
        private Button LoadForm;
        private Button SaveForm;

        private string ShowInputDialog(string promptText, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = promptText };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "ОК", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}