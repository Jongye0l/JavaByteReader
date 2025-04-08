using System.Collections.Generic;
using JavaByteReader.AccessFlags;

namespace JavaByteReader;

public class FieldDef : Field {
    public override Class Class { get; set; }
    public override string Name { get; set; }
    public override string Descriptor { get; set; }
    public FieldAccessFlags AccessFlags { get; set; }
    public List<JavaAttribute> CustomAttributes { get; } = [];
}