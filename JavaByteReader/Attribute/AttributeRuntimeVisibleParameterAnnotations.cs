using JavaByteReader.Attribute.Data;

namespace JavaByteReader.Attribute;

class AttributeRuntimeVisibleParameterAnnotations : JavaAttribute {
    public const string AttributeName = "RuntimeVisibleParameterAnnotations";
    public ParameterAnnotation[] parameterAnnotations;

    public AttributeRuntimeVisibleParameterAnnotations(ParameterAnnotation[] parameterAnnotations) {
        this.parameterAnnotations = parameterAnnotations;
    }

    public AttributeRuntimeVisibleParameterAnnotations(FixedBinaryReader reader) {
        ushort numParameters = reader.ReadUInt16();
        parameterAnnotations = new ParameterAnnotation[numParameters];
        for(int i = 0; i < numParameters; i++) parameterAnnotations[i] = new ParameterAnnotation(reader);
    }

    public override string Name => AttributeName;
}