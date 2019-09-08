using System;

using Renci.SshNet;


namespace R5T.NetStandard.SSH
{
    public static class SftpClientExtensions
    {
        /// <summary>
        /// Creates a directory (checking if the directory exists first to avoid error when the directory already exists).
        /// Can be called multiple times.
        /// The <see cref="System.IO.Directory.CreateDirectory(string)"/> method can be called multiple times without error. The <see cref="SftpClient.CreateDirectory(string)"/> method cannot. This method fixes the SFTP client behavior to be like the Directory class.
        /// </summary>
        public static void CreateDirectoryOkIfExists(this SftpClient sftpClient, string directoryPath)
        {
            if (!sftpClient.Exists(directoryPath))
            {
                sftpClient.CreateDirectory(directoryPath);
            }
        }
    }
}
