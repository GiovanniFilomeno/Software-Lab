namespace obstacle_avoidance1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.TBTest = new System.Windows.Forms.TextBox();
            this.btnPed = new System.Windows.Forms.Button();
            this.btnElement = new System.Windows.Forms.Button();
            this.btnCons = new System.Windows.Forms.Button();
            this.PbGrid = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PbGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TBTest
            // 
            this.TBTest.Location = new System.Drawing.Point(618, 241);
            this.TBTest.Multiline = true;
            this.TBTest.Name = "TBTest";
            this.TBTest.ReadOnly = true;
            this.TBTest.Size = new System.Drawing.Size(192, 119);
            this.TBTest.TabIndex = 0;
            // 
            // btnPed
            // 
            this.btnPed.Location = new System.Drawing.Point(668, 71);
            this.btnPed.Name = "btnPed";
            this.btnPed.Size = new System.Drawing.Size(75, 23);
            this.btnPed.TabIndex = 1;
            this.btnPed.Text = "button1";
            this.btnPed.UseVisualStyleBackColor = true;
            this.btnPed.Click += new System.EventHandler(this.btnPed_Click);
            // 
            // btnElement
            // 
            this.btnElement.Location = new System.Drawing.Point(668, 124);
            this.btnElement.Name = "btnElement";
            this.btnElement.Size = new System.Drawing.Size(75, 23);
            this.btnElement.TabIndex = 2;
            this.btnElement.Text = "Element";
            this.btnElement.UseVisualStyleBackColor = true;
            this.btnElement.Click += new System.EventHandler(this.btnElement_Click);
            // 
            // btnCons
            // 
            this.btnCons.Location = new System.Drawing.Point(668, 174);
            this.btnCons.Name = "btnCons";
            this.btnCons.Size = new System.Drawing.Size(75, 23);
            this.btnCons.TabIndex = 3;
            this.btnCons.Text = "Construction";
            this.btnCons.UseVisualStyleBackColor = true;
            this.btnCons.Click += new System.EventHandler(this.btnCons_Click);
            // 
            // PbGrid
            // 
            this.PbGrid.BackColor = System.Drawing.Color.White;
            this.PbGrid.Location = new System.Drawing.Point(12, 1);
            this.PbGrid.Name = "PbGrid";
            this.PbGrid.Size = new System.Drawing.Size(600, 400);
            this.PbGrid.TabIndex = 4;
            this.PbGrid.TabStop = false;
            this.PbGrid.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 422);
            this.Controls.Add(this.PbGrid);
            this.Controls.Add(this.btnCons);
            this.Controls.Add(this.btnElement);
            this.Controls.Add(this.btnPed);
            this.Controls.Add(this.TBTest);
            this.Name = "Form1";
            this.Text = "Construction site ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBTest;
        private System.Windows.Forms.Button btnPed;
        private System.Windows.Forms.Button btnElement;
        private System.Windows.Forms.Button btnCons;
        private System.Windows.Forms.PictureBox PbGrid;
        private System.Windows.Forms.Timer timer1;
    }
}

