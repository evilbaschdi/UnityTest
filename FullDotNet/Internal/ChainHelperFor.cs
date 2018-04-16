namespace FullDotNet.Internal
{
    /// <inheritdoc />
    public abstract class ChainHelperFor<TIn, TOut> : IChainHelperFor<TIn, TOut>
    {
        /// <summary>
        /// </summary>
        protected TIn Input;

        /// <inheritdoc />
        public IChainHelperFor<TIn, TOut> NextChain { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        protected ChainHelperFor(IChainHelperFor<TIn, TOut> number)
        {
            NextChain = number;
        }


        /// <inheritdoc />
        public abstract bool AmIResponsible { get; }

        /// <inheritdoc />
        public TOut ValueFor(TIn input)
        {
            Input = input;
            return AmIResponsible ? InnerValueFor(input) : NextChain.ValueFor(input);
        }

        /// <summary>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected abstract TOut InnerValueFor(TIn input);
    }

    public interface INumber : IChainHelperForString
    {
    }


    /// <inheritdoc cref="IChainHelperForString" />
    public abstract class ChainHelperForString : ChainHelperFor<string, string>, IChainHelperForString
    {
        protected ChainHelperForString(IChainHelperForString number)
            : base(number)
        {
        }
    }
}