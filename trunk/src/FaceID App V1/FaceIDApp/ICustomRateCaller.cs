using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta
{
    public interface ICustomRateCaller
    {
        void ImplementNewRate(Rate newRate);
    }
}