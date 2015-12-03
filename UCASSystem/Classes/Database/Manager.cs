using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System.IO.Packaging;
using System.Windows.Forms;

namespace UCASSys.Classes.Database
{

    static class Manager
    {

        public const int BackUp_Ask = 0;
        public const int BackUp_NoAsk = 1;
        public const int BackUp_Auto = 2;

        public static void setLastBackupTime()
        {
            Items.ConfigItem backup = new Items.ConfigItem();

            if (!Program.configCtrl.getSetting("backup_last"))
            {
                return;
            }
            backup = (Items.ConfigItem)Program.configCtrl.getSetting("backup_last").Data;
            backup.Value = DateTime.Now.ToString("yyyy-MM-dd");

            Program.configCtrl.saveSetting(backup, true);
        }

        public static bool should_backup()
        {
            if (!Program.configCtrl.getSetting("backup_last"))
            {
                return true;
            }
            int timeToAdd = 7;
            if (Program.regCtrl.getKey("backup_reminder"))
            {
                timeToAdd = (int)Program.regCtrl.getKey("backup_reminder").Data;
            }
            Items.ConfigItem lastBackup = (Items.ConfigItem)Program.configCtrl.getSetting("backup_last").Data;
            if (lastBackup.Value == null)
            {
                return true;
            }

            DateTime lastBackup_dt;
            DateTime.TryParse((string)lastBackup.Value, out lastBackup_dt);
            if (lastBackup_dt.AddDays(timeToAdd) < DateTime.Now)
            {
                return true;
            }
            return false;
        }

        #region Backup
        public static void database_backup(string fileOut = "")
        {
            if (fileOut == "")
            {
                using (SaveFileDialog backupOutDialog = new SaveFileDialog())
                {
                    backupOutDialog.InitialDirectory = Path.GetDirectoryName(Program.dbInt.currentDatabase) + "\\backup\\";
                    backupOutDialog.AddExtension = true;
                    backupOutDialog.AutoUpgradeEnabled = true;
                    backupOutDialog.DefaultExt = "usysx";
                    backupOutDialog.SupportMultiDottedExtensions = true;
                    backupOutDialog.FileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    backupOutDialog.Filter = "UCAS System Compressed Database (*.usysx)|*.usysx|UCAS System Database (*.usys)|*.usys|Microsoft Access Database (*.accdb)|*.accdb";
                    backupOutDialog.OverwritePrompt = true;

                    if (backupOutDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    fileOut = backupOutDialog.FileName;
                }
            }

            if (Path.GetExtension(fileOut).Replace(".", "") != "usysx")
            {
                Items.NotificationItem notification = new Items.NotificationItem();
                notification.Title = "Backup";

                File.Copy(Program.dbInt.currentDatabase, fileOut);

                if (File.Exists(fileOut))
                {
                    notification.Icon = System.Windows.Forms.ToolTipIcon.Info;
                    notification.Message = "UCCAS System successfully backed up the database to " + Path.GetFileName(fileOut);
                    notification.Sound = System.Media.SystemSounds.Asterisk;
                }
                else
                {
                    notification.Icon = System.Windows.Forms.ToolTipIcon.Error;
                    notification.Message = "UCCAS System failed backed up the database.";
                    notification.Sound = System.Media.SystemSounds.Exclamation;
                }

                Program.notifyCtrl.Add(notification);

                return;
            }

            File.Copy(Program.dbInt.currentDatabase, Path.GetFileNameWithoutExtension(fileOut) + ".usys");

            StatusMessage compressed = Manager.compress(Path.GetFileNameWithoutExtension(fileOut) + ".usys", fileOut);
            if (compressed)
            {
                File.Delete(Path.GetFileNameWithoutExtension(fileOut) + ".usys");
                setLastBackupTime();
                Program.notifyCtrl.Add(new Items.NotificationItem(
                        "Backup",
                        "UCAS System Successfully backed up the database to " + Path.GetFileName(fileOut), ToolTipIcon.Info,
                        "",
                        System.Media.SystemSounds.Asterisk
                ));
            }
            else
            {
                TaskDialog errorDialog = new TaskDialog();
                errorDialog.errorBox();
                errorDialog.Title = "Backup Failure";
                errorDialog.Subtitle = "UCAS System failed to backup the database.";
                errorDialog.DetailsText = compressed.Data.ToString();
                errorDialog.ExpansionMode = TaskDialogExpandedDetailsLocation.ExpandFooter;
                errorDialog.StandardButtons = TaskDialogStandardButtons.Retry | TaskDialogStandardButtons.Cancel;
                if (errorDialog.Show() == TaskDialogResult.Retry)
                {
                    database_backup(fileOut);
                }
            }
            
        }

        #endregion

        #region Compression
        public static StatusMessage compress(string fileIn, string fileOut)
        {
            try
            {
                using (Package zip = ZipPackage.Open(fileOut, FileMode.Create, FileAccess.ReadWrite))
                {
                    string zipUri = string.Concat("/database.usys");
                    Uri partUri = new Uri(zipUri, UriKind.Relative);
                    string contentType = "application/msaccess";
                    PackagePart pkgPart = zip.CreatePart(partUri, contentType, CompressionOption.Maximum);

                    byte[] bytes = File.ReadAllBytes(fileIn);
                    
                    pkgPart.GetStream().Write(bytes, 0, bytes.Length);
                }
                return new StatusMessage();
            }
            catch (Exception ex)
            {
                Program.log.log("UCASSys.Classes.Database.Manager", ex.Message + ex.TargetSite);
                return new StatusMessage(false, "Failed to compress file.", ex.Message);
            }

        }

        public static StatusMessage expand(string fileIn, string fileOut)
        {
            try
            {
                using (Package zip = ZipPackage.Open(fileIn, FileMode.Open, FileAccess.Read))
                {
                    PackagePart zipPart = zip.GetPart(new Uri("/database.usys", UriKind.Relative));
                    byte[] bytes = new byte[zipPart.GetStream().Length];
                    zipPart.GetStream().Read(bytes, 0, bytes.Length);
                    if (File.Exists(fileOut))
                    {
                        File.Delete(fileOut);
                    }
                    File.WriteAllBytes(fileOut, bytes);
                }
                return new StatusMessage();
            }
            catch (Exception ex)
            {
                Program.log.log("UCASSys.Classes.Database.Manager", ex.Message + ex.TargetSite);
                return new StatusMessage(false, "Failed to extract zip.", ex.Message);
            }
        }
        #endregion
    }
}
