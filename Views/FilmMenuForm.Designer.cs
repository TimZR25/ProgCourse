namespace ProgCourse.Views
{
    partial class FilmMenuForm
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
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "0", "FilmName", "Time-Time", "xx.xx.xxxx" }, -1);
            buttonNavigate = new Button();
            listViewSessions = new ListView();
            columnHeaderHallID = new ColumnHeader();
            columnHeaderFilm = new ColumnHeader();
            columnHeaderDuration = new ColumnHeader();
            columnHeaderDate = new ColumnHeader();
            buttonRemove = new Button();
            buttonAdd = new Button();
            SuspendLayout();
            // 
            // buttonNavigate
            // 
            buttonNavigate.Location = new Point(612, 309);
            buttonNavigate.Name = "buttonNavigate";
            buttonNavigate.Size = new Size(144, 50);
            buttonNavigate.TabIndex = 0;
            buttonNavigate.Text = "Перейти";
            buttonNavigate.UseVisualStyleBackColor = true;
            buttonNavigate.Click += buttonNavigate_Click;
            // 
            // listViewSessions
            // 
            listViewSessions.Columns.AddRange(new ColumnHeader[] { columnHeaderHallID, columnHeaderFilm, columnHeaderDuration, columnHeaderDate });
            listViewSessions.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewSessions.Items.AddRange(new ListViewItem[] { listViewItem1 });
            listViewSessions.Location = new Point(12, 12);
            listViewSessions.MultiSelect = false;
            listViewSessions.Name = "listViewSessions";
            listViewSessions.Size = new Size(594, 347);
            listViewSessions.TabIndex = 1;
            listViewSessions.UseCompatibleStateImageBehavior = false;
            listViewSessions.View = View.Details;
            listViewSessions.SelectedIndexChanged += listViewSessions_SelectedIndexChanged;
            // 
            // columnHeaderHallID
            // 
            columnHeaderHallID.Text = "HallID";
            columnHeaderHallID.Width = 50;
            // 
            // columnHeaderFilm
            // 
            columnHeaderFilm.Text = "Film";
            columnHeaderFilm.Width = 180;
            // 
            // columnHeaderDuration
            // 
            columnHeaderDuration.Text = "Duration";
            columnHeaderDuration.Width = 180;
            // 
            // columnHeaderDate
            // 
            columnHeaderDate.Text = "Date";
            columnHeaderDate.Width = 180;
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(612, 68);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(144, 50);
            buttonRemove.TabIndex = 2;
            buttonRemove.Text = "Удалить";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(612, 12);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(144, 50);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // FilmMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(763, 371);
            Controls.Add(buttonAdd);
            Controls.Add(buttonRemove);
            Controls.Add(listViewSessions);
            Controls.Add(buttonNavigate);
            MaximizeBox = false;
            Name = "FilmMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FilmMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonNavigate;
        private ListView listViewSessions;
        private ColumnHeader columnHeaderHallID;
        private ColumnHeader columnHeaderFilm;
        private ColumnHeader columnHeaderDuration;
        private ColumnHeader columnHeaderDate;
        private Button buttonRemove;
        private Button buttonAdd;
    }
}