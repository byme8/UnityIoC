using DryIoc;

namespace IoC
{
    public class Dependency<TValue>
        where TValue : class
    {
        private TValue value;

        public TValue Value
        {
            get
            {
                return this.value ?? (this.value = UnityIoC.Container.Resolve<TValue>());
            }
        }
    }
}