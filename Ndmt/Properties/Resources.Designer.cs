﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18052
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ndmt.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]///....可能这个生成代码
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Ndmt.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
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
        ///   查找 System.Drawing.Bitmap 类型的本地化资源。
        /// </summary>
        internal static System.Drawing.Bitmap _JC5offline {
            get {
                object obj = ResourceManager.GetObject("_JC5offline", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   查找 System.Drawing.Bitmap 类型的本地化资源。
        /// </summary>
        internal static System.Drawing.Bitmap _JC5online {
            get {
                object obj = ResourceManager.GetObject("_JC5online", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   查找类似 &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;resources&gt;
        ///  &lt;Debug&gt;
        ///    &lt;string name =&quot;BindDeviceDatasourceFromObject&quot;&gt;设备数据源绑定完成&lt;/string&gt;
        ///    &lt;string name =&quot;CreateDeviceShortcutWithKnitterEntityBond&quot;&gt;创建设备快捷方式&lt;/string&gt;
        ///    &lt;string name =&quot;CreateShiftIndexGroupedByFriendlyName&quot;&gt;创建订单索引&lt;/string&gt;
        ///    &lt;string name =&quot;BindConsoleToLogDatasource&quot;&gt;绑定日志到rtbConsole控件&lt;/string&gt;
        ///    &lt;string name =&quot;StartLog4NetListening&quot;&gt;开启日志监听&lt;/string&gt;
        ///    &lt;string name =&quot;RemoveDeviceShortcutFromUI&quot;&gt;设备号: {0} 快捷方式从界面删除&lt;/string&gt;
        ///    &lt;strin [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string LogInfo {
            get {
                return ResourceManager.GetString("LogInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找 System.Byte[] 类型的本地化资源。
        /// </summary>
        internal static byte[] SampleShift {
            get {
                object obj = ResourceManager.GetObject("SampleShift", resourceCulture);
                return ((byte[])(obj));
            }
        }
    }
}
