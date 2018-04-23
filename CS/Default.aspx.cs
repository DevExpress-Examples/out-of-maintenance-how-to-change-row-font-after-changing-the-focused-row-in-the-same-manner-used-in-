using System;
using DevExpress.Web.ASPxGridView;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
		if(!IsPostBack)
			Session.Clear();
		
		grid.DataSource = DataHelper.Data;
		grid.DataBind();
	}

    protected void grid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        bool isRead = Convert.ToBoolean(grid.GetRowValues(e.VisibleIndex, "IsRead"));
        e.Row.Font.Bold = !isRead;
    }
    protected void grid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
		if(e.Parameters == "Unread")
			DataHelper.MakeAllUnread();        
    }
    protected void grid_FocusedRowChanged(object sender, EventArgs e)
    {
		var index = (grid.FocusedRowIndex != -1) ? grid.FocusedRowIndex : 0;
		var id = Convert.ToInt32(grid.GetRowValues(index, "Oid"));
		DataHelper.MarkAsRead(id);		
    }
}
