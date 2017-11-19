using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Lab3;
using LabIProject.Test;
using Xunit;
using Record = Lab3.Record;

namespace Lab3Tests
{
    public class RecordRepositoryTest : BaseTest<RecordRepository>
    {
        private readonly ICollection<Record> recordsListMock = new List<Record>
        {
            Record.Create("Title", DateTime.Now.AddDays(3), DateTime.Now.AddDays(10), 2),
            Record.Create("RecorTitle", DateTime.Now.Subtract(new TimeSpan(1, 0, 0)),
                DateTime.Now.Subtract(new TimeSpan(1, 0, 0)), 7),
            Record.Create("RecorderTitle", DateTime.Now.AddDays(1), DateTime.Now.AddDays(6), 121)
        };

        protected override RecordRepository SetupSystemUnderTest()
        {
            return new RecordRepository(recordsListMock);
        }

        [Fact]
        public void Given_AddRecord_When_GoodRecordIsPassed_ThenListCountShouldBeGreater()
        {
            var newRecord = Record.Create("alb", DateTime.Now, DateTime.Now.AddDays(1), 10);

            var oldCount = recordsListMock.Count;
            SystemUnderTest.AddRecord(newRecord);
            var result = recordsListMock.Count;

            result.Should().Be(oldCount + 1);
        }

        [Fact]
        public void Given_AddRecord_When_NullRecordIsPassed_Then_ShouldThrowArgumentException()
        {
            Action result = () => { SystemUnderTest.AddRecord(null); };

            result.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Given_FindFutureRecords_When_ListWithTwoFutureRecordsIsPassed_ThenShouldReturnTwoRecords()
        {
            var futureRecords = SystemUnderTest.FindFutureRecords();

            var result = futureRecords.Count();

            result.Should().Be(recordsListMock.Count - 1);
        }

        [Fact]
        public void Given_GetExpiredRecords_When_ListWithOneExpiredRecordIsPassed_ThenShouldReturnOneRecord()
        {
            var expiredRecords = SystemUnderTest.GetExpiredRecords();

            var result = expiredRecords.Count();

            result.Should().Be(1);
        }

        [Fact]
        public void Given_GetRecordByPosition_When_RecordInRangeIsPassed_Then_ShouldreturnRecordAtIndex()
        {
            var result = SystemUnderTest.GetRecordByPosition(recordsListMock.Count - 1);
            var recordAtIndex = recordsListMock.ElementAt(recordsListMock.Count - 1);
            result.Should().Be(recordAtIndex);
        }


        [Fact]
        public void Given_GetRecordByPosition_When_RecordOutOfRangeIsPassed_Then_ShouldThrowIndexOutOfRangeException()
        {
            Action result = () => { SystemUnderTest.GetRecordByPosition(recordsListMock.Count); };

            result.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Given_GetRecordByTitle_WhenPassedExistingTitle_ThenShouldReturnARecord()
        {
            var recordTitle = "Title";

            var result = SystemUnderTest.GetRecordByTitle(recordTitle);

            result.Should().NotBeNull();
        }

        [Fact]
        public void Given_GetRecordByTitle_WhenPassedNotExistingTitle_ThenShouldReturnNull()
        {
            var recordTitle = "agsah";

            var result = SystemUnderTest.GetRecordByTitle(recordTitle);

            result.Should().BeNull();
        }

        [Fact]
        public void Given_GetRecordByTitle_WhenPassedNull_ThenShouldThrowException()
        {
            Action result = () => { SystemUnderTest.GetRecordByTitle(null); };

            result.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Given_GetRecordByTitle_WhenPassedWhiteSpace_ThenShouldThrowException()
        {
            Action result = () => { SystemUnderTest.GetRecordByTitle(" "); };

            result.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Given_GRemoveRecordsWithTitle_WhenPassedWhiteSpace_ThenShouldThrowException()
        {
            Action result = () => { SystemUnderTest.RemoveRecordsWithTitle(" "); };

            result.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Given_RemoveRecordsWithTitle_When_RecordNameNotFoundIsPassed_Then_RemoveNothing()
        {
            var oldCount = recordsListMock.Count;

            SystemUnderTest.RemoveRecordsWithTitle("aasdasd");

            var result = recordsListMock.Count;

            result.Should().Be(oldCount);
        }

        [Fact]
        public void Given_RemoveRecordsWithTitle_When_ValidRecordIsPassed_Then_RemoveRecord()
        {
            var oldCount = recordsListMock.Count;

            SystemUnderTest.RemoveRecordsWithTitle(recordsListMock.ElementAt(0).Title);

            var result = recordsListMock.Count;

            result.Should().Be(oldCount - 1);
        }


        [Fact]
        public void Given_RemoveRecordsWithTitle_WhenPassedNull_ThenShouldThrowException()
        {
            Action result = () => { SystemUnderTest.RemoveRecordsWithTitle(null); };

            result.ShouldThrow<ArgumentException>();
        }
    }
}