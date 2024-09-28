﻿namespace LiveSplit.VTS
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.L_CompileState = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.TB_Address = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.CB_Autoconnect = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.L_ConnectionStatus = new System.Windows.Forms.Label();
			this.CB_Log_DebugMessages = new System.Windows.Forms.CheckBox();
			this.B_Connect = new System.Windows.Forms.Button();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.B_BrowseScript = new System.Windows.Forms.Button();
			this.TB_ScriptFile = new System.Windows.Forms.TextBox();
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.gbLog = new System.Windows.Forms.GroupBox();
			this.RB_LogText = new System.Windows.Forms.RichTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.B_Test_OnStart = new System.Windows.Forms.Button();
			this.B_Test_OnPause = new System.Windows.Forms.Button();
			this.B_Test_OnReset = new System.Windows.Forms.Button();
			this.B_Test_OnResume = new System.Windows.Forms.Button();
			this.B_Test_OnSplit = new System.Windows.Forms.Button();
			this.B_Test_OnUndoSplit = new System.Windows.Forms.Button();
			this.B_Test_OnSkipSplit = new System.Windows.Forms.Button();
			this.B_Test_OnRedSplit = new System.Windows.Forms.Button();
			this.B_Test_OnGreenSplit = new System.Windows.Forms.Button();
			this.B_Test_OnGoldSplit = new System.Windows.Forms.Button();
			this.B_Test_OnGold = new System.Windows.Forms.Button();
			this.gbStartSplits.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tlpMain.SuspendLayout();
			this.gbLog.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbStartSplits
			// 
			this.gbStartSplits.Controls.Add(this.tableLayoutPanel1);
			this.gbStartSplits.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbStartSplits.Location = new System.Drawing.Point(3, 3);
			this.gbStartSplits.Name = "gbStartSplits";
			this.gbStartSplits.Size = new System.Drawing.Size(470, 302);
			this.gbStartSplits.TabIndex = 5;
			this.gbStartSplits.TabStop = false;
			this.gbStartSplits.Text = "Config";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 4);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 277);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel5.ColumnCount = 1;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel5.Controls.Add(this.L_CompileState, 0, 0);
			this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 121);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 1;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(458, 34);
			this.tableLayoutPanel5.TabIndex = 4;
			// 
			// L_CompileState
			// 
			this.L_CompileState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.L_CompileState.AutoSize = true;
			this.L_CompileState.Location = new System.Drawing.Point(3, 10);
			this.L_CompileState.Name = "L_CompileState";
			this.L_CompileState.Size = new System.Drawing.Size(452, 13);
			this.L_CompileState.TabIndex = 6;
			this.L_CompileState.Text = "Failed";
			this.L_CompileState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel2.Controls.Add(this.TB_Address, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.CB_Autoconnect, 2, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(458, 30);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// TB_Address
			// 
			this.TB_Address.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TB_Address.Location = new System.Drawing.Point(77, 5);
			this.TB_Address.Name = "TB_Address";
			this.TB_Address.Size = new System.Drawing.Size(278, 20);
			this.TB_Address.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "API address";
			// 
			// CB_Autoconnect
			// 
			this.CB_Autoconnect.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.CB_Autoconnect.AutoSize = true;
			this.CB_Autoconnect.Location = new System.Drawing.Point(361, 6);
			this.CB_Autoconnect.Name = "CB_Autoconnect";
			this.CB_Autoconnect.Size = new System.Drawing.Size(87, 17);
			this.CB_Autoconnect.TabIndex = 1;
			this.CB_Autoconnect.Text = "Autoconnect";
			this.CB_Autoconnect.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 4;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
			this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.L_ConnectionStatus, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.CB_Log_DebugMessages, 2, 0);
			this.tableLayoutPanel3.Controls.Add(this.B_Connect, 3, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 39);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(458, 32);
			this.tableLayoutPanel3.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Status:";
			// 
			// L_ConnectionStatus
			// 
			this.L_ConnectionStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.L_ConnectionStatus.AutoSize = true;
			this.L_ConnectionStatus.Location = new System.Drawing.Point(49, 9);
			this.L_ConnectionStatus.Name = "L_ConnectionStatus";
			this.L_ConnectionStatus.Size = new System.Drawing.Size(13, 13);
			this.L_ConnectionStatus.TabIndex = 3;
			this.L_ConnectionStatus.Text = "?";
			// 
			// CB_Log_DebugMessages
			// 
			this.CB_Log_DebugMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.CB_Log_DebugMessages.AutoSize = true;
			this.CB_Log_DebugMessages.Location = new System.Drawing.Point(224, 7);
			this.CB_Log_DebugMessages.Name = "CB_Log_DebugMessages";
			this.CB_Log_DebugMessages.Size = new System.Drawing.Size(136, 17);
			this.CB_Log_DebugMessages.TabIndex = 4;
			this.CB_Log_DebugMessages.Text = "Log debug messages";
			this.CB_Log_DebugMessages.UseVisualStyleBackColor = true;
			// 
			// B_Connect
			// 
			this.B_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.B_Connect.Location = new System.Drawing.Point(366, 4);
			this.B_Connect.Name = "B_Connect";
			this.B_Connect.Size = new System.Drawing.Size(89, 23);
			this.B_Connect.TabIndex = 1;
			this.B_Connect.Text = "Connect";
			this.B_Connect.UseVisualStyleBackColor = true;
			this.B_Connect.Click += new System.EventHandler(this.B_Connect_Click);
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel4.ColumnCount = 3;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.B_BrowseScript, 2, 0);
			this.tableLayoutPanel4.Controls.Add(this.TB_ScriptFile, 1, 0);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 78);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(458, 34);
			this.tableLayoutPanel4.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Script";
			// 
			// B_BrowseScript
			// 
			this.B_BrowseScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.B_BrowseScript.Location = new System.Drawing.Point(397, 5);
			this.B_BrowseScript.Name = "B_BrowseScript";
			this.B_BrowseScript.Size = new System.Drawing.Size(58, 23);
			this.B_BrowseScript.TabIndex = 5;
			this.B_BrowseScript.Text = "Browse";
			this.B_BrowseScript.UseVisualStyleBackColor = true;
			this.B_BrowseScript.Click += new System.EventHandler(this.B_BrowseScript_Click);
			// 
			// TB_ScriptFile
			// 
			this.TB_ScriptFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TB_ScriptFile.Location = new System.Drawing.Point(43, 7);
			this.TB_ScriptFile.Name = "TB_ScriptFile";
			this.TB_ScriptFile.Size = new System.Drawing.Size(348, 20);
			this.TB_ScriptFile.TabIndex = 4;
			// 
			// tlpMain
			// 
			this.tlpMain.ColumnCount = 1;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpMain.Controls.Add(this.gbLog, 0, 1);
			this.tlpMain.Controls.Add(this.gbStartSplits, 0, 0);
			this.tlpMain.Location = new System.Drawing.Point(0, 0);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.RowCount = 2;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpMain.Size = new System.Drawing.Size(476, 467);
			this.tlpMain.TabIndex = 0;
			// 
			// gbLog
			// 
			this.gbLog.Controls.Add(this.RB_LogText);
			this.gbLog.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbLog.Location = new System.Drawing.Point(3, 311);
			this.gbLog.Name = "gbLog";
			this.gbLog.Size = new System.Drawing.Size(470, 153);
			this.gbLog.TabIndex = 6;
			this.gbLog.TabStop = false;
			this.gbLog.Text = "Log";
			// 
			// RB_LogText
			// 
			this.RB_LogText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RB_LogText.Location = new System.Drawing.Point(3, 16);
			this.RB_LogText.Name = "RB_LogText";
			this.RB_LogText.Size = new System.Drawing.Size(464, 134);
			this.RB_LogText.TabIndex = 0;
			this.RB_LogText.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.B_Test_OnGold);
			this.groupBox1.Controls.Add(this.B_Test_OnGoldSplit);
			this.groupBox1.Controls.Add(this.B_Test_OnGreenSplit);
			this.groupBox1.Controls.Add(this.B_Test_OnRedSplit);
			this.groupBox1.Controls.Add(this.B_Test_OnSkipSplit);
			this.groupBox1.Controls.Add(this.B_Test_OnUndoSplit);
			this.groupBox1.Controls.Add(this.B_Test_OnSplit);
			this.groupBox1.Controls.Add(this.B_Test_OnResume);
			this.groupBox1.Controls.Add(this.B_Test_OnReset);
			this.groupBox1.Controls.Add(this.B_Test_OnPause);
			this.groupBox1.Controls.Add(this.B_Test_OnStart);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 161);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(458, 113);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Test actions";
			// 
			// B_Test_OnStart
			// 
			this.B_Test_OnStart.Location = new System.Drawing.Point(6, 19);
			this.B_Test_OnStart.Name = "B_Test_OnStart";
			this.B_Test_OnStart.Size = new System.Drawing.Size(88, 24);
			this.B_Test_OnStart.TabIndex = 0;
			this.B_Test_OnStart.Text = "OnStart";
			this.B_Test_OnStart.UseVisualStyleBackColor = true;
			this.B_Test_OnStart.Click += new System.EventHandler(this.B_Test_OnStart_Click);
			// 
			// B_Test_OnPause
			// 
			this.B_Test_OnPause.Location = new System.Drawing.Point(100, 19);
			this.B_Test_OnPause.Name = "B_Test_OnPause";
			this.B_Test_OnPause.Size = new System.Drawing.Size(88, 24);
			this.B_Test_OnPause.TabIndex = 1;
			this.B_Test_OnPause.Text = "OnPause";
			this.B_Test_OnPause.UseVisualStyleBackColor = true;
			this.B_Test_OnPause.Click += new System.EventHandler(this.B_Test_OnPause_Click);
			// 
			// B_Test_OnReset
			// 
			this.B_Test_OnReset.Location = new System.Drawing.Point(194, 19);
			this.B_Test_OnReset.Name = "B_Test_OnReset";
			this.B_Test_OnReset.Size = new System.Drawing.Size(88, 24);
			this.B_Test_OnReset.TabIndex = 2;
			this.B_Test_OnReset.Text = "OnReset";
			this.B_Test_OnReset.UseVisualStyleBackColor = true;
			this.B_Test_OnReset.Click += new System.EventHandler(this.B_Test_OnReset_Click);
			// 
			// B_Test_OnResume
			// 
			this.B_Test_OnResume.Location = new System.Drawing.Point(288, 19);
			this.B_Test_OnResume.Name = "B_Test_OnResume";
			this.B_Test_OnResume.Size = new System.Drawing.Size(88, 24);
			this.B_Test_OnResume.TabIndex = 3;
			this.B_Test_OnResume.Text = "OnResume";
			this.B_Test_OnResume.UseVisualStyleBackColor = true;
			this.B_Test_OnResume.Click += new System.EventHandler(this.B_Test_OnResume_Click);
			// 
			// B_Test_OnSplit
			// 
			this.B_Test_OnSplit.Location = new System.Drawing.Point(6, 49);
			this.B_Test_OnSplit.Name = "B_Test_OnSplit";
			this.B_Test_OnSplit.Size = new System.Drawing.Size(88, 24);
			this.B_Test_OnSplit.TabIndex = 4;
			this.B_Test_OnSplit.Text = "OnSplit";
			this.B_Test_OnSplit.UseVisualStyleBackColor = true;
			this.B_Test_OnSplit.Click += new System.EventHandler(this.B_Test_OnSplit_Click);
			// 
			// B_Test_OnUndoSplit
			// 
			this.B_Test_OnUndoSplit.Location = new System.Drawing.Point(100, 49);
			this.B_Test_OnUndoSplit.Name = "B_Test_OnUndoSplit";
			this.B_Test_OnUndoSplit.Size = new System.Drawing.Size(88, 24);
			this.B_Test_OnUndoSplit.TabIndex = 5;
			this.B_Test_OnUndoSplit.Text = "OnUndoSplit";
			this.B_Test_OnUndoSplit.UseVisualStyleBackColor = true;
			this.B_Test_OnUndoSplit.Click += new System.EventHandler(this.B_Test_OnUndoSplit_Click);
			// 
			// B_Test_OnSkipSplit
			// 
			this.B_Test_OnSkipSplit.Location = new System.Drawing.Point(194, 49);
			this.B_Test_OnSkipSplit.Name = "B_Test_OnSkipSplit";
			this.B_Test_OnSkipSplit.Size = new System.Drawing.Size(88, 24);
			this.B_Test_OnSkipSplit.TabIndex = 6;
			this.B_Test_OnSkipSplit.Text = "OnSkipSplit";
			this.B_Test_OnSkipSplit.UseVisualStyleBackColor = true;
			this.B_Test_OnSkipSplit.Click += new System.EventHandler(this.B_Test_OnSkipSplit_Click);
			// 
			// B_Test_OnRedSplit
			// 
			this.B_Test_OnRedSplit.Location = new System.Drawing.Point(6, 79);
			this.B_Test_OnRedSplit.Name = "B_Test_OnRedSplit";
			this.B_Test_OnRedSplit.Size = new System.Drawing.Size(88, 24);
			this.B_Test_OnRedSplit.TabIndex = 8;
			this.B_Test_OnRedSplit.Text = "OnRedSplit";
			this.B_Test_OnRedSplit.UseVisualStyleBackColor = true;
			this.B_Test_OnRedSplit.Click += new System.EventHandler(this.B_Test_OnRedSplit_Click);
			// 
			// B_Test_OnGreenSplit
			// 
			this.B_Test_OnGreenSplit.Location = new System.Drawing.Point(100, 79);
			this.B_Test_OnGreenSplit.Name = "B_Test_OnGreenSplit";
			this.B_Test_OnGreenSplit.Size = new System.Drawing.Size(88, 24);
			this.B_Test_OnGreenSplit.TabIndex = 9;
			this.B_Test_OnGreenSplit.Text = "OnGreenSplit";
			this.B_Test_OnGreenSplit.UseVisualStyleBackColor = true;
			this.B_Test_OnGreenSplit.Click += new System.EventHandler(this.B_Test_OnGreenSplit_Click);
			// 
			// B_Test_OnGoldSplit
			// 
			this.B_Test_OnGoldSplit.Location = new System.Drawing.Point(194, 79);
			this.B_Test_OnGoldSplit.Name = "B_Test_OnGoldSplit";
			this.B_Test_OnGoldSplit.Size = new System.Drawing.Size(88, 24);
			this.B_Test_OnGoldSplit.TabIndex = 10;
			this.B_Test_OnGoldSplit.Text = "OnGoldSplit";
			this.B_Test_OnGoldSplit.UseVisualStyleBackColor = true;
			this.B_Test_OnGoldSplit.Click += new System.EventHandler(this.B_Test_OnGoldSplit_Click);
			// 
			// B_Test_OnGold
			// 
			this.B_Test_OnGold.Location = new System.Drawing.Point(288, 79);
			this.B_Test_OnGold.Name = "B_Test_OnGold";
			this.B_Test_OnGold.Size = new System.Drawing.Size(88, 24);
			this.B_Test_OnGold.TabIndex = 11;
			this.B_Test_OnGold.Text = "OnGold";
			this.B_Test_OnGold.UseVisualStyleBackColor = true;
			this.B_Test_OnGold.Click += new System.EventHandler(this.B_Test_OnGold_Click);
			// 
			// VTSSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tlpMain);
			this.Name = "VTSSettings";
			this.Size = new System.Drawing.Size(476, 471);
			this.VisibleChanged += new System.EventHandler(this.VTSSettings_VisibleChanged);
			this.gbStartSplits.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.tlpMain.ResumeLayout(false);
			this.gbLog.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbStartSplits;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TextBox TB_Address;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button B_Connect;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label L_ConnectionStatus;
		private System.Windows.Forms.CheckBox CB_Autoconnect;
		private System.Windows.Forms.CheckBox CB_Log_DebugMessages;
		private System.Windows.Forms.GroupBox gbLog;
		private System.Windows.Forms.RichTextBox RB_LogText;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Button B_BrowseScript;
		private System.Windows.Forms.TextBox TB_ScriptFile;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label L_CompileState;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button B_Test_OnReset;
		private System.Windows.Forms.Button B_Test_OnPause;
		private System.Windows.Forms.Button B_Test_OnStart;
		private System.Windows.Forms.Button B_Test_OnGold;
		private System.Windows.Forms.Button B_Test_OnGoldSplit;
		private System.Windows.Forms.Button B_Test_OnGreenSplit;
		private System.Windows.Forms.Button B_Test_OnRedSplit;
		private System.Windows.Forms.Button B_Test_OnSkipSplit;
		private System.Windows.Forms.Button B_Test_OnUndoSplit;
		private System.Windows.Forms.Button B_Test_OnSplit;
		private System.Windows.Forms.Button B_Test_OnResume;
	}
}
