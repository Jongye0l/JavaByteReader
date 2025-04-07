namespace JavaByteReader;

public class FieldRef : Field {
    public override Class Class { get; set; }
    public override UTF8String Name { get; set; }
    public override UTF8String Descriptor { get; set; }
}