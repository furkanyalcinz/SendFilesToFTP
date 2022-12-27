// See https://aka.ms/new-console-template for more information
using Core.Manager.Concrete;
using Core.Models;

Console.WriteLine("Program started");
SFTPManager sFTP = new SFTPManager();
SFTPConnectionModel connectionModel = new SFTPConnectionModel("127.0.0.1", 21, "furkan", "123456");
List<string> files = new List<string> { @"C:\Users\furka\Desktop\2.txt", @"C:\Users\furka\Desktop\1.txt" };
sFTP.SendToFTP(files, connectionModel);

