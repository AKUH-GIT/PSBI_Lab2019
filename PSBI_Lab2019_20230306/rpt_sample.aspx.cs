using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;

public partial class rpt_sample : System.Web.UI.Page
{
    private int m_currentPageIndex;
    private IList<Stream> m_streams;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                LinkButton lnkUser = (LinkButton)FindControl("usernme");
                lnkUser.Text = "Welcome: " + HttpContext.Current.Request["mycookie"].ToString();
                lnkUser.CssClass = "dropdown-toggle nav-link";
                lnkUser = null;

                ReportViewer1.Visible = false;
            }
        }
    }


    private DataSet GetData()
    {
        DataSet ds = null;

        try
        {
            CConnection cn = new CConnection();
            SqlDataAdapter da = new SqlDataAdapter("select " +
"b.AS1_screening_ID,"+
"b.AS1_rand_id,"+
"b.AS1_name,"+
"b.AS1_sex,"+
"b.AS1_age,"+
"b.AS1_barcode,"+
"b.AS1_mrno,"+
"b.AS1_lno,"+
"b.AS1_barcode1,"+
"b.AS1_fsite,"+
"b.AS1_Samp_1,"+
"b.AS1_Samp_2,"+
"b.AS1_Samp_3,"+
"b.AS1_Samp_4,"+
"b.AS1_Q1_1,"+
"b.AS1_Q1_2,"+
"b.AS1_Q2_1,"+
"b.AS1_Q2_2,"+
"b.AS1_Q3,"+
"b.AS1_Q3a_1,"+
"b.AS1_Q3a_2,"+
"b.AS1_Q4,"+
"b.AS1_Q5,"+
"b.AS1_Q6,"+
"b.AS1_Q6a,"+
"b.AS1_Q6b,"+
"b.AS1_Q6c,"+
"b.AS2_Q7_1,"+
"b.AS2_Q7_2,"+
"b.AS2_Q7_CBC_CODE,"+
"b.AS2_Q8,"+
"b.AS2_Q8_BacT,"+
"b.AS2_Q8_3,"+
"b.AS2_Q8a,"+
"b.AS2_Q9,"+
"b.AS2_Q10,"+
"b.AS2_Q11,"+
"b.AS2_Q12_1,"+
"b.AS2_Q12_2,"+
"b.AS2_Q12_3,"+
"b.AS2_Q12_4,"+
"b.AS2_Q13,"+
"b.AS2_Q13a,"+
"b.AS3_Q14,"+
"b.AS3_Q14a,"+
"b.AS3_Q15,"+
"b.AS3_Q16,"+
"b.AS3_Q17,"+
"b.AS3_Q18,"+
"b.AS3_Q19,"+
"b.AS3_Q20,"+
"b.AS4_Q21a,"+
"b.AS4_Q22a,"+
"b.AS4_Q22b,"+
"b.AS4_Q23,"+
"b.AS4_Q24,"+
"b.AS5_Q25a,"+
"b.AS5_Q25b,"+
"b.AS5_Q26,"+
"b.AS5_Q27,"+
"b.AS5_Q28,"+
"b.AS5_Q29,"+
"b.AS5_Q30,"+
"b.AS5_Q31,"+
"b.AS5_Q32,"+
"b.AS5_Q33a,"+
"b.AS5_Q33b,"+
"b.AS3_Remarks,"+
"b.AS6_Q34,"+
"b.AS6_Q35,"+
"b.AS6_Q36,"+
"b.AS6_Q37,"+
"b.AS6_Q38,"+
"b.AS6_Q39,"+
"b.AS6_Q40,"+
"b.AS6_Q41,"+
"b.AS6_Q42,"+
"b.AS6_Q43,"+
"b.AS6_Q44,"+
"b.AS6_Q45,"+
"b.AS6_Q46,"+
"b.AS6_Q47,"+
"b.AS5_R1,"+
"b.AS3_A1,"+
"b.AS3_A2,"+
"b.AS3_B1,"+
"b.AS3_B2,"+
"a.la_sno,"+
"a.LA_01,"+
"a.LA_02,"+
"a.LA_03_b,"+
"a.LA_03_a,"+
"a.LA_04_b,"+
"a.LA_04_a,"+
"a.LA_05_b,"+
"a.LA_05_a,"+
"a.LA_06_b,"+
"a.LA_06_a,"+
"a.LA_07_b,"+
"a.LA_07_a,"+
"a.LA_08_b,"+
"a.LA_08_a,"+
"a.LA_09_b,"+
"a.LA_09_a,"+
"a.LA_10_b,"+
"a.LA_10_a,"+
"a.LA_11_b,"+
"a.LA_11_a,"+
"a.LA_12_b,"+
"a.LA_12_a,"+
"a.LA_13_b,"+
"a.LA_13_a,"+
"a.LA_14_b,"+
"a.LA_14_a,"+
"a.LA_15_b,"+
"a.LA_15_a,"+
"a.LA_16_b,"+
"a.LA_16_a,"+
"a.LF_01,"+
"a.LF_01_a,"+
"a.LF_02,"+
"a.LF_02_a,"+
"a.LF_03,"+
"a.LF_03_a,"+
"a.LF_04,"+
"a.LF_04_a,"+
"a.LF_05,"+
"a.LF_05_a,"+
"a.LF_06,"+
"a.LF_06_a,"+
"a.LF_07,"+
"a.LF_07_a,"+
"a.RF_01,"+
"a.RF_01_a,"+
"a.RF_02,"+
"a.RF_02_a,"+
"a.RF_03,"+
"a.RF_03_a,"+
"a.RF_04,"+
"a.RF_04_a,"+
"a.SE_01,"+
"a.SE_01_a,"+
"a.SE_02,"+
"a.SE_02_a,"+
"a.SE_03,"+
"a.SE_03_a,"+
"a.SE_04,"+
"a.SE_04_a,"+
"a.CS_01,"+
"a.CS_01_a,"+
"a.CS_02,"+
"a.CS_02_a,"+
"a.CS_03,"+
"a.CS_03_a,"+
"a.CS_04,"+
"a.CS_04_a,"+
"a.CS_05,"+
"a.CS_05_a,"+
"a.CS_06,"+
"a.CS_06_a,"+
"a.CS_07,"+
"a.CS_07_a,"+
"a.CS_08,"+
"a.CS_08_a,"+
"a.CS_09,"+
"a.CS_09_a,"+
"a.CS_10,"+
"a.CS_10_a,"+
"a.UR_01,"+
"a.UR_01_a,"+
"a.UR_02,"+
"a.UR_02_a,"+
"a.UR_03,"+
"a.UR_03_a,"+
"a.UR_04,"+
"a.UR_04_a,"+
"a.UR_04a,"+
"a.UR_04a_a,"+
"a.UR_05,"+
"a.UR_05_a,"+
"a.UR_06,"+
"a.UR_06_a,"+
"a.UR_07,"+
"a.UR_07_a,"+
"a.UR_08,"+
"a.UR_08_a,"+
"a.UR_10,"+
"a.UR_10_a,"+
"a.UR_11,"+
"a.UR_11_a,"+
"a.UR_12,"+
"a.UR_12_a,"+
"a.UR_13,"+
"a.UR_13_a,"+
"a.UR_14,"+
"a.UR_14_a,"+
"a.UR_15,"+
"a.UR_15_a,"+
"a.UR_16,"+
"a.UR_16_a,"+
"a.UR_17,"+
"a.UR_17_a,"+
"a.UR_18,"+
"a.UR_18_a,"+
"a.UR_19,"+
"a.UR_19_a,"+
"a.UR_20,"+
"a.UR_20_a,"+
"a.UR_21,"+
"a.UR_21_a,"+
"a.uc_01_ca,"+
"case when a.uc_01a = 1 then 'Uropathogen Isolated' when a.uc_01a = 2 then 'No Uropathogen Isolated' when a.uc_01a = 999 then 'NA' end uc_01a,"+
"a.uc_02a,"+
"a.uc_02a_a,"+
"a.uc_02b,"+
"a.uc_03a,"+
"a.uc_03a_a,"+
"a.uc_03b,"+
"a.uc_04a,"+
"a.uc_04a_a,"+
"a.uc_04b,"+
"a.uc_05a,"+
"a.uc_05a_a,"+
"a.uc_05b,"+
"a.uc_06a,"+
"a.uc_06a_a,"+
"a.uc_06b,"+
"a.uc_07a,"+
"a.uc_07a_a,"+
"a.uc_07b,"+
"a.uc_08a,"+
"a.uc_08a_a,"+
"a.uc_08b,"+
"a.uc_09a,"+
"a.uc_09a_a,"+
"a.uc_09b,"+
"a.uc_10a,"+
"a.uc_10a_a,"+
"a.uc_10b,"+
"a.uc_11a,"+
"a.uc_11a_a,"+
"a.uc_11b,"+
"a.uc_12a,"+
"a.uc_12a_a,"+
"a.uc_12b,"+
"a.uc_13a,"+
"a.uc_13a_a,"+
"a.uc_13b,"+
"a.uc_14a,"+
"a.uc_14a_a,"+
"a.uc_14b,"+
"a.uc_15a,"+
"a.uc_15a_a,"+
"a.uc_15b,"+
"a.uc_16a,"+
"a.uc_16a_a,"+
"a.uc_16b,"+
"a.uc_17a,"+
"a.uc_17a_a,"+
"a.uc_17b,"+
"a.uc_18a,"+
"a.uc_18a_a,"+
"a.uc_18b,"+
"a.uc_19a,"+
"a.uc_19a_a,"+
"a.uc_19b,"+
"a.uc_20a,"+
"a.uc_20a_a,"+
"a.uc_20b,"+
"a.uc_21a,"+
"a.uc_21a_a,"+
"a.uc_21b,"+
"a.uc_22a,"+
"a.uc_22a_a,"+
"a.uc_22b,"+
"a.uc_23a,"+
"a.uc_23a_a,"+
"a.uc_23b,"+
"a.uc_24a,"+
"a.uc_24a_a,"+
"a.uc_24b,"+
"a.uc_25a,"+
"a.uc_25a_a,"+
"a.uc_25b,"+
"a.uc_26a,"+
"a.uc_26a_a,"+
"a.uc_26b,"+
"a.uc_27a,"+
"a.uc_27a_a,"+
"a.uc_27b,"+
"a.uc_28a,"+
"a.uc_28a_a,"+
"a.uc_28b,"+
"a.uc_29a,"+
"a.uc_29a_a,"+
"a.uc_29b,"+
"a.uc_30a,"+
"a.uc_30a_a,"+
"a.uc_30b,"+
"a.uc_31a,"+
"a.uc_31a_a,"+
"a.uc_31b,"+
"a.uc_32a,"+
"a.uc_32a_a,"+
"a.uc_32b,"+
"a.uc_33a,"+
"a.uc_33a_a,"+
"a.uc_33b,"+
"a.uc_34a,"+
"a.uc_34a_a,"+
"a.uc_34b,"+
"a.uc_35a,"+
"a.uc_35a_a,"+
"a.uc_35b,"+
"a.uc_36a,"+
"a.uc_36a_a,"+
"a.uc_36b,"+
"a.uc_37a,"+
"a.uc_37a_a,"+
"a.uc_37b,"+
"a.LA_17,"+
"a.LA_18,"+
"a.LA_19,"+
"a.LA_20a_b,"+
"a.LA_20a_a,"+
"a.LA_20b_a,"+
"a.LA_21a_b,"+
"a.LA_21a_a,"+
"a.LA_21b_a,"+
"a.LA_22a_b,"+
"a.LA_22a_a,"+
"a.LA_22b_a,"+
"a.LA_23a_b,"+
"a.LA_23a_a,"+
"a.LA_23b_a,"+
"a.LA_24a_b,"+
"a.LA_24a_a,"+
"a.LA_24b_a,"+
"a.LA_25a_b,"+
"a.LA_25a_a,"+
"a.LA_25b_a,"+
"a.LA_26a_b,"+
"a.LA_26a_a,"+
"a.LA_26b_a,"+
"a.LA_27a_b,"+
"a.LA_27a_a,"+
"a.LA_27b_a,"+
"a.LA_28a_b,"+
"a.LA_28a_a,"+
"a.LA_28b_a,"+
"a.LA_29a_b,"+
"a.LA_29a_a,"+
"a.LA_29b_a,"+
"a.LA_30a_b,"+
"a.LA_30a_a,"+
"a.LA_30b_a,"+
"a.LA_31a_b,"+
"a.LA_31a_a,"+
"a.LA_31b_a,"+
"a.LA_32a_b,"+
"a.LA_32a_a,"+
"a.LA_32b_a,"+
"a.LA_33a_b,"+
"a.LA_33a_a,"+
"a.LA_33b_a,"+
"a.LA_34a_b,"+
"a.LA_34a_a,"+
"a.LA_34b_a,"+
"a.LA_35a_b,"+
"a.LA_35a_a,"+
"a.LA_35b_a,"+
"a.LA_36a_b,"+
"a.LA_36a_a,"+
"a.LA_36b_a,"+
"a.LA_37a_b,"+
"a.LA_37a_a,"+
"a.LA_37b_a,"+
"a.LA_38a_b,"+
"a.LA_38a_a,"+
"a.LA_38b_a,"+
"a.LA_39a_b,"+
"a.LA_39a_a,"+
"a.LA_39b_a,"+
"a.LA_40a_b,"+
"a.LA_40a_a,"+
"a.LA_40b_a,"+
"a.LA_41a_b,"+
"a.LA_41a_a,"+
"a.LA_41b_a,"+
"a.LA_42a_b,"+
"a.LA_42a_a,"+
"a.LA_42b_a,"+
"a.LA_43a_b,"+
"a.LA_43a_a,"+
"a.LA_43b_a,"+
"a.LA_44a_b,"+
"a.LA_44a_a,"+
"a.LA_44b_a,"+
"a.LA_45a_b,"+
"a.LA_45a_a,"+
"a.LA_45b_a,"+
"a.LA_46a_b,"+
"a.LA_46a_a,"+
"a.LA_46b_a,"+
"a.LA_47a_b,"+
"a.LA_47a_a,"+
"a.LA_47b_a,"+
"a.LA_48a_b,"+
"a.LA_48a_a,"+
"a.LA_48b_a,"+
"a.LA_49a_b,"+
"a.LA_49a_a,"+
"a.LA_49b_a,"+
"a.LA_50a_b,"+
"a.LA_50a_a,"+
"a.LA_50b_a,"+
"a.LA_51a_b,"+
"a.LA_51a_a,"+
"a.LA_51b_a,"+
"a.LA_52a_b,"+
"a.LA_52a_a,"+
"a.LA_52b_a" + 
            " from sample_result a inner join form1 b on a.la_sno = b.AS1_screening_ID where a.la_sno = '" + AS1_screening_ID.Text + "' and b.userid='usernrl'", cn.cn);
            ds = new DataSet();
            da.Fill(ds);
        }

        catch (Exception ex)
        {

        }

        finally
        {

        }

        return ds;
    }


    protected void lnk_logout_Click(object sender, EventArgs e)
    {
        Session.Remove("UserID");
        Session.Abandon();
        Response.Redirect("login.aspx");
    }

    protected void cmdSave_Click(object sender, EventArgs e)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("rpt_Sample.rdlc");
        DataSet ds = GetData();
        ReportDataSource datasource = new ReportDataSource("ds", ds.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(datasource);

        ReportViewer1.Visible = true;
    }


    private Stream CreateStream(string name,
          string fileNameExtension, Encoding encoding,
          string mimeType, bool willSeek)
    {
        Stream stream = new MemoryStream();
        m_streams.Add(stream);
        return stream;
    }
    // Export the given report as an EMF (Enhanced Metafile) file.
    private void Export(LocalReport report)
    {
        string deviceInfo =
          @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.25in</MarginLeft>
                <MarginRight>0.25in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
            </DeviceInfo>";
        Warning[] warnings;
        m_streams = new List<Stream>();
        report.Render("Image", deviceInfo, CreateStream,
           out warnings);
        foreach (Stream stream in m_streams)
            stream.Position = 0;
    }
    // Handler for PrintPageEvents
    private void PrintPage(object sender, PrintPageEventArgs ev)
    {
        Metafile pageImage = new
           Metafile(m_streams[m_currentPageIndex]);

        // Adjust rectangular area with printer margins.
        Rectangle adjustedRect = new Rectangle(
            ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
            ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
            ev.PageBounds.Width,
            ev.PageBounds.Height);

        // Draw a white background for the report
        ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

        // Draw the report content
        ev.Graphics.DrawImage(pageImage, adjustedRect);

        // Prepare for the next page. Make sure we haven't hit the end.
        m_currentPageIndex++;
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
    }

    private void Print()
    {
        if (m_streams == null || m_streams.Count == 0)
            throw new Exception("Error: no stream to print.");
        PrintDocument printDoc = new PrintDocument();
        if (!printDoc.PrinterSettings.IsValid)
        {
            throw new Exception("Error: cannot find the default printer.");
        }
        else
        {
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            m_currentPageIndex = 0;
            printDoc.Print();
        }
    }
    // Create a local report for Report.rdlc, load the data,
    //    export the report to an .emf file, and print it.
    private void Run()
    {
        //LocalReport report = new LocalReport();
        //report.ReportPath = @"..\..\Report.rdlc";
        //report.DataSources.Add(
        //   new ReportDataSource("Sales", LoadSalesData()));

        Export(ReportViewer1.LocalReport);
        Print();
    }

    public void Dispose()
    {
        if (m_streams != null)
        {
            foreach (Stream stream in m_streams)
                stream.Close();
            m_streams = null;
        }
    }



    public class Demo : IDisposable
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        private DataTable LoadSalesData()
        {
            // Create a new DataSet and read sales data file 
            //    data.xml into the first DataTable.
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"..\..\data.xml");
            return dataSet.Tables[0];
        }
        // Routine to provide to the report renderer, in order to
        //    save an image for each page of the report.
        private Stream CreateStream(string name,
          string fileNameExtension, Encoding encoding,
          string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.25in</MarginLeft>
                <MarginRight>0.25in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }
        // Create a local report for Report.rdlc, load the data,
        //    export the report to an .emf file, and print it.
        public void Run(LocalReport report)
        {
            //LocalReport report = new LocalReport();
            //report.ReportPath = @"..\..\Report.rdlc";
            //report.DataSources.Add(
            //   new ReportDataSource("Sales", LoadSalesData()));

            Export(report);
            Print();
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

    }

    protected void cmdPrint_Click(object sender, EventArgs e)
    {
        Run();
    }
}