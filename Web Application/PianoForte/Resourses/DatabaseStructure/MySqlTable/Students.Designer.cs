﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PianoForte.Resourses.DatabaseStructure.MySqlTable {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Students {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Students() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PianoForte.Resourses.DatabaseStructure.MySqlTable.Students", typeof(Students).Assembly);
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
        ///   Looks up a localized string similar to birthday.
        /// </summary>
        internal static string ColumnBirthday {
            get {
                return ResourceManager.GetString("ColumnBirthday", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to firstname.
        /// </summary>
        internal static string ColumnFirstname {
            get {
                return ResourceManager.GetString("ColumnFirstname", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to lastname.
        /// </summary>
        internal static string ColumnLastname {
            get {
                return ResourceManager.GetString("ColumnLastname", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to nickname.
        /// </summary>
        internal static string ColumnNickname {
            get {
                return ResourceManager.GetString("ColumnNickname", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to registered_date.
        /// </summary>
        internal static string ColumnRegisteredDate {
            get {
                return ResourceManager.GetString("ColumnRegisteredDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to student_id.
        /// </summary>
        internal static string ColumnStudentId {
            get {
                return ResourceManager.GetString("ColumnStudentId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to student_status.
        /// </summary>
        internal static string ColumnStudentStatus {
            get {
                return ResourceManager.GetString("ColumnStudentStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to students.
        /// </summary>
        internal static string TableName {
            get {
                return ResourceManager.GetString("TableName", resourceCulture);
            }
        }
    }
}