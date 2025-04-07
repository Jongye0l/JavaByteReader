using System.Collections.Generic;

namespace JavaByteReader;

public class MethodDef : Method {
    public ushort AccessFlags;
    public UTF8String Name;
    public UTF8String Descriptor;
    public List<CustomAttribute> CustomAttributes = [];
}