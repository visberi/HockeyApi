﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlayerService.UnitTests.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PlayerService.UnitTests.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name,PlayerNumber,Team,PlayerPosition
        ///Test Person 1,1,Hervannan Häkki,G
        ///Test Person 2,2,Hervannan Häkki,LD
        ///Test Person 3,3,Hervannan Häkki,RD
        ///Test Person 4,4,Hervannan Häkki,LW
        ///Test Person 5,5,Hervannan Häkki,RW
        ///Test Person 6,6,Hervannan Häkki,C
        ///Test Person 7,1,Muotialan Mainio,G
        ///Test Person 8,2,Muotialan Mainio,LD
        ///Test Person 9,3,Muotialan Mainio,RD
        ///Test Person 10,4,Muotialan Mainio,LW
        ///Test Person 11,5,Muotialan Mainio,RW
        ///Test Person 12, 6,Muotialan Mainio,C
        ///Mika Malli, 18, Hervannan Häkki,C
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TestPlayerData {
            get {
                return ResourceManager.GetString("TestPlayerData", resourceCulture);
            }
        }
    }
}
