using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace UCASSys.Classes.Controllers
{
    public class Config
    {

        private Dictionary<string, Classes.Items.ConfigItem> config = new Dictionary<string, Items.ConfigItem>();

        public delegate void configLoadedHandler();
        public event configLoadedHandler configLoaded;

        public delegate void configSavedHandler();
        public event configSavedHandler configSaved;

        public Config()
        {
            Program.log.console(GetType().ToString(), "Initialising...");
            Program.dbInt.databaseOpened += loadConfig;
            Program.dbInt.databaseClosed += clearConfig;
            Program.log.console(GetType().ToString(), "Initialised!");
        }

        private void clearConfig()
        {
            config.Clear();
        }
        private void loadConfig()
        {
            Program.log.console(GetType().ToString(), "Loading config...");
            string queryStr = "SELECT `id`, `value`, `description` FROM `config`";
            try
            {
                using (OleDbDataReader data = Program.dbInt.query(queryStr).ExecuteReader())
                {
                    if (!data.HasRows)
                    {
                        return;
                    }

                    Classes.Items.ConfigItem configItem = default(Classes.Items.ConfigItem);
                    while (data.Read())
                    {
                        configItem = new Classes.Items.ConfigItem();
                        configItem.ID = (string)data["id"];
                        if (data["value"] != null)
                        {
                            configItem.Value = (string)data["value"];
                        }

                        if (data["description"] != null)
                        {
                            configItem.Description = (string)data["description"];
                        }

                        config.Add(configItem.ID, configItem);
                    }
                    Program.log.console(GetType().ToString(), "Loaded!");
                    if (configLoaded != null)
                    {
                        configLoaded();
                    }
                }
            }
            catch (Exception ex)
            {
                Database.Interface.databaseError("Failed to load database configuration.", "Classes.Controllers.Config", ex.Message);
            }
        }

        public StatusMessage getSetting(string setting)
        {
            if (this.config.ContainsKey(setting))
            {
                return new StatusMessage(true, "", this.config[setting]);
            }
            else
            {
                return new StatusMessage(false, "Setting \"" + setting + "\" was not found.");
            }
        }

        public StatusMessage saveSetting(Items.ConfigItem config, bool override_acl = false)
        {
            if (!override_acl)
            {
                if (!Program.userCtrl.is_admin)
                {
                    return new StatusMessage(false, "Failed to save setting.", "User is not allowed to save settings.");
                }
            }
            if (getSetting(config.ID))
            {
                return saveConfigUpdate(config);
            }
            else
            {
                return saveConfigInsert(config);
            }
        }

        private StatusMessage saveConfigInsert(Items.ConfigItem config)
        {
            OleDbCommand insertQuery = Program.dbInt.preparedStmt();
            insertQuery.CommandText = "INSERT INTO `config` (`id`,`value`,`description`) VALUES (@id, @value, @description)";
            try
            {
                insertQuery.Parameters.Add("@id", OleDbType.VarChar, 255).Value = config.ID;
                insertQuery.Parameters.Add("@value", OleDbType.VarChar, 255).Value = config.Value.ToString();
                insertQuery.Parameters.Add("@description", OleDbType.VarChar, 255).Value = config.Description.ToString();

                dynamic result = insertQuery.ExecuteNonQuery();
                if (result == 1)
                {
                    configSaved();
                    return new StatusMessage();
                }
                else
                {
                    return new StatusMessage(false, "Failed to save config item.", result.ToString());
                }
            }
            catch (Exception ex)
            {
                Program.log.log(GetType().Namespace, ex.Message + ex.TargetSite);
                return new StatusMessage(false, "Failed to save config item.", ex.Message);
            }
        }
        private StatusMessage saveConfigUpdate(Items.ConfigItem config)
        {
            OleDbCommand updateQuery = Program.dbInt.preparedStmt();
            updateQuery.CommandText = "UPDATE `config` SET `value`=@value, `description`=@description WHERE `id`=@id";
            try
            {
                updateQuery.Parameters.Add("@value", OleDbType.VarChar, 255).Value = config.Value.ToString();
                updateQuery.Parameters.Add("@description", OleDbType.VarChar, 255).Value = config.Description;
                updateQuery.Parameters.Add("@id", OleDbType.VarChar, 255).Value = config.ID;

                dynamic result = updateQuery.ExecuteNonQuery();
                if (result == 1)
                {
                    if (configSaved != null)
                    {
                        configSaved();
                    }
                    return new StatusMessage();
                }
                else
                {
                    return new StatusMessage(false, "Failed to save config item.", result.ToString());
                }
            }
            catch (Exception ex)
            {
                Program.log.log(GetType().Namespace, ex.Message + ex.TargetSite);
                return new StatusMessage(false, "Failed to save config item.", ex.Message);
            }
        }
    }
}
