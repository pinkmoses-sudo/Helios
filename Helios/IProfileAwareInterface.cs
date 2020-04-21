﻿using System;
using System.Collections.Generic;

namespace GadrocsWorkshop.Helios
{
    namespace ProfileAwareInterface
    {
        public class ProfileHint : EventArgs
        {
            public string Tag { get; set; }
        }

        public class DriverStatus : EventArgs
        {
            public string ExportDriver { get; set; }
        }

        public class ClientChange: EventArgs
        {
            /// <summary>
            /// the only handle value which we may interpret, all other values are opaque
            /// </summary>
            public static string NO_CLIENT = "";
            public string FromOpaqueHandle { get; set; }
            public string ToOpaqueHandle { get; set; }
        }

        /// <summary>
        /// Interface instances that support this interface are loosely aware of the existence
        /// of profiles.  They may receive information that helps select a profile and they
        /// may also make their containing profile appropriate for selection or not.
        /// Finally, they are aware that profiles may require certain drivers to be loaded.
        /// </summary>
        public interface IProfileAwareInterface
        {
            /// <summary>
            /// Fired to indicate the interface is providing information related
            /// to the specified export driver name.  This name is not necessarily the 
            /// same as the HeliosProfile.Name
            ///
            /// This event can be fired with or without a previous RequestDriver call.
            /// </summary>
            event EventHandler<ProfileAwareInterface.DriverStatus> DriverStatusReceived;

            /// <summary>
            /// Fired to indicate the interface would like a profile with a tag matching
            /// the hint received.
            /// </summary>
            event EventHandler<ProfileAwareInterface.ProfileHint> ProfileHintReceived;

            /// <summary>
            /// Fired to indicate that the interface may no longer be connected to the same
            /// endpoint as before.
            /// </summary>
            event EventHandler<ProfileAwareInterface.ClientChange> ClientChanged;
            
            /// <summary>
            /// Tags that can be used to match a profile containing this interface to a future
            /// profile hint.  
            /// </summary>
            IEnumerable<string> Tags { get; }

            /// <summary>
            /// Request that the interface provide the information for the specified driver name,
            /// and send a DriverStatus event when this is accomplished.
            /// </summary>
            /// <param name="name"></param>
            void RequestDriver(string name);
        }
    }
}
