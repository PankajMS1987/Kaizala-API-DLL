using Microsoft.Kaizala.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Kaizala.Services
{
    public interface IContentCreationAPIStub
    {
        List<SendMessageResponse> SendMessage(string groupId, SendMessageRq sendMessageRequest);
        List<SendMessageResponse> SendBulkMessageInSameGroup(string groupId, List<SendMessageRq> sendMessageRequests);
        List<SendActionResponse> SendAction(string groupId, SendActionRequest sendActionRequest);
    }
}
