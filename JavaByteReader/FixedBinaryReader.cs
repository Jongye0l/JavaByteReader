using System;
using System.IO;

namespace JavaByteReader;

public class FixedBinaryReader : IDisposable {
    private Stream _stream;
    private byte[] _buffer = new byte[8];

    public FixedBinaryReader(Stream stream) {
        _stream = stream;
    }

    public byte ReadByte() {
        if(_stream.Read(_buffer, 0, 1) != 1) throw new EndOfStreamException();
        return _buffer[0];
    }

    public ushort ReadUInt16() {
        if(_stream.Read(_buffer, 0, 2) != 2) throw new EndOfStreamException();
        return (ushort) (_buffer[0] << 8 | _buffer[1]);
    }

    public uint ReadUInt32() {
        if(_stream.Read(_buffer, 0, 4) != 4) throw new EndOfStreamException();
        return (uint) (_buffer[0] << 24 | _buffer[1] << 16 | _buffer[2] << 8 | _buffer[3]);
    }

    public ulong ReadUInt64() {
        if(_stream.Read(_buffer, 0, 8) != 8) throw new EndOfStreamException();
        return (ulong) _buffer[0] << 56 | (ulong) _buffer[1] << 48 | (ulong) _buffer[2] << 40 | (ulong) _buffer[3] << 32 |
               (uint) _buffer[4] << 24 | (uint) (_buffer[5] << 16) | (uint) (_buffer[6] << 8) | _buffer[7];
    }

    public sbyte ReadSByte() {
        if(_stream.Read(_buffer, 0, 1) != 1) throw new EndOfStreamException();
        return (sbyte) _buffer[0];
    }

    public short ReadInt16() {
        if(_stream.Read(_buffer, 0, 2) != 2) throw new EndOfStreamException();
        return (short) (_buffer[0] << 8 | _buffer[1]);
    }

    public int ReadInt32() {
        if(_stream.Read(_buffer, 0, 4) != 4) throw new EndOfStreamException();
        return _buffer[0] << 24 | _buffer[1] << 16 | _buffer[2] << 8 | _buffer[3];
    }

    public long ReadInt64() {
        if(_stream.Read(_buffer, 0, 8) != 8) throw new EndOfStreamException();
        return (long) _buffer[0] << 56 | (long) _buffer[1] << 48 | (long) _buffer[2] << 40 | (long) _buffer[3] << 32 |
               (uint) _buffer[4] << 24 | (uint) (_buffer[5] << 16) | (uint) (_buffer[6] << 8) | _buffer[7];
    }

    public float ReadSingle() {
        if(_stream.Read(_buffer, 0, 4) != 4) throw new EndOfStreamException();
        Array.Reverse(_buffer, 0, 4);
        return BitConverter.ToSingle(_buffer, 0);
    }

    public double ReadDouble() {
        if(_stream.Read(_buffer, 0, 8) != 8) throw new EndOfStreamException();
        Array.Reverse(_buffer, 0, 8);
        return BitConverter.ToDouble(_buffer, 0);
    }

    public byte[] ReadBytes(int count) {
        byte[] bytes = new byte[count];
        int read = 0;
        while(read < count) {
            int result = _stream.Read(bytes, read, count - read);
            if(result == 0) throw new EndOfStreamException();
            read += result;
        }
        return bytes;
    }

    public string ReadUTF(int length) {
        byte[] bytes = ReadBytes(length);
        return System.Text.Encoding.UTF8.GetString(bytes);
    }

    public int Read(byte[] data, int offset, int count) {
        return _stream.Read(data, offset, count);
    }

    public decimal ReadDecimal() {
        return new decimal([
            ReadInt32(),
            ReadInt32(),
            ReadInt32(),
            ReadInt32()
        ]);
    }

    public void Dispose() {
        _stream.Dispose();
    }
}