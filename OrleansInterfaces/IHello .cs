using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrleansInterfaces;

public interface IHello : IGrainWithIntegerKey
{
    ValueTask<string> SayHello(string greeting);
}