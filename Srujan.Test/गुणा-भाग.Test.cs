using System.Diagnostics;

namespace Srujan.Test
{
    [TestClass]
    public class गुणाभागTest
    {
        [TestMethod]
        public void Test_Addition_Prints_Correct_Result()
        {
            // Arrange
            var fileName = "गुणाभाग.सृ";
            var expected = "137478.381";

            // Get a stream that we can use writer and reader on
            var stream = new MemoryStream();
            var textWriter = new StreamWriter(stream);

            // Act
            Process process = new Process();

            // Configure the process using StartInfo
            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = $"/c Srujan.exe {fileName}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;

            // Start the process
            process.Start();

            // Read standard output synchronously
            string output = process.StandardOutput.ReadToEnd();

            // Wait for the process to exit
            process.WaitForExit();

            // Assert
            Assert.AreEqual(expected, output);
        }
    }
}