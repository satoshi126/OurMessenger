using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPChat.Server
{
    internal class Program
    {
        static TcpListener listener = new(IPAddress.Any, 5050);
        static List<ConnectedClient> clients = new();
        static void Main(string[] args)
        {
            listener.Start();

            Console.WriteLine(listener.LocalEndpoint);
            while (true)
            {
                var client = listener.AcceptTcpClient();

                Task.Factory.StartNew(() =>
                {
                    var sr = new StreamReader(client.GetStream());
                    while (client.Connected)
                    {
                        var line = sr.ReadLine();
                        var nick = line.Replace("Login: ", "");

                        if (line.Contains("Login: ") && !string.IsNullOrWhiteSpace(nick))
                        {
                            if (clients.FirstOrDefault(s => s.Name == nick) is null)
                            {
                                clients.Add(new ConnectedClient(client, nick));
                                Console.WriteLine($"Новое подключение: {nick}");
                                break;
                            }
                            else
                            {
                                var sw = new StreamWriter(client.GetStream());
                                sw.AutoFlush = true;
                                sw.WriteLine("Пользователь с таким ником уже есть");
                                client.Client.Disconnect(false);
                            }
                        }
                    }

                    while (client.Connected)
                    {
                        try
                        {
                            var line = sr.ReadLine();

                            StringBuilder sb = new StringBuilder();
                            int c = 0;
                            while (true)
                            {
                                if (line[c] == ':')
                                    break;
                                sb.Append(line[c]);
                                c++;
                            }
                            c++;
                            line = line.Remove(0, c);

                            var target = sb.ToString();
                            if (clients.FirstOrDefault(s => s.Name == target) is not null)
                            {
                                SendToClient(line, target);
                                Console.WriteLine($"{target} <= " + line);
                            }
                            else
                            {
                                var sw = new StreamWriter(client.GetStream());
                                sw.AutoFlush = true;
                                sw.WriteLine("Пользователя не сущестыует или нет в сети!");
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                });
            }
        }

        private static void SendToClient(string message, string nick)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    try
                    {
                        if (clients[i].Client.Connected)
                        {
                            if (clients[i].Name == nick)
                            {
                                var sw = new StreamWriter(clients[i].Client.GetStream());
                                sw.AutoFlush = true;
                                sw.WriteLine(message);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{clients[i].Name} отключился");
                            clients.RemoveAt(i);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            });
        }
    }
}
