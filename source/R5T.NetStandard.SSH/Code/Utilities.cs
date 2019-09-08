using System;

using Renci.SshNet;


namespace R5T.NetStandard.SSH
{
    public static class Utilities
    {
        public static ConnectionInfo GetConnectionInfo(string hostUrl, string userName, string password, string privateKeyFilePath)
        {
            var privateKeyFiles = new[]
            {
                new PrivateKeyFile(privateKeyFilePath, password),
            };

            var authenticationMethods = new AuthenticationMethod[]
            {
                new PasswordAuthenticationMethod(userName, password),
                new PrivateKeyAuthenticationMethod(userName, privateKeyFiles)
            };

            // Get a connection.
            var output = new ConnectionInfo(
                hostUrl,
                userName,
                authenticationMethods);

            return output;
        }

        public static SftpClient GetSftpClient(string hostUrl, string userName, string password, string privateKeyFilePath)
        {
            var connectionInfo = Utilities.GetConnectionInfo(hostUrl, userName, password, privateKeyFilePath);

            var sftpClient = new SftpClient(connectionInfo);
            return sftpClient;
        }
    }
}
