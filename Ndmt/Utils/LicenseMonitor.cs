using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using License;
using DevExpress.Utils.About;

namespace Ndmt.Utils
{
    public sealed class LicenseMonitor//阻止其他类从该类继承
    {
        /// <summary>
        /// 静态构造
        /// </summary>
        static LicenseMonitor()
        {
            if( singleton == null)
                singleton = new LicenseMonitor();
        }

        /// <summary>
        /// 强制初始化
        /// </summary>
        public static void Init()
        {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private LicenseMonitor()
        {
            this.licenseInfomation = new Dictionary<string, string>();
            ReadAdditonalLicenseInformation();
        }

        /// <summary>
        /// 唯一实例
        /// </summary>
        public static LicenseMonitor CurrentLicense
        {
            get { return singleton; }
        }

        /// <summary>
        /// Additional License Information
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key]
        {
            get {
                if (this.licenseInfomation.ContainsKey(key))//确定 Dictionary<TKey, TValue> 是否包含指定的键
                    return this.licenseInfomation[key];
                else
                    return TRIAL_VERSION_STRING;
            }
        }

        /// <summary>
        /// Additional License Information
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public string this[Properties prop]
        {
            get { return this[prop.ToString()]; }
        }

        /// <summary>
        /// 证书是否有效
        /// </summary>
        /// <returns></returns>
        public bool IsValidLicenseAvailable
        {
            get { return License.Status.Licensed; }
        }

        /// <summary>
        /// 读取license文件中的Additonal License Information
        /// </summary>
        private void ReadAdditonalLicenseInformation()
        {
            if (License.Status.Licensed)
            {
                for (int i = 0; i < License.Status.KeyValueList.Count; i++)
                {
                    string key = License.Status.KeyValueList.GetKey(i).ToString();
                    string value = License.Status.KeyValueList.GetByIndex(i).ToString();
                    this.licenseInfomation.Add(key, value);
                }
            }
        }

        #region 未处理
        /// <summary>
        /// 检查证书过期时间
        /// </summary>
        public void CheckExpirationDateLock()
        {
            bool lock_enabled = License.Status.Expiration_Date_Lock_Enable;
            System.DateTime expiration_date = License.Status.Expiration_Date;
        }


        /// <summary>
        /// 检查软件使用次数
        /// </summary>
        public void CheckNumberOfUsesLock()
        {
            bool lock_enabled = License.Status.Number_Of_Uses_Lock_Enable;
            int max_uses = License.Status.Number_Of_Uses;
            int current_uses = License.Status.Number_Of_Uses_Current;
        }

        /// <summary>
        /// 检查程序实例个数
        /// </summary>
        public void CheckNumberOfInstancesLock()
        {
            bool lock_enabled = License.Status.Number_Of_Instances_Lock_Enable;
            int max_instances = License.Status.Number_Of_Instances;
        }

        /// <summary>
        /// 检查硬件ID锁定
        /// </summary>
        public void CheckHardwareLock()
        {
            bool lock_enabled = License.Status.Hardware_Lock_Enabled;

            if (lock_enabled)
            {
                /* Get Hardware ID which is stored inside the license file */
                string lic_hardware_id = License.Status.License_HardwareID;
            }
        }

        /// <summary>
        /// 对比当前硬件ID与证书中硬件ID是否匹配
        /// </summary>
        /// <returns></returns>
        public bool CompareHardwareID()
        {
            if (License.Status.HardwareID == License.Status.License_HardwareID)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Invalidate the license. Please note, your protected software does not accept a license file anymore!
        /// </summary>
        public void InvalidateLicense()
        {
            string confirmation_code = License.Status.InvalidateLicense();
        }

        /// <summary>
        /// Check if a confirmation code is valid
        /// </summary>
        /// <param name="confirmation_code"></param>
        /// <returns></returns>
        public bool CheckConfirmationCode(string confirmation_code)
        {
            return License.Status.CheckConfirmationCode(License.Status.HardwareID, confirmation_code);
        }

        /// <summary>
        /// Reactivate an invalidated license.
        /// </summary>
        /// <param name="reactivation_code"></param>
        /// <returns></returns>
        public bool ReactivateLicense(string reactivation_code)
        {
            return License.Status.ReactivateLicense(reactivation_code);
        }

        /// <summary>
        /// Load the license.
        /// </summary>
        /// <param name="filename">license file</param>
        public void LoadLicense(string filename)
        {
            License.Status.LoadLicense(filename);
        }

        /// <summary>
        /// Load the license.
        /// </summary>
        /// <param name="license">license stream</param>
        public void LoadLicense(byte[] license)
        {
            License.Status.LoadLicense(license);
        }

        /// <summary>
        /// Get the license.
        /// </summary>
        /// <returns>lincense stream</returns>
        public byte[] GetLicense()
        {
            return License.Status.License;
        }

        #endregion

        /// <summary>
        /// 单例
        /// </summary>
        private static LicenseMonitor singleton;//singleton 单键模式,就是一个类只允许一次实例化

        /// <summary>
        /// Addition License Information
        /// </summary>
        private Dictionary<string, string> licenseInfomation;
        //Dictionary<string, string>是一个泛型,他本身有集合的功能,有时候可以把它看成数组结构是这样的：Dictionary<[key], [value]>

        /// <summary>
        /// 试用版提示
        /// </summary>
        public const string TRIAL_VERSION_STRING = "[Trial Version]";

        /// <summary>
        /// Addition License Information字段
        /// </summary>
        public enum Properties
        {
            Company,
            SNPrefix
        }
    }
}
