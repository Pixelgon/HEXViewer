using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Zadejte adresu souboru, kterou chcete zobrazit: ");

        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("Soubor neexistuje");
            return;
        }

        using (FileStream fs = new FileStream(filename, FileMode.Open))
        {
            int offset = 0;
            byte[] buffer = new byte[16];

            while (fs.Read(buffer, 0, buffer.Length) > 0)
            {
                Console.Write("{0:X8} ", offset);

                for (int i = 0; i < 16; i++)
                {
                    if (i < buffer.Length)
                    {
                        Console.Write("{0:X2} ", buffer[i]);
                    }
                    else
                    {
                        Console.Write("");
                    }

                    if (i == 7)
                    {
                        Console.Write("");
                    }
                }

                Console.Write("");

                for (int i = 0; i < buffer.Length; i++)
                {
                    if (i < buffer.Length)
                    {
                        byte b = buffer[i];

                        if (b < 32 || b > 127)
                        {
                            Console.Write(".");
                        }
                        else
                        {
                            Console.Write((char)b);
                        }
                    }
                }

                Console.WriteLine();

                offset += 16;
            }
        }
    }
}
