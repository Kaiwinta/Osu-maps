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
    }
}
