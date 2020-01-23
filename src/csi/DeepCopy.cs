﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

//MG
namespace csi
{
    class DeepCopy
    {
        public static Matrix Copy(Matrix source)
        {
            if (!typeof(Matrix).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", nameof(source));
            }

            if (ReferenceEquals(source, null))
            {
                return default;
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (Matrix)formatter.Deserialize(stream);
            }
        }
    }
}
