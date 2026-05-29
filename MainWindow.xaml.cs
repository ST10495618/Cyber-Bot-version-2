using System;
using System.IO;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
       
    public partial class MainWindow : Window
    {
        private string favouriteTopic = "";
        private ChatMemory memory = new ChatMemory();

        private Random random = new Random();

        private List<Brush> backgrounds =
            new List<Brush>()
        {
            Brushes.DarkSlateBlue,
            Brushes.DarkOliveGreen,
            Brushes.DarkCyan,
            Brushes.DarkRed,
            Brushes.MidnightBlue
        };
        // dictionary
        // CYBERSECURITY RESPONSES
        private Dictionary<string, List<string>> cyberResponses =
            new Dictionary<string, List<string>>()
        {
            {
                "password",
                new List<string>()
                {
                    "Use strong passwords with symbols ",
                    "Never reuse passwords on different websites ",
                    "Enable two-factor authentication for extra protection 🛡"
                }
            },

            {
                "privacy",
                new List<string>()
                {
                    "Avoid sharing personal information publicly ",
                    "Review app permissions regularly ",
                    "Use privacy settings on social media "
                }
            },

            {
                "scam",
                new List<string>()
                {
                    "Never trust suspicious emails |",
                    "Scammers often create urgency to trick victims |",
                    "Verify links before clicking them |"
                }
            },

            {
                "phishing",
                new List<string>()
                {
                    "Avoid clicking suspicious links ",
                    "Check email addresses carefully ",
                    "Do not download unknown attachments ",
                    "Use antivirus software "
                }
            },
            {
    "malware",
    new List<string>()
    {
        "Install trusted antivirus software.",
        "Avoid downloading files from unknown websites.",
        "Keep your operating system updated regularly."
    }
},

{
    "vpn",
    new List<string>()
    {
        "A VPN helps protect your internet privacy.",
        "Use trusted VPN services only.",
        "VPNs are useful on public Wi-Fi networks."
    }
},

{
    "ransomware",
    new List<string>()
    {
        "Always back up important files.",
        "Do not open suspicious email attachments.",
        "Ransomware can lock your files until money is paid."
    }
},

{
    "antivirus",
    new List<string>()
    {
        "Keep your antivirus updated.",
        "Run regular system scans.",
        "Antivirus software helps detect threats early."
    }
},

{
    "hacking",
    new List<string>()
    {
        "Enable two-factor authentication for better security.",
        "Never reuse passwords across accounts.",
        "Hackers often target weak passwords."
    }
}
        };

        private string historyFile =
            "History/chat_history.txt";

        private bool nameStored = false;

        public MainWindow()
        {
            InitializeComponent();

            StartBackgroundAnimation();

            PlayGreeting();
            
            AddBotMessage("Hello,I am an Online Cyberbot Luna. What is your name?");
        }


      
        // The background color 
        private void StartBackgroundAnimation()
        {
            DispatcherTimer timer =new DispatcherTimer();

            timer.Interval =TimeSpan.FromSeconds(5);

            timer.Tick += (s, e) =>
            {
                MainGrid.Background =backgrounds[random.Next(backgrounds.Count)];
            };

            timer.Start();
        }

        // INTRO VOICE
        private void PlayGreeting()
        {
            try
            {
                //Add the voice path here 
                SoundPlayer player =new SoundPlayer("C:\\Users\\shlaps\\Pictures\\WpfApp1\\WpfApp1\\voice1.wav");

                player.Load();
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sound could not play: " + ex.Message);


            }
        }

        private async void SendButton_Click(object sender,RoutedEventArgs e)
        {
            try
            {
                string message =
                    UserInput.Text.Trim();

                if (string.IsNullOrWhiteSpace(message))
                {
                    AddBotMessage("Please type something to interact with Luna ");
                    return;
                }

                AddUserMessage(message);

                SaveMessage("USER", message);

                UserInput.Clear();

                string lower =
                    message.ToLower();

                     // SAVE FAVOURITE TOPIC USING "INTERESTED IN"
 if (lower.Contains("interested in"))
 {
     string[] parts =
         lower.Split(new string[] { "interested in" },
         StringSplitOptions.None);

     if (parts.Length > 1)
     {
         favouriteTopic = parts[1].Trim();

         AddBotMessage("Great! I will remember that you are interested in "
             + favouriteTopic);

         return;
     }
 }
                // EXIT COMMAND
                if (lower.Contains("bye") ||
                    lower.Contains("exit") ||
                    lower.Contains("goodbye"))
                {
                    AddBotMessage("Goodbye! Stay safe online ");

                    Application.Current.Shutdown();

                    return;
                }

                // STORE NAME
                if (!nameStored)
                {
                    memory.UserMemory["name"] =message;

                    nameStored = true;

                    await TypingAnimation();

                    AddBotMessage("Nice to meet you "+ message );

                    return;
                }

                await TypingAnimation();

                
                if (lower.Contains("what is my name"))
                {
                    AddBotMessage("Your name is "+ memory.UserMemory["name"]);
                }

                // Emotions
              
                else if (lower.Contains("sad"))
                {
                    AddBotMessage("I'm sorry you're sad. " +
                        GetRandomCyberResponse());
                }

                else if (lower.Contains("happy"))
                {
                    AddBotMessage("That's amazing! " +
                        GetRandomCyberResponse());
                }

                else if (lower.Contains("worried"))
                {
                    AddBotMessage("Do not worry. " +
                        GetRandomCyberResponse());
                }

                else if (lower.Contains("frustrated"))
                {
                    AddBotMessage("I understand this can be frustrating. " +
                        GetRandomCyberResponse());
                }

                else if (lower.Contains("tell me more") ||
                         lower.Contains("another tip") ||
                         lower.Contains("explain more"))
                {
                    HandleFollowUp();


                }

                // KEYWORD DETECTION
                else
                {
                    bool found = false;

                    foreach (var keyword in cyberResponses.Keys)
                    {
                        if (lower.Contains(keyword))
                        {
                            memory.LastTopic = keyword;

                            var responses = cyberResponses[keyword];

                 string randomResponse = responses[random.Next(responses.Count)];
                      if (!string.IsNullOrEmpty(favouriteTopic))
{
    AddBotMessage("Since you are interested in " +
        favouriteTopic + ", " + randomResponse);
}
else
{
    AddBotMessage(randomResponse);
}

                            found = true;

                            break;
                        }
                    }

                    if (!found)
                    {
                        AddBotMessage(" I am still learning about that topic.");
                    }
                }
            }

            catch (Exception ex)
            {
                AddBotMessage(" Error: "+ ex.Message);
            }
        }

        // FOLLOW-UP SYSTEM
        private void HandleFollowUp()
        {
            if (memory.LastTopic != null &&cyberResponses.ContainsKey(memory.LastTopic))
            {
                var responses = cyberResponses[memory.LastTopic];

                string randomResponse =responses[random.Next(responses.Count)];

                AddBotMessage(randomResponse);
            }
            else
            {
                AddBotMessage("Please ask about a topic first ");
            }
        }
        private string GetRandomCyberResponse()
{
    List<string> allResponses =
        new List<string>();

    foreach (var topic in cyberResponses.Values)
    {
        allResponses.AddRange(topic);
    }

    return allResponses[random.Next(allResponses.Count)];
}

        // BOT MESSAGE
        private void AddBotMessage(
            string message)
        {
            StackPanel stack =new StackPanel();

            TextBlock time =new TextBlock()
                {

                Text = DateTime.Now.ToString("HH:mm"),
                    Foreground = Brushes.LightGray,
                    FontSize = 11
                };

            Border border =new Border()
                {

                Background = Brushes.DarkSlateBlue,


                CornerRadius = new CornerRadius(15),


                Padding = new Thickness(12),


                Margin = new Thickness(5),

                    MaxWidth = 420,

                    HorizontalAlignment =HorizontalAlignment.Left
                };

            TextBlock text =
                new TextBlock()
                {
                    Text =
                    "Luna :" + message,

                    Foreground =Brushes.White,

                    FontSize = 16,

                    TextWrapping =TextWrapping.Wrap
                };

            border.Child = text;

            stack.Children.Add(time);
            stack.Children.Add(border);

            ChatPanel.Children.Add(stack);

            SaveMessage("BOT", message);
        }

        // USER MESSAGE
        private void AddUserMessage(string message)
        {
            StackPanel stack =new StackPanel()
                {
                    HorizontalAlignment =HorizontalAlignment.Right
                };

            TextBlock time =
                new TextBlock()
                {
                    Text =DateTime.Now.ToString("HH:mm"),

                    Foreground =Brushes.LightGray,

                    FontSize = 11,

                    HorizontalAlignment =
                    HorizontalAlignment.Right
                };

            Border border =new Border()
                {
                    Background = Brushes.Teal,

                    CornerRadius =new CornerRadius(15),

                    Padding =new Thickness(12),

                    Margin =new Thickness(5),

                    MaxWidth = 420,

                    HorizontalAlignment =HorizontalAlignment.Right
                };

            TextBlock text =
                new TextBlock()
                {
                    Text =
                    "You :" + message,

                    Foreground =
                    Brushes.White,

                    FontSize = 16,

                    TextWrapping =
                    TextWrapping.Wrap
                };

            border.Child = text;

            stack.Children.Add(time);
            stack.Children.Add(border);

            ChatPanel.Children.Add(stack);
        }

        // TYPING EFFECT 
        private async Task TypingAnimation()
        {
            Border typingBorder =new Border()
                {
                    Background =
                    Brushes.Gray,

                    CornerRadius =
                    new CornerRadius(10),

                    Padding =
                    new Thickness(10),

                    Margin =
                    new Thickness(5),

                    HorizontalAlignment =
                    HorizontalAlignment.Left
                };

            TextBlock typingText =new TextBlock()
                {
                    Text = "Luna is Typing...",Foreground = Brushes.White
                };

            typingBorder.Child =typingText;

            ChatPanel.Children.Add(typingBorder);

            await Task.Delay(1200);

            ChatPanel.Children.Remove(typingBorder);
        }

        // SAVE CHAT
        private void SaveMessage(string sender,string message)
        {
            Directory.CreateDirectory("History");

            string line =$"{DateTime.Now} [{sender}] {message}";

            File.AppendAllText(historyFile,line + Environment.NewLine);
        }
    }
}
