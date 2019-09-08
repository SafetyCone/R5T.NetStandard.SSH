using System;

using Renci.SshNet;


namespace R5T.NetStandard.SSH
{
    public static class ConnectionInfoExtensions
    {
        public static SftpClient GetConnectedClient(this ConnectionInfo connectionInfo)
        {
            var sftpClient = new SftpClient(connectionInfo);

            sftpClient.Connect();

            return sftpClient;
        }
    }
}
