using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ndmt.Model
{
    public interface IKnitterState
    {
        /// <summary>
        /// 发送Action:Restart使JC5 Network Driver重新启动
        /// </summary>
        void Restart();

        /// <summary>
        /// 发送Action:Reset使JC5 Network Driver重置
        /// </summary>
        void Reset();

        /// <summary>
        /// 改变当前状态为IDLE
        /// </summary>
        void Ready();

        /// <summary>
        /// 挂载USB设备
        /// </summary>
        void MountExStorage();

        /// <summary>
        /// 通过FTP装载花纹样式文件
        /// </summary>
        void FlushAndLoadPatternEP();

        /// <summary>
        /// 卸载USB设备
        /// </summary>
        void UnmountExStorage();

        /// <summary>
        /// 数据库记录开始时间或结束时间
        /// </summary>
        void LogEventTime();


    }
}
