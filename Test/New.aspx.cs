using RoadBook.CsharpBasic.Chapter10.Examples.Manager;
using RoadBook.CsharpBasic.Chapter10.Examples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoadBook.CsharpBasicChapter10.Web.Board
{
    public partial class New : System.Web.UI.Page
    {
        private int m_iIdx;

        protected void Page_Load(object sender, EventArgs e)
        {
            m_iIdx = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseInfo dbInfo = new DatabaseInfo();
                MsSqlManager ms = new MsSqlManager();

                dbInfo.Name = "RoadbookDB";
                dbInfo.Ip = "127.0.0.1";
                dbInfo.Port = 1433;
                dbInfo.UserId = "sa";
                dbInfo.UserPassword = "1";

                ms = new MsSqlManager();
                ms.Open(dbInfo);

                StringBuilder sbSQL = new StringBuilder();
                sbSQL.Append(" INSERT TB_CONTENTS ( TITLE, SUMMARY, CREATE_DT, CREATE_USER_NM, TAGS, CATEGORY_IDX ) ");
                sbSQL.Append(
                    string.Format(" VALUES( '{0}', '{1}', '{2}', '{3}', '{4}', '{5}' )",
                        txtTitle.Text,
                        txtSummary.Text,
                        DateTime.Now.ToString("yyyy-MM-dd"),
                        txtUserNm.Text,
                        txtTags.Text,
                        2
                    )
                );

                ms.Insert(sbSQL.ToString());

                Response.Redirect("Default.aspx");
            }
            catch
            { }
        }//btnSave_Click

        protected void btnAlt_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Default.aspx");
            }
            catch
            { }
        }//btnAlt_Click

        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Default.aspx");
            }
            catch
            { }
        }//btnDel_Click

    }//class
}//namespace