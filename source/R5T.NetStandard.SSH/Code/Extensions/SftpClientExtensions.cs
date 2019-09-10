using System;

using Renci.SshNet;

using PathUtilities = R5T.NetStandard.IO.Paths.Utilities;


namespace R5T.NetStandard.SSH
{
    public static class SftpClientExtensions
    {
        /// <summary>
        /// Creates a directory (checking if the directory exists first to avoid error when the directory already exists).
        /// Can be called multiple times.
        /// The <see cref="System.IO.Directory.CreateDirectory(string)"/> method can be called multiple times without error. The <see cref="SftpClient.CreateDirectory(string)"/> method cannot. This method fixes the SFTP client behavior to be like the Directory class.
        /// Cannot be called to make intermediate directories for nested directories. For example, if A exists, but B does not, a call to create C such that /A/B/C will fail with exception:
        ///     Renci.SshNet.Common.SftpPathNotFoundException: 'No such file'
        /// </summary>
        public static void CreateDirectoryOkIfExists(this SftpClient sftpClient, string directoryPath)
        {
            if (!sftpClient.Exists(directoryPath))
            {
                sftpClient.CreateDirectory(directoryPath);
            }
        }

        /// <summary>
        /// Creates a directory, creating all required intermediate directories.
        /// Ok if the directory already exists (idempotent) like <see cref="CreateDirectoryOkIfExists(SftpClient, string)"/>.
        /// </summary>
        /// <remarks>
        /// The <see cref="Renci.SshNet.SftpClient.CreateDirectory(string)"/> method will not make intermediate directories for nested directories. For example, if A exists, but B does not, a call to create C such that /A/B/C will fail with exception:
        ///     Renci.SshNet.Common.SftpPathNotFoundException: 'No such file'
        /// </remarks>
        public static void CreateDirectoryOkIfIntermediatesAndExists(this SftpClient sftpClient, string directoryPath)
        {
            // The SftpClient.CreateDirectory() call will not make intermediate directories as required for a path.
            // This work-around walks up the directory tree until a parent directory exists, and makes intermediate directories as required.
            var parentDirectoryPath = PathUtilities.GetParentDirectoryPath(directoryPath);
            if (!sftpClient.Exists(parentDirectoryPath))
            {
                sftpClient.CreateDirectoryOkIfIntermediatesAndExists(parentDirectoryPath);
            }

            sftpClient.CreateDirectory(directoryPath);
        }
    }
}
