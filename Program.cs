using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

using VideoLibrary;

namespace youtube_dl {
    class Program {
        static void Main() {

            List<string> args = new List<string>(Environment.GetCommandLineArgs());
            args.RemoveAt(0);

            try {
                string ytlink = args[0];

                if (ytlink.StartsWith("https://www.youtube.com/watch?v=")) {

                    Info("Starting YouTube Player...");
                    var youtube = YouTube.Default;
                    var video = youtube.GetVideo(ytlink);

                    Info($"Video name = [\"{video.FullName}\"]");
                    string dir = "D:\\youtube-dl";
                    File.WriteAllBytes($"{dir}\\{video.FullName}", video.GetBytes());

                    Info($"Video Downloaded successfully");
                
                } else {
                    Error("Invalid YouTube link.");
                }

            }

            catch (System.ArgumentOutOfRangeException e) {
                Error("No YouTube link provided.");
            }

            catch(Exception e) {
                Error(e.Message);
            }

        }

        static void Info(string info) {
            Console.WriteLine($"[INFO]: {info}");
        }

        static void Error(string error) {
            Console.WriteLine($"[ERROR]: {error}");
        }

    }
}
