using System;
using Unity;
using Unity.Injection;

namespace UnityTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new UnityContainer();

            container.RegisterType<IChainHelperFor<string, string>, One>("One");
            container.RegisterType<IChainHelperFor<string, string>, Two>("Two", new InjectionConstructor(new ResolvedParameter<IChainHelperFor<string, string>>("One")));
            container.RegisterType<IDemoInterface, DemoClass>();
            var returnClass = container.Resolve<ReturnClass>();
            Console.WriteLine(returnClass.Value);

            Console.WriteLine("...");
            Console.ReadLine();
        }

        public interface IDemoInterface
        {
            string Value { get; }
        }

        public class DemoClass : IDemoInterface
        {
            public string Value => "Das ist ein Demowert";
        }

        public class ReturnClass
        {
            private readonly IChainHelperFor<string, string> _chainHelperFor;
            private readonly IDemoInterface _demoInterface;

            public ReturnClass(IDemoInterface demoInterface, IChainHelperFor<string, string> chainHelperFor)
            {
                _demoInterface = demoInterface ?? throw new ArgumentNullException(nameof(demoInterface));
                _chainHelperFor = chainHelperFor ?? throw new ArgumentNullException(nameof(chainHelperFor));
            }

            public string Value => _demoInterface.Value + ": " + _chainHelperFor.ValueFor("One");
        }
    }

    public class One : ChainHelperFor<string, string>
    {
        public One(IChainHelperFor<string, string> chainHelperFor)
            : base(chainHelperFor)
        {
        }

        public override bool AmIResponsible => Input.Equals("One");


        protected override string InnerValueFor(string input)
        {
            return "1";
        }
    }

    public class Two : ChainHelperFor<string, string>
    {
        public Two(IChainHelperFor<string, string> chainHelperFor)
            : base(chainHelperFor)
        {
        }

        public override bool AmIResponsible => Input.Equals("Two");

        protected override string InnerValueFor(string input)
        {
            return "2";
        }
    }
}