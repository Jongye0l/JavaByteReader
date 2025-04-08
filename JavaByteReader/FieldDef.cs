using System.Collections.Generic;

namespace JavaByteReader;

public class FieldDef : Field {
    public override Class Class { get; set; }
    public override string Name { get; set; }
    public override string Descriptor { get; set; }
    public ushort AccessFlags { get; set; }
    public List<CustomAttribute> CustomAttributes { get; } = [];
}