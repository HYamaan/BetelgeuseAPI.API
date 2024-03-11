using BetelgeuseAPI.Domain.Common;

public class BlogCategories : BaseEntity
{
    private string _title;
    private string _slug;
    private int _type;

    public BlogCategories()
    {
        Status = false;
    }

    public string Slug
    {
        get { return _slug; }
        set { _slug = value; }
    }

    public string Title
    {
        get { return _title; }
        set
        {
            _title = value;
            Slug = value.ToLower();
        }
    }

    public int Type 
    {
        get { return _type; }
        set { _type = value; }
    }

    public string SubTitle { get; set; }

    public bool Status { get; set; } = false;
}