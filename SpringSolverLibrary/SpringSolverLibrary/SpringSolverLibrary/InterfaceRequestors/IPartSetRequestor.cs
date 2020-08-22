using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringSolverLibrary.InterfaceRequestors
{
    public interface IPartSetRequestor
    {
        void NewPartSetCreated(PartSetModel model);
    }
}
