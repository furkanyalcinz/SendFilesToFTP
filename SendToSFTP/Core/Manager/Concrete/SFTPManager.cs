
using Core.Logging.TextLogger;
using Core.Manager.Abstract;
using Core.Models;
using Core.Utilities.Result;
using Renci.SshNet;
using WinSCP;
namespace Core.Manager.Concrete
{
    public class SFTPManager:ISFTPService
    {
        public IResult SendToSFTP(List<string> filesToUpload, SFTPConnectionModel connectionModel)
        {
            TextLogger.WriteInformationLog("SFTP connection is started.");
            SftpClient client = new SftpClient(host: connectionModel.Host, port: connectionModel.Port, username: connectionModel.Username, password: connectionModel.Password);

            try
            {
                client.Connect();
                TextLogger.WriteInformationLog("Connection establised.");
            }
            catch (Exception err)
            {
                TextLogger.WriteErrorLog("Connection could not established. " + err.ToString());
                return new Result(false, "SFTP connection is failed + " + err.ToString());
            }
            int numberOfUploadedFile = 0;
            TextLogger.WriteInformationLog("Number of" + filesToUpload.Count.ToString() + "file will be upload");
            if (filesToUpload.Count > 0)
            {
                foreach (string file in filesToUpload)
                {
                    using (var uplFileStream = File.OpenRead(file))
                    {
                        try
                        {
                            string fileName = Path.GetFileName(file);
                            client.UploadFile(uplFileStream, "/" + fileName, null);
                            numberOfUploadedFile++;
                            TextLogger.WriteInformationLog(fileName + " uploaded.");

                        }
                        catch (Exception err)
                        {
                            TextLogger.WriteErrorLog(Path.GetFileName(file) + " could not uploaded." + err.ToString());
                        }
                    }
                }
                return new Result(true, "Number of " + numberOfUploadedFile.ToString() + "files are sent");
            }
            return new Result(true, "There is no file to sent.");
        }

        public IResult SendToFTP(List<string> filesToUpload, SFTPConnectionModel connectionModel)
        {
            int numOfUploadedFile = 0;
            TextLogger.WriteInformationLog("Sendig to FTP is Started");
            SessionOptions sessionOption = new SessionOptions
            {
                Protocol = Protocol.Ftp,
                PortNumber = connectionModel.Port,
                HostName = connectionModel.Host,
                UserName = connectionModel.Username,
                Password = connectionModel.Password
            };
            using (WinSCP.Session session = new WinSCP.Session())
            {
                try
                {
                    session.Open(sessionOption);
                    TextLogger.WriteInformationLog("Connection established. " + filesToUpload.Count.ToString());
                }
                catch (Exception err)
                {
                    TextLogger.WriteErrorLog("Could not connected");
                    return new Result(false, err.ToString());
                }
                
                
                TextLogger.WriteInformationLog("session established");
                foreach (string file in filesToUpload)
                {
                    if (File.Exists(file))
                    {
                        try
                        {
                            session.PutFiles(file, "/");
                            TextLogger.WriteInformationLog("File uploaded >> " + file);
                        }
                        catch (Exception err)
                        {
                            TextLogger.WriteErrorLog("File could not uploaded >> " + file + " " + err.ToString());
                        }
                        

                    }
                    else
                    {
                        TextLogger.WriteInformationLog("File is not found >> " + file);
                    }
                    
                }
                session.Close();
                TextLogger.WriteInformationLog("Connection closed");
            }
            return new Result(true, numOfUploadedFile.ToString() + "files uploaded");
        }
    }
}
