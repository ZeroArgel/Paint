namespace TestCoreApp
{
    partial class Frm_Paint
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Gbx_Actions = new System.Windows.Forms.GroupBox();
            this.Btn_Clean = new System.Windows.Forms.Button();
            this.Btn_Load = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Lbl_MaxX = new System.Windows.Forms.Label();
            this.Lbl_MaxY = new System.Windows.Forms.Label();
            this.Gbx_Paint = new System.Windows.Forms.GroupBox();
            this.Txt_MaxX = new System.Windows.Forms.NumericUpDown();
            this.Txt_Ctrl = new System.Windows.Forms.TextBox();
            this.Txt_MaxY = new System.Windows.Forms.NumericUpDown();
            this.Gbx_Actions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_MaxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_MaxY)).BeginInit();
            this.SuspendLayout();
            // 
            // Gbx_Actions
            // 
            this.Gbx_Actions.Controls.Add(this.Txt_MaxY);
            this.Gbx_Actions.Controls.Add(this.Txt_MaxX);
            this.Gbx_Actions.Controls.Add(this.Btn_Clean);
            this.Gbx_Actions.Controls.Add(this.Btn_Load);
            this.Gbx_Actions.Controls.Add(this.Btn_Save);
            this.Gbx_Actions.Controls.Add(this.Lbl_MaxX);
            this.Gbx_Actions.Controls.Add(this.Lbl_MaxY);
            this.Gbx_Actions.Location = new System.Drawing.Point(12, 12);
            this.Gbx_Actions.Name = "Gbx_Actions";
            this.Gbx_Actions.Size = new System.Drawing.Size(82, 174);
            this.Gbx_Actions.TabIndex = 3;
            this.Gbx_Actions.TabStop = false;
            this.Gbx_Actions.Text = "Actions";
            // 
            // Btn_Clean
            // 
            this.Btn_Clean.Location = new System.Drawing.Point(6, 82);
            this.Btn_Clean.Name = "Btn_Clean";
            this.Btn_Clean.Size = new System.Drawing.Size(69, 24);
            this.Btn_Clean.TabIndex = 1;
            this.Btn_Clean.Text = "Clean";
            this.Btn_Clean.UseVisualStyleBackColor = true;
            this.Btn_Clean.Click += new System.EventHandler(this.Btn_Clean_Click);
            // 
            // Btn_Load
            // 
            this.Btn_Load.Location = new System.Drawing.Point(6, 52);
            this.Btn_Load.Name = "Btn_Load";
            this.Btn_Load.Size = new System.Drawing.Size(69, 24);
            this.Btn_Load.TabIndex = 1;
            this.Btn_Load.Text = "Load";
            this.Btn_Load.UseVisualStyleBackColor = true;
            this.Btn_Load.Click += new System.EventHandler(this.Btn_Load_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(7, 22);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(69, 24);
            this.Btn_Save.TabIndex = 1;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Lbl_MaxX
            // 
            this.Lbl_MaxX.AutoSize = true;
            this.Lbl_MaxX.Location = new System.Drawing.Point(-2, 123);
            this.Lbl_MaxX.Name = "Lbl_MaxX";
            this.Lbl_MaxX.Size = new System.Drawing.Size(43, 15);
            this.Lbl_MaxX.TabIndex = 9;
            this.Lbl_MaxX.Text = "Max X:";
            // 
            // Lbl_MaxY
            // 
            this.Lbl_MaxY.AutoSize = true;
            this.Lbl_MaxY.Location = new System.Drawing.Point(-2, 147);
            this.Lbl_MaxY.Name = "Lbl_MaxY";
            this.Lbl_MaxY.Size = new System.Drawing.Size(43, 15);
            this.Lbl_MaxY.TabIndex = 10;
            this.Lbl_MaxY.Text = "Max Y:";
            // 
            // Gbx_Paint
            // 
            this.Gbx_Paint.AutoSize = true;
            this.Gbx_Paint.Location = new System.Drawing.Point(100, 12);
            this.Gbx_Paint.Name = "Gbx_Paint";
            this.Gbx_Paint.Size = new System.Drawing.Size(253, 251);
            this.Gbx_Paint.TabIndex = 2;
            this.Gbx_Paint.TabStop = false;
            this.Gbx_Paint.Text = "Paint";
            // 
            // Txt_MaxX
            // 
            this.Txt_MaxX.Location = new System.Drawing.Point(38, 118);
            this.Txt_MaxX.Name = "Txt_MaxX";
            this.Txt_MaxX.Size = new System.Drawing.Size(44, 23);
            this.Txt_MaxX.TabIndex = 0;
            // 
            // Txt_Ctrl
            // 
            this.Txt_Ctrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Ctrl.Location = new System.Drawing.Point(12, 192);
            this.Txt_Ctrl.Name = "Txt_Ctrl";
            this.Txt_Ctrl.ReadOnly = true;
            this.Txt_Ctrl.Size = new System.Drawing.Size(36, 16);
            this.Txt_Ctrl.TabIndex = 1;
            this.Txt_Ctrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_Ctrl_KeyDown);
            // 
            // Txt_MaxY
            // 
            this.Txt_MaxY.Location = new System.Drawing.Point(38, 145);
            this.Txt_MaxY.Name = "Txt_MaxY";
            this.Txt_MaxY.Size = new System.Drawing.Size(44, 23);
            this.Txt_MaxY.TabIndex = 0;
            // 
            // Frm_Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 269);
            this.Controls.Add(this.Txt_Ctrl);
            this.Controls.Add(this.Gbx_Paint);
            this.Controls.Add(this.Gbx_Actions);
            this.Name = "Frm_Paint";
            this.Text = "Paint v1";
            this.Load += new System.EventHandler(this.Frm_Paint_Load);
            this.Click += new System.EventHandler(this.Frm_Paint_Click);
            this.Gbx_Actions.ResumeLayout(false);
            this.Gbx_Actions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_MaxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_MaxY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.GroupBox Gbx_Actions;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.GroupBox Gbx_Paint;
        private System.Windows.Forms.Label Lbl_MaxY;
        private System.Windows.Forms.Label Lbl_MaxX;
        private System.Windows.Forms.TextBox Txt_Ctrl;
        private System.Windows.Forms.Button Btn_Clean;
        private System.Windows.Forms.Button Btn_Load;
        private System.Windows.Forms.NumericUpDown Txt_MaxX;
        private System.Windows.Forms.NumericUpDown Txt_MaxY;
    }
}