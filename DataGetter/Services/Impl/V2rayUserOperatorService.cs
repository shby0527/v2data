using System;
using System.Collections.Generic;
using System.Text;
using V2Ray.Core.App.Proxyman.Command;
using V2Ray.Core.Common.Serial;
using V2RayProto.Utils;

namespace DataGetter.Services.Impl
{
    public class V2rayUserOperatorService : IUserOperatorService
    {
        private HandlerService.HandlerServiceClient _client;

        public V2rayUserOperatorService(HandlerService.HandlerServiceClient client)
        {
            this._client = client;
        }

        public bool InitUsers()
        {
            AddUserOperation addUser = new AddUserOperation();
            addUser.User = new V2Ray.Core.Common.Protocol.User();
            V2Ray.Core.Proxy.Vmess.Account account = new V2Ray.Core.Proxy.Vmess.Account();
            addUser.User.Account = SearisUtils.ToTypedMessage(account);
            AlterInboundRequest request = new AlterInboundRequest();
            request.Operation = SearisUtils.ToTypedMessage(addUser);
            throw new NotImplementedException();
        }
    }
}
