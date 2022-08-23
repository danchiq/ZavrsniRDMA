using System;
using System.Diagnostics;


public class User
{
	public User()
	{
		public string id_user { get; set; }
	    public string email { get; set; }
	public string create_time { get; set; }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
}
