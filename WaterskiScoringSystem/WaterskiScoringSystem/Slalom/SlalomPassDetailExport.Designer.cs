﻿namespace WaterskiScoringSystem.Slalom {
    partial class SlalomPassDetailExport {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlalomPassDetailExport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.winNavStrip = new System.Windows.Forms.ToolStrip();
            this.navRefresh = new System.Windows.Forms.ToolStripButton();
            this.navPrint = new System.Windows.Forms.ToolStripButton();
            this.navExport = new System.Windows.Forms.ToolStripButton();
            this.navExportHtml = new System.Windows.Forms.ToolStripButton();
            this.SanctionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SkierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgeGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Round = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Boat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Driver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SkierRunNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoatTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeInTol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.winNavStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SanctionId,
            this.SkierName,
            this.Event,
            this.AgeGroup,
            this.EventGroup,
            this.EventClass,
            this.Round,
            this.Boat,
            this.Driver,
            this.Score,
            this.SkierRunNum,
            this.BoatTime,
            this.PassScore,
            this.TimeInTol,
            this.PassNotes,
            this.LastUpdateDate});
            this.dataGridView.Location = new System.Drawing.Point(15, 41);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1189, 503);
            this.dataGridView.TabIndex = 6;
            // 
            // winNavStrip
            // 
            this.winNavStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navRefresh,
            this.navPrint,
            this.navExport,
            this.navExportHtml});
            this.winNavStrip.Location = new System.Drawing.Point(0, 0);
            this.winNavStrip.Name = "winNavStrip";
            this.winNavStrip.Size = new System.Drawing.Size(1213, 38);
            this.winNavStrip.TabIndex = 104;
            this.winNavStrip.Text = "toolStrip1";
            // 
            // navRefresh
            // 
            this.navRefresh.Image = global::WaterskiScoringSystem.Properties.Resources.Terminal;
            this.navRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navRefresh.Name = "navRefresh";
            this.navRefresh.Size = new System.Drawing.Size(50, 35);
            this.navRefresh.Text = "Refresh";
            this.navRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.navRefresh.Click += new System.EventHandler(this.navRefresh_Click);
            // 
            // navPrint
            // 
            this.navPrint.Image = global::WaterskiScoringSystem.Properties.Resources.Printer_Network;
            this.navPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navPrint.Name = "navPrint";
            this.navPrint.Size = new System.Drawing.Size(36, 35);
            this.navPrint.Text = "Print";
            this.navPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.navPrint.Click += new System.EventHandler(this.navPrint_Click);
            // 
            // navExport
            // 
            this.navExport.Image = ((System.Drawing.Image)(resources.GetObject("navExport.Image")));
            this.navExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navExport.Name = "navExport";
            this.navExport.Size = new System.Drawing.Size(44, 35);
            this.navExport.Text = "Export";
            this.navExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.navExport.ToolTipText = "Export visible data to a tab delimited text file";
            this.navExport.Click += new System.EventHandler(this.navExport_Click);
            // 
            // navExportHtml
            // 
            this.navExportHtml.Image = ((System.Drawing.Image)(resources.GetObject("navExportHtml.Image")));
            this.navExportHtml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navExportHtml.Name = "navExportHtml";
            this.navExportHtml.Size = new System.Drawing.Size(38, 35);
            this.navExportHtml.Text = "Html";
            this.navExportHtml.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.navExportHtml.ToolTipText = "Export visible data to an HTML file";
            this.navExportHtml.Click += new System.EventHandler(this.navExportHtml_Click);
            // 
            // SanctionId
            // 
            this.SanctionId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SanctionId.HeaderText = "SanctionId";
            this.SanctionId.Name = "SanctionId";
            this.SanctionId.ReadOnly = true;
            this.SanctionId.Visible = false;
            this.SanctionId.Width = 80;
            // 
            // SkierName
            // 
            this.SkierName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SkierName.HeaderText = "Skier";
            this.SkierName.Name = "SkierName";
            this.SkierName.ReadOnly = true;
            this.SkierName.Width = 125;
            // 
            // Event
            // 
            this.Event.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Event.HeaderText = "Event";
            this.Event.Name = "Event";
            this.Event.ReadOnly = true;
            this.Event.Visible = false;
            // 
            // AgeGroup
            // 
            this.AgeGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AgeGroup.DefaultCellStyle = dataGridViewCellStyle2;
            this.AgeGroup.HeaderText = "Div";
            this.AgeGroup.Name = "AgeGroup";
            this.AgeGroup.ReadOnly = true;
            this.AgeGroup.Width = 40;
            // 
            // EventGroup
            // 
            this.EventGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EventGroup.DefaultCellStyle = dataGridViewCellStyle3;
            this.EventGroup.HeaderText = "Group";
            this.EventGroup.Name = "EventGroup";
            this.EventGroup.ReadOnly = true;
            this.EventGroup.Width = 50;
            // 
            // EventClass
            // 
            this.EventClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EventClass.DefaultCellStyle = dataGridViewCellStyle4;
            this.EventClass.HeaderText = "Class";
            this.EventClass.Name = "EventClass";
            this.EventClass.ReadOnly = true;
            this.EventClass.Width = 40;
            // 
            // Round
            // 
            this.Round.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Round.DefaultCellStyle = dataGridViewCellStyle5;
            this.Round.HeaderText = "Rd";
            this.Round.Name = "Round";
            this.Round.ReadOnly = true;
            this.Round.Width = 30;
            // 
            // Boat
            // 
            this.Boat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Boat.HeaderText = "Boat";
            this.Boat.Name = "Boat";
            this.Boat.ReadOnly = true;
            this.Boat.Width = 125;
            // 
            // Driver
            // 
            this.Driver.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Driver.HeaderText = "Driver";
            this.Driver.Name = "Driver";
            this.Driver.ReadOnly = true;
            this.Driver.Width = 125;
            // 
            // Score
            // 
            this.Score.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Score.DefaultCellStyle = dataGridViewCellStyle6;
            this.Score.HeaderText = "Score";
            this.Score.Name = "Score";
            this.Score.ReadOnly = true;
            this.Score.Width = 75;
            // 
            // SkierRunNum
            // 
            this.SkierRunNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SkierRunNum.DefaultCellStyle = dataGridViewCellStyle7;
            this.SkierRunNum.HeaderText = "Pass";
            this.SkierRunNum.Name = "SkierRunNum";
            this.SkierRunNum.ReadOnly = true;
            this.SkierRunNum.Width = 35;
            // 
            // BoatTime
            // 
            this.BoatTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BoatTime.DefaultCellStyle = dataGridViewCellStyle8;
            this.BoatTime.HeaderText = "Time";
            this.BoatTime.Name = "BoatTime";
            this.BoatTime.ReadOnly = true;
            this.BoatTime.Width = 50;
            // 
            // PassScore
            // 
            this.PassScore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PassScore.DefaultCellStyle = dataGridViewCellStyle9;
            this.PassScore.HeaderText = "PassScore";
            this.PassScore.Name = "PassScore";
            this.PassScore.ReadOnly = true;
            this.PassScore.Width = 60;
            // 
            // TimeInTol
            // 
            this.TimeInTol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TimeInTol.DefaultCellStyle = dataGridViewCellStyle10;
            this.TimeInTol.HeaderText = "InTol";
            this.TimeInTol.Name = "TimeInTol";
            this.TimeInTol.ReadOnly = true;
            this.TimeInTol.Width = 40;
            // 
            // PassNotes
            // 
            this.PassNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PassNotes.HeaderText = "Pass Description";
            this.PassNotes.Name = "PassNotes";
            this.PassNotes.ReadOnly = true;
            this.PassNotes.Width = 175;
            // 
            // LastUpdateDate
            // 
            this.LastUpdateDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LastUpdateDate.HeaderText = "LastUpdateDate";
            this.LastUpdateDate.Name = "LastUpdateDate";
            this.LastUpdateDate.ReadOnly = true;
            this.LastUpdateDate.Width = 120;
            // 
            // SlalomPassDetailExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 556);
            this.Controls.Add(this.winNavStrip);
            this.Controls.Add(this.dataGridView);
            this.Name = "SlalomPassDetailExport";
            this.Text = "SlalomPassDetailExport";
            this.Load += new System.EventHandler(this.SlalomPassDetailExport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.winNavStrip.ResumeLayout(false);
            this.winNavStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStrip winNavStrip;
        private System.Windows.Forms.ToolStripButton navRefresh;
        private System.Windows.Forms.ToolStripButton navPrint;
        private System.Windows.Forms.ToolStripButton navExport;
        private System.Windows.Forms.ToolStripButton navExportHtml;
        private System.Windows.Forms.DataGridViewTextBoxColumn SanctionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SkierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgeGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Round;
        private System.Windows.Forms.DataGridViewTextBoxColumn Boat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Driver;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn SkierRunNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoatTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeInTol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdateDate;
    }
}