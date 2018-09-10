namespace Microsoft.Kaizala.Services
{
    using Microsoft.Kaizala.Exceptions;
    using Microsoft.Kaizala.Models;
    using Microsoft.Kaizala.Util;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    /// <summary>
    /// Implements the ContentCreationAPiStub to call content creation API
    /// </summary>
    public class ContentCreationAPIStubImpl : IContentCreationAPIStub
    {
        /// <summary>
        /// Get and set Kaizala Session
        /// </summary>
        private IKaizalaSession Session;

        /// <summary>
        /// Initializes a new instance of ContentCreationAPIStubImpl
        /// </summary>
        /// <param name="session">Kaizala Session instance</param>
        public ContentCreationAPIStubImpl(IKaizalaSession session)
        {
            this.Session = session;
        }

        /// <summary>
        /// Send messages in a group
        /// </summary>
        /// <param name="groupId">The Group Id</param>
        /// <param name="sendMessageRequest">The SendMessageRequest object</param>
        /// <returns>The SendMessageResponse object</returns>
        public List<SendMessageResponse> SendMessage(string groupId, SendMessageRq sendMessageRequest)
        {
            List<string> senderSubsList = null;
            List<string> allSubsNumbers = sendMessageRequest.Subscribers;
            List<SendMessageResponse> allResponses = new List<SendMessageResponse>();
            string request;
            if (sendMessageRequest.Subscribers == null || sendMessageRequest.Subscribers.Count == 0)
            {
                request = JsonConvert.SerializeObject(sendMessageRequest);
                SendMessageResponse response = SendSingleMessage(groupId, request);
                allResponses.Add(response);
            }
            else
            {
                for (int i = 0; i <= allSubsNumbers.Count / Constants.MAX_SUBSCRIBER_COUNT; i++)
                {
                    senderSubsList = allSubsNumbers.GetRange(Constants.MAX_SUBSCRIBER_COUNT * i, i == allSubsNumbers.Count / Constants.MAX_SUBSCRIBER_COUNT ? allSubsNumbers.Count - Constants.MAX_SUBSCRIBER_COUNT * i : Constants.MAX_SUBSCRIBER_COUNT);
                    sendMessageRequest.Subscribers = senderSubsList;
                    request = JsonConvert.SerializeObject(sendMessageRequest);
                    SendMessageResponse response = SendSingleMessage(groupId, request);
                    allResponses.Add(response);
                }
            }
            return allResponses;
        }

        private SendMessageResponse SendSingleMessage(string groupId, string request)
        {
            NameValueCollection header = new NameValueCollection
            {
                { Constants.ACCESS_TOKEN_STRING, this.Session.GetAccessToken() }
            };

            SendMessageResponse response = AsyncHelpers.RunSync<SendMessageResponse>(() => APICallHandler.PostAsync<SendMessageResponse>(header, string.Format(Constants.SEND_MESSAGE_IN_GROUP_URL, Session.GetApiEndPoint(), groupId), request));
            if (!ErrorValidator.IsResponseValid(response) && ErrorValidator.IsAccessTokenExpired(response))
            {
                header.Remove(Constants.ACCESS_TOKEN_STRING);
                header.Add(Constants.ACCESS_TOKEN_STRING, Session.GenerateAccessToken());
                response = AsyncHelpers.RunSync<SendMessageResponse>(() => APICallHandler.PostAsync<SendMessageResponse>(header, string.Format(Constants.SEND_MESSAGE_IN_GROUP_URL, Constants.API_ROOT, groupId), request));
            }
            return response;
        }

        /// <summary>
        /// Sending group of messages in a group
        /// </summary>
        /// <param name="groupId">The GroupId</param>
        /// <param name="sendMessageRequests">List of sendMessageRequests</param>
        /// <returns>List of SendMessageResponse</returns>
        public List<SendMessageResponse> SendBulkMessageInSameGroup(string groupId, List<SendMessageRq> sendMessageRequests)
        {
            List<SendMessageResponse> responseList = new List<SendMessageResponse>();
            foreach(SendMessageRq request in sendMessageRequests) {
                responseList.AddRange(this.SendMessage(groupId, request));
            }

            return responseList;
        }

        /// <summary>
        /// Sending actions in a group
        /// </summary>
        /// <param name="groupId">The GroupId</param>
        /// <param name="sendActionRequest">The SendActionRequest</param>
        /// <returns>SendActionResponse</returns>
        public List<SendActionResponse> SendAction(string groupId, SendActionRequest sendActionRequest)
        {
            List<string> senderSubsList = null;
            List<string> allSubsNumbers = sendActionRequest.Subscribers;
            List<SendActionResponse> allResponses = new List<SendActionResponse>();
            string request;
            if (sendActionRequest.Subscribers == null || sendActionRequest.Subscribers.Count == 0)
            {
                request = JsonConvert.SerializeObject(sendActionRequest);
                SendActionResponse response = SendSingleAction(groupId, request);
                allResponses.Add(response);
            } else
            {
                for (int i = 0; i <= allSubsNumbers.Count / Constants.MAX_SUBSCRIBER_COUNT; i++)
                {
                    senderSubsList = allSubsNumbers.GetRange(Constants.MAX_SUBSCRIBER_COUNT * i, i == allSubsNumbers.Count / Constants.MAX_SUBSCRIBER_COUNT ? allSubsNumbers.Count - Constants.MAX_SUBSCRIBER_COUNT * i : Constants.MAX_SUBSCRIBER_COUNT);
                    sendActionRequest.Subscribers = senderSubsList;
                    request = JsonConvert.SerializeObject(sendActionRequest);
                    SendActionResponse response = SendSingleAction(groupId, request);
                    allResponses.Add(response);
                }
            }

            return allResponses;
        }

        private SendActionResponse SendSingleAction(string groupId, string request)
        {
            NameValueCollection header = new NameValueCollection
            {
                { Constants.ACCESS_TOKEN_STRING, this.Session.GetAccessToken() }
            };

            SendActionResponse response = AsyncHelpers.RunSync<SendActionResponse>(() => APICallHandler.PostAsync<SendActionResponse>(header, string.Format(Constants.SEND_ACTION_IN_GROUP_URL, Session.GetApiEndPoint(), groupId), request));
            if (!ErrorValidator.IsResponseValid(response) && ErrorValidator.IsAccessTokenExpired(response))
            {
                header.Remove(Constants.ACCESS_TOKEN_STRING);
                header.Add(Constants.ACCESS_TOKEN_STRING, Session.GenerateAccessToken());
                response = AsyncHelpers.RunSync<SendActionResponse>(() => APICallHandler.PostAsync<SendActionResponse>(header, string.Format(Constants.SEND_ACTION_IN_GROUP_URL, Session.GetApiEndPoint(), groupId), request));
            }
            return response;
        }


    }
}
