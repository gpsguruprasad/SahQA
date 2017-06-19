using System;
using Microsoft.Practices.Unity;

namespace QA.Base.Handlers
{
    public sealed class UnityHandler
    {
        private static readonly Lazy<UnityContainer> Lazy = new Lazy<UnityContainer>(() => new UnityContainer());

        public static UnityContainer Instance => Lazy.Value;

        private UnityHandler()
        {
        }
    }
}
