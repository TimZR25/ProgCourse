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
            dateTimePickerDate = new DateTimePicker();
            textBoxFilmName = new TextBox();
            labelHallID = new Label();
            labelFilmName = new Label();
            labelData = new Label();
            labelDuration = new Label();
            buttonAdd = new Button();
            dateTimePickerDuration = new DateTimePicker();
            comboBoxHallID = new ComboBox();
            dateTimePickerStartTime = new DateTimePicker();
            labelStartTime = new Label();
            SuspendLayout();
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Location = new Point(260, 109);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(131, 23);
            dateTimePickerDate.TabIndex = 0;
            dateTimePickerDate.Value = new DateTime(2023, 12, 29, 6, 0, 4, 0);
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
            labelDuration.Location = new Point(37, 69);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(131, 15);
            labelDuration.TabIndex = 7;
            labelDuration.Text = "Длительность фильма";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(260, 156);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(131, 30);
            buttonAdd.TabIndex = 8;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // dateTimePickerDuration
            // 
            dateTimePickerDuration.Format = DateTimePickerFormat.Time;
            dateTimePickerDuration.Location = new Point(37, 91);
            dateTimePickerDuration.Name = "dateTimePickerDuration";
            dateTimePickerDuration.Size = new Size(131, 23);
            dateTimePickerDuration.TabIndex = 10;
            dateTimePickerDuration.Value = new DateTime(2023, 12, 29, 0, 0, 0, 0);
            // 
            // comboBoxHallID
            // 
            comboBoxHallID.FormattingEnabled = true;
            comboBoxHallID.Location = new Point(260, 34);
            comboBoxHallID.Name = "comboBoxHallID";
            comboBoxHallID.Size = new Size(131, 23);
            comboBoxHallID.TabIndex = 11;
            // 
            // dateTimePickerStartTime
            // 
            dateTimePickerStartTime.Format = DateTimePickerFormat.Time;
            dateTimePickerStartTime.Location = new Point(37, 156);
            dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            dateTimePickerStartTime.Size = new Size(131, 23);
            dateTimePickerStartTime.TabIndex = 13;
            dateTimePickerStartTime.Value = new DateTime(2023, 12, 29, 0, 0, 0, 0);
            // 
            // labelStartTime
            // 
            labelStartTime.AutoSize = true;
            labelStartTime.Location = new Point(37, 134);
            labelStartTime.Name = "labelStartTime";
            labelStartTime.Size = new Size(96, 15);
            labelStartTime.TabIndex = 12;
            labelStartTime.Text = "Начало фильма";
            // 
            // FilmSessionHostForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 201);
            Controls.Add(dateTimePickerStartTime);
            Controls.Add(labelStartTime);
            Controls.Add(comboBoxHallID);
            Controls.Add(dateTimePickerDuration);
            Controls.Add(buttonAdd);
            Controls.Add(labelDuration);
            Controls.Add(labelData);
            Controls.Add(labelFilmName);
            Controls.Add(labelHallID);
            Controls.Add(textBoxFilmName);
            Controls.Add(dateTimePickerDate);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FilmSessionHostForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление кино-сессии";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePickerDate;
        private TextBox textBoxFilmName;
        private Label labelHallID;
        private Label labelFilmName;
        private Label labelData;
        private Label labelDuration;
        private Button buttonAdd;
        private DateTimePicker dateTimePickerDuration;
        private ComboBox comboBoxHallID;
        private DateTimePicker dateTimePickerStartTime;
        private Label labelStartTime;
    }
}