namespace kaizala.Services
{
    using Microsoft.Kaizala;
    using Microsoft.Kaizala.Models;
    using Microsoft.Kaizala.Util;
    using Newtonsoft.Json;
    using System.Collections.Specialized;
    using System.Threading.Tasks;

    class GroupManagementAPIStubImpl : IGroupManagementAPIStub
    {
        private IKaizalaSession Session;
        public GroupManagementAPIStubImpl(IKaizalaSession session)
        {
            this.Session = session;
        }
        public async Task<CreateGroupResponse> CreateGroup(CreateGroupRequest createGroupRequest)
        {
            NameValueCollection header = new NameValueCollection();
            header.Add(Constants.ACCESS_TOKEN_STRING, this.Session.GetAccessToken());
            string request = JsonConvert.SerializeObject(createGroupRequest);
            CreateGroupResponse response = await APICallHandler.PostAsync<CreateGroupResponse>(header, string.Format(Constants.CREATE_GROUP_URL, Constants.API_ROOT), request);
            return await Task.FromResult(response);
        }
    }
}
