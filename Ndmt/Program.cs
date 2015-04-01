using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace Ndmt
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*
            // 界面汉化
            DevExpress.XtraGrid.Localization.GridResLocalizer.Active = new Dxper.LocalizationCHS.Win.XtraGridCHS();
            DevExpress.XtraEditors.Controls.Localizer.Active = new Dxper.LocalizationCHS.Win.XtraEditorsCHS();
            //DevExpress.XtraCharts.Localization.ChartResLocalizer.Active = new Dxper.LocalizationCHS.Win.XtraChartsCHS();
            //DevExpress.XtraBars.Localization.BarLocalizer.Active = new Dxper.LocalizationCHS.Win.XtraBars();
            DevExpress.XtraLayout.Localization.LayoutLocalizer.Active = new Dxper.LocalizationCHS.Win.XtraLayoutCHS();
            DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new Dxper.LocalizationCHS.Win.XtraPrintingCHS();
            //DevExpress.XtraTreeList.Localization.TreeListResLocalizer.Active = new Dxper.LocalizationCHS.Win.XtraTreeListCHS();
            //DevExpress.Office.Localization.OfficeResLocalizer.Active = new Dxper.LocalizationCHS.Win.OfficeCHS();
            //DevExpress.XtraSpreadsheet.Localization.XtraSpreadsheetLocalizer.Active = new Dxper.LocalizationCHS.Win.XtraSpreadsheetCHS();

            //DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
             */
            DevExpress.Xpo.XpoDefault.DataLayer = DevExpress.Xpo.XpoDefault.GetDataLayer(
                global::Ndmt.Properties.Settings.Default.ConnectionString,
                DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);

            frmLogin authentication = new frmLogin();
            if (authentication.ShowDialog() == DialogResult.OK)//frmLogin窗体中点击登录按钮后才判断成功
            {
                // 运行主界面
                Application.Run(new frmKnitterManagement());
            }
            else
                Application.Exit();
        }
    }
}
