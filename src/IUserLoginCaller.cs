using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta
{
    public interface IUserLoginCaller
    {
        void SetUserAccess(FaceIDUser user);
    }
}
