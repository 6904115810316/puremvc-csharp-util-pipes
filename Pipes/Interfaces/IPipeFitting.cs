﻿//
//  PureMVC C# Multicore Utility - Pipes
//
//  Copyright(c) 2017-2027 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace Pipes.Interfaces
{
    /// <summary>
    /// Pipe Fitting Interface.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         An `IPipeFitting` can be connected to other
    ///         `IPipeFittings`, forming a Pipeline.
    ///         `IPipeMessages` are written to one end of a
    ///         Pipeline by some client code. The messages are then
    ///         transfered in synchronous fashion from one fitting to the next.
    ///     </para>
    /// </remarks>
    public interface IPipeFitting
    {
        /// <summary>
        /// Connect another Pipe Fitting to the output.
        /// other fittings in a one way syncrhonous 
        /// chain, as water typically flows one direction 
        /// through a physical pipe.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Fittings connect and write to
        ///     </para>
        /// </remarks>
        /// <param name="output"></param>
        /// <returns>Boolean true if no other fitting was already connected.</returns>
        bool Connect(IPipeFitting output);

        /// <summary>
        /// Disconnect the Pipe Fitting connected to the output.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         This disconnects the output fitting, returning a
        ///         reference to it. If you were splicing another fitting 
        ///         into a pipeline, you need to keep (at least briefly) 
        ///         a reference to both sides of the pipeline in order to 
        ///         connect them to the input and output of whatever 
        ///         fiting that you're splicing in.
        ///     </para>
        /// </remarks>
        /// <returns>IPipeFitting the now disconnected output fitting</returns>
        IPipeFitting Disconnect();

        /// <summary>
        /// Write the message to the output Pipe Fitting.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         There may be subsequent filters and tees 
        ///         (which also implement this interface), that the 
        ///         fitting is writing to, and so a message 
        ///         may branch and arrive in different forms at 
        ///         different endpoints.
        ///     </para>
        ///     <para>
        ///         If any fitting in the chain returns false 
        ///         from this method, then the client who originally 
        ///         wrote into the pipe can take action, such as 
        ///         rolling back changes.
        ///     </para>
        /// </remarks>
        /// <param name="message">message to write</param>
        /// <returns>Boolean true if write was successful</returns>
        bool Write(IPipeMessage message);
    }
}
