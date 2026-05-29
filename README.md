# Cyber-Bot-version-2
# 🛡 Luna Cybersecurity Chatbot v2.0

## 📌 Overview

Luna is a cybersecurity awareness chatbot developed in **C# using WPF**.
The chatbot helps users learn about online safety by providing cybersecurity tips, emotional support responses, memory recall, and interactive conversation features.

This project was created for the **PROG6221 Programming Assignment**.

---

# ✨ Features

## ✅ Cybersecurity Awareness

The chatbot provides information and tips about:

* Password safety
* Phishing attacks
* Online scams
* Privacy protection
* Safe browsing
* Malware
* VPNs
* Antivirus software
* Ransomware
* Hacking prevention

---

# 🧠 Memory and Recall

Luna can:

* Remember the user’s name
* Remember the user’s favourite cybersecurity topic
* Personalise responses using stored memory

Example:

```text
I am interested in malware
```

The chatbot remembers this topic and later responds with:

```text
Since you are interested in malware...
```

---

# 😊 Sentiment Detection

The chatbot detects emotions such as:

* Happy
* Sad
* Worried
* Frustrated

It responds with supportive messages combined with cybersecurity advice.

Example:

```text
Do not worry. Use antivirus software.
```

---

# 💬 Follow-Up Conversations

Luna supports follow-up questions such as:

* Tell me more
* Another tip
* Explain more

The chatbot remembers the last topic discussed and continues the conversation naturally.

---

# 🎲 Randomized Responses

Responses are randomly selected from stored cybersecurity tips using:

* Dictionaries
* Lists
* Random class

This makes conversations more dynamic and less repetitive.

---

# 🖥 GUI Features

The application includes:

* WPF graphical interface
* Chat bubbles
* Typing animation
* Dynamic background colours
* Timestamps
* Voice greeting

---

# 💾 Chat History

All chat conversations are saved automatically in:

```text
History/chat_history.txt
```

---

# 🚪 Exit Command

Users can exit the chatbot using:

```text
bye
exit
goodbye
```

---

# ⚠ Exception Handling

The application uses try-catch blocks to prevent crashes and improve stability.

---

# 🛠 Technologies Used

* C#
* WPF
* .NET
* Dictionaries
* Lists
* File Handling
* SoundPlayer
* Async/Await

---

# 📂 Project Structure

```text
WpfApp1
│
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── ChatMemory.cs
├── voice1.wav
├── History/
│   └── chat_history.txt
```

---

# ▶ How to Run

1. Open the project in Visual Studio
2. Build the solution
3. Run the application
4. Interact with Luna through the chat interface

---

# 📈 Version History

## Version 1.0

* Basic cybersecurity chatbot
* GUI interface
* Random responses

## Version 1.5

* Sentiment detection
* Favourite topic memory
* Follow-up conversation handling
* Personalised responses
* More cybersecurity topics
* Exit command
* Improved interaction flow

---

# 👨‍💻 Developer

Developed by THUTO for the PROG6221 Programming Assignment.

---

# 📜 License

This project is for educational purposes.
