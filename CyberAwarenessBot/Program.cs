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

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=============================================================");
            Console.WriteLine($"   Welcome to the {BotName} for South Africa!   ");
            Console.WriteLine("=============================================================\n");
            Console.ResetColor();

            Console.WriteLine("I'm here to help you stay safe online.\n");

            Thread.Sleep(800);

            // Main loop
            bool running = true;
            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1": PhishingTopic(); break;
                    case "2": PasswordTopic(); break;
                    case "3": SafeBrowsingTopic(); break;
                    case "4": CommonScamsTopic(); break;
                    case "5": HackedTopic(); break;
                    case "6": FreeQuestionMode(); break;
                    case "0":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nThank you! Stay safe online 🇿🇦");
                        Console.ResetColor();
                        running = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n❌ Invalid choice. Please enter 0-6.");
                        Console.ResetColor();
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚠️ Greeting.wav not found. Make sure the file is added and set to 'Copy if newer'.");
                Console.ResetColor();
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

        static void PhishingTopic() => Console.WriteLine("\n🔴 Never share OTPs from unexpected messages.");
        static void PasswordTopic() => Console.WriteLine("\n🔑 Use strong passphrases and enable MFA.");
        static void SafeBrowsingTopic() => Console.WriteLine("\n🌐 Hover over links before clicking.");
        static void CommonScamsTopic() => Console.WriteLine("\n🚨 Beware of fake SARS and bank scams.");
        static void HackedTopic() => Console.WriteLine("\n🛠️ Change passwords immediately and report to your bank.");

        static void FreeQuestionMode()
        {
            Console.WriteLine("\n💬 Ask anything (type 'back' to return):");
            while (true)
            {
                if (Console.ReadLine()?.Trim().ToLower() == "back") break;
            }
        }
    }
}