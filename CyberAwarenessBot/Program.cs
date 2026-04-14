using System;
using System.Media;
using System.Threading;

namespace CyberAwarenessBot
{
    class Program
    {
        // Bot configuration
        public static string BotName { get; set; } = "Cybersecurity Awareness Assistant";

        static void Main(string[] args)
        {
            Console.Title = "🇿🇦 Cybersecurity Awareness Assistant";

            PlayVoiceGreeting();
            DisplayAsciiArt();
            ShowWelcomeMessage();

            RunBot();
        }

        // 🔹 NEW: Separated main loop into its own method
        static void RunBot()
        {
            bool running = true;

            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1": ShowMessage("🔴 Never share OTPs from unexpected messages."); break;
                    case "2": ShowMessage("🔑 Use strong passphrases and enable MFA."); break;
                    case "3": ShowMessage("🌐 Hover over links before clicking."); break;
                    case "4": ShowMessage("🚨 Beware of fake SARS and bank scams."); break;
                    case "5": ShowMessage("🛠️ Change passwords immediately and report to your bank."); break;
                    case "6": FreeQuestionMode(); break;
                    case "0":
                        ExitMessage();
                        running = false;
                        break;
                    default:
                        ShowError("❌ Invalid choice. Please enter 0-6.");
                        break;
                }

                if (running)
                {
                    ReturnToMenu();
                }
            }
        }

        // 🔹 NEW: Welcome message extracted
        static void ShowWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=============================================================");
            Console.WriteLine($"   Welcome to the {BotName} for South Africa!   ");
            Console.WriteLine("=============================================================\n");
            Console.ResetColor();

            Console.WriteLine("I'm here to help you stay safe online.\n");
            Thread.Sleep(800);
        }

        static void PlayVoiceGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("Greeting.wav");
                player.Play();
            }
            catch
            {
                ShowError("⚠️ Greeting.wav not found. Make sure the file is added.");
            }
        }

        static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
   _____ _          _     _____                 
  / ____| |        | |   |  __ \                
 | |    | |__   ___| |_  | |__) |___  ___ _ __  
 | |    | '_ \ / _ \ __| |  _  // _ \/ _ \ '_ \ 
 | |____| | | |  __/ |_  | | \ \  __/  __/ |_) |
  \_____|_| |_|\___|\__| |_|  \_\___|\___| .__/ 
                                         | |    
                                         |_|    
            South African Cybersecurity Assistant
");
            Console.ResetColor();
        }

        static void ShowMenu()
        {
            Console.WriteLine("\nWhat would you like to learn about today?");
            Console.WriteLine("1. Spotting Phishing Emails & SMS");
            Console.WriteLine("2. Strong Passwords & MFA");
            Console.WriteLine("3. Safe Browsing & Suspicious Links");
            Console.WriteLine("4. Common Scams in South Africa");
            Console.WriteLine("5. What to do if you've been hacked");
            Console.WriteLine("6. Ask me a free question");
            Console.WriteLine("0. Exit");
            Console.Write("\nEnter your choice: ");
        }

        // 🔹 NEW: Reusable message method
        static void ShowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }

        // 🔹 NEW: Error handler
        static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }

        // 🔹 NEW: Exit message
        static void ExitMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThank you! Stay safe online 🇿🇦");
            Console.ResetColor();
        }

        // 🔹 NEW: Return-to-menu handler
        static void ReturnToMenu()
        {
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey(true);
            Console.Clear();
        }

        static void FreeQuestionMode()
        {
            Console.WriteLine("\n💬 Ask anything (type 'back' to return):");
            while (true)
            {
                string input = Console.ReadLine()?.Trim().ToLower() ?? "";

                if (input == "back") break;

                // 🔹 NEW: Simple keyword-based responses
                if (input.Contains("password"))
                    ShowMessage("Use long passphrases and never reuse passwords.");
                else if (input.Contains("phishing"))
                    ShowMessage("Check sender addresses and avoid urgent requests.");
                else
                    ShowMessage("That's a great question! Stay cautious online.");
            }
        }
    }
}