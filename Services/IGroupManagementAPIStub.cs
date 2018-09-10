namespace Microsoft.Kaizala
{
    using Microsoft.Kaizala.Models;
    using System.Threading.Tasks;

    public interface IGroupManagementAPIStub
    {
        Task<CreateGroupResponse> CreateGroup(CreateGroupRequest createGroupRequest);
    }
}
