using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    internal class clsUtile
    {
        public static string CreateGUID()
        {
            Guid guName = new Guid();

            guName = Guid.NewGuid();

            return guName.ToString();
        }

        public static bool CreateFolderIsDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
                return true;
            }
            else if(Directory.Exists(FolderPath))
            {
                return true;
            }
            else 
            { 
                return false;
            }
        }

        public static string ReplaceFileNameToGuid(string sourceFile)
        {
            string fileName = sourceFile;

            FileInfo fio = new FileInfo(fileName);

            string extention = fio.Extension;

            return CreateGUID() + extention;
        }

        public static bool CopyImageToProjectImageFolder(ref string sourceFile)
        {
            string DirectoryPath = @"C:\Image-DVLD-Project\";

            if (!CreateFolderIsDoesNotExist(DirectoryPath))
            {
                return false;
            }

            string distinationFile = DirectoryPath + ReplaceFileNameToGuid(sourceFile);

            try
            {
                File.Copy(sourceFile, distinationFile, true);
            }
            catch(IOException exio)
            {
                MessageBox.Show(exio.Message, " erorr ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = distinationFile;
            return true;
        }

    }
}
