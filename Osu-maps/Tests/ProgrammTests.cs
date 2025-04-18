using System;
using System.IO;
using Xunit;
using Osu_maps;
using Osu_maps.Class;
using Osu_maps.CustomException;

namespace Osu_maps.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Test_ProcessMusicFile_With_ValidMp3File()
        {
            // Act
            var result = Program.Main(new string[] { "--music", "hello.mp3" });

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_ProcessMusicFile_With_ValidWavFile()
        {
            // Act
            var result = Program.Main(new string[] { "--music", "hello.wav" });

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_ProcessMusicFile_With_InvalidFileType()
        {
            // Act
            var result = Program.Main(new string[] { "--music", "hello.txt" });

            // Assert
            Assert.Equal(84, result);
        }

        [Fact]
        public void Test_Main_With_NoMusicProvided()
        {
            // Arrange
            string[] args = new string[] { };

            // Redirecting the console output to capture it in the test
            using (var sw = new StringWriter())
            {
                Console.SetError(sw);

                // Act
                int exitCode = Program.Main(args);

                // Assert
                Assert.Equal(84, exitCode);
                Assert.Contains("No music file provided, use -m or --music", sw.ToString());
            }
        }
    }
}
