// <copyright file="IconSelectionForm.cs" company="PublicDomain.com.ve">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

namespace AppFolderIcon
{
    // Directives
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Description of IconSelectionForm.
    /// </summary>
    public partial class IconSelectionForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppFolderIcon.IconSelectionForm"/> class.
        /// </summary>
        /// <param name="iconDirectoryPath">Icon directory path.</param>
        public IconSelectionForm(string iconDirectoryPath)
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();
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
            // TODO Add code
        }
    }
}
