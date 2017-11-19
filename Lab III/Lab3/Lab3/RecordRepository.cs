using System;
using System.Collections.Generic;
using System.Linq;
using EnsureThat;

namespace Lab3
{
    public class RecordRepository
    {
        private ICollection<Record> recordsList;

        public RecordRepository(ICollection<Record> recordsList)
        {
            EnsureArg.IsGte(recordsList.Count, 3);
            this.recordsList = recordsList;
        }

        public Record GetRecordByTitle(string recordTitle)
        {
            EnsureArg.IsNotNullOrWhiteSpace(recordTitle);
            return recordsList.FirstOrDefault(r => r.Title == recordTitle);
        }

        public IEnumerable<Record> FindFutureRecords()
        {
            return recordsList.Where(r => r.StartDate > DateTime.Now);
        }


        public void AddRecord(Record record)
        {
            EnsureArg.IsNotNull(record);
            recordsList.Add(record);
        }


        public Record GetRecordByPosition(int position)
        {
            EnsureArg.IsInRange(position, 0, recordsList.Count - 1);
 
            return recordsList.ElementAt(position);
        }

        public void RemoveRecordsWithTitle(string recordTitle)
        {
            EnsureArg.IsNotNullOrWhiteSpace(recordTitle);

            var recordsContainingTitle = recordsList.Where(r => r.Title == recordTitle);
            foreach (var record in recordsContainingTitle.ToList())
                recordsList.Remove(record);
        }

        public IEnumerable<Record> GetExpiredRecords()
        {
            return recordsList.Where(r => r.EndDate < DateTime.Now);
        }

        public int GetCount()
        {
            return recordsList.Count;
        }
    }
}