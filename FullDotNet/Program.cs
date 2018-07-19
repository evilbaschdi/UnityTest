using System;
using FullDotNet.Internal;
using Unity;
using Unity.Injection;

namespace FullDotNet
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IUnityContainer compositionRoot = CompositionRoot();
            IReturn returnClass = compositionRoot.Resolve<IReturn>();

            //IDemoInterface demoInterface = new DemoClass();
            //INumber chainHelperForStringOne = new One(null);
            //INumber chainHelperForStringTwo = new Two(chainHelperForStringOne);
            //IReturn returnClass = new Return(demoInterface, chainHelperForStringTwo);

            Console.WriteLine(returnClass.Value);

            Console.WriteLine("...");
            Console.ReadLine();
        }

        private static IUnityContainer CompositionRoot()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IDemoInterface, DemoClass>();
            container.RegisterType<INumber, One>("One");
            container.RegisterType<INumber, Two>("Two", new InjectionConstructor(new ResolvedParameter<INumber>("One")));
            container.RegisterType<IReturn, Return>("Return", new InjectionConstructor(new ResolvedParameter<IDemoInterface>(), new ResolvedParameter<INumber>("Two")));
            return container;
        }
    }
}