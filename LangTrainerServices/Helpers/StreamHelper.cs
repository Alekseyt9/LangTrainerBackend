

namespace LangTrainerServices.Helpers
{
    public static class StreamHelper
    {
        public static byte[] ToBytes(this Stream stream)
        {
            var buffer = new byte[16 * 1024];
            using var ms = new MemoryStream();
            int read;
            while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }

        public static byte[] GetMd5Hash(this byte[] arr)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            md5.TransformFinalBlock(arr, 0, arr.Length);
            return md5.Hash;
        }

    }
}
