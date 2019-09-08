using System;

using Renci.SshNet;


namespace R5T.NetStandard.SSH
{
    /// <summary>
    /// Wraps a <see cref="Renci.SshNet.SftpClient"/> so that client libraries do not have take a reference on the Renci library.
    /// </summary>
    public class SftpClientWrapper : IDisposable
    {
        #region IDisposable

        private bool zDisposed = false;


        public void Dispose()
        {
            this.Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!this.zDisposed)
            {
                if (disposing)
                {
                    this.SftpClient.Dispose();
                }
            }

            this.zDisposed = true;
        }

        #endregion


        public SftpClient SftpClient { get; }


        public SftpClientWrapper(SftpClient sftpClient)
        {
            this.SftpClient = sftpClient;
        }

        public SftpClientWrapper(ConnectionInfo connectionInfo)
            : this(new SftpClient(connectionInfo))
        {
        }

        public SftpClientWrapper(string hostUrl, string userName, string password, string privateKeyFilePath)
            : this(Utilities.GetConnectionInfo(hostUrl, userName, password, privateKeyFilePath))
        {
        }
    }
}
