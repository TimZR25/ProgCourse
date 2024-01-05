namespace ProgCourse.Views
{
    partial class CinemaHallForm
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
            labelCostText = new Label();
            labelAmountText = new Label();
            labelCost = new Label();
            labelAmount = new Label();
            SuspendLayout();
            // 
            // buttonBuy
            // 
            buttonBuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonBuy.BackColor = Color.White;
            buttonBuy.Location = new Point(90, 119);
            buttonBuy.Name = "buttonBuy";
            buttonBuy.Size = new Size(176, 39);
            buttonBuy.TabIndex = 0;
            buttonBuy.Text = "Купить";
            buttonBuy.UseVisualStyleBackColor = false;
            buttonBuy.Click += buttonBuy_Click;
            // 
            // labelCostText
            // 
            labelCostText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCostText.BackColor = Color.White;
            labelCostText.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelCostText.ForeColor = SystemColors.ControlText;
            labelCostText.Location = new Point(90, 83);
            labelCostText.Name = "labelCostText";
            labelCostText.Size = new Size(130, 19);
            labelCostText.TabIndex = 1;
            labelCostText.Text = "Стоимость:";
            // 
            // labelAmountText
            // 
            labelAmountText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelAmountText.BackColor = Color.White;
            labelAmountText.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelAmountText.ForeColor = SystemColors.ControlText;
            labelAmountText.Location = new Point(90, 44);
            labelAmountText.Name = "labelAmountText";
            labelAmountText.Size = new Size(130, 19);
            labelAmountText.TabIndex = 2;
            labelAmountText.Text = "Билетов к покупке:";
            // 
            // labelCost
            // 
            labelCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCost.BackColor = Color.White;
            labelCost.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelCost.ForeColor = SystemColors.ControlText;
            labelCost.Location = new Point(225, 83);
            labelCost.Name = "labelCost";
            labelCost.Size = new Size(41, 19);
            labelCost.TabIndex = 3;
            labelCost.Text = "0";
            labelCost.TextAlign = ContentAlignment.TopRight;
            // 
            // labelAmount
            // 
            labelAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelAmount.BackColor = Color.White;
            labelAmount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelAmount.ForeColor = SystemColors.ControlText;
            labelAmount.Location = new Point(225, 44);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(41, 19);
            labelAmount.TabIndex = 4;
            labelAmount.Text = "0";
            labelAmount.TextAlign = ContentAlignment.TopRight;
            // 
            // CinemaHallForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(278, 247);
            Controls.Add(labelAmount);
            Controls.Add(labelCost);
            Controls.Add(labelAmountText);
            Controls.Add(labelCostText);
            Controls.Add(buttonBuy);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CinemaHallForm";
            Text = "Зал№";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonBuy;
        private Label labelCostText;
        private Label labelAmountText;
        private Label labelCost;
        private Label labelAmount;
    }
}