namespace Draw_NonConvex_Polygons_Show_Union
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.chkPolygon1 = new System.Windows.Forms.CheckBox();
            this.chkPolygon2 = new System.Windows.Forms.CheckBox();
            this.chkUnion = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 35);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(466, 214);
            this.picCanvas.TabIndex = 1;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            this.picCanvas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDoubleClick);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            // 
            // chkPolygon1
            // 
            this.chkPolygon1.AutoSize = true;
            this.chkPolygon1.Checked = true;
            this.chkPolygon1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPolygon1.Location = new System.Drawing.Point(12, 12);
            this.chkPolygon1.Name = "chkPolygon1";
            this.chkPolygon1.Size = new System.Drawing.Size(73, 17);
            this.chkPolygon1.TabIndex = 2;
            this.chkPolygon1.Text = "Polygon 1";
            this.chkPolygon1.UseVisualStyleBackColor = true;
            this.chkPolygon1.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkPolygon2
            // 
            this.chkPolygon2.AutoSize = true;
            this.chkPolygon2.Checked = true;
            this.chkPolygon2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPolygon2.Location = new System.Drawing.Point(115, 12);
            this.chkPolygon2.Name = "chkPolygon2";
            this.chkPolygon2.Size = new System.Drawing.Size(73, 17);
            this.chkPolygon2.TabIndex = 3;
            this.chkPolygon2.Text = "Polygon 2";
            this.chkPolygon2.UseVisualStyleBackColor = true;
            this.chkPolygon2.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkUnion
            // 
            this.chkUnion.AutoSize = true;
            this.chkUnion.Checked = true;
            this.chkUnion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnion.Location = new System.Drawing.Point(218, 12);
            this.chkUnion.Name = "chkUnion";
            this.chkUnion.Size = new System.Drawing.Size(54, 17);
            this.chkUnion.TabIndex = 4;
            this.chkUnion.Text = "Union";
            this.chkUnion.UseVisualStyleBackColor = true;
            this.chkUnion.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(298, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Intersection";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(400, 12);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Subtraction";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Instructions";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 261);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chkUnion);
            this.Controls.Add(this.chkPolygon2);
            this.Controls.Add(this.chkPolygon1);
            this.Controls.Add(this.picCanvas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Polgyon Operations";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.CheckBox chkPolygon1;
        private System.Windows.Forms.CheckBox chkPolygon2;
        private System.Windows.Forms.CheckBox chkUnion;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

