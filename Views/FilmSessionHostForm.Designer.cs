namespace ProgCourse.Views
{
    partial class FilmSessionHostForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dateTimePicker1 = new DateTimePicker();
            textBoxFilmName = new TextBox();
            labelHallID = new Label();
            labelFilmName = new Label();
            labelData = new Label();
            labelDuration = new Label();
            buttonAdd = new Button();
            numericUpDownHallID = new NumericUpDown();
            dateTimePickerDuration = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHallID).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(260, 109);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(131, 23);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.Value = new DateTime(2023, 12, 29, 6, 0, 4, 0);
            // 
            // textBoxFilmName
            // 
            textBoxFilmName.Location = new Point(37, 34);
            textBoxFilmName.Name = "textBoxFilmName";
            textBoxFilmName.Size = new Size(131, 23);
            textBoxFilmName.TabIndex = 1;
            // 
            // labelHallID
            // 
            labelHallID.AutoSize = true;
            labelHallID.Location = new Point(260, 16);
            labelHallID.Name = "labelHallID";
            labelHallID.Size = new Size(72, 15);
            labelHallID.TabIndex = 4;
            labelHallID.Text = "Номер зала";
            // 
            // labelFilmName
            // 
            labelFilmName.AutoSize = true;
            labelFilmName.Location = new Point(37, 16);
            labelFilmName.Name = "labelFilmName";
            labelFilmName.Size = new Size(106, 15);
            labelFilmName.TabIndex = 5;
            labelFilmName.Text = "Название фильма";
            // 
            // labelData
            // 
            labelData.AutoSize = true;
            labelData.Location = new Point(260, 91);
            labelData.Name = "labelData";
            labelData.Size = new Size(79, 15);
            labelData.TabIndex = 6;
            labelData.Text = "Дата проката";
            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.Location = new Point(37, 87);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(131, 15);
            labelDuration.TabIndex = 7;
            labelDuration.Text = "Длительность фильма";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(260, 156);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(125, 30);
            buttonAdd.TabIndex = 8;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // numericUpDownHallID
            // 
            numericUpDownHallID.Location = new Point(260, 35);
            numericUpDownHallID.Name = "numericUpDownHallID";
            numericUpDownHallID.Size = new Size(131, 23);
            numericUpDownHallID.TabIndex = 9;
            // 
            // dateTimePickerDuration
            // 
            dateTimePickerDuration.Format = DateTimePickerFormat.Time;
            dateTimePickerDuration.Location = new Point(37, 109);
            dateTimePickerDuration.Name = "dateTimePickerDuration";
            dateTimePickerDuration.Size = new Size(131, 23);
            dateTimePickerDuration.TabIndex = 10;
            dateTimePickerDuration.Value = new DateTime(2023, 12, 29, 0, 0, 0, 0);
            // 
            // FilmSessionHostForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 201);
            Controls.Add(dateTimePickerDuration);
            Controls.Add(numericUpDownHallID);
            Controls.Add(buttonAdd);
            Controls.Add(labelDuration);
            Controls.Add(labelData);
            Controls.Add(labelFilmName);
            Controls.Add(labelHallID);
            Controls.Add(textBoxFilmName);
            Controls.Add(dateTimePicker1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FilmSessionHostForm";
            Text = "FilmSessionHostForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDownHallID).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private TextBox textBoxFilmName;
        private Label labelHallID;
        private Label labelFilmName;
        private Label labelData;
        private Label labelDuration;
        private Button buttonAdd;
        private NumericUpDown numericUpDownHallID;
        private DateTimePicker dateTimePickerDuration;
    }
}