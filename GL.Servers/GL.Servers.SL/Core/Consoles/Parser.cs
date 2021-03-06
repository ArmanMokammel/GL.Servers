﻿namespace GL.Servers.SL.Core.Consoles
{
    using System;
    using System.Linq;
    using System.Threading;

    using GL.Servers.SL.Core;
    using GL.Servers.SL.Core.Events;
    using GL.Servers.SL.Logic;

    using GL.Servers.Extensions;
    using GL.Servers.SL.Core.Network;
    using GL.Servers.SL.Logic.Avatar;
    using GL.Servers.SL.Packets.Messages.Server;

    internal class Parser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class.
        /// </summary>
        internal static void Initialize()
        {
            new Thread(() =>
            {
                while (true)
                {
                    int CursorTop2 = Console.CursorTop = Console.WindowTop + Console.WindowHeight - 1;
                    Console.Write("root@localhost > ");

                    string Command = Console.ReadLine();

                    Console.SetCursorPosition(0, CursorTop2 - 1);
                    Console.WriteLine(new string(' ', Console.BufferWidth));
                    Console.SetCursorPosition(0, CursorTop2 - 2);

                    switch (Command)
                    {
                        case "/stats":
                        {
                            if (Resources.Started)
                            {
                                Console.WriteLine();
                                Console.WriteLine("# " + DateTime.Now.ToString("d") + " ---- STATS ---- " + DateTime.Now.ToString("T") + " #");
                                Console.WriteLine("# ----------------------------------- #");
                                Console.WriteLine("# In-Memory Players # " + ConsolePad.Padding(Resources.Players.Count.ToString(), 15) + " #");
                                Console.WriteLine("# In-Memory Clans   # " + ConsolePad.Padding(Resources.Clans.Count.ToString(), 15) + " #");
                                // Console.WriteLine("# In-Memory Battles # " + ConsolePad.Padding(Resources.Battles.Count + " - " + Resources.Battles.Waiting.Count, 15) + " #");
                                Console.WriteLine("# In-Memory Saea    # " + ConsolePad.Padding(Resources.TCPGateway.ReadPool.Pool.Count + " - " + Resources.TCPGateway.WritePool.Pool.Count, 15) + " #");
                                Console.WriteLine("# ----------------------------------- #");
                            }

                            break;
                        }

                        case "/test":
                        {
                            if (Resources.Started)
                            {
                                foreach (Player Player in Resources.Players.Values.ToList())
                                {
                                    new Own_Avatar_Data(Player.Device).Send();
                                }
                            }

                            break;
                        }

                        case "/clear":
                        {
                            Console.Clear();
                            break;
                        }

                        case "/exit":
                        case "/shutdown":
                        case "/stop":
                        {
                            EventsHandler.Process();
                            break;
                        }

                        default:
                        {
                            Console.WriteLine();
                            break;
                        }
                    }
                }
            }).Start();
        }
    }
}