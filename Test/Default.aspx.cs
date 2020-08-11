using RoadBook.CsharpBasic.Chapter10.Examples.Manager;
using RoadBook.CsharpBasic.Chapter10.Examples.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoadBook.CsharpBasicChapter10.Web.Board
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DatabaseInfo dbInfo = new DatabaseInfo();
                dbInfo.Name = "RoadbookDB";
                dbInfo.Ip = "127.0.0.1";
                dbInfo.Port = 1433;
                dbInfo.UserId = "sa";
                dbInfo.UserPassword = "1";

                MsSqlManager ms = new MsSqlManager();
                ms.Open(dbInfo);

                DataTable dt = ms.Select("SELECT IDX, TITLE, SUMMARY, CREATE_DT, CREATE_USER_NM, TAGS, LIKE_CNT, CATEGORY_IDX FROM TB_CONTENTS");
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch
            {

            }
        }//Page_Load
    }//class
}//namespace