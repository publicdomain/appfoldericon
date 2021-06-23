// <copyright file="IconSelectionForm.cs" company="PublicDomainWeekly.com">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

namespace AppFolderIcon
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    using F23.StringSimilarity;

    /// <summary>
    /// Description of IconSelectionForm.
    /// </summary>
    public partial class IconSelectionForm : Form
    {
        /// <summary>
        /// Gets or sets the processed count.
        /// </summary>
        /// <value>The processed count.</value>
        public int ProcessedCount { get; set; }

        /// <summary>
        /// The icon directory path.
        /// </summary>
        private string iconDirectoryPath;

        /// <summary>
        /// The log event.
        /// </summary>
        private LogEvent logEvent = new LogEvent();

        /// <summary>
        /// The fcs forcewrite.
        /// </summary>
        private UInt32 FCS_FORCEWRITE = 0x00000002;

        /// <summary>
        /// SHGs the et set folder custom settings.
        /// </summary>
        /// <returns>The et set folder custom settings.</returns>
        /// <param name="pfcs">Pfcs.</param>
        /// <param name="pszPath">Psz path.</param>
        /// <param name="dwReadWrite">Dw read write.</param>
        [DllImport("Shell32.dll", CharSet = CharSet.Auto)]
        private static extern UInt32 SHGetSetFolderCustomSettings(ref LPSHFOLDERCUSTOMSETTINGS pfcs, string pszPath, UInt32 dwReadWrite);

        /// <summary>
        /// Lpshfoldercustomsettings.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct LPSHFOLDERCUSTOMSETTINGS
        {
            public UInt32 dwSize;
            public UInt32 dwMask;
            public IntPtr pvid;
            public string pszWebViewTemplate;
            public UInt32 cchWebViewTemplate;
            public string pszWebViewTemplateVersion;
            public string pszInfoTip;
            public UInt32 cchInfoTip;
            public IntPtr pclsid;
            public UInt32 dwFlags;
            public string pszIconFile;
            public UInt32 cchIconFile;
            public int iIconIndex;
            public string pszLogo;
            public UInt32 cchLogo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppFolderIcon.IconSelectionForm"/> class.
        /// </summary>
        /// <param name="iconDirectoryPath">Icon directory path.</param>
        public IconSelectionForm(string iconDirectoryPath)
        {
            // Declare reusable icon file variable
            string iconFilePath = string.Empty;

            // Set icon directory path
            this.iconDirectoryPath = iconDirectoryPath;

            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            /* Populate TreeView */

            // Assign image list
            this.iconTreeView.ImageList = this.iconImageList;

            // Clear image indexes
            this.iconTreeView.ImageIndex = -1;
            this.iconTreeView.SelectedImageIndex = -1;

            // Set sbudirectories list
            var subdirectoryList = Directory.GetDirectories(iconDirectoryPath, "*", SearchOption.TopDirectoryOnly);

            // Iterate subdirectories
            foreach (var subdirectory in subdirectoryList)
            {
                // Error handling & logging
                try
                {
                    // Get .exe file(s)
                    List<string> exeFileList = Directory.GetFiles(subdirectory, "*.exe", SearchOption.TopDirectoryOnly).ToList();

                    // Check for no exe file
                    if (exeFileList.Count == 0)
                    {
                        // Halt flow
                        continue;
                    }

                    // Set name
                    var subdirectoryName = Path.GetFileName(subdirectory);

                    // Add to tree view
                    this.iconTreeView.Nodes.Add(subdirectory, subdirectoryName);

                    // Declare exe file icon list
                    var exeFileIconList = new List<string>();

                    // Add exe files list to tree view node
                    foreach (var exeFilePath in exeFileList)
                    {
                        // Set name
                        var exeFileName = Path.GetFileName(exeFilePath);

                        // Try to get icon
                        var exeFileIcon = Icon.ExtractAssociatedIcon(exeFilePath);

                        // Check there's an icon
                        if (exeFileIcon != null)
                        {
                            // Add icon to image list
                            this.iconImageList.Images.Add(exeFilePath, Icon.ExtractAssociatedIcon(exeFilePath));

                            // Add to subdirectory tree view node
                            this.iconTreeView.Nodes[subdirectory].Nodes.Add(exeFilePath, exeFileName, exeFilePath, exeFilePath);

                            // Add to exe file icon list
                            exeFileIconList.Add(exeFilePath);
                        }
                    }

                    // Check for only one file
                    if (exeFileIconList.Count == 1)
                    {
                        // Set icon file path
                        iconFilePath = exeFileIconList[0];
                    }
                    else
                    {
                        // String score dictionary
                        var exeScoreDictionary = new Dictionary<double, string>();

                        // Get score for each exe file with icon
                        foreach (var exeFileIcon in exeFileIconList)
                        {
                            // Set RatcliffObershelp 
                            var ratcliffObershelp = new RatcliffObershelp();

                            // Set score
                            var score = ratcliffObershelp.Similarity(iconDirectoryPath, exeFileIcon);

                            // Add unique score only (user can select manually)
                            if (!exeScoreDictionary.ContainsKey(score))
                            {
                                exeScoreDictionary.Add(score, exeFileIcon);
                            }
                        }

                        // Set icon file path to the best score
                        iconFilePath = exeScoreDictionary[exeScoreDictionary.Keys.Min()];
                    }

                    // Set program's node icon
                    this.iconTreeView.Nodes[subdirectory].ImageKey = iconFilePath;
                    this.iconTreeView.Nodes[subdirectory].SelectedImageKey = iconFilePath;
                }
                catch (Exception ex)
                {
                    // Declare string builder
                    StringBuilder eventBodyStringBuilder = new StringBuilder();

                    // Event body
                    eventBodyStringBuilder.AppendLine($"Folder path: {iconDirectoryPath}");
                    eventBodyStringBuilder.AppendLine($"Message: {ex.Message}");

                    // Log to disk
                    this.logEvent.WriteEvent("Folder processing error", eventBodyStringBuilder.ToString());
                }
            }
        }

        /// <summary>
        /// Processes the button click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnProcessButtonClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Icons the tree view after select.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnIconTreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            // Update parent node icon
            if (e.Node.Parent != null)
            {
                e.Node.Parent.ImageKey = e.Node.ImageKey;
                e.Node.Parent.SelectedImageKey = e.Node.SelectedImageKey;
            }
        }
    }
}
