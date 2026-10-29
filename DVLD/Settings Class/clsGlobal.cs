using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD
{
    internal class clsGlobal
    {
        public static clsUser currentUser = clsUser.Find("", "");

        public static bool SaveUserNameAndPasswordToFile(string userName, string password)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();

                string filePath = currentDirectory + "\\App_File_Setting.txt";
                
                if (userName == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
                
                string dataToSave = userName + "#||#" + password;

                using (StreamWriter write = new StreamWriter(filePath))
                {
                    write.WriteLine(dataToSave);
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool RecoveryUserNameAndPasswordFromFile(ref string userName, ref string password)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();

                string filePath = currentDirectory + "\\App_File_Setting.txt";

                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                            string[] result = line.Split(new string[] { "#||#" }, StringSplitOptions.None);

                            userName = result[0];
                            password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

    }
}
