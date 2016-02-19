﻿namespace WaterskiScoringSystem.Trick {
    partial class LoadVideosFile {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadVideosFile));
            this.VideoFolderLocTextbox = new System.Windows.Forms.TextBox();
            this.VideoFileSelectButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.TagsListBox = new System.Windows.Forms.CheckedListBox();
            this.AddTagButton = new System.Windows.Forms.Button();
            this.NewTagTextbox = new System.Windows.Forms.TextBox();
            this.ViewButton = new System.Windows.Forms.Button();
            this.loadedVideoDataGridView = new System.Windows.Forms.DataGridView();
            this.selectedFileDataGridView = new System.Windows.Forms.DataGridView();
            this.SelectedFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectedSkierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectedAgeGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectedRound = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectedPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectedMemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowStatusLabel = new System.Windows.Forms.Label();
            this.LiveWebButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ExportLoadedButton = new System.Windows.Forms.Button();
            this.VideoTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoPlays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoSizeSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoSizeHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.loadedVideoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedFileDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoFolderLocTextbox
            // 
            this.VideoFolderLocTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VideoFolderLocTextbox.Location = new System.Drawing.Point(91, 29);
            this.VideoFolderLocTextbox.Name = "VideoFolderLocTextbox";
            this.VideoFolderLocTextbox.Size = new System.Drawing.Size(389, 20);
            this.VideoFolderLocTextbox.TabIndex = 3;
            // 
            // VideoFileSelectButton
            // 
            this.VideoFileSelectButton.Location = new System.Drawing.Point(10, 28);
            this.VideoFileSelectButton.Name = "VideoFileSelectButton";
            this.VideoFileSelectButton.Size = new System.Drawing.Size(75, 23);
            this.VideoFileSelectButton.TabIndex = 1;
            this.VideoFileSelectButton.Text = "Select Files";
            this.VideoFileSelectButton.UseVisualStyleBackColor = true;
            this.VideoFileSelectButton.Click += new System.EventHandler(this.VideoFileSelectButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.AutoSize = true;
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(186, 253);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.AutoSize = true;
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(91, 253);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 6;
            this.OkButton.Text = "Load";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // TagsListBox
            // 
            this.TagsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TagsListBox.CheckOnClick = true;
            this.TagsListBox.FormattingEnabled = true;
            this.TagsListBox.Location = new System.Drawing.Point(91, 81);
            this.TagsListBox.Name = "TagsListBox";
            this.TagsListBox.Size = new System.Drawing.Size(389, 169);
            this.TagsListBox.TabIndex = 5;
            this.TagsListBox.ThreeDCheckBoxes = true;
            // 
            // AddTagButton
            // 
            this.AddTagButton.Location = new System.Drawing.Point(10, 57);
            this.AddTagButton.Name = "AddTagButton";
            this.AddTagButton.Size = new System.Drawing.Size(75, 23);
            this.AddTagButton.TabIndex = 2;
            this.AddTagButton.Text = "Add Tag";
            this.AddTagButton.UseVisualStyleBackColor = true;
            this.AddTagButton.Click += new System.EventHandler(this.AddTagButton_Click);
            // 
            // NewTagTextbox
            // 
            this.NewTagTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewTagTextbox.Location = new System.Drawing.Point(91, 57);
            this.NewTagTextbox.Name = "NewTagTextbox";
            this.NewTagTextbox.Size = new System.Drawing.Size(389, 20);
            this.NewTagTextbox.TabIndex = 4;
            // 
            // ViewButton
            // 
            this.ViewButton.AutoSize = true;
            this.ViewButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ViewButton.Location = new System.Drawing.Point(278, 254);
            this.ViewButton.Name = "ViewButton";
            this.ViewButton.Size = new System.Drawing.Size(79, 23);
            this.ViewButton.TabIndex = 8;
            this.ViewButton.Text = "View Loaded";
            this.ViewButton.UseVisualStyleBackColor = true;
            this.ViewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // loadedVideoDataGridView
            // 
            this.loadedVideoDataGridView.AllowUserToAddRows = false;
            this.loadedVideoDataGridView.AllowUserToDeleteRows = false;
            this.loadedVideoDataGridView.AllowUserToResizeRows = false;
            this.loadedVideoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.loadedVideoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.loadedVideoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.loadedVideoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VideoTitle,
            this.VideoState,
            this.VideoPlays,
            this.VideoSizeSD,
            this.VideoSizeHD,
            this.VideoURL,
            this.VideoId});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.loadedVideoDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.loadedVideoDataGridView.Location = new System.Drawing.Point(5, 279);
            this.loadedVideoDataGridView.Name = "loadedVideoDataGridView";
            this.loadedVideoDataGridView.RowHeadersVisible = false;
            this.loadedVideoDataGridView.Size = new System.Drawing.Size(475, 201);
            this.loadedVideoDataGridView.TabIndex = 9;
            this.loadedVideoDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_RowEnter);
            // 
            // selectedFileDataGridView
            // 
            this.selectedFileDataGridView.AllowUserToAddRows = false;
            this.selectedFileDataGridView.AllowUserToDeleteRows = false;
            this.selectedFileDataGridView.AllowUserToResizeRows = false;
            this.selectedFileDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.selectedFileDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.selectedFileDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectedFileDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectedFileName,
            this.SelectedSkierName,
            this.SelectedAgeGroup,
            this.SelectedRound,
            this.SelectedPass,
            this.SelectedMemberId});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.selectedFileDataGridView.DefaultCellStyle = dataGridViewCellStyle11;
            this.selectedFileDataGridView.Location = new System.Drawing.Point(59, 280);
            this.selectedFileDataGridView.Name = "selectedFileDataGridView";
            this.selectedFileDataGridView.RowHeadersVisible = false;
            this.selectedFileDataGridView.Size = new System.Drawing.Size(421, 200);
            this.selectedFileDataGridView.TabIndex = 10;
            this.selectedFileDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_RowEnter);
            // 
            // SelectedFileName
            // 
            this.SelectedFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SelectedFileName.HeaderText = "File Name";
            this.SelectedFileName.Name = "SelectedFileName";
            this.SelectedFileName.ReadOnly = true;
            this.SelectedFileName.Width = 150;
            // 
            // SelectedSkierName
            // 
            this.SelectedSkierName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SelectedSkierName.HeaderText = "Skier";
            this.SelectedSkierName.Name = "SelectedSkierName";
            this.SelectedSkierName.ReadOnly = true;
            this.SelectedSkierName.Width = 125;
            // 
            // SelectedAgeGroup
            // 
            this.SelectedAgeGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SelectedAgeGroup.DefaultCellStyle = dataGridViewCellStyle8;
            this.SelectedAgeGroup.HeaderText = "Div";
            this.SelectedAgeGroup.Name = "SelectedAgeGroup";
            this.SelectedAgeGroup.ReadOnly = true;
            this.SelectedAgeGroup.Width = 35;
            // 
            // SelectedRound
            // 
            this.SelectedRound.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SelectedRound.DefaultCellStyle = dataGridViewCellStyle9;
            this.SelectedRound.HeaderText = "RD";
            this.SelectedRound.Name = "SelectedRound";
            this.SelectedRound.ReadOnly = true;
            this.SelectedRound.Width = 30;
            // 
            // SelectedPass
            // 
            this.SelectedPass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SelectedPass.DefaultCellStyle = dataGridViewCellStyle10;
            this.SelectedPass.HeaderText = "Pass";
            this.SelectedPass.Name = "SelectedPass";
            this.SelectedPass.ReadOnly = true;
            this.SelectedPass.Width = 30;
            // 
            // SelectedMemberId
            // 
            this.SelectedMemberId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SelectedMemberId.HeaderText = "MemberId";
            this.SelectedMemberId.Name = "SelectedMemberId";
            this.SelectedMemberId.ReadOnly = true;
            this.SelectedMemberId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SelectedMemberId.Visible = false;
            this.SelectedMemberId.Width = 75;
            // 
            // RowStatusLabel
            // 
            this.RowStatusLabel.AutoSize = true;
            this.RowStatusLabel.Location = new System.Drawing.Point(5, 255);
            this.RowStatusLabel.Name = "RowStatusLabel";
            this.RowStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.RowStatusLabel.TabIndex = 0;
            // 
            // LiveWebButton
            // 
            this.LiveWebButton.Location = new System.Drawing.Point(136, 3);
            this.LiveWebButton.Name = "LiveWebButton";
            this.LiveWebButton.Size = new System.Drawing.Size(75, 23);
            this.LiveWebButton.TabIndex = 1;
            this.LiveWebButton.Text = "Live Web";
            this.LiveWebButton.UseVisualStyleBackColor = true;
            this.LiveWebButton.Click += new System.EventHandler(this.LiveWebButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(234, 3);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 23);
            this.ExportButton.TabIndex = 2;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ExportLoadedButton
            // 
            this.ExportLoadedButton.Location = new System.Drawing.Point(368, 253);
            this.ExportLoadedButton.Name = "ExportLoadedButton";
            this.ExportLoadedButton.Size = new System.Drawing.Size(89, 23);
            this.ExportLoadedButton.TabIndex = 9;
            this.ExportLoadedButton.Text = "Export Loaded";
            this.ExportLoadedButton.UseVisualStyleBackColor = true;
            this.ExportLoadedButton.Click += new System.EventHandler(this.ExportLoadedButton_Click);
            // 
            // VideoTitle
            // 
            this.VideoTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.VideoTitle.HeaderText = "Title";
            this.VideoTitle.Name = "VideoTitle";
            this.VideoTitle.ReadOnly = true;
            this.VideoTitle.Width = 150;
            // 
            // VideoState
            // 
            this.VideoState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.VideoState.DefaultCellStyle = dataGridViewCellStyle2;
            this.VideoState.HeaderText = "Status";
            this.VideoState.Name = "VideoState";
            this.VideoState.ReadOnly = true;
            this.VideoState.Width = 65;
            // 
            // VideoPlays
            // 
            this.VideoPlays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.VideoPlays.DefaultCellStyle = dataGridViewCellStyle3;
            this.VideoPlays.HeaderText = "Plays";
            this.VideoPlays.Name = "VideoPlays";
            this.VideoPlays.ReadOnly = true;
            this.VideoPlays.Width = 40;
            // 
            // VideoSizeSD
            // 
            this.VideoSizeSD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.VideoSizeSD.DefaultCellStyle = dataGridViewCellStyle4;
            this.VideoSizeSD.HeaderText = "SD Size";
            this.VideoSizeSD.Name = "VideoSizeSD";
            this.VideoSizeSD.ReadOnly = true;
            this.VideoSizeSD.Width = 60;
            // 
            // VideoSizeHD
            // 
            this.VideoSizeHD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.VideoSizeHD.DefaultCellStyle = dataGridViewCellStyle5;
            this.VideoSizeHD.HeaderText = "HD Size";
            this.VideoSizeHD.Name = "VideoSizeHD";
            this.VideoSizeHD.ReadOnly = true;
            this.VideoSizeHD.Width = 60;
            // 
            // VideoURL
            // 
            this.VideoURL.HeaderText = "URL";
            this.VideoURL.Name = "VideoURL";
            this.VideoURL.ReadOnly = true;
            // 
            // VideoId
            // 
            this.VideoId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.VideoId.HeaderText = "ID";
            this.VideoId.Name = "VideoId";
            this.VideoId.ReadOnly = true;
            this.VideoId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.VideoId.Visible = false;
            // 
            // LoadVideosFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 484);
            this.Controls.Add(this.ExportLoadedButton);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.LiveWebButton);
            this.Controls.Add(this.RowStatusLabel);
            this.Controls.Add(this.selectedFileDataGridView);
            this.Controls.Add(this.loadedVideoDataGridView);
            this.Controls.Add(this.ViewButton);
            this.Controls.Add(this.NewTagTextbox);
            this.Controls.Add(this.AddTagButton);
            this.Controls.Add(this.TagsListBox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.VideoFileSelectButton);
            this.Controls.Add(this.VideoFolderLocTextbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoadVideosFile";
            this.Text = "Load Videos Files";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoadVideosFile_FormClosed);
            this.Load += new System.EventHandler(this.LoadVideosFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loadedVideoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedFileDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox VideoFolderLocTextbox;
        private System.Windows.Forms.Button VideoFileSelectButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.CheckedListBox TagsListBox;
        private System.Windows.Forms.Button AddTagButton;
        private System.Windows.Forms.TextBox NewTagTextbox;
        private System.Windows.Forms.Button ViewButton;
        private System.Windows.Forms.DataGridView loadedVideoDataGridView;
        private System.Windows.Forms.DataGridView selectedFileDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectedFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectedSkierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectedAgeGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectedRound;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectedPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectedMemberId;
        private System.Windows.Forms.Label RowStatusLabel;
        private System.Windows.Forms.Button LiveWebButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button ExportLoadedButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoState;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoPlays;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoSizeSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoSizeHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoId;
    }
}