# WhatsApp Message Bot

A C# console application that simulates automated message injection into WhatsApp Web using low-level keyboard input. Inspired by hacker-style terminals and designed primarily for harmless pranks.

## 💻 Features

* Hacker-style console animation (letter-by-letter typing)
* Custom message input
* Custom repeat count
* Sends messages to currently focused window (ideal for WhatsApp Web)
* No dependencies on Windows Forms or external libraries

## 🚀 How It Works

This application mimics keystrokes using `user32.dll` to type messages into any focused input field. After taking user input, it gives you 5 seconds to focus the target window (e.g., WhatsApp Web), then starts typing the message repeatedly.

## 🛠️ Requirements

* Windows OS
* .NET 8 SDK or higher
* Visual Studio Code or any C# compatible IDE

## ⚙️ Build & Run

```bash
# Clone the repo
git clone https://github.com/mehmeteyupkatirci/WhatsAppMessageBot.git
cd WhatsAppMessageBot

# Build the project
dotnet build

# Run the app
dotnet run --project WhatsAppMessageBot
```

## 📦 Publish to EXE

To create a standalone executable:

```bash
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
```

The output `.exe` will be in `bin\Release\net8.0\win-x64\publish`

## 🔒 Disclaimer

This project is for educational and entertainment purposes only. Do not use it to spam or harass others. Be respectful — it's meant to make people laugh, not get blocked. 😉

## 📷 Preview

```
>>> Initializing sequence...
>>> Establishing connection to target channel...
>>> Preparing payload structure...
>>> SYSTEM ONLINE
>>> Enter payload text: selam
>>> Define injection count: 31
>>> TARGET LOCK: You have 5 seconds to focus the target window (e.g. WhatsApp Web)
>>> Injected [1/31] : "selam"
...
>>> Injection sequence complete. System idle.
```

## 🤝 Contributions

Pull requests are welcome! If you want to improve the UX or add features like random emoji injection or more realistic typing, feel free to contribute.

---

Made with ☕ and a bit of mischief by @mehmeteyupkatirci
