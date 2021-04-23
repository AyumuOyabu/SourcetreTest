namespace TraningTask
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbCsvFilePath = new System.Windows.Forms.TextBox();
            this.btFileDialog = new System.Windows.Forms.Button();
            this.gbCsvFile = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btStart = new System.Windows.Forms.Button();
            this.btEnd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbCsvFolderPath = new System.Windows.Forms.TextBox();
            this.gbCsvFolder = new System.Windows.Forms.GroupBox();
            this.cbSelectTable = new System.Windows.Forms.ComboBox();
            this.btViewTable = new System.Windows.Forms.Button();
            this.btDeleteGridData = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCsvFilePath
            // 
            this.tbCsvFilePath.AllowDrop = true;
            this.tbCsvFilePath.Location = new System.Drawing.Point(94, 28);
            this.tbCsvFilePath.Name = "tbCsvFilePath";
            this.tbCsvFilePath.Size = new System.Drawing.Size(321, 19);
            this.tbCsvFilePath.TabIndex = 0;
            this.tbCsvFilePath.TextChanged += new System.EventHandler(this.tbCsvFilePath_TextChanged);
            this.tbCsvFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbFilepath_DragDrop);
            this.tbCsvFilePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbFilepath_DragEnter);
            // 
            // btFileDialog
            // 
            this.btFileDialog.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btFileDialog.Location = new System.Drawing.Point(431, 27);
            this.btFileDialog.Name = "btFileDialog";
            this.btFileDialog.Size = new System.Drawing.Size(31, 23);
            this.btFileDialog.TabIndex = 1;
            this.btFileDialog.Text = "..";
            this.btFileDialog.UseVisualStyleBackColor = true;
            this.btFileDialog.Click += new System.EventHandler(this.btFileDialog_Click);
            // 
            // gbCsvFile
            // 
            this.gbCsvFile.AutoSize = true;
            this.gbCsvFile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbCsvFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gbCsvFile.Location = new System.Drawing.Point(28, 28);
            this.gbCsvFile.Name = "gbCsvFile";
            this.gbCsvFile.Size = new System.Drawing.Size(58, 19);
            this.gbCsvFile.TabIndex = 2;
            this.gbCsvFile.TabStop = false;
            this.gbCsvFile.Text = "フォルダ:";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowDrop = true;
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(30, 137);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 21;
            this.dataGridView.Size = new System.Drawing.Size(432, 297);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // btStart
            // 
            this.btStart.BackColor = System.Drawing.Color.Aqua;
            this.btStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btStart.Location = new System.Drawing.Point(387, 56);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 4;
            this.btStart.Text = "取り込み";
            this.btStart.UseVisualStyleBackColor = false;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btEnd
            // 
            this.btEnd.BackColor = System.Drawing.Color.Snow;
            this.btEnd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEnd.Location = new System.Drawing.Point(379, 447);
            this.btEnd.Name = "btEnd";
            this.btEnd.Size = new System.Drawing.Size(75, 23);
            this.btEnd.TabIndex = 5;
            this.btEnd.Text = "終了";
            this.btEnd.UseVisualStyleBackColor = false;
            this.btEnd.Click += new System.EventHandler(this.btEnd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(3, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(85, 16);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "テーブルを検索:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tbCsvFolderPath
            // 
            this.tbCsvFolderPath.Location = new System.Drawing.Point(95, 55);
            this.tbCsvFolderPath.Name = "tbCsvFolderPath";
            this.tbCsvFolderPath.Size = new System.Drawing.Size(215, 19);
            this.tbCsvFolderPath.TabIndex = 8;
            // 
            // gbCsvFolder
            // 
            this.gbCsvFolder.Location = new System.Drawing.Point(30, 55);
            this.gbCsvFolder.Name = "gbCsvFolder";
            this.gbCsvFolder.Size = new System.Drawing.Size(61, 20);
            this.gbCsvFolder.TabIndex = 9;
            this.gbCsvFolder.TabStop = false;
            this.gbCsvFolder.Text = "ファイル:";
            this.gbCsvFolder.Enter += new System.EventHandler(this.gbCsvFolder_Enter);
            // 
            // cbSelectTable
            // 
            this.cbSelectTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectTable.FormattingEnabled = true;
            this.cbSelectTable.Location = new System.Drawing.Point(95, 98);
            this.cbSelectTable.Name = "cbSelectTable";
            this.cbSelectTable.Size = new System.Drawing.Size(121, 20);
            this.cbSelectTable.TabIndex = 10;
            this.cbSelectTable.SelectedIndexChanged += new System.EventHandler(this.cbSelectTable_SelectedIndexChanged);
            // 
            // btViewTable
            // 
            this.btViewTable.BackColor = System.Drawing.SystemColors.Window;
            this.btViewTable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btViewTable.Location = new System.Drawing.Point(235, 98);
            this.btViewTable.Name = "btViewTable";
            this.btViewTable.Size = new System.Drawing.Size(75, 23);
            this.btViewTable.TabIndex = 11;
            this.btViewTable.Text = "テーブル表示";
            this.btViewTable.UseVisualStyleBackColor = false;
            this.btViewTable.Click += new System.EventHandler(this.btViewTable_Click);
            // 
            // btDeleteGridData
            // 
            this.btDeleteGridData.BackColor = System.Drawing.Color.Red;
            this.btDeleteGridData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDeleteGridData.Location = new System.Drawing.Point(325, 98);
            this.btDeleteGridData.Name = "btDeleteGridData";
            this.btDeleteGridData.Size = new System.Drawing.Size(99, 23);
            this.btDeleteGridData.TabIndex = 12;
            this.btDeleteGridData.Text = "選択データ削除";
            this.btDeleteGridData.UseVisualStyleBackColor = false;
            this.btDeleteGridData.Click += new System.EventHandler(this.btDeleteGridData_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // btSave
            // 
            this.btSave.BackColor = System.Drawing.Color.Cyan;
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSave.Location = new System.Drawing.Point(277, 447);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 13;
            this.btSave.Text = "保存";
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(489, 482);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btDeleteGridData);
            this.Controls.Add(this.btViewTable);
            this.Controls.Add(this.cbSelectTable);
            this.Controls.Add(this.gbCsvFolder);
            this.Controls.Add(this.tbCsvFolderPath);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btEnd);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.gbCsvFile);
            this.Controls.Add(this.btFileDialog);
            this.Controls.Add(this.tbCsvFilePath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbFilepath_DragDrop);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCsvFilePath;
        private System.Windows.Forms.Button btFileDialog;
        private System.Windows.Forms.GroupBox gbCsvFile;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btEnd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCsvFolderPath;
        private System.Windows.Forms.GroupBox gbCsvFolder;
        private System.Windows.Forms.ComboBox cbSelectTable;
        private System.Windows.Forms.Button btViewTable;
        private System.Windows.Forms.Button btDeleteGridData;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btSave;

    }
}

