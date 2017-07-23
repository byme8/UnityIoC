using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoC
{
    /// <summary>
    /// The kinds of reusing instances.
    /// </summary>
    public enum Reuse
    {
        Transient,
        Singletone
    }

    /// <summary>
    /// Provides extentions methods for <see cref="Reuse"/>.
    /// </summary>
    public static class ReuseExtentions
    {
        /// <summary>
        /// Casts the <see cref="Reuse"/> to instance of <see cref="IReuse"/>.
        /// </summary>
        /// <param name="reuse">The kind.</param>
        /// <returns>The instance of reusing.</returns>
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
