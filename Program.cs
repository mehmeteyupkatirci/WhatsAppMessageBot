﻿using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    [DllImport("user32.dll")]
    static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

    [DllImport("user32.dll")]
    static extern short VkKeyScan(char ch);

    const int KEYEVENTF_KEYUP = 0x0002;

    static void Main()
    {
        #region HackerAesthetics
        //Bu kısımda olan satırlar tamamen işlevsiz. Sadece havalı gözüküyo
        
        Console.Title = "Terminal v1.4 | Automated Message Injector";
        Console.ForegroundColor = ConsoleColor.Green;

        Thread.Sleep(500);
        PrintLetterByLetter(">>> Initializing sequence...\n", 20);

        Thread.Sleep(500);
        PrintLetterByLetter(">>> Establishing connection to target channel...\n", 20);

        Thread.Sleep(500);
        PrintLetterByLetter(">>> Preparing payload structure...\n", 20);
        #endregion

        Console.Write(">>> Enter payload text: ");
        string inputText = Console.ReadLine();

        Console.Write(">>> Define injection count: ");
        if (!int.TryParse(Console.ReadLine(), out int repeatCount) || repeatCount < 1)
        {
            Console.WriteLine("\n>>> ERROR: Invalid injection count.");
            return;
        }

        //Yazdırmak istediğin ekrana tıklamak için 5 saniyen var.
        Console.WriteLine("\n>>> TARGET LOCK: You have 5 seconds to focus the target window (e.g. WhatsApp Web)");
        Thread.Sleep(5000);

        for (int i = 0; i < repeatCount; i++)
        {
            SendString(inputText);
            SendEnter();

            Console.WriteLine($">>> Injected [{i + 1}/{repeatCount}] : \"{inputText}\"");
            Thread.Sleep(200);
        }

        Console.WriteLine("\n>>> Injection sequence complete. System idle.");
        Console.ReadLine();
    }

    static void SendChar(char c)
    {
        short vk = VkKeyScan(c);
        byte vkCode = (byte)(vk & 0xff);

        keybd_event(vkCode, 0, 0, 0);
        Thread.Sleep(10);
        keybd_event(vkCode, 0, KEYEVENTF_KEYUP, 0);
    }

    static void SendString(string text)
    {
        foreach (char c in text)
        {
            SendChar(c);
            Thread.Sleep(10); // Harfler arasında kısa bir gecikme
        }
    }

    static void SendEnter()
    {
        const byte VK_RETURN = 0x0D;
        keybd_event(VK_RETURN, 0, 0, 0);
        Thread.Sleep(10);
        keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, 0);
    }

    static void PrintLetterByLetter(string text, int delay = 20)
    {
        //Hacker konsolu gibi gözükmesi için harfleri tek tek yazdırma işlemi. (Gereksiz sadece havalı)
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay);  
        }
    }

}
