using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTPLib
{
    public interface IFileTransport
    {
        void download(string remoteFile, string localFile);
        void upload(string remoteFile, string localFile);
        void delete(string deleteFile);
        void rename(string currentFileNameAndPath, string newFileName);
        void createDirectory(string newDirectory);
        string getFileCreatedDateTime(string fileName);
        string getFileSize(string fileName);
        string[] directoryListSimple(string directory);
        string[] directoryListDetailed(string directory);
    }
}
