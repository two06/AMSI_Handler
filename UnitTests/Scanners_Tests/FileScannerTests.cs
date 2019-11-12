using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scanners;
using UnitTests.Helpers;

namespace UnitTests.Scanners_Tests
{
    [TestClass]
    public class FileScannerTests
    {
        [TestMethod]
        public void CorrectLine_IsFlagged_WhenMalwarePresent_OnOneLine()
        {
            //arange
            var scanner = new FileScanner();
            var sample1 = @"X5O!P%@AP[4\PZX54(P^)7CC)7}$EIC";
            var sample2 = @"AR-STANDARD-ANTIVIRUS-TEST-FILE!$H+H*";

            var testString = RandomData.RandomMultiLineString(5, 10);
            testString += sample1 + sample2 + Environment.NewLine;
            testString += RandomData.RandomMultiLineString(2, 10);

            //act
            var detections = scanner.ScanFile(testString);

            //assert
            Assert.AreEqual(1, detections.Count, "Wrong number of lines detected.");
            Assert.AreEqual(6, detections.First(), "Wrong line detected.");
        }

        [TestMethod]
        public void CorrectLines_AreFlagged_WhenMalwarePresent_MultiLine()
        {
            //arange
            var scanner = new FileScanner();
            var sample1 = @"X5O!P%@AP[4\PZX54(P^)7CC)7}$EIC";
            var sample2 = @"AR-STANDARD-ANTIVIRUS-TEST-FILE!$H+H*";

            var testString = RandomData.RandomMultiLineString(5, 10);
            testString += sample1 + sample2 + Environment.NewLine;
            testString += RandomData.RandomMultiLineString(2, 10);
            testString += sample1 + sample2 + Environment.NewLine;
            testString += RandomData.RandomMultiLineString(2, 10);

            //act
            var detections = scanner.ScanFile(testString);

            //assert
            Assert.AreEqual(2, detections.Count, "Wrong number of lines detected.");
            Assert.AreEqual(6, detections.First(), "Wrong line detected.");
            Assert.AreEqual(9, detections.Skip(1).Take(1).First(), "Wrong line deteceted");
        }

        [TestMethod]
        public void NoLines_AreDetected_WhenMalwareNotPresent()
        {
            //arange
            var scanner = new FileScanner();
            
            var testString = RandomData.RandomMultiLineString(5, 10);

            //act
            var detections = scanner.ScanFile(testString);

            //assert
            Assert.AreEqual(0, detections.Count, "Wrong number of lines detected.");
        }
    }
}
