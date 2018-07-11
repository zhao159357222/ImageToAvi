需求：传入几张图片，可将图片生成为一个视频，要求视频中图片在切换是会带有一些转场效果（例如渐隐，翻页等）。
技术方案：可能能实现的方式有以下技术可选.
Ffmpeg
Avifil32.dll
Python + opencv
Emgucv

最终选型：
目前选用的是opencv，使用的是opencv来实现，采用第三方提供的nuget包opencvsharp+C#实现。
opencvsharp的开源地址：https://github.com/shimat/opencvsharp
opencvsharp的文档地址：https://shimat.github.io/opencvsharp_docs/index.html

幻灯片渐变的效果python实现：https://blog.csdn.net/sh39o/article/details/79585191

代码位置：https://github.com/zhao159357222/ImageToAvi

开发建议：由于网上很多代码都是opencv+python的示例，因此可通过opencv python 来检索相关内容，然后依据python的代码逻辑来编写相关的C#
