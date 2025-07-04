using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryEcommerceSystem
{
    public interface IShippable
    {
        string GetName();
        double GetWeight();
        // واجهة للمنتجات القابلة للشحن

    }
}
