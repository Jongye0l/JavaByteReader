using System.Collections.Generic;
using JavaByteReader.AccessFlags;

namespace JavaByteReader;

public class MethodDef : Method {
    public MethodAccessFlags AccessFlags;
    public override string Name { get; set; }
    public string Descriptor;
    public List<JavaAttribute> CustomAttributes = [];
}