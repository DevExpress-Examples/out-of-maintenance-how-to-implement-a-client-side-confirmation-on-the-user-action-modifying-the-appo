using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

public class ResourceDataSourceHelper {
    public ResourceDataSourceHelper() {  }

    public static List<CustomResource> GetCustomResources() {
        List<CustomResource> list = new List<CustomResource>();
        list.Add(new CustomResource() { Caption = "Resource 1", Color = Color.LightCoral, ResourceId = 1 });
        list.Add(new CustomResource() { Caption = "Resource 2", Color = Color.LightGreen, ResourceId = 2 });
        list.Add(new CustomResource() { Caption = "Resource 3", Color = Color.LightYellow, ResourceId = 3 });

        return list;
    }
}

public class CustomResource {
    public CustomResource() { }

    public string Caption { get; set; }
    public Color Color { get; set; }
    public int ResourceId { get; set; }
}
