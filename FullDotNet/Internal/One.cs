namespace FullDotNet.Internal
{
    public class One : ChainHelperForString, INumber
    {
        public One(INumber number)
            : base(number)
        {
        }

        public override bool AmIResponsible => Input.Equals("One");


        protected override string InnerValueFor(string input)
        {
            return "1";
        }
    }
}