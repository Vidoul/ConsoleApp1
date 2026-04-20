using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static string entryfolder = @"C:\Users\Vince\source\repos\Vidoul\ConsoleApp1\ExoOptimisation\images\";
    static string exitfolderSeq = @"C:\Users\Vince\source\repos\Vidoul\ConsoleApp1\ExoOptimisation\images\ConvertImages_Seq\";
    static string exitfolderPar = @"C:\Users\Vince\source\repos\Vidoul\ConsoleApp1\ExoOptimisation\images\ConvertImages_Par\";
    static int[] heights = { 480, 720, 1080 };

    static async Task Main()
    {
        Directory.CreateDirectory(exitfolderSeq);
        Directory.CreateDirectory(exitfolderPar);

        var sw1 = Stopwatch.StartNew();
        RunSequential();
        sw1.Stop();
        Console.WriteLine($"\nWITHOUT OPTIMISATION : {sw1.ElapsedMilliseconds} ms\n");

        var sw2 = Stopwatch.StartNew();
        await RunParallelAsync();
        sw2.Stop();
        Console.WriteLine($"\nWITH OPTIMISATION    : {sw2.ElapsedMilliseconds} ms\n    ");
    }

    static void RunSequential()
    {
        foreach (string file in Directory.GetFiles(entryfolder, "*.jpg"))
        {
            Bitmap src = new Bitmap(file);
            string name = Path.GetFileNameWithoutExtension(file);

            Console.WriteLine($"File Name : {name}");

            foreach (int h in heights)
            {
                int w = src.Width * h / src.Height;
                Bitmap dst = new Bitmap(src, w, h);
                dst.Save(Path.Combine(exitfolderSeq, $"{name}_{h}p.jpg"), ImageFormat.Jpeg);
                Console.WriteLine($"Convert File Name : ${name}_{h}p.jpg");
                dst.Dispose();
            }
            src.Dispose();
        }
    }

    static async Task RunParallelAsync()
    {
        await Task.Run(() =>
        {
            Parallel.ForEach(Directory.GetFiles(entryfolder, "*.jpg"), file =>
            {
                Bitmap src = new Bitmap(file);
                string name = Path.GetFileNameWithoutExtension(file);

                Console.WriteLine($"File Name : {name}");

                foreach (int h in heights)
                {
                    int w = src.Width * h / src.Height;
                    Bitmap dst = new Bitmap(src, w, h);
                    dst.Save(Path.Combine(exitfolderPar, $"{name}_{h}p.jpg"), ImageFormat.Jpeg);
                    Console.WriteLine($"Convert File Name : ${name}_{h}p.jpg");
                    dst.Dispose();
                }
                src.Dispose();
            });
        });
    }
}