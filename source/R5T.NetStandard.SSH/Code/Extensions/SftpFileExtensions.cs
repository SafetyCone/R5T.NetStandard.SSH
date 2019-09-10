using System;

using Renci.SshNet.Sftp;


namespace R5T.NetStandard.SSH
{
    public static class SftpFileExtensions
    {
        // Determines if a file (or directory since directories are considered to be SFTP files) is hidden by whether its name begins with a period.
        public static bool IsHidden(this SftpFile sftpFile)
        {
            var nameBeginsWithPeriod = sftpFile.Name[0] == '.';
            return nameBeginsWithPeriod;
        }
    }
}
