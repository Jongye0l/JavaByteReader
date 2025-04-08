using System;

namespace JavaByteReader.Attribute.Data;

struct ElementValue {
    public ElementTag tag;
    public object value;

    public ElementValue(ElementTag tag, object value) {
        this.tag = tag;
        this.value = value;
    }

    public ElementValue(FixedBinaryReader reader) {
        tag = (ElementTag) reader.ReadByte();
        switch(tag) {
            case ElementTag.Byte:
                value = reader.ReadByte();
                break;
            case ElementTag.Char:
                value = reader.ReadChar();
                break;
            case ElementTag.Double:
                value = reader.ReadDouble();
                break;
            case ElementTag.Float:
                value = reader.ReadSingle();
                break;
            case ElementTag.Int:
                value = reader.ReadInt32();
                break;
            case ElementTag.Long:
                value = reader.ReadInt64();
                break;
            case ElementTag.Short:
            case ElementTag.String:
            case ElementTag.Class:
                value = reader.ReadInt16();
                break;
            case ElementTag.Boolean:
                value = reader.ReadBoolean();
                break;
            case ElementTag.EnumConst:
                value = new EnumConstValue(reader);
                break;
            case ElementTag.Annotation:
                value = new Annotation(reader);
                break;
            case ElementTag.Array:
                ElementValue[] elementValues = new ElementValue[reader.ReadInt16()];
                for(int i = 0; i < elementValues.Length; i++) elementValues[i] = new ElementValue(reader);
                value = elementValues;
                break;
            default:
                throw new NotImplementedException($"ElementValue tag {tag} not implemented.");
        }
    }
}