﻿namespace FullDotNet.Internal
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public interface IChainHelperFor<in TIn, out TOut>
    {
        /// <summary>
        /// </summary>
        IChainHelperFor<TIn, TOut> NextChain { get; }

        /// <summary>
        /// </summary>
        bool AmIResponsible { get; }

        /// <summary>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        TOut ValueFor(TIn input);
    }


  
}