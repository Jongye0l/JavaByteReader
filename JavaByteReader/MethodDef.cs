using System.Collections.Generic;

namespace JavaByteReader;

public class MethodDef : Method {
    public ushort AccessFlags;
    public override string Name { get; set; }
    public string Descriptor;
    public List<CustomAttribute> CustomAttributes = [];
}