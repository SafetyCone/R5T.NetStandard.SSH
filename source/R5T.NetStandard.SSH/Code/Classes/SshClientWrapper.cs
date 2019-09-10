using System;

using Renci.SshNet;


namespace R5T.NetStandard.SSH
{
    public class SshClientWrapper : IDisposable
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
                    this.SshClient.Dispose();
                }
            }

            this.zDisposed = true;
        }

        #endregion


        public SshClient SshClient { get; }


        public SshClientWrapper(SshClient sshClient)
        {
            this.SshClient = sshClient;
        }

        public SshClientWrapper(ConnectionInfo connectionInfo)
            : this(new SshClient(connectionInfo))
        {
        }

        public SshClientWrapper(string hostUrl, string userName, string password, string privateKeyFilePath)
            : this(Utilities.GetConnectionInfo(hostUrl, userName, password, privateKeyFilePath))
        {
        }
    }
}
