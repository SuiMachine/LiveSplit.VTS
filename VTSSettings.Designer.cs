namespace LiveSplit.VTS
{
    partial class VTSSettings
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbStartSplits = new System.Windows.Forms.GroupBox();
            this.tlpStartSplits = new System.Windows.Forms.TableLayoutPanel();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.chkAutoReset = new System.Windows.Forms.CheckBox();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.chkUnsafeReading = new System.Windows.Forms.CheckBox();
            this.gbStartSplits.SuspendLayout();
            this.tlpStartSplits.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbStartSplits
            // 
            this.gbStartSplits.AutoSize = true;
            this.gbStartSplits.Controls.Add(this.tlpStartSplits);
            this.gbStartSplits.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbStartSplits.Location = new System.Drawing.Point(3, 3);
            this.gbStartSplits.Name = "gbStartSplits";
            this.gbStartSplits.Size = new System.Drawing.Size(470, 85);
            this.gbStartSplits.TabIndex = 5;
            this.gbStartSplits.TabStop = false;
            this.gbStartSplits.Text = "Options";
            // 
            // tlpStartSplits
            // 
            this.tlpStartSplits.AutoSize = true;
            this.tlpStartSplits.BackColor = System.Drawing.Color.Transparent;
            this.tlpStartSplits.ColumnCount = 1;
            this.tlpStartSplits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStartSplits.Controls.Add(this.chkUnsafeReading, 0, 0);
            this.tlpStartSplits.Controls.Add(this.chkAutoReset, 0, 1);
            this.tlpStartSplits.Controls.Add(this.chkAutoStart, 0, 2);
            this.tlpStartSplits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStartSplits.Location = new System.Drawing.Point(3, 16);
            this.tlpStartSplits.Name = "tlpStartSplits";
            this.tlpStartSplits.RowCount = 3;
            this.tlpStartSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpStartSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpStartSplits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStartSplits.Size = new System.Drawing.Size(464, 66);
            this.tlpStartSplits.TabIndex = 4;
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Checked = true;
            this.chkAutoStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoStart.Location = new System.Drawing.Point(3, 49);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(48, 14);
            this.chkAutoStart.TabIndex = 5;
            this.chkAutoStart.Text = "Start";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            // 
            // chkAutoReset
            // 
            this.chkAutoReset.AutoSize = true;
            this.chkAutoReset.Checked = true;
            this.chkAutoReset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoReset.Location = new System.Drawing.Point(3, 26);
            this.chkAutoReset.Name = "chkAutoReset";
            this.chkAutoReset.Size = new System.Drawing.Size(54, 17);
            this.chkAutoReset.TabIndex = 4;
            this.chkAutoReset.Text = "Reset";
            this.chkAutoReset.UseVisualStyleBackColor = true;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.gbStartSplits, 0, 0);
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(476, 376);
            this.tlpMain.TabIndex = 0;
            // 
            // chkUnsafeReading
            // 
            this.chkUnsafeReading.AutoSize = true;
            this.chkUnsafeReading.Checked = true;
            this.chkUnsafeReading.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnsafeReading.Location = new System.Drawing.Point(3, 3);
            this.chkUnsafeReading.Name = "chkUnsafeReading";
            this.chkUnsafeReading.Size = new System.Drawing.Size(171, 17);
            this.chkUnsafeReading.TabIndex = 6;
            this.chkUnsafeReading.Text = "Use Non-Safe Memory Reader";
            this.chkUnsafeReading.UseVisualStyleBackColor = true;
            // 
            // DXIWSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "DXIWSettings";
            this.Size = new System.Drawing.Size(476, 382);
            this.gbStartSplits.ResumeLayout(false);
            this.gbStartSplits.PerformLayout();
            this.tlpStartSplits.ResumeLayout(false);
            this.tlpStartSplits.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbStartSplits;
        private System.Windows.Forms.TableLayoutPanel tlpStartSplits;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.CheckBox chkAutoReset;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.CheckBox chkUnsafeReading;
    }
}
