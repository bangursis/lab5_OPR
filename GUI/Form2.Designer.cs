namespace GUI
{
    partial class Form2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.roadMap = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.Label();
            this.tables = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(18, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 249);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // roadMap
            // 
            this.roadMap.AutoSize = true;
            this.roadMap.Location = new System.Drawing.Point(15, 5);
            this.roadMap.Name = "roadMap";
            this.roadMap.Size = new System.Drawing.Size(35, 13);
            this.roadMap.TabIndex = 1;
            this.roadMap.Text = "label1";
            this.roadMap.Click += new System.EventHandler(this.roadMap_Click);
            // 
            // amount
            // 
            this.amount.AutoSize = true;
            this.amount.Location = new System.Drawing.Point(18, 22);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(35, 13);
            this.amount.TabIndex = 2;
            this.amount.Text = "label2";
            this.amount.Click += new System.EventHandler(this.amount_Click);
            // 
            // tables
            // 
            this.tables.Location = new System.Drawing.Point(18, 322);
            this.tables.Name = "tables";
            this.tables.Size = new System.Drawing.Size(703, 100);
            this.tables.TabIndex = 3;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tables);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.roadMap);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label roadMap;
        private System.Windows.Forms.Label amount;
        private System.Windows.Forms.FlowLayoutPanel tables;
    }
}