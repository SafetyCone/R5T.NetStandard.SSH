using System;


namespace R5T.NetStandard.SSH
{
    public static class SftpClientWrapperExtensions
    {
        /// <summary>
        /// Creates a directory.
        /// Idempotent, can be called multiple times (does not throw an exception if the directory already exists).
        /// Creates all required intermediate directories for a nested directory path.
        /// </summary>
        public static void CreateDirectory(this SftpClientWrapper clientWrapper, string directoryPath)
        {
            clientWrapper.SftpClient.CreateDirectoryOkIfIntermediatesAndExists(directoryPath);
        }

        /// <summary>
        /// Deletes a directory.
        /// Not idempotent, cannot be called multiple times. If an attempt is made to delete a non-existent directory, "Renci.SshNet.Common.SftpPathNotFoundException: 'No such file'" is thrown.
        /// Note, this is consistent with the <see cref="System.IO.Directory.Delete(string)"/> behavior.
        /// </summary>
        public static void DeleteDirectoryThrowIfNotExists(this SftpClientWrapper clientWrapper, string directoryPath)
        {
            clientWrapper.SftpClient.DeleteDirectory(directoryPath);
        }

        /// <summary>
        /// Creates a directory.
        /// Idempotent, can be called multiple times (does not throw an exception if the directory does not exist).
        /// Note, this is different than the <see cref="System.IO.Directory.Delete(string)"/> behavior.
        /// </summary>
        public static void DeleteDirectory(this SftpClientWrapper clientWrapper, string directoryPath)
        {
            var client = clientWrapper.SftpClient;

            if(client.Exists(directoryPath))
            {
                client.Delete(directoryPath);
            }
        }
    }
}
