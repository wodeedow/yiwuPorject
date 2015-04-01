using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.Office.Core;
//using Microsoft.Office.Interop.Excel;

namespace Ndmt.Model
{
    public class ExcelHelper
    {
        private const string commandString = @"insert into [WUP].[dbo].[Shift]([ddh],[jt],[wdh],[bh],[dh],[llsj]) values (@ddh,@jt,@wdh,@bh,@dh,@llsj)";
        private const string clearupString = @"truncate table [WUP].[dbo].[Shift];";
        private const int testNum = 698;

        public static void ReloadSampleShift(string fileName)
        {
           /*
#if (DEBUG)
            string connectonString = global::Ndmt.Properties.Settings.Default.ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectonString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = clearupString;
                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }

            // 此行若报错，引用属性中"嵌入互操作类型"改成"false"
            ApplicationClass xlsApp = new ApplicationClass();
            if (xlsApp == null)
            {
                //对此实例进行验证，如果为null则表示运行此代码的机器可能未安装Excel
                //MessageBox.Show("Excel编程环境出错"); LogHelper
            }
            else
            {
                xlsApp.Visible = false;
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectonString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = commandString;

                SqlParameter param_ddh = new SqlParameter("@ddh", SqlDbType.Char, 9);
                SqlParameter param_jt = new SqlParameter("@jt", SqlDbType.VarChar, 3);
                SqlParameter param_wdh = new SqlParameter("@wdh", SqlDbType.NVarChar, 255);
                SqlParameter param_bh = new SqlParameter("@bh", SqlDbType.NVarChar, 255);
                SqlParameter param_dh = new SqlParameter("@dh", SqlDbType.NVarChar, 255);
                SqlParameter param_llsj = new SqlParameter("@llsj", SqlDbType.VarChar, 16);  //若类型为Time，可使用TimeSpan

                command.Parameters.Add(param_ddh);
                command.Parameters.Add(param_jt);
                command.Parameters.Add(param_wdh);
                command.Parameters.Add(param_bh);
                command.Parameters.Add(param_dh);
                command.Parameters.Add(param_llsj);
                sqlConnection.Open();

                Workbook workbook = xlsApp.Workbooks.Open(fileName);
                Worksheet shift = workbook.Sheets[1] as Worksheet;

                for (int i = 0; i < testNum; i++)
                {
                    param_ddh.Value = (shift.Cells[i + 2, 1] as Range).Text;    // "130529105"
                    param_jt.Value = (shift.Cells[i + 2, 2] as Range).Text;     // "212"
                    param_wdh.Value = (shift.Cells[i + 2, 3] as Range).Text;    // "13KA0251"
                    param_bh.Value = (shift.Cells[i + 2, 4] as Range).Text;     // "13KA0251.EP"
                    param_dh.Value = (shift.Cells[i + 2, 5] as Range).Text;     // "原(S/P)"
                    param_llsj.Value = (shift.Cells[i + 2, 6] as Range).Text;   //
                    command.ExecuteNonQuery();
                }

                workbook.Close();
                sqlConnection.Close();
            }
#endif
            * */
        }
    }
}
