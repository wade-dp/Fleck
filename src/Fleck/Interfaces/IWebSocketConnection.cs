﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace Fleck
{
    public interface IWebSocketConnection
    {
        Action OnOpen { get; set; }
        Action OnClose { get; set; }
        Action<string> OnMessage { get; set; }
        Action<byte[]> OnBinary { get; set; }
        Action<byte[]> OnPing { get; set; }
        Action<byte[]> OnPong { get; set; }
        Action<Exception> OnError { get; set; }
        Task Send(string message);
        Task Send(byte[] message);
        void SyncSend(byte[] message);
        void SyncSend(string message);
        Stream GetStream();
        Task SendPing(byte[] message);
        Task SendPong(byte[] message);
        void Close();
        void Close(int code);
        IWebSocketConnectionInfo ConnectionInfo { get; }
        bool IsAvailable { get; }
    }
}
