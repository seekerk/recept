/*
 * Created by SharpDevelop.
 * User: kirill
 * Date: 23.10.2009
 * Time: 12:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Recept2
{
    /// <summary>
    /// Настройки формирования отчета.
    /// </summary>
    public partial class PanelConfigReport : UserControl
    {
        public PanelConfigReport()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            LoadData(Config.Cfg);
        }
        
        public PanelConfigReport(Config cfg)
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            LoadData(cfg);
        }
        
        public void LoadData(Config cfg)
        {
            
            tbUseCounts.Text = Config.BindingListToString(cfg.ReportUseCounts);
            tbUseExits.Text = Config.BindingListToString(cfg.ReportUseExits);
            cbIsShowOriginal.Checked = cfg.ReportIsShowOriginal;
            cbShowConfig.Checked = cfg.ReportShowConfig;
        }
        
        public void StoreData(Config cfg)
        {
            Config.StringToBindingList(cfg.ReportUseCounts, tbUseCounts.Text);
            Config.StringToBindingList(cfg.ReportUseExits, tbUseExits.Text);
            cfg.ReportIsShowOriginal = cbIsShowOriginal.Checked;
            cfg.ReportShowConfig = cbShowConfig.Checked;
        }
    }
}
