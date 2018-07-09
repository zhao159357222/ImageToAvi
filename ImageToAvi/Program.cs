using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using System.IO;

namespace ImageToAvi
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = DateTime.Now.ToString("yyyyMMddhhmmss");
            Console.WriteLine("开始生成...");
            
            using (VideoWriter videoWriter = new VideoWriter("c:\\test_" + name + ".avi"
                , VideoWriter.FourCC('M', 'J', 'P', 'G')
                , 1//每秒播放帧数
                , new Size(800, 600), true))//视频大小
            {

                string filePath = System.AppDomain.CurrentDomain.BaseDirectory;
                DirectoryInfo directoryInfo = new DirectoryInfo(filePath + "\\image");

                var filePathList = directoryInfo.GetFiles();

                foreach (var item in filePathList)
                {
                    Mat tempCCv = Cv2.ImRead(item.FullName);
                    Mat result = new Mat();
                    Cv2.Resize(tempCCv, result, new Size(800, 600));//必须将图片的大小调整为视频的大小
                    //插入4帧相同的图片
                    videoWriter.Write(result);
                    videoWriter.Write(result);
                    videoWriter.Write(result);
                    videoWriter.Write(result);
                }
                videoWriter.Release();
                Cv2.DestroyAllWindows();
            }

            Console.Write("生成完成！路径c:\\test_" + name + ".avi，建议使用Windows Media Player播放");
            Console.Read();
        }
    }
}
