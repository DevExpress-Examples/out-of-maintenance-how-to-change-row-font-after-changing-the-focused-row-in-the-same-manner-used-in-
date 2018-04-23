using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxCallback;
using DevExpress.Web.ASPxGridView;
using DevExpress.Xpo;

public partial class _Default : System.Web.UI.Page
{
    Session session = XpoHelper.GetNewSession();

    protected void Page_Init(object sender, EventArgs e)
    {
        xpoDS.Session = session;
    }

    protected void grid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        bool isRead = Convert.ToBoolean(grid.GetRowValues(e.VisibleIndex, "IsRead"));
        e.Row.Font.Bold = !isRead;
    }
    protected void grid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        if (e.Parameters == "Unread")
        {
            MyObject obj = null;
            for (int i = 0; i < grid.VisibleRowCount; i++)
            {
                obj = grid.GetRow(i) as MyObject;
                obj.IsRead = false;
                obj.Save();
            }

        }
    }
    protected void grid_FocusedRowChanged(object sender, EventArgs e)
    {
        MyObject obj = null;
        if (grid.FocusedRowIndex == -1)
            obj = grid.GetRow(0) as MyObject;
        else
            obj = grid.GetRow(grid.FocusedRowIndex) as MyObject;

        obj.IsRead = true;
        obj.Save();
    }
}
