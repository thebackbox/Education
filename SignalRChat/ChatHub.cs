﻿using Microsoft.AspNet.SignalR;

namespace SignalRChat {
    public class ChatHub : Hub {
        public void Send(string name, string message) {
            Clients.All.broadcastMessage(name, message);
        }
    }
}