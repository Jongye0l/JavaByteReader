using System;
using System.Text;

namespace JavaByteReader;

public sealed class UTF8String : IEquatable<UTF8String>, IComparable<UTF8String> {
    private object data;

    public string Value {
        get {
            if(data is string str) return str;
            byte[] bytes = (byte[]) data;
            return (string) (data = Encoding.UTF8.GetString(bytes));
        }
    }

    public bool Equals(UTF8String other) => other != null && Value == other.Value;

    public int CompareTo(UTF8String other) => other == null ? 1 : string.Compare(Value, other.Value, StringComparison.Ordinal);

    public UTF8String(byte[] data) {
        this.data = data;
    }

    public UTF8String(string data) {
        this.data = data;
    }

    public override string ToString() {
        return Value;
    }
}