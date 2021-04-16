using System;

namespace XGamingRuntime
{
    public enum XblErrorCondition : UInt32
    {
        /// <summary>
        /// No error.
        /// </summary>
        NoError = 0,

        /// <summary>
        /// A generic error condition.
        /// </summary>
        GenericError,

        /// <summary>
        /// An error condition related to an object being out of range.
        /// </summary>
        GenericOutOfRange,

        /// <summary>
        /// An error condition related to attempting to authenticate.
        /// </summary>
        Auth,

        /// <summary>
        /// An error condition related to network connectivity.
        /// </summary>
        Network,

        /// <summary>
        /// An error condition related to an HTTP method call.
        /// </summary>
        HttpGeneric,

        /// <summary>
        /// The requested resource was not modified.
        /// </summary>
        Http304NotModified,

        /// <summary>
        /// The requested resource was not found.
        /// </summary>
        Http404NotFound,

        /// <summary>
        /// The precondition given in one or more of the request-header fields evaluated
        /// to false when it was tested on the server.
        /// </summary>
        Http412PreconditionFailed,

        /// <summary>
        /// Client is sending too many requests
        /// </summary>
        Http429TooManyRequests,

        /// <summary>
        /// The service timed out while attempting to process the request.
        /// </summary>
        HttpServiceTimeout,

        /// <summary>
        /// An error related to real time activity.
        /// </summary>
        Rta
    }
}
