using Microsoft.AspNetCore.SignalR;
using System.Web;

namespace ChatServer.Hubs
{
    public class GroupChatHub:Hub<IGroupClient>
    {
        public Task AddGroup(string groupName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
        public Task LeaveGroup(string groupName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
        public Task Send(string groupName, string name, string message)
        {
            return Clients.Group(groupName).MessageToGroup(groupName, HttpUtility.HtmlEncode(name), HttpUtility.HtmlEncode(message));
        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }

    public interface IGroupClient
    {
        Task MessageToGroup(string groupName, string name, string message);
    }
}
