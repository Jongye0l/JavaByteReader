using System.IO;
using JavaByteReader.Constants;

namespace JavaByteReader;

public class CustomAttribute {
    public UTF8String Name { get; set; }
    public byte[] data;

    internal CustomAttribute(BinaryReader reader, Constant[] constants) {
        ushort nameIndex = reader.ReadUInt16();
        Name = ((ConstantUTF8) constants[nameIndex]).data;
        uint length = reader.ReadUInt32();
        if(length > int.MaxValue) throw new InvalidDataException("Attribute length is too long.");
        data = new byte[length];
        if(reader.Read(data, 0, (int) length) != length) throw new EndOfStreamException();
    }

    public CustomAttribute() {

    }
}