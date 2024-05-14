namespace Srujan.Test
{
    [TestClass]
    public class गुणाभागTest
    {
        [TestMethod]
        public void Test_Addition_Prints_Correct_Result()
        {
            // Arrange
            var text = "अंक प्रवेश () { एक: दशमलव  = 1374783.8128; दो: दशमलव = 10.0; दिखाएँ एक / दो; }";
            var expected = "10";

            // Get a stream that we can use writer and reader on
            var stream = new MemoryStream();
            var textWriter = new StreamWriter(stream);

            // Act
            new CompileAndRun().CompileAndRunCode(text, textWriter);

            // read all text from memory stream
            textWriter.Flush();
            stream.Position = 0;
            var reader = new StreamReader(stream);
            var actual = reader.ReadToEnd();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}