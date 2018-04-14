using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter faculty number");
            String fNumber = Console.ReadLine();
            Console.WriteLine("Enter file name number");
            String fileName = Console.ReadLine();
            String certificate = StudentData.PrepareCertificate(fNumber);
            Console.WriteLine(certificate);
            StudentData.SaveCertificate(certificate, fileName);

            Console.ReadLine();
        }
    }
}
