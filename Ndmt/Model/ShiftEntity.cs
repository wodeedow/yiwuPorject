using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using Ndmt;

namespace Ndmt.Model
{
    /// <summary>
    /// 订单排版实体
    /// </summary>
    [Persistent("Shift")]
    public class ShiftEntity : XPCustomObject
    {
        //一个持久类，一般来说映射为一个表类型，该表的每一条记录即一个持久类的实例。
        public static readonly string DisplayableProperties;

        public ShiftEntity()
            : base(Session.DefaultSession)
        {
            // remain empty
        }

        public ShiftEntity(Session session)
            : base(session)
        {
            // remain empty
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Add init code here
        }

        /// <summary>
        /// XPInstantFeedbackSource构造使用的显示属性
        /// </summary>
        static ShiftEntity()
        {
            try
            {
                IEnumerable<string> enumString = from prop in  (Properties[]) Enum.GetValues(typeof(Properties))
                                      select prop.ToString();
                DisplayableProperties = String.Join(";", enumString.ToArray<string>());
                //DisplayableProperties=ID;ShiftID;KnitterFriendlyName;PatternName;DocumentName;SizeName;StartTime;FinishTime;FinishTimeExpected  
            }
            catch (Exception err)
            {
                LogHelper.LogHere("GeneralException",err.Message);
            }
        }

        /// <summary>
        /// 排班表字段描述
        /// </summary>
        public enum Properties : int
        {
            ID = 0,                    // 自增主键ID
            ShiftID = 1,               // 订单号
            KnitterFriendlyName = 2,   // 机台
            PatternName = 3,           // 文档号
            DocumentName = 4,          // 版号
            SizeName = 5,              // 代号
            StartTime = 6,             // 开始时间
            FinishTime = 7,            // 结束时间
            FinishTimeExpected = 8,    // 理论时间
        }

        [Persistent("id"),Key]//强制持久化
        private Int32 _id = 0;
        [PersistentAlias("_id")]
        public Int32 ID
        {
            get { return _id; }
        }

        [Persistent("ddh")]
        private String _ddh = String.Empty;
        [PersistentAlias("_ddh")]
        public String ShiftID
        {
            get { return _ddh; }
            //set { SetPropertyValue<String>("ShiftID", ref _ddh, value); }
        }

        [Persistent("jt")]
        private String _jt = String.Empty;
        [PersistentAlias("_jt")]
        public String KnitterFriendlyName
        {
            get { return _jt; }
            //set { SetPropertyValue<String>("KnitterFriendlyName", ref _jt, value); }
        }

        [Persistent("wdh")]
        private String _wdh = String.Empty;
        [PersistentAlias("_wdh")]
        public String PatternName
        {
            get { return _wdh; }
            //set { SetPropertyValue<String>("PatternName", ref _wdh, value); }
        }

        [Persistent("bh")]
        private String _bh = String.Empty;
        [PersistentAlias("_bh")]
        public String DocumentName
        {
            get { return _bh; }
            //set { SetPropertyValue<String>("DocumentName", ref _bh, value); }
        }

        [Persistent("dh")]
        private String _dh = String.Empty;
        [PersistentAlias("_dh")]
        public String SizeName
        {
            get { return _dh; }
            //set { SetPropertyValue<String>("SizeName", ref _dh, value); }
        }

        [Persistent("kssj")]
        private DateTime _kssj;
        [PersistentAlias("_kssj")]
        public DateTime StartTime
        {
            get { return _kssj; }
            set { SetPropertyValue<DateTime>("StartTime", ref _kssj, value); }
        }

        [Persistent("jssj")]
        private DateTime _jssj;
        [PersistentAlias("_jssj")]
        public DateTime FinishTime
        {
            get { return _jssj; }
            set { SetPropertyValue<DateTime>("FinishTime", ref _jssj, value); }
        }

        [Persistent("llsj")]
        private String _llsj = String.Empty;
        [PersistentAlias("_llsj")]
        public String FinishTimeExpected
        {
            get { return _llsj; }
            //set { SetPropertyValue<String>("FinishTimeExpected", ref _llsj, value); }
        }

        /// <summary>
        /// 重载索引器以访问内部数据
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public Object this[Properties prop]
        {
            get
            {
                return typeof(ShiftEntity).GetProperty(prop.ToString()).GetValue(this, null);
            }
            set
            {
                //Convert.ChangeType(value, typeof(ShiftEntity).GetProperty(prop.ToString()).PropertyType);
                typeof(ShiftEntity).GetProperty(prop.ToString()).SetValue(this, value, null);
            }
        }
    }
}