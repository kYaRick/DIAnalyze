using System;
using Xunit;

using kYaTestSpace;
using System.Diagnostics;

namespace testspace.test
{
    public class MyFileReaderTest
    {
        [Fact]
        public void ItShouldReturnFullPath()
        {
            //Arrange
            string filePath = "mytestpath";
            string fileName = "log.txt";
            string expected = filePath+"\\"+fileName;

            //Act
            MyFileReader.FileName = fileName;
            MyFileReader.FilePath = filePath;
            string result = MyFileReader.GetFullPath();

            //Assert
            Assert.Equal(expected, result, ignoreCase: true);
            Debug.WriteLine("Ttt");
        }
    }
}
