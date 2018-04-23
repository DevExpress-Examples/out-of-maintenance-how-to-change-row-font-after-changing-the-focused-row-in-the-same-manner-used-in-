using System;
using DevExpress.Xpo;

public class MyObject : XPObject {
    public MyObject()
        : base() { }

    public MyObject(Session session)
        : base(session) { }

    public override void AfterConstruction() {
        base.AfterConstruction();
    }

    protected String _Title;
    public String Title {
        get { return _Title; }
        set { SetPropertyValue<String>("Title", ref _Title, value); }
    }

    protected String _Message;
    public String Message
    {
        get { return _Message; }
        set { SetPropertyValue<String>("Message", ref _Message, value); }
    }

    private Boolean _IsRead;
    public Boolean IsRead
    {
        get { return _IsRead; }
        set { SetPropertyValue("IsRead", ref _IsRead, value); }
    }
}

