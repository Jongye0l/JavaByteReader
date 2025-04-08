namespace JavaByteReader.Attribute.Data;

struct ParameterAnnotation {
    public Annotation[] annotations;

    public ParameterAnnotation(Annotation[] annotations) {
        this.annotations = annotations;
    }

    public ParameterAnnotation(FixedBinaryReader reader) {
        ushort numAnnotations = reader.ReadUInt16();
        annotations = new Annotation[numAnnotations];
        for(int i = 0; i < numAnnotations; i++) annotations[i] = new Annotation(reader);
    }
}