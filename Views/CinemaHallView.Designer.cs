namespace ProgCourse.Views
{
    partial class CinemaHallView
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
            buttonBuy = new Button();
            SuspendLayout();
            // 
            // buttonBuy
            // 
            buttonBuy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonBuy.Location = new Point(97, 171);
            buttonBuy.Name = "buttonBuy";
            buttonBuy.Size = new Size(125, 39);
            buttonBuy.TabIndex = 0;
            buttonBuy.Text = "Купить";
            buttonBuy.UseVisualStyleBackColor = true;
            // 
            // CinemaHallView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(245, 247);
            Controls.Add(buttonBuy);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CinemaHallView";
            Text = "CinemaHallView";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonBuy;
    }
}