using System;

using Renci.SshNet;


namespace R5T.NetStandard.SSH
{
    public static class ConnectionInfoExtensions
    {
        public static SftpClient GetUnconnectedSftpClient(this ConnectionInfo connectionInfo)
        {
            var sftpClient = new SftpClient(connectionInfo);
            return sftpClient;
        }

        public static SftpClient GetSftpClient(this ConnectionInfo connectionInfo)
        {
            var sftpClient = connectionInfo.GetUnconnectedSftpClient();

            sftpClient.Connect();

            return sftpClient;
        }

        public static SshClient GetUnconnectedSshClient(this ConnectionInfo connectionInfo)
        {
            var sshClient = new SshClient(connectionInfo);
            return sshClient;
        }

        public static SshClient GetSshClient(this ConnectionInfo connectionInfo)
        {
            var sshClient = connectionInfo.GetUnconnectedSshClient();

            sshClient.Connect();

            return sshClient;
        }
    }
}
