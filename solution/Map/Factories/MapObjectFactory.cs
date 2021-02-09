using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace solution.Map
{
    public interface MapObjectFactory
    {
        public MapObject CreateObject(); 
    }
}
