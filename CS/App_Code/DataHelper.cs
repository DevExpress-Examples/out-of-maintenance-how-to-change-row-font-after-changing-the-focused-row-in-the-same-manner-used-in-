using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class DataHelper {
	static List<Model> _data { get {
			if(HttpContext.Current.Session["data"] == null)
				HttpContext.Current.Session["data"] = GenerateData();

			return (List<Model>)HttpContext.Current.Session["data"];
		}
	}
	public static List<Model> Data {
		get { return _data; }		
	}
	private static List<Model> GenerateData() {
		var list = Enumerable.Range(0, 10).Select(x => new Model {
			Oid = x,
			IsRead = (x != 3 && x != 5) ? false : true,
			Title = "Title" + x,
			Message = "Message" + x
		}).ToList();
		return list;
	}
	public static void MakeAllUnread() {		
		foreach(var item in Data) {
			item.IsRead = false;
		}		
	}
	public static void MarkAsRead(int ID) {		
		Data.Find(x => x.Oid == ID).IsRead = true;		
	}
}