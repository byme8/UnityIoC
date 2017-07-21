using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoC
{
    public enum Reuse
    {
        Transient,
        Singletone
    }

    public static class ReuseExtentions
    {
        public static DryIoc.IReuse ToInstance(this Reuse reuse)
        {
            switch (reuse)
            {
                case Reuse.Transient:
                    return DryIoc.Reuse.Transient;
                case Reuse.Singletone:
                    return DryIoc.Reuse.Singleton;
            }

            return DryIoc.Reuse.Transient;
        }
    }
}
