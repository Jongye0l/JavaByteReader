namespace JavaByteReader;

public abstract class Class {
    public abstract UTF8String Name { get; set; }
    public abstract ClassDef ToDef();
}