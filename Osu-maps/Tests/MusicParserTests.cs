using System;
using Osu_maps.Class;
using Osu_maps.CustomException;
using Osu_maps.Interfaces;
using Xunit;

namespace Osu_maps.Tests
{
    public class MusicParserTests
    {
        [Fact]
        public void Constructor_ShouldThrowException_WhenFilenameIsEmpty()
        {
            string emptyFilename = string.Empty;

            // Act & Assert
            var exception = Assert.Throws<ParserInitException>(() => new BaseMusicParser(emptyFilename));
            Assert.Equal("No filename provided", exception.Message);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenInvalidFileExtension()
        {
            string invalidFilename = "song.txt";

            // Act & Assert
            var exception = Assert.Throws<ParserInitException>(() => new BaseMusicParser(invalidFilename));
            Assert.Equal("Invalid file Extension : song.txt", exception.Message);
        }

        [Fact]
        public void Constructor_ShouldNotThrowException_WhenValidFilename()
        {
            string validFilename = "song.mp3";

            // Act
            var musicParser = new BaseMusicParser(validFilename);

            // Assert
            Assert.NotNull(musicParser);
            Assert.Equal(validFilename, musicParser.Filename);
        }

        [Fact]
        public void ParseFile_ShouldThrowException_WhenOnBaseClass()
        {
            string validFilename = "song.mp3";

            // Act
            var musicParser = new BaseMusicParser(validFilename);

            // Assert
            var exception = Assert.Throws<NotImplementedException>(() => musicParser.ParseFile());
            Assert.Equal("ParseFile must be implemented in a derived class.", exception.Message);
        }

        [Fact]
        public void Mp3Parser_Init()
        {
            string validFilename = "song.mp3";

            var musicParser = new Mp3Parser(validFilename);

            Assert.NotNull(musicParser);
        }

        [Fact]
        public void WavParser_Init()
        {
            string validFilename = "song.wav";

            var musicParser = new WavParser(validFilename);

            Assert.NotNull(musicParser);
        }
    }
}
