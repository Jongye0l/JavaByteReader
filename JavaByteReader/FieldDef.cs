using System.Collections.Generic;

namespace JavaByteReader;

public class FieldDef : Field {
    public override Class Class { get; set; }
    public override UTF8String Name { get; set; }
    public override UTF8String Descriptor { get; set; }
    public ushort AccessFlags { get; set; }
    public List<CustomAttribute> CustomAttributes { get; } = [];
}