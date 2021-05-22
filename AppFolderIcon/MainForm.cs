// <copyright file="MainForm.cs" company="PublicDomain.com">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

namespace AppFolderIcon
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    using Istepaniuk.StringDistance;
    using PublicDomain;

    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Gets or sets the associated icon.
        /// </summary>
        /// <value>The associated icon.</value>
        private Icon associatedIcon = null;

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
        /// Initializes a new instance of the <see cref="T:AppFolderIcon.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            /* Icons */

            // Set associated icon from exe file
            this.associatedIcon = Icon.ExtractAssociatedIcon(typeof(MainForm).GetTypeInfo().Assembly.Location);

            // Set public domain weekly tool strip menu item image
            this.weeklyReleasesPublicDomainWeeklycomToolStripMenuItem.Image = this.associatedIcon.ToBitmap();
        }

        /// <summary>
        /// Handles the weekly releases public domain weeklycom tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnWeeklyReleasesPublicDomainWeeklycomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open weekly releases website
            Process.Start("https://publicdomainweekly.com");
        }

        /// <summary>
        /// Handles the original thread donation codercom tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOriginalThreadDonationCodercomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // IDEA: Pull icon from exe and put on the containing folder
            Process.Start("https://www.donationcoder.com/forum/index.php?topic=51070.0");
        }

        /// <summary>
        /// Handles the source code githubcom tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open source code repository
            Process.Start("https://github.com/publicdomain/appfoldericon");
        }

        /// <summary>
        /// Handles the about tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Set license text
            var licenseText = $"CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication{Environment.NewLine}" +
                $"https://creativecommons.org/publicdomain/zero/1.0/legalcode{Environment.NewLine}{Environment.NewLine}" +
                $"Libraries and icons have separate licenses.{Environment.NewLine}{Environment.NewLine}" +
                $"String Distance library by Iván Stepaniuk - MIT License{Environment.NewLine}" +
                $"https://github.com/istepaniuk/StringDistance{Environment.NewLine}{Environment.NewLine}" +
                $"File folder icon by OpenClipart-Vectors - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/vectors/file-folder-gray-iconset-icons-157955/{Environment.NewLine}{Environment.NewLine}" +
                $"Patreon icon used according to published brand guidelines{Environment.NewLine}" +
                $"https://www.patreon.com/brand{Environment.NewLine}{Environment.NewLine}" +
                $"GitHub mark icon used according to published logos and usage guidelines{Environment.NewLine}" +
                $"https://github.com/logos{Environment.NewLine}{Environment.NewLine}" +
                $"DonationCoder icon used with permission{Environment.NewLine}" +
                $"https://www.donationcoder.com/forum/index.php?topic=48718{Environment.NewLine}{Environment.NewLine}" +
                $"PublicDomain icon is based on the following source images:{Environment.NewLine}{Environment.NewLine}" +
                $"Bitcoin by GDJ - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/vectors/bitcoin-digital-currency-4130319/{Environment.NewLine}{Environment.NewLine}" +
                $"Letter P by ArtsyBee - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/illustrations/p-glamour-gold-lights-2790632/{Environment.NewLine}{Environment.NewLine}" +
                $"Letter D by ArtsyBee - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/illustrations/d-glamour-gold-lights-2790573/{Environment.NewLine}{Environment.NewLine}";

            // Set title
            string programTitle = typeof(MainForm).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;

            // Set version for generating semantic version 
            Version version = typeof(MainForm).GetTypeInfo().Assembly.GetName().Version;

            // Set about form
            var aboutForm = new AboutForm(
                $"About {programTitle}",
                $"{programTitle} {version.Major}.{version.Minor}.{version.Build}",
                $"Made for: kunkel321{Environment.NewLine}DonationCoder.com{Environment.NewLine}Day #45, Week #06 @ February 14, 2021",
                licenseText,
                this.Icon.ToBitmap())
            {

                // Set about form icon
                Icon = this.associatedIcon
            };

            // Show about form
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Handles the options tool strip menu item drop down item clicked event
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOptionsToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Set tool strip menu item
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)e.ClickedItem;

            // Toggle checked
            toolStripMenuItem.Checked = !toolStripMenuItem.Checked;

            // Set topmost by check box
            this.TopMost = this.alwaysOnTopToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the exit tool strip menu item1 click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItem1Click(object sender, EventArgs e)
        {
            // Close program
            this.Close();
        }

        /// <summary>
        /// Handles the browse for folder button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnBrowseForFolderButtonClick(object sender, EventArgs e)
        {
            // Show folder browser dialog
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK && this.folderBrowserDialog.SelectedPath.Length > 0)
            {
                // Declare reusable icon file variable
                string iconFilePath = string.Empty;

                // Declare processed count 
                int processedCount = 0;

                // Iterate subdirectories
                foreach (var subdirectory in Directory.GetDirectories(this.folderBrowserDialog.SelectedPath, "*", SearchOption.AllDirectories))
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

                        // Check for only one file
                        if (exeFileList.Count == 1)
                        {
                            // Set icon file path
                            iconFilePath = exeFileList[0];
                        }
                        else
                        {
                            // Set folder name to compare
                            string folderName = Path.GetDirectoryName(this.folderBrowserDialog.SelectedPath);

                            /** Determine icon file path **/

                            // Dictionary
                            Dictionary<int, List<string>> levenshteinDistanceListDictionary = new Dictionary<int, List<string>>();

                            /* Levenshtein distance */

                            // Set Levenshtein distance calculator
                            LevenshteinDistanceCalculator levenshteinDistanceCalculator = new LevenshteinDistanceCalculator();

                            // Iterate exe files
                            foreach (var exeFilePath in exeFileList)
                            {
                                // Calculate string distance
                                int stringDistanceValue = levenshteinDistanceCalculator.Distance(folderName, Path.GetFileNameWithoutExtension(exeFilePath));

                                // Check if must make room
                                if (!levenshteinDistanceListDictionary.Keys.Contains(stringDistanceValue))
                                {
                                    // Add placeholder to dictionary
                                    levenshteinDistanceListDictionary.Add(stringDistanceValue, new List<string>());
                                }

                                // Add string distance to dictionary
                                levenshteinDistanceListDictionary[stringDistanceValue].Add(exeFilePath);
                            }

                            // Set minimal distance
                            int levenshteinMinStringDistance = levenshteinDistanceListDictionary.Keys.Min();

                            // Check if we have only one element in minimum key list
                            if (levenshteinDistanceListDictionary[levenshteinMinStringDistance].Count == 1)
                            {
                                // Pick item
                                iconFilePath = levenshteinDistanceListDictionary[levenshteinMinStringDistance][0];

                                // Jump to set icon;
                                goto setIcon;
                            }

                            /* Damerau-Levenshtein distance */

                            // Dictionary
                            Dictionary<int, List<string>> damerauLevenshteinDistanceListDictionary = new Dictionary<int, List<string>>();

                            // Set Damerau Levenshtein distance calculator
                            DamerauLevenshteinDistanceCalculator damerauLevenshteinDistanceCalculator = new DamerauLevenshteinDistanceCalculator();

                            // Iterate exe files
                            foreach (var exeFilePath in levenshteinDistanceListDictionary[levenshteinMinStringDistance])
                            {
                                // Calculate string distance
                                int damerauLevenshteinStringDistanceValue = damerauLevenshteinDistanceCalculator.Distance(folderName, Path.GetFileNameWithoutExtension(exeFilePath));

                                // Check if must make room
                                if (!damerauLevenshteinDistanceListDictionary.Keys.Contains(damerauLevenshteinStringDistanceValue))
                                {
                                    // Add placeholder to dictionary
                                    damerauLevenshteinDistanceListDictionary.Add(damerauLevenshteinStringDistanceValue, new List<string>());
                                }

                                // Add string distance to dictionary
                                damerauLevenshteinDistanceListDictionary[damerauLevenshteinStringDistanceValue].Add(exeFilePath);
                            }

                            // Set minimal distance
                            int damerauLevenshteinMinStringDistance = damerauLevenshteinDistanceListDictionary.Keys.Min();

                            // Check if we have only one element in minimum key list
                            if (damerauLevenshteinDistanceListDictionary[damerauLevenshteinMinStringDistance].Count == 1)
                            {
                                // Pick item
                                iconFilePath = damerauLevenshteinDistanceListDictionary[damerauLevenshteinMinStringDistance][0];

                                // Jump to set icon;
                                goto setIcon;
                            }

                            /* Hamming distance */

                            // Dictionary
                            Dictionary<int, List<string>> hammingDistanceListDictionary = new Dictionary<int, List<string>>();

                            // Set Hamming distance calculator
                            HammingDistanceCalculator hammingDistanceCalculator = new HammingDistanceCalculator();

                            // Iterate exe files
                            foreach (var exeFilePath in levenshteinDistanceListDictionary[levenshteinMinStringDistance])
                            {
                                // Calculate string distance
                                int hammingStringDistanceValue = hammingDistanceCalculator.Calculate(folderName, Path.GetFileNameWithoutExtension(exeFilePath));

                                // Check if must make room
                                if (!hammingDistanceListDictionary.Keys.Contains(hammingStringDistanceValue))
                                {
                                    // Add placeholder to dictionary
                                    hammingDistanceListDictionary.Add(hammingStringDistanceValue, new List<string>());
                                }

                                // Add string distance to dictionary
                                hammingDistanceListDictionary[hammingStringDistanceValue].Add(exeFilePath);
                            }

                            // Set minimal distance
                            int hammingMinStringDistance = hammingDistanceListDictionary.Keys.Min();

                            // Pick first .exe
                            iconFilePath = hammingDistanceListDictionary[hammingMinStringDistance][0];

                            // Check if we have only one element in minimum key list
                            if (hammingDistanceListDictionary[hammingMinStringDistance].Count == 1)
                            {
                                // Jump to set icon;
                                goto setIcon;
                            }

                            /* Pick first .exe and log event to file */

                            // Declare string builder
                            StringBuilder eventBodyStringBuilder = new StringBuilder();

                            // Event body
                            eventBodyStringBuilder.AppendLine($"Folder path: {this.folderBrowserDialog.SelectedPath}");
                            eventBodyStringBuilder.AppendLine($"Selected file: {iconFilePath}");
                            eventBodyStringBuilder.AppendLine($"Files:{Environment.NewLine}{string.Join(Environment.NewLine, hammingDistanceListDictionary[hammingMinStringDistance])}");

                            // Log to disk
                            this.LogEvent("Multiple .exe files", eventBodyStringBuilder.ToString());
                        }

                    // Set icon label
                    setIcon:

                        // Set settings
                        LPSHFOLDERCUSTOMSETTINGS FolderCustomSettings = new LPSHFOLDERCUSTOMSETTINGS();
                        FolderCustomSettings.dwMask = 0x10;
                        FolderCustomSettings.pszIconFile = iconFilePath;
                        FolderCustomSettings.iIconIndex = 0;

                        // Set new icon
                        UInt32 HRESULT = SHGetSetFolderCustomSettings(ref FolderCustomSettings, subdirectory, FCS_FORCEWRITE);

                        // Raise processed count
                        processedCount++;
                    }
                    catch (Exception ex)
                    {
                        // Declare string builder
                        StringBuilder eventBodyStringBuilder = new StringBuilder();

                        // Event body
                        eventBodyStringBuilder.AppendLine($"Folder path: {this.folderBrowserDialog.SelectedPath}");
                        eventBodyStringBuilder.AppendLine($"Message: {ex.Message}");

                        // Log to disk
                        this.LogEvent("Folder processing error", eventBodyStringBuilder.ToString());
                    }
                }

                // Update processed count 
                this.countToolStripStatusLabel.Text = processedCount.ToString();
            }
        }

        /// <summary>
        /// Logs the event.
        /// </summary>
        /// <param name="eventTitle">Event title.</param>
        /// <param name="eventBody">Event body.</param>
        private void LogEvent(string eventTitle, string eventBody)
        {
            // Declare string buffer
            StringBuilder stringBuilder = new StringBuilder();

            // Event body
            stringBuilder.AppendLine("----------");
            stringBuilder.AppendLine($"Event: {eventTitle}");
            stringBuilder.AppendLine($"{eventBody}");

            // Log to disk
            File.AppendAllText("AppFolderIcon-EventLog.txt", stringBuilder.ToString());
        }

        /// <summary>
        /// Handles the delete desktop ini button click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnDeleteDesktopIniButtonClick(object sender, EventArgs e)
        {
            // Show folder browser dialog
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK && this.folderBrowserDialog.SelectedPath.Length > 0)
            {
                // Declare processed count 
                int processedCount = 0;

                // Iterate subdirectories
                foreach (var desktopIniPath in Directory.GetFiles(this.folderBrowserDialog.SelectedPath, "desktop.ini", SearchOption.AllDirectories))
                {
                    // Error handling & logging
                    try
                    {
                        // Delete ini file
                        File.Delete(desktopIniPath);

                        // Raise count
                        processedCount++;
                    }
                    catch (Exception ex)
                    {
                        // Log error event
                        this.LogEvent("desktop.ini removal failed", $"File: {desktopIniPath}{Environment.NewLine}Message: {ex.Message}");
                    }
                }

                // Advise user
                MessageBox.Show("Please refresh Explorer to see default icon.", $"Removed {processedCount} desktop.ini files", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
