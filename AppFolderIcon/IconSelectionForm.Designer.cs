﻿// // <copyright file="IconSelectionForm.cs" company="PublicDomain.com">
// //     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
// //     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// // </copyright>
// // <auto-generated />

namespace AppFolderIcon
{
    partial class IconSelectionForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.processButton = new System.Windows.Forms.Button();
            this.setOneIconLabel = new System.Windows.Forms.Label();
            this.iconTreeView = new System.Windows.Forms.TreeView();
            this.iconImageList = new System.Windows.Forms.ImageList(this.components);
            this.mainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.processButton, 0, 2);
            this.mainTableLayoutPanel.Controls.Add(this.setOneIconLabel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.iconTreeView, 0, 1);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 3;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(284, 262);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // processButton
            // 
            this.processButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processButton.Location = new System.Drawing.Point(3, 220);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(278, 39);
            this.processButton.TabIndex = 2;
            this.processButton.Text = "Process selection";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.OnProcessButtonClick);
            // 
            // setOneIconLabel
            // 
            this.setOneIconLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setOneIconLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setOneIconLabel.Location = new System.Drawing.Point(3, 0);
            this.setOneIconLabel.Name = "setOneIconLabel";
            this.setOneIconLabel.Size = new System.Drawing.Size(278, 25);
            this.setOneIconLabel.TabIndex = 0;
            this.setOneIconLabel.Text = "Set one icon per program:";
            this.setOneIconLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconTreeView
            // 
            this.iconTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconTreeView.FullRowSelect = true;
            this.iconTreeView.HotTracking = true;
            this.iconTreeView.Location = new System.Drawing.Point(3, 28);
            this.iconTreeView.Name = "iconTreeView";
            this.iconTreeView.Size = new System.Drawing.Size(278, 186);
            this.iconTreeView.TabIndex = 1;
            this.iconTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnIconTreeViewAfterSelect);
            // 
            // iconImageList
            // 
            this.iconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iconImageList.ImageSize = new System.Drawing.Size(48, 48);
            this.iconImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // IconSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "IconSelectionForm";
            this.Text = "Icon selection";
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.ImageList iconImageList;
        private System.Windows.Forms.TreeView iconTreeView;
        private System.Windows.Forms.Label setOneIconLabel;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
    }
}
